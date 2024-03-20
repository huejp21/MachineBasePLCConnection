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
using BASE.MASTER;

namespace BASE.FORM.MSGBOX
{
  /// <summary>
  /// A: AbortRetryIgnore
  /// B: OK
  /// C: OKCancel
  /// D: RetryCancel
  /// E: YesNo
  /// F: YesNoCancel
  /// </summary>
  public partial class FormMessageBox_Msg : Form
  {
    #region Delegate
    public delegate DialogResult del_Show_(enumMsg type);
    #endregion

    private enumMsg eCurrentType = enumMsg.NONE_NONE;
    private System.Windows.Forms.DialogResult eCurrentResult = System.Windows.Forms.DialogResult.None;

    public FormMessageBox_Msg()
    {
      InitializeComponent();
    }

    public DialogResult Show_(enumMsg type)
    {
      if (this.InvokeRequired)
      {
        del_Show_ Show__ = new del_Show_(Show_);
        object obj = this.Invoke(Show__, new object[] { type });
        return (DialogResult)obj;
      }


      string strType = "";
      eCurrentResult = System.Windows.Forms.DialogResult.None;
      try
      {
        strType = type.ToString().Split('_')[1];
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return eCurrentResult;
      }
      CForm.Check_Display(this);
      switch (strType)
      {
        // Image
        // 0: Cancle
        // 1: OK or YES
        // 2: Ignore
        // 4: NO
        // 5: Retry
        case "A": // AbortRetryIgnore
          btnMessageBoxMsg_3.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "무시" : "Ignore";
          btnMessageBoxMsg_2.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "재시도" : "Retry";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "취소" : "Cancel";
          btnMessageBoxMsg_3.Visible = true;
          btnMessageBoxMsg_2.Visible = true;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_3.ImageIndex = 2;
          btnMessageBoxMsg_2.ImageIndex = 5;
          btnMessageBoxMsg_1.ImageIndex = 0;
          break;
        case "B": // OK
          btnMessageBoxMsg_3.Text = "";
          btnMessageBoxMsg_2.Text = "";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "확인" : "OK";
          btnMessageBoxMsg_3.Visible = false;
          btnMessageBoxMsg_2.Visible = false;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_1.ImageIndex = 1;
          break;
        case "C": // OKCancel
          btnMessageBoxMsg_3.Text = "";
          btnMessageBoxMsg_2.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "확인" : "OK";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "취소" : "Cancel";
          btnMessageBoxMsg_3.Visible = false;
          btnMessageBoxMsg_2.Visible = true;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_2.ImageIndex = 1;
          btnMessageBoxMsg_1.ImageIndex = 0;
          break;
        case "D": // RetryCancel
          btnMessageBoxMsg_3.Text = "";
          btnMessageBoxMsg_2.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "재시도" : "Retry";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "취소" : "Cancel";
          btnMessageBoxMsg_3.Visible = false;
          btnMessageBoxMsg_2.Visible = true;
          btnMessageBoxMsg_2.ImageIndex = 5;
          btnMessageBoxMsg_1.ImageIndex = 0;
          break;
        case "E": // YesNo
          btnMessageBoxMsg_3.Text = "";
          btnMessageBoxMsg_2.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "예" : "Yes";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "아니오" : "No";
          btnMessageBoxMsg_3.Visible = false;
          btnMessageBoxMsg_2.Visible = true;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_2.ImageIndex = 1;
          btnMessageBoxMsg_1.ImageIndex = 4;
          break;
        case "F": // YesNoCancel
          btnMessageBoxMsg_3.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "예" : "Yes";
          btnMessageBoxMsg_2.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "아니오" : "No";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "취소" : "Cancel";
          btnMessageBoxMsg_3.Visible = true;
          btnMessageBoxMsg_2.Visible = true;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_3.ImageIndex = 1;
          btnMessageBoxMsg_2.ImageIndex = 4;
          btnMessageBoxMsg_1.ImageIndex = 0;
          break;
        default: // NONE: Cancel
          btnMessageBoxMsg_3.Text = "";
          btnMessageBoxMsg_2.Text = "";
          btnMessageBoxMsg_1.Text = CVo.eCurrentLanguage == enumLanguageType.Korean ? "취소" : "Cancel";
          btnMessageBoxMsg_3.Visible = false;
          btnMessageBoxMsg_2.Visible = false;
          btnMessageBoxMsg_1.Visible = true;
          btnMessageBoxMsg_1.ImageIndex = 0;
          break;
      }
      eCurrentType = type;
      int iIndex = (int)type;
      lblMessageBoxMsgTitle.Text = string.Format("[{0}]{1}", iIndex.ToString(), CVo.arrMsgName[iIndex]);
      lblMessageBoxMsgInfo.Text = CVo.arrMsgInfo[iIndex];
      this.TopMost = true;
      this.ShowDialog();
      return eCurrentResult;
    }

    private void btnMessageBoxMsg_3_Click(object sender, EventArgs e)
    {
      string strType = "";
      try
      {
        strType = eCurrentType.ToString().Split('_')[1];
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        this.Hide();
        return;
      }
      switch (strType)
      {
        case "A": // AbortRetryIgnore
          eCurrentResult = System.Windows.Forms.DialogResult.Ignore;
          break;
        case "B": // OK
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
        case "C": // OKCancel
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
        case "D": // RetryCancel
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
        case "E": // YesNo
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
        case "F": // YesNoCancel
          eCurrentResult = System.Windows.Forms.DialogResult.Yes;
          break;
        default: // NONE: Cancel
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
      }
      this.Hide();
    }

    private void btnMessageBoxMsg_2_Click(object sender, EventArgs e)
    {
      string strType = "";
      try
      {
        strType = eCurrentType.ToString().Split('_')[1];
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        this.Hide();
        return;
      }
      switch (strType)
      {
        case "A": // AbortRetryIgnore
          eCurrentResult = System.Windows.Forms.DialogResult.Retry;
          break;
        case "B": // OK
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
        case "C": // OKCancel
          eCurrentResult = System.Windows.Forms.DialogResult.OK;
          break;
        case "D": // RetryCancel
          eCurrentResult = System.Windows.Forms.DialogResult.Retry;
          break;
        case "E": // YesNo
          eCurrentResult = System.Windows.Forms.DialogResult.Yes;
          break;
        case "F": // YesNoCancel
          eCurrentResult = System.Windows.Forms.DialogResult.No;
          break;
        default: // NONE: Cancel
          eCurrentResult = System.Windows.Forms.DialogResult.None;
          break;
      }
      this.Hide();
    }

    private void btnMessageBoxMsg_1_Click(object sender, EventArgs e)
    {
      string strType = "";
      try
      {
        strType = eCurrentType.ToString().Split('_')[1];
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        this.Hide();
        return;
      }
      switch (strType)
      {
        case "A": // AbortRetryIgnore
          eCurrentResult = System.Windows.Forms.DialogResult.Cancel;
          break;
        case "B": // OK
          eCurrentResult = System.Windows.Forms.DialogResult.OK;
          break;
        case "C": // OKCancel
          eCurrentResult = System.Windows.Forms.DialogResult.Cancel;
          break;
        case "D": // RetryCancel
          eCurrentResult = System.Windows.Forms.DialogResult.Cancel;
          break;
        case "E": // YesNo
          eCurrentResult = System.Windows.Forms.DialogResult.No;
          break;
        case "F": // YesNoCancel
          eCurrentResult = System.Windows.Forms.DialogResult.Cancel;
          break;
        default: // NONE: Cancel
          eCurrentResult = System.Windows.Forms.DialogResult.Cancel;
          break;
      }
      this.Hide();
    }

    private void tmr_Msg_Tick(object sender, EventArgs e)
    {
      tmr_Msg.Enabled = false;
      tmr_Msg.Enabled = true;
    }
  }
}
