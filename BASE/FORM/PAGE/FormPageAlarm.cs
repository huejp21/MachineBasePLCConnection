using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BASE.VO;
using BASE.MASTER;

namespace BASE.FORM.PAGE
{

  public partial class FormPageAlarm : Form
  {
    public enum enumSelectAlarmTab
    {
      AlarmStop,
      AlarmWarn,
      Exception,
      ChangedParameter,
    }

    private enumSelectAlarmTab eSelectTab = enumSelectAlarmTab.AlarmStop;
    private List<string> listCurrentResult = new List<string>();

    private int iStartTime = 0;
    private int iEndTime = 0;

    public FormPageAlarm()
    {
      InitializeComponent();
    }

    private void FormPageAlarm_Load(object sender, EventArgs e)
    {
      cbo_Alarm_TimeStart.Items.Clear();
      cbo_Alarm_TimeEnd.Items.Clear();
      for (int i = 0; i < 24; i++)
      {
        cbo_Alarm_TimeStart.Items.Add(i.ToString("00"));
        cbo_Alarm_TimeEnd.Items.Add(i.ToString("00"));
      }
      cbo_Alarm_TimeStart.SelectedIndex = 0;
      cbo_Alarm_TimeEnd.SelectedIndex = 23;
      iStartTime = 0;
      iEndTime = 23;

      tabAlarm.SelectedTab = tabpAlarmStop;

      Update_TabStatus();
    }

    private void Update_TabStatus()
    {
      Control ctrl = (Control)tabAlarm.SelectedTab;
      switch (ctrl.Name)
      {
        case "tabpAlarmStop": eSelectTab = enumSelectAlarmTab.AlarmStop; break;
        case "tabpAlarmWarn": eSelectTab = enumSelectAlarmTab.AlarmWarn; break;
        case "tabpException": eSelectTab = enumSelectAlarmTab.Exception; break;
        case "tabpChangedParameter": eSelectTab = enumSelectAlarmTab.ChangedParameter; break;
        default:
          break;
      }
    }

    private void cbo_Alarm_TimeStart_SelectedIndexChanged(object sender, EventArgs e)
    {
      iStartTime = Convert.ToInt32(cbo_Alarm_TimeStart.Text);
    }

    private void cbo_Alarm_TimeEnd_SelectedIndexChanged(object sender, EventArgs e)
    {
      iEndTime = Convert.ToInt32(cbo_Alarm_TimeEnd.Text);
    }

    private void txt_Alarm_Word_Click(object sender, EventArgs e)
    {
      string strKey = CForm.frmKeypadChar.Show_(txt_Alarm_Word.Text, "");
      if (strKey.CompareTo(strKey.Trim()) != 0)
      {
        return;
      }
      txt_Alarm_Word.Text = strKey;
    }

    private void tabAlarm_SelectedIndexChanged(object sender, EventArgs e)
    {
      Update_TabStatus();
    }

    private void btn_Alarm_Search_All_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.AllLogView_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      bool bResult = true;
      switch (eSelectTab)
      {
        case enumSelectAlarmTab.AlarmStop: bResult = Search_Alarm_Stop(false); break;
        case enumSelectAlarmTab.AlarmWarn: bResult = Search_Alarm_Warn(false); break;
        case enumSelectAlarmTab.Exception: bResult = Search_Exception(false); break;
        case enumSelectAlarmTab.ChangedParameter: bResult = Search_ChangedParameter(false); break;
        default: break;
      }
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.DataAlarmSearchFail);
      }
    }

    private void btn_Alarm_Search_Option_Click(object sender, EventArgs e)
    {
      bool bResult = true;
      switch (eSelectTab)
      {
        case enumSelectAlarmTab.AlarmStop: bResult = Search_Alarm_Stop(true); break;
        case enumSelectAlarmTab.AlarmWarn: bResult = Search_Alarm_Warn(true); break;
        case enumSelectAlarmTab.Exception: bResult = Search_Exception(true); break;
        case enumSelectAlarmTab.ChangedParameter: bResult = Search_ChangedParameter(true); break;
        default: break;
      }
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.DataAlarmSearchFail);
      }
    }

    private bool Search_Alarm_Stop(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Alarm_Start.Value;
      System.DateTime dte = dtp_Alarm_End.Value;
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
      grid_Alarm_Stop.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        int iDiff = (sEndDate - sStartDate).Days;
        for (int i = 0; i <= iDiff; i++)
        {
          System.DateTime temp = sStartDate;
          temp.AddDays(i);
          string strFileDir = CVo.LOG_PATH_ALARM_STOP;
          string strFileFull = strFileDir + temp.ToString("yyyyMMdd") + "_" + CVo.LOG_NAME_ALARM_STOP;
          if (System.IO.Directory.Exists(strFileDir))
          {
            if (System.IO.File.Exists(strFileFull))
            {
              System.IO.StreamReader sr = null;
              try
              {
                sr = new System.IO.StreamReader(strFileFull, System.Text.Encoding.UTF8);
                string strReadLine = null;
                while ((strReadLine = sr.ReadLine()) != null)
                {
                  string[] strData = strReadLine.Split(',');
                  if (strData.Length > 3)
                  {
                    if (strData[0].CompareTo("Time") == 0)
                    {
                      continue;
                    }
                    System.DateTime sTempTime = System.DateTime.Now;
                    bool bPossibleTemp = System.DateTime.TryParseExact(strData[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempTime);
                    if (bPossibleTemp == false)
                    {
                      continue;
                    }
                    if (sStartDate > sTempTime || sTempTime > sEndDate)
                    {
                      continue;
                    }
                    bool bSearched = false;
                    if (txt_Alarm_Word.Text.Trim().CompareTo("") == 0)
                    {
                      bSearched = true;
                    }
                    for (int j = 0; j < strData.Length; j++)
                    {
                      if (strData[j].Contains(txt_Alarm_Word.Text.Trim()))
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
            }
          }
          if (bResultError)
          {
            return false;
          }
        }
      }
      else
      {
        // 전체 검색


        string strFileDir = CVo.LOG_PATH_ALARM_STOP;
        if (System.IO.Directory.Exists(strFileDir))
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strName = System.IO.Path.GetFileName(f);
            string[] temp = strName.Split('_');
            if (temp.Length < 1)
            {
              continue;
            }
            if (temp[1].CompareTo(CVo.LOG_NAME_ALARM_STOP) != 0)
            {
              continue;
            }
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(f, System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length > 3)
                {
                  if (strData[0].CompareTo("Time") == 0)
                  {
                    continue;
                  }
                  list.Add(strReadLine);
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
          }
        }
        if (bResultError)
        {
          return false;
        }
      }

      grid_Alarm_Stop.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        grid_Alarm_Stop.Rows[i].Cells[0].Value = i.ToString();
        grid_Alarm_Stop.Rows[i].Cells[1].Value = list[i].Split(',')[0];
        grid_Alarm_Stop.Rows[i].Cells[2].Value = list[i].Split(',')[1];
        grid_Alarm_Stop.Rows[i].Cells[3].Value = list[i].Split(',')[2];
        grid_Alarm_Stop.Rows[i].Cells[4].Value = list[i].Split(',')[3];
      }
      listCurrentResult = list;
      return true;
    }
    private bool Search_Alarm_Warn(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Alarm_Start.Value;
      System.DateTime dte = dtp_Alarm_Start.Value;
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
      grid_Alarm_Warn.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        int iDiff = (sEndDate - sStartDate).Days;
        for (int i = 0; i <= iDiff; i++)
        {
          System.DateTime temp = sStartDate;
          temp.AddDays(i);
          string strFileDir = CVo.LOG_PATH_ALARM_WARN;
          string strFileFull = strFileDir + temp.ToString("yyyyMMdd") + "_" + CVo.LOG_NAME_ALARM_WARN;
          if (System.IO.Directory.Exists(strFileDir))
          {
            if (System.IO.File.Exists(strFileFull))
            {
              System.IO.StreamReader sr = null;
              try
              {
                sr = new System.IO.StreamReader(strFileFull, System.Text.Encoding.UTF8);
                string strReadLine = null;
                while ((strReadLine = sr.ReadLine()) != null)
                {
                  string[] strData = strReadLine.Split(',');
                  if (strData.Length > 3)
                  {
                    if (strData[0].CompareTo("Time") == 0)
                    {
                      continue;
                    }
                    System.DateTime sTempTime = System.DateTime.Now;
                    bool bPossibleTemp = System.DateTime.TryParseExact(strData[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempTime);
                    if (bPossibleTemp == false)
                    {
                      continue;
                    }
                    if (sStartDate > sTempTime || sTempTime > sEndDate)
                    {
                      continue;
                    }
                    bool bSearched = false;
                    if (txt_Alarm_Word.Text.Trim().CompareTo("") == 0)
                    {
                      bSearched = true;
                    }
                    for (int j = 0; j < strData.Length; j++)
                    {
                      if (strData[j].Contains(txt_Alarm_Word.Text.Trim()))
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
            }
          }
          if (bResultError)
          {
            return false;
          }
        }
      }
      else
      {
        // 전체 검색


        string strFileDir = CVo.LOG_PATH_ALARM_WARN;
        if (System.IO.Directory.Exists(strFileDir))
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strName = System.IO.Path.GetFileName(f);
            string[] temp = strName.Split('_');
            if (temp.Length < 1)
            {
              continue;
            }
            if (temp[1].CompareTo(CVo.LOG_NAME_ALARM_WARN) != 0)
            {
              continue;
            }
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(f, System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length > 3)
                {
                  if (strData[0].CompareTo("Time") == 0)
                  {
                    continue;
                  }
                  list.Add(strReadLine);
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
          }
        }
        if (bResultError)
        {
          return false;
        }
      }

      grid_Alarm_Warn.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        grid_Alarm_Warn.Rows[i].Cells[0].Value = i.ToString();
        grid_Alarm_Warn.Rows[i].Cells[1].Value = list[i].Split(',')[0];
        grid_Alarm_Warn.Rows[i].Cells[2].Value = list[i].Split(',')[1];
        grid_Alarm_Warn.Rows[i].Cells[3].Value = list[i].Split(',')[2];
        grid_Alarm_Warn.Rows[i].Cells[4].Value = list[i].Split(',')[3];
      }
      listCurrentResult = list;
      return true;
    }
    private bool Search_Exception(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Alarm_Start.Value;
      System.DateTime dte = dtp_Alarm_Start.Value;
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

      grid_Exception.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        int iDiff = (sEndDate - sStartDate).Days;
        for (int i = 0; i <= iDiff; i++)
        {
          System.DateTime temp = sStartDate;
          temp.AddDays(i);
          string strFileDir = CVo.LOG_PATH_DEBUG;
          string strFileFull = strFileDir + temp.ToString("yyyyMMdd") + "_" + CVo.LOG_NAME_DEBUG;
          if (System.IO.Directory.Exists(strFileDir))
          {
            if (System.IO.File.Exists(strFileFull))
            {
              System.IO.StreamReader sr = null;
              try
              {
                sr = new System.IO.StreamReader(strFileFull, System.Text.Encoding.UTF8);
                string strReadLine = null;
                while ((strReadLine = sr.ReadLine()) != null)
                {
                  string[] strData = strReadLine.Split(',');
                  if (strData.Length > 3)
                  {
                    if (strData[0].CompareTo("Time") == 0)
                    {
                      continue;
                    }
                    System.DateTime sTempTime = System.DateTime.Now;
                    bool bPossibleTemp = System.DateTime.TryParseExact(strData[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempTime);
                    if (bPossibleTemp == false)
                    {
                      continue;
                    }
                    if (sStartDate > sTempTime || sTempTime > sEndDate)
                    {
                      continue;
                    }
                    bool bSearched = false;
                    if (txt_Alarm_Word.Text.Trim().CompareTo("") == 0)
                    {
                      bSearched = true;
                    }
                    for (int j = 0; j < strData.Length; j++)
                    {
                      if (strData[j].Contains(txt_Alarm_Word.Text.Trim()))
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
            }
          }
          if (bResultError)
          {
            return false;
          }
        }
      }

      // 전체 검색
      else
      {
        string strFileDir = CVo.LOG_PATH_DEBUG;
        if (System.IO.Directory.Exists(strFileDir))
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strName = System.IO.Path.GetFileName(f);
            string[] temp = strName.Split('_');
            if (temp.Length < 1)
            {
              continue;
            }
            if (temp[1].CompareTo(CVo.LOG_NAME_DEBUG) != 0)
            {
              continue;
            }
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(f, System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length > 3)
                {
                  if (strData[0].CompareTo("Time") == 0)
                  {
                    continue;
                  }
                  list.Add(strReadLine);
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
          }
        }
        if (bResultError)
        {
          return false;
        }
      }

      grid_Exception.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        grid_Exception.Rows[i].Cells[0].Value = i.ToString();
        grid_Exception.Rows[i].Cells[1].Value = list[i].Split(',')[0];
        grid_Exception.Rows[i].Cells[2].Value = list[i].Split(',')[1];
        grid_Exception.Rows[i].Cells[3].Value = list[i].Split(',')[2];
        grid_Exception.Rows[i].Cells[4].Value = list[i].Split(',')[3];
      }
      listCurrentResult = list;
      
      return true;
    }
    private bool Search_ChangedParameter(bool useOption)
    {
      // useOption false: 전체 검색 true: 옵션 검색
      bool bResultError = false;
      System.DateTime dts = dtp_Alarm_Start.Value;
      System.DateTime dte = dtp_Alarm_Start.Value;
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

      grid_ChangedParameter.RowCount = 0;

      if (useOption)
      {
        // 옵션 검색
        if (sEndDate < sStartDate)
        {
          return false;
        }
        int iDiff = (sEndDate - sStartDate).Days;
        for (int i = 0; i <= iDiff; i++)
        {
          System.DateTime temp = sStartDate;
          temp.AddDays(i);
          string strFileDir = CVo.LOG_PATH_CHANGE_PARAMETER;
          string strFileFull = strFileDir + temp.ToString("yyyyMMdd") + "_" + CVo.LOG_NAME_CHANGE_PARAMETER;
          if (System.IO.Directory.Exists(strFileDir))
          {
            if (System.IO.File.Exists(strFileFull))
            {
              System.IO.StreamReader sr = null;
              try
              {
                sr = new System.IO.StreamReader(strFileFull, System.Text.Encoding.UTF8);
                string strReadLine = null;
                while ((strReadLine = sr.ReadLine()) != null)
                {
                  string[] strData = strReadLine.Split(',');
                  if (strData.Length > 6)
                  {
                    if (strData[0].CompareTo("Time") == 0)
                    {
                      continue;
                    }
                    System.DateTime sTempTime = System.DateTime.Now;
                    bool bPossibleTemp = System.DateTime.TryParseExact(strData[0], "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sTempTime);
                    if (bPossibleTemp == false)
                    {
                      continue;
                    }
                    if (sStartDate > sTempTime || sTempTime > sEndDate)
                    {
                      continue;
                    }
                    bool bSearched = false;
                    if (txt_Alarm_Word.Text.Trim().CompareTo("") == 0)
                    {
                      bSearched = true;
                    }
                    for (int j = 0; j < strData.Length; j++)
                    {
                      if (strData[j].Contains(txt_Alarm_Word.Text.Trim()))
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
            }
          }
          if (bResultError)
          {
            return false;
          }
        }
      }

      // 전체 검색
      else
      {
        string strFileDir = CVo.LOG_PATH_CHANGE_PARAMETER;
        if (System.IO.Directory.Exists(strFileDir))
        {
          foreach (string f in System.IO.Directory.GetFiles(strFileDir))
          {
            string strName = System.IO.Path.GetFileName(f);
            string[] temp = strName.Split('_');
            if (temp.Length < 1)
            {
              continue;
            }
            if (temp[1].CompareTo(CVo.LOG_NAME_CHANGE_PARAMETER) != 0)
            {
              continue;
            }
            System.IO.StreamReader sr = null;
            try
            {
              sr = new System.IO.StreamReader(f, System.Text.Encoding.UTF8);
              string strReadLine = null;
              while ((strReadLine = sr.ReadLine()) != null)
              {
                string[] strData = strReadLine.Split(',');
                if (strData.Length > 6)
                {
                  if (strData[0].CompareTo("Time") == 0)
                  {
                    continue;
                  }
                  list.Add(strReadLine);
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
          }
        }
        if (bResultError)
        {
          return false;
        }
      }

      grid_ChangedParameter.RowCount = list.Count;
      for (int i = 0; i < list.Count; i++)
      {
        for (int j = 0; j < list[i].Split(',').Length; j++)
        {
          grid_ChangedParameter.Rows[i].Cells[j].Value = list[i].Split(',')[j];
        }
      }
      listCurrentResult = list;

      return true;
    }

    private void FormPageAlarm_Shown(object sender, EventArgs e)
    {
      dtp_Alarm_Start.Value = System.DateTime.Now;
      dtp_Alarm_End.Value = System.DateTime.Now;
    }

    private void FormPageAlarm_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        dtp_Alarm_Start.Value = System.DateTime.Now;
        dtp_Alarm_End.Value = System.DateTime.Now;
      }
    }


  }
}
