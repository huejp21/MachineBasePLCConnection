using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BASE.MASTER;

using BASE.VO;
using BASE.MODULE.MOTION;

namespace BASE.FORM
{
  // size: 200, 814
  public enum enumControlLocationType
  {
    Right = 0,
    Left
  };

  public partial class FormControl : Form
  {
    public int iInitialCount = 0;
    public bool bInitialButtonDown = false;

    public enumControlLocationType m_eLocation = enumControlLocationType.Right;
    public FormControl()
    {
      InitializeComponent();
    }

    private void btn_control_location_Click(object sender, EventArgs e)
    {
      m_eLocation = m_eLocation == enumControlLocationType.Right ? enumControlLocationType.Left : enumControlLocationType.Right;
    }

    private void timer_control_Tick(object sender, EventArgs e)
    {
      tmrControl.Enabled = false;
      if (bInitialButtonDown)
      {
        iInitialCount++;
      }
      try
      {
        switch (m_eLocation)
        {
          case enumControlLocationType.Right:
            CForm.frmMother.pnlMotherControl.Dock = DockStyle.Right;
            btn_control_location.Text = "Left";
            btn_control_location.ImageIndex = 4;
            break;
          case enumControlLocationType.Left:
            CForm.frmMother.pnlMotherControl.Dock = DockStyle.Left;
            btn_control_location.Text = "Right";
            btn_control_location.ImageIndex = 5;
            break;
          default:
            CForm.frmMother.pnlMotherControl.Dock = DockStyle.Right;
            btn_control_location.Text = "Left";
            btn_control_location.ImageIndex = 4;
            break;
        }
        Refresh_Mode();
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }
      tmrControl.Enabled = true;
    }

    private void btn_control_start_Click(object sender, EventArgs e)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      if (CVo.TestRunning())
      {
        return;
      }
      if (CVo.bRunning_All)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.MovingNotComplete);
        return;
      }
      if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.InitNotComplete);
        return;
      }

      if (CVo.Check_PointTypeSelected(CVo.cParaRcp) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeMeasurePointTypeNotSelected);
        return;
      }

      if (CVo.bLotRunning == false)
      {
        if (CIoVo.Get_RB_Input(enumBitInput.B2046_Align_Material_Check_Sensor))
        {
          // 얼라인에 제품있으면 알람
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.ExistInBCB);
          return;
        }
        if (CIoVo.Get_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol))
        {
          // 로더 솔 켜져있음
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.ExistInBCB);
          return;
        }
        if (CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol))
        {
           // 언로더 솔 켜져있음
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.ExistInBCB);
          return;
        }
        if (CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear))
        {
          // Stage1 솔 켜져있음
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.ExistInBCB);
          return;
        }
        if (CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front))
        {
          // Stage2 솔 켜져있음
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.ExistInBCB);
          return;
        }
      }

      if (cSys.bUseBarcode_1D)
      {
        if (CVo.bLotRunning == false
         /*&& CVo.strLotBCR.CompareTo("") == 0*/)
        {
          CVo.strLotBCR = "";
          string strLotBCR_Data = CForm.frmBCR_Lot.Show_();
          if (strLotBCR_Data.CompareTo("Cancel") != 0)
          {
            CVo.strLotBCR = strLotBCR_Data;
          }
        }

        if (CVo.strLotBCR.Length != 9)
        {
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.BCRLotDataWrong);
          return;
        }
      }


      CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.StartButton);
      CVo.eVirtualBit = enumVirtualBit.Start;
    }

    private void btnControlStop_Click(object sender, EventArgs e)
    {
      if (CVo.TestRunning())
      {
        return;
      }
      CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.StopButton);
      CVo.eVirtualBit = enumVirtualBit.Stop;
    }

    private void btnControlReset_MouseDown(object sender, MouseEventArgs e)
    {
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A2_PC_Error_Reset_Signal, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1101_ResetSwitchLED_Blue, true);
      CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.ResetButton);
      CVo.eVirtualBit = enumVirtualBit.Reset;
    }

    private void btnControlReset_MouseUp(object sender, MouseEventArgs e)
    {
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A2_PC_Error_Reset_Signal, false);
      CIoVo.Set_WB_Output(enumBitOutput.B1101_ResetSwitchLED_Blue, false);
    }

    private void btn_control_Mode_Click(object sender, EventArgs e)
    {
      CVo.bSetupMode = !CVo.bSetupMode;
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1420_Setup_Mode, CVo.bSetupMode ? 1 : 0);
    }

    private void Refresh_Mode()
    {
      if (CVo.eCurrentUserLevel > enumUserLevel.Maintenance)
      {
        btn_control_Mode.Visible = true;
      }
      else
      {
        btn_control_Mode.Visible = false;
        CVo.bSetupMode = false;
        CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1420_Setup_Mode, CVo.bSetupMode ? 1 : 0);
      }
      if (CVo.bSetupMode)
      {
        switch (CVo.eCurrentLanguage)
        {
          case enumLanguageType.Korean:
            btn_control_Mode.Text = "셋업모드";
            break;
          case enumLanguageType.Chinese:
            btn_control_Mode.Text = "Setup Mode";
            break;
          case enumLanguageType.Japanese:
            btn_control_Mode.Text = "Setup Mode";
            break;
          case enumLanguageType.Default_Caption:
          case enumLanguageType.English:
          default:
            btn_control_Mode.Text = "Setup Mode";
            break;
        }
        btn_control_Mode.ImageIndex = 7;
      }
      else
      {
        switch (CVo.eCurrentLanguage)
        {
          case enumLanguageType.Korean:
            btn_control_Mode.Text = "안전모드";
            break;
          case enumLanguageType.Chinese:
            btn_control_Mode.Text = "Safety Mode";
            break;
          case enumLanguageType.Japanese:
            btn_control_Mode.Text = "Safety Mode";
            break;
          case enumLanguageType.Default_Caption:
          case enumLanguageType.English:
          default:
            btn_control_Mode.Text = "Safety Mode";
            break;
        }
        btn_control_Mode.ImageIndex = 6;
      }
    }

    private void btnControlInitialize_MouseDown(object sender, MouseEventArgs e)
    {
      if (CVo.TestRunning())
      {
        return;
      }
      bInitialButtonDown = true;

    }

    private void btnControlInitialize_MouseUp(object sender, MouseEventArgs e)
    {
      bInitialButtonDown = false;
      if (2 < iInitialCount)
      {
        switch (CVo.eMachineStatus)
        {
          case enumMachineStatus.Idle:
          case enumMachineStatus.Stop:
          case enumMachineStatus.None:
            if (CForm.frmMessageMsg.Show_(enumMsg.InitialCheck_C) == System.Windows.Forms.DialogResult.OK)
            {
              // 버튼 누를때 확인하고 띄워준다.
              CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.InitialButton);
              CVo.eVirtualBit = enumVirtualBit.Init;
            }
            break;
          case enumMachineStatus.ErrorAuto:
          case enumMachineStatus.Error:
          case enumMachineStatus.Initial:
          case enumMachineStatus.Cycle:
          case enumMachineStatus.Auto:
          default: break;
        }
      }
      iInitialCount = 0;
    }

    private void btnControlLotCancel_MouseDown(object sender, MouseEventArgs e)
    {
      if (CVo.TestRunning())
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
          if (CForm.frmMessageMsg.Show_(enumMsg.LotClearCheck_C) == System.Windows.Forms.DialogResult.OK)
          {
            if (CVo.bLotRunning)
            {
              CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.LotEnd);
              CVo.bLotEndWait = false;
              CVo.bLotRunning = false;
              CVo.bLELastOut = false;
              CVo.bUE1LastOut = false;
              CVo.bUE2LastOut = false;
              CVo.bUE3LastOut = false;
              CVo.bUE4LastOut = false;
              if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
              {
                CVo.eMachineStatus = enumMachineStatus.Idle;
              }
              else
              {
                CVo.eMachineStatus = enumMachineStatus.Stop;
              }
              CVo.sTactTime_LotEnd = System.DateTime.Now;

              CVo.Save_Lot_Log();
              CVo.eAlarmWarn = enumAlarmWarn.LotEnd;
              CVo.bOnAlarmWarn = true;
            }
            CMaster.cLogMgr.Add_MachineEvent(enumMachineEvent.LotClearButton);
            CVo.Reset_LotData();
          }
          break;
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        case enumMachineStatus.Initial:
        default:
          break;
      }
    }
  }
}
