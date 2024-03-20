using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MODULE.MOTION;
using BASE.FORM;
using BASE.MASTER;

namespace BASE.PROCESS
{
  public class ClassThread_Main
  {
    public static double dTime = 0;
    private static ClassThread_Main cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    private int iDelayCount = 10; // 메뉴얼 딜레이 카운트
    private int iManualDelay = 0; // 싸이클상태가 바로 Idle 로 바뀌어 버리는 경우가 있어 쓰레드를 한바퀴 더 돌리기 위해 이 딜레이를 사용

    protected ClassThread_Main()
    {
      Check_Thread();
    }

    public static ClassThread_Main Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_Main();
          }
        }
      }
      return cInstatnce;
    }

    public void Check_Thread()
    {
      if (th == null)
      {
        bThread = true;
        th = new Thread(Run);
        th.Start();
      }
    }

    public void Abort_Thread()
    {
      th.Abort();
      bThread = false;
      th = null;
    } // Kill All Thread

    private void Run()
    {
      while (bThread)
      {
        lock (this)
        {
          System.DateTime start = System.DateTime.Now;
          Thread.Sleep(1);
          #region PLC 데이터 갱신
          Refresh_PLC_Data();
          #endregion

          #region Alarm 처리
          Check_MotorStatus_LE();
          Check_MotorStatus_LP();
          Check_MotorStatus_BCX();
          Check_MotorStatus_BCY();
          Check_MotorStatus_ALX();
          Check_MotorStatus_ALY();
          Check_MotorStatus_X1();
          Check_MotorStatus_X2();
          Check_MotorStatus_Z1();
          Check_MotorStatus_Z2();
          Check_MotorStatus_PR1();
          Check_MotorStatus_PR2();
          Check_MotorStatus_PR3();
          Check_MotorStatus_PR4();
          Check_MotorStatus_UPX();
          Check_MotorStatus_UPY();
          Check_MotorStatus_UE1();
          Check_MotorStatus_UE2();
          Check_MotorStatus_UE3();
          Check_MotorStatus_UE4();


          int iErrorStartIndex = (int)enumError.B2140_AW_LE_Ready_Error;
          int iErrorEndIndex = (int)enumError.B24FF_;
          if (CVo.bLaptopTestMode == false)
          {
            for (int i = iErrorStartIndex; i <= iErrorEndIndex; i++)
            {
              if (CIoVo.Get_RB_Error((enumError)i))
              {
                CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
              }
            }
          }
          

          if (CVo.eMachineStatus == enumMachineStatus.Auto
           || CVo.eMachineStatus == enumMachineStatus.Cycle)
          {
            // 구동중 알람처리 여기서 함.
            Check_AutoRunError();
          }



          if (CVo.eMachineStatus == enumMachineStatus.Initial)
          {
            // 초기화중 에러발생
            int iStartIndex = (int)enumError.B2220_BH_Door_Open_Error_Home;
            int iEndIndex = (int)enumError.B223F_;
            for (int i = iStartIndex; i <= iEndIndex; i++)
            {
              if (CIoVo.Get_RB_Error((enumError)i))
              {
                CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
              }
            }
          }
          #endregion

          #region 입력 버튼 처리 관리
          switch (CVo.eVirtualBit)
          {
            case enumVirtualBit.Start:
              CVo.eVirtualBit = enumVirtualBit.None;
              Recovery();
              break;
            case enumVirtualBit.Stop:
              CVo.eVirtualBit = enumVirtualBit.None;
              Change_Stop();
              break;
            case enumVirtualBit.Init:
              CVo.eVirtualBit = enumVirtualBit.None;
              Change_Init();
              break;
            case enumVirtualBit.Reset:
              CVo.eVirtualBit = enumVirtualBit.None;
              Change_Reset();
              break;
            case enumVirtualBit.None:
            default:
              break;
          }
          #endregion

          #region 장비 상태 관리
          // 장비 구동 상태
          bool bRunning_All_Temp = false;;
          for (int i = 0; i < Enum.GetNames(typeof(enumFlagRunning)).Length; i++)
          {
            if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
            {
              bRunning_All_Temp = true;
              break;
            }
          }
          if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving)
          {
            bRunning_All_Temp = true;
          }
          if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving)
          {
            bRunning_All_Temp = true;
          }
          if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving)
          {
            bRunning_All_Temp = true;
          }
          if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving)
          {
            bRunning_All_Temp = true;
          }

          CVo.bRunning_All = bRunning_All_Temp;

          // UE까지 마지막 소재가 넘어갔는지 확인
          bool bPCBOut
              = CVo.bLELastOut
              && CVo.bUE1LastOut
              && CVo.bUE2LastOut
              && CVo.bUE3LastOut
              && CVo.bUE4LastOut;

          // 구동여부 확인
          bool bRunning_All = false;
          for (int i = 0; i < Enum.GetNames(typeof(enumFlagRunning)).Length; i++)
          {
            if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
            {
              bRunning_All = true;
              break;
            }
          }

          // 소재유무 확인 센서
          bool bLastPCBExist =
              CIoVo.Get_RB_Input(enumBitInput.B2030_Loading_Material_CheckSensor)
              || CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist)
              || CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist)
              || CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist)
              || CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist)
              || CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor);

          // 랏 엔드 확인
          if (CVo.eMachineStatus == enumMachineStatus.Auto
           && CVo.bLotEndWait
           && CVo.bRunningLE == false
           && CVo.bRunningUE1 == false
           && CVo.bRunningUE2 == false
           && CVo.bRunningUE3 == false
           && CVo.bRunningUE4 == false
           && CVo.bRunningLP == false
           && CVo.bRunningStage1 == false
           && CVo.bRunningStage2 == false
           && bLastPCBExist == false
           && bRunning_All == false
           && (bPCBOut || CVo.bLastPCBLost))
          {
            CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.LotEnd);
            CVo.bLotEndWait = false;
            CVo.bLotRunning = false;
            CVo.bLELastOut = false;
            CVo.bUE1LastOut = false;
            CVo.bUE2LastOut = false;
            CVo.bUE3LastOut = false;
            CVo.bUE4LastOut = false;
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
            {
              CVo.eMachineStatus = enumMachineStatus.Idle;
            }
            else
            {
              CVo.eMachineStatus = enumMachineStatus.Stop;
            }
            CVo.sTactTime_LotEnd = System.DateTime.Now;

            CVo.Save_Lot_Log();
            CVo.eAlarmWarn = enumAlarmWarn.LotEnd;
            CVo.bOnAlarmWarn = true;
          }

          if (CVo.bManualRun)
          {
            iManualDelay++;
          }
          else
          {
            iManualDelay = 0;
          }

          // 싸이클 동작 확인
          if (CVo.bManualRun)
          {
            int iStartIndex = (int)enumError.B2220_BH_Door_Open_Error_Home;
            int iEndIndex = (int)enumError.B24FF_;
            bool bError = false;
            for (int i = iStartIndex; i <= iEndIndex; i++)
            {
              if (CIoVo.Get_RB_Error((enumError)i))
              {
                CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
                bError = true;
              }
            }
            if (bError)
            {
              CVo.bManualRun = false;
            }

            if (CVo.eMachineStatus == enumMachineStatus.Cycle)
            {
              bool bRunningCycle
            = CVo.bRunningLE == false
           && CVo.bRunningUE1 == false
           && CVo.bRunningUE2 == false
           && CVo.bRunningUE3 == false
           && CVo.bRunningUE4 == false
           && CVo.bRunningLP == false
           && CVo.bRunningStage1 == false
           && CVo.bRunningStage2 == false;

              if (iDelayCount < iManualDelay && bRunningCycle)
              {
                bool bRunning = false;
                int iStartRunBit = (int)enumFlagRunning.B2080_LE_Homming;
                int iEndRunBit = (int)enumFlagRunning.B20DF_;
                for (int i = iStartRunBit; i < iEndRunBit; i++)
                {
                  if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
                  {
                    bRunning = true;
                  }
                }

                if (bRunning == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving == false)
                {
                  CVo.bManualRun = false;
                  if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
                  {
                    CVo.eMachineStatus = enumMachineStatus.Idle;
                  }
                  else
                  {
                    CVo.eMachineStatus = enumMachineStatus.Stop;
                  }
                }
              }
            }
            else
            {
              CVo.bManualRun = false;
            }
          }

          if (CVo.bManualRun && CVo.eMachineStatus == enumMachineStatus.Cycle)
          {
            bool bRunningCycle
            = CVo.bRunningLE == false
            && CVo.bRunningUE1 == false
            && CVo.bRunningUE2 == false
            && CVo.bRunningUE3 == false
            && CVo.bRunningUE4 == false
            && CVo.bRunningLP == false
            && CVo.bRunningStage1 == false
            && CVo.bRunningStage2 == false;

            if (iDelayCount < iManualDelay && bRunningCycle)
            {
              bool bRunning = false;
              int iStartRunBit = (int)enumFlagRunning.B2080_LE_Homming;
              int iEndRunBit = (int)enumFlagRunning.B20DF_;
              for (int i = iStartRunBit; i < iEndRunBit; i++)
              {
                if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
                {
                  bRunning = true;
                }
              }

              if (bRunning == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving == false
                  && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving == false)
              {
                CVo.bManualRun = false;
                if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
                {
                  CVo.eMachineStatus = enumMachineStatus.Idle;
                }
                else
                {
                  CVo.eMachineStatus = enumMachineStatus.Stop;
                }
              }

            }
          }
          else
          {
            CVo.bManualRun = false;
          }


          #endregion

          #region 스레드 처리용 비트 관리
          //Home 상태 관리
          structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
          for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
          {
            sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
          }

          sMotor[(int)enumMotorName.LE].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E0_LE_Home_Complete);
          sMotor[(int)enumMotorName.LP].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E7_LP_Home_Complete);
          sMotor[(int)enumMotorName.BCX].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E5_BCX_Home_Complete);
          sMotor[(int)enumMotorName.BCY].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E6_BCY_Home_Complete);
          sMotor[(int)enumMotorName.ALX].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EC_ALX_Home_Complete);
          sMotor[(int)enumMotorName.ALY].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20ED_ALY_Home_Complete);
          sMotor[(int)enumMotorName.X1].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EE_X1_Home_Complete);
          sMotor[(int)enumMotorName.X2].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EF_X2_Home_Complete);
          sMotor[(int)enumMotorName.Z1].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EA_Z1_Home_Complete);
          sMotor[(int)enumMotorName.Z2].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EB_Z2_Home_Complete);
          sMotor[(int)enumMotorName.PR1].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F0_PR1_Home_Complete);
          sMotor[(int)enumMotorName.PR2].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F1_PR2_Home_Complete);
          sMotor[(int)enumMotorName.PR3].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F2_PR3_Home_Complete);
          sMotor[(int)enumMotorName.PR4].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F3_PR4_Home_Complete);
          sMotor[(int)enumMotorName.UPX].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E8_UPX_Home_Complete);
          sMotor[(int)enumMotorName.UPY].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E9_UPY_Home_Complete);
          sMotor[(int)enumMotorName.UE1].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E1_UE1_Home_Complete);
          sMotor[(int)enumMotorName.UE2].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E2_UE2_Home_Complete);
          sMotor[(int)enumMotorName.UE3].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E3_UE3_Home_Complete);
          sMotor[(int)enumMotorName.UE4].bHomeComplete = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E4_UE4_Home_Complete);

          for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
          {
            CMotionVo.SetMotorStatus(sMotor[i], (enumMotorName)i);
          }



          // 스레트 체크용 비트를 항상 갱신한다. 작업을 다른 스레드로 넘길때 이 비트를 이용해 상태를 확인하고 작업을 넘긴다.
          CVo.bRunningLE
           = CVo.bLaptopTestMode
          ? (CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bMoving
          || CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bMoving)

          : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running)
          || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting));

          CVo.bRunningLP
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Align].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bMoving)

            : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running)
            || CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Align].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bMoving);

          CVo.bRunningStage1
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bMoving)

            : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running));

          CVo.bRunningStage2
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bMoving)

            : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running));

          CVo.bRunningUP
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bMoving)

            : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running)
            || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running));

          CVo.bRunningUE1
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bMoving)

           : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting));

          CVo.bRunningUE2
            = CVo.bLaptopTestMode
            ? (CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bMoving
            || CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bMoving)

           : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting));

          CVo.bRunningUE3
           = CVo.bLaptopTestMode
           ? (CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bMoving
           || CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bMoving)

           : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting));

          CVo.bRunningUE4
           = CVo.bLaptopTestMode
           ? (CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bMoving
           || CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bMoving)

           : (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting));

          #endregion
          dTime = (System.DateTime.Now - start).TotalMilliseconds;
        }
      }
    }



    #region PLC 데이터 통신 관련 함수
    private void Refresh_PLC_Data()
    {
      CMaster.cPlc.Read_Every_MachineData();

      CMaster.cPlc.Read_W_Bit();
    }
    #endregion

    #region 입력 버튼 확인 관련함수

    #endregion

    #region 리커버리 및 장비상태 변경 관련 함수
    private void Recovery()
    {
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.None:
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
          CVo.eAlarmWarn = enumAlarmWarn.PleaseErrorReset;
          CVo.bOnAlarmWarn = false;
          return;
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }

      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      if (CVo.bLotRunning == false)
      {
        CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.LotStart);
        CVo.bLotRunning = true;
        CVo.Init_PCBData();
        CVo.eNextSeq_LE = enumCycleStatus.LE_Align;
        CVo.eNextSeq_LP = enumCycleStatus.NONE;
        if (cSys.bUsePB1 || cSys.bUsePB2)
        {
          CVo.eNextSeq_Stage1 = enumCycleStatus.Stage1_Zero;
        }
        if (cSys.bUsePB3 || cSys.bUsePB4)
        {
          CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Zero;
        }
        CVo.eNextSeq_UL = enumCycleStatus.NONE;
        CVo.eNextSeq_UE1 = enumCycleStatus.UE1_Align;
        CVo.eNextSeq_UE2 = enumCycleStatus.UE2_Align;
        CVo.eNextSeq_UE3 = enumCycleStatus.UE3_Align;
        CVo.eNextSeq_UE4 = enumCycleStatus.UE4_Align;

        CVo.sTactTime_LotStart = System.DateTime.Now;
      }

      bool bStatusAir_LP = CIoVo.Get_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol);
      bool bStatusAir_UP = CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol);
      bool bStatusAir_St1 = CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear);
      bool bStatusAir_St2 = CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front);


      int iDelay = 100;
      List<int> listAirDelay = new List<int>(); listAirDelay.Clear();
      listAirDelay.Add(cSys.iDelayTime_LPVacuum);
      listAirDelay.Add(cSys.iDelayTime_UPVacuum);
      listAirDelay.Add(cSys.iDelayTime_Stage1Vacuum);
      listAirDelay.Add(cSys.iDelayTime_Stage2Vacuum);
      int iDelayAir = listAirDelay.Max() + iDelay;
      CIoVo.Set_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front, true);
      while (CIoVo.Get_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol) == false
          || CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol) == false
          || CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear) == false
          || CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front) == false)
      {
        Thread.Sleep(100);
      }
      Thread.Sleep(iDelayAir);
      
      if (bStatusAir_LP == false)
      {
        bool bExist_PCB = false;
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist))
        {
          bExist_PCB = true;
        }
        CIoVo.Set_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol, false);
        if (bExist_PCB)
        {
          CVo.eVirtualBit = enumVirtualBit.Stop;
          System.Threading.Thread.Sleep(1000);
          CVo.eAlarmWarn = enumAlarmWarn.RemovePCB_LP;
          CVo.bOnAlarmWarn = true;
          return;
        }
      }
      if (bStatusAir_UP == false)
      {
        bool bExist_PCB = false;
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist))
        {
          bExist_PCB = true;
        }
        CIoVo.Set_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol, false);
        if (bExist_PCB)
        {
          CVo.eVirtualBit = enumVirtualBit.Stop;
          System.Threading.Thread.Sleep(1000);
          CVo.eAlarmWarn = enumAlarmWarn.RemovePCB_UP;
          CVo.bOnAlarmWarn = true;
          return;
        }
      }
      if (bStatusAir_St1 == false)
      {
        bool bExist_PCB = false;
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist))
        {
          bExist_PCB = true;
        }
        CIoVo.Set_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear, false);
        if (bExist_PCB)
        {
          CVo.eVirtualBit = enumVirtualBit.Stop;
          System.Threading.Thread.Sleep(1000);
          CVo.eAlarmWarn = enumAlarmWarn.RemovePCB_ST1;
          CVo.bOnAlarmWarn = true;
          return;
        }
      }
      if (bStatusAir_St2 == false)
      {
        bool bExist_PCB = false;
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist))
        {
          bExist_PCB = true;
        }
        CIoVo.Set_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front, false);
        if (bExist_PCB)
        {
          CVo.eVirtualBit = enumVirtualBit.Stop;
          System.Threading.Thread.Sleep(1000);
          CVo.eAlarmWarn = enumAlarmWarn.RemovePCB_ST2;
          CVo.bOnAlarmWarn = true;
          return;
        }
      }

      // 랏 구동중 재시작시 현재 상태를 확인하여 다음동작을 결정해 준다.

      /////////////////////////////////////////////////////////////////////////////////
      // LP
      /////////////////////////////////////////////////////////////////////////////////
      switch (CVo.eNextSeq_LP)
      {
        case enumCycleStatus.LE_to_LP:
          CVo.eNextSeq_LP = enumCycleStatus.NONE;          
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist))
          {
            // LP가 소재를 들고 있는 경우 다음동작을 잔행한다.
            CVo.eNextSeq_LP = enumCycleStatus.LP_to_AL;
          }
          else
          {
            if (CVo.bLotEndWait)
            {
              // 마지막 소재인데 잃어 버렸을 경우
              CVo.bLastPCBLost = true;
            }
            else
            {
              CVo.bLE_to_LP_Wait = true;
            }
          }
          break;
        case enumCycleStatus.LP_to_AL:
          if (CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor))
          {
            // 얼라인부에 제품이 있음
            CVo.eNextSeq_LP = enumCycleStatus.Align;
          }
          else
          {
            // 얼라인부 제품 없음
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist))
            {
              // 로더피커에 제품 있음 
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              CVo.bStageSelectWait = true;
            }
            else
            {
              // 로더피커에 제품 없음
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
            }
          }
          if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
          {
              CVo.bWaitLE = true;
          }
          break;
        case enumCycleStatus.Align:
          if (CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor) == false)
          {
            // AL 에 제품이 없으면 작업 날린다.
            CVo.eNextSeq_LP = enumCycleStatus.NONE;
            if (CVo.bLotEndWait)
            {
              // 마지막 소재인데 잃어 버렸을 경우
              CVo.bLastPCBLost = true;
            }
            else
            {
                if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
                {
                    CVo.bWaitLE = true;
                }
            }
          }
          else
          {
              if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
              {
                  CVo.bWaitLE = true;
              }
          }
          break;
        case enumCycleStatus.AL_to_LP:
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist))
          {
            // LP에 소재가 있는 경우
            CVo.eNextSeq_LP = enumCycleStatus.NONE;
            CVo.bStageSelectWait = true; // 스테이지 선택 대기비트 살림
            if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
            {
                CVo.bWaitLE = true;
            }
            else
            {
                if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
                {
                    CVo.bWaitLE = true;
                }
            }
          }
          else
          {
            // LP에 소재가 없는 경우
            if (CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor) == false)
            {
              // AL에 소재가 없는 경우
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
              else
              {
                  if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
                  {
                      CVo.bWaitLE = true;
                  }
              }
            }
            else
            {
              CVo.eNextSeq_LP = enumCycleStatus.Align;
            }
          }
          break;
        case enumCycleStatus.LP_to_Stage1:
          CVo.eNextSeq_LP = enumCycleStatus.NONE;
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist) == false)
          {
            // LP에 소재가 없으면
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist))
            {
              // Stage에 소재가 있으면
              CVo.iPCBIndex_Stage1 = CVo.iPCBIndex_Loader;
              CVo.eNextSeq_Stage1 = enumCycleStatus.Stage1_Measure;
              CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bCycleStart = true;
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
              {
                  CVo.bWaitLE = true;
              }
            }
            else
            {
              // Stage에 소재 없으면
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
            }
          }
          else
          {
            // LP에 소재가 있을때
            CVo.bLP_to_Stage1_Wait = true;
            if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
            {
              CVo.bWaitLE = true;
            }
          }
          break;
        case enumCycleStatus.LP_to_Stage2:
          CVo.eNextSeq_LP = enumCycleStatus.NONE;
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213A_LP_PCB_Exist) == false)
          {
            // LP에 소재가 없으면
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist))
            {
              // Stage에 소재가 있으면
              CVo.iPCBIndex_Stage2 = CVo.iPCBIndex_Loader;
              CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Measure;
              CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart = true;
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
              {
                  CVo.bWaitLE = true;
              }
            }
            else
            {
              // Stage에 소재 없으면
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
            }
          }
          else
          {
            CVo.bLP_to_Stage2_Wait = true;
            if (CVo.bLELastOut == false && CVo.bWaitLE == false && CVo.eNextSeq_LE == enumCycleStatus.NONE)
            {
              CVo.bWaitLE = true;
            }
          }
          break;
        default:
          break;
      }

      if (/*CVo.eNextSeq_LP == enumCycleStatus.NONE*/
        CVo.bLELastOut == false
        && CVo.bLotEndWait == false
        && CVo.eNextSeq_LE == enumCycleStatus.NONE
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart ==false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bExtrenStart == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bMoving == false
        && CVo.bWaitLE == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bCycleStart == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bExtrenStart == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bMoving == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bCycleStart == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bExtrenStart == false
        && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bMoving == false)
      {
        CVo.bWaitLE = true;
      }

      /////////////////////////////////////////////////////////////////////////////////
      // Stage1
      /////////////////////////////////////////////////////////////////////////////////
      switch (CVo.eNextSeq_Stage1)
      {
        case enumCycleStatus.Stage1_Zero:
          break;
        case enumCycleStatus.Stage1_Measure:
          if (CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear) == false)
          {
            // stage 진공이 꺼졋으면 작업 날림
            CVo.eNextSeq_Stage1 = enumCycleStatus.NONE;
            if (CVo.bLotEndWait)
            {
              // 마지막 소재인데 잃어 버렸을 경우
              CVo.bLastPCBLost = true;
            }
          }
          break;
        case enumCycleStatus.Stage1_Clean:
          break;
        case enumCycleStatus.Stage1_Probe_Clean:
          break;
        default:
          break;
      }
      if (CVo.bStage1_Measuring && CVo.eNextSeq_Stage1 == enumCycleStatus.NONE)
      {
        // 스테이지1 작업중 비트 켜졋는데 작업 없으면(무한대기 방지)
        if (CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear) == false)
        {
          CVo.bStage1_Measuring = false;
        }
        else
        {
          if (CVo.bLotEndWait)
          {
            // 마지막 소재인데 잃어 버렸을 경우
            CVo.bStage1_Measuring = false;
            CVo.bLastPCBLost = true;
          }
          else
          {
            CVo.eNextSeq_Stage1 = enumCycleStatus.Stage1_Measure;
          }
        }
      }

      /////////////////////////////////////////////////////////////////////////////////
      // Stage2
      /////////////////////////////////////////////////////////////////////////////////
      switch (CVo.eNextSeq_Stage2)
      {
        case enumCycleStatus.Stage2_Zero:
          break;
        case enumCycleStatus.Stage2_Measure:
          if (CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front) == false)
          {
            // stage 진공이 꺼졋으면 작업 날림
            CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
            if (CVo.bLotEndWait)
            {
              // 마지막 소재인데 잃어 버렸을 경우
              CVo.bLastPCBLost = true;
            }
          }
          break;
        case enumCycleStatus.Stage2_Clean:
          break;
        case enumCycleStatus.Stage2_Probe_Clean:
          break;
        default:
          break;
      }
      if (CVo.bStage2_Measuring && CVo.eNextSeq_Stage2 == enumCycleStatus.NONE)
      {
        // 스테이지2 작업중 비트 켜졋는데 작업 없으면(무한대기 방지)
        if (CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front) == false)
        {
          CVo.bStage2_Measuring = false;
        }
        else
        {
          if (CVo.bLotEndWait)
          {
            // 마지막 소재인데 잃어 버렸을 경우
            CVo.bStage2_Measuring = false;
            CVo.bLastPCBLost = true;
          }
          else
          {
            CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Measure;
          }
        }
      }

      /////////////////////////////////////////////////////////////////////////////////
      // UL
      /////////////////////////////////////////////////////////////////////////////////
      switch (CVo.eNextSeq_UL)
      {
        case enumCycleStatus.Stage1_to_UP:
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist))
          {
            // UP가 소재를 들고 있을 경우
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist) == false)
            {
              // Stage에 소재가 없을 경우
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              switch (CVo.sPCBData[CVo.iPCBIndex_Unloader].Result)
              {
                case enumPCBResult.A:
                  CVo.bWaitUE1 = true;
                  break;
                case enumPCBResult.B:
                  CVo.bWaitUE2 = true;
                  break;
                case enumPCBResult.C:
                  CVo.bWaitUE3 = true;
                  break;
                case enumPCBResult.D:
                  CVo.bWaitUE4 = true;
                  break;
                case enumPCBResult.NONE:
                default:
                  break;
              }
            }
          }
          else
          {
            // UP 소재 없는 경우
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist) == false)
            {
              // Stage 에 소재가 없는 경우
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
            }
            else
            {
              // UP 소재없고 스테이지1 소재 있는데 다음동작이 측정 다시하면 UP 작업 날림
              if (CVo.eNextSeq_Stage1 == enumCycleStatus.Stage1_Measure)
              {
                CVo.eNextSeq_UL = enumCycleStatus.NONE;
              }
            }
          }
          break;
        case enumCycleStatus.Stage2_to_UP:
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist))
          {
            // UP가 소재를 들고 있을 경우
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist) == false)
            {
              // Stage에 소재가 없을 경우
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              switch (CVo.sPCBData[CVo.iPCBIndex_Unloader].Result)
              {
                case enumPCBResult.A:
                  CVo.bWaitUE1 = true;
                  break;
                case enumPCBResult.B:
                  CVo.bWaitUE2 = true;
                  break;
                case enumPCBResult.C:
                  CVo.bWaitUE3 = true;
                  break;
                case enumPCBResult.D:
                  CVo.bWaitUE4 = true;
                  break;
                case enumPCBResult.NONE:
                default:
                  break;
              }
            }
          }
          else
          {
            // UP 소재 없는 경우
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist) == false)
            {
              // Stage 에 소재가 없는 경우
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait)
              {
                // 마지막 소재인데 잃어 버렸을 경우
                CVo.bLastPCBLost = true;
              }
            }
            else
            {
              // UP 소재없고 스테이지1 소재 있는데 다음동작이 측정 다시하면 UP 작업 날림
              if (CVo.eNextSeq_Stage2 == enumCycleStatus.Stage2_Measure)
              {
                CVo.eNextSeq_UL = enumCycleStatus.NONE;
              }
            }
          }
          break;
        case enumCycleStatus.UP_to_UE1:
        case enumCycleStatus.UP_to_UE2:
        case enumCycleStatus.UP_to_UE3:
        case enumCycleStatus.UP_to_UE4:
          if (CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol) == false)
          {
            // UP버큠이 꺼져있으면
            CVo.eNextSeq_UL = enumCycleStatus.NONE;
            if (CVo.bLotEndWait)
            {
              // 마지막 소재인데 잃어 버렸을 경우
              CVo.bLastPCBLost = true;
            }
          }
          break;
        default:
          break;
      }

      if (CVo.bLastPCBLost
       && CVo.bWaitUE1 == false
       && CVo.bWaitUE2 == false
       && CVo.bWaitUE3 == false
       && CVo.bWaitUE4 == false
       && CVo.bStage1_Measuring == false
       && CVo.bStage2_Measuring == false
       && CVo.eNextSeq_Stage1 == enumCycleStatus.NONE
       && CVo.eNextSeq_Stage2 == enumCycleStatus.NONE)
      {
        CVo.bLastPCBLost = false;

        CVo.eNextSeq_LE = enumCycleStatus.NONE;
        CVo.eNextSeq_LP = enumCycleStatus.NONE;
        CVo.eNextSeq_Stage1 = enumCycleStatus.NONE;
        CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
        CVo.eNextSeq_UL = enumCycleStatus.NONE;
        CVo.eNextSeq_UE1 = enumCycleStatus.NONE;
        CVo.eNextSeq_UE2 = enumCycleStatus.NONE;
        CVo.eNextSeq_UE3 = enumCycleStatus.NONE;
        CVo.eNextSeq_UE4 = enumCycleStatus.NONE;

        CVo.eNextSeq_LE = enumCycleStatus.LE_Cassette_Wait;
        CVo.eNextSeq_UE1 = enumCycleStatus.UE1_Cassette_Wait;
        CVo.eNextSeq_UE2 = enumCycleStatus.UE2_Cassette_Wait;
        CVo.eNextSeq_UE3 = enumCycleStatus.UE3_Cassette_Wait;
        CVo.eNextSeq_UE4 = enumCycleStatus.UE4_Cassette_Wait;
        CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bCycleStart = true;
        CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bCycleStart = true;
        CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bCycleStart = true;
        CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bCycleStart = true;
        CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bCycleStart = true;
      }







      //////////////////////////////////////////////////////////
      // 결정된 다음동작을 시작해준다.
      //////////////////////////////////////////////////////////
      CVo.eMachineStatus = enumMachineStatus.Auto;
      if (CVo.eNextSeq_LE != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_LE].bExtrenStart = true;
      }
      if (CVo.eNextSeq_LP != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_LP].bExtrenStart = true;
      }
      if (CVo.eNextSeq_Stage1 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_Stage1].bExtrenStart = true;
      }
      if (CVo.eNextSeq_Stage2 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_Stage2].bExtrenStart = true;
      }
      if (CVo.eNextSeq_UL != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_UL].bExtrenStart = true;
      }
      if (CVo.eNextSeq_UE1 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_UE1].bExtrenStart = true;
      }
      if (CVo.eNextSeq_UE2 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_UE2].bExtrenStart = true;
      }
      if (CVo.eNextSeq_UE3 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_UE3].bExtrenStart = true;
      }
      if (CVo.eNextSeq_UE4 != enumCycleStatus.NONE)
      {
        CVo.sCycleStatus[(int)CVo.eNextSeq_UE4].bExtrenStart = true;
      }



    }

    private void Change_Stop()
    {
      CVo.bManualRun = false;
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.Initial:
        case enumMachineStatus.Cycle:
        case enumMachineStatus.Auto:
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
          {
            CVo.eMachineStatus = enumMachineStatus.Idle;
          }
          else
          {
            CVo.eMachineStatus = enumMachineStatus.Stop;
          }
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
          CVo.eAlarmWarn = enumAlarmWarn.PleaseErrorReset;
          CVo.bOnAlarmWarn = false;
          break;
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.None:
        default:
          break;
      }
    }

    private void Change_Reset()
    {
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.None:
          CVo.listAlarmStopName.Clear();
          CVo.listAlarmStopTime.Clear();
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
          {
            CVo.eMachineStatus = enumMachineStatus.Idle;
          }
          else
          {
            CVo.eMachineStatus = enumMachineStatus.Stop;
          }
          break;
        case enumMachineStatus.Initial:
        case enumMachineStatus.Cycle:
        case enumMachineStatus.Auto:
        default:
          break;
      }
    }

    private void Change_Init()
    {
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.None:
            CVo.bInit_All = true;
            CVo.eMachineStatus = enumMachineStatus.Initial;
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
          CVo.eAlarmWarn = enumAlarmWarn.PleaseErrorReset;
          CVo.bOnAlarmWarn = false;
          break;
        case enumMachineStatus.Initial:
        case enumMachineStatus.Cycle:
        case enumMachineStatus.Auto:
        default:
          break;
      }
    }

    private bool Check_LP_PCB(bool onOff)
    {
      // ?????
      return true;
    }

    #endregion

    #region Alarm 관련 함수
    private void Check_AutoRunError()
    {
      if (CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Align].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bError
       || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bError)
      {
        for (int i = 0; i < Enum.GetNames(typeof(enumCycleStatus)).Length; i++)
        {
          CVo.sCycleStatus[i].bError = false;
        }
        for (int i = 0; i < Enum.GetNames(typeof(enumError)).Length; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
          }
        }
      }



      //if (CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bError = false;
      //  for (int i = (int)enumError.B2260_BH_Door_Open_Error_LEAlignReady; i < (int)enumError.B227F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bError = false;
      //  for (int i = (int)enumError.B2280_BH_Door_Open_Error_UE1AlignReady; i < (int)enumError.B229F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bError = false;
      //  for (int i = (int)enumError.B22A0_BH_Door_Open_Error_UE2AlignReady; i < (int)enumError.B22BF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bError = false;
      //  for (int i = (int)enumError.B22C0_BH_Door_Open_Error_UE3AlignReady; i < (int)enumError.B22DF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bError = false;
      //  for (int i = (int)enumError.B22E0_BH_Door_Open_Error_UE4AlignReady; i < (int)enumError.B22FF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bError = false;
      //  for (int i = (int)enumError.B2300_BH_Door_Open_Error_LEtoLP; i < (int)enumError.B231F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bError = false;
      //  for (int i = (int)enumError.B2320_BH_Door_Open_Error_LPtoAL; i < (int)enumError.B233F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Align].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Align].bError = false;
      //  for (int i = (int)enumError.B2340_BH_Door_Open_Error_AL; i < (int)enumError.B235F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bError = false;
      //  for (int i = (int)enumError.B2360_BH_Door_Open_Error_ALtoLP; i < (int)enumError.B237F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bError = false;
      //  for (int i = (int)enumError.B2380_BH_Door_Open_Error_LPtoStage1; i < (int)enumError.B239F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bError = false;
      //  for (int i = (int)enumError.B23A0_BH_Door_Open_Error_LPtoStage2; i < (int)enumError.B23BF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bError = false;
      //  for (int i = (int)enumError.B23C0_BH_Door_Open_Error_Stage1Zero; i < (int)enumError.B23DF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bError = false;
      //  for (int i = (int)enumError.B23E0_BH_Door_Open_Error_Stage2Zero; i < (int)enumError.B23FF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bError = false;
      //  for (int i = (int)enumError.B2400_BH_Door_Open_Error_Stage1Measure; i < (int)enumError.B241F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bError = false;
      //  for (int i = (int)enumError.B2420_BH_Door_Open_Error_Stage2Measure; i < (int)enumError.B243F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bError = false;
      //  for (int i = (int)enumError.B2440_BH_Door_Open_Error_Stage1toUP; i < (int)enumError.B245F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bError = false;
      //  for (int i = (int)enumError.B2460_BH_Door_Open_Error_Stage2toUP; i < (int)enumError.B247F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bError = false;
      //  for (int i = (int)enumError.B2480_BH_Door_Open_Error_UPtoUE; i < (int)enumError.B249F_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bError = false;
      //  for (int i = (int)enumError.B24A0_BH_Door_Open_Error_Stage1Clean; i < (int)enumError.B24BF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
      //if (CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bError
      // || CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bError)
      //{
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bError = false;
      //  CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bError = false;
      //  for (int i = (int)enumError.B24C0_BH_Door_Open_Error_Stage2Clean; i < (int)enumError.B24DF_; i++)
      //  {
      //    if (CIoVo.Get_RB_Error((enumError)i))
      //    {
      //      CVo.OnAlaramStop((enumAlarmStop)(i + 1));// 알람번호가 0번은 None 이므로 1을 더한 알람번호를 호출한다.
      //    }
      //  }
      //}
    }

    private void Check_MotorStatus_LE()
    {
      enumMotorName eName = enumMotorName.LE;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2140_AW_LE_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2141_AW_LE_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2142_AW_LE_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2143_AW_LE_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C0_AW_LE_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_LP()
    {
      enumMotorName eName = enumMotorName.LP;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B215C_AW_LP_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B215D_AW_LP_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B215E_AW_LP_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B215F_AW_LP_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C7_AW_LP_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_BCX()
    {
      enumMotorName eName = enumMotorName.BCX;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2154_AW_BCX_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2155_AW_BCX_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2156_AW_BCX_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2157_AW_BCX_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C5_AW_BCX_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_BCY()
    {
      enumMotorName eName = enumMotorName.BCY;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2158_AW_BCY_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2159_AW_BCY_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B215A_AW_BCY_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B215B_AW_BCY_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C6_AW_BCY_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_ALX()
    {
      enumMotorName eName = enumMotorName.ALX;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2170_AW_ALX_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2171_AW_ALX_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2172_AW_ALX_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2173_AW_ALX_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CC_AW_ALX_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_ALY()
    {
      enumMotorName eName = enumMotorName.ALY;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2174_AW_ALY_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2175_AW_ALY_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2176_AW_ALY_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2177_AW_ALY_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CD_AW_ALY_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_X1()
    {
      enumMotorName eName = enumMotorName.X1;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2178_AW_X1_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2179_AW_X1_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B217A_AW_X1_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B217B_AW_X1_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CE_AW_X1_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_X2()
    {
      enumMotorName eName = enumMotorName.X2;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B217C_AW_X2_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B217D_AW_X2_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B217E_AW_X2_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B217F_AW_X2_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CF_AW_X2_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_Z1()
    {
      enumMotorName eName = enumMotorName.Z1;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2168_AW_Z1_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2169_AW_Z1_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B216A_AW_Z1_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B216B_AW_Z1_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CA_AW_Z1_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_Z2()
    {
      enumMotorName eName = enumMotorName.Z2;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B216C_AW_Z2_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B216D_AW_Z2_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B216E_AW_Z2_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B216F_AW_Z2_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21CB_AW_Z2_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_PR1()
    {
      enumMotorName eName = enumMotorName.PR1;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2180_AW_PR1_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2181_AW_PR1_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2182_AW_PR1_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2183_AW_PR1_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21D0_AW_PR1_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_PR2()
    {
      enumMotorName eName = enumMotorName.PR2;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2184_AW_PR2_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2185_AW_PR2_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2186_AW_PR2_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2187_AW_PR2_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21D1_AW_PR2_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_PR3()
    {
      enumMotorName eName = enumMotorName.PR3;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2188_AW_PR3_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2189_AW_PR3_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B218A_AW_PR3_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B218B_AW_PR3_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21D2_AW_PR3_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_PR4()
    {
      enumMotorName eName = enumMotorName.PR4;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B218C_AW_PR4_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B218D_AW_PR4_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B218E_AW_PR4_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B218F_AW_PR4_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21D3_AW_PR4_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UPX()
    {
      enumMotorName eName = enumMotorName.UPX;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2160_AW_UPX_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2161_AW_UPX_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2162_AW_UPX_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2163_AW_UPX_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C8_AW_UPX_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UPY()
    {
      enumMotorName eName = enumMotorName.UPY;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2164_AW_UPY_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2165_AW_UPY_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2166_AW_UPY_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2167_AW_UPY_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C9_AW_UPY_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UE1()
    {
      enumMotorName eName = enumMotorName.UE1;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2144_AW_UE1_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2145_AW_UE1_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2146_AW_UE1_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2147_AW_UE1_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C1_AW_UE1_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UE2()
    {
      enumMotorName eName = enumMotorName.UE2;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2148_AW_UE2_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2149_AW_UE2_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B214A_AW_UE2_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B214B_AW_UE2_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C2_AW_UE2_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UE3()
    {
      enumMotorName eName = enumMotorName.UE3;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B214C_AW_UE3_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B214D_AW_UE3_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B214E_AW_UE3_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B214F_AW_UE3_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C3_AW_UE3_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }
    private void Check_MotorStatus_UE4()
    {
      enumMotorName eName = enumMotorName.UE4;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eName);
      sMotor.bErrorPLCReady = CIoVo.Get_RB_Error(enumError.B2150_AW_UE4_Ready_Error);
      sMotor.bErrorPLCMotor = CIoVo.Get_RB_Error(enumError.B2151_AW_UE4_Motor_Error);
      sMotor.bErrorPLCLimit = CIoVo.Get_RB_Error(enumError.B2152_AW_UE4_Limit_Error);
      sMotor.bErrorPLCState = CIoVo.Get_RB_Error(enumError.B2153_AW_UE4_PLC_Error);
      sMotor.bErrorPLCPosition = CIoVo.Get_RB_Error(enumError.B21C4_AW_UE4_Position_Data_Error);
      if (sMotor.bErrorPLCReady
       || sMotor.bErrorPLCMotor
       || sMotor.bErrorPLCLimit
       || sMotor.bErrorPLCState
       || sMotor.bErrorPLCPosition)
      {
        sMotor.bAlarm = true;
      }
      else
      {
        sMotor.bAlarm = false;
      }
      CMotionVo.SetMotorStatus(sMotor, eName);
    }

    public bool Check_Running_Home(enumMotorName name)
    {
      switch (name)
      {
        case enumMotorName.LE: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2080_LE_Homming);
        case enumMotorName.LP: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2087_LP_Homming);
        case enumMotorName.BCX: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2085_BCX_Homming);
        case enumMotorName.BCY: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2086_BCY_Homming);
        case enumMotorName.ALX: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208C_ALX_Homming);
        case enumMotorName.ALY: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208D_ALY_Homming);
        case enumMotorName.X1: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208E_X1_Homming);
        case enumMotorName.X2: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208F_X2_Homming);
        case enumMotorName.Z1: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208A_Z1_Homming);
        case enumMotorName.Z2: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208B_Z2_Homming);
        case enumMotorName.PR1: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2090_PR1_Homming);
        case enumMotorName.PR2: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2091_PR2_Homming);
        case enumMotorName.PR3: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2092_PR3_Homming);
        case enumMotorName.PR4: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2093_PR4_Homming);
        case enumMotorName.UPX: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2088_UPX_Homming);
        case enumMotorName.UPY: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2089_UPY_Homming);
        case enumMotorName.UE1: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2081_UE1_Homming);
        case enumMotorName.UE2: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2082_UE2_Homming);
        case enumMotorName.UE3: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2083_UE3_Homming);
        case enumMotorName.UE4: return CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2084_UE4_Homming);
        default: return false;
      }
    }
    public bool Check_Compelete_Home(enumMotorName name)
    {
      switch (name)
      {
        case enumMotorName.LE: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E0_LE_Home_Complete);
        case enumMotorName.LP: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E7_LP_Home_Complete);
        case enumMotorName.BCX: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E5_BCX_Home_Complete);
        case enumMotorName.BCY: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E6_BCY_Home_Complete);
        case enumMotorName.ALX: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EC_ALX_Home_Complete);
        case enumMotorName.ALY: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20ED_ALY_Home_Complete);
        case enumMotorName.X1: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EE_X1_Home_Complete);
        case enumMotorName.X2: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EF_X2_Home_Complete);
        case enumMotorName.Z1: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EA_Z1_Home_Complete);
        case enumMotorName.Z2: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EB_Z2_Home_Complete);
        case enumMotorName.PR1: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F0_PR1_Home_Complete);
        case enumMotorName.PR2: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F1_PR2_Home_Complete);
        case enumMotorName.PR3: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F2_PR3_Home_Complete);
        case enumMotorName.PR4: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F3_PR4_Home_Complete);
        case enumMotorName.UPX: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E8_UPX_Home_Complete);
        case enumMotorName.UPY: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E9_UPY_Home_Complete);
        case enumMotorName.UE1: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E1_UE1_Home_Complete);
        case enumMotorName.UE2: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E2_UE2_Home_Complete);
        case enumMotorName.UE3: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E3_UE3_Home_Complete);
        case enumMotorName.UE4: return CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E4_UE4_Home_Complete);
        default: return false;
      }
    }
    public bool Check_Error_Home()
    {
      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;
      bool bResult = false;
      for (int i = iErrorStart; i <= iErrorEnd; i++)
      {
        if (CIoVo.Get_RB_Error((enumError)i))
        {
          bResult = true;
          break;
        }
      }
      return bResult;
    }
    #endregion

  }
}

