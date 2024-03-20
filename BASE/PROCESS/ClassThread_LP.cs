using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MASTER;

namespace BASE.PROCESS
{
  public class ClassThread_LP
  {
    private static ClassThread_LP cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_LP()
    {
      Check_Thread();
    }

    public static ClassThread_LP Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_LP();
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
          Thread.Sleep(50);
          ClassSystemPara cSys = CVo.cParaSys.GetValues();
          ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

          if (CVo.bLE_to_LP_Wait && CVo.eMachineStatus == enumMachineStatus.Auto)
          {
            if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running) == false
              && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2120_LE_Align_Complete)
              && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting) == false
              && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bExtrenStart == false
              && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart == false
              && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bMoving == false)
            {
              CVo.bLE_to_LP_Wait = false;
              CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bExtrenStart = true;
            }
          }
          if (CVo.bLP_to_Stage1_Wait && CVo.eMachineStatus == enumMachineStatus.Auto)
          {
            if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running) == false
             && CVo.bStage1_Measuring == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running) == false
             && CVo.bWaitStage1_to_UP == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving == false
            )
            {
              CVo.bLP_to_Stage1_Wait = false;
              CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bCycleStart = true;
            }
          }
          if (CVo.bLP_to_Stage2_Wait && CVo.eMachineStatus == enumMachineStatus.Auto)
          {
            if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running) == false
             && CVo.bStage2_Measuring == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running) == false
             && CVo.bWaitStage2_to_UP == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving == false
            )
            {
              CVo.bLP_to_Stage2_Wait = false;
              CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bCycleStart = true;
            }
          }

          //////////////////////////
          // LE_to_LP 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LE_to_LP) 
            && CVo.bRunningLP == false
            && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bMoving == false
            )
          {
            // 외부 입력 확인
            if (CVo.bRunningLP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LE_to_LP);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LE_to_LP);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.LE_to_LP);
            bool bCycleResult = CMaster.cMotion.cAction.LE_to_LP();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LE_to_LP);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.LE_to_LP);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              CVo.eNextSeq_LP = enumCycleStatus.LP_to_AL;
              CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bCycleStart = true;

              CVo.bWaitLE = true;
            }

          }

          //////////////////////////
          // LP_to_AL 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LP_to_AL) && CVo.bRunningLP == false)
          {
            // 외부 입력 확인
            if (CVo.bRunningLP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_AL);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_AL);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.LP_to_AL);
            bool bCycleResult = CMaster.cMotion.cAction.LP_to_AL();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LP_to_AL);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.LP_to_AL);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              CVo.eNextSeq_LP = enumCycleStatus.Align;
              CVo.sCycleStatus[(int)enumCycleStatus.Align].bCycleStart = true;
            }

          }

          //////////////////////////
          // Align 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Align) && CVo.bRunningLP == false)
          {
            // 외부 입력 확인
            if (CVo.bRunningLP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Align);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Align);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Align);
            bool bCycleResult = CMaster.cMotion.cAction.Align();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.Align);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.Align);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              CVo.eNextSeq_LP = enumCycleStatus.AL_to_LP;
              CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bCycleStart = true;
            }

          }

          //////////////////////////
          // AL_to_LP 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.AL_to_LP) && CVo.bRunningLP == false)
          {
            if (CVo.sCycleStatus[(int)enumCycleStatus.Align].bMoving
              || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CC_AL_Running)
              )
            {
              // Align 동작중이면 한번더 쓰레드 돌린다.
              continue;
            }
            // 외부 입력 확인
            if (CVo.bRunningLP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.AL_to_LP);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.AL_to_LP);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.AL_to_LP);
            bool bCycleResult = CMaster.cMotion.cAction.AL_to_LP_Start();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.AL_to_LP);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.AL_to_LP);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
              CVo.bStageSelectWait = true;

            }
          }

          //////////////////////////
          // LP_to_Stage1
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LP_to_Stage1)
           && CVo.bWaitStage1ZeroSet == false)
          {
            // 외부 입력 확인
            if (CVo.bRunningStage1 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_Stage1);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_Stage1);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.LP_to_Stage1);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (0 < cSys.iPreStageCleanCount)
              {
                if (CMaster.cMotion.cAction.Stage1_Clean(cSys.iPreStageCleanCount, 0) == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.CycleStatus_Error(enumCycleStatus.LP_to_Stage1);
                  continue;
                }
              }
            }

            bool bCycleResult = CMaster.cMotion.cAction.LP_to_Stage1_Start();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LP_to_Stage1);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.LP_to_Stage1);
            CVo.bStage1_PCB_Exist = true;
            CVo.iStage1_Cur_ReMeasure_Count = 0;

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              // 데이터 변경
              CVo.iPCBIndex_Stage1 = CVo.iPCBIndex_Loader;

              CVo.eNextSeq_Stage1 = enumCycleStatus.Stage1_Measure;
              CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bCycleStart = true;
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
            }
          }

          //////////////////////////
          // LP_to_Stage2
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LP_to_Stage2)
           && CVo.bWaitStage2ZeroSet == false)
          {
            // 외부 입력 확인
            if (CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_Stage2);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LP_to_Stage2);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.LP_to_Stage2);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (0 < cSys.iPreStageCleanCount)
              {
                if (CMaster.cMotion.cAction.Stage2_Clean(cSys.iPreStageCleanCount, 0) == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.CycleStatus_Error(enumCycleStatus.LP_to_Stage2);
                  continue;
                }
              }
            }

            bool bCycleResult = CMaster.cMotion.cAction.LP_to_Stage2_Start();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LP_to_Stage2);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.LP_to_Stage2);
            CVo.bStage2_PCB_Exist = true;
            CVo.iStage2_Cur_ReMeasure_Count = 0;

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              // 데이터 변경
              CVo.iPCBIndex_Stage2 = CVo.iPCBIndex_Loader;
              CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Measure;
              CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart = true;
              CVo.eNextSeq_LP = enumCycleStatus.NONE;
            }
          }

          //////////////////////////
          // 스테이지 선택 조건
          //////////////////////////
          if (CVo.bStageSelectWait)
          {
            if (CVo.eMachineStatus != enumMachineStatus.Auto)
            {
              CVo.bStageSelectWait = false;
              if (cSys.bUsePB1 || cSys.bUsePB2)
              {
                CVo.eNextSeq_LP = enumCycleStatus.LP_to_Stage1;
              }
              else
              {
                CVo.eNextSeq_LP = enumCycleStatus.LP_to_Stage2;
              }
              continue;
            }
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist) == false
             && CVo.bRunningStage1 == false
             && (cSys.bUsePB1 || cSys.bUsePB2)
             && (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running) == false)
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bCycleStart == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running) == false
             && CVo.bWaitStage1ZeroSet == false
             && CVo.bStage1_Measuring == false
             && (CVo.bLaptopTestMode ? CVo.bStage1_PCB_Exist == false : true))
            {
              CVo.bStageSelectWait = false;
              CVo.eNextSeq_LP = enumCycleStatus.LP_to_Stage1;
              CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bCycleStart = true;
              continue;
            }
            if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist) == false
             && CVo.bRunningStage2 == false
             && (cSys.bUsePB3 || cSys.bUsePB4)
             && (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running) == false)
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running) == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running) == false
             && CVo.bWaitStage2ZeroSet == false
             && CVo.bStage2_Measuring == false
             && (CVo.bLaptopTestMode ? CVo.bStage2_PCB_Exist == false : true))
            {
              CVo.bStageSelectWait = false;
              CVo.eNextSeq_LP = enumCycleStatus.LP_to_Stage2;
              CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bCycleStart = true;
              continue;
            }
          }

          //////////////////////////
          // LE_to_LP 가능 확인
          //////////////////////////
          if (CVo.bWaitLP)
          {
            if (CVo.Check_MachineStatus() == false)
            {
              continue;
            }
            if (CVo.bRunningLP == false
             && CVo.eNextSeq_LP == enumCycleStatus.NONE
             && CVo.bStageSelectWait == false
             && CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor) == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bCycleStart == false
             && CVo.bWaitLE == false)
            {
              CVo.bWaitLP = false;
              CVo.iPCBIndex_Loader = CVo.iPCBIndex_LE;
              CVo.sPCBData[CVo.iPCBIndex_Loader].Total_StartTime = System.DateTime.Now;
              if (CVo.bLotEndWait == false)
              {
                CVo.iPCBIndex_LE++;
                CVo.eNextSeq_LP = enumCycleStatus.LE_to_LP;
                CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bCycleStart = true;
              }
              else
              {

              }
            }
          }

          //////////////////////////
          // Stage1/Stage2 교체 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.ProbeChange))
          {
            // 외부 입력 확인
            if (CVo.bRunningStage1 == false
             && CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.ProbeChange);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.ProbeChange);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.ProbeChange);
            bool bCycleResult = CMaster.cMotion.cAction.Probe_Change();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.ProbeChange);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.ProbeChange);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {

            }
          }


        }
      }
    }
  }
}
