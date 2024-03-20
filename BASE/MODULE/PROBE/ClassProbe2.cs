using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

using BASE.MASTER;

namespace BASE.MODULE.PROBE
{
  public class ClassProbe2
  {
    private static ClassProbe2 cInstatnce;
    private static object syncLock = new object();

    private static SerialPort cSerial = null;
    private static string strProbe1 = "";
    private static string strProbe2 = "";

    protected ClassProbe2()
    {

    }

    public static ClassProbe2 Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassProbe2();
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
          //if (Convert.ToDouble(strProbe1) < 0
          // || Convert.ToDouble(strProbe2) < 0)
          //{
          //  string strData = System.DateTime.Now.ToString("yyyyMMddHHmmss");
          //  strData += ("," + "1");
          //  strData += ("," + strFull.Trim(CharsToTrim));

          //  string strFullPath = "D:\\DLM\\FullData.csv";
          //  System.IO.StreamWriter sw = new System.IO.StreamWriter(strFullPath, true, System.Text.Encoding.UTF8);
          //  sw.WriteLine(strData);
          //  sw.Close();
          //}
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
