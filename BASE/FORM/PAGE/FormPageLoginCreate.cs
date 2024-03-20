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

namespace BASE.FORM.PAGE
{
  public partial class FormPageLoginCreate : Form
  {
    public FormPageLoginCreate()
    {
      InitializeComponent();
    }

    private void btnCreateBack_Click(object sender, EventArgs e)
    {
      CForm.Display_Page(CForm.frmPageLogin);
    }

    private void txtBox_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strSouce = strSouce = ctrl.Text;
      string strTitle = "";
      string strUser = "";

      //txtCreatePassword
      //txtCreatePasswordC
      //txtCreateInfo
      switch (ctrl.Name)
      {
        case "txtCreateId":
          strTitle = "ID";
          break;
        case "txtCreatePassword":
          strTitle = "Password";
          break;
        case "txtCreatePasswordC":
          strTitle = "Password Confirm";
          break;
        case "txtCreateInfo":
          strTitle = "Information";
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

    private void btnCreateCreate_Click(object sender, EventArgs e)
    {
      string strId = txtCreateId.Text;
      string strPw = txtCreatePassword.Text;
      string strPwC = txtCreatePasswordC.Text;
      string strInfo = txtCreateInfo.Text;

      if (strId.Trim().CompareTo("") == 0
        || strPw.Trim().CompareTo("") == 0
        || strPwC.Trim().CompareTo("") == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginBlankRequiredField);
        return;
      }

      CVo.Load_User();
      for (int i = 0; i < CVo.listUser.Count; i++)
      {
        if (CVo.listUser[i].strId.CompareTo(strId) == 0)
        {
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginExistID);
          return;
        }
      }

      if (strPw.CompareTo(strPwC) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginCreatePwNotCorrect);
        return;
      }

      bool bResult = CVo.Create_User(strId, strPw, strInfo, enumUserLevel.Operator);
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
        return;
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginCreateFail);
        return;
      }
    }

    private void txt_MouseDown(object sender, MouseEventArgs e)
    {
      Control ctrl = (Control)sender;
      ctrl.Text = CForm.frmKeypadChar.Show_(ctrl.Text, "");
    }
  }
}
