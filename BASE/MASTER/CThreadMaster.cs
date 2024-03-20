using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.PROCESS;

namespace BASE.MASTER
{
  public static class CThreadMaster
  {
    #region Thread
    public static ClassThread_Main cThMain = ClassThread_Main.Get_Instance();
    public static ClassThread_LP cThLP = ClassThread_LP.Get_Instance();
    public static ClassThread_Stage1 cThSt1 = ClassThread_Stage1.Get_Instance();
    public static ClassThread_Stage2 cThSt2 = ClassThread_Stage2.Get_Instance();
    public static ClassThread_UP cThUP = ClassThread_UP.Get_Instance();
    public static ClassThread_LE cThLE = ClassThread_LE.Get_Instance();
    public static ClassThread_UE1 cThUE1 = ClassThread_UE1.Get_Instance();
    public static ClassThread_UE2 cThUE2 = ClassThread_UE2.Get_Instance();
    public static ClassThread_UE3 cThUE3 = ClassThread_UE3.Get_Instance();
    public static ClassThread_UE4 cThUE4 = ClassThread_UE4.Get_Instance();
    public static ClassThread_Init cThInit = ClassThread_Init.Get_Instance();

    public static ClassThread_Test1 cThTest1 = ClassThread_Test1.Get_Instance();
    public static ClassThread_Test2 cThTest2 = ClassThread_Test2.Get_Instance();

    #endregion


    public static void Kill_Thread()
    {
      cThMain.Abort_Thread();

      cThLP.Abort_Thread();
      cThSt1.Abort_Thread();
      cThSt2.Abort_Thread();
      cThUP.Abort_Thread();
      cThLE.Abort_Thread();
      cThUE1.Abort_Thread();
      cThUE2.Abort_Thread();
      cThUE3.Abort_Thread();
      cThUE4.Abort_Thread();
      cThInit.Abort_Thread();

      cThTest1.Abort_Thread();
      cThTest2.Abort_Thread();
    }

    public static void Check_Thread()
    {
      cThMain.Check_Thread();

      cThLP.Check_Thread();
      cThSt1.Check_Thread();
      cThSt2.Check_Thread();
      cThUP.Check_Thread();
      cThLE.Check_Thread();
      cThUE1.Check_Thread();
      cThUE2.Check_Thread();
      cThUE3.Check_Thread();
      cThUE4.Check_Thread();
      cThInit.Check_Thread();

      cThTest1.Check_Thread();
      cThTest2.Check_Thread();
    }
  }
}
