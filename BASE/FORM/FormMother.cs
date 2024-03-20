using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BASE.FORM;
using BASE.VO;
using BASE.MASTER;
using BASE.MODULE.MOTION;

namespace BASE
{
  public partial class FormMother : Form
  {
    // size: 1274, 989
    // title: 1274, 75
    // main: 1074, 814
    // control: 200, 814
    // navi: 1274, 100
    public FormMother()
    {
      InitializeComponent();
      Init_();
    }

    private void Init_()
    {
      bool bResult = true;

      // Initialize For Program
      CForm.frmMother = this; // Add Parents Form
      CForm.frmStartup.Show_();
      CForm.Init_(); // Initialize Form
      CVo.Init_(); // Initialize Value Object

      // Initialize For Extern Static Value
      CIoVo.Init_Io(); // IO
      bResult = CMotionVo.Init_Status(); // 모션 초기화 

      // Load All Parameter
      bool bResult1 = CVo.Load_User();
      bool bResult2 = CVo.Load_Parameter_System();
      bool bResult3 = CVo.Load_Parameter_Recipe();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      CVo.eCurrentLanguage = (enumLanguageType)CVo.cParaSys.iLanguage;
      bool bResult4 = CVo.Load_AlarmList(CVo.eCurrentLanguage); // 
      bool bResult5 = CVo.Load_MsgList(CVo.eCurrentLanguage); // 메세지 목록 로드
      bool bResult6 = CForm.Change_Language(CVo.eCurrentLanguage); // 언어 변환
      bool bResult7 = CVo.Delete_Old_Log(cSys.iDeleteLogPeriod); // 로그 삭제
      bResult = bResult1 && bResult2 && bResult3 && bResult4 && bResult5 && bResult6;

      // Initialize Harware Connection
      bResult = CForm.Init_Hardware(); // Init Hardware

      //Thread Start Check
      CMaster.Check_Thread();
      CThreadMaster.Check_Thread();
      CMotionVo.StartMonitor();
      CVo.Reset_PCBData();
      CForm.frmStartup.Hide_();
    }

    private void FRM_MOTHER_Load(object sender, EventArgs e)
    {

    }

    private void timer_mother_Tick(object sender, EventArgs e)
    {
      timer_mother.Enabled = false;
      try
      {
        if (CVo.bOnAlarmStop
        /* && CVo.bOnAlarmStopOnece == false*/)
        {
          CVo.bOnAlarmStop = false;
          //CVo.bOnAlarmStopOnece = true;
          switch (CVo.eMachineStatus)
          {
            case enumMachineStatus.Auto:
              CVo.eMachineStatus = enumMachineStatus.ErrorAuto;
              break;
            case enumMachineStatus.Cycle:
            case enumMachineStatus.None:
            case enumMachineStatus.Initial:
            case enumMachineStatus.Idle:
            case enumMachineStatus.Stop:
            case enumMachineStatus.ErrorAuto:
            case enumMachineStatus.Error:
            default:
              CVo.eMachineStatus = enumMachineStatus.Error;
              break;
          }
          CForm.frmMessageAlarmStop.Show_Stop(CVo.eAlarmStop);
        }
        if (CVo.bOnAlarmWarn)
        {
          CVo.bOnAlarmWarn = false;
          CForm.frmMessageAlarm.Show_Warn(CVo.eAlarmWarn);
        }

      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
      }

      bool bRunning = false;
      for (int i = 0; i < Enum.GetNames(typeof(enumFlagRunning)).Length; i++)
			{
        if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
        {
          bRunning = true;
        }
      }
      if (bRunning || CVo.Check_MachineStatus())
      {
        if (CIoVo.Get_WW_Select_Section(enumWW_Select_Section.W1420_Setup_Mode) == 0)
        {
          CIoVo.Set_WB_Output(enumBitOutput.B1108_DoorLockSignal1, true);
          CIoVo.Set_WB_Output(enumBitOutput.B1109_DoorLockSignal2, true);
          CIoVo.Set_WB_Output(enumBitOutput.B110A_DoorLockSignal3, true);
          CIoVo.Set_WB_Output(enumBitOutput.B110B_DoorLockSignal4, true);
          CIoVo.Set_WB_Output(enumBitOutput.B110C_DoorLockSignal5, true);
          CIoVo.Set_WB_Output(enumBitOutput.B110D_DoorLockSignal6, true);
        }
        else
        {
          CIoVo.Set_WB_Output(enumBitOutput.B1108_DoorLockSignal1, false);
          CIoVo.Set_WB_Output(enumBitOutput.B1109_DoorLockSignal2, false);
          CIoVo.Set_WB_Output(enumBitOutput.B110A_DoorLockSignal3, false);
          CIoVo.Set_WB_Output(enumBitOutput.B110B_DoorLockSignal4, false);
          CIoVo.Set_WB_Output(enumBitOutput.B110C_DoorLockSignal5, false);
          CIoVo.Set_WB_Output(enumBitOutput.B110D_DoorLockSignal6, false);
        }
        CIoVo.Set_WB_OutFlag(enumFlagOut.B10A4_PC_Auto_Running_Signal, true);
      }
      else
      {
        CIoVo.Set_WB_Output(enumBitOutput.B1108_DoorLockSignal1, false);
        CIoVo.Set_WB_Output(enumBitOutput.B1109_DoorLockSignal2, false);
        CIoVo.Set_WB_Output(enumBitOutput.B110A_DoorLockSignal3, false);
        CIoVo.Set_WB_Output(enumBitOutput.B110B_DoorLockSignal4, false);
        CIoVo.Set_WB_Output(enumBitOutput.B110C_DoorLockSignal5, false);
        CIoVo.Set_WB_Output(enumBitOutput.B110D_DoorLockSignal6, false);
        CIoVo.Set_WB_OutFlag(enumFlagOut.B10A4_PC_Auto_Running_Signal, false);
      }
      timer_mother.Enabled = true;
    }
  }
}
