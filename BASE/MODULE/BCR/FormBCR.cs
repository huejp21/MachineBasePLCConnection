using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BASE.FORM;
using BASE.MASTER;
using BASE.VO;

namespace BASE.MODULE.BCR
{
  public partial class FormBCR : Form
  {
    private Rectangle sCurrentROI = new Rectangle(); //사용자 ROI 임시 변수 저장시 이곳의 좌표를 바코드로 보냄
    private bool bROIMousePushed = false;
    private Control cCurrentROIButton = null;

    public FormBCR()
    {
      InitializeComponent();
    }

    private void FormBCR_Load(object sender, EventArgs e)
    {
      CMaster.cBCR.SetPictureBox(picBCR);

      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      sCurrentROI = new Rectangle(cRcp.iBCR_SX, cRcp.iBCR_SY, cRcp.iBCR_EX - cRcp.iBCR_SX, cRcp.iBCR_EY - cRcp.iBCR_SY);

      if (CMaster.cBCR.Check_Open())
      {
        CMaster.cBCR.SetROI(sCurrentROI);
      }
    }

    private void FormBCR_Shown(object sender, EventArgs e)
    {
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      sCurrentROI = new Rectangle(cRcp.iBCR_SX, cRcp.iBCR_SY, cRcp.iBCR_EX - cRcp.iBCR_SX, cRcp.iBCR_EY - cRcp.iBCR_SY);


      if (CMaster.cBCR.Check_Open())
      {
        CMaster.cBCR.SetROI(sCurrentROI);
      }
    }

    private void FormBCR_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
        sCurrentROI = new Rectangle(cRcp.iBCR_SX, cRcp.iBCR_SY, cRcp.iBCR_EX - cRcp.iBCR_SX, cRcp.iBCR_EY - cRcp.iBCR_SY);


        if (CMaster.cBCR.Check_Open())
        {
          CMaster.cBCR.SetROI(sCurrentROI);
        }
      }
    }

    public void Show_()
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Show();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      CMaster.cBCR.Live(false);
      this.Hide();
    }

    private void tmr_BCR_Tick(object sender, EventArgs e)
    {
      tmr_BCR.Enabled = false;
      btnConnect.Enabled = CMaster.cBCR.Check_Open() == false;
      btnDisconnect.Enabled = CMaster.cBCR.Check_Open();
      btnLiveOn.Enabled = CMaster.cBCR.Check_Open() && CMaster.cBCR.Check_Live() == false;
      btnLiveOff.Enabled = CMaster.cBCR.Check_Open() && CMaster.cBCR.Check_Live();
      btnRead.Enabled = CMaster.cBCR.Check_Open();
      btnSaveROI.Enabled = CMaster.cBCR.Check_Open();

      if (CMaster.cBCR.Check_Open())
      {
        CMaster.cBCR.SetLiveROI(sCurrentROI);
      }

      if (bROIMousePushed)
      {
        if (cCurrentROIButton != null)
        {
          switch (cCurrentROIButton.Name)
          {
            case "btnROI_VSmall":
              if (sCurrentROI.Height > 64)
              {
                sCurrentROI.Height -= 8;
              }
              break;
            case "btnROI_VBig":
              if (sCurrentROI.Height < 1280)
              {
                sCurrentROI.Height += 8;
              }
              break;
            case "btnROI_HSmall":
              if (sCurrentROI.Width > 64)
              {
                sCurrentROI.Width -= 8;
              }
              break;
            case "btnROI_HBig":
              if (sCurrentROI.Width < 960)
              {
                sCurrentROI.Width += 8;
              }
              break;
            case "btnROI_MUp":
              if (sCurrentROI.Y > 0)
              {
                sCurrentROI.Y -= 8;
              }
              break;
            case "btnROI_MDown":
              if (sCurrentROI.Y + sCurrentROI.Height < 960)
              {
                sCurrentROI.Y += 8;
              }
              break;
            case "btnROI_MLeft":
              if (sCurrentROI.X > 0)
              {
                sCurrentROI.X -= 8;
              }
              break;
            case "btnROI_MRight":
              if (sCurrentROI.X + sCurrentROI.Width > 0)
              {
                sCurrentROI.X += 8;
              }
              break;
            default:
              break;
          }
        }
      }
      tmr_BCR.Enabled = true;
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      if (CMaster.cBCR.Open_Port())
      {
        sCurrentROI = CMaster.cBCR.GetROI_Live();
      }
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
      CMaster.cBCR.Close_Port();
    }

    private void btnLiveOn_Click(object sender, EventArgs e)
    {
      CMaster.cBCR.Live(true);
    }

    private void btnLiveOff_Click(object sender, EventArgs e)
    {
      CMaster.cBCR.Live(false);
    }

    private void btnRead_Click(object sender, EventArgs e)
    {
      int iStartTime = System.Environment.TickCount;
      txtResult.Text = CMaster.cBCR.Read();
      int iEndTime = System.Environment.TickCount;
      int iCycleTime = iEndTime - iStartTime;
      lblReadingTime.Text = iCycleTime.ToString() + " m/s";
    }


    private void btnROI_MouseDown(object sender, MouseEventArgs e)
    {
      bROIMousePushed = true;
      cCurrentROIButton = (Control)sender;
    }

    private void btnROI_MouseUp(object sender, MouseEventArgs e)
    {
      bROIMousePushed = false;
    }

    private void btnROI_Reset_Click(object sender, EventArgs e)
    {
      if (CMaster.cBCR.Check_Open())
      {
        sCurrentROI = CMaster.cBCR.GetROI();
      }
    }

    private void btnSaveROI_Click(object sender, EventArgs e)
    {
      if (CMaster.cBCR.Check_Open())
      {
        ClassRecipePara cOld = CVo.cParaRcp.GetValues();
        ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

        cReplace.iBCR_SX = sCurrentROI.Left;
        cReplace.iBCR_SY = sCurrentROI.Top;
        cReplace.iBCR_EX = sCurrentROI.Right;
        cReplace.iBCR_EY = sCurrentROI.Bottom;

        CVo.cParaRcp = cReplace.GetValues();
        bool bResult = CVo.Save_Parameter_Recipe();
        if (bResult)
        {
          if (CMaster.cBCR.SetROI(sCurrentROI))
          {
            CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
          }
          else
          {
            CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeBCRROISaveFail);
          }
        }
        else
        {
          CVo.cParaRcp = cOld.GetValues();
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeBCRROISaveFail);
        }
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeBCRROISaveFail);
      }
    }

  }
}
