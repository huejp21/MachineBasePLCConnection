using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MASTER;
using BASE.MODULE.MOTION;
using BASE.FORM;

namespace BASE.PROCESS
{
  public class ClassThread_LE
  {
    private static ClassThread_LE cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_LE()
    {
      Check_Thread();
    }

    public static ClassThread_LE Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_LE();
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

          //////////////////////////
          // LE Align 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LE_Align) 
           && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running) == false
           && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bCycleStart == false
           && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bExtrenStart == false
           && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bMoving == false)
          {
            // 외부 입력 확인
            if (CVo.bRunningLE == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LE_Align);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LE_Align);
              continue;
            }
            bool bAuto = (CVo.eMachineStatus == enumMachineStatus.Auto);

            CVo.CycleStatus_Moving(enumCycleStatus.LE_Align);
            bool bCycleResult = CMaster.cMotion.cAction.LE_Align();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LE_Align);
              continue;
            }
            if (CVo.bLaptopTestMode ? CVo.bPCB_Empty : CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213E_LE_Lot_Complete))
            {
              CVo.CycleStatus_Complete(enumCycleStatus.LE_Align);
              if (bAuto)
              {
                // 동작 실패시 소재유무 판단하여 랏 종료 대기비트 켬
                CVo.bLotEndWait = true;
                if (CVo.iPCBIndex_LE > CVo.iPCBIndex_Loader)
                {
                  if (0 < CVo.iPCBIndex_LE)
                  {
                    // 로더가 소재를 집어갈때 카운트를 상응 시키므로 1개를 줄여주어 실제 마지막 카운트를 한다.
                    CVo.iPCBIndex_LE--;
                  }
                }
              }
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false) 
            { 
              continue; 
            }
            // 성공시 바코드 읽고 상태 변경
            CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = false;
            if (bAuto)
            {
              if (cSys.bUseBarcode_2D)
              {
                // 바코드 사용이면 바코드 관련 처리 이곳에서 한다.
                string strBCR = CMaster.cBCR.Read();
                CForm.frmPageAuto.Set_BCR_Image(CMaster.cBCR.Get_Image());
                //CVo.bOnAlarmWarn
                //CVo.eAlarmWarn
                if (strBCR.Trim().CompareTo("") == 0) // 바코드 미인식 조건
                {
                  CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = false;
                  CVo.sPCBData[CVo.iPCBIndex_LE].BCR = strBCR;
                }
                else
                {
                  if (cSys.bUseBarcode_1D)
                  {
                    // 바코드 실패, 혼입, 랏정보 입력 안함시 장비 멈추고 알람
                    if (CVo.strLotBCR.Length != 9) // 1D 바코드 데이터 이상
                    {
                      CVo.eVirtualBit = enumVirtualBit.Stop;
                      Thread.Sleep(1000);
                      CVo.eAlarmWarn = enumAlarmWarn.BCRLotDataWrong;
                      CVo.bOnAlarmWarn = true;
                      continue;
                    }
                    // 바코드 인식 성공
                    if (strBCR.Contains(CVo.strLotBCR)) // 바코드 혼입 비교 성공
                    {
                      CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = true;
                      CVo.sPCBData[CVo.iPCBIndex_LE].BCR = strBCR;
                    }
                    else
                    {
                      // 바코드 혼입
                      CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = false;
                      CVo.sPCBData[CVo.iPCBIndex_LE].BCR = strBCR;
                    }
                  }
                  else
                  {
                    // 2D 바코드 설정, 1D 비활성화
                    CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = true;
                    CVo.sPCBData[CVo.iPCBIndex_LE].BCR = strBCR;
                  }
                }
              }
              else
              {
                CVo.sPCBData[CVo.iPCBIndex_LE].BCR_OK = true;
                CVo.sPCBData[CVo.iPCBIndex_LE].BCR = "SKIP";
              }
            }


            CVo.CycleStatus_Complete(enumCycleStatus.LE_Align);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              // 데이터 변경
              CVo.eNextSeq_LE = enumCycleStatus.NONE;
              CVo.bWaitLP = true;
            }
          }

          //////////////////////////
          // LE Cassette 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.LE_Cassette_Wait))
          {
            // 외부 입력 확인
            if (CVo.bRunningLE == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.LE_Cassette_Wait);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.LE_Cassette_Wait);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.LE_Cassette_Wait);
            bool bCycleResult = CMaster.cMotion.cAction.LE_Cassette_Wait();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.LE_Cassette_Wait);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.LE_Cassette_Wait);
            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
                CVo.bLELastOut = true;
            }
            CVo.eNextSeq_LE = enumCycleStatus.NONE;
          }

          //////////////////////////
          // LE_Align 가능 확인
          //////////////////////////
          if (CVo.bWaitLE)
          {
            if (CVo.Check_MachineStatus() == false)
            {
              continue;
            }

            if (CVo.bRunningLE == false
             && CVo.eNextSeq_LE == enumCycleStatus.NONE
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bMoving == false
             && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running) == false)
            {
              CVo.bWaitLE = false;
              CVo.eNextSeq_LE = enumCycleStatus.LE_Align;
              CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart = true;
            }
          }

        } // lock
      } // while
    } // Run()





  }
}
