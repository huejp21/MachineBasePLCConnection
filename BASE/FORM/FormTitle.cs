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

namespace BASE.FORM
{
  public partial class FormTitle : Form
  {
    private double dLampTimer = 0;
    private double dBuzzTimer = 0;
    private enumMachineStatus eBuzzStatus = enumMachineStatus.None;

    public FormTitle()
    {
      InitializeComponent();
    }

    private void btnTitleLogin_Click(object sender, EventArgs e)
    {
      if (CVo.TestRunning())
      {
        return;
      }
      CForm.Display_Page(CForm.frmPageLogin);
    }

    private void tmrDisplay_Tick(object sender, EventArgs e)
    {
      lblTitleVersion.Text = CVo.strVersion;
      lblTitle_Connect_BCR.BackColor = CMaster.cBCR.Check_Open() ? Color.Lime : Color.Red;
      lblTitle_Connect_PLC.BackColor = CMaster.cPlc.IsOpen() ? Color.Lime : Color.Red;
      lblTitle_Connect_Probe1.BackColor = CMaster.cProbe1.Check_Open() ? Color.Lime : Color.Red;
      lblTitle_Connect_Probe2.BackColor = CMaster.cProbe2.Check_Open() ? Color.Lime : Color.Red;
      //lblTitle_Connect_GEM.BackColor = CMaster.cBCR.Check_Open() ? Color.Lime : Color.Red;

      string strData = "";

      if (CVo.strCurrentUser.CompareTo("NONE") == 0
        && CVo.eCurrentUserLevel == enumUserLevel.Operator)
      {
        switch (CVo.eCurrentLanguage)
        {
          case enumLanguageType.Default_Caption:
          case enumLanguageType.English:
            strData = "Login\r\nHere";
            break;
          case enumLanguageType.Korean:
            strData = "로그인";
            break;
          case enumLanguageType.Chinese:
            strData = "Login\r\nHere";
            break;
          case enumLanguageType.Japanese:
            strData = "Login\r\nHere";
            break;
          default:
            break;
        }
        
        btnTitleLogin.ImageIndex = 2;
      }
      else
      {
        strData = string.Format("{0}\n\r{1}", CVo.strCurrentUser, CVo.eCurrentUserLevel.ToString());
        btnTitleLogin.ImageIndex = 1;
      }
      btnTitleLogin.Text = strData;
      lblTitleRecipe.Text = CVo.RECIPE_CURRENT.Replace("\\", "");
      lblTitleTime.Text = System.DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]");

      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.Initial:
          lblTitleMachineStatus.BackColor = Color.Yellow;
          break;
        case enumMachineStatus.Idle:
          lblTitleMachineStatus.BackColor = Color.Blue;
          break;
        case enumMachineStatus.Auto:
          lblTitleMachineStatus.BackColor = Color.Lime;
          break;
        case enumMachineStatus.Stop:
          lblTitleMachineStatus.BackColor = Color.Red;
          break;
        case enumMachineStatus.ErrorAuto:
          lblTitleMachineStatus.BackColor = Color.Pink;
          break;
        case enumMachineStatus.Error:
          lblTitleMachineStatus.BackColor = Color.Plum;
          break;
        case enumMachineStatus.Cycle:
          lblTitleMachineStatus.BackColor = Color.Purple;
          break;
        case enumMachineStatus.None:
        default:
          lblTitleMachineStatus.BackColor = Color.Gray;
          break;
      }
      lblTitleMachineStatus.Text = CVo.eMachineStatus.ToString();
      Control_Lamp();
    }

    private void Control_Lamp()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      enumBuzzer eBuzz = enumBuzzer.Off;
      int iBuzzTime = 0;

      enumTowerLamp eR = enumTowerLamp.Off;
      enumTowerLamp eY = enumTowerLamp.Off;
      enumTowerLamp eG = enumTowerLamp.Off;
      int iBlankTime = 0;
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
          eR = (enumTowerLamp)cSys.iLampNone_R;
          eY = (enumTowerLamp)cSys.iLampNone_Y;
          eG = (enumTowerLamp)cSys.iLampNone_G;
          iBlankTime = cSys.iLampNone_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzNone_Mode;
          iBuzzTime = cSys.iBuzzNone_Time;
          break;
        case enumMachineStatus.Initial:
          eR = (enumTowerLamp)cSys.iLampInitail_R;
          eY = (enumTowerLamp)cSys.iLampInitail_Y;
          eG = (enumTowerLamp)cSys.iLampInitail_G;
          iBlankTime = cSys.iLampInitail_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzInitail_Mode;
          iBuzzTime = cSys.iBuzzInitail_Time;
          break;
        case enumMachineStatus.Idle:
          eR = (enumTowerLamp)cSys.iLampIdle_R;
          eY = (enumTowerLamp)cSys.iLampIdle_Y;
          eG = (enumTowerLamp)cSys.iLampIdle_G;
          iBlankTime = cSys.iLampIdle_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzIdle_Mode;
          iBuzzTime = cSys.iBuzzIdle_Time;
          break;
        case enumMachineStatus.Auto:
          eR = (enumTowerLamp)cSys.iLampAuto_R;
          eY = (enumTowerLamp)cSys.iLampAuto_Y;
          eG = (enumTowerLamp)cSys.iLampAuto_G;
          iBlankTime = cSys.iLampAuto_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzAuto_Mode;
          iBuzzTime = cSys.iBuzzAuto_Time;
          break;
        case enumMachineStatus.Stop:
          eR = (enumTowerLamp)cSys.iLampStop_R;
          eY = (enumTowerLamp)cSys.iLampStop_Y;
          eG = (enumTowerLamp)cSys.iLampStop_G;
          iBlankTime = cSys.iLampStop_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzStop_Mode;
          iBuzzTime = cSys.iBuzzStop_Time;
          break;
        case enumMachineStatus.ErrorAuto:
          eR = (enumTowerLamp)cSys.iLampErrorAuto_R;
          eY = (enumTowerLamp)cSys.iLampErrorAuto_Y;
          eG = (enumTowerLamp)cSys.iLampErrorAuto_G;
          iBlankTime = cSys.iLampErrorAuto_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzErrorAuto_Mode;
          iBuzzTime = cSys.iBuzzErrorAuto_Time;
          break;
        case enumMachineStatus.Error:
          eR = (enumTowerLamp)cSys.iLampErrorCycle_R;
          eY = (enumTowerLamp)cSys.iLampErrorCycle_Y;
          eG = (enumTowerLamp)cSys.iLampErrorCycle_G;
          iBlankTime = cSys.iLampErrorCycle_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzErrorCycle_Mode;
          iBuzzTime = cSys.iBuzzErrorCycle_Time;
          break;
        case enumMachineStatus.Cycle:
          eR = (enumTowerLamp)cSys.iLampCycle_R;
          eY = (enumTowerLamp)cSys.iLampCycle_Y;
          eG = (enumTowerLamp)cSys.iLampCycle_G;
          iBlankTime = cSys.iLampCycle_BlinkTime;
          eBuzz = (enumBuzzer)cSys.iBuzzCycle_Mode;
          iBuzzTime = cSys.iBuzzCycle_Time;
          break;
        default:
          break;
      }
      if (eR == enumTowerLamp.On) { pnlTitleTowerR.BackColor = Color.Red; CIoVo.Set_WB_Output(enumBitOutput.B1102_TowerLampLED_Red, true); }
      else if (eR == enumTowerLamp.Off) { pnlTitleTowerR.BackColor = Color.Maroon; CIoVo.Set_WB_Output(enumBitOutput.B1102_TowerLampLED_Red, false); }
      if (eY == enumTowerLamp.On) { pnlTitleTowerY.BackColor = Color.Yellow; CIoVo.Set_WB_Output(enumBitOutput.B1103_TowerLampLED_Yellow, true); }
      else if (eY == enumTowerLamp.Off) { pnlTitleTowerY.BackColor = Color.DarkGoldenrod; CIoVo.Set_WB_Output(enumBitOutput.B1103_TowerLampLED_Yellow, false); }
      if (eG == enumTowerLamp.On) { pnlTitleTowerG.BackColor = Color.Lime; CIoVo.Set_WB_Output(enumBitOutput.B1104_TowerLampLED_Green, true); }
      else if (eG == enumTowerLamp.Off) { pnlTitleTowerG.BackColor = Color.DarkGreen; CIoVo.Set_WB_Output(enumBitOutput.B1104_TowerLampLED_Green, false); }

      dLampTimer += 100;
      if (dLampTimer < iBlankTime / 2)
      {
        if (eR == enumTowerLamp.Blink) { pnlTitleTowerR.BackColor = Color.Red; CIoVo.Set_WB_Output(enumBitOutput.B1102_TowerLampLED_Red, true); }
        if (eY == enumTowerLamp.Blink) { pnlTitleTowerY.BackColor = Color.Yellow; CIoVo.Set_WB_Output(enumBitOutput.B1103_TowerLampLED_Yellow, true); }
        if (eG == enumTowerLamp.Blink) { pnlTitleTowerG.BackColor = Color.Lime; CIoVo.Set_WB_Output(enumBitOutput.B1104_TowerLampLED_Green, true); }
      }
      if (dLampTimer > iBlankTime / 2)
      {
        if (eR == enumTowerLamp.Blink) { pnlTitleTowerR.BackColor = Color.Maroon; CIoVo.Set_WB_Output(enumBitOutput.B1102_TowerLampLED_Red, false); }
        if (eY == enumTowerLamp.Blink) { pnlTitleTowerY.BackColor = Color.DarkGoldenrod; CIoVo.Set_WB_Output(enumBitOutput.B1103_TowerLampLED_Yellow, false); }
        if (eG == enumTowerLamp.Blink) { pnlTitleTowerG.BackColor = Color.DarkGreen; CIoVo.Set_WB_Output(enumBitOutput.B1104_TowerLampLED_Green, false); }
      }

      if (dLampTimer >= iBlankTime)
      {
        dLampTimer = 0;
      }

      if (CVo.bLotUserConfirmWait == false)
      {
        // LOT End 때는 확인 팝업에서 완료 버저를 울려주므로 타이머쪽은 작업 하지 말것
        if (CVo.eMachineStatus != eBuzzStatus)
        {
          // 장비 상태가 바뀌면 버저 타이머 초기화
          dBuzzTimer = 0;
          CVo.bBuzzOff = false;
          eBuzzStatus = CVo.eMachineStatus;
        }
        if (CVo.bBuzzOff)
        {
          // OFF 눌리면 끔
          CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
          CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
        }
        else
        {
          if (iBuzzTime == 0)
          {
            // 설정이 0 이면 켬
            dBuzzTimer = 0;
            if (eBuzz == enumBuzzer.End)
            {
              CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, true);
              CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
            }
            else if (eBuzz == enumBuzzer.Error)
            {
              CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
              CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, true);
            }
            else
            {
              CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
              CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
            }
          }
          else
          {
            // 타이머 설정 값이 있으면 해당 타이머 만큼 켬
            if (dBuzzTimer >= iBuzzTime)
            {
              CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
              CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
            }
            else
            {
              dBuzzTimer += 10;
              if (eBuzz == enumBuzzer.End)
              {
                CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, true);
                CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
              }
              else if (eBuzz == enumBuzzer.Error)
              {
                CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
                CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, true);
              }
              else
              {
                CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
                CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
              }
            }
          }
        }

      }
    }

    private void btnTitleBuzzStop_Click(object sender, EventArgs e)
    {
      CVo.bBuzzOff = true;
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A7_PC_Buzz_Stop_Signal, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
      CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
    }

    private void btnTitleMotor_Click(object sender, EventArgs e)
    {
      CForm.frmMotorControl.Show_();
    }

    private void btnTitleIO_Click(object sender, EventArgs e)
    {
      CForm.frmIoControl.Show_();
    }

    private void pic_Title_MachineName_DoubleClick(object sender, EventArgs e)
    {
      switch (CVo.eCurrentUserLevel)
      {
        case enumUserLevel.Developer:
          CForm.frmPLCView.Show_();
          CForm.frmThView.Show();
          break;
        case enumUserLevel.Administator:
        case enumUserLevel.Operator:
        case enumUserLevel.Maintenance:
        default:
          break;
      }
    }

    private void lblMachineName_DoubleClick(object sender, EventArgs e)
    {
        switch (CVo.eCurrentUserLevel)
        {
            case enumUserLevel.Developer:
                CForm.frmPLCView.Show_();
                CForm.frmThView.Show();
                break;
            case enumUserLevel.Administator:
            case enumUserLevel.Operator:
            case enumUserLevel.Maintenance:
            default:
                break;
        }
    }
  }
}
