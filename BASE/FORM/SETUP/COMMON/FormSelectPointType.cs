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
  public partial class FormSelectPointType : Form
  {
    private enumPointType eResult;

    public FormSelectPointType()
    {
      InitializeComponent();
    }

    public enumPointType Show_(string number /* ex) 1-1*/)
    {
      eResult = enumPointType.NONE;
      this.TopMost = true;
      CForm.Check_Display(this);

      lbl_PointType_CurrentPointValue.Text = number;

      this.ShowDialog();
      return eResult;
    }

    private void btn_PointType_Dummy_Click(object sender, EventArgs e)
    {
      eResult = enumPointType.Dummy;
      this.Hide();
    }

    private void btn_PointType_Unit_Click(object sender, EventArgs e)
    {
      eResult = enumPointType.Unit;
      this.Hide();
    }
  }
}
