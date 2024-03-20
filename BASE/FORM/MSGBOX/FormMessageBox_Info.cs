using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE.FORM.MSGBOX
{
  public partial class FormMessageBox_Info : Form
  {
    public FormMessageBox_Info()
    {
      InitializeComponent();
    }

    private void btn_messageBox_info_close_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void ttmr_Info_Tick(object sender, EventArgs e)
    {
      ttmr_Info.Enabled = false;
      if (this.Visible)
      {
        this.TopMost = true;
      }
      ttmr_Info.Enabled = true;
    }
  }
}
