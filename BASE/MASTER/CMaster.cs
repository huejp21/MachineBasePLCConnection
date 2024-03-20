using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.UTIL;
using BASE.VO;

using BASE.MODULE.MOTION;
using BASE.MODULE.PLC;
using BASE.MODULE.PROBE;
using BASE.MODULE.BCR;


namespace BASE.MASTER
{
  public static class CMaster
  {
    public static ClassDataMgr cDataMgr = ClassDataMgr.Get_Instance();
    public static ClassLogMgr cLogMgr = ClassLogMgr.Get_Instance();

    public static ClassMotionMaster cMotion = ClassMotionMaster.Get_Instance();
    public static ClassProbe1 cProbe1 = ClassProbe1.Get_Instance();
    public static ClassProbe2 cProbe2 = ClassProbe2.Get_Instance();
    public static ClassCognexEthernet cBCR = ClassCognexEthernet.Get_Instance();
    public static ClassMxComponent cPlc = ClassMxComponent.Get_Instance();


    public static void Kill_Thread()
    {
      cLogMgr.Abort_Log();
    }

    public static void Check_Thread()
    {
      cLogMgr.Check_Thread();
    }



    #region Motion
    #endregion

    #region Probe
    #endregion

    #region BCR

    #endregion

    #region PLC
    //public static ClassMxComponent cPlc = ClassMxComponent.Get_Instance();
    #endregion


  }
}
