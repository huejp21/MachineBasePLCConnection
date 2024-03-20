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
  public class ClassThread_UP
  {
    private static ClassThread_UP cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_UP()
    {
      Check_Thread();
    }

    public static ClassThread_UP Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_UP();
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

          //////////////////////////
          // Stage1_to_UP 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage1_to_UP))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage1_to_UP);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage1_to_UP);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Stage1_to_UP);
            bool bCycleResult = CMaster.cMotion.cAction.Stage1_to_UP();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.Stage1_to_UP);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.Stage1_to_UP);
            CVo.bStage1_PCB_Exist = false;

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
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

              if (CVo.bWaitStage1ZeroSet)
              {
                CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bCycleStart = true;
              }
            }
          }

          //////////////////////////
          // Stage2_to_UP 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage2_to_UP))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_to_UP);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_to_UP);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Stage2_to_UP);
            bool bCycleResult = CMaster.cMotion.cAction.Stage2_to_UP();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.Stage2_to_UP);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.Stage2_to_UP);
            CVo.bStage2_PCB_Exist = false;

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
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
            if (CVo.bWaitStage2ZeroSet)
            {
              CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bCycleStart = true;
            }
          }

          //////////////////////////
          // UP_to_UE1
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UP_to_UE1))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE1);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE1);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UP_to_UE1);
            bool bCycleResult = CMaster.cMotion.cAction.UP_to_UE(1);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UP_to_UE1);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UP_to_UE1);

            bool bError = false;
            int iRunStart = System.Environment.TickCount;
            while (CVo.bRunningUE1)
            {
              // 오토나 싸이클이 아니면 빠져나감
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CVo.iRunTimeOut < (System.Environment.TickCount - iRunStart))
              {
                CVo.OnAlaramStop(enumAlarmStop.N0001_AUTO_RunTimeOut_UE1_Cassette_Wait);
                bError = true;
                break;
              }
            }

            if (bError)
            {
              // 타임아웃 이나 장비상태 변경시 빠져나감
              continue;
            }

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.sPCBData[CVo.iPCBIndex_Unloader].BCR_OK)
              {
                // 데이터 변경
                CVo.uiProductTotalCount++;
                CVo.sPCBData[CVo.iPCBIndex_Unloader].PerfectlyOut = true;
              }
              CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime = System.DateTime.Now;
              double dTactTime = (CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime - CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_StartTime).TotalSeconds;
              CVo.dTactTime_Previous = CVo.dTactTime_Currnet;
              CVo.dTactTime_Currnet = dTactTime;
              CVo.sPreviousOutTime = CVo.sCurrentOutTime;
              CVo.sCurrentOutTime = System.DateTime.Now;
              CVo.listOutTact.Add((CVo.sCurrentOutTime - CVo.sPreviousOutTime).TotalSeconds);
              CVo.bRefreshInfo = true;
              CVo.iPCBIndex_UE1 = CVo.iPCBIndex_Unloader;
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait && (CVo.iPCBIndex_UE1 == CVo.iPCBIndex_LE))
              {
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
              else
              {
                if (CVo.bLastPCBLost && (CVo.iPCBIndex_UE1 == (CVo.iPCBIndex_LE - 1)))
                {
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
                else
                {
                  CVo.eNextSeq_UE1 = enumCycleStatus.UE1_Align;
                  CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bCycleStart = true;
                }
              }

            }
          }

          //////////////////////////
          // UP_to_UE2
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UP_to_UE2))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE2);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE2);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UP_to_UE2);
            bool bCycleResult = CMaster.cMotion.cAction.UP_to_UE(2);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UP_to_UE2);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UP_to_UE2);

            bool bError = false;
            int iRunStart = System.Environment.TickCount;
            while (CVo.bRunningUE2)
            {
              // 오토나 싸이클이 아니면 빠져나감
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CVo.iRunTimeOut < (System.Environment.TickCount - iRunStart))
              {
                CVo.OnAlaramStop(enumAlarmStop.N0002_AUTO_RunTimeOut_UE2_Cassette_Wait);
                bError = true;
                break;
              }
            }

            if (bError)
            {
              // 타임아웃 이나 장비상태 변경시 빠져나감
              continue;
            }

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.sPCBData[CVo.iPCBIndex_Unloader].BCR_OK)
              {
                // 데이터 변경
                CVo.uiProductTotalCount++;
                CVo.sPCBData[CVo.iPCBIndex_Unloader].PerfectlyOut = true;
              }
              CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime = System.DateTime.Now;
              double dTactTime = (CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime - CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_StartTime).TotalSeconds;
              CVo.dTactTime_Previous = CVo.dTactTime_Currnet;
              CVo.dTactTime_Currnet = dTactTime;
              CVo.sPreviousOutTime = CVo.sCurrentOutTime;
              CVo.sCurrentOutTime = System.DateTime.Now;
              CVo.listOutTact.Add((CVo.sCurrentOutTime - CVo.sPreviousOutTime).TotalSeconds);
              CVo.bRefreshInfo = true;
              CVo.iPCBIndex_UE2 = CVo.iPCBIndex_Unloader;
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait && (CVo.iPCBIndex_UE2 == CVo.iPCBIndex_LE))
              {
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
              else
              {
                if (CVo.bLastPCBLost && (CVo.iPCBIndex_UE2 == (CVo.iPCBIndex_LE - 1)))
                {
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
                else
                {
                  CVo.eNextSeq_UE2 = enumCycleStatus.UE2_Align;
                  CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bCycleStart = true;
                }
              }
            }
          }


          //////////////////////////
          // UP_to_UE3
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UP_to_UE3))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE3);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE3);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UP_to_UE3);
            bool bCycleResult = CMaster.cMotion.cAction.UP_to_UE(3);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UP_to_UE3);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UP_to_UE3);

            bool bError = false;
            int iRunStart = System.Environment.TickCount;
            while (CVo.bRunningUE3)
            {
              // 오토나 싸이클이 아니면 빠져나감
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CVo.iRunTimeOut < (System.Environment.TickCount - iRunStart))
              {
                CVo.OnAlaramStop(enumAlarmStop.N0003_AUTO_RunTimeOut_UE3_Cassette_Wait);
                bError = true;
                break;
              }
            }

            if (bError)
            {
              // 타임아웃 이나 장비상태 변경시 빠져나감
              continue;
            }

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.sPCBData[CVo.iPCBIndex_Unloader].BCR_OK)
              {
                // 데이터 변경
                CVo.uiProductTotalCount++;
                CVo.sPCBData[CVo.iPCBIndex_Unloader].PerfectlyOut = true;
              }
              CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime = System.DateTime.Now;
              double dTactTime = (CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime - CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_StartTime).TotalSeconds;
              CVo.dTactTime_Previous = CVo.dTactTime_Currnet;
              CVo.dTactTime_Currnet = dTactTime;
              CVo.sPreviousOutTime = CVo.sCurrentOutTime;
              CVo.sCurrentOutTime = System.DateTime.Now;
              CVo.listOutTact.Add((CVo.sCurrentOutTime - CVo.sPreviousOutTime).TotalSeconds);
              CVo.bRefreshInfo = true;
              CVo.iPCBIndex_UE3 = CVo.iPCBIndex_Unloader;
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait && (CVo.iPCBIndex_UE3 == CVo.iPCBIndex_LE))
              {
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
              else
              {
                if (CVo.bLastPCBLost && (CVo.iPCBIndex_UE3 == (CVo.iPCBIndex_LE - 1)))
                {
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
                else
                {
                  CVo.eNextSeq_UE3 = enumCycleStatus.UE3_Align;
                  CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bCycleStart = true;
                }
              }
            }
          }

          //////////////////////////
          // UP_to_UE4
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UP_to_UE4))
          {
            // 외부 입력 확인
            if (CVo.bRunningUP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE4);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UP_to_UE4);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UP_to_UE4);
            bool bCycleResult = CMaster.cMotion.cAction.UP_to_UE(4);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UP_to_UE4);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UP_to_UE4);

            bool bError = false;
            int iRunStart = System.Environment.TickCount;
            while (CVo.bRunningUE4)
            {
              // 오토나 싸이클이 아니면 빠져나감
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CVo.iRunTimeOut < (System.Environment.TickCount - iRunStart))
              {
                CVo.OnAlaramStop(enumAlarmStop.N0004_AUTO_RunTimeOut_UE4_Cassette_Wait);
                bError = true;
                break;
              }
            }

            if (bError)
            {
              // 타임아웃 이나 장비상태 변경시 빠져나감
              continue;
            }

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.sPCBData[CVo.iPCBIndex_Unloader].BCR_OK)
              {
                // 데이터 변경
                CVo.uiProductTotalCount++;
                CVo.sPCBData[CVo.iPCBIndex_Unloader].PerfectlyOut = true;
              }
              CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime = System.DateTime.Now;
              double dTactTime = (CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_EndTime - CVo.sPCBData[CVo.iPCBIndex_Unloader].Total_StartTime).TotalSeconds;
              CVo.dTactTime_Previous = CVo.dTactTime_Currnet;
              CVo.dTactTime_Currnet = dTactTime;
              CVo.sPreviousOutTime = CVo.sCurrentOutTime;
              CVo.sCurrentOutTime = System.DateTime.Now;
              CVo.listOutTact.Add((CVo.sCurrentOutTime - CVo.sPreviousOutTime).TotalSeconds);
              CVo.bRefreshInfo = true;
              CVo.iPCBIndex_UE4 = CVo.iPCBIndex_Unloader;
              CVo.eNextSeq_UL = enumCycleStatus.NONE;
              if (CVo.bLotEndWait && (CVo.iPCBIndex_UE4 == CVo.iPCBIndex_LE))
              {
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
              else
              {
                if (CVo.bLastPCBLost && (CVo.iPCBIndex_UE4 == (CVo.iPCBIndex_LE - 1)))
                {
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
                else
                {
                  CVo.eNextSeq_UE4 = enumCycleStatus.UE4_Align;
                  CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bCycleStart = true;
                }
              }
            }
          }

          //////////////////////////
          // UP_to_UE 동작 가능확인
          //////////////////////////
          if (CVo.bWaitUE1)
          {
            if (CVo.eMachineStatus != enumMachineStatus.Auto)
            {
              //CVo.bWaitUE1 = false;
              continue;
            }
            if (CVo.bRunningUE1 == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bMoving == false
             && (CVo.bLaptopTestMode ? CVo.bUP_PCB_Exist == false : true))
            {
              CVo.bWaitUE1 = false;
              CVo.eNextSeq_UL = enumCycleStatus.UP_to_UE1;
              CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bCycleStart = true;
            }
          }
          if (CVo.bWaitUE2)
          {
            if (CVo.eMachineStatus != enumMachineStatus.Auto)
            {
              //CVo.bWaitUE2 = false;
              continue;
            }
            if (CVo.bRunningUE2 == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bMoving == false
             && (CVo.bLaptopTestMode ? CVo.bUP_PCB_Exist == false : true))
            {
              CVo.bWaitUE2 = false;
              CVo.eNextSeq_UL = enumCycleStatus.UP_to_UE2;
              CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bCycleStart = true;
            }
          }
          if (CVo.bWaitUE3)
          {
            if (CVo.eMachineStatus != enumMachineStatus.Auto)
            {
              //CVo.bWaitUE3 = false;
              continue;
            }
            if (CVo.bRunningUE3 == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bMoving == false
             && (CVo.bLaptopTestMode ? CVo.bUP_PCB_Exist == false : true))
            {
              CVo.bWaitUE3 = false;
              CVo.eNextSeq_UL = enumCycleStatus.UP_to_UE3;
              CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bCycleStart = true;
            }
          }
          if (CVo.bWaitUE4)
          {
            if (CVo.eMachineStatus != enumMachineStatus.Auto)
            {
              //CVo.bWaitUE4 = false;
              continue;
            }
            if (CVo.bRunningUE4 == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bMoving == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bExtrenStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bCycleStart == false
             && CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bMoving == false
             && (CVo.bLaptopTestMode ? CVo.bUP_PCB_Exist == false : true))
            {
              CVo.bWaitUE4 = false;
              CVo.eNextSeq_UL = enumCycleStatus.UP_to_UE4;
              CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bCycleStart = true;
            }
          }


          //////////////////////////
          // Stage_to_UP 동작가능 확인
          //////////////////////////
          if (CVo.bWaitStage1_to_UP
            && CVo.bWaitUE1 == false
            && CVo.bWaitUE2 == false
            && CVo.bWaitUE3 == false
            && CVo.bWaitUE4 == false
            && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running) == false
            && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running) == false
            && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running) == false
            && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bMoving == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bMoving == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bExtrenStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bCycleStart == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bMoving == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bMoving == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bMoving == false
            && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bMoving == false
            && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist) == false
            && CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol) == false)
          {
            CVo.bWaitStage1_to_UP = false;
            CVo.iPCBIndex_Unloader = CVo.iPCBIndex_Stage1;
            CVo.eNextSeq_UL = enumCycleStatus.Stage1_to_UP;
            CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bCycleStart = true;
          }
          else if (CVo.bWaitStage2_to_UP
                && CVo.bWaitUE1 == false
                && CVo.bWaitUE2 == false
                && CVo.bWaitUE3 == false
                && CVo.bWaitUE4 == false
                && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running) == false
                && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running) == false
                && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running) == false
                && CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bMoving == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bMoving == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bExtrenStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bCycleStart == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bMoving == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bMoving == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bMoving == false
                && CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bMoving == false
                && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213B_UP_PCB_Exist) == false
                && CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol) == false)
          {
            CVo.bWaitStage2_to_UP = false;
            CVo.iPCBIndex_Unloader = CVo.iPCBIndex_Stage2;
            CVo.eNextSeq_UL = enumCycleStatus.Stage2_to_UP;
            CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bCycleStart = true;
          }


        }
      }
    }
  }
}
