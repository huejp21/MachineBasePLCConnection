using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace BASE.FORM.SETUP.COMMON
{
  public partial class FormKeypadChar : Form
  {
    private List<System.Windows.Forms.Button> listCharButton = new List<Button>();
    private string strInput = "";

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int nVirtualKey);
    public void CapsLockOnOff()
    {
      keybd_event((byte)Keys.CapsLock, 0, 0, 0);
      keybd_event((byte)Keys.CapsLock, 0, 0x02, 0);
    }

    public FormKeypadChar()
    {
      InitializeComponent();

      System.Windows.Forms.Application.Idle += Application_Idle; //For Monitoring Capslock status

      //Add Char Button
      listCharButton.Clear();
      listCharButton.Add(btnKeypadCharQ);
      listCharButton.Add(btnKeypadCharW);
      listCharButton.Add(btnKeypadCharE);
      listCharButton.Add(btnKeypadCharR);
      listCharButton.Add(btnKeypadCharT);
      listCharButton.Add(btnKeypadCharY);
      listCharButton.Add(btnKeypadCharU);
      listCharButton.Add(btnKeypadCharI);
      listCharButton.Add(btnKeypadCharO);
      listCharButton.Add(btnKeypadCharP);
      listCharButton.Add(btnKeypadCharA);
      listCharButton.Add(btnKeypadCharS);
      listCharButton.Add(btnKeypadCharD);
      listCharButton.Add(btnKeypadCharF);
      listCharButton.Add(btnKeypadCharG);
      listCharButton.Add(btnKeypadCharH);
      listCharButton.Add(btnKeypadCharJ);
      listCharButton.Add(btnKeypadCharK);
      listCharButton.Add(btnKeypadCharL);
      listCharButton.Add(btnKeypadCharZ);
      listCharButton.Add(btnKeypadCharX);
      listCharButton.Add(btnKeypadCharC);
      listCharButton.Add(btnKeypadCharV);
      listCharButton.Add(btnKeypadCharB);
      listCharButton.Add(btnKeypadCharN);
      listCharButton.Add(btnKeypadCharM);
    }

    public string Show_(string source, string title)
    {
      strInput = source;
      this.TopMost = true;
      lblKeypadCharTitle.Text = title;
      txtKeypadCharValue.Text = strInput;
      txtKeypadCharPreviousValue.Text = strInput;

      CForm.Check_Display(this);
      this.ShowDialog();
      return strInput;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      bool bOn = Control.IsKeyLocked(Keys.CapsLock);
      btnKeypadCharCapsLock.BackColor = bOn ? System.Drawing.Color.Lime : System.Drawing.Color.LightSlateGray;
      string strKey = "";
      for (int i = 0; i < listCharButton.Count; i++)
      {
        strKey = bOn ? listCharButton[i].Text.ToUpper() : listCharButton[i].Text.ToLower();
        if (listCharButton[i].Text.CompareTo(strKey) != 0)
        {
          listCharButton[i].Text = strKey;
        }
      }
    } //For Monitoring Capslock status

    private void btn_keypadChar_Clear_Click(object sender, EventArgs e)
    {
      txtKeypadCharValue.Text = "";
      txtKeypadCharValue.Focus();
    }

    private void btn_Key_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrlSender = (Control)sender;
      this.txtKeypadCharValue.Focus();
      int iSelectionStart = txtKeypadCharValue.SelectionStart;
      string strData = txtKeypadCharValue.Text.Insert(iSelectionStart, ctrlSender.Text.Trim());

      txtKeypadCharValue.Text = strData;

      txtKeypadCharValue.Focus();
      txtKeypadCharValue.SelectionStart = iSelectionStart + 1;
    }

    private void btn_keypadChar_Del_Click(object sender, EventArgs e)
    {
      int iSelectionStart = 0;
      txtKeypadCharValue.Focus();

      if (txtKeypadCharValue.Text.Trim() == "")
      {
        return;
      }

      if (txtKeypadCharValue.SelectionStart == 0)
      {
        txtKeypadCharValue.SelectionStart = txtKeypadCharValue.TextLength;
      }
      iSelectionStart = txtKeypadCharValue.SelectionStart;
      txtKeypadCharValue.Text = txtKeypadCharValue.Text.Substring(0, iSelectionStart - 1) + txtKeypadCharValue.Text.Substring(iSelectionStart);
      txtKeypadCharValue.Focus();
      txtKeypadCharValue.SelectionStart = iSelectionStart - 1;
      txtKeypadCharValue.Select(iSelectionStart, 0);   
    }

    private void btn_keypadChar_Left_Click(object sender, EventArgs e)
    {
      txtKeypadCharValue.Focus();
      SendKeys.Send("{LEFT}");
      txtKeypadCharValue.Focus();
    }

    private void btn_keypadChar_Right_Click(object sender, EventArgs e)
    {
      txtKeypadCharValue.Focus();
      SendKeys.Send("{RIGHT}");
      txtKeypadCharValue.Focus();
    }

    private void btn_keypadChar_Space_Click(object sender, EventArgs e)
    {
      string strData = "";
      if (txtKeypadCharValue.TextLength == txtKeypadCharValue.MaxLength)
      {
        return;
      }
      txtKeypadCharValue.Focus();
      int iSelectionStart = txtKeypadCharValue.SelectionStart;
      strData = txtKeypadCharValue.Text.Substring(0, iSelectionStart) + " " + txtKeypadCharValue.Text.Substring(iSelectionStart, txtKeypadCharValue.Text.Length - iSelectionStart);
      txtKeypadCharValue.Text = strData;
      txtKeypadCharValue.SelectionStart = iSelectionStart + 1;
    }

    private void btn_keypadChar_CapsLock_CheckedChanged(object sender, EventArgs e)
    {
      CapsLockOnOff();
      bool bOn = Control.IsKeyLocked(Keys.CapsLock);
      btnKeypadCharCapsLock.BackColor = bOn ? System.Drawing.Color.Lime : System.Drawing.Color.LightSlateGray;
      for (int i = 0; i < listCharButton.Count; i++)
      {
        listCharButton[i].Text = bOn ? listCharButton[i].Text.ToUpper() : listCharButton[i].Text.ToLower();
      }
    }

    private void btn_keypadChar_Ok_Click(object sender, EventArgs e)
    {
      strInput = txtKeypadCharValue.Text;
      this.Hide();
    }

    private void btn_keypadChar_Cancel_Click(object sender, EventArgs e)
    {
      strInput = txtKeypadCharPreviousValue.Text;
      this.Hide();
    }

    private void btn_keypadChar_Restore_Click(object sender, EventArgs e)
    {
      txtKeypadCharValue.Text = txtKeypadCharPreviousValue.Text;
      this.txtKeypadCharValue.Focus();
      txtKeypadCharValue.Select(txtKeypadCharValue.Text.Length, 0);
    }

    private void KeyPress_Event(object sender, KeyPressEventArgs e)
    {
      bool bResult1 = (e.KeyChar >= 'a' && e.KeyChar <= 'z');
      bool bResult2 = (e.KeyChar >= 'A' && e.KeyChar <= 'Z');
      bool bResult3 = (e.KeyChar >= '0' && e.KeyChar <= '9');
      bool bResult4 = (e.KeyChar == '.' || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '_' || e.KeyChar == ' ' || e.KeyChar == '\b');
      bool bTotal = (bResult1 || bResult2 || bResult3 || bResult4);
      if (bTotal == false)
      {
        e.Handled = true;
      }

      if (e.KeyChar == '\r')
      {
        strInput = txtKeypadCharValue.Text;
        this.Hide();
      }
    }

    private void FormKeypadChar_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        txtKeypadCharValue.Focus();
      }
    }

    private void FormKeypadChar_Shown(object sender, EventArgs e)
    {
      txtKeypadCharValue.Focus();
    }
  }
}
