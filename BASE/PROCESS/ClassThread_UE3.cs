﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MASTER;

namespace BASE.PROCESS
{
  public class ClassThread_UE3
  {
    private static ClassThread_UE3 cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_UE3()
    {
      Check_Thread();
    }

    public static ClassThread_UE3 Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_UE3();
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
          // UE3_Align 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UE3_Align))
          {
            // 외부 입력 확인
            if (CVo.bRunningLP == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UE3_Align);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UE3_Align);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UE3_Align);
            bool bCycleResult = CMaster.cMotion.cAction.UE3_Align();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UE3_Align);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UE3_Align);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {

            }
          }

          //////////////////////////
          // UE3_Casette 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.UE3_Cassette_Wait))
          {
            // 외부 입력 확인
              if (CVo.bRunningUE3 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.UE3_Cassette_Wait);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.UE3_Cassette_Wait);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.UE3_Cassette_Wait);
            bool bCycleResult = CMaster.cMotion.cAction.UE3_Cassette_Wait();
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.UE3_Cassette_Wait);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.UE3_Cassette_Wait);
            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
                CVo.bUE3LastOut = true;
            }
            CVo.eNextSeq_UE3 = enumCycleStatus.NONE;

          }

        }
      }
    }
  }
}
