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
  public partial class FormPageTestCycle : Form
  {
    private enum enumTestMode
    {
      Cycle,
      Bust,
    }
    private enumTestMode eTestMode1 = enumTestMode.Cycle;
    private enumTestMode eTestMode2 = enumTestMode.Cycle;

    public FormPageTestCycle()
    {
      InitializeComponent();
    }

    private void FormPageTestCycle_Load(object sender, EventArgs e)
    {
      cbo_Test1Mode.Items.Clear();
      cbo_Test2Mode.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumTestMode)).Length; i++)
      {
        cbo_Test1Mode.Items.Add(((enumTestMode)i).ToString());
        cbo_Test2Mode.Items.Add(((enumTestMode)i).ToString());
      }
      cbo_Test1Mode.SelectedIndex = 0;
      cbo_Test2Mode.SelectedIndex = 0;
      eTestMode1 = (enumTestMode)cbo_Test1Mode.SelectedIndex;
      eTestMode2 = (enumTestMode)cbo_Test2Mode.SelectedIndex;

      Refreash_Data();
    }

    private void cbo_TestMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strName = ctrl.Name;
      switch (strName)
      {
        case "cbo_Test1Mode": eTestMode1 = (enumTestMode)cbo_Test1Mode.SelectedIndex; break;
        case "cbo_Test2Mode": eTestMode2 = (enumTestMode)cbo_Test1Mode.SelectedIndex; break;
        default:
          break;
      }
    }

    private void Refreash_Data()
    { 
      txtTestRepeat1.Text = CVo.iTestRepeat_Bust1.ToString();
      txtTestRepeat2.Text = CVo.iTestRepeat_Bust2.ToString();
      txtTestGap1.Text = CVo.iTestDelay_Bust1.ToString();
      txtTestGap2.Text = CVo.iTestDelay_Bust2.ToString();
    }

    private void txt_IntMouseDown(object sender, MouseEventArgs e)
    {
      if (CVo.bRunning_All)
      {
        // 동작중이면 리턴
        return;
      }

      if (CVo.TestRunning())
      {
        // 테스트 동작중이면 리턴
        return;
      }

      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "Number");

      if (strData.Trim().CompareTo("") == 0)
      {
        //  값없음
        return;
      }
      int iTemp;
      if (int.TryParse(strData, out iTemp) == false)
      {
        // 숫자아님
        return;
      }

      switch (ctrl.Name)
      {
        case "txtTestRepeat1": CVo.iTestRepeat_Bust1 = iTemp; break;
        case "txtTestRepeat2": CVo.iTestRepeat_Bust2 = iTemp; break;
        case "txtTestGap1": CVo.iTestDelay_Bust1 = iTemp; break;
        case "txtTestGap2": CVo.iTestDelay_Bust2 = iTemp; break;
        default: break;
      }

      Refreash_Data();
    }

    private void btnTest_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strName = ctrl.Name;





      switch (strName)
      {
        case "btnTestMeasure1":
          CVo.bTestMeasure1 = (eTestMode1 == enumTestMode.Cycle) ? !CVo.bTestMeasure1 : false;
          CVo.bTestZeroSet1 = false;
          CVo.bTestMeasure_Bust1 = (eTestMode1 == enumTestMode.Bust) ? !CVo.bTestMeasure_Bust1 : false;
          CVo.bTestZeroSet_Bust1 = false;
          break;
        case "btnTestZero1": 
          CVo.bTestMeasure1 = false;
          CVo.bTestZeroSet1 = (eTestMode1 == enumTestMode.Cycle) ? !CVo.bTestZeroSet1 : false;
          CVo.bTestMeasure_Bust1 = false;
          CVo.bTestZeroSet_Bust1 = (eTestMode1 == enumTestMode.Bust) ? !CVo.bTestZeroSet_Bust1 : false;
          break;
        case "btnTestMeasure2":
          CVo.bTestMeasure2 = (eTestMode2 == enumTestMode.Cycle) ? !CVo.bTestMeasure2 : false;
          CVo.bTestZeroSet2 = false;
          CVo.bTestMeasure_Bust2 = (eTestMode2 == enumTestMode.Bust) ? !CVo.bTestMeasure_Bust2 : false;
          CVo.bTestZeroSet_Bust2 = false;
          break;
        case "btnTestZero2": 
          CVo.bTestMeasure2 = false;
          CVo.bTestZeroSet2 = (eTestMode2 == enumTestMode.Cycle) ? !CVo.bTestZeroSet2 : false;
          CVo.bTestMeasure_Bust2 = false;
          CVo.bTestZeroSet_Bust2 = (eTestMode2 == enumTestMode.Bust) ? !CVo.bTestZeroSet_Bust2 : false;
          break;
        default:
          break;
      }

    }

    private void tmr_Test_Tick(object sender, EventArgs e)
    {
      tmr_Test.Enabled = false;
      btnTestMeasure1.BackColor = (CVo.bTestMeasure1 || CVo.bTestMeasure_Bust1) ? Color.Lime : Color.White;
      btnTestZero1.BackColor = (CVo.bTestZeroSet1 || CVo.bTestZeroSet_Bust1) ? Color.Lime : Color.White;
      btnTestMeasure2.BackColor = (CVo.bTestMeasure2 || CVo.bTestMeasure_Bust2) ? Color.Lime : Color.White;
      btnTestZero2.BackColor = (CVo.bTestZeroSet2 || CVo.bTestZeroSet_Bust2) ? Color.Lime : Color.White;
      tmr_Test.Enabled = true;
    }


  }
}
