using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.MODULE.MOTION
{
  public class ClassMotionMaster
  {
    private static ClassMotionMaster cInstatnce;
    private static object syncLock = new object();

    public ClassMotionAction cAction = ClassMotionAction.Get_Instance();

    protected ClassMotionMaster()
    {

    }

    public static ClassMotionMaster Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassMotionMaster();
          }
        }
      }
      return cInstatnce;
    }


  }
}
