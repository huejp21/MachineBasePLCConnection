using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.VO;

namespace BASE.UTIL
{
  public class ClassLogMgr
  {
    private static ClassLogMgr cInstatnce;
    private static object syncLock = new object();

    private static List<string> listDebug = new List<string>();
    private static System.Threading.Thread thDebug = null;
    private static bool bThreadDebug = true;

    private static List<string> listEvent = new List<string>();
    private static System.Threading.Thread thEvent = null;
    private static bool bThreadEvent = true;

    private static List<string> listAlarmStopEvent = new List<string>();
    private static System.Threading.Thread thAlarmStopEvent = null;
    private static bool bThreadAlarmStopEvent = true;

    private static List<string> listAlarmWarnEvent = new List<string>();
    private static System.Threading.Thread thAlarmWarnEvent = null;
    private static bool bThreadAlarmWarnEvent = true;

    private static List<string> listMotionEvent = new List<string>();
    private static System.Threading.Thread thMotionEvent = null;
    private static bool bThreadMotionEvent = true;

    private static List<string> listMachineEvent = new List<string>();
    private static System.Threading.Thread thMachineEvent = null;
    private static bool bThreadMachineEvent = true;

    public void Abort_Log()
    {
      thDebug.Abort();
      bThreadDebug = false;
      thDebug = null;

      thEvent.Abort();
      bThreadEvent = false;
      thEvent = null;

      thAlarmStopEvent.Abort();
      bThreadAlarmStopEvent = false;
      thAlarmStopEvent = null;

      thAlarmWarnEvent.Abort();
      bThreadAlarmWarnEvent = false;
      thAlarmWarnEvent = null;

      thMotionEvent.Abort();
      bThreadMotionEvent = false;
      thMotionEvent = null;

      thMachineEvent.Abort();
      bThreadMachineEvent = false;
      thMachineEvent = null;
    } // Kill All Log Thread

    protected ClassLogMgr()
    {
      Check_Thread();
    }
    public static ClassLogMgr Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassLogMgr();
          }
        }
      }
      return cInstatnce;
    }

    public void Check_Thread()
    {
      if (thDebug == null)
      {
        bThreadDebug = true;
        thDebug = new System.Threading.Thread(Run_Debug);
        thDebug.Start();
      }
      if (thEvent == null)
      {
        bThreadEvent = true;
        thEvent = new System.Threading.Thread(Run_Event);
        thEvent.Start();
      }
      if (thAlarmStopEvent == null)
      {
        bThreadAlarmStopEvent = true;
        thAlarmStopEvent = new System.Threading.Thread(Run_AlarmStop);
        thAlarmStopEvent.Start();
      }
      if (thAlarmWarnEvent == null)
      {
        bThreadAlarmWarnEvent = true;
        thAlarmWarnEvent = new System.Threading.Thread(Run_AlarmWarn);
        thAlarmWarnEvent.Start();
      }
      if (thMotionEvent == null)
      {
        bThreadMotionEvent = true;
        thMotionEvent = new System.Threading.Thread(Run_MotionEvent);
        thMotionEvent.Start();
      }
      if (thMachineEvent == null)
      {
        bThreadMachineEvent = true;
        thMachineEvent = new System.Threading.Thread(Run_MachineEvent);
        thMachineEvent.Start();
      }
    }


    private void Run_Debug() // Write Log Thread (Debug)
    {
      while (bThreadDebug)
      {
        lock (this)
        {          
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listDebug.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_DEBUG))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_DEBUG);
              }

              System.IO.StreamWriter swLogDebug = null;
              string strTitle = "Time,MethodName,Infomation,Description";
              if (!System.IO.File.Exists(CVo.LOG_PATH_DEBUG + strDate + "_" + CVo.LOG_NAME_DEBUG))
              {
                swLogDebug = new System.IO.StreamWriter(CVo.LOG_PATH_DEBUG + strDate + "_" + CVo.LOG_NAME_DEBUG, true, System.Text.Encoding.UTF8);
                swLogDebug.WriteLine(strTitle);
              }
              else
              {
                swLogDebug = new System.IO.StreamWriter(CVo.LOG_PATH_DEBUG + strDate + "_" + CVo.LOG_NAME_DEBUG, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listDebug.Count; i++)
              {
                swLogDebug.WriteLine(listDebug[i]);
              }
              swLogDebug.Close();
              listDebug.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    } 
    public void Add_Exception(string methodName, System.Diagnostics.StackTrace st, Exception ex) // Log Exception(Log Debug)
    {
      //If has problem in try catch statment. set break point here!!!
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2},{3}\n\r", strDate, methodName, st.ToString().Replace('\n', ' ').Replace(',', '/').Replace('\r', ' '), ex.Message);
      listDebug.Add(strData);
    } 

    private void Run_Event() // Write Log Thread (Form Event)
    {
      while (bThreadEvent)
      {
        lock (this)
        {
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listEvent.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_EVENT))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_EVENT);
              }

              System.IO.StreamWriter swLog = null;
              string strTitle = "Time,MethodName,FormName"; //title
              if (!System.IO.File.Exists(CVo.LOG_PATH_EVENT + strDate + "_" + CVo.LOG_NAME_EVENT))
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_EVENT + strDate + "_" + CVo.LOG_NAME_EVENT, true, System.Text.Encoding.UTF8);
                swLog.WriteLine(strTitle);
              }
              else
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_EVENT + strDate + "_" + CVo.LOG_NAME_EVENT, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listEvent.Count; i++)
              {
                swLog.WriteLine(listEvent[i]);
              }
              swLog.Close();
              listEvent.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    }
    public void Add_FormEvent(string methodName, string parentName) // Log (Form Event)
    {
      //If has problem in try catch statment. set break point here!!!
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2}\n\r", strDate, methodName, parentName.Replace(","," "));
      listEvent.Add(strData);
    }

    private void Run_AlarmStop()
    {
      while (bThreadAlarmStopEvent)
      {
        lock (this)
        {
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listAlarmStopEvent.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_ALARM_STOP))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_ALARM_STOP);
              }

              System.IO.StreamWriter swLog = null;
              string strTitle = "Time,Name,Info,Status"; //title
              if (!System.IO.File.Exists(CVo.LOG_PATH_ALARM_STOP + strDate + "_" + CVo.LOG_NAME_ALARM_STOP))
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_ALARM_STOP + strDate + "_" + CVo.LOG_NAME_ALARM_STOP, true, System.Text.Encoding.UTF8);
                swLog.WriteLine(strTitle);
              }
              else
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_ALARM_STOP + strDate + "_" + CVo.LOG_NAME_ALARM_STOP, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listAlarmStopEvent.Count; i++)
              {
                swLog.WriteLine(listAlarmStopEvent[i]);
              }
              swLog.Close();
              listAlarmStopEvent.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    }
    public void Add_Alarm_Stop(enumAlarmStop name, string dsp, enumMachineStatus status) // Log Alarm Stop
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2},{3}\n\r", strDate, name.ToString(), dsp, status.ToString());
      listAlarmStopEvent.Add(strData);
    }

    private void Run_AlarmWarn()
    {
      while (bThreadAlarmWarnEvent)
      {
        lock (this)
        {
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listAlarmWarnEvent.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_ALARM_WARN))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_ALARM_WARN);
              }

              System.IO.StreamWriter swLog = null;
              string strTitle = "Time,Name,Info,Status"; //title
              if (!System.IO.File.Exists(CVo.LOG_PATH_ALARM_WARN + strDate + "_" + CVo.LOG_NAME_ALARM_WARN))
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_ALARM_WARN + strDate + "_" + CVo.LOG_NAME_ALARM_WARN, true, System.Text.Encoding.UTF8);
                swLog.WriteLine(strTitle);
              }
              else
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_ALARM_WARN + strDate + "_" + CVo.LOG_NAME_ALARM_WARN, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listAlarmWarnEvent.Count; i++)
              {
                swLog.WriteLine(listAlarmWarnEvent[i]);
              }
              swLog.Close();
              listAlarmWarnEvent.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    }
    public void Add_Alarm_Warn(enumAlarmWarn name, string dsp, enumMachineStatus status) // Log Alarm Warn
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2},{3}\n\r", strDate, name.ToString(), dsp, status.ToString());
      listAlarmWarnEvent.Add(strData);
    }

    private void Run_MotionEvent() // Log Motion Event
    {
      while (bThreadMotionEvent)
      {
        lock (this)
        {
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listMotionEvent.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_MOTON_EVENT))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_MOTON_EVENT);
              }

              System.IO.StreamWriter swLog = null;
              string strTitle = "Time,Name,Status"; //title
              if (!System.IO.File.Exists(CVo.LOG_PATH_MOTON_EVENT + strDate + "_" + CVo.LOG_NAME_MOTION_EVENT))
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_MOTON_EVENT + strDate + "_" + CVo.LOG_NAME_MOTION_EVENT, true, System.Text.Encoding.UTF8);
                swLog.WriteLine(strTitle);
              }
              else
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_MOTON_EVENT + strDate + "_" + CVo.LOG_NAME_MOTION_EVENT, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listMotionEvent.Count; i++)
              {
                swLog.WriteLine(listMotionEvent[i]);
              }
              swLog.Close();
              listMotionEvent.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    }
    public void Add_MotionEvent(string name, enumMachineStatus status)
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2}\n\r", strDate, name.ToString(), status.ToString());
      listMotionEvent.Add(strData);
    }

    private void Run_MachineEvent() // 장비 이벤트
    {
      while (bThreadMachineEvent)
      {
        lock (this)
        {
          string strDate = System.DateTime.Now.ToString("yyyyMMdd");
          try
          {
            System.Threading.Thread.Sleep(50);
            if (listMachineEvent.Count > 0)
            {
              if (!System.IO.Directory.Exists(CVo.LOG_PATH_MACHINE_EVENT))
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_MACHINE_EVENT);
              }

              System.IO.StreamWriter swLog = null;
              string strTitle = "Time,Name,Status"; //title
              if (!System.IO.File.Exists(CVo.LOG_PATH_MACHINE_EVENT + strDate + "_" + CVo.LOG_NAME_MACHINE_EVENT))
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_MACHINE_EVENT + strDate + "_" + CVo.LOG_NAME_MACHINE_EVENT, true, System.Text.Encoding.UTF8);
                swLog.WriteLine(strTitle);
              }
              else
              {
                swLog = new System.IO.StreamWriter(CVo.LOG_PATH_MACHINE_EVENT + strDate + "_" + CVo.LOG_NAME_MACHINE_EVENT, true, System.Text.Encoding.UTF8);
              }
              for (int i = 0; i < listMachineEvent.Count; i++)
              {
                swLog.WriteLine(listMachineEvent[i]);
              }
              swLog.Close();
              listMachineEvent.Clear();
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + new System.Diagnostics.StackTrace(ex, true) + "\n" + ex.Message);
          }
        }
      }
    }
    public void Add_MachineEvent(enumMachineEvent name)
    {
      string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
      string strData = string.Format("{0},{1},{2}\n\r", strDate, name.ToString(), CVo.eMachineStatus.ToString());
      listMachineEvent.Add(strData);
    }
    //값 로드 해서 뿌리는거

    
 

  }
}
