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
  public partial class FormMessageBox_AlarmStop : Form
  {

      public enumAlarmStop eCurrentAlarm = enumAlarmStop.NONE;
    public delegate void del_Show_Stop(enumAlarmStop eAlarm);

    public FormMessageBox_AlarmStop()
    {
      InitializeComponent();
    }

    public void Show_Stop(enumAlarmStop eAlarm)
    {
      if (this.InvokeRequired)
      {
        del_Show_Stop Show_Stop_ = new del_Show_Stop(Show_Stop);
        object obj = this.Invoke(Show_Stop_, new object[] { eAlarm });
        //return;
      }
      int iIndex = (int)eAlarm;

      CMaster.cLogMgr.Add_Alarm_Stop(eAlarm, CVo.arrAlarmStopName[iIndex], CVo.eMachineStatus); // 로그 기록
      CForm.Check_Display(this);
      lblMessageBoxAlarmStopTitle.Text = string.Format("[{0}]{1}", iIndex.ToString(), CVo.arrAlarmStopName[iIndex]);
      lblMessageBoxAlarmStopInfo.Text = CVo.arrAlarmStopInfo[iIndex];

      eCurrentAlarm = eAlarm;
      this.TopMost = true;
      this.Show();
    }

    private void tmr_AlarmStop_Tick(object sender, EventArgs e)
    {
      tmr_AlarmStop.Enabled = false;
      if (this.Visible)
      {
        //this.TopMost = true;
      }
      if (listMessageBoxAlarmStopCurrentAlarm.Items.Count != CVo.listAlarmStopName.Count)
      {
        listMessageBoxAlarmStopCurrentAlarm.Items.Clear();
        for (int i = 0; i < CVo.listAlarmStopName.Count; i++)
        {
          string strData = string.Format("[{0}] {1}", CVo.listAlarmStopTime[i], CVo.arrAlarmStopName[(int)CVo.listAlarmStopName[i]]);
          listMessageBoxAlarmStopCurrentAlarm.Items.Add(strData);
        }
      }
      //for (int i = 0; i < CVo.listAlarmStopName.Count; i++)
      //{
      //    if (eCurrentAlarm == CVo.listAlarmStopName[i])
      //    {
      //        if (listMessageBoxAlarmStopCurrentAlarm.SelectedIndex != i)
      //        {
                  
      //        }
      //        listMessageBoxAlarmStopCurrentAlarm.SelectedIndex = i;
      //        break;
      //    }
      //}
      tmr_AlarmStop.Enabled = true;
    }

    //private void btnMessageBoxAlarmStopClose_Click(object sender, EventArgs e)
    //{
    //  //CVo.bOnAlarmStopOnece = false;
    //  this.Hide();
    //}

    private void listMessageBoxAlarmStopCurrentAlarm_SelectedIndexChanged(object sender, EventArgs e)
    {
      int iSel = listMessageBoxAlarmStopCurrentAlarm.SelectedIndex;
      if (iSel >= CVo.listAlarmStopName.Count || iSel < 0)
      {
        return;
      }

      int iIndex = (int)CVo.listAlarmStopName[iSel];
      lblMessageBoxAlarmStopTitle.Text = string.Format("[{0}]{1}", iIndex.ToString(), CVo.arrAlarmStopName[iIndex]);
      lblMessageBoxAlarmStopInfo.Text = CVo.arrAlarmStopInfo[iIndex];
    }

    private void btnMessageBoxAlarmStopClose_MouseDown(object sender, MouseEventArgs e)
    {
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A2_PC_Error_Reset_Signal, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1101_ResetSwitchLED_Blue, true);
      CVo.eVirtualBit = enumVirtualBit.Reset;
    }

    private void btnMessageBoxAlarmStopClose_MouseUp(object sender, MouseEventArgs e)
    {
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A2_PC_Error_Reset_Signal, false);
      CIoVo.Set_WB_Output(enumBitOutput.B1101_ResetSwitchLED_Blue, false);
      this.Hide();
    }

    private void btnMessageBoxAlarmStopBuzzOff_Click(object sender, EventArgs e)
    {
      CVo.bBuzzOff = true;
      CIoVo.Set_WB_OutFlag(enumFlagOut.B10A7_PC_Buzz_Stop_Signal, true);
      CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, false);
      CIoVo.Set_WB_Output(enumBitOutput.B1105_TowerLampBuzzer_Error, false);
    }
  }
}
