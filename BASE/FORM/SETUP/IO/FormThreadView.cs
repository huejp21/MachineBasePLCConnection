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

namespace BASE.FORM.SETUP.IO
{
  public partial class FormThreadView : Form
  {
    public FormThreadView()
    {
      InitializeComponent();
    }

    public void Show_()
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Show();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void tmr_ThreadView_Tick(object sender, EventArgs e)
    {
      // Debug용 Grid 
      SetThreadStatusGridView(grid_ThStatus_LE_AL, enumCycleStatus.LE_Align);
      SetThreadStatusGridView(grid_ThStatus_LE_Cassette, enumCycleStatus.LE_Cassette_Wait);
      SetThreadStatusGridView(grid_ThStatus_UE1_AL, enumCycleStatus.UE1_Align);
      SetThreadStatusGridView(grid_ThStatus_UE1_Cassette, enumCycleStatus.UE1_Cassette_Wait);
      SetThreadStatusGridView(grid_ThStatus_UE2_AL, enumCycleStatus.UE2_Align);
      SetThreadStatusGridView(grid_ThStatus_UE2_Cassette, enumCycleStatus.UE2_Cassette_Wait);
      SetThreadStatusGridView(grid_ThStatus_UE3_AL, enumCycleStatus.UE3_Align);
      SetThreadStatusGridView(grid_ThStatus_UE3_Cassette, enumCycleStatus.UE3_Cassette_Wait);
      SetThreadStatusGridView(grid_ThStatus_UE4_AL, enumCycleStatus.UE4_Align);
      SetThreadStatusGridView(grid_ThStatus_UE4_Cassette, enumCycleStatus.UE4_Cassette_Wait);
      SetThreadStatusGridView(grid_ThStatus_LE_LP, enumCycleStatus.LE_to_LP);
      SetThreadStatusGridView(grid_ThStatus_LP_AL, enumCycleStatus.LP_to_AL);
      SetThreadStatusGridView(grid_ThStatus_AL, enumCycleStatus.Align);
      SetThreadStatusGridView(grid_ThStatus_AL_LP, enumCycleStatus.AL_to_LP);
      SetThreadStatusGridView(grid_ThStatus_LP_ST1, enumCycleStatus.LP_to_Stage1);
      SetThreadStatusGridView(grid_ThStatus_LP_ST2, enumCycleStatus.LP_to_Stage2);
      SetThreadStatusGridView(grid_ThStatus_ST1_Zero, enumCycleStatus.Stage1_Zero);
      SetThreadStatusGridView(grid_ThStatus_ST2_Zero, enumCycleStatus.Stage2_Zero);
      SetThreadStatusGridView(grid_ThStatus_ST1_MS, enumCycleStatus.Stage1_Measure);
      SetThreadStatusGridView(grid_ThStatus_ST2_MS, enumCycleStatus.Stage2_Measure);
      SetThreadStatusGridView(grid_ThStatus_ST1_UL, enumCycleStatus.Stage1_to_UP);
      SetThreadStatusGridView(grid_ThStatus_ST2_UL, enumCycleStatus.Stage2_to_UP);
      SetThreadStatusGridView(grid_ThStatus_UL_UE1, enumCycleStatus.UP_to_UE1);
      SetThreadStatusGridView(grid_ThStatus_UL_UE2, enumCycleStatus.UP_to_UE2);
      SetThreadStatusGridView(grid_ThStatus_UL_UE3, enumCycleStatus.UP_to_UE3);
      SetThreadStatusGridView(grid_ThStatus_UL_UE4, enumCycleStatus.UP_to_UE4);
      SetThreadStatusGridView(grid_ThStatus_ST1_STC, enumCycleStatus.Stage1_Clean);
      SetThreadStatusGridView(grid_ThStatus_ST2_STC, enumCycleStatus.Stage2_Clean);
      SetThreadStatusGridView(grid_ThStatus_ST1_PBC, enumCycleStatus.Stage1_Probe_Clean);
      SetThreadStatusGridView(grid_ThStatus_ST2_PBC, enumCycleStatus.Stage2_Probe_Clean);
    
      txtIndex_LE.Text = CVo.iPCBIndex_LE.ToString();
      txtIndex_LP.Text = CVo.iPCBIndex_Loader.ToString();
      txtIndex_ST1.Text = CVo.iPCBIndex_Stage1.ToString();
      txtIndex_ST2.Text = CVo.iPCBIndex_Stage2.ToString();
      txtIndex_UP.Text = CVo.iPCBIndex_Unloader.ToString();
      txtIndex_UE1.Text = CVo.iPCBIndex_UE1.ToString();
      txtIndex_UE2.Text = CVo.iPCBIndex_UE2.ToString();
      txtIndex_UE3.Text = CVo.iPCBIndex_UE3.ToString();
      txtIndex_UE4.Text = CVo.iPCBIndex_UE4.ToString();

      btnLotEnd.BackColor = CVo.bPCB_Empty ? Color.Lime : Color.Red;
    }

    private void SetThreadStatusGridView(System.Windows.Forms.DataGridView grid, enumCycleStatus name)
    {
      grid.RowCount = 5;
      grid.Columns[0].HeaderText = name.ToString();
      grid.Rows[0].Cells[0].Value = "ExStart";
      grid.Rows[1].Cells[0].Value = "InStart";
      grid.Rows[2].Cells[0].Value = "Moving";
      grid.Rows[3].Cells[0].Value = "Comp";
      grid.Rows[4].Cells[0].Value = "Err";

      grid.Rows[0].Cells[0].Style.BackColor = CVo.sCycleStatus[(int)name].bExtrenStart ? Color.Lime : Color.White;
      grid.Rows[1].Cells[0].Style.BackColor = CVo.sCycleStatus[(int)name].bCycleStart ? Color.Lime : Color.White;
      grid.Rows[2].Cells[0].Style.BackColor = CVo.sCycleStatus[(int)name].bMoving ? Color.Lime : Color.White;
      grid.Rows[3].Cells[0].Style.BackColor = CVo.sCycleStatus[(int)name].bComplete ? Color.Lime : Color.White;
      grid.Rows[4].Cells[0].Style.BackColor = CVo.sCycleStatus[(int)name].bError ? Color.Lime : Color.White;
    }

    private void btnLotEnd_Click(object sender, EventArgs e)
    {
      CVo.bPCB_Empty = !CVo.bPCB_Empty;
    }
  }
}
