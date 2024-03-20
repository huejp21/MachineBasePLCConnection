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
  public partial class FormFolderCreate : Form
  {
    string strData = "";
    public FormFolderCreate()
    {
      InitializeComponent();
    }

    private void FormFolder_Shown(object sender, EventArgs e)
    {
      
    }

    private void FormFolder_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible == true)
      {
        
      }
    }

    public string Show_(string defStr)
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      txtName.Text = defStr;
      this.ShowDialog();
      System.Threading.Thread.Sleep(100);
      return strData;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      strData = txtName.Text;
      this.Hide();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      strData = "(CANCEL)";
      this.Hide();
    }

    private void txtName_MouseDown(object sender, MouseEventArgs e)
    {
      string strTemp = CForm.frmKeypadChar.Show_(txtName.Text, lblName.Text);
      string strAllowChar = "[^a-zA-Z0-9_]";
      string strReplaceData = System.Text.RegularExpressions.Regex.Replace(strTemp, strAllowChar, "", System.Text.RegularExpressions.RegexOptions.Singleline);
      if (strTemp.CompareTo(strReplaceData.Trim()) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNameIsWrong);
        return;
      }
      else
      {
        txtName.Text = strTemp;
        return;
      }
    }

  }
}
