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
  public partial class FormMessageBox_Input : Form
  {
    public FormMessageBox_Input()
    {
      InitializeComponent();
    }

    private void tmr_Input_Tick(object sender, EventArgs e)
    {
      tmr_Input.Enabled = false;
      if (this.Visible)
      {
        this.TopMost = true;
      }
      tmr_Input.Enabled = true;

    }
  }
}
