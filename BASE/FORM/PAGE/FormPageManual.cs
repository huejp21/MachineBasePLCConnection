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
using BASE.MODULE.MOTION;
using BASE.MASTER;

namespace BASE.FORM.PAGE
{
  public partial class FormPageManual : Form
  {
    public FormPageManual()
    {
      InitializeComponent();
    }

    private bool Check_MachineStatus()
    {
      switch (CVo.eMachineStatus)
      {
        case enumMachineStatus.None:
        case enumMachineStatus.Idle:
        case enumMachineStatus.Stop:
          return true;
        case enumMachineStatus.Cycle:
        case enumMachineStatus.Auto:
        case enumMachineStatus.Initial:
        case enumMachineStatus.ErrorAuto:
        case enumMachineStatus.Error:
        default:
          return false;
      }
    }

    private bool Check_MotorStatus(enumMotorName name)
    {
      if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running)
       || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running))
      {
        return false;
      }

      if (CMotionVo.GetMotorStatus(name).bBusy)
      {
        return false;
      }

      return true;
    }

    private bool Check_ManualRun()
    {
      for (int i = 0; i < Enum.GetNames(typeof(enumFlagRunning)).Length; i++)
      {
        if (CIoVo.Get_RB_RunningFlag((enumFlagRunning)i))
        {
          return false;
        }
      }

      return true;
    }

    private void btnGo_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      if (Check_MachineStatus() == false)
      {
        return;
      }
      CVo.bManualRun = true;
      CVo.eMachineStatus = enumMachineStatus.Cycle;

      switch (ctrl.Name)
      {
        case "btnGo_LE_ScanStart":
          if (Check_MotorStatus(enumMotorName.LE) == false) { return; }
          if (sMotor[(int)enumMotorName.LE].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(cSys.dLE_ScanStart_Pos * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(cSys.dLE_Normal_Spd * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case "btnGo_LE_ScanEnd":
          if (Check_MotorStatus(enumMotorName.LE) == false) { return; }
          if (sMotor[(int)enumMotorName.LE].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(cSys.dLE_ScanStart_Pos * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(cSys.dLE_Normal_Spd * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case "btnGo_LE_CassetteWait":
          if (Check_MotorStatus(enumMotorName.LE) == false) { return; }
          if (sMotor[(int)enumMotorName.LE].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(cSys.dLE_Cassette_Wait_Pos * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(cSys.dLE_Normal_Spd * sMotor[(int)enumMotorName.LE].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case "btnGo_LP_LEPos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_LE_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_LP_AlignPos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_AL_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_LP_AlignUnloadingPos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_AL_Unloading_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_LP_Stage1Pos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_Stage1_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_LP_Stage2Pos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_Stage2_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_ALX_LoadingPos":
          if (Check_MotorStatus(enumMotorName.ALX) == false) { return; }
          if (sMotor[(int)enumMotorName.ALX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(cSys.dALX_Loading_Pos * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(cSys.dALX_Normal_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case "btnGo_ALX_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.ALX) == false) { return; }
          if (sMotor[(int)enumMotorName.ALX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(cSys.dALX_Unloading_Pos * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(cSys.dALX_Normal_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case "btnGo_ALX_AlignStartPos":
          if (Check_MotorStatus(enumMotorName.ALX) == false) { return; }
          if (sMotor[(int)enumMotorName.ALX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(cSys.dALX_AlignStart_Pos * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(cSys.dALX_Normal_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case "btnGo_ALX_AlignPos":
          if (Check_MotorStatus(enumMotorName.ALX) == false) { return; }
          if (sMotor[(int)enumMotorName.ALX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(cRcp.dPCB_Align_ALX_Pos * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(cSys.dALX_Normal_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102C_ALX_Teaching_Start, true);
          break;
        case "btnGo_ALY_LoadingPos":
          if (Check_MotorStatus(enumMotorName.ALY) == false) { return; }
          if (sMotor[(int)enumMotorName.ALX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(cSys.dALY_Loading_Pos * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(cSys.dALY_Normal_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case "btnGo_ALY_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.ALY) == false) { return; }
          if (sMotor[(int)enumMotorName.ALY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(cSys.dALY_Unloading_Pos * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(cSys.dALY_Normal_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case "btnGo_ALY_AlignStartPos":
         if (Check_MotorStatus(enumMotorName.ALY) == false) { return; }
         if (sMotor[(int)enumMotorName.ALY].bHomeComplete == false) { return; }
         CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(cSys.dALY_AlignStart_Pos * sMotor[(int)enumMotorName.ALY].dLimitScale));
         CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(cSys.dALY_Normal_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case "btnGo_ALY_AlignPos":
          if (Check_MotorStatus(enumMotorName.ALY) == false) { return; }
          if (sMotor[(int)enumMotorName.ALY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(cRcp.dPCB_Align_ALY_Pos * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(cSys.dALY_Normal_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102D_ALY_Teaching_Start, true);
          break;
        case "btnGo_X1_LoadingPos":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_Loading_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case "btnGo_X1_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_Unloading_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case "btnGo_X1_CenterPos":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_Center_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case "btnGo_X1_StageCleanStart":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_CleanStart_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case "btnGo_X1_StageCleanEnd":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_CleanEnd_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1020_LE_Teaching_Start, true);
          break;
        case "btnGo_X1_ProbeClean":
          if (Check_MotorStatus(enumMotorName.X1) == false) { return; }
          if (sMotor[(int)enumMotorName.X1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(cSys.dX1_CleanProbe_Pos * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102E_X1_Teaching_Start, true);
          break;
        case "btnGo_X2_LoadingPos":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_Loading_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_X2_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_Unloading_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_X2_CenterPos":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_Center_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_X2_StageCleanStart":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_CleanStart_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_X2_StageCleanEnd":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_CleanEnd_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_X2_ProbeClean":
          if (Check_MotorStatus(enumMotorName.X2) == false) { return; }
          if (sMotor[(int)enumMotorName.X2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(cSys.dX2_CleanProbe_Pos * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102F_X2_Teaching_Start, true);
          break;
        case "btnGo_Z1_LoadingPos":
          if (Check_MotorStatus(enumMotorName.Z1) == false) { return; }
          if (sMotor[(int)enumMotorName.Z1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Loading_Pos * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case "btnGo_Z1_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.Z1) == false) { return; }
          if (sMotor[(int)enumMotorName.Z1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Unloading_Pos * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case "btnGo_Z1_CenterPos":
          if (Check_MotorStatus(enumMotorName.Z1) == false) { return; }
          if (sMotor[(int)enumMotorName.Z1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Center_Pos * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case "btnGo_Z2_LoadingPos":
          if (Check_MotorStatus(enumMotorName.Z2) == false) { return; }
          if (sMotor[(int)enumMotorName.Z2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Loading_Pos * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case "btnGo_Z2_UnloadingPos":
          if (Check_MotorStatus(enumMotorName.Z2) == false) { return; }
          if (sMotor[(int)enumMotorName.Z2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Unloading_Pos * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case "btnGo_Z2_CenterPos":
          if (Check_MotorStatus(enumMotorName.Z2) == false) { return; }
          if (sMotor[(int)enumMotorName.Z2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Center_Pos * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case "btnGo_UPX_Stage1Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_Stage1_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPX_Stage2Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_Stage2_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPX_UE1Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_UE1_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPX_UE2Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_UE2_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPX_UE3Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_UE3_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPX_UE4Pos":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_UE4_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPY_Stage1Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_Stage1_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_UPY_Stage2Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_Stage2_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_UPY_UE1Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_UE1_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_UPY_UE2Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_UE2_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_UPY_UE3Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_UE3_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_UPY_UE4Pos":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_UE4_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_PR1_CenterPos":
          if (Check_MotorStatus(enumMotorName.PR1) == false) { return; }
          if (sMotor[(int)enumMotorName.PR1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1042_PR1_Teaching_Pos, (int)(cSys.dPR1_Center_Pos * sMotor[(int)enumMotorName.PR1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1040_PR1_Teaching_Spd, (int)(cSys.dPR1_Normal_Spd * sMotor[(int)enumMotorName.PR1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1030_PR1_Teaching_Start, true);
          break;
        case "btnGo_PR1_CleanPos":
          if (Check_MotorStatus(enumMotorName.PR1) == false) { return; }
          if (sMotor[(int)enumMotorName.PR1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1042_PR1_Teaching_Pos, (int)(cSys.dPR1_Clean_Pos * sMotor[(int)enumMotorName.PR1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1040_PR1_Teaching_Spd, (int)(cSys.dPR1_Normal_Spd * sMotor[(int)enumMotorName.PR1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1030_PR1_Teaching_Start, true);
          break;
        case "btnGo_PR2_CenterPos":
          if (Check_MotorStatus(enumMotorName.PR2) == false) { return; }
          if (sMotor[(int)enumMotorName.PR2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1046_PR2_Teaching_Pos, (int)(cSys.dPR2_Center_Pos * sMotor[(int)enumMotorName.PR2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1044_PR2_Teaching_Spd, (int)(cSys.dPR2_Normal_Spd * sMotor[(int)enumMotorName.PR2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1031_PR2_Teaching_Start, true);
          break;
        case "btnGo_PR2_CleanPos":
          if (Check_MotorStatus(enumMotorName.PR2) == false) { return; }
          if (sMotor[(int)enumMotorName.PR2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1046_PR2_Teaching_Pos, (int)(cSys.dPR2_Clean_Pos * sMotor[(int)enumMotorName.PR2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1044_PR2_Teaching_Spd, (int)(cSys.dPR2_Normal_Spd * sMotor[(int)enumMotorName.PR2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1031_PR2_Teaching_Start, true);
          break;
        case "btnGo_PR3_CenterPos":
          if (Check_MotorStatus(enumMotorName.PR3) == false) { return; }
          if (sMotor[(int)enumMotorName.PR3].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104A_PR3_Teaching_Pos, (int)(cSys.dPR3_Center_Pos * sMotor[(int)enumMotorName.PR3].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1048_PR3_Teaching_Spd, (int)(cSys.dPR3_Normal_Spd * sMotor[(int)enumMotorName.PR3].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1032_PR3_Teaching_Start, true);
          break;
        case "btnGo_PR3_CleanPos":
          if (Check_MotorStatus(enumMotorName.PR3) == false) { return; }
          if (sMotor[(int)enumMotorName.PR3].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104A_PR3_Teaching_Pos, (int)(cSys.dPR3_Clean_Pos * sMotor[(int)enumMotorName.PR3].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1048_PR3_Teaching_Spd, (int)(cSys.dPR3_Normal_Spd * sMotor[(int)enumMotorName.PR3].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1032_PR3_Teaching_Start, true);
          break;
        case "btnGo_PR4_CenterPos":
          if (Check_MotorStatus(enumMotorName.PR4) == false) { return; }
          if (sMotor[(int)enumMotorName.PR4].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104E_PR4_Teaching_Pos, (int)(cSys.dPR4_Center_Pos * sMotor[(int)enumMotorName.PR4].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104C_PR4_Teaching_Spd, (int)(cSys.dPR4_Normal_Spd * sMotor[(int)enumMotorName.PR4].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1033_PR4_Teaching_Start, true);
          break;
        case "btnGo_PR4_CleanPos":
          if (Check_MotorStatus(enumMotorName.PR4) == false) { return; }
          if (sMotor[(int)enumMotorName.PR4].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104E_PR4_Teaching_Pos, (int)(cSys.dPR4_Clean_Pos * sMotor[(int)enumMotorName.PR4].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104C_PR4_Teaching_Spd, (int)(cSys.dPR4_Normal_Spd * sMotor[(int)enumMotorName.PR4].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1033_PR4_Teaching_Start, true);
          break;
        case "btnGo_UE1_ScanStart":
          if (Check_MotorStatus(enumMotorName.UE1) == false) { return; }
          if (sMotor[(int)enumMotorName.UE1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(cSys.dUE1_ScanStart_Pos * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(cSys.dUE1_Normal_Spd * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1021_UE1_Teaching_Start, true);
          break;
        case "btnGo_UE1_ScanEnd":
          if (Check_MotorStatus(enumMotorName.UE1) == false) { return; }
          if (sMotor[(int)enumMotorName.UE1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(cSys.dUE1_ScanEnd_Pos * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(cSys.dUE1_Normal_Spd * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1021_UE1_Teaching_Start, true);
          break;
        case "btnGo_UE1_CassetteWait":
          if (Check_MotorStatus(enumMotorName.UE1) == false) { return; }
          if (sMotor[(int)enumMotorName.UE1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(cSys.dUE1_Cassette_Wait_Pos * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(cSys.dUE1_Normal_Spd * sMotor[(int)enumMotorName.UE1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1021_UE1_Teaching_Start, true);
          break;
        case "btnGo_UE2_ScanStart":
          if (Check_MotorStatus(enumMotorName.UE2) == false) { return; }
          if (sMotor[(int)enumMotorName.UE2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(cSys.dUE2_ScanStart_Pos * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(cSys.dUE2_Normal_Spd * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1022_UE2_Teaching_Start, true);
          break;
        case "btnGo_UE2_ScanEnd":
          if (Check_MotorStatus(enumMotorName.UE2) == false) { return; }
          if (sMotor[(int)enumMotorName.UE2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(cSys.dUE2_ScanEnd_Pos * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(cSys.dUE2_Normal_Spd * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1022_UE2_Teaching_Start, true);
          break;
        case "btnGo_UE2_CassetteWait":
          if (Check_MotorStatus(enumMotorName.UE2) == false) { return; }
          if (sMotor[(int)enumMotorName.UE2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(cSys.dUE2_Cassette_Wait_Pos * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(cSys.dUE2_Normal_Spd * sMotor[(int)enumMotorName.UE2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1022_UE2_Teaching_Start, true);
          break;
        case "btnGo_UE3_ScanStart":
          if (Check_MotorStatus(enumMotorName.UE3) == false) { return; }
          if (sMotor[(int)enumMotorName.UE3].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(cSys.dUE3_ScanStart_Pos * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(cSys.dUE3_Normal_Spd * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1023_UE3_Teaching_Start, true);
          break;
        case "btnGo_UE3_ScanEnd":
          if (Check_MotorStatus(enumMotorName.UE3) == false) { return; }
          if (sMotor[(int)enumMotorName.UE3].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(cSys.dUE3_ScanEnd_Pos * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(cSys.dUE3_Normal_Spd * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1023_UE3_Teaching_Start, true);
          break;
        case "btnGo_UE3_CassetteWait":
          if (Check_MotorStatus(enumMotorName.UE3) == false) { return; }
          if (sMotor[(int)enumMotorName.UE3].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(cSys.dUE3_Cassette_Wait_Pos * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(cSys.dUE3_Normal_Spd * sMotor[(int)enumMotorName.UE3].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1023_UE3_Teaching_Start, true);
          break;
        case "btnGo_UE4_ScanStart":
          if (Check_MotorStatus(enumMotorName.UE4) == false) { return; }
          if (sMotor[(int)enumMotorName.UE4].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(cSys.dUE4_ScanStart_Pos * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(cSys.dUE4_Normal_Spd * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1024_UE4_Teaching_Start, true);
          break;
        case "btnGo_UE4_ScanEnd":
          if (Check_MotorStatus(enumMotorName.UE4) == false) { return; }
          if (sMotor[(int)enumMotorName.UE4].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(cSys.dUE4_ScanEnd_Pos * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(cSys.dUE4_Normal_Spd * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1024_UE4_Teaching_Start, true);
          break;
        case "btnGo_UE4_CassetteWait":
          if (Check_MotorStatus(enumMotorName.UE4) == false) { return; }
          if (sMotor[(int)enumMotorName.UE4].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(cSys.dUE4_Cassette_Wait_Pos * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(cSys.dUE4_Normal_Spd * sMotor[(int)enumMotorName.UE4].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1024_UE4_Teaching_Start, true);
          break;
        case "btnGo_BCX_ReadingPos":
          if (Check_MotorStatus(enumMotorName.BCX) == false) { return; }
          if (sMotor[(int)enumMotorName.BCX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1016_BCX_Teaching_Pos, (int)(cRcp.dPCB_Barcode_BCX_Pos * sMotor[(int)enumMotorName.BCX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1014_BCX_Teaching_Spd, (int)(cSys.dBCX_Normal_Spd * sMotor[(int)enumMotorName.BCX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1025_BCX_Teaching_Start, true);
          break;
        case "btnGo_BCY_ReadingPos":
          if (Check_MotorStatus(enumMotorName.BCY) == false) { return; }
          if (sMotor[(int)enumMotorName.BCY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101A_BCY_Teaching_Pos, (int)(cRcp.dPCB_Barcode_BCY_Pos * sMotor[(int)enumMotorName.BCY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1018_BCY_Teaching_Spd, (int)(cSys.dBCY_Normal_Spd * sMotor[(int)enumMotorName.BCY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1026_BCY_Teaching_Start, true);
          break;
        case "btnGo_LP_ReadyPos":
          if (Check_MotorStatus(enumMotorName.LP) == false) { return; }
          if (sMotor[(int)enumMotorName.LP].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(cSys.dLP_Ready_Pos * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1027_LP_Teaching_Start, true);
          break;
        case "btnGo_Z1_ReadyPos":
          if (Check_MotorStatus(enumMotorName.Z1) == false) { return; }
          if (sMotor[(int)enumMotorName.Z1].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Ready_Pos * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
          break;
        case "btnGo_Z2_ReadyPos":
          if (Check_MotorStatus(enumMotorName.Z2) == false) { return; }
          if (sMotor[(int)enumMotorName.Z2].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Ready_Pos * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
          break;
        case "btnGo_UPX_Ready":
          if (Check_MotorStatus(enumMotorName.UPX) == false) { return; }
          if (sMotor[(int)enumMotorName.UPX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(cSys.dUPX_Ready_Pos * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1028_UPX_Teaching_Start, true);
          break;
        case "btnGo_UPY_Ready":
          if (Check_MotorStatus(enumMotorName.UPY) == false) { return; }
          if (sMotor[(int)enumMotorName.UPY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(cSys.dUPY_Ready_Pos * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1029_UPY_Teaching_Start, true);
          break;
        case "btnGo_BCX_Ready":
          if (Check_MotorStatus(enumMotorName.BCX) == false) { return; }
          if (sMotor[(int)enumMotorName.BCX].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1016_BCX_Teaching_Pos, (int)(cSys.dBCX_Ready_Pos * sMotor[(int)enumMotorName.BCX].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1014_BCX_Teaching_Spd, (int)(cSys.dBCX_Normal_Spd * sMotor[(int)enumMotorName.BCX].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1025_BCX_Teaching_Start, true);
          break;
        case "btnGo_BCY_Ready":
          if (Check_MotorStatus(enumMotorName.BCY) == false) { return; }
          if (sMotor[(int)enumMotorName.BCY].bHomeComplete == false) { return; }
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101A_BCY_Teaching_Pos, (int)(cSys.dBCY_Ready_Pos * sMotor[(int)enumMotorName.BCY].dLimitScale));
          CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1018_BCY_Teaching_Spd, (int)(cSys.dBCY_Normal_Spd * sMotor[(int)enumMotorName.BCY].dLimitScale));
          CIoVo.Set_WB_OutFlag(enumFlagOut.B1026_BCY_Teaching_Start, true);
          break;
        default:
          break;
      }
    }

    private void btnCycle_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      if (Check_ManualRun() == false)
      {
        return;
      }
      if (Check_MachineStatus() == false)
      {
        return;
      }
      CVo.bManualRun = true;
      CVo.bWaitStage1ZeroSet = false;
      CVo.bWaitStage2ZeroSet = false; 
      CVo.eMachineStatus = enumMachineStatus.Cycle;

      switch (ctrl.Name)
      {
        case "btnCycle_LE_Align": CVo.sCycleStatus[(int)enumCycleStatus.LE_Align].bCycleStart = true; break;
        case "btnCycle_UE1_Align": CVo.sCycleStatus[(int)enumCycleStatus.UE1_Align].bCycleStart = true; break;
        case "btnCycle_UE2_Align": CVo.sCycleStatus[(int)enumCycleStatus.UE2_Align].bCycleStart = true; break;
        case "btnCycle_UE3_Align": CVo.sCycleStatus[(int)enumCycleStatus.UE3_Align].bCycleStart = true; break;
        case "btnCycle_UE4_Align": CVo.sCycleStatus[(int)enumCycleStatus.UE4_Align].bCycleStart = true; break;

        case "btnCycle_LE_CassetteWait": CVo.sCycleStatus[(int)enumCycleStatus.LE_Cassette_Wait].bCycleStart = true; break;
        case "btnCycle_UE1_CassetteWait": CVo.sCycleStatus[(int)enumCycleStatus.UE1_Cassette_Wait].bCycleStart = true; break;
        case "btnCycle_UE2_CassetteWait": CVo.sCycleStatus[(int)enumCycleStatus.UE2_Cassette_Wait].bCycleStart = true; break;
        case "btnCycle_UE3_CassetteWait": CVo.sCycleStatus[(int)enumCycleStatus.UE3_Cassette_Wait].bCycleStart = true; break;
        case "btnCycle_UE4_CassetteWait": CVo.sCycleStatus[(int)enumCycleStatus.UE4_Cassette_Wait].bCycleStart = true; break;

        case "btnCycle_LE_to_LP": CVo.sCycleStatus[(int)enumCycleStatus.LE_to_LP].bCycleStart = true; break;

        case "btnCycle_LP_to_AL": CVo.sCycleStatus[(int)enumCycleStatus.LP_to_AL].bCycleStart = true; break;

        case "btnCycle_Align": CVo.sCycleStatus[(int)enumCycleStatus.Align].bCycleStart = true; break;

        case "btnCycle_AL_to_LP": CVo.sCycleStatus[(int)enumCycleStatus.AL_to_LP].bCycleStart = true; break;

        case "btnCycle_LP_to_Stage1": CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage1].bCycleStart = true; break;
        case "btnCycle_LP_to_Stage2": CVo.sCycleStatus[(int)enumCycleStatus.LP_to_Stage2].bCycleStart = true; break;

        case "btnCycle_Stage1_Zero": CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Zero].bCycleStart = true; break;
        case "btnCycle_Stage2_Zero": CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Zero].bCycleStart = true; break;

        case "btnCycle_Stage1_Measure": CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Measure].bCycleStart = true; break;
        case "btnCycle_Stage2_Measure": CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart = true; break;

        case "btnCycle_Stage1_to_UP": CVo.sCycleStatus[(int)enumCycleStatus.Stage1_to_UP].bCycleStart = true; break;
        case "btnCycle_Stage2_to_UP": CVo.sCycleStatus[(int)enumCycleStatus.Stage2_to_UP].bCycleStart = true; break;

        case "btnCycle_UP_to_UE1": CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE1].bCycleStart = true; break;
        case "btnCycle_UP_to_UE2": CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE2].bCycleStart = true; break;
        case "btnCycle_UP_to_UE3": CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE3].bCycleStart = true; break;
        case "btnCycle_UP_to_UE4": CVo.sCycleStatus[(int)enumCycleStatus.UP_to_UE4].bCycleStart = true; break;

        case "btnCycle_Stage1_Clean": CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Clean].bCycleStart = true; break;
        case "btnCycle_Stage2_Clean": CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Clean].bCycleStart = true; break;

        case "btnCycle_Stage1_Probe_Clean": CVo.sCycleStatus[(int)enumCycleStatus.Stage1_Probe_Clean].bCycleStart = true; break;
        case "btnCycle_Stage2_Probe_Clean": CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bCycleStart = true; break;
        case "btnCycle_ProbeChange": CVo.sCycleStatus[(int)enumCycleStatus.ProbeChange].bCycleStart = true; break;
        default:
          break;
      }
    }

    private void btnHome_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      if (Check_ManualRun() == false)
      {
        return;
      }
      if (Check_MachineStatus() == false)
      {
        return;
      }

      CVo.eMachineStatus = enumMachineStatus.Initial;

      switch (ctrl.Name)
      {
        case "btnHome_Loading":
          CVo.bInit_Loading = true;
          break;
        case "btnHome_Stage":
          CVo.bInit_Stage = true; 
          break;
        case "btnHome_Unloading":
          CVo.bInit_Unloading = true;              
          break;
        default: break;
      }
    }

    private void btnCycle_Air_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      if (Check_ManualRun() == false)
      {
        return;
      }
      if (Check_MachineStatus() == false)
      {
        return;
      }

      //int iTime = 500;
      switch (ctrl.Name)
      {
        case "btnCycle_Cylinder_Loader_UpDown": CMaster.cMotion.cAction.Cylinder_Loader(!CIoVo.Get_WB_Output(enumBitOutput.B1115_LoadingPickerDownSol)); break;
        case "btnCycle_Vaccum_Loader": CMaster.cMotion.cAction.Vaccum_Loader(!CIoVo.Get_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol)); break;
        case "btnCycle_Loading_AirBlow": CMaster.cMotion.cAction.Sol_Loader(!CIoVo.Get_WB_Output(enumBitOutput.B1113_LoadingAirBlowSol)); break;

        case "btnCycle_Vaccum_Stage1": CMaster.cMotion.cAction.Vaccume_Stage1(!CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear)); break;
        case "btnCycle_Vaccum_Stage2": CMaster.cMotion.cAction.Vaccume_Stage2(!CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front)); break;
        case "btnCycle_Stage1_StageCleanAirBlow": CMaster.cMotion.cAction.Sol_Stage1(!CIoVo.Get_WB_Output(enumBitOutput.B1116_Chuck1AirBlow_Rear)); break;
        case "btnCycle_Stage2_StageCleanAirBlow": CMaster.cMotion.cAction.Sol_Stage2(!CIoVo.Get_WB_Output(enumBitOutput.B1117_Chuck2AirBlow_Front)); break;
        case "btnCycle_Stage1_probeCleanAirBlow": CMaster.cMotion.cAction.Sol_Probe1(!CIoVo.Get_WB_Output(enumBitOutput.B1118_ProbeAirBlowSol1_Rear)); break;
        case "btnCycle_Stage2_probeCleanAirBlow": CMaster.cMotion.cAction.Sol_Probe2(!CIoVo.Get_WB_Output(enumBitOutput.B1119_ProbeAirBlowSol2_Front)); break;

        case "btnCycle_Cylinder_Unloader_UpDown": CMaster.cMotion.cAction.Cylinder_Unloader(!CIoVo.Get_WB_Output(enumBitOutput.B111B_UnloadingPickerDownSol)); break;
        case "btnCycle_Vaccum_Unloader": CMaster.cMotion.cAction.Vaccum_Unloader(!CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol)); break;

        default:
          break;
      }
    }

    private void tmr_Manual_Tick(object sender, EventArgs e)
    {
      tmr_Manual.Enabled = false;
      btnCycle_Cylinder_Loader_UpDown.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1115_LoadingPickerDownSol) ? Color.Lime : Color.White;
      btnCycle_Loading_AirBlow.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1113_LoadingAirBlowSol) ? Color.Lime : Color.White;

      btnCycle_Vaccum_Stage1.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear) ? Color.Lime : Color.White;
      btnCycle_Vaccum_Stage2.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front) ? Color.Lime : Color.White;
      btnCycle_Stage1_StageCleanAirBlow.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1116_Chuck1AirBlow_Rear) ? Color.Lime : Color.White;
      btnCycle_Stage2_StageCleanAirBlow.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1117_Chuck2AirBlow_Front) ? Color.Lime : Color.White;
      btnCycle_Stage1_probeCleanAirBlow.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1118_ProbeAirBlowSol1_Rear) ? Color.Lime : Color.White;
      btnCycle_Stage2_probeCleanAirBlow.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1119_ProbeAirBlowSol2_Front) ? Color.Lime : Color.White;

      btnCycle_Cylinder_Unloader_UpDown.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B111B_UnloadingPickerDownSol) ? Color.Lime : Color.White;

      btnCycle_Vaccum_Loader.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol) ? Color.Lime : Color.White;
      btnCycle_Vaccum_Unloader.BackColor = CIoVo.Get_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol) ? Color.Lime : Color.White;

      tmr_Manual.Enabled = true;
    }

    private void FormPageManual_Load(object sender, EventArgs e)
    {

    }

    private void cbo_TestMode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


  }
}
