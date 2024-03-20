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
  public class ClassThread_Init
  {
    private static ClassThread_Init cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_Init()
    {
      Check_Thread();
    }

    public static ClassThread_Init Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_Init();
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
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
          {
             // 홈 상태 확인
            CVo.bAllHome = true;
          }
          else
          {
            CVo.bAllHome = false;
          }

          if (CVo.eMachineStatus == enumMachineStatus.Initial
           && CVo.bInit_All)
          {
            // 전체 원점
            CVo.bInit_All = false;
            for (int i = 0; i < Enum.GetNames(typeof(enumCycleStatus)).Length; i++)
            {
              CVo.CycleStatus_Reset((enumCycleStatus)i);
            }
            if (CMaster.cMotion.cAction.Home_All())
            {
              if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
              {
                CVo.eMachineStatus = enumMachineStatus.Idle;
              }
              else
              {
                CVo.eMachineStatus = enumMachineStatus.Stop;
              }
            }
            else
            {
              CVo.eMachineStatus = enumMachineStatus.Error;
            }
          }

          if (CVo.eMachineStatus == enumMachineStatus.Initial
           && CVo.bInit_Loading)
          { 
           // 로더 부 원점 
            CVo.bInit_Loading = false;
            if (CMaster.cMotion.cAction.Home_Loading())
            {
              if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
              {
                CVo.eMachineStatus = enumMachineStatus.Idle;
              }
              else
              {
                CVo.eMachineStatus = enumMachineStatus.Stop;
              }
            }
            else
            {
              CVo.eMachineStatus = enumMachineStatus.Error;
            }
          }
          if (CVo.eMachineStatus == enumMachineStatus.Initial
           && CVo.bInit_Stage)
          {
            // 스테이즈 부 원점 
            CVo.bInit_Stage = false;
            CVo.bZeroSetStatus_Stage1 = false;
            CVo.bZeroSetStatus_Stage2 = false;
            if (CMaster.cMotion.cAction.Home_Measure())
            {
              if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
              {
                CVo.eMachineStatus = enumMachineStatus.Idle;
              }
              else
              {
                CVo.eMachineStatus = enumMachineStatus.Stop;
              }
            }
            else
            {
              CVo.eMachineStatus = enumMachineStatus.Error;
            }
          }
          if (CVo.eMachineStatus == enumMachineStatus.Initial
           && CVo.bInit_Unloading)
          {
            // 언로더 부 원점 
            CVo.bInit_Unloading = false;
            if (CMaster.cMotion.cAction.Home_Unloading())
            {
              if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
              {
                CVo.eMachineStatus = enumMachineStatus.Idle;
              }
              else
              {
                CVo.eMachineStatus = enumMachineStatus.Stop;
              }
            }
            else
            {
              CVo.eMachineStatus = enumMachineStatus.Error;
            }
          }



        }
      }
    }
  }
}
