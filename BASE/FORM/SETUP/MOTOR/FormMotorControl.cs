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
using BASE.MODULE.MOTION;
using BASE.VO;

namespace BASE.FORM.SETUP.MOTOR
{
  public partial class FormMotorControl : Form
  {
    private bool bOption = false;
    private int iOptionCloseWidth = 470;
    //private int iOptionOpenWidth = 1280;
    private enumMotorName eCurrentAxis = (enumMotorName)0;

    public FormMotorControl()
    {
      InitializeComponent();
    }

    private void btnMtcClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void tmrMtcDisplay_Tick(object sender, EventArgs e)
    {
      tmrMtcDisplay.Enabled = false;
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      lblMtcLimitN.BackColor = sMotor.bSensorCcw ? Color.Red : Color.Maroon;
      lblMtcOrg.BackColor = sMotor.bSensorHome ? Color.Lime : Color.DarkGreen;
      lblMtcLimitP.BackColor = sMotor.bSensorCw ? Color.Red : Color.Maroon;
      lblMtcBusy.BackColor = sMotor.bBusy ? Color.Lime : Color.DarkGreen;
      lblMtcAlarm.BackColor = sMotor.bAlarm ? Color.Red : Color.Maroon;

      txtMtcEnc.Text = sMotor.dCurrentPos.ToString("0.000");

      btnMtcHome.BackColor = sMotor.bHomeComplete ? Color.Lime : Color.White;

      double dCommand = Convert.ToDouble(txtMtcCmd.Text);
      double dEncoder = Convert.ToDouble(txtMtcEnc.Text);
      txtMtcGap.Text = System.Math.Abs(dCommand - dEncoder).ToString();

      tmrMtcDisplay.Enabled = true;
    }

    public void Show_()
    {
      bOption = false;
      btnMtcOption.Text = bOption ? "◀" : "▶";
      this.Width = iOptionCloseWidth;
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Show();
    }

    private void FormMotorControl_Load(object sender, EventArgs e)
    {
      cboMtcMotorSelect.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
			{
        cboMtcMotorSelect.Items.Add(((enumMotorName)i).ToString());
			}
      cboMtcMotorSelect.SelectedIndex = 0;
      eCurrentAxis = (enumMotorName)cboMtcMotorSelect.SelectedIndex;
      cboMtcJogSpeed.SelectedIndex = 0;
      txtMtcCmd.Text = "0.000";
    }

    private void cboMtcMotorSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
      eCurrentAxis = (enumMotorName)cboMtcMotorSelect.SelectedIndex;
      txtMtcAbsolutePosition.Text = "0";
      txtMtcRelativePosition.Text = "0";
    }

    private void btnMtcHome_Click(object sender, EventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      if (sMotor.bBusy)
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          CVo.bInit_All = false;
          CVo.bInit_Loading = false;
          CVo.bInit_Stage = false;
          CVo.bInit_Unloading = false;
          CVo.bManualRun = true;
          CVo.eMachineStatus = enumMachineStatus.Cycle;
          CMaster.cMotion.cAction.Home_Select_Direct(eCurrentAxis);
          SetReadyPos(eCurrentAxis);
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void btnMtcJogCw_MouseDown(object sender, MouseEventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      if (sMotor.bBusy || sMotor.bAlarm)
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          CVo.bManualRun = true; // 상태 변경안하고 신호만 보내고 알람처리함
          Jog_Ccw(eCurrentAxis, false);
          SetJogSpd(eCurrentAxis, Convert.ToDouble(cboMtcJogSpeed.Text));
          Jog_Cw(eCurrentAxis, true);
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void btnMtcJogCw_MouseUp(object sender, MouseEventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      Jog_Ccw(eCurrentAxis, false);
      Jog_Cw(eCurrentAxis, false);
      txtMtcCmd.Text = sMotor.dCurrentPos.ToString("0.000");
    }

    private void btnMtcJogCcw_MouseDown(object sender, MouseEventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      if (sMotor.bBusy || sMotor.bAlarm)
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          CVo.bManualRun = true; // 상태 변경안하고 신호만 보내고 알람처리함
          Jog_Cw(eCurrentAxis, false);
          SetJogSpd(eCurrentAxis, Convert.ToDouble(cboMtcJogSpeed.Text));
          Jog_Ccw(eCurrentAxis, true);
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void btnMtcJogCcw_MouseUp(object sender, MouseEventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      Jog_Ccw(eCurrentAxis, false);
      Jog_Cw(eCurrentAxis, false);
      txtMtcCmd.Text = sMotor.dCurrentPos.ToString("0.000");
    }

    private void btnMtcAbsoluteMove_Click(object sender, EventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      if (sMotor.bBusy || sMotor.bAlarm)
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          CVo.bManualRun = true; // 상태 변경안하고 신호만 보내고 알람처리함
          Move_Absolute(eCurrentAxis, Convert.ToDouble(txtMtcAbsolutePosition.Text), Convert.ToDouble(cboMtcJogSpeed.Text));
          txtMtcCmd.Text = txtMtcAbsolutePosition.Text;        
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void btnMtcRelativeMove_Click(object sender, EventArgs e)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(eCurrentAxis);
      if (sMotor.bBusy || sMotor.bAlarm)
      {
        return;
      }
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          CVo.bManualRun = true;
          CVo.eMachineStatus = enumMachineStatus.Cycle;
          txtMtcCmd.Text = (CMotionVo.GetMotorStatus(eCurrentAxis).dCurrentPos + Convert.ToDouble(txtMtcRelativePosition.Text)).ToString();
          Move_Relative(eCurrentAxis, Convert.ToDouble(txtMtcRelativePosition.Text), Convert.ToDouble(cboMtcJogSpeed.Text));
          break;
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void btnMtcStop_Click(object sender, EventArgs e)
    {
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
          CIoVo.Set_WB_OutFlag(enumFlagOut.B10C0_Teaching_Cancel, true);
          CIoVo.Set_WB_OutFlag(enumFlagOut.B10C1_All_Stop, true);
          break;
        case enumMachineStatus.Initial:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Cycle:
        default:
          return;
      }
    }

    private void txt_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "X");

      if (strData.Trim().CompareTo("") == 0)
      {
        // 값없음
        return;
      }
      double dTemp;
      if (double.TryParse(strData, out dTemp) == false)
      {
        // 숫자아님
        return;
      }

      double dRELToABS = CMotionVo.GetMotorStatus(eCurrentAxis).dCurrentPos + Convert.ToDouble(strData);
      switch (ctrl.Name)
      {
        case "txtMtcAbsolutePosition": if (CVo.Allow_Limit(eCurrentAxis, Convert.ToDouble(strData)) == false) { break; } txtMtcAbsolutePosition.Text = strData; break;
        case "txtMtcRelativePosition": if (CVo.Allow_Limit(eCurrentAxis, dRELToABS) == false) { break; } txtMtcRelativePosition.Text = strData; break;
        default:
          break;
      }
    }


    #region Control Function
    private void SetJogSpd(enumMotorName name, double spd)
    {
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(name);
      switch (name)
      {
        case enumMotorName.LE: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1080_LE_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.LP: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108E_LP_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.BCX: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108A_BCX_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.BCY: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108C_BCY_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.ALX: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1098_ALX_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.ALY: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109A_ALY_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.X1: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109C_X1_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.X2: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109E_X2_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.Z1: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1094_Z1_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.Z2: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1096_Z2_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.PR1: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A0_PR1_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.PR2: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A2_PR2_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.PR3: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A4_PR3_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.PR4: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A6_PR4_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UPX: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1090_UPX_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UPY: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1092_UPY_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UE1: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1082_UE1_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UE2: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1084_UE2_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UE3: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1086_UE3_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        case enumMotorName.UE4: CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1088_UE4_Jog_Spd, (int)(spd * sMotor.dLimitScale)); break;
        default: break;
      }
    }
    private void Jog_Cw(enumMotorName name, bool on)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      if (on)
      {
        if (name == enumMotorName.X1)
        {
          if (cSys.dPR1_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
          {
            return;
          }
          if (cSys.dPR2_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.X2)
        {
          if (cSys.dPR3_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
          {
            return;
          }
          if (cSys.dPR4_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR1)
        {
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR2)
        {
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR3)
        {
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR4)
        {
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            return;
          }
        }
      }

      structMotorStatus sMotor = CMotionVo.GetMotorStatus(name);
      switch (name)
      {
        case enumMotorName.LE: CIoVo.Set_WB_OutFlag(enumFlagOut.B1060_LE_Cw_Jog_Signal, on); break;
        case enumMotorName.LP: CIoVo.Set_WB_OutFlag(enumFlagOut.B106E_LP_Cw_Jog_Signal, on); break;
        case enumMotorName.BCX: CIoVo.Set_WB_OutFlag(enumFlagOut.B106A_BCX_Cw_Jog_Signal, on); break;
        case enumMotorName.BCY: CIoVo.Set_WB_OutFlag(enumFlagOut.B106C_BCY_Cw_Jog_Signal, on); break;
        case enumMotorName.ALX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1078_ALX_Cw_Jog_Signal, on); break;
        case enumMotorName.ALY: CIoVo.Set_WB_OutFlag(enumFlagOut.B107A_ALY_Cw_Jog_Signal, on); break;
        case enumMotorName.X1: CIoVo.Set_WB_OutFlag(enumFlagOut.B107C_X1_Cw_Jog_Signal, on); break;
        case enumMotorName.X2: CIoVo.Set_WB_OutFlag(enumFlagOut.B107E_X2_Cw_Jog_Signal, on); break;
        case enumMotorName.Z1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1074_Z1_Cw_Jog_Signal, on); break;
        case enumMotorName.Z2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1076_Z2_Cw_Jog_Signal, on); break;
        case enumMotorName.PR1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1080_PR1_Cw_Jog_Signal, on); break;
        case enumMotorName.PR2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1082_PR2_Cw_Jog_Signal, on); break;
        case enumMotorName.PR3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1084_PR3_Cw_Jog_Signal, on); break;
        case enumMotorName.PR4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1086_PR4_Cw_Jog_Signal, on); break;
        case enumMotorName.UPX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1070_UPX_Cw_Jog_Signal, on); break;
        case enumMotorName.UPY: CIoVo.Set_WB_OutFlag(enumFlagOut.B1072_UPY_Cw_Jog_Signal, on); break;
        case enumMotorName.UE1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1062_UE1_Cw_Jog_Signal, on); break;
        case enumMotorName.UE2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1064_UE2_Cw_Jog_Signal, on); break;
        case enumMotorName.UE3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1066_UE3_Cw_Jog_Signal, on); break;
        case enumMotorName.UE4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1068_UE4_Cw_Jog_Signal, on); break;
        default: break;
      }
    }
    private void Jog_Ccw(enumMotorName name, bool on)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      if (on)
      {
        if (name == enumMotorName.X1)
        {
          if (cSys.dPR1_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
          {
            return;
          }
          if (cSys.dPR2_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.X2)
        {
          if (cSys.dPR3_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
          {
            return;
          }
          if (cSys.dPR4_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR1)
        {
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR2)
        {
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR3)
        {
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            return;
          }
        }
        if (name == enumMotorName.PR4)
        {
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            return;
          }
        }
      }
 



      structMotorStatus sMotor = CMotionVo.GetMotorStatus(name);
      switch (name)
      {
        case enumMotorName.LE: CIoVo.Set_WB_OutFlag(enumFlagOut.B1061_LE_Ccw_Jog_Signal, on); break;
        case enumMotorName.LP: CIoVo.Set_WB_OutFlag(enumFlagOut.B106F_LP_Ccw_Jog_Signal, on); break;
        case enumMotorName.BCX: CIoVo.Set_WB_OutFlag(enumFlagOut.B106B_BCX_Ccw_Jog_Signal, on); break;
        case enumMotorName.BCY: CIoVo.Set_WB_OutFlag(enumFlagOut.B106D_BCY_Ccw_Jog_Signal, on); break;
        case enumMotorName.ALX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1079_ALX_Ccw_Jog_Signal, on); break;
        case enumMotorName.ALY: CIoVo.Set_WB_OutFlag(enumFlagOut.B107B_ALY_Ccw_Jog_Signal, on); break;
        case enumMotorName.X1: CIoVo.Set_WB_OutFlag(enumFlagOut.B107D_X1_Ccw_Jog_Signal, on); break;
        case enumMotorName.X2: CIoVo.Set_WB_OutFlag(enumFlagOut.B107F_X2_Ccw_Jog_Signal, on); break;
        case enumMotorName.Z1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1075_Z1_Ccw_Jog_Signal, on); break;
        case enumMotorName.Z2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1077_Z2_Ccw_Jog_Signal, on); break;
        case enumMotorName.PR1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1081_PR1_Ccw_Jog_Signal, on); break;
        case enumMotorName.PR2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1083_PR2_Ccw_Jog_Signal, on); break;
        case enumMotorName.PR3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1085_PR3_Ccw_Jog_Signal, on); break;
        case enumMotorName.PR4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1087_PR4_Ccw_Jog_Signal, on); break;
        case enumMotorName.UPX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1071_UPX_Ccw_Jog_Signal, on); break;
        case enumMotorName.UPY: CIoVo.Set_WB_OutFlag(enumFlagOut.B1073_UPY_Ccw_Jog_Signal, on); break;
        case enumMotorName.UE1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1063_UE1_Ccw_Jog_Signal, on); break;
        case enumMotorName.UE2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1065_UE2_Ccw_Jog_Signal, on); break;
        case enumMotorName.UE3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1067_UE3_Ccw_Jog_Signal, on); break;
        case enumMotorName.UE4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1069_UE4_Ccw_Jog_Signal, on); break;
        default: break;
      }
    }
    private void Move_Absolute(enumMotorName name, double pos, double spd)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(name);
      switch (name)
      {
        case enumMotorName.LE:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case enumMotorName.LP:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case enumMotorName.BCX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1016_BCX_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1014_BCX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1025_BCX_Teaching_Start, true);
          break;
        case enumMotorName.BCY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101A_BCY_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1018_BCY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1026_BCY_Teaching_Start, true);
          break;
        case enumMotorName.ALX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case enumMotorName.ALY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case enumMotorName.X1:
          if (cSys.dPR1_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
          {
            break;
          }
          if (cSys.dPR2_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
          {
            break;
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case enumMotorName.X2:
          if (cSys.dPR3_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
          {
            break;
          }
          if (cSys.dPR4_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
          {
            break;
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case enumMotorName.Z1:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case enumMotorName.Z2:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case enumMotorName.PR1:
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            if (pos < CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
            {
              if (pos < cSys.dPR1_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1042_PR1_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1040_PR1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1030_PR1_Teaching_Start, true);
          break;
        case enumMotorName.PR2:
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            if (pos < CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
            {
              if (pos < cSys.dPR2_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1046_PR2_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1044_PR2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1031_PR2_Teaching_Start, true);
          break;
        case enumMotorName.PR3:
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            if (pos < CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
            {
              if (pos < cSys.dPR3_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104A_PR3_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1048_PR3_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1032_PR3_Teaching_Start, true);
          break;
        case enumMotorName.PR4:
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            if (pos < CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
            {
              if (pos < cSys.dPR4_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104E_PR4_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104C_PR4_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1033_PR4_Teaching_Start, true);
          break;
        case enumMotorName.UPX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case enumMotorName.UPY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case enumMotorName.UE1:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1021_UE1_Teaching_Start, true);
          break;
        case enumMotorName.UE2:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1022_UE2_Teaching_Start, true);
          break;
        case enumMotorName.UE3:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1023_UE3_Teaching_Start, true);
          break;
        case enumMotorName.UE4:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(pos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1024_UE4_Teaching_Start, true);
          break;
        default: break;
      }
    }
    private void Move_Relative(enumMotorName name, double pos, double spd)
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      structMotorStatus sMotor = CMotionVo.GetMotorStatus(name);
      double dRelPos = sMotor.dCurrentPos + pos;

      switch (name)
      {
        case enumMotorName.LE:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case enumMotorName.LP:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case enumMotorName.BCX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1016_BCX_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1014_BCX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1025_BCX_Teaching_Start, true);
          break;
        case enumMotorName.BCY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101A_BCY_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1018_BCY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1026_BCY_Teaching_Start, true);
          break;
        case enumMotorName.ALX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case enumMotorName.ALY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case enumMotorName.X1:
          if (cSys.dPR1_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
          {
            break;
          }
          if (cSys.dPR2_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
          {
            break;
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case enumMotorName.X2:
          if (cSys.dPR3_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
          {
            break;
          }
          if (cSys.dPR4_Change_Pos > CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
          {
            break;
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case enumMotorName.Z1:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case enumMotorName.Z2:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case enumMotorName.PR1:
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            if (dRelPos < CMotionVo.GetMotorStatus(enumMotorName.PR1).dCurrentPos)
            {
              if (dRelPos < cSys.dPR1_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1042_PR1_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1040_PR1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1030_PR1_Teaching_Start, true);
          break;
        case enumMotorName.PR2:
          if (cSys.dX1_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos
           || cSys.dX1_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X1).dCurrentPos)
          {
            if (dRelPos < CMotionVo.GetMotorStatus(enumMotorName.PR2).dCurrentPos)
            {
              if (dRelPos < cSys.dPR2_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1046_PR2_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1044_PR2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1031_PR2_Teaching_Start, true);
          break;
        case enumMotorName.PR3:
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            if (dRelPos < CMotionVo.GetMotorStatus(enumMotorName.PR3).dCurrentPos)
            {
              if (dRelPos < cSys.dPR3_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104A_PR3_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1048_PR3_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1032_PR3_Teaching_Start, true);
          break;
        case enumMotorName.PR4:
          if (cSys.dX2_Interlock_Plus < CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos
           || cSys.dX2_Interlock_Minus > CMotionVo.GetMotorStatus(enumMotorName.X2).dCurrentPos)
          {
            if (dRelPos < CMotionVo.GetMotorStatus(enumMotorName.PR4).dCurrentPos)
            {
              if (dRelPos < cSys.dPR4_Change_Pos)
              {
                break;
              }
            }
          }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104E_PR4_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104C_PR4_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1033_PR4_Teaching_Start, true);
          break;
        case enumMotorName.UPX:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case enumMotorName.UPY:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case enumMotorName.UE1:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1021_UE1_Teaching_Start, true);
          break;
        case enumMotorName.UE2:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1022_UE2_Teaching_Start, true);
          break;
        case enumMotorName.UE3:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1023_UE3_Teaching_Start, true);
          break;
        case enumMotorName.UE4:
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(dRelPos * sMotor.dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(spd * sMotor.dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1024_UE4_Teaching_Start, true);
          break;
        default: break;
      }
    }


    private void SetReadyPos(enumMotorName name) // 2017.05.21. 김태중대리 요청에 의해 개별 홈 잡을때 Ready Pos 넣어줌
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      switch (name)
      {
        case enumMotorName.LE:
          break;
        case enumMotorName.LP:
          CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
          break;
        case enumMotorName.BCX:
          CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1164_BCX_Ready_Pos, (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
          CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C6_BCX_Ready_Pos, (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
          break;
        case enumMotorName.BCY:
          CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1166_BCY_Ready_Pos, (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
          CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C8_BCY_Ready_Pos, (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
          break;
        case enumMotorName.ALX:
          CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1182_ALX_Ready_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
          CIoVo.Set_WW_Align(enumWW_Align.W11A0_ALX_Befor_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
          CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C2_ALX_Ready_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
          break;
        case enumMotorName.ALY:
          CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1184_ALY_Ready_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
          CIoVo.Set_WW_Align(enumWW_Align.W11A2_ALY_Befor_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
          CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C4_ALY_Ready_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
          break;
        case enumMotorName.X1:
          break;
        case enumMotorName.X2:
          break;
        case enumMotorName.Z1:
          CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11E2_Z1_Ready_Pos, (int)(cSys.dZ1_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
          break;
        case enumMotorName.Z2:
          CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1202_Z2_Ready_Pos, (int)(cSys.dZ2_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
          break;
        case enumMotorName.PR1:
          break;
        case enumMotorName.PR2:
          break;
        case enumMotorName.PR3:
          break;
        case enumMotorName.PR4:
          break;
        case enumMotorName.UPX:
          CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F0_UPX_Ready_Pos, (int)(cSys.dUPX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
          break;
        case enumMotorName.UPY:
          CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F2_UPY_Ready_Pos, (int)(cSys.dUPY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
          break;
        case enumMotorName.UE1:
          break;
        case enumMotorName.UE2:
          break;
        case enumMotorName.UE3:
          break;
        case enumMotorName.UE4:
          break;
        default:
          break;
      }
    }
    #endregion





 }
}
