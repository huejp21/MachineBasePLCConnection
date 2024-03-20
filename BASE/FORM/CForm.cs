using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.FORM.MSGBOX;
using BASE.FORM.SETUP.COMMON;
using BASE.FORM.PAGE;
using BASE.VO;
using BASE.FORM.SETUP.MOTOR;
using BASE.FORM.SETUP.IO;
using BASE.MODULE.PLC;
using BASE.MODULE.BCR;
using BASE.MASTER;

namespace BASE.FORM
{
  #region Define
  
  #endregion

  static public class CForm
  {
    //InitForm
    public static FormStartUp frmStartup = new FormStartUp();

    //Main Form
    public static FormMother frmMother = null;  //Parent Form!!!

    public static FormNavigation frmNavigation = new FormNavigation();
    public static FormTitle frmTitle = new FormTitle();
    public static FormControl frmControl = new FormControl();

    //MessageBox
    public static FormMessageBox_Info frmMessageInfo = new FormMessageBox_Info();
    public static FormMessageBox_Input frmMessageInput = new FormMessageBox_Input();
    public static FormMessageBox_Msg frmMessageMsg = new FormMessageBox_Msg();
    public static FormMessageBox_Alarm frmMessageAlarm = new FormMessageBox_Alarm();
    public static FormMessageBox_AlarmStop frmMessageAlarmStop = new FormMessageBox_AlarmStop();

    //Setup Common
    public static FormKeypadChar frmKeypadChar = new FormKeypadChar();
    public static FormKeypadNum frmKeypadNum = new FormKeypadNum();
    public static FormFolderCreate frmCreate = new FormFolderCreate();
    public static FormFolderCopy frmCopy = new FormFolderCopy();
    public static FormSelectPointType frmPointType = new FormSelectPointType();
    public static FormBCR_Lot frmBCR_Lot = new FormBCR_Lot();

    //Setup & Viewer
    public static FormMotorControl frmMotorControl = new FormMotorControl();
    public static FormIoControl frmIoControl = new FormIoControl();
    public static FormPLCView frmPLCView = new FormPLCView();
    public static FormThreadView frmThView = new FormThreadView();

    //Page
    public static List<System.Windows.Forms.Form> listPage = new List<System.Windows.Forms.Form>(); //Page Manager List
    public static System.Windows.Forms.Form frmCurrentPage = null;
    public static FormPageLogin frmPageLogin = new FormPageLogin();
    public static FormPageLoginCreate frmPageLoginCreate = new FormPageLoginCreate();
    public static FormPageLoginManage frmPageLoginManage = new FormPageLoginManage();
    public static FormPageDebug frmPageDebug = new FormPageDebug();
    public static FormPageRecipe frmPageRecipe = new FormPageRecipe();
    public static FormPageAuto frmPageAuto = new FormPageAuto();
    public static FormPageSetup frmPageSetup = new FormPageSetup();
    public static FormPageManual frmPageManual = new FormPageManual();
    public static FormPageDataLog frmPageDataLog = new FormPageDataLog();
    public static FormPageAlarm frmPageAlarm = new FormPageAlarm();
    public static FormPageTestCycle frmPageTestCycle = new FormPageTestCycle();


    //Extern Form
    //public static FormMxComponent frmMxComponent = new FormMxComponent();
    public static FormBCR frmBCR = new FormBCR();

    //For Language Change 
    public static List<System.Windows.Forms.Control> listControl = new List<System.Windows.Forms.Control>(); //Language Manager List

    #region Initialize
    public static void Init_()
    {
      /////////////////////////
      //Add Frame
      /////////////////////////
      Add_Form(frmMother.pnlMotherBottom, frmNavigation); //Frame Navigation
      Add_Form(frmMother.pnlMotherControl, frmControl); //Frame Control
      Add_Form(frmMother.pnlMotherTop, frmTitle); //Frame Title

      /////////////////////////
      //Add Page
      /////////////////////////
      listPage.Clear();
      Add_Page(frmPageDebug);
      Add_Page(frmPageLogin);
      Add_Page(frmPageLoginCreate);
      Add_Page(frmPageLoginManage);
      Add_Page(frmPageRecipe);
      Add_Page(frmPageAuto);
      Add_Page(frmPageSetup);
      Add_Page(frmPageManual);
      Add_Page(frmPageDataLog);
      Add_Page(frmPageAlarm);
      Add_Page(frmPageTestCycle);      

      /////////////////////////
      //AddControl for Language
      /////////////////////////
      listControl.Clear();
      for (int i = 0; i < listPage.Count; i++)
      {
        Add_AllControls(listPage[i]);
      } //Page List
      Add_AllControls(frmMother);
      Add_AllControls(frmNavigation);
      Add_AllControls(frmTitle);
      Add_AllControls(frmControl);
      Add_AllControls(frmMessageInfo);
      Add_AllControls(frmMessageInput);
      Add_AllControls(frmMessageMsg);
      Add_AllControls(frmMessageAlarm);
      Add_AllControls(frmMessageAlarmStop);
      Add_AllControls(frmKeypadChar);
      Add_AllControls(frmKeypadNum);
      Add_AllControls(frmCreate);
      Add_AllControls(frmCopy);
      Add_AllControls(frmMotorControl);
      Add_AllControls(frmIoControl);
      Add_AllControls(frmPLCView);
      Add_AllControls(frmThView);
      Add_AllControls(frmBCR);
      Add_AllControls(frmPointType);
      Add_AllControls(frmBCR_Lot);
      
      /////////////////////////
      //Extern Form
      /////////////////////////
      //frmMxComponent.TopMost = true;
      //frmMxComponent.TopLevel = false;
      //frmMxComponent.Parent = frmTitle;
      //frmMxComponent.Size = frmTitle.pnl_title_PLC.Size;
      //frmTitle.pnl_title_PLC.Controls.Add(frmMxComponent);
      //frmMxComponent.Show();

      listControl = Check_OverlapControl(listControl); //Remove overlap data

    } //Initialize Form

    public static bool Init_Hardware()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      bool bResult_BCR = CMaster.cBCR.Open_Port();
      bool bResult_Probe1 = CMaster.cProbe1.Open_Port(cSys.strProbe1_Com, cSys.strProbe1_Baudrate);
      bool bResult_Probe2 = CMaster.cProbe2.Open_Port(cSys.strProbe2_Com, cSys.strProbe2_Baudrate);
      bool bResult_PLC = true;//CMaster.cPlc.Open();
      // 이곳에서 PLC 초기화 값 보냄
      //CIoVo.Send_Init();
      CVo.bSetupMode = false;
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1420_Setup_Mode, CVo.bSetupMode ? 1 : 0);


      bool bResult = bResult_BCR && bResult_Probe1 && bResult_Probe2 && bResult_PLC;
      return bResult;
    }

    private static void Add_AllControls(System.Windows.Forms.Form form)
    {
      System.Windows.Forms.Control.ControlCollection ctrl = form.Controls;
      Add_Controls(ctrl);
    } //Add Control from Form

    private static void Add_Controls(System.Windows.Forms.Control.ControlCollection ctrl)
    {
      foreach (System.Windows.Forms.Control con in ctrl)
      {
        if (con.Controls.Count > 0)
        {
          Add_Controls(con.Controls);
        }
        listControl.Add(con);
      }
    } //Add Control in List Value (Recurcive Function)

    private static List<System.Windows.Forms.Control> Check_OverlapControl(List<System.Windows.Forms.Control> list)
    {
      List<System.Windows.Forms.Control> newList = new List<System.Windows.Forms.Control>();
      newList.Clear();
      for (int i = 0; i < list.Count; i++)
      {
        if (!newList.Contains(list[i]))
        {
          newList.Add(list[i]);
        }
      }
      return newList;
    } //Remove overlap data
    #endregion

    #region Terminator
    #endregion

    #region Setup Function
    private static void Add_Form(System.Windows.Forms.Panel pnl, System.Windows.Forms.Form form)
    {
      form.TopMost = true;
      form.TopLevel = false;
      form.Parent = frmMother;
      pnl.Controls.Add(form);
      form.Show();
    } //Add Form (Panel <- Form)

    private static void Add_Page(System.Windows.Forms.Form form)
    {
      form.TopMost = true;
      form.TopLevel = false;
      form.Parent = frmMother;
      frmMother.pnlMotherMain.Controls.Add(form);
      listPage.Add(form);
      form.Hide();
    } //Add Page (Main Panel <- Form)
    #endregion

    #region Control Form Function

    #region Form
    public static void Draw_PCBMap(System.Windows.Forms.Form form, System.Windows.Forms.PictureBox pic, System.Windows.Forms.Label size) // PCB 맵 그리기
    {
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      // Point Set 그리기
      int iWidth = (int)cRcp.dPCB_Width;
      int iHeight = (int)cRcp.dPCB_Height;

      System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
     .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
      controlProperty.SetValue(pic, true, null);

      System.Drawing.Graphics gp = pic.CreateGraphics();
      System.Windows.Forms.Control map = (System.Windows.Forms.Control)pic;
      
      string str = pic.Parent.ToString();
      System.Drawing.SolidBrush solbr_Back = new System.Drawing.SolidBrush(System.Drawing.Color.White);
      System.Drawing.SolidBrush solbr_PCB = new System.Drawing.SolidBrush(System.Drawing.Color.SeaGreen);
      System.Drawing.SolidBrush solbr_Y1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
      System.Drawing.SolidBrush solbr_Y2 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
      System.Drawing.Pen penCenterLine = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

      penCenterLine.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

      gp.FillRectangle(solbr_Back, 0, 0, pic.Width, pic.Height);
      gp.FillRectangle(solbr_PCB, 0, 0, iWidth, iHeight);
      gp.DrawLine(penCenterLine, new System.Drawing.Point(0, (int)(iHeight / 2)), new System.Drawing.Point(iWidth, (int)(iHeight / 2)));
      gp.DrawLine(penCenterLine, new System.Drawing.Point((int)(iWidth / 2), 0), new System.Drawing.Point((int)(iWidth / 2), iHeight));

      System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
      for (int i = 0; i < cRcp.iPointCount; i++)
      {
        if (cRcp.abUsePointX[i])
        {
          switch ((enumPointType)cRcp.aiPointY1_Type[i])
          {
            case enumPointType.Dummy: 
              solbr_Y1 = new System.Drawing.SolidBrush(System.Drawing.Color.Magenta);
              break;
            case enumPointType.Unit: 
              solbr_Y1 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
              break;
            case enumPointType.NONE: 
            default:
              solbr_Y1 = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
              break;
          }

          switch ((enumPointType)cRcp.aiPointY2_Type[i])
          {
            case enumPointType.Dummy:
              solbr_Y2 = new System.Drawing.SolidBrush(System.Drawing.Color.Magenta);
              break;
            case enumPointType.Unit:
              solbr_Y2 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
              break;
            case enumPointType.NONE:
            default:
              solbr_Y2 = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
              break;
          }

          if (cRcp.abUsePointY_Two[i])
          {
            int iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            int iPointY = (int)((iHeight / 2) - cRcp.adPointY1[i]);
            string strText = string.Format("{0}-{1}", i + 1, "1");
            gp.DrawString(strText, drawFont, solbr_Y1, new System.Drawing.Point(iPointX, iPointY));
            gp.FillRectangle(solbr_Y1, iPointX, iPointY, 4, 4);

            iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            iPointY = (int)((iHeight / 2) - cRcp.adPointY2[i]);
            strText = string.Format("{0}-{1}", i + 1, "2");
            gp.DrawString(strText, drawFont, solbr_Y2, new System.Drawing.Point(iPointX, iPointY));
            gp.FillRectangle(solbr_Y2, iPointX, iPointY, 4, 4);
          }
          else
          {
            int iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            int iPointY = (int)((iHeight / 2) - cRcp.adPointY1[i]);
            string strText = string.Format("{0}-{1}", i + 1, "1");
            gp.DrawString(strText, drawFont, solbr_Y1, new System.Drawing.Point(iPointX, iPointY));
            gp.FillRectangle(solbr_Y1, iPointX, iPointY, 4, 4);
          }
        }
      }
      string strSize = string.Format("{0}mm / {1}mm", cRcp.dPCB_Width, cRcp.dPCB_Height);
      size.Text = strSize;
    }
    public static void Draw_PCBMap_Number(System.Windows.Forms.Form form, System.Windows.Forms.PictureBox pic, System.Windows.Forms.Label size) // PCB 맵 그리기
    {
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      // Point Set 그리기
      int iWidth = (int)cRcp.dPCB_Width;
      int iHeight = (int)cRcp.dPCB_Height;

      System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
     .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
      controlProperty.SetValue(pic, true, null);

      System.Drawing.Graphics gp = pic.CreateGraphics();
      System.Windows.Forms.Control map = (System.Windows.Forms.Control)pic;

      string str = pic.Parent.ToString();
      System.Drawing.SolidBrush solbr_Back = new System.Drawing.SolidBrush(System.Drawing.Color.White);
      System.Drawing.SolidBrush solbr_PCB = new System.Drawing.SolidBrush(System.Drawing.Color.SeaGreen);
      //System.Drawing.SolidBrush solbr_Point = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
      System.Drawing.SolidBrush solbr_Number = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
      System.Drawing.Pen penCenterLine = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

      penCenterLine.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

      gp.FillRectangle(solbr_Back, 0, 0, pic.Width, pic.Height);
      gp.FillRectangle(solbr_PCB, 0, 0, iWidth, iHeight);
      gp.DrawLine(penCenterLine, new System.Drawing.Point(0, (int)(iHeight / 2)), new System.Drawing.Point(iWidth, (int)(iHeight / 2)));
      gp.DrawLine(penCenterLine, new System.Drawing.Point((int)(iWidth / 2), 0), new System.Drawing.Point((int)(iWidth / 2), iHeight));

      System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
      List<int[]> listLocation = new List<int[]>();
      List<System.Drawing.SolidBrush> listPointBr = new List<System.Drawing.SolidBrush>();
      listLocation.Clear();
      listPointBr.Clear();

      for (int i = 0; i < cRcp.iPointCount; i++)
      {
        if (cRcp.abUsePointX[i])
        {
          if (cRcp.abUsePointY_Two[i])
          {
            int iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            int iPointY = (int)((iHeight / 2) - cRcp.adPointY1[i]);
            listLocation.Add(new int[] { iPointX, iPointY });
            switch ((enumPointType)cRcp.aiPointY1_Type[i])
            {
              case enumPointType.Dummy:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Magenta));
                break;
              case enumPointType.Unit:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Blue));
                break;
              case enumPointType.NONE: 
              default:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.LightGray));
                break;
            }

            iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            iPointY = (int)((iHeight / 2) - cRcp.adPointY2[i]);
            listLocation.Add(new int[] { iPointX, iPointY });
            switch ((enumPointType)cRcp.aiPointY2_Type[i])
            {
              case enumPointType.Dummy:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Magenta));
                break;
              case enumPointType.Unit:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Blue));
                break;
              case enumPointType.NONE:
              default:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.LightGray));
                break;
            }
          }
          else
          {
            int iPointX = (int)((iWidth / 2) + cRcp.adPointX[i]);
            int iPointY = (int)((iHeight / 2) - cRcp.adPointY1[i]);
            listLocation.Add(new int[] { iPointX, iPointY });
            switch ((enumPointType)cRcp.aiPointY1_Type[i])
            {
              case enumPointType.Dummy:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Magenta));
                break;
              case enumPointType.Unit:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.Blue));
                break;
              case enumPointType.NONE:
              default:
                listPointBr.Add(new System.Drawing.SolidBrush(System.Drawing.Color.LightGray));
                break;
            }
          }
        }
      }

      for (int i = 0; i < listLocation.Count; i++)
      {
        string strText = string.Format("{0}", i + 1);
        gp.DrawString(strText, drawFont, listPointBr[i], new System.Drawing.Point(listLocation[i][0], listLocation[i][1]));
        gp.FillRectangle(listPointBr[i], listLocation[i][0], listLocation[i][1], 4, 4);
      }

      string strSize = string.Format("{0}mm / {1}mm", cRcp.dPCB_Width, cRcp.dPCB_Height);
      size.Text = strSize;
    }


    public static void Check_Display(System.Windows.Forms.Form form)
    {
      bool bOpened = false;
      foreach (System.Windows.Forms.Form frm in System.Windows.Forms.Application.OpenForms)
      {
        if (frm.Name == form.Name)
        {
          bOpened = true;
        }
      }
      if (bOpened)
      {
        form.Hide();
      }
    } //Privent Overlap Dialog
    public static void Hide_Application()
    {
      frmMother.ShowInTaskbar = false;
      frmMother.Hide();
    } //Hide Main Window
    public static void Show_Application()
    {
      System.Windows.Forms.Form Form = frmMother;
      bool bOpened = false;
      foreach (System.Windows.Forms.Form frm in System.Windows.Forms.Application.OpenForms)
      {
        if (frm.Name == Form.Name)
        {
          bOpened = true;
        }
      }
      if (bOpened)
      {
        Form.Hide();
      }
      Form.ShowInTaskbar = true;
      Form.Show();
    } //Show Main Window
    public static void Display_Page(System.Windows.Forms.Form form)
    {
      frmCurrentPage = form;
      string strNameForm = form.Name;
      for (int i = 0; i < listPage.Count; i++)
      {
        if (listPage[i].Name == strNameForm)
        {
          listPage[i].Show();
        }
        else
        {
          listPage[i].Hide();
        }
      }
    } //Page Change
    public static void Hide_Page()
    {
      for (int i = 0; i < listPage.Count; i++)
      {
        listPage[i].Hide();
      }
    } //Page All Hide
    #endregion

    #region Language
    public static bool Change_Language(enumLanguageType type)
    {
      CVo.eCurrentLanguage = type;
      string strDBPath = CVo.UI_PATH + CVo.UI_NAME_LANGUAGE;
      bool bResult = true;
      if (!System.IO.Directory.Exists(CVo.UI_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Language();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSQL = "SELECT * FROM tbLanguage;";
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSQL, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      int iIndexOffset = 2;
      int iIndex = ((int)CVo.eCurrentLanguage >= Enum.GetNames(typeof(enumLanguageType)).Length ? (int)enumLanguageType.Default_Caption : (int)CVo.eCurrentLanguage) + iIndexOffset;

      try
      {
        for (int i = 0; i < listControl.Count; i++)
        {
          for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
          {
            if (listControl[i].FindForm().Name.CompareTo(Ds.Tables[0].Rows[j][0].ToString()) == 0)
            {
              if (listControl[i].Name.CompareTo(Ds.Tables[0].Rows[j][1].ToString()) == 0)
              {
                listControl[i].Text = Ds.Tables[0].Rows[j][iIndex].ToString();
                break;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      if (!bResult)
      {
        return false;
      }

      return true;
    } //Language Change From Language DB
    public static bool Organize_Language()
    {
      string strDBPath = CVo.UI_PATH + CVo.UI_NAME_LANGUAGE;
      bool bResult = true;
      if (!System.IO.Directory.Exists(CVo.UI_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        return Create_Language();
      }

      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
      System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
      System.Data.DataSet Ds = new System.Data.DataSet();
      System.Data.OleDb.OleDbDataAdapter pAdapter = new System.Data.OleDb.OleDbDataAdapter();
      string strSql = "SELECT FormName, ControlName FROM tbLanguage;";
      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        pAdapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strSql, conn);
        pAdapter.Fill(Ds);
        connCmd.Connection = conn;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      List<int> listAdditionalDBData = new List<int>();
      listAdditionalDBData.Clear();
      bool bExsit = false;
      for (int i = 0; i < listControl.Count; i++)
      {
        bExsit = false;
        for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
        {
          if (listControl[i].FindForm().Name.CompareTo(Ds.Tables[0].Rows[j][0].ToString()) == 0)
          {
            if (listControl[i].Name.CompareTo(Ds.Tables[0].Rows[j][1].ToString()) == 0)
            {
              bExsit = true;
              break;
            }
          }
        }
        if (!bExsit)
        {
          listAdditionalDBData.Add(i);
        }
      }

      List<string> listRemoveDBData = new List<string>();
      listRemoveDBData.Clear();
      for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
      {
        listRemoveDBData.Add(Ds.Tables[0].Rows[i][0].ToString() + "," + Ds.Tables[0].Rows[i][1].ToString());
      }
      for (int i = 0; i < listControl.Count; i++)
      {
        listRemoveDBData.Remove(listControl[i].FindForm().Name + "," + listControl[i].Name);
      }

      // 중복제거 있으면 좋을듯

      if (listRemoveDBData.Count == 0 && listAdditionalDBData.Count == 0)
      {
        return true;
      }

      try
      {
        conn.ConnectionString =
                      @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                      + strDBPath
                      + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                      + "";
        conn.Open();
        connCmd.Connection = conn;
        for (int i = 0; i < listRemoveDBData.Count; i++)
        {
          connCmd.CommandText = "DELETE * FROM tbLanguage WHERE "
            + "FormName='" + listRemoveDBData[i].Split(',')[0] + "' AND "
            + "ControlName='" + listRemoveDBData[i].Split(',')[1] + "'"
            + ";";
          connCmd.ExecuteNonQuery();
        }

        for (int i = 0; i < listAdditionalDBData.Count; i++)
        {
          connCmd.CommandText = String.Format("INSERT INTO tbLanguage VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
                    , listControl[listAdditionalDBData[i]].FindForm().Name
                    , listControl[listAdditionalDBData[i]].Name
                    , listControl[listAdditionalDBData[i]].Text
                    , listControl[listAdditionalDBData[i]].Text
                    , listControl[listAdditionalDBData[i]].Text
                    , listControl[listAdditionalDBData[i]].Text
                    , listControl[listAdditionalDBData[i]].Text
                    );
          connCmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        conn.Close();
      }
      if (!bResult)
      {
        return false;
      }

      return true;
    } //Organize Language DB
    public static bool Create_Language()
    {
      string strDBPath = CVo.UI_PATH + CVo.UI_NAME_LANGUAGE;
      bool bResult = true;

      if (!System.IO.Directory.Exists(CVo.UI_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.UI_PATH);
      }
      if (!System.IO.File.Exists(strDBPath))
      {
        bool bCreated = false;
        try
        {
          string strNewDB =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                        + strDBPath
                        + ";Jet OLEDB:Database Password="
                        + "";
          Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");
          if (objClassType != null)
          {
            object obj = Activator.CreateInstance(objClassType);
            // Create MDB file
            obj.GetType().InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[] { "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewDB + ";" });
            bCreated = true;
            // Clean up
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        if (!bResult)
        {
          return false;
        }
        if (!bCreated)
        {
          return false;
        }

        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand connCmd = new System.Data.OleDb.OleDbCommand();
        try
        {
          conn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
                        + strDBPath
                        + ";Mode=ReadWrite;Jet OLEDB:Database Password="
                        + "";
          conn.Open();
          connCmd.Connection = conn;

          string strCaption = "";
          for (int i = 0; i < Enum.GetNames(typeof(enumLanguageType)).Length; i++)
          {
            strCaption += ("," + ((enumLanguageType)i).ToString() + " text");
          }

          connCmd.CommandText = "CREATE TABLE "
          + "tbLanguage" + "("
          + "FormName" + " text,"
          + "ControlName" + " text"
          + strCaption
          + ")";
          connCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }

        try
        {
          conn.ConnectionString =
              @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
              + strDBPath
              + ";Mode=ReadWrite;Jet OLEDB:Database Password="
              + "";
          conn.Open();
          connCmd.Connection = conn;
          for (int i = 0; i < listControl.Count; i++)
          {
            connCmd.CommandText = String.Format("INSERT INTO tbLanguage VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
                      , listControl[i].FindForm().Name
                      , listControl[i].Name
                      , listControl[i].Text
                      , listControl[i].Text
                      , listControl[i].Text
                      , listControl[i].Text
                      , listControl[i].Text
                      );
            connCmd.ExecuteNonQuery();
          }

        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          conn.Dispose();
          conn.Close();
        }
        if (!bResult)
        {
          return false;
        }
      }
      return true;
    } //Create Language DB
    #endregion

    #region Login
 
    #endregion 

    #endregion
  }
}
