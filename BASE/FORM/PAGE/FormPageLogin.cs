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
using BASE.FORM;

namespace BASE.FORM.PAGE
{
  public partial class FormPageLogin : Form
  {
    public FormPageLogin()
    {
      InitializeComponent();
    }

    private void txtBox_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strSouce = strSouce = ctrl.Text;
      string strTitle = "";
      string strUser = "";
      switch (ctrl.Name)
      {
        case "txtLoginId":
          strTitle = "ID";
          break;
        case "txtLoginPassword":
          strTitle = "Password";
          break;
        default:
          strTitle = "Default";
          break;
      }

      strUser = CForm.frmKeypadChar.Show_(strSouce, strTitle);

      if (strUser.CompareTo(strUser.Trim()) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginUnallowbleSpace);
        ctrl.Text = strSouce;
        return;
      }

      bool bExsit = false;
      for (int i = 0; i < CVo.arrExcept.Length; i++)
      {
        bExsit = strUser.Contains(CVo.arrExcept[i]);
        if (bExsit)
        {
          break;
        }
      }
      if (bExsit)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginUnallowbleLetter);
        ctrl.Text = strSouce;
      }
      else
      {
        ctrl.Text = strUser;
      }
    }

    private void btnLoginCreate_Click(object sender, EventArgs e)
    {
      CForm.Display_Page(CForm.frmPageLoginCreate);
    }

    private void btnLoginManage_Click(object sender, EventArgs e)
    {
      string strId = txtLoginId.Text;
      string strPw = txtLoginPassword.Text;
      bool bResult = CVo.Login(strId, strPw);
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginWrongIDPW);
        return;
      }
      if ((CVo.eCurrentUserLevel >= enumUserLevel.Administator) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginCanNotAccess);
        return;
      }
      CForm.Display_Page(CForm.frmPageLoginManage);
    }

    private void btnLoginLogin_Click(object sender, EventArgs e)
    {
      string strId = txtLoginId.Text;
      string strPw = txtLoginPassword.Text;
      bool bResult = CVo.Login(strId, strPw);
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginWrongIDPW);
        return;
      }
      CForm.Display_Page(CForm.frmPageAuto);
    }

    private void FormPageLogin_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        CVo.Logout();
      }
    }

    private void tabLogin_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        txtLoginId.Text = "";
        txtLoginPassword.Text = "";
      }
    }

    private void FormPageLogin_Shown(object sender, EventArgs e)
    {
      txtLoginId.Text = "";
      txtLoginPassword.Text = "";
    }
  }
}
