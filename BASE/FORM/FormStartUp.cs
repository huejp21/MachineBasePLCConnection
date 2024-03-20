using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE.FORM
{
  public partial class FormStartUp : Form
  {
    public FormStartUp()
    {
      InitializeComponent();
    }

    public void Show_()
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Opacity = 100;
      CForm.Hide_Application();
      this.Show();
      System.Threading.Thread.Sleep(100);
    }

    public void Hide_()
    {
      for (double i = 100.0; i >= 0.0; i--)
      {
        this.Opacity = i / 100.0;
        System.Threading.Thread.Sleep(20);
      }
      this.Hide();
      CForm.Show_Application();
    }

    private void FormStartUp_Load(object sender, EventArgs e)
    {
      this.Opacity = 100;
    }
  }
}
