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
using BASE.MODULE.MOTION;

namespace BASE.FORM
{
  public partial class FormNavigation : Form
  {
    List<System.Windows.Forms.Button> listButton = new List<Button>();

    public FormNavigation()
    {
      InitializeComponent();

      listButton.Clear();
      listButton.Add(this.btnNavigationAlarm);
      listButton.Add(this.btnNavigationAuto);
      listButton.Add(this.btnNavigationDatalog);
      listButton.Add(this.btnNavigationDebug);
      listButton.Add(this.btnNavigationExit);
      listButton.Add(this.btnNavigationManual);
      listButton.Add(this.btnNavigationRecipe);
      listButton.Add(this.btnNavigationSetup);
      listButton.Add(this.btnNavigationTestCycle);
    }

    private void btn_navigation_exit_Click(object sender, EventArgs e)
    {
      bool bPossible = false;
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
          bPossible = false;
          break;
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        default:
          bPossible = true;
          break;
      }

      if (bPossible)
      {
        if (CForm.frmMessageMsg.Show_(enumMsg.ProgramExit_E) != System.Windows.Forms.DialogResult.Yes)
        {
          return;
        }
        CMotionVo.StopMonitor();
        CMaster.Kill_Thread();
        CThreadMaster.Kill_Thread();
        CMaster.cPlc.Close();
        Application.Exit();
      }
    }

    private void btnClick(object sender, EventArgs e)
    {
      if (CVo.TestRunning())
      {
        return;
      }
      System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

      switch (btn.Name)
      {
        case "btnNavigationAuto":
          CForm.Display_Page(CForm.frmPageAuto);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationRecipe":
          CForm.Display_Page(CForm.frmPageRecipe);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationDebug":
          CForm.Display_Page(CForm.frmPageDebug);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationSetup":
          CForm.Display_Page(CForm.frmPageSetup);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationManual":
          CForm.Display_Page(CForm.frmPageManual);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationDatalog":
          CForm.Display_Page(CForm.frmPageDataLog);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationAlarm":
          CForm.Display_Page(CForm.frmPageAlarm);
          Change_ButtonColor(btn);
          break;
        case "btnNavigationTestCycle":
          CForm.Display_Page(CForm.frmPageTestCycle);
          Change_ButtonColor(btn);
          break;
        default:
          CForm.Hide_Page();
          On_Button(false);
          break;
      }
    }

    private void Change_ButtonColor(System.Windows.Forms.Button btn)
    {
      Image cImg_Off = ImgList_Button.Images[0];
      Image cImg_On = ImgList_Button.Images[1];
      Color cCrOff = Color.White;
      Color cCrOn = Color.Lime;

      for (int i = 0; i < listButton.Count; i++)
      {
        if (btn.Name.CompareTo(listButton[i].Name) == 0)
        {
          listButton[i].BackgroundImage = cImg_On;
          listButton[i].BackColor = cCrOn;
        }
        else
        {
          if (listButton[i].Enabled)
          {
            listButton[i].BackgroundImage = cImg_Off;
            listButton[i].BackColor = cCrOff;
          }
        }
      }
    }

    private void On_Button(bool on)
    {
      Image cImg_Off = ImgList_Button.Images[0];
      Image cImg_On = ImgList_Button.Images[1];
      Color cCrOff = Color.White;
      Color cCrOn = Color.Lime;

      for (int i = 0; i < listButton.Count; i++)
      {
        listButton[i].BackgroundImage = on ? cImg_On : cImg_Off;
        listButton[i].BackColor = on ? cCrOn : cCrOff;
      }
    }

    private void tmr_Navigation_Tick(object sender, EventArgs e)
    {
      tmr_Navigation.Enabled = false;
      if (CVo.eMachineStatus == enumMachineStatus.Auto)
      {
        btnNavigationAuto.Visible = true;
        btnNavigationRecipe.Visible = false;
        btnNavigationSetup.Visible = false;
        btnNavigationManual.Visible = false;
        btnNavigationDatalog.Visible = false;
        btnNavigationAlarm.Visible = false;
        btnNavigationDebug.Visible = false;
        btnNavigationTestCycle.Visible = false;
        bool bOpened = false;
        foreach (Form frm in Application.OpenForms)
        {
          if (frm.Name == CForm.frmPageAuto.Name)
          {
            bOpened = true;
          }
        }
        if (bOpened)
        {
          CForm.Display_Page(CForm.frmPageAuto);
          Change_ButtonColor(this.btnNavigationAuto);
        }
      }
      else
      {
        btnNavigationAuto.Visible = true;
        btnNavigationRecipe.Visible = true;
        btnNavigationSetup.Visible = true;
        btnNavigationManual.Visible = true;
        btnNavigationDatalog.Visible = true;
        btnNavigationAlarm.Visible = true;
        btnNavigationTestCycle.Visible = true;
        if (CVo.eCurrentUserLevel == enumUserLevel.Developer)
        {
          btnNavigationDebug.Visible = true;
        }
        else
        {
          btnNavigationDebug.Visible = false;
        }
      }

      switch (CVo.eCurrentUserLevel)
      {

        case enumUserLevel.Maintenance:
          btnNavigationAuto.Enabled = true;
          btnNavigationRecipe.Enabled = true;
          btnNavigationSetup.Enabled = true;
          btnNavigationManual.Enabled = true;
          btnNavigationDatalog.Enabled = true;
          btnNavigationAlarm.Enabled = true;
          btnNavigationDebug.Enabled = false;
          btnNavigationTestCycle.Enabled = true;
          break;
        case enumUserLevel.Administator:
          btnNavigationAuto.Enabled = true;
          btnNavigationRecipe.Enabled = true;
          btnNavigationSetup.Enabled = true;
          btnNavigationManual.Enabled = true;
          btnNavigationDatalog.Enabled = true;
          btnNavigationAlarm.Enabled = true;
          btnNavigationDebug.Enabled = false;
          btnNavigationTestCycle.Enabled = true;
          break;
        case enumUserLevel.Developer:
          btnNavigationAuto.Enabled = true;
          btnNavigationRecipe.Enabled = true;
          btnNavigationSetup.Enabled = true;
          btnNavigationManual.Enabled = true;
          btnNavigationDatalog.Enabled = true;
          btnNavigationAlarm.Enabled = true;
          btnNavigationDebug.Enabled = true;
          btnNavigationTestCycle.Enabled = true;
          break;
        case enumUserLevel.Operator:
        default:
          btnNavigationAuto.Enabled = true;
          btnNavigationRecipe.Enabled = true;
          btnNavigationSetup.Enabled = false;
          btnNavigationManual.Enabled = true;
          btnNavigationDatalog.Enabled = true;
          btnNavigationAlarm.Enabled = true;
          btnNavigationDebug.Enabled = false;
          btnNavigationTestCycle.Enabled = false;
          break;
      }
      for (int i = 0; i < listButton.Count; i++)
      {
        if (listButton[i].Enabled && listButton[i].BackColor == Color.Black)
        {
          listButton[i].BackColor = Color.White;
        }
        if (listButton[i].Enabled == false)
        {
          listButton[i].BackColor = Color.Black;
        }
      }

      if (true)
      {
        lblStatusStrip_Image1.Image = lmgList_Connection.Images[0];
        lblStatusStrip_Connection.Text = "Connected";
      }
      else
      {
        lblStatusStrip_Image1.Image = lmgList_Connection.Images[1];
        lblStatusStrip_Connection.Text = "Disconnected";
      }
      string strStripAlarm = "";
      if (CVo.listAlarmStopName.Count > 0)
      {
        strStripAlarm = CVo.arrAlarmStopName[(int)CVo.listAlarmStopName[0]];
      }
      else
      {
        strStripAlarm = "NONE";
      }
      lblStatusStrip_Alarm.Text = strStripAlarm;

      string strStripStatus = "NONE";
      Image cImg_Off = ImgList_Button.Images[0];
      Image cImg_On = ImgList_Button.Images[1];
      Color cCrOff = Color.White;
      Color cCrOn = Color.Lime;
      bool bOn = false;
      for (int i = 0; i < listButton.Count; i++)
      {
        //bOn = listButton[i].BackgroundImage == cImg_On;
        bOn = listButton[i].BackColor == cCrOn;
        if (bOn)
        {
          switch (listButton[i].Name)
          {
            case "btnNavigationAuto": strStripStatus = "Auto"; break;
            case "btnNavigationRecipe": strStripStatus = "Recipe"; break;
            case "btnNavigationDebug": strStripStatus = "Debug"; break;
            case "btnNavigationSetup": strStripStatus = "Setup"; break;
            case "btnNavigationManual": strStripStatus = "Manual"; break;
            case "btnNavigationDatalog": strStripStatus = "Data Log"; break;
            case "btnNavigationAlarm": strStripStatus = "Alarm"; break;
            case "btnNavigationTestCycle": strStripStatus = "Test"; break;
            default: break;
          }
          break;
        }
      }
      lblStatusStrip_Notice.Text = strStripStatus;

      tmr_Navigation.Enabled = true;
    }

    private void FormNavigation_Load(object sender, EventArgs e)
    {
      CForm.Display_Page(CForm.frmPageAuto);
      Change_ButtonColor(this.btnNavigationAuto);
    }

  }
}
