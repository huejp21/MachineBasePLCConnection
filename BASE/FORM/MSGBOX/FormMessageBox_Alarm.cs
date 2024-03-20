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
  public partial class FormMessageBox_Alarm : Form
  {
    public delegate void del_Show_Warn(enumAlarmWarn eAlarm);
    private delegate void del_tmr_Alarm_Tick(object sender, EventArgs e);

    public FormMessageBox_Alarm()
    {
      InitializeComponent();
    }



    public void Show_Warn(enumAlarmWarn eAlarm)
    {
      if (this.InvokeRequired)
      {
        del_Show_Warn Show_Warn_ = new del_Show_Warn(Show_Warn);
        object obj = this.Invoke(Show_Warn_, new object[] { eAlarm });
        //return;
      }
      if (eAlarm == enumAlarmWarn.LotEnd)
      {
        CVo.bLotUserConfirmWait = true;
        CIoVo.Set_WB_Output(enumBitOutput.B1106_TowerLampBuzzer_End, true);
      }
      int iIndex = (int)eAlarm;
      CMaster.cLogMgr.Add_Alarm_Warn(eAlarm, CVo.arrAlarmWarnName[iIndex], CVo.eMachineStatus); // 로그 기록

      CForm.Check_Display(this);
      lblMessageBoxAlarmTitle.Text = string.Format("[{0}]{1}", iIndex.ToString(), CVo.arrAlarmWarnName[iIndex]);
      lblMessageBoxAlarmInfo.Text = CVo.arrAlarmWarnInfo[iIndex];
      this.TopMost = true;
      this.Show();


    }

    private void btnMessageBoxAlarmClose_Click(object sender, EventArgs e)
    {
      CVo.bLotUserConfirmWait = false;
      this.Hide();
    }

    private void tmr_Alarm_Tick(object sender, EventArgs e)
    {
      if (this.InvokeRequired)
      {
        del_tmr_Alarm_Tick tmr_Alarm_Tick_ = new del_tmr_Alarm_Tick(tmr_Alarm_Tick);
        object obj = this.Invoke(tmr_Alarm_Tick_, new object[] { sender, e });
        //return;
      }
      tmr_Alarm.Enabled = false;
      if (this.Visible)
      {
        //this.TopMost = true;
      }
      tmr_Alarm.Enabled = true;

    }
  }
}
