using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE.FORM.SETUP.COMMON
{
  public enum eNumpadFocus
  { 
    Value = 0,
    Calc
  };

  public partial class FormKeypadNum : Form
  {
    private bool bOption = false;
    private eNumpadFocus eFocus = eNumpadFocus.Value;

    private string strInput = "";

    public FormKeypadNum()
    {
      InitializeComponent();
    }

    public string Show_(string source, string strTitle)
    {
      bOption = false;
      On_Option(bOption);
      strInput = source;
      this.TopMost = true;
      lblKeypadNumTitle.Text = strTitle;
      txtKeypadNumValue.Text = strInput;
      txtKeypadNumPreviousValue.Text = strInput;
      CForm.Check_Display(this);


      this.ShowDialog();
      return strInput;
    }

    private System.Windows.Forms.TextBox Get_TextBox()
    {
      switch (eFocus)
      {
        case eNumpadFocus.Value: return txtKeypadNumValue;
        case eNumpadFocus.Calc: return txtKeypadNumCalcValue;
        default: return txtKeypadNumValue;
      }
    }

    private void On_Option(bool bOn)
    {
      if (bOption)
      {
        this.Width = 470;
        btnKeypadNumOption.Text = "Option◀";
      }
      else
      {
        this.Width = 317;
        btnKeypadNumOption.Text = "Option▶";
      }
    }

    private void Focus_MouseDown(object sender, MouseEventArgs e)
    {
      string strControlName = ((System.Windows.Forms.Control)sender).Name;
      switch (strControlName)
      {
        case "txtKeypadNumValue": eFocus = eNumpadFocus.Value; break;
        case "txtKeypadNumCalcValue": eFocus = eNumpadFocus.Calc; break;
        default: eFocus = eNumpadFocus.Value; break;
      }
    }

    private void btn_keypadNum_Option_Click(object sender, EventArgs e)
    {
      bOption = !bOption;
      On_Option(bOption);
    }

    private void btn_Key_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrlSender = (Control)sender;
      Get_TextBox().Focus();

      if (ctrlSender.Text.CompareTo(".") == 0)
      {
        if (Get_TextBox().Text.Contains("."))
        {
          return;
        }
        else
        {
          if (Get_TextBox().Text.Length == 0
            && Get_TextBox().SelectionStart == 0)
          {
            Get_TextBox().Text = "0." + Get_TextBox().Text;
            Get_TextBox().SelectionStart = 2;
            Get_TextBox().Focus();
            return;
          }
        }
      }

      if ((Get_TextBox().Text == "0") && (ctrlSender.Text == "0"))
      {
        return;
      }

      if ((Get_TextBox().Text == "0") && (ctrlSender.Text != "."))
      {
        Get_TextBox().Text = "";
      }

      if (Get_TextBox().Text.Length == 1)
      {
        Get_TextBox().SelectionStart = 1;
      }

      SendKeys.Send(ctrlSender.Text.Trim());
    }

    private void btn_keypadNum_Clear_Click(object sender, EventArgs e)
    {
      Get_TextBox().Text = "0";
      Get_TextBox().Focus();
    }

    private void btn_keypadNum_Del_Click(object sender, EventArgs e)
    {
      int iSelectionStart = 0;

      Get_TextBox().Focus();

      if (Get_TextBox().Text.Trim() == "")
      {
        return;
      }

      if (Get_TextBox().SelectionStart == 0)
      {
        Get_TextBox().SelectionStart = Get_TextBox().TextLength;
      }

      string strBuffer = Get_TextBox().Text;
      iSelectionStart = Get_TextBox().SelectionStart;
      Get_TextBox().Text = Get_TextBox().Text.Substring(0, iSelectionStart - 1) + Get_TextBox().Text.Substring(iSelectionStart);
      Get_TextBox().Focus();
      iSelectionStart = iSelectionStart - 1;
      if (Get_TextBox().Text.Length > 0)
      {
        if (Get_TextBox().Text[0] == '.')
        {
          Get_TextBox().Text = strBuffer;
          Get_TextBox().SelectionStart = 1;
          Get_TextBox().Focus();
          return;
        }
      }
      Get_TextBox().SelectionStart = iSelectionStart;
      Get_TextBox().Select(iSelectionStart, 0);
    }

    private void btn_keypadNum_Plus_Click(object sender, EventArgs e)
    {
      if (eFocus != eNumpadFocus.Value)
      {
        eFocus = eNumpadFocus.Value;
      }
      int iSelectionStart = Get_TextBox().SelectionStart;
      if (Get_TextBox().Text.Length <= 0)
      {
        return;
      }

      bool bExist = Get_TextBox().Text.Contains("-");
      if (bExist)
      {
        Get_TextBox().Text = Get_TextBox().Text.Replace("-", "");
        if (iSelectionStart > 0)
        {
          Get_TextBox().SelectionStart = iSelectionStart - 1;
        }
        else
        {
          Get_TextBox().SelectionStart = iSelectionStart;
        }
      }

      Get_TextBox().Focus();
    }

    private void btn_keypadNum_Minus_Click(object sender, EventArgs e)
    {
      if (eFocus != eNumpadFocus.Value)
      {
        eFocus = eNumpadFocus.Value;
      }
      int iSelectionStart = Get_TextBox().SelectionStart;
      if (Get_TextBox().Text.Length <= 0)
      {
        Get_TextBox().Text = "-";
        Get_TextBox().SelectionStart = iSelectionStart + 1;
        Get_TextBox().Focus();
        return;
      }

      if (Get_TextBox().Text.Contains("-"))
      {
        Get_TextBox().SelectionStart = iSelectionStart;
        Get_TextBox().Focus();
        return;
      }

      string strText = Get_TextBox().Text;
      Get_TextBox().Text = "-" + strText;
      Get_TextBox().SelectionStart = iSelectionStart + 1;
      Get_TextBox().Focus();
    }

    private void btnKeypadNumLeft_Click(object sender, EventArgs e)
    {
      Get_TextBox().Focus();
      SendKeys.Send("{LEFT}");
      Get_TextBox().Focus();
    }

    private void btnKeypadNumRight_Click(object sender, EventArgs e)
    {
      Get_TextBox().Focus();
      SendKeys.Send("{RIGHT}");
      Get_TextBox().Focus();
    }

    private void btnKeypadNumDown_Click(object sender, EventArgs e)
    {
      int iSelectionStart = Get_TextBox().SelectionStart;
      string strData = "";

      if (Get_TextBox().Text.Trim() == "")
      {
        return;
      }
      if (Get_TextBox().SelectionStart == 0)
      {
        return;
      }
      float fTemp;
      if (float.TryParse(Get_TextBox().Text, out fTemp) == false)
      {
        return;
      }
      strData = Get_TextBox().Text.Substring(iSelectionStart - 1, 1);
      Control ctrl = (Control)sender;

      if (strData.CompareTo("0") != 0
        && strData.CompareTo(".") != 0
        && strData.CompareTo("-") != 0)
      {
        strData = (Convert.ToInt16(strData) - 1).ToString();
      }

      Get_TextBox().Text = Get_TextBox().Text.Substring(0, iSelectionStart - 1) + strData + Get_TextBox().Text.Substring(iSelectionStart);
      Get_TextBox().Focus();
      Get_TextBox().SelectionStart = iSelectionStart;
      Get_TextBox().Select(iSelectionStart, 0);   
    }

    private void btnKeypadNumUp_Click(object sender, EventArgs e)
    {
      int iSelectionStart = Get_TextBox().SelectionStart;
      string strData = "";

      if (Get_TextBox().Text.Trim() == "")
      {
        return;
      }
      if (Get_TextBox().SelectionStart == 0)
      {
        return;
      }
      float fTemp;
      if (float.TryParse(Get_TextBox().Text, out fTemp) == false)
      {
        return;
      }
      strData = Get_TextBox().Text.Substring(iSelectionStart - 1, 1);
      Control ctrl = (Control)sender;

      if (strData.CompareTo("9") != 0 
        && strData.CompareTo(".") != 0
        && strData.CompareTo("-") != 0)
      {
        strData = (Convert.ToInt16(strData) + 1).ToString();
      }

      Get_TextBox().Text = Get_TextBox().Text.Substring(0, iSelectionStart - 1) + strData + Get_TextBox().Text.Substring(iSelectionStart);
      Get_TextBox().Focus();
      Get_TextBox().SelectionStart = iSelectionStart;
      Get_TextBox().Select(iSelectionStart, 0);   
    }

    private void btnKeypadNumOk_Click(object sender, EventArgs e)
    {
      strInput = txtKeypadNumValue.Text;
      this.Hide();
    }

    private void btnKeypadNumCancel_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void btnKeypadNumRestore_Click(object sender, EventArgs e)
    {
      txtKeypadNumValue.Text = txtKeypadNumPreviousValue.Text;
    }

    private void btnKeypadNumSub_Click(object sender, EventArgs e)
    {
      float fTemp;
      if (float.TryParse(txtKeypadNumCalcValue.Text, out fTemp) == false)
      {
        return;
      }
      if (float.TryParse(txtKeypadNumValue.Text, out fTemp) == false)
      {
        return;
      }
      double dBuffer1 = Convert.ToDouble(txtKeypadNumCalcValue.Text);
      double dBuffer2 = Convert.ToDouble(txtKeypadNumValue.Text);
      double dResult = dBuffer2 - dBuffer1;
      txtKeypadNumValue.Text = dResult.ToString();
    }

    private void btnKeypadNumAdd_Click(object sender, EventArgs e)
    {
      float fTemp;
      if (float.TryParse(txtKeypadNumCalcValue.Text, out fTemp) == false)
      {
        return;
      }
      if (float.TryParse(txtKeypadNumValue.Text, out fTemp) == false)
      {
        return;
      }
      double dBuffer1 = Convert.ToDouble(txtKeypadNumCalcValue.Text);
      double dBuffer2 = Convert.ToDouble(txtKeypadNumValue.Text);
      double dResult = dBuffer2 + dBuffer1;
      txtKeypadNumValue.Text = dResult.ToString();
    }

    private void FormKeypadNum_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        eFocus = eNumpadFocus.Value;        
      }
    }

    private void FormKeypadNum_Shown(object sender, EventArgs e)
    {
      eFocus = eNumpadFocus.Value;   
    }

    private void FormKeypadNum_KeyPress(object sender, KeyPressEventArgs e)
    {
      string strData = Get_TextBox().Text;
      bool bResult1 = (e.KeyChar >= '0' && e.KeyChar <= '9');
      bool bResult2 = (e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '\b');
      bool bTotal = (bResult1 || bResult2);
      if (bTotal == false)
      {
        e.Handled = true;
      }

      if (e.KeyChar == '\r')
      {
        strInput = txtKeypadNumValue.Text;
        this.Hide();
      }
    }
  }
}
