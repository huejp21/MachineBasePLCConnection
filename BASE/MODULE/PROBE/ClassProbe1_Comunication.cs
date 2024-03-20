using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

using BASE.MASTER;
using BASE.MODULE.PLC;
using BASE.VO;

namespace BASE.MODULE.PROBE
{
  public class ClassProbe1_Comunication
  {
    private static ClassProbe1_Comunication cInstatnce;
    private static object syncLock = new object();

    private static SerialPort cSerial = null;
    private static string strProbe1 = "";
    private static string strProbe2 = "";

    private static bool bRecieved = false;

    protected ClassProbe1_Comunication()
    {

    }

    public static ClassProbe1_Comunication Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassProbe1_Comunication();
          }
        }
      }
      return cInstatnce;
    }

    public bool Open_Port(string com, string baud)
    {
      string strCom = "COM" + com;
      try
      {
        if (cSerial == null)
        {
          cSerial = new SerialPort(strCom);
        }
        if (cSerial.IsOpen)
        {
          return true;
        }

        cSerial.PortName = strCom;
        cSerial.BaudRate = Convert.ToInt32(baud);
        cSerial.DataBits = 8;
        cSerial.StopBits = StopBits.One;
        cSerial.Parity = Parity.None;
        cSerial.DataReceived += new SerialDataReceivedEventHandler(Event_DataRecived);
        cSerial.Open();
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
      return true;
    }

    public void Close_Port()
    {
      if (cSerial != null)
      {
        cSerial.Close();
        cSerial = null;
      }
    }

    public bool Check_Open()
    {
      if (cSerial == null)
      {
        return false;
      }
      return cSerial.IsOpen;
    }

    private void Event_DataRecived(object sender, SerialDataReceivedEventArgs e)
    {
      string strFull = "";
      try
      {
        strFull = cSerial.ReadLine().ToString();
        string[] asData = strFull.Split(',');
        char[] CharsToTrim = { '@', '\r', (char)0x03 };
        if (asData.Length > 3)
        {
          strProbe1 = asData[2].Trim(CharsToTrim);
          strProbe2 = asData[3].Trim(CharsToTrim);
          bRecieved = true;
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }
    }

    public double GetData(int num /*1~2 컨트롤러 1개당 2개*/ )
    {
      
      if (cSerial == null)
      {
        return -666;
      }
      if (cSerial.IsOpen == false)
      {
        return -666;
      }

      bRecieved = false;
      bool bTimeOutErr = false;
      double dTimeOutLimit = 20000;
      System.DateTime sStartTime = System.DateTime.Now;
      CIoVo.Set_WB_Output(enumBitOutput.B1131_Probe_Stage1_Start_Signal, true); // On
      for (int i = 0; i < (int)dTimeOutLimit; i++)
      {
        System.Threading.Thread.Sleep(1);
        if (bRecieved)
        {
          CIoVo.Set_WB_Output(enumBitOutput.B1131_Probe_Stage1_Start_Signal, false); // Off
          break;
        }
        if ((System.DateTime.Now - sStartTime).TotalSeconds > dTimeOutLimit)
        {
          CIoVo.Set_WB_Output(enumBitOutput.B1131_Probe_Stage1_Start_Signal, false); // Off
          bTimeOutErr = true;
          break;
        }
      }
      if (bTimeOutErr)
      {
        return -444;
      }


      double dValue = 0.0;
      if (strProbe1.CompareTo("") == 0) { return -999; }
      if (strProbe2.CompareTo("") == 0) { return -999; }

      try
      {
        switch (num)
        {
          case 1:
            dValue = Convert.ToDouble(strProbe1) / 1000.0;
            break;
          case 2:
            dValue = Convert.ToDouble(strProbe2) / 1000.0;
            break;
          default:
            dValue = -888;
            break;
        }
        return dValue;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return -777;
      }
    }

  }
}
