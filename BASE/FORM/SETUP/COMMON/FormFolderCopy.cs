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
  public partial class FormFolderCopy : Form
  {
    public FormFolderCopy()
    {
      InitializeComponent();
    }

    private void FormFolderCopy_Shown(object sender, EventArgs e)
    {

    }

    private void FormFolderCopy_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        
      }
    }

    public void Show_(List<string> items, string defStr)
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      cboSourceName.Items.Clear();
      for (int i = 0; i < items.Count; i++)
			{
        cboSourceName.Items.Add(items[i]);
			}
      for (int i = 0; i < cboSourceName.Items.Count; i++)
      {
        if (cboSourceName.Items[i].ToString().CompareTo(CVo.RECIPE_CURRENT.Replace("\\", "")) == 0)
        {
          cboSourceName.SelectedIndex = i;
          break;
        }
      }
      txtNewName.Text = defStr;
      this.ShowDialog();
    }

    private void txtNewName_MouseDown(object sender, MouseEventArgs e)
    {
      string strTemp = CForm.frmKeypadChar.Show_(txtNewName.Text, lblNewName.Text);
      string strAllowChar = "[^a-zA-Z0-9_]";
      string strReplaceData = System.Text.RegularExpressions.Regex.Replace(strTemp, strAllowChar, "", System.Text.RegularExpressions.RegexOptions.Singleline);
      if (strTemp.CompareTo(strReplaceData.Trim()) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNameIsWrong);
        return;
      }
      else
      {
        txtNewName.Text = strTemp;
        return;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cboSourceName.Text.Trim().CompareTo("") == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoSelectedSourceFile);
        return;
      }
      if (txtNewName.Text.Trim().CompareTo("") == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNameIsWrong);
        return;
      }
      if (txtNewName.Text.Trim().CompareTo(txtNewName.Text) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNameIsWrong);
        return;
      }
      string strAllowChar = "[^a-zA-Z0-9_]";
      string strReplaceData = System.Text.RegularExpressions.Regex.Replace(txtNewName.Text, strAllowChar, "", System.Text.RegularExpressions.RegexOptions.Singleline);
      if (txtNewName.Text.CompareTo(strReplaceData.Trim()) != 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNameIsWrong);
        return;
      }

      string strSource = cboSourceName.Text + "\\";
      string strSourcePath = CVo.RECIPE_PATH + strSource;

      bool bExsit = false;
      for (int i = 0; i < cboSourceName.Items.Count; i++)
      {
        if (cboSourceName.Items[i].ToString().CompareTo(txtNewName.Text) == 0)
        {
          bExsit = true;
          break;
        }
      }
      if (bExsit)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeCanNotCreateSameName);
        return;
      }
      if (System.IO.Directory.Exists(strSourcePath) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoExist);
        return;
      }

      string strNewRecipe = txtNewName.Text + "\\";
      string strNewRecipePath = CVo.RECIPE_PATH + strNewRecipe;

      System.IO.Directory.CreateDirectory(strNewRecipePath);
      var files = System.IO.Directory.GetFiles(strSourcePath);
      foreach (var item in files)
      {
        System.IO.File.Copy(item, System.IO.Path.Combine(strNewRecipePath, System.IO.Path.GetFileName(item)), true);
      }
      CForm.frmPageRecipe.Display_RecipeList();
      List<string> listRcp = CForm.frmPageRecipe.Get_RecipeList();
      string strOldSource = cboSourceName.Text;
      cboSourceName.Items.Clear();
      for (int i = 0; i < listRcp.Count; i++)
      {
        cboSourceName.Items.Add(listRcp[i]);
      }
      cboSourceName.Text = strOldSource;

      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Hide();
    }
  }
}
