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
using BASE.MODULE.PLC;
using BASE.MODULE.MOTION;

namespace BASE.FORM.SETUP.IO
{
  public partial class FormPLCView : Form
  {
    List<string> listNameInput = new List<string>();
    List<string> listNameOutput = new List<string>();
    List<string> listNameWIn = new List<string>();
    List<string> listNameWOut = new List<string>();


    public FormPLCView()
    {
      InitializeComponent();
    }

    private void FormPLCData_Shown(object sender, EventArgs e)
    {
      tmr_PLCData.Enabled = true;
    }

    private void FormPLCData_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        tmr_PLCData.Enabled = true;
      }
    }

    private void Load_Io()
    {
      List<bool> listInput = new List<bool>();
      listNameInput.Clear();
      listInput.Clear();

      int iCount_Input 
        = Enum.GetNames(typeof(enumBitInput)).Length
        + Enum.GetNames(typeof(enumFlagRunning)).Length
        + Enum.GetNames(typeof(enumFlagComplete)).Length
        + Enum.GetNames(typeof(enumError)).Length; ;
      int iNumber = 0x2000;
      for (int i = 0; i < Enum.GetNames(typeof(enumBitInput)).Length; i++)
      {
        listInput.Add(CIoVo.GetInput_Org((enumBitInput)i).bOriginSignal);
        listNameInput.Add(iNumber.ToString("X4"));
        iNumber++;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumFlagRunning)).Length; i++)
      {
        listInput.Add(CIoVo.Get_RB_RunningFlag((enumFlagRunning)i));
        listNameInput.Add(iNumber.ToString("X4"));
        iNumber++;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumFlagComplete)).Length; i++)
      {
        listInput.Add(CIoVo.Get_RB_CompleteFlag((enumFlagComplete)i));
        listNameInput.Add(iNumber.ToString("X4"));
        iNumber++;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumError)).Length; i++)
      {
        listInput.Add(CIoVo.Get_RB_Error((enumError)i));
        listNameInput.Add(iNumber.ToString("X4"));
        iNumber++;
      }

      List<bool> listOutput = new List<bool>();
      listNameOutput.Clear();
      listOutput.Clear();
      int iCount_Output
        = Enum.GetNames(typeof(enumFlagOut)).Length
        + Enum.GetNames(typeof(enumBitOutput)).Length;
      iNumber = 0x1000;
      for (int i = 0; i < Enum.GetNames(typeof(enumFlagOut)).Length; i++)
      {
        listOutput.Add(CIoVo.Get_WB_OutFlag((enumFlagOut)i));
        listNameOutput.Add(iNumber.ToString("X4"));
        iNumber++;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumBitOutput)).Length; i++)
      {
        listOutput.Add(CIoVo.Get_WB_Output((enumBitOutput)i));
        listNameOutput.Add(iNumber.ToString("X4"));
        iNumber++;
      }

      List<int> listWIn = new List<int>();
      listNameWIn.Clear();
      listWIn.Clear();
      int iCount_WIn
        = Enum.GetNames(typeof(enumWR_AD_Data)).Length
        + Enum.GetNames(typeof(enumWR_CurPos)).Length
        + Enum.GetNames(typeof(enumWR_CurSpd)).Length
        + Enum.GetNames(typeof(enumWR_AlarmCode)).Length
        + Enum.GetNames(typeof(enumWR_Counter)).Length
        + Enum.GetNames(typeof(enumWR_Etc)).Length;
      iNumber = 0x1500;
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_AD_Data)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_AD((enumWR_AD_Data)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber+=2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_CurPos)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_CurPos((enumWR_CurPos)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber+=2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_CurSpd)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_CurSpd((enumWR_CurSpd)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_AlarmCode)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_AlarmCode((enumWR_AlarmCode)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_Counter)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_Counter((enumWR_Counter)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWR_Etc)).Length; i++)
      {
        listWIn.Add(CIoVo.Get_RW_Etc((enumWR_Etc)i));
        listNameWIn.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }

      List<int> listWOut = new List<int>();
      listNameWOut.Clear();
      listWOut.Clear();
      int iCount_WOut
        = Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length
        + Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length
        + Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length
        + Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length
        + Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length
        + Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length
        + Enum.GetNames(typeof(enumWW_LE_to_LP)).Length
        + Enum.GetNames(typeof(enumWW_LP_to_AL)).Length
        + Enum.GetNames(typeof(enumWW_Align)).Length
        + Enum.GetNames(typeof(enumWW_AL_to_LP)).Length
        + Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length
        + Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length
        + Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length
        + Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length
        + Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length
        + Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length
        + Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length
        + Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length
        + Enum.GetNames(typeof(enumWW_UL_to_UE)).Length
        + Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length
        + Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length
        + Enum.GetNames(typeof(enumWW_Etc)).Length
        + Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length
        + Enum.GetNames(typeof(enumWW_Select_Section)).Length;
      iNumber = 0x1000;
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Teaching_Jog((enumWW_Teaching_Jog_Data)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_LE_Align_Ready((enumWW_LE_Align_Ready)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_UE1_Align_Ready((enumWW_UE1_Align_Ready)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_UE2_Align_Ready((enumWW_UE2_Align_Ready)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_UE3_Align_Ready((enumWW_UE3_Align_Ready)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_UE4_Align_Ready((enumWW_UE4_Align_Ready)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_LE_to_LP)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_LE_to_LP((enumWW_LE_to_LP)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_LP_to_AL)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_LP_to_AL((enumWW_LP_to_AL)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Align)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Align((enumWW_Align)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_AL_to_LP)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_AL_to_LP((enumWW_AL_to_LP)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_LP_to_Stage1((enumWW_LP_to_Stage1)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_LP_to_Stage2((enumWW_LP_to_Stage2)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage1_Zero((enumWW_Stage1_Zero)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage2_Zero((enumWW_Stage2_Zero)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage1_Measure((enumWW_Stage1_Measure)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage2_Measure((enumWW_Stage2_Measure)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage1_to_UL((enumWW_Stage1_to_UL)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage2_to_UL((enumWW_Stage2_to_UL)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_UL_to_UE)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_UL_to_UE((enumWW_UL_to_UE)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage1_Clean((enumWW_Stage1_Clean)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Stage2_Clean((enumWW_Stage2_Clean)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Etc)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Etc((enumWW_Etc)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_ErrorValue_Allow((enumWW_ErrorValue_Allow_Data)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumWW_Select_Section)).Length; i++)
      {
        listWOut.Add(CIoVo.Get_WW_Select_Section((enumWW_Select_Section)i));
        listNameWOut.Add(iNumber.ToString("X4"));
        iNumber += 2;
      }


      gridIoInput.RowCount = listNameInput.Count;
      for (int i = 0; i < listNameInput.Count; i++)
      {
        gridIoInput.Rows[i].Cells[0].Value = "B" + listNameInput[i];
        gridIoInput.Rows[i].Cells[0].Style.BackColor = listInput[i] ? Color.Lime : Color.White;
      }

      gridIoOutput.RowCount = listNameOutput.Count;
      for (int i = 0; i < listNameOutput.Count; i++)
      {
        gridIoOutput.Rows[i].Cells[0].Value = "B" + listNameOutput[i];
        gridIoOutput.Rows[i].Cells[0].Style.BackColor = listOutput[i] ? Color.Red : Color.White;
      }

      gridDataInput.RowCount = listNameWIn.Count;
      for (int i = 0; i < listNameWIn.Count; i++)
      {
        gridDataInput.Rows[i].Cells[0].Value = "W" + listNameWIn[i];
        gridDataInput.Rows[i].Cells[1].Value = listWIn[i].ToString();
      }

      gridDataOutput.RowCount = listNameWOut.Count;
      for (int i = 0; i < listNameWOut.Count; i++)
      {
        gridDataOutput.Rows[i].Cells[0].Value = "W" + listNameWOut[i];
        gridDataOutput.Rows[i].Cells[1].Value = listWOut[i].ToString();
      }


    }

    private void tmr_PLCData_Tick(object sender, EventArgs e)
    {
      tmr_PLCData.Enabled = false;
      Load_Io();
      tmr_PLCData.Enabled = true;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      tmr_PLCData.Enabled = false;
      this.Hide();
    }

    public void Show_()
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Show();
    }

    private void gridIoOutput_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      System.Windows.Forms.DataGridView grid = (System.Windows.Forms.DataGridView)sender;
      System.Windows.Forms.DataGridViewCell cell = grid.CurrentCell;
      int nRow = cell.RowIndex;

      CIoVo.Set_Address_Bit("B" + listNameOutput[nRow], CIoVo.Get_Address_Bit("B" + listNameOutput[nRow]) == false);
    }

    private void gridDataOutput_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      System.Windows.Forms.DataGridView grid = (System.Windows.Forms.DataGridView)sender;
      System.Windows.Forms.DataGridViewCell cell = grid.CurrentCell;
      int nRow = cell.RowIndex;

      //CIoVo.Set_Address_Bit(listNameOutput[nRow], CIoVo.Get_Address_Bit(listNameOutput[nRow]) == false);
    }

  }
}
