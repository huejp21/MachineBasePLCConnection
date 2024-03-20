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

namespace BASE.FORM.SETUP.COMMON
{
  public partial class FormBCR_Lot : Form
  {
    private string strBeforeDate = "";
    private string strData = "";
    public FormBCR_Lot()
    {
      InitializeComponent();
    }

    private void txtBCR_KeyDown(object sender, KeyEventArgs e)
    {
      //e.Handled = true;
    }

    private void txtBCR_KeyPress(object sender, KeyPressEventArgs e)
    {
      //e.Handled = true;
    }

    private void tmr_BCR_Lot_Tick(object sender, EventArgs e)
    {
      tmr_BCR_Lot.Enabled = false;
      txtBCR.Focus();
      tmr_BCR_Lot.Enabled = true;
    }

    public string Show_()
    {
      strBeforeDate = strData;
      txtBCR.Text = "";
      strData = "";
      CForm.Check_Display(this);
      this.TopMost = true;
      this.ShowDialog();
      return strData;
    }

    private void btn_Clear_MouseDown(object sender, MouseEventArgs e)
    {
      txtBCR.Text = "";
    }

    private void btn_Ok_MouseDown(object sender, MouseEventArgs e)
    {
      if (txtBCR.Text.Length != 9)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.BCRLotDataWrong);
        return;
      }
      
      strData = txtBCR.Text;
      this.Hide();
    }

    private void btn_Close_MouseDown(object sender, MouseEventArgs e)
    {
      //strData = strBeforeDate;
      strData = "Cancel";
      this.Hide();
    }

  }
}
