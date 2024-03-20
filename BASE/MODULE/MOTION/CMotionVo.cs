using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

using BASE.MASTER;
using BASE.VO;
using BASE.FORM;

namespace BASE.MODULE.MOTION
{
  public class ClassMotionDataMonitor
  {
    private static ClassMotionDataMonitor cInstatnce;
    private static object syncLock = new object();
    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    private static structMData[,] sMotorData = null;// new structMData[Enum.GetNames(typeof(enumMotorName)).Length, CMotionVo.cMotorPosition]; //Motor Data
    private static structMotorStatus[] sMotorStatus = null;// new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length]; // Motor Status

    public void SetMonitorMotorData(ref structMData[,] source) { sMotorData = source; }
    public void SetMonitorMotorStatus(ref structMotorStatus[] source) { sMotorStatus = source; }

    protected ClassMotionDataMonitor()
    {
      Check_Thread();
    }

    public static ClassMotionDataMonitor Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassMotionDataMonitor();
          }
        }
      }
      return cInstatnce;
    }

    public void Check_Thread()
    {
      if (th == null)
      {
        bThread = true;
        th = new System.Threading.Thread(Run);
        th.Start();
      }
    }
    public void Abort_Thread()
    {
      if (th != null)
      {
        th.Abort();
      }
      bThread = false;
      th = null;
    } // Kill All Thread
    public void Run()
    {
      while (bThread)
      {
        System.Threading.Thread.Sleep(1);
        lock (this)
        {
          if (sMotorStatus != null)
          {
            sMotorStatus[(int)enumMotorName.LE].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1560_LE_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1560_LE_Cur_Pos) / sMotorStatus[(int)enumMotorName.LE].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.LP].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W156E_LP_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W156E_LP_Cur_Pos) / sMotorStatus[(int)enumMotorName.LP].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.BCX].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W156A_BCX_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W156A_BCX_Cur_Pos) / sMotorStatus[(int)enumMotorName.BCX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.BCY].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W156C_BCY_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W156C_BCY_Cur_Pos) / sMotorStatus[(int)enumMotorName.BCY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.ALX].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1578_ALX_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1578_ALX_Cur_Pos) / sMotorStatus[(int)enumMotorName.ALX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.ALY].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W157A_ALY_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W157A_ALY_Cur_Pos) / sMotorStatus[(int)enumMotorName.ALY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.X1].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W157C_X1_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W157C_X1_Cur_Pos) / sMotorStatus[(int)enumMotorName.X1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.X2].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W157E_X2_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W157E_X2_Cur_Pos) / sMotorStatus[(int)enumMotorName.X2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.Z1].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1574_Z1_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1574_Z1_Cur_Pos) / sMotorStatus[(int)enumMotorName.Z1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.Z2].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1576_Z2_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1576_Z2_Cur_Pos) / sMotorStatus[(int)enumMotorName.Z2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR1].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1580_PR1_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1580_PR1_Cur_Pos) / sMotorStatus[(int)enumMotorName.PR1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR2].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1582_PR2_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1582_PR2_Cur_Pos) / sMotorStatus[(int)enumMotorName.PR2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR3].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1584_PR3_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1584_PR3_Cur_Pos) / sMotorStatus[(int)enumMotorName.PR3].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR4].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1586_PR4_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1586_PR4_Cur_Pos) / sMotorStatus[(int)enumMotorName.PR4].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UPX].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1570_UPX_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1570_UPX_Cur_Pos) / sMotorStatus[(int)enumMotorName.UPX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UPY].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1572_UPY_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1572_UPY_Cur_Pos) / sMotorStatus[(int)enumMotorName.UPY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE1].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1562_UE1_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1562_UE1_Cur_Pos) / sMotorStatus[(int)enumMotorName.UE1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE2].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1564_UE2_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1564_UE2_Cur_Pos) / sMotorStatus[(int)enumMotorName.UE2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE3].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1566_UE3_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1566_UE3_Cur_Pos) / sMotorStatus[(int)enumMotorName.UE3].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE4].dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1568_UE4_Cur_Pos) != 0 ? (double)(CIoVo.Get_RW_CurPos(enumWR_CurPos.W1568_UE4_Cur_Pos) / sMotorStatus[(int)enumMotorName.UE4].dLimitScale) : 0.0;

            sMotorStatus[(int)enumMotorName.LE].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A0_LE_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A0_LE_Cur_Spd) / sMotorStatus[(int)enumMotorName.LE].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.LP].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AE_LP_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AE_LP_Cur_Spd) / sMotorStatus[(int)enumMotorName.LP].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.BCX].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AA_BCX_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AA_BCX_Cur_Spd) / sMotorStatus[(int)enumMotorName.BCX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.BCY].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AC_BCY_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15AC_BCY_Cur_Spd) / sMotorStatus[(int)enumMotorName.BCY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.ALX].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B8_ALX_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B8_ALX_Cur_Spd) / sMotorStatus[(int)enumMotorName.ALX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.ALY].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BA_ALY_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BA_ALY_Cur_Spd) / sMotorStatus[(int)enumMotorName.ALY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.X1].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BC_X1_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BC_X1_Cur_Spd) / sMotorStatus[(int)enumMotorName.X1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.X2].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BE_X2_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15BE_X2_Cur_Spd) / sMotorStatus[(int)enumMotorName.X2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.Z1].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B4_Z1_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B4_Z1_Cur_Spd) / sMotorStatus[(int)enumMotorName.Z1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.Z2].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B6_Z2_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B6_Z2_Cur_Spd) / sMotorStatus[(int)enumMotorName.Z2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR1].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C0_PR1_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C0_PR1_Cur_Spd) / sMotorStatus[(int)enumMotorName.PR1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR2].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C2_PR2_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C2_PR2_Cur_Spd) / sMotorStatus[(int)enumMotorName.PR2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR3].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C4_PR3_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C4_PR3_Cur_Spd) / sMotorStatus[(int)enumMotorName.PR3].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.PR4].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C6_PR4_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15C6_PR4_Cur_Spd) / sMotorStatus[(int)enumMotorName.PR4].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UPX].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B0_UPX_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B0_UPX_Cur_Spd) / sMotorStatus[(int)enumMotorName.UPX].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UPY].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B2_UPY_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15B2_UPY_Cur_Spd) / sMotorStatus[(int)enumMotorName.UPY].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE1].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A2_UE1_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A2_UE1_Cur_Spd) / sMotorStatus[(int)enumMotorName.UE1].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE2].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A4_UE2_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A4_UE2_Cur_Spd) / sMotorStatus[(int)enumMotorName.UE2].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE3].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A6_UE3_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A6_UE3_Cur_Spd) / sMotorStatus[(int)enumMotorName.UE3].dLimitScale) : 0.0;
            sMotorStatus[(int)enumMotorName.UE4].dCurrentSpeed = CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A8_UE4_Cur_Spd) != 0 ? (double)(CIoVo.Get_RW_CurSpd(enumWR_CurSpd.W15A8_UE4_Cur_Spd) / sMotorStatus[(int)enumMotorName.UE4].dLimitScale) : 0.0;

            sMotorStatus[(int)enumMotorName.LE].bInposition = CIoVo.Get_RB_Input(enumBitInput.B201C_LE_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.LP].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2023_LP_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.BCX].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2021_BC1_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.BCY].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2022_BC2_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.ALX].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2028_ALX_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.ALY].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2029_ALY_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.X1].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202A_X1_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.X2].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202B_X2_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.Z1].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2026_Z1_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.Z2].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2027_Z2_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.PR1].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202C_PR1_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.PR2].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202D_PR2_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.PR3].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202E_PR3_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.PR4].bInposition = CIoVo.Get_RB_Input(enumBitInput.B202F_PR4_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UPX].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2024_UPX_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UPY].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2025_UPY_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UE1].bInposition = CIoVo.Get_RB_Input(enumBitInput.B201D_UE1_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UE2].bInposition = CIoVo.Get_RB_Input(enumBitInput.B201E_UE2_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UE3].bInposition = CIoVo.Get_RB_Input(enumBitInput.B201F_UE3_AXISIn_position_Signal);
            sMotorStatus[(int)enumMotorName.UE4].bInposition = CIoVo.Get_RB_Input(enumBitInput.B2020_UE4_AXISIn_position_Signal);

            sMotorStatus[(int)enumMotorName.LE].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2080_LE_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A0_LE_Teaching_Running);
            sMotorStatus[(int)enumMotorName.LP].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2087_LP_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A7_LP_Teaching_Running);
            sMotorStatus[(int)enumMotorName.BCX].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2085_BCX_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A5_BCX_Teaching_Running);
            sMotorStatus[(int)enumMotorName.BCY].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2086_BCY_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A6_BCY_Teaching_Running);
            sMotorStatus[(int)enumMotorName.ALX].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208C_ALX_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AC_ALX_Teaching_Running);
            sMotorStatus[(int)enumMotorName.ALY].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208D_ALY_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AD_ALY_Teaching_Running);
            sMotorStatus[(int)enumMotorName.X1].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208E_X1_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AE_X1_Teaching_Running);
            sMotorStatus[(int)enumMotorName.X2].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208F_X2_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AF_X2_Teaching_Running);
            sMotorStatus[(int)enumMotorName.Z1].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208A_Z1_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running);
            sMotorStatus[(int)enumMotorName.Z2].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208B_Z2_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running);
            sMotorStatus[(int)enumMotorName.PR1].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2090_PR1_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B0_PR1_Teaching_Running);
            sMotorStatus[(int)enumMotorName.PR2].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2091_PR2_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B1_PR2_Teaching_Running);
            sMotorStatus[(int)enumMotorName.PR3].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2092_PR3_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B2_PR3_Teaching_Running);
            sMotorStatus[(int)enumMotorName.PR4].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2093_PR4_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B3_PR4_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UPX].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2088_UPX_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A8_UPX_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UPY].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2089_UPY_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A9_UPY_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UE1].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2081_UE1_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A1_UE1_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UE2].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2082_UE2_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A2_UE2_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UE3].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2083_UE3_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A3_UE3_Teaching_Running);
            sMotorStatus[(int)enumMotorName.UE4].bBusy = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2084_UE4_Homming) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20A4_UE4_Teaching_Running);
         
            
          }

          if (sMotorData != null)
          {
            //CForm.frmMxComponent.set
          }

 
        }
      }
    }

  }

  public enum enumMotorType
  {
    Ajin = 0,
    EzServo,
    PLC,
  } // Motor Brand And Connection

  public enum enumMotorName
  {
    LE = 0,
    LP,
    BCX,
    BCY,
    ALX,
    ALY,
    X1,
    X2,
    Z1,
    Z2,
    PR1,
    PR2,
    PR3,
    PR4,
    UPX,
    UPY,
    UE1,
    UE2,
    UE3,
    UE4,
  } // Axis Name

  public enum enumPos_LE
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Scan_Start_Pos,
    Scan_End_Pos,
    Cassette_Wait_Pos,
  }
  public enum enumPos_LP
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    LE_Pos,
    AL_Loading,
    AL_Unloading,
    Stage1_Pos,
    Stage2_Pos,

  }
  public enum enumPos_BCX
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Reading,
  }
  public enum enumPos_BCY
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Reading,
  }
  public enum enumPos_ALX
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Before_Align,
    Align,
    Align_Back_offset,
  }
  public enum enumPos_ALY
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Before_Align,
    Align,
    Align_Back_offset,
  }
  public enum enumPos_X1
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Loading,
    Zero,
    Measure,
    Clean_Start,
    Clean_End,
    Unloading,
  }
  public enum enumPos_X2
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Loading,
    Zero,
    Measure,
    Clean_Start,
    Clean_End,
    Unloading,
  }
  public enum enumPos_Z1
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Loading,
    Zero,
    Measure,
    Unloading,
  }
  public enum enumPos_Z2
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Loading,
    Zero,
    Measure,
    Unloading,
  }
  public enum enumPos_PR1
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Zero,
    Measure,
  }
  public enum enumPos_PR2
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Zero,
    Measure,
  }
  public enum enumPos_PR3
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Zero,
    Measure,
  }
  public enum enumPos_PR4
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Zero,
    Measure,
  }
  public enum enumPos_UPX
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Stage1_Pos,
    Stage2_Pos,
    UE1_Pos,
    UE2_Pos,
    UE3_Pos,
    UE4_Pos,
  }
  public enum enumPos_UPY
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Stage1_Pos,
    Stage2_Pos,
    UE1_Pos,
    UE2_Pos,
    UE3_Pos,
    UE4_Pos,
  }
  public enum enumPos_UE1
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Scan_Start_Pos,
    Scan_End_Pos,
    Cassette_Wait_Pos,
  }
  public enum enumPos_UE2
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Scan_Start_Pos,
    Scan_End_Pos,
    Cassette_Wait_Pos,
  }
  public enum enumPos_UE3
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Scan_Start_Pos,
    Scan_End_Pos,
    Cassette_Wait_Pos,
  }
  public enum enumPos_UE4
  {
    Ready,        // 원점복귀후 대기위치 
    Teaching,     // 티칭 동작시 
    Calculate,    // 연산값으로 위치값이 계속 바뀌는 곳 
    Scan_Start_Pos,
    Scan_End_Pos,
    Cassette_Wait_Pos,
  }

  public struct structMData
  {
    public double dPosition;                // 구동 위치
    public double dSpeed;                   // 구동 속도
    public double dAcc;                     // 구동 가속도
    public double dDcc;                     // 구동 감속도
    public double dTimeOut;                 // 구동 타임아웃
    public double dDelay;                   // 구동 완료후 딜레이
  } // Motor Position Data

  public enum enumSetMotorStatus
  {
    bMoveComplete = 0,      // Move Complete (변경)
    bHomeComplete,        // Home Complete (변경)
    bErrMove,             // Moving Error (변경)
    bErrTimeOut,          // Time Out Error (변경)
    bErrHome,             // Home Error (변경)
    bErrLimitCw,          // + Limit Sensor Error (변경)
    bErrLimitCcw,         // - Limit Sensor Error (변경)
    bErrLimitSwCw,        // + Limit Soft Error (변경)
    bErrLimitSwCcw,       // - Limit Soft Error (변경)
    bErrServoAlarm,       // Servo Alarm (변경)
    bCmdHome,             // 원점복귀 명령 (변경)
    bErrTimeOutGap,       // 지령 과 피드백 오차로 인한 타임아웃 (변경)
    dCurrentPos,          // Current Position  (디버깅모드만 변경)
    bErrEmgStop,          // Moving 급정지  (변경)
    bErrBorad,            // Borad 에러 (변경)
  }

  public struct structMotorStatus
  {
    public enumMotorType eType;     // Brand And Connect Type
    public int iGentry;             // 갠트리 사용유무 0:미사용 1:마스터 2:슬레이브 
    public int iCoaxial;            // 한축에서 2개 모터를 사용하는지 체크 0:미사용 1:마스터 2:슬레이브
    public bool bSpare;             // 보드 배열중 사용하지 않는것 체크  
    public bool bCompensation;      // 1D 보정 사용 유무 체크 
    public bool bEncNot;            // 엔코더 피드백을 받지 않는것 체크 

    public bool bMotorSkip;         // motor 고장으로 인한 스킵시 (저장 로드) 

    public double dLimitSpeed;      // Speed Limit (저장 로드)
    public double dLimitJogSpd;    // Speed Limit Jog (저장 로드)
    public double dLimitGap;        // 모터 이동후 허가 갭 (저장 로드)

    public double dCurrentSpeed;    // Current Speed(읽기)
    public double dCmdPosition;     // Command Position (읽기)
    public double dCurrentGap;      // Encoder - Command (읽기)
    public double dCurrentRatio;    // Current Motor Load Ratio (읽기)
    //   public bool bReady;             // Servo Ready (읽기)
    public bool bEmgStop;           // 구동중 급정지 스위치 (변경)
    public bool bMoveComplete;      // Move Complete (변경)

    public bool bErrMove;           // Moving Error (변경)
    public bool bErrBorad;          // 보드에러 Error (변경)
    public bool bErrEmgStop;        // Moving 급정지 (변경)
    public bool bErrTimeOut;        // Time Out Error (변경)
    public bool bErrTimeOutGap;     // 모터 Gap Time Out Error (변경)
    public bool bErrHome;           // Home Error (변경)
    public bool bErrLimitCw;        // + Limit Sensor Error (변경)
    public bool bErrLimitCcw;       // - Limit Sensor Error (변경)
    public bool bErrLimitSwCw;      // + Limit Soft Error (변경)
    public bool bErrLimitSwCcw;     // - Limit Soft Error (변경)
    public bool bErrServoAlarm;     // Servo Alarm (변경)
    //  public bool bErrParam;          // Motor Parameter Error(Drive Setting) (변경)
    public bool bCmdHome;           // 원점복귀 명령 (변경)


    //////// ↓↓↓↓↓ PLC 사용 비트 ↓↓↓↓↓ ////////
    public bool bAlarm;             // Servo Alarm (읽기)
    public bool bInPosition;        // In Position (읽기)
    public bool bServoOn;           // Servo On (읽기)
    public double dCurrentPos;      // Current Position (읽기)
    public bool bSensorCw;          // + Sensor Limit (읽기)
    public bool bSensorCcw;         // - Sensor Limit (읽기)
    public bool bSensorHome;        // Sensor Origin (읽기)

    public double dLimitSoftCw;     // + Soft Limit (저장 로드)
    public double dLimitSoftCcw;    // - Soft Limit (저장 로드)

    public bool bBusy;              // Moving Status (읽기)
    public double dLimitScale;      // PLC 사용시 Scale (저장 로드)
    public bool bHomeComplete;      // Home Complete (변경)
    public bool bInposition;

    public bool bErrorPLCReady;          //PLC Motor Ready 에러
    public bool bErrorPLCMotor;          //PLC Motor 상태 에러
    public bool bErrorPLCLimit;          //PLC Motor 리미트 에러
    public bool bErrorPLCState;          //PLC Motor PLC 상태이상 에러
    public bool bErrorPLCPosition;       //PLC Motor 위치데이터 에러
  } // Motor Status

  public static class CMotionVo
  {
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    //PLC Connect Data
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Monitor
    private static ClassMotionDataMonitor cMonitor = ClassMotionDataMonitor.Get_Instance();
    public static void StartMonitor()
    {
      cMonitor.Check_Thread();
    }
    public static void StopMonitor()
    {
      cMonitor.Abort_Thread();
    }

    public static double[] dMorotScale = new double[Enum.GetNames(typeof(enumMotorName)).Length];

    public const int cMotorPosition = 20;  // 축당 할당하는 포인트 갯수 
    private static structMData[,] sMotorData = new structMData[Enum.GetNames(typeof(enumMotorName)).Length, cMotorPosition]; //Motor Data

    private static structMotorStatus[] sMotorStatus = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length]; // Motor Status

    public static bool bAjinConnect = false; // 아진보드 연결 상태 
    private static enumMotorName[] eEmptyMotor = new enumMotorName[]                        // 배열중에 미사용 축 선언
    {
     //  enumMotorName.LE, 
      //enumMotorName.Spare1
    };
    private static enumMotorName[] eCompensation = new enumMotorName[]                      // 1D보정 사용 축 선언
    {

    };
    private static enumMotorName[] eEncNot = new enumMotorName[]                            // 엔코더 미사용 축 선언
    {

    };
    private static enumMotorName[] eGentryMaster = new enumMotorName[]                      // 갠트리 축이 있으면 선언 마스터
    { 
    //    enumMotorName.ALX, 
    };
    private static enumMotorName[] eGentrySlave = new enumMotorName[]                       // 갠트리 축이 있으면 선언 슬레이브
    { 

    };
    private static enumMotorName[] eCoaxialMaster = new enumMotorName[]                     // 한축상에 충돌 가능성 있는 모터 선언 마스터
    { 

    };
    private static enumMotorName[] eCoaxialSlave = new enumMotorName[]                      // 한축상에 충돌 가능성 있는 모터 선언 슬레이브
    {

    };
    // Motor Status Data
    public static structMotorStatus GetMotorStatus(enumMotorName axis)
    {
      return sMotorStatus[(int)axis];
    } // Get Motor Status

    public static void SetMotorStatus(structMotorStatus sSendStatus, enumMotorName axis)
    {
      sMotorStatus[(int)axis] = sSendStatus;
    } // Set Motor Status
    public static void SetMotorStatus(enumSetMotorStatus eSetMotorStatus, enumMotorName axis, bool bWrite)
    {
      switch (eSetMotorStatus)
      {
        case enumSetMotorStatus.bMoveComplete:
          sMotorStatus[(int)axis].bMoveComplete = bWrite;
          break;
        case enumSetMotorStatus.bHomeComplete:
          sMotorStatus[(int)axis].bHomeComplete = bWrite;
          break;
        case enumSetMotorStatus.bErrMove:
          sMotorStatus[(int)axis].bErrMove = bWrite;
          break;
        case enumSetMotorStatus.bErrTimeOut:
          sMotorStatus[(int)axis].bErrTimeOut = bWrite;
          break;
        case enumSetMotorStatus.bErrHome:
          sMotorStatus[(int)axis].bErrHome = bWrite;
          break;
        case enumSetMotorStatus.bErrLimitCw:
          sMotorStatus[(int)axis].bErrLimitCw = bWrite;
          break;
        case enumSetMotorStatus.bErrLimitCcw:
          sMotorStatus[(int)axis].bErrLimitCcw = bWrite;
          break;
        case enumSetMotorStatus.bErrLimitSwCw:
          sMotorStatus[(int)axis].bErrLimitSwCw = bWrite;
          break;
        case enumSetMotorStatus.bErrLimitSwCcw:
          sMotorStatus[(int)axis].bErrLimitSwCcw = bWrite;
          break;
        case enumSetMotorStatus.bErrServoAlarm:
          sMotorStatus[(int)axis].bErrServoAlarm = bWrite;
          break;
        case enumSetMotorStatus.bErrTimeOutGap:
          sMotorStatus[(int)axis].bErrTimeOutGap = bWrite;
          break;
        default:
          break;
      }

    } // Set Motor 개별 Status 

    public static void SetMotorStatus(enumSetMotorStatus eSetMotorStatus, enumMotorName axis, double dValue)
    {
      switch (eSetMotorStatus)
      {
        case enumSetMotorStatus.dCurrentPos:
          sMotorStatus[(int)axis].dCurrentPos = dValue;
          break;
      }

    } // Set Motor 개별 Status 

    public static bool Init_Status()
    {
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        dMorotScale[i] = 1000.0;
        switch ((enumMotorName)i)
        {
          case enumMotorName.LE:
            break;
          case enumMotorName.LP:
            break;
          case enumMotorName.BCX:
            break;
          case enumMotorName.BCY:
            break;
          case enumMotorName.ALX:
            break;
          case enumMotorName.ALY:
            break;
          case enumMotorName.X1:
            break;
          case enumMotorName.X2:
            break;
          case enumMotorName.Z1:
            break;
          case enumMotorName.Z2:
            break;
          case enumMotorName.PR1:
            break;
          case enumMotorName.PR2:
            break;
          case enumMotorName.PR3:
            break;
          case enumMotorName.PR4:
            break;
          case enumMotorName.UPX:
            break;
          case enumMotorName.UPY:
            break;
          case enumMotorName.UE1:
            break;
          case enumMotorName.UE2:
            break;
          case enumMotorName.UE3:
            break;
          case enumMotorName.UE4:
            break;
          default:
            break;
        }
      }

      try
      {
        for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
        {
          sMotorStatus[i].iCoaxial = Check_Coaxial(i);             // Use Coaxial
          sMotorStatus[i].iGentry = Check_Gentry(i);               // Use Gentry
          sMotorStatus[i].bSpare = CMotionVo.Check_Empty(i, false);// 보드 배열중 사용하지 않는것 체크           
          sMotorStatus[i].bCompensation = Check_Compensation(i);   // 1D 보정 사용 유무 체크
          sMotorStatus[i].bEncNot = Check_EncNot(i);               // 엔코더 피드백을 받지 않는것 체크

          switch ((enumMotorName)i)
          {
            default:
              sMotorStatus[i].eType = enumMotorType.Ajin;     //Brand And Connect Type
              break;
          } // Init Status
        }

        cMonitor.SetMonitorMotorData(ref sMotorData);
        cMonitor.SetMonitorMotorStatus(ref sMotorStatus);

        Init_Parameter_Motor(); // 저장되어 있는 파일 불러오기 

      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
      return true;
    } // Initialize Motor Status (Set Default)
    public static int Check_Gentry(int index) //갠트리 축사용 여부 리턴 
    {
      int iResult = 0;
      string strName = ((enumMotorName)index).ToString();
      for (int i = 0; i < eGentryMaster.Length; i++)
      {
        if (eGentryMaster[i].ToString().CompareTo(strName) == 0)
        {
          iResult = 1;
          return iResult;
        }
      }

      for (int i = 0; i < eGentrySlave.Length; i++)
      {
        if (eGentrySlave[i].ToString().CompareTo(strName) == 0)
        {
          iResult = 2;
          return iResult;
        }
      }

      return iResult;
    } // Check Gentry
    public static int Check_Coaxial(int index) //한축에서 2개 모터를 사용하는 리턴 
    {
      int iResult = 0;
      string strName = ((enumMotorName)index).ToString();
      for (int i = 0; i < eCoaxialMaster.Length; i++)
      {
        if (eCoaxialMaster[i].ToString().CompareTo(strName) == 0)
        {
          iResult = 1;
          return iResult;
        }
      }

      for (int i = 0; i < eCoaxialSlave.Length; i++)
      {
        if (eCoaxialSlave[i].ToString().CompareTo(strName) == 0)
        {
          iResult = 2;
          return iResult;
        }
      }

      return iResult;
    } // Check Coaxial
    public static bool Check_Empty(object value, bool defaultReturnType) // 배열에서 모터 미사용인지 리턴 
    {
      Type type = value.GetType();
      enumMotorName eType;
      bool bResult = defaultReturnType;

      if (type == typeof(int))
      {
        if (0 > (int)value || Enum.GetNames(typeof(enumMotorName)).Length <= (int)value)
        {
          return defaultReturnType;
        }
        eType = (enumMotorName)value;
        for (int i = 0; i < eEmptyMotor.Length; i++)
        {
          if (eEmptyMotor[i] == eType)
          {
            bResult = !bResult;
            break;
          }
        }
      }
      else if (type == typeof(string))
      {
        for (int i = 0; i < eEmptyMotor.Length; i++)
        {
          if (((enumMotorName)i).ToString().CompareTo(value.ToString()) == 0)
          {
            bResult = !bResult;
            break;
          }
        }
      }
      else if (type == typeof(double))
      {
        double dTemp = (double)value;
        if (dTemp != 0.0)
        {
          dTemp = dTemp / 1.0;
        }
        if (0 > (int)dTemp || Enum.GetNames(typeof(enumMotorName)).Length <= (int)dTemp)
        {
          return defaultReturnType;
        }

        eType = (enumMotorName)dTemp;
        for (int i = 0; i < eEmptyMotor.Length; i++)
        {
          if (eEmptyMotor[i] == eType)
          {
            bResult = !bResult;
            break;
          }
        }
      }
      else if (type == typeof(enumMotorName))
      {
        for (int i = 0; i < eEmptyMotor.Length; i++)
        {
          if (eEmptyMotor[i] == (enumMotorName)value)
          {
            bResult = !bResult;
            break;
          }
        }
      }
      else
      {
        return defaultReturnType;
      }
      return bResult;
    }
    public static bool Check_Compensation(int index) // 1D 보정 사용 유무 체크
    {
      bool bResult = false;
      string strName = ((enumMotorName)index).ToString();
      for (int i = 0; i < eCompensation.Length; i++)
      {
        if (eCompensation[i].ToString().CompareTo(strName) == 0)
        {
          bResult = true;
          break;
        }
      }

      return bResult;
    }
    public static bool Check_EncNot(int index) // 엔코더 피드백을 받지 않는것 체크
    {
      bool bResult = false;
      string strName = ((enumMotorName)index).ToString();
      for (int i = 0; i < eEncNot.Length; i++)
      {
        if (eEncNot[i].ToString().CompareTo(strName) == 0)
        {
          bResult = true;
          break;
        }
      }

      return bResult;
    }
    public static bool Init_Parameter_Motor() // 저장되어 있는 파일 불러오기 
    {
      try
      {
        Load_Parameter_Motor_Setting(); // Load Motor Data 기본 파라미터
        Load_Parameter_Motor_Moving(); // Load Motor Data 구동시 필요 
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
      return true;
    }
    public static structMData GetMotorData(enumMotorName name, int pos)
    {
      return sMotorData[(int)name, (int)pos];
    } //Get Motor Data
    public static bool SetMotorData(enumMotorName name, int pos, structMData data)
    {
      try
      {
        sMotorData[(int)name, (int)pos] = data;
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
      return true;
    } // Set Motor Data
    public static bool Save_Parameter_Motor_Moving()  // Save Motor Data 구동시 필요 
    {

      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_MOTION;
      string strSection = "";
      string strKey = "";
      structMData sMotor = new structMData();

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        for (int j = 0; j < cMotorPosition; j++)
        {
          try
          {
            sMotor = GetMotorData((enumMotorName)i, j);
            strSection = string.Format("{0}", ((enumMotorName)i).ToString());
            strKey = string.Format("{0}_", (j).ToString());
            if (0 == WritePrivateProfileString(strSection, strKey + "Position", sMotor.dPosition.ToString(), strPath)) { return false; };
            if (0 == WritePrivateProfileString(strSection, strKey + "Speed", sMotor.dSpeed.ToString(), strPath)) { return false; };
            if (0 == WritePrivateProfileString(strSection, strKey + "Acc", sMotor.dAcc.ToString(), strPath)) { return false; };
            if (0 == WritePrivateProfileString(strSection, strKey + "Dcc", sMotor.dDcc.ToString(), strPath)) { return false; };
            if (0 == WritePrivateProfileString(strSection, strKey + "TimeOut", sMotor.dTimeOut.ToString(), strPath)) { return false; };
            if (0 == WritePrivateProfileString(strSection, strKey + "Delay", sMotor.dDelay.ToString(), strPath)) { return false; };
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
        }
      }
      return true;
    }
    public static bool Load_Parameter_Motor_Moving() // Load Motor Data 구동시 필요 
    {
      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_MOTION;
      string strSection = "";
      string strKey = "";
      int iSize = 32768;
      structMData sMotor = new structMData();
      StringBuilder sbBuffer = new StringBuilder(iSize);

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        for (int j = 0; j < cMotorPosition; j++)
        {
          try
          {
            strSection = string.Format("{0}", ((enumMotorName)i).ToString());
            strKey = string.Format("{0}_", (j).ToString());
            GetPrivateProfileString(strSection, strKey + "Postion", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dPosition = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotor.dPosition = 10;
            GetPrivateProfileString(strSection, strKey + "Speed", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dSpeed = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotor.dSpeed = 10;
            GetPrivateProfileString(strSection, strKey + "Acc", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dAcc = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotor.dAcc = 1000; // 가속율 Sec = (최고속도 / 가속도) * 구동속도  
            GetPrivateProfileString(strSection, strKey + "Dcc", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dDcc = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotor.dDcc = 1000; // 가속율 Sec = (최고속도 / 가속도) * 구동속도  
            GetPrivateProfileString(strSection, strKey + "TimeOut", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dTimeOut = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotor.dTimeOut = 200000; //200초  
            GetPrivateProfileString(strSection, strKey + "Delay", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotor.dDelay = Convert.ToDouble(sbBuffer.ToString());
            }
            sMotor.dDelay = 0;
            SetMotorData((enumMotorName)i, j, sMotor);
          }
          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
        }
      }

      if (!File.Exists(strPath)) //화일이 없으면 디폴트값으로 넣어준다 
      {
        Save_Parameter_Motor_Moving();
      }

      return true;
    }
    public static bool Save_Parameter_Motor_Setting() // Save Motor Data 기본 파라미터
    {
      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_MOTION_SETTING;
      string strSection = "";
      string strKey = "";

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        try
        {
          strSection = string.Format("{0}", ((enumMotorName)i).ToString());
          if (0 == WritePrivateProfileString(strSection, strKey + "MotorSkip", sMotorStatus[i].bMotorSkip.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitSoftCw", sMotorStatus[i].dLimitSoftCw.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitSoftCcw", sMotorStatus[i].dLimitSoftCcw.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitSpeed", sMotorStatus[i].dLimitSpeed.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitJogSpd", sMotorStatus[i].dLimitJogSpd.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitScale", sMotorStatus[i].dLimitScale.ToString(), strPath)) { return false; };
          if (0 == WritePrivateProfileString(strSection, strKey + "LimitGap", sMotorStatus[i].dLimitGap.ToString(), strPath)) { return false; };
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          return false;
        }
      }
      return true;
    }
    public static bool Load_Parameter_Motor_Setting() // Load Motor Data 기본 파라미터
    {
      string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_MOTION_SETTING;
      string strSection = "";
      string strKey = "";
      int iMotorSkip = 0;

      int iSize = 32768;
      StringBuilder sbBuffer = new StringBuilder(iSize);

      if (!Directory.Exists(CVo.SYSTEM_PATH))
      {
        Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        for (int j = 0; j < cMotorPosition; j++)
        {
          try
          {
            strSection = string.Format("{0}", ((enumMotorName)i).ToString());

            GetPrivateProfileString(strSection, strKey + "MotorSkip", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].bMotorSkip = Convert.ToBoolean(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].bMotorSkip = false;
            if (sMotorStatus[i].bMotorSkip == true)
              iMotorSkip++;
            GetPrivateProfileString(strSection, strKey + "LimitSoftCw", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitSoftCw = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitSoftCw = 400;
            GetPrivateProfileString(strSection, strKey + "LimitSoftCcw", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitSoftCcw = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitSoftCcw = -10;
            GetPrivateProfileString(strSection, strKey + "LimitSpeed", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitSpeed = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitSpeed = 500;
            GetPrivateProfileString(strSection, strKey + "LimitJogSpd", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitJogSpd = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitJogSpd = 50;
            GetPrivateProfileString(strSection, strKey + "LimitScale", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitScale = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitScale = 1000;
            GetPrivateProfileString(strSection, strKey + "LimitGap", "(NONE)", sbBuffer, iSize, strPath);
            if (sbBuffer.ToString().CompareTo("(NONE)") != 0)
            {
              sMotorStatus[i].dLimitGap = Convert.ToDouble(sbBuffer.ToString());
            }
            else
              sMotorStatus[i].dLimitGap = 0;

          }

          catch (Exception ex)
          {
            CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
            return false;
          }
        }
      }

      if (!File.Exists(strPath)) //화일이 없으면 밑에 디폴트값으로 넣어준다 
      {
        Save_Parameter_Motor_Setting();
      }

      if (iMotorSkip > 0)
      {
        MessageBox.Show("Motor  " + iMotorSkip.ToString() + " Skip !");
      }
      return true;
    }
  }
}
