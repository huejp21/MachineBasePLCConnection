using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using BASE.VO;
using BASE.MASTER;

namespace BASE.FORM.PAGE
{
  public enum enumSelectLogTab
  {
    LotLog,
    DataLog,
  }
  public partial class FormPageDataLog : Form
  {
    private enumSelectLogTab eSelectTab = enumSelectLogTab.LotLog;
    private List<string> listCurrentResult = new List<string>();
    private int iStartTime = 0;
    private int iEndTime = 23;

    public FormPageDataLog()
    {
      InitializeComponent();
    }

    private void FormPageDataLog_Load(object sender, EventArgs e)
    {
      cbo_Log_TimeStart.Items.Clear();
      cbo_Log_TimeEnd.Items.Clear();
      for (int i = 0; i < 24; i++)
      {
        cbo_Log_TimeStart.Items.Add(i.ToString("00"));
        cbo_Log_TimeEnd.Items.Add(i.ToString("00"));
      }
      cbo_Log_TimeStart.SelectedIndex = 0;
      cbo_Log_TimeEnd.SelectedIndex = 23;
      iStartTime = 0;
      iEndTime = 23;

      tabDataLog.SelectedTab = tabpLotLog;

      Update_TabStatus();
    }

    private void Update_TabStatus()
    {
      Control ctrl = (Control)tabDataLog.SelectedTab;
      switch (ctrl.Name)
      {
        case "tabpLotLog": eSelectTab = enumSelectLogTab.LotLog; break;
        case "tabpDataLog": eSelectTab = enumSelectLogTab.DataLog; break;
        default:
          break;
      }
    }

    private void cbo_Log_TimeStart_SelectedIndexChanged(object sender, EventArgs e)
    {
      iStartTime = Convert.ToInt32(cbo_Log_TimeStart.Text);
    }

    private void cbo_Log_TimeEnd_SelectedIndexChanged(object sender, EventArgs e)
    {
      iEndTime = Convert.ToInt32(cbo_Log_TimeEnd.Text);
    }

    private void txt_LogWord_MouseDown(object sender, MouseEventArgs e)
    {
      string strKey = CForm.frmKeypadChar.Show_(txt_LogWord.Text, "");
      if (strKey.CompareTo(strKey.Trim()) != 0)
      {
        return;
      }
      txt_LogWord.Text = strKey;
    }

    private void btn_Search_All_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.AllLogView_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      bool bResult = true;
      switch (eSelectTab)
      {
        case enumSelectLogTab.LotLog: bResult = Search_Lotlog(false); break;
        case enumSelectLogTab.DataLog: bResult = Search_Datalog(false); break;
        default: break;
      }
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.DataLogSearchFail);
      }
    }

    private void btn_Search_Option_Click(object sender, EventArgs e)
    {
      bool bResult = true;
      switch (eSelectTab)
      {
        case enumSelectLogTab.LotLog: bResult = Search_Lotlog(true); break;
        case enumSelectLogTab.DataLog: bResult = Search_Datalog(true); break;
        default: break;
      }
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.DataLogSearchFail);
      }
    }

    private bool Search_Lotlog(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Log_Start.Value;
      System.DateTime dte = dtp_Log_End.Value;
      string strStartDate = dts.Date.ToString("yyyyMMdd") + iStartTime.ToString("00") + "0000";
      string strEndDate = dte.Date.ToString("yyyyMMdd") + iEndTime.ToString("00") + "5959";
      System.DateTime sStartDate = System.DateTime.Now;
      System.DateTime sEndDate = System.DateTime.Now;
      bool bPossibleSt = System.DateTime.TryParseExact(strStartDate, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sStartDate);
      bool bPossibleEd = System.DateTime.TryParseExact(strEndDate, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sEndDate);
      if (bPossibleSt == false || bPossibleEd == false)
      {
        return false;
      }

      List<string> list = new List<string>();
      list.Clear();
      listCurrentResult.Clear();
      grid_Log_LotLog.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        string strFileDir = CVo.LOG_PATH_LOT_INFO;
        List<string> listFiles = new List<string>();
        listFiles.Clear();
        try
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strFileName = System.IO.Path.GetFileName(f);
            if (strFileName.Contains(CVo.LOG_NAME_LOT_INFO))
            {
              listFiles.Add(f);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }


        for (int i = 0; i < listFiles.Count; i++)
        {
          string[] strFileName = null;
          try
          {
            strFileName = System.IO.Path.GetFileName(listFiles[i]).Split('_');
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
          if ((1 < strFileName.Length) == false)
          {
            continue;
          }
          System.DateTime sTempDate = System.DateTime.Now;
          bool bPossibleTempDate = System.DateTime.TryParseExact(strFileName[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempDate);
          if (bPossibleTempDate == false)
          {
            continue;
          }
          if (sStartDate > sTempDate || sEndDate < sTempDate)
          {
            continue;
          }

          if (System.IO.File.Exists(listFiles[i]))
          {
            string[] strBuffer = new string[10];
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(listFiles[i], System.Text.Encoding.UTF8);
              string strReadLine = null;
              strBuffer[0] = strFileName[0];
              while ((strReadLine = sr.ReadLine()) != null)
              {

                if (strReadLine.Split(',').Length > 1)
                {
                  switch (strReadLine.Split(',')[0])
                  {
                    case "Recipe Name:": strBuffer[1] = strReadLine.Split(',')[1]; break;
                    case "UE Use Mode:": strBuffer[2] = strReadLine.Split(',')[1]; break;
                    case "LOT Count:": strBuffer[3] = strReadLine.Split(',')[1]; break;
                    case "Total Tact Time:": strBuffer[4] = strReadLine.Split(',')[1]; break;
                    case "1Cycle Tact Time(Average):": strBuffer[5] = strReadLine.Split(',')[1]; break;
                    case "A Count:": strBuffer[6] = strReadLine.Split(',')[1]; break;
                    case "B Count:": strBuffer[7] = strReadLine.Split(',')[1]; break;
                    case "C Count:": strBuffer[8] = strReadLine.Split(',')[1]; break;
                    case "D Count:": strBuffer[9] = strReadLine.Split(',')[1]; break;
                    default:
                      break;
                  }
                }
              }

              string strTotalData = "";
              for (int j = 0; j < strBuffer.Length; j++)
              {
                if (j == 0)
                {
                  strTotalData = strBuffer[j];
                }
                else
                {
                  strTotalData += ("," + strBuffer[j]);
                }

              }
              if (txt_LogWord.Text.Trim().CompareTo("") == 0)
              {
                list.Add(strTotalData);
              }
              else
              {
                if (strTotalData.Replace(",", " ").Contains(txt_LogWord.Text.Trim()))
                {
                  list.Add(strTotalData);
                }
              }
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              bResultError = true;
            }
            finally
            {
              if (sr != null)
              {
                sr.Close();
                sr = null;
              }
            }
            if (bResultError)
            {
              return false;
            }

          }
        }
      }
      else
      {
        // 전체검색
        string strFileDir = CVo.LOG_PATH_LOT_INFO;
        List<string> listFiles = new List<string>();
        listFiles.Clear();
        try
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strFileName = System.IO.Path.GetFileName(f);
            if (strFileName.Contains(CVo.LOG_NAME_LOT_INFO))
            {
              listFiles.Add(f);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }


        for (int i = 0; i < listFiles.Count; i++)
        {
          string[] strFileName = null;
          try
          {
            strFileName = System.IO.Path.GetFileName(listFiles[i]).Split('_');
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
          if ((1 < strFileName.Length) == false)
          {
            continue;
          }
          System.DateTime sTempDate = System.DateTime.Now;
          bool bPossibleTempDate = System.DateTime.TryParseExact(strFileName[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempDate);
          if (bPossibleTempDate == false)
          {
            continue;
          }

          if (System.IO.File.Exists(listFiles[i]))
          {
            string[] strBuffer = new string[10];
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(listFiles[i], System.Text.Encoding.UTF8);
              string strReadLine = null;
              strBuffer[0] = strFileName[0];
              while ((strReadLine = sr.ReadLine()) != null)
              {

                if (strReadLine.Split(',').Length > 1)
                {
                  switch (strReadLine.Split(',')[0])
                  {
                    case "Recipe Name:": strBuffer[1] = strReadLine.Split(',')[1]; break;
                    case "UE Use Mode:": strBuffer[2] = strReadLine.Split(',')[1]; break;
                    case "LOT Count:": strBuffer[3] = strReadLine.Split(',')[1]; break;
                    case "Total Tact Time:": strBuffer[4] = strReadLine.Split(',')[1]; break;
                    case "1Cycle Tact Time(Average):": strBuffer[5] = strReadLine.Split(',')[1]; break;
                    case "A Count:": strBuffer[6] = strReadLine.Split(',')[1]; break;
                    case "B Count:": strBuffer[7] = strReadLine.Split(',')[1]; break;
                    case "C Count:": strBuffer[8] = strReadLine.Split(',')[1]; break;
                    case "D Count:": strBuffer[9] = strReadLine.Split(',')[1]; break;
                    default:
                      break;
                  }
                }
              }

              string strTotalData = "";
              for (int j = 0; j < strBuffer.Length; j++)
              {
                if (j == 0)
                {
                  strTotalData = strBuffer[j];
                }
                else
                {
                  strTotalData += ("," + strBuffer[j]);
                }

              }
              list.Add(strTotalData);
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              bResultError = true;
            }
            finally
            {
              if (sr != null)
              {
                sr.Close();
                sr = null;
              }
            }
            if (bResultError)
            {
              return false;
            }
          }
        }
      }

      grid_Log_LotLog.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        string[] strData = list[i].Split(',');
        if (strData.Length < 10)
        {
          continue;
        }
        grid_Log_LotLog.Rows[i].Cells[0].Value = i.ToString();
        grid_Log_LotLog.Rows[i].Cells[1].Value = strData[0].ToString();
        grid_Log_LotLog.Rows[i].Cells[2].Value = strData[1].ToString();
        grid_Log_LotLog.Rows[i].Cells[3].Value = strData[2].ToString();
        grid_Log_LotLog.Rows[i].Cells[4].Value = strData[3].ToString();
        grid_Log_LotLog.Rows[i].Cells[5].Value = strData[4].ToString();
        grid_Log_LotLog.Rows[i].Cells[6].Value = strData[5].ToString();
        grid_Log_LotLog.Rows[i].Cells[7].Value = strData[6].ToString();
        grid_Log_LotLog.Rows[i].Cells[8].Value = strData[7].ToString();
        grid_Log_LotLog.Rows[i].Cells[9].Value = strData[8].ToString();
        grid_Log_LotLog.Rows[i].Cells[10].Value = strData[9].ToString();
      }
      return true;
    }
    private bool Search_Datalog(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Log_Start.Value;
      System.DateTime dte = dtp_Log_End.Value;
      string strStartDate = dts.Date.ToString("yyyyMMdd") + iStartTime.ToString("00") + "0000";
      string strEndDate = dte.Date.ToString("yyyyMMdd") + iEndTime.ToString("00") + "5959";
      System.DateTime sStartDate = System.DateTime.Now;
      System.DateTime sEndDate = System.DateTime.Now;
      bool bPossibleSt = System.DateTime.TryParseExact(strStartDate, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sStartDate);
      bool bPossibleEd = System.DateTime.TryParseExact(strEndDate, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sEndDate);
      if (bPossibleSt == false || bPossibleEd == false)
      {
        return false;
      }

      List<string> list = new List<string>();
      list.Clear();
      listCurrentResult.Clear();
      grid_Log_DataLog.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        string strFileDir = CVo.LOG_PATH_DATA;
        List<string> listFiles = new List<string>();
        listFiles.Clear();
        try
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strFileName = System.IO.Path.GetFileName(f);
            if (strFileName.Contains(CVo.LOG_NAME_DATA))
            {
              listFiles.Add(f);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }

        for (int i = 0; i < listFiles.Count; i++)
        {
          string[] strFileName = null;
          try
          {
            strFileName = System.IO.Path.GetFileName(listFiles[i]).Split('_');
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }

          if ((1 < strFileName.Length) == false)
          {
            continue;
          }
          System.DateTime sTempDate = System.DateTime.Now;
          bool bPossibleTempDate = System.DateTime.TryParseExact(strFileName[0], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sTempDate);
          if (bPossibleTempDate == false)
          {
            continue;
          }
          if (sStartDate > sTempDate || sEndDate < sTempDate)
          {
            continue;
          }

          if (System.IO.File.Exists(listFiles[i]))
          {
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(listFiles[i], System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length < 4)
                {
                  continue;
                }
                System.DateTime sTempDateLine = System.DateTime.Now;
                bool bPossibleTempDateLine = System.DateTime.TryParseExact(strData[1], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempDateLine);
                if (bPossibleTempDateLine == false)
                {
                  continue;
                }
                if (sStartDate > sTempDateLine || sEndDate < sTempDateLine)
                {
                  continue;
                }

                bool bSearched = false;
                if (txt_LogWord.Text.Trim().CompareTo("") == 0)
                {
                  bSearched = true;
                }
                for (int j = 0; j < strData.Length; j++)
                {
                  if (strData[j].Contains(txt_LogWord.Text.Trim()))
                  {
                    bSearched = true;
                    break;
                  }
                }
                if (bSearched == false)
                {
                  continue;
                }
                list.Add(strReadLine);
              }
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              bResultError = true;
            }
            finally
            {
              if (sr != null)
              {
                sr.Close();
                sr = null;
              }
            }
            if (bResultError)
            {
              return false;
            }

          }
        }
      }
      else
      {
        // 전체 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        string strFileDir = CVo.LOG_PATH_DATA;
        List<string> listFiles = new List<string>();
        listFiles.Clear();
        try
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strFileName = System.IO.Path.GetFileName(f);
            if (strFileName.Contains(CVo.LOG_NAME_DATA))
            {
              listFiles.Add(f);
            }
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }


        for (int i = 0; i < listFiles.Count; i++)
        {
          string[] strFileName = null;
          try
          {
            strFileName = System.IO.Path.GetFileName(listFiles[i]).Split('_');
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }

          if ((1 < strFileName.Length) == false)
          {
            continue;
          }
          System.DateTime sTempDate = System.DateTime.Now;
          bool bPossibleTempDate = System.DateTime.TryParseExact(strFileName[0], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sTempDate);
          if (bPossibleTempDate == false)
          {
            continue;
          }

          if (System.IO.File.Exists(listFiles[i]))
          {
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(listFiles[i], System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length < 4)
                {
                  continue;
                }
                System.DateTime sTempDateLine = System.DateTime.Now;
                bool bPossibleTempDateLine = System.DateTime.TryParseExact(strData[1], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempDateLine);
                if (bPossibleTempDateLine == false)
                {
                  continue;
                }

                list.Add(strReadLine);
              }
            }
            catch (Exception ex)
            {
              CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
              bResultError = true;
            }
            finally
            {
              if (sr != null)
              {
                sr.Close();
                sr = null;
              }
            }
            if (bResultError)
            {
              return false;
            }

          }
        }
      }

      grid_Log_DataLog.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        if ((grid_Log_DataLog.ColumnCount + 1) < list[i].Split(',').Length)
        {
          continue;
        }
        for (int j = 0; j < list[i].Split(',').Length - 1; j++)
        {
          grid_Log_DataLog.Rows[i].Cells[j].Value = list[i].Split(',')[j + 1];
        }
      }
      return true;
    }

    private void tabDataLog_SelectedIndexChanged(object sender, EventArgs e)
    {
      Update_TabStatus();
    }
  }
}
