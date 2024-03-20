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
  public partial class FormPageLoginManage : Form
  {
    public FormPageLoginManage()
    {
      InitializeComponent();
    }

    private bool Display_RefreshList()
    {
      listManage.Items.Clear();
      bool bResult = CVo.Load_User();
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginManageLoadFail);
        return false;
      }
      for (int i = 0; i < CVo.listUser.Count; i++)
      {
        listManage.Items.Add(CVo.listUser[i].strId);
      }
      return true;
    }

    private void btnCreateBack_Click(object sender, EventArgs e)
    {
      CForm.Display_Page(CForm.frmPageLogin);
    }

    private void FormPageLoginManage_Load(object sender, EventArgs e)
    {
      int iLength = Enum.GetNames(typeof(enumUserLevel)).Length;
      if (iLength > 1)
      {
        iLength -= 1;
      }
      for (int i = 0; i < iLength; i++)
			{
        cboManageLevel.Items.Add(((enumUserLevel)i).ToString());
			}
      cboManageLevel.SelectedIndex = 0;
    }

    private void listManage_Click(object sender, EventArgs e)
    {
      int iIndex = listManage.SelectedIndex;
      if (iIndex < 0
        || iIndex >= CVo.listUser.Count)
      {
        return;
      }

      txtManageId.Text = CVo.listUser[iIndex].strId;
      txtManagePassword.Text = CVo.listUser[iIndex].strPw;
      txtManagePasswordC.Text = CVo.listUser[iIndex].strPw;
      txtManageInfo.Text = CVo.listUser[iIndex].strInfo;
      cboManageLevel.SelectedIndex = (int)CVo.listUser[iIndex].eLevel;
    }

    private void btnManageApply_Click(object sender, EventArgs e)
    {
      string strId = txtManageId.Text;
      string strPw = txtManagePassword.Text;
      string strPwC = txtManagePasswordC.Text;
      string strInfo = txtManageInfo.Text;
      enumUserLevel eLevel = (enumUserLevel)cboManageLevel.SelectedIndex;

      int iIndex = -1;
      for (int i = 0; i < listManage.Items.Count; i++)
      {
        if (CVo.listUser[i].strId.CompareTo(strId) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (iIndex < 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginManageNotSelect);
        return;
      }

      if (strId.Trim().CompareTo("") == 0 
        || strPw.Trim().CompareTo("") == 0
        || strPwC.Trim().CompareTo("") == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginBlankRequiredField);
        return;
      }

      if (strPw.CompareTo(strPwC) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginCreatePwNotCorrect);
        return;
      }

      bool bResult = CVo.Delete_User(strId);
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginManageDelFail);
        return;
      }

      bResult = CVo.Create_User(strId, strPw, strInfo, eLevel);
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginCreateFail);
        return;
      }

      Display_RefreshList();

      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      return;
    }

    private void btnManageDelete_Click(object sender, EventArgs e)
    {
      int iIndex = listManage.SelectedIndex;
      if (iIndex < 0 || CVo.listUser.Count <= iIndex)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginManageNotSelect);
        return;
      }

      bool bResult = CVo.Delete_User(CVo.listUser[iIndex].strId);
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginManageDelFail);
        return;
      }

      Display_RefreshList();

      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void FormPageLoginManage_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        Display_RefreshList();
      }
    }

    private void FormPageLoginManage_Shown(object sender, EventArgs e)
    {
      Display_RefreshList();
    }

    private void txt_MouseDown(object sender, MouseEventArgs e)
    {
      Control ctrl = (Control)sender;
      ctrl.Text = CForm.frmKeypadChar.Show_(ctrl.Text, "");
    }

  }
}
