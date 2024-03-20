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
  public partial class FormIoControl : Form
  {
    public FormIoControl()
    {
      InitializeComponent();
    }

    private void btnIoClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    public void Show_()
    {
      this.TopMost = true;
      CForm.Check_Display(this);
      this.Show();
    }

    private void Load_IO()
    {
      if (CIoVo.Load_IoList() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LoginNoExistUserDBData);
      }
      gridIoInput.RowCount = Enum.GetNames(typeof(enumBitInput)).Length;
      for (int i = 0; i < gridIoInput.RowCount; i++)
      {
        structIo sIn = CIoVo.GetInput_Org((enumBitInput)i);
        gridIoInput.Rows[i].Cells[0].Value = i.ToString();
        gridIoInput.Rows[i].Cells[1].Value = ((enumBitInput)i).ToString();
        gridIoInput.Rows[i].Cells[2].Value = sIn.strName;
        gridIoInput.Rows[i].Cells[3].Value = sIn.bContactSetting ? "B" : "A";
      }

      gridIoOutput.RowCount = Enum.GetNames(typeof(enumBitOutput)).Length;
      for (int i = 0; i < gridIoOutput.RowCount; i++)
      {
        structIo sOut = CIoVo.GetOutput_Org((enumBitOutput)i);
        gridIoOutput.Rows[i].Cells[0].Value = i.ToString();
        gridIoOutput.Rows[i].Cells[1].Value = ((enumBitOutput)i).ToString();
        gridIoOutput.Rows[i].Cells[2].Value = sOut.strName;
        gridIoOutput.Rows[i].Cells[3].Value = sOut.bContactSetting ? "B" : "A";
      }
    }

    private void FormIoControl_Shown(object sender, EventArgs e)
    {
      Load_IO();
    }

    private void FormIoControl_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible == true)
      {
        Load_IO();
      }
    }

    private void btnIoSave_Click(object sender, EventArgs e)
    {
      switch (CVo.eCurrentUserLevel)
      {
        case enumUserLevel.Maintenance:
        case enumUserLevel.Administator:
        case enumUserLevel.Developer:
          break;
        case enumUserLevel.Operator:
        default:
          return;
      }
      bool bContact = false;
      for (int i = 0; i < gridIoInput.RowCount; i++)
      {
        bContact = false;
        structIo sIn = CIoVo.GetInput_Org((enumBitInput)i);
        sIn.strName = gridIoInput.Rows[i].Cells[2].Value.ToString();
        if (gridIoInput.Rows[i].Cells[3].Value.ToString().CompareTo("A") == 0)
        {
          bContact = false;
        }
        else if (gridIoInput.Rows[i].Cells[3].Value.ToString().CompareTo("B") == 0)
        {
          bContact = true;
        }
        sIn.bContactSetting = bContact;
        CIoVo.SetInput_Org((enumBitInput)i, sIn);
      }

      for (int i = 0; i < gridIoOutput.RowCount; i++)
      {
        bContact = false;
        structIo sOut = CIoVo.GetOutput_Org((enumBitOutput)i);
        sOut.strName = gridIoOutput.Rows[i].Cells[2].Value.ToString();
        if (gridIoOutput.Rows[i].Cells[3].Value.ToString().CompareTo("A") == 0)
        {
          bContact = false;
        }
        else if (gridIoOutput.Rows[i].Cells[3].Value.ToString().CompareTo("B") == 0)
        {
          bContact = true;
        }
        sOut.bContactSetting = bContact;
        CIoVo.SetOutput_Org((enumBitOutput)i, sOut);
      }

      CIoVo.Delete_IoList();
      CIoVo.Create_IoList();
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void gridIoInput_DoubleClick(object sender, EventArgs e)
    {
      switch (CVo.eCurrentUserLevel)
      {
        case enumUserLevel.Maintenance:
        case enumUserLevel.Administator:
        case enumUserLevel.Developer:
          break;
        case enumUserLevel.Operator:
        default:
          return;
      }
      System.Windows.Forms.DataGridView grid = (System.Windows.Forms.DataGridView)sender;
      System.Windows.Forms.DataGridViewCell cell = grid.CurrentCell;
      string strValue = cell.Value.ToString();
      if (cell.ColumnIndex == 3)
      {
        if (strValue.CompareTo("A") == 0)
        {
          cell.Value = "B";
        }
        else if (strValue.CompareTo("B") == 0)
        {
          cell.Value = "A";
        }
      }
    }

    private void gridIoOutput_DoubleClick(object sender, EventArgs e)
    {
      switch (CVo.eCurrentUserLevel)
      {
        case enumUserLevel.Maintenance:
        case enumUserLevel.Administator:
        case enumUserLevel.Developer:
          break;
        case enumUserLevel.Operator:
        default:
          return;
      }
      System.Windows.Forms.DataGridView grid = (System.Windows.Forms.DataGridView)sender;
      System.Windows.Forms.DataGridViewCell cell = grid.CurrentCell;
      string strValue = cell.Value.ToString();
      if (cell.ColumnIndex == 3)
      {
        if (strValue.CompareTo("A") == 0)
        {
          cell.Value = "B";
        }
        else if (strValue.CompareTo("B") == 0)
        {
          cell.Value = "A";
        }
      }
    }

    private void tmrIo_Tick(object sender, EventArgs e)
    {
      tmrIo.Enabled = false;
      for (int i = 0; i < Enum.GetNames(typeof(enumBitInput)).Length; i++)
      {
        gridIoInput.Rows[i].Cells[1].Style.BackColor = CIoVo.GetInput_Org((enumBitInput)i).bOriginSignal ? Color.GreenYellow : Color.LightGray;
        gridIoInput.Rows[i].Cells[2].Style.BackColor = CIoVo.GetInput_Org((enumBitInput)i).bOriginSignal ? Color.GreenYellow : Color.LightGray;
        if (gridIoInput.Rows[i].Cells[3].Value.ToString().CompareTo("A") == 0)
        {
          gridIoInput.Rows[i].Cells[3].Style.BackColor = Color.LightPink;
        }
        else if (gridIoInput.Rows[i].Cells[3].Value.ToString().CompareTo("B") == 0)
        {
          gridIoInput.Rows[i].Cells[3].Style.BackColor = Color.LightBlue;
        }
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumBitOutput)).Length; i++)
      {
        gridIoOutput.Rows[i].Cells[1].Style.BackColor = CIoVo.Get_WB_Output((enumBitOutput)i) ? Color.Red : Color.LightGray;
        gridIoOutput.Rows[i].Cells[2].Style.BackColor = CIoVo.Get_WB_Output((enumBitOutput)i) ? Color.Red : Color.LightGray;
        if (gridIoOutput.Rows[i].Cells[3].Value.ToString().CompareTo("A") == 0)
        {
          gridIoOutput.Rows[i].Cells[3].Style.BackColor = Color.LightPink;
        }
        else if (gridIoOutput.Rows[i].Cells[3].Value.ToString().CompareTo("B") == 0)
        {
          gridIoOutput.Rows[i].Cells[3].Style.BackColor = Color.LightBlue;
        }
      }
      tmrIo.Enabled = true;
    }

    private void FormIoControl_Load(object sender, EventArgs e)
    {
      tmrIo.Enabled = true;
    }

    private void gridIoInput_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void gridIoOutput_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      switch (CVo.eCurrentUserLevel)
      {
        case enumUserLevel.Maintenance:
        case enumUserLevel.Administator:
        case enumUserLevel.Developer:
          break;
        case enumUserLevel.Operator:
        default:
          return;
      }
      System.Windows.Forms.DataGridView grid = (System.Windows.Forms.DataGridView)sender;
      System.Windows.Forms.DataGridViewCell cell = grid.CurrentCell;
      int nRow = cell.RowIndex;
      bool bOn = CIoVo.Get_WB_Output((enumBitOutput)nRow);
      if (cell.ColumnIndex == 1 || cell.ColumnIndex == 2)
      {
        CIoVo.Set_WB_Output((enumBitOutput)nRow, !bOn);
      }
    }

  }
}
