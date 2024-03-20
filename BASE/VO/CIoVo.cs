using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.MASTER;
using BASE.FORM;
using BASE.MODULE.PLC;
using BASE.MODULE.MOTION;

public struct structIo
{
  public string strName;
  public bool bOriginSignal;
  public bool bContactSetting; // false = A, true = B
}

namespace BASE.VO
{

  public static class CIoVo
  {

    #region Buffer
    // Read Bit Memory(B)
    public static structIo[] sInput = new structIo[Enum.GetNames(typeof(enumBitInput)).Length];
    public static bool[] abFlag_Running = new bool[Enum.GetNames(typeof(enumFlagRunning)).Length];
    public static bool[] abFlag_Complete = new bool[Enum.GetNames(typeof(enumFlagComplete)).Length];
    public static bool[] abError = new bool[Enum.GetNames(typeof(enumError)).Length];

    // Read Data Memory(DW)
    public static int[] aiAD_Data = new int[Enum.GetNames(typeof(enumWR_AD_Data)).Length];
    public static int[] aiCurPos = new int[Enum.GetNames(typeof(enumWR_CurPos)).Length];
    public static int[] aiCurSpd = new int[Enum.GetNames(typeof(enumWR_CurSpd)).Length];
    public static int[] aiAlarmCode = new int[Enum.GetNames(typeof(enumWR_AlarmCode)).Length];
    public static int[] aiCounter = new int[Enum.GetNames(typeof(enumWR_Counter)).Length];
    public static int[] aiEtc = new int[Enum.GetNames(typeof(enumWR_Etc)).Length];

    // Write Bit Memory(B)
    public static bool[] abFlag_Out = new bool[Enum.GetNames(typeof(enumFlagOut)).Length];
    public static structIo[] sOutput = new structIo[Enum.GetNames(typeof(enumBitOutput)).Length];

    // Write Data Memory(DW)
    public static int[] aiTeaching_Jog_Data = new int[Enum.GetNames(typeof(enumWW_Teaching_Jog_Data)).Length];
    public static int[] aiLE_Align_Ready_Data = new int[Enum.GetNames(typeof(enumWW_LE_Align_Ready)).Length];
    public static int[] aiUE1_Align_Ready_Data = new int[Enum.GetNames(typeof(enumWW_UE1_Align_Ready)).Length];
    public static int[] aiUE2_Align_Ready_Data = new int[Enum.GetNames(typeof(enumWW_UE2_Align_Ready)).Length];
    public static int[] aiUE3_Align_Ready_Data = new int[Enum.GetNames(typeof(enumWW_UE3_Align_Ready)).Length];
    public static int[] aiUE4_Align_Ready_Data = new int[Enum.GetNames(typeof(enumWW_UE4_Align_Ready)).Length];
    public static int[] aiLE_to_LP_Data = new int[Enum.GetNames(typeof(enumWW_LE_to_LP)).Length];
    public static int[] aiLP_to_AL_Data = new int[Enum.GetNames(typeof(enumWW_LP_to_AL)).Length];
    public static int[] aiAlign_Data = new int[Enum.GetNames(typeof(enumWW_Align)).Length];
    public static int[] aiAL_to_LP_Data = new int[Enum.GetNames(typeof(enumWW_AL_to_LP)).Length];
    public static int[] aiLP_to_Stage1_Data = new int[Enum.GetNames(typeof(enumWW_LP_to_Stage1)).Length];
    public static int[] aiLP_to_Stage2_Data = new int[Enum.GetNames(typeof(enumWW_LP_to_Stage2)).Length];
    public static int[] aiStage1_Zero_Data = new int[Enum.GetNames(typeof(enumWW_Stage1_Zero)).Length];
    public static int[] aiStage2_Zero_Data = new int[Enum.GetNames(typeof(enumWW_Stage2_Zero)).Length];
    public static int[] aiStage1_Measure_Data = new int[Enum.GetNames(typeof(enumWW_Stage1_Measure)).Length];
    public static int[] aiStage2_Measure_Data = new int[Enum.GetNames(typeof(enumWW_Stage2_Measure)).Length];
    public static int[] aiStage1_to_UL_Data = new int[Enum.GetNames(typeof(enumWW_Stage1_to_UL)).Length];
    public static int[] aiStage2_to_UL_Data = new int[Enum.GetNames(typeof(enumWW_Stage2_to_UL)).Length];
    public static int[] aiUL_to_UE_Data = new int[Enum.GetNames(typeof(enumWW_UL_to_UE)).Length];
    public static int[] aiStage1_Clean_Data = new int[Enum.GetNames(typeof(enumWW_Stage1_Clean)).Length];
    public static int[] aiStage2_Clean_Data = new int[Enum.GetNames(typeof(enumWW_Stage2_Clean)).Length];
    public static int[] aiEtc_Data = new int[Enum.GetNames(typeof(enumWW_Etc)).Length];
    public static int[] aiErrorValue_Allow_Data = new int[Enum.GetNames(typeof(enumWW_ErrorValue_Allow_Data)).Length];
    public static int[] aiSelect_Section_Data = new int[Enum.GetNames(typeof(enumWW_Select_Section)).Length];

    #endregion

    #region Access PLC Data
    ////////////////////////////////////////////
    // 이곳을 통해 IO 접근 한다.
    ////////////////////////////////////////////
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    #region Get
    // Read Bit Memory(B)
    public static structIo GetInput_Org(enumBitInput num)
    {
      return sInput[(int)num];
    }
    public static bool Get_RB_Input(enumBitInput num)
    {
      return (sInput[(int)num].bOriginSignal ^ sInput[(int)num].bContactSetting);
    }
    public static bool Get_RB_RunningFlag(enumFlagRunning num)
    {
      return abFlag_Running[(int)num];
    }
    public static bool Get_RB_CompleteFlag(enumFlagComplete num)
    {
      return abFlag_Complete[(int)num];
    }
    public static bool Get_RB_Error(enumError num)
    {
      return abError[(int)num];    
    }

    // Read Data Memory(DW)
    public static int Get_RW_AD(enumWR_AD_Data num)
    {
      return aiAD_Data[(int)num];
    }
    public static int Get_RW_CurPos(enumWR_CurPos num)
    {
      return aiCurPos[(int)num];
    }
    public static int Get_RW_CurSpd(enumWR_CurSpd num)
    {
      return aiCurSpd[(int)num];
    }
    public static int Get_RW_AlarmCode(enumWR_AlarmCode num)
    {
      return aiAlarmCode[(int)num];
    }
    public static int Get_RW_Counter(enumWR_Counter num)
    {
      return aiCounter[(int)num];
    }
    public static int Get_RW_Etc(enumWR_Etc num)
    {
      return aiEtc[(int)num];
    }

    // Read WriteBit Memory(B)
    public static bool Get_WB_OutFlag(enumFlagOut num)
    {
      return abFlag_Out[(int)num];
    }
    public static structIo GetOutput_Org(enumBitOutput num)
    {
      return sOutput[(int)num];
    }
    public static bool Get_WB_Output(enumBitOutput num)
    {
      return sOutput[(int)num].bOriginSignal;
    }

    // Read WriteData Memory(DW)
    public static int Get_WW_Teaching_Jog(enumWW_Teaching_Jog_Data num) { return aiTeaching_Jog_Data[(int)num]; }
    public static int Get_WW_LE_Align_Ready(enumWW_LE_Align_Ready num) { return aiLE_Align_Ready_Data[(int)num]; }
    public static int Get_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready num) { return aiUE1_Align_Ready_Data[(int)num]; }
    public static int Get_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready num) { return aiUE2_Align_Ready_Data[(int)num]; }
    public static int Get_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready num) { return aiUE3_Align_Ready_Data[(int)num]; }
    public static int Get_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready num) { return aiUE4_Align_Ready_Data[(int)num]; }
    public static int Get_WW_LE_to_LP(enumWW_LE_to_LP num) { return aiLE_to_LP_Data[(int)num]; }
    public static int Get_WW_LP_to_AL(enumWW_LP_to_AL num) { return aiLP_to_AL_Data[(int)num]; }
    public static int Get_WW_Align(enumWW_Align num) { return aiAlign_Data[(int)num]; }
    public static int Get_WW_AL_to_LP(enumWW_AL_to_LP num) { return aiAL_to_LP_Data[(int)num]; }
    public static int Get_WW_LP_to_Stage1(enumWW_LP_to_Stage1 num) { return aiLP_to_Stage1_Data[(int)num]; }
    public static int Get_WW_LP_to_Stage2(enumWW_LP_to_Stage2 num) { return aiLP_to_Stage2_Data[(int)num]; }
    public static int Get_WW_Stage1_Zero(enumWW_Stage1_Zero num) { return aiStage1_Zero_Data[(int)num]; }
    public static int Get_WW_Stage2_Zero(enumWW_Stage2_Zero num) { return aiStage2_Zero_Data[(int)num]; }
    public static int Get_WW_Stage1_Measure(enumWW_Stage1_Measure num) { return aiStage1_Measure_Data[(int)num]; }
    public static int Get_WW_Stage2_Measure(enumWW_Stage2_Measure num) { return aiStage2_Measure_Data[(int)num]; }
    public static int Get_WW_Stage1_to_UL(enumWW_Stage1_to_UL num) { return aiStage1_to_UL_Data[(int)num]; }
    public static int Get_WW_Stage2_to_UL(enumWW_Stage2_to_UL num) { return aiStage2_to_UL_Data[(int)num]; }
    public static int Get_WW_UL_to_UE(enumWW_UL_to_UE num) { return aiUL_to_UE_Data[(int)num]; }
    public static int Get_WW_Stage1_Clean(enumWW_Stage1_Clean num) { return aiStage1_Clean_Data[(int)num]; }
    public static int Get_WW_Stage2_Clean(enumWW_Stage2_Clean num) { return aiStage2_Clean_Data[(int)num]; }
    public static int Get_WW_Etc(enumWW_Etc num) { return aiEtc_Data[(int)num]; }
    public static int Get_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data num) { return aiErrorValue_Allow_Data[(int)num]; }
    public static int Get_WW_Select_Section(enumWW_Select_Section num) { return aiSelect_Section_Data[(int)num]; }

    #endregion

    #region Set
    public static bool Set_Address_Bit(string add, bool on)
    {
      return CMaster.cPlc.Set_Address_Bit(add, on);
    }

    public static bool Set_Address_Word(string add, ref int data)
    {
      return CMaster.cPlc.Set_Address_Word(add, ref data);
    }

    public static bool Get_Address_Bit(string add)
    {
      return CMaster.cPlc.Get_Address_Bit(add);
    }

    public static void SetInput_Org(enumBitInput num, structIo io)
    {
      sInput[(int)num] = io;
    }
    public static void SetOutput_Org(enumBitOutput num, structIo io)
    {
      sOutput[(int)num] = io;
    }

    // Send WriteBit Memory(B)
    public static bool Set_WB_OutFlag(enumFlagOut num, bool on)
    {
      return CMaster.cPlc.Set_W_OutFlag(num, on);
    }
    public static bool Set_WB_Output(enumBitOutput num, bool on)
    {
      return CMaster.cPlc.Set_W_OutBit(num, on);
    }

    public static bool Set_WA_Teaching_Jog(int[] data) { return CMaster.cPlc.Set_WA_Teaching_Jog_Data(data); }
    public static bool Set_WA_LE_Align_Ready(int[] data) { return CMaster.cPlc.Set_WA_LE_Align_Ready_Data(data); }
    public static bool Set_WA_UE1_Align_Ready(int[] data) { return CMaster.cPlc.Set_WA_UE1_Align_Ready_Data(data); }
    public static bool Set_WA_UE2_Align_Ready(int[] data) { return CMaster.cPlc.Set_WA_UE2_Align_Ready_Data(data); }
    public static bool Set_WA_UE3_Align_Ready(int[] data) { return CMaster.cPlc.Set_WA_UE3_Align_Ready_Data(data); }
    public static bool Set_WA_UE4_Align_Ready(int[] data) { return CMaster.cPlc.Set_WA_UE4_Align_Ready_Data(data); }
    public static bool Set_WA_LE_to_LP(int[] data) { return CMaster.cPlc.Set_WA_LE_to_LP_Data(data); }
    public static bool Set_WA_LP_to_AL(int[] data) { return CMaster.cPlc.Set_WA_LP_to_AL_Data(data); }
    public static bool Set_WA_Align(int[] data) { return CMaster.cPlc.Set_WA_Align_Data(data); }
    public static bool Set_WA_AL_to_LP(int[] data) { return CMaster.cPlc.Set_WA_AL_to_LP_Data(data); }
    public static bool Set_WA_LP_to_Stage1(int[] data) { return CMaster.cPlc.Set_WA_LP_to_Stage1_Data(data); }
    public static bool Set_WA_LP_to_Stage2(int[] data) { return CMaster.cPlc.Set_WA_LP_to_Stage2_Data(data); }
    public static bool Set_WA_Stage1_Zero(int[] data) { return CMaster.cPlc.Set_WA_Stage1_Zero_Data(data); }
    public static bool Set_WA_Stage2_Zero(int[] data) { return CMaster.cPlc.Set_WA_Stage2_Zero_Data(data); }
    public static bool Set_WA_Stage1_Measure(int[] data) { return CMaster.cPlc.Set_WA_Stage1_Measure_Data(data); }
    public static bool Set_WA_Stage2_Measure(int[] data) { return CMaster.cPlc.Set_WA_Stage2_Measure_Data(data); }
    public static bool Set_WA_Stage1_to_UL(int[] data) { return CMaster.cPlc.Set_WA_Stage1_to_UL_Data(data); }
    public static bool Set_WA_Stage2_to_UL(int[] data) { return CMaster.cPlc.Set_WA_Stage2_to_UL_Data(data); }
    public static bool Set_WA_UL_to_UE(int[] data) { return CMaster.cPlc.Set_WA_UL_to_UE_Data(data); }
    public static bool Set_WA_Stage1_Clean(int[] data) { return CMaster.cPlc.Set_WA_Stage1_Clean_Data(data); }
    public static bool Set_WA_Stage2_Clean(int[] data) { return CMaster.cPlc.Set_WA_Stage2_Clean_Data(data); }
    public static bool Set_WA_Etc(int[] data) { return CMaster.cPlc.Set_WA_Etc_Data(data); }
    public static bool Set_WA_ErrorValue_Allow(int[] data) { return CMaster.cPlc.Set_WA_ErrorValue_Allow_Data(data); }
    public static bool Set_WA_Select_Section(int[] data) { return CMaster.cPlc.Set_WA_Select_Section_Data(data); }

    // Send WriteData Memory(DW)
    public static bool Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data num, int data)
    {
      return CMaster.cPlc.Set_W_Teaching_Jog_Data(num, data);
    }
    public static bool Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready num, int data)
    {
      return CMaster.cPlc.Set_W_LE_Align_Ready_Data(num, data);
    }
    public static bool Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready num, int data)
    {
      return CMaster.cPlc.Set_W_UE1_Align_Ready_Data(num, data);
    }
    public static bool Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready num, int data)
    {
      return CMaster.cPlc.Set_W_UE2_Align_Ready_Data(num, data);
    }
    public static bool Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready num, int data)
    {
      return CMaster.cPlc.Set_W_UE3_Align_Ready_Data(num, data);
    }
    public static bool Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready num, int data)
    {
      return CMaster.cPlc.Set_W_UE4_Align_Ready_Data(num, data);
    }
    public static bool Set_WW_LE_to_LP(enumWW_LE_to_LP num, int data)
    {
      return CMaster.cPlc.Set_W_LE_to_LP_Data(num, data);
    }
    public static bool Set_WW_LP_to_AL(enumWW_LP_to_AL num, int data)
    {
      return CMaster.cPlc.Set_W_LP_to_AL_Data(num, data);
    }
    public static bool Set_WW_Align(enumWW_Align num, int data)
    {
      return CMaster.cPlc.Set_W_Align_Data(num, data);
    }
    public static bool Set_WW_AL_to_LP(enumWW_AL_to_LP num, int data)
    {
      return CMaster.cPlc.Set_W_AL_to_LP_Data(num, data);
    }
    public static bool Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1 num, int data)
    {
      return CMaster.cPlc.Set_W_LP_to_Stage1_Data(num, data);
    }
    public static bool Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2 num, int data)
    {
      return CMaster.cPlc.Set_W_LP_to_Stage2_Data(num, data);
    }
    public static bool Set_WW_Stage1_Zero(enumWW_Stage1_Zero num, int data)
    {
      return CMaster.cPlc.Set_W_Stage1_Zero_Data(num, data);
    }
    public static bool Set_WW_Stage2_Zero(enumWW_Stage2_Zero num, int data)
    {
      return CMaster.cPlc.Set_W_Stage2_Zero_Data(num, data);
    }
    public static bool Set_WW_Stage1_Measure(enumWW_Stage1_Measure num, int data)
    {
      return CMaster.cPlc.Set_W_Stage1_Measure_Data(num, data);
    }
    public static bool Set_WW_Stage2_Measure(enumWW_Stage2_Measure num, int data)
    {
      return CMaster.cPlc.Set_W_Stage2_Measure_Data(num, data);
    }
    public static bool Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL num, int data)
    {
      return CMaster.cPlc.Set_W_Stage1_to_UL_Data(num, data);
    }
    public static bool Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL num, int data)
    {
      return CMaster.cPlc.Set_W_Stage2_to_UL_Data(num, data);
    }
    public static bool Set_WW_UL_to_UE(enumWW_UL_to_UE num, int data)
    {
      return CMaster.cPlc.Set_W_UL_to_UE_Data(num, data);
    }
    public static bool Set_WW_Stage1_Clean(enumWW_Stage1_Clean num, int data)
    {
      return CMaster.cPlc.Set_W_Stage1_Clean_Data(num, data);
    }
    public static bool Set_WW_Stage2_Clean(enumWW_Stage2_Clean num, int data)
    {
      return CMaster.cPlc.Set_W_Stage2_Clean_Data(num, data);
    }
    public static bool Set_WW_Etc(enumWW_Etc num, int data)
    {
      return CMaster.cPlc.Set_W_Etc_Data(num, data);
    }
    public static bool Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data num, int data)
    {
      return CMaster.cPlc.Set_W_ErrorValue_Allow_Data(num, data);
    }
    public static bool Set_WW_Select_Section(enumWW_Select_Section num, int data)
    {
      return CMaster.cPlc.Set_W_Select_Section_Data(num, data);
    }
    #endregion

    #region Send Parameter
    // 실시간으로 PLC에 전달되어 있어야 하는 데이터들을 전송한다.
    public static void Send_Init() // 프로그램 시작시만 사용
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      sMotor[(int)enumMotorName.LE].dLimitSoftCw = cSys.dLE_LimitCw;
      sMotor[(int)enumMotorName.LP].dLimitSoftCw = cSys.dLP_LimitCw;
      sMotor[(int)enumMotorName.BCX].dLimitSoftCw = cSys.dBCX_LimitCw;
      sMotor[(int)enumMotorName.BCY].dLimitSoftCw = cSys.dBCY_LimitCw;
      sMotor[(int)enumMotorName.ALX].dLimitSoftCw = cSys.dALX_LimitCw;
      sMotor[(int)enumMotorName.ALY].dLimitSoftCw = cSys.dALY_LimitCw;
      sMotor[(int)enumMotorName.X1].dLimitSoftCw = cSys.dX1_LimitCw;
      sMotor[(int)enumMotorName.X2].dLimitSoftCw = cSys.dX2_LimitCw;
      sMotor[(int)enumMotorName.Z1].dLimitSoftCw = cSys.dZ1_LimitCw;
      sMotor[(int)enumMotorName.Z2].dLimitSoftCw = cSys.dZ2_LimitCw;
      sMotor[(int)enumMotorName.PR1].dLimitSoftCw = cSys.dPR1_LimitCw;
      sMotor[(int)enumMotorName.PR2].dLimitSoftCw = cSys.dPR2_LimitCw;
      sMotor[(int)enumMotorName.PR3].dLimitSoftCw = cSys.dPR3_LimitCw;
      sMotor[(int)enumMotorName.PR4].dLimitSoftCw = cSys.dPR4_LimitCw;
      sMotor[(int)enumMotorName.UPX].dLimitSoftCw = cSys.dUPX_LimitCw;
      sMotor[(int)enumMotorName.UPY].dLimitSoftCw = cSys.dUPY_LimitCw;
      sMotor[(int)enumMotorName.UE1].dLimitSoftCw = cSys.dUE1_LimitCw;
      sMotor[(int)enumMotorName.UE2].dLimitSoftCw = cSys.dUE2_LimitCw;
      sMotor[(int)enumMotorName.UE3].dLimitSoftCw = cSys.dUE3_LimitCw;
      sMotor[(int)enumMotorName.UE4].dLimitSoftCw = cSys.dUE4_LimitCw;

      sMotor[(int)enumMotorName.LE].dLimitSoftCcw = cSys.dLE_LimitCcw;
      sMotor[(int)enumMotorName.LP].dLimitSoftCcw = cSys.dLP_LimitCcw;
      sMotor[(int)enumMotorName.BCX].dLimitSoftCcw = cSys.dBCX_LimitCcw;
      sMotor[(int)enumMotorName.BCY].dLimitSoftCcw = cSys.dBCY_LimitCcw;
      sMotor[(int)enumMotorName.ALX].dLimitSoftCcw = cSys.dALX_LimitCcw;
      sMotor[(int)enumMotorName.ALY].dLimitSoftCcw = cSys.dALY_LimitCcw;
      sMotor[(int)enumMotorName.X1].dLimitSoftCcw = cSys.dX1_LimitCcw;
      sMotor[(int)enumMotorName.X2].dLimitSoftCcw = cSys.dX2_LimitCcw;
      sMotor[(int)enumMotorName.Z1].dLimitSoftCcw = cSys.dZ1_LimitCcw;
      sMotor[(int)enumMotorName.Z2].dLimitSoftCcw = cSys.dZ2_LimitCcw;
      sMotor[(int)enumMotorName.PR1].dLimitSoftCcw = cSys.dPR1_LimitCcw;
      sMotor[(int)enumMotorName.PR2].dLimitSoftCcw = cSys.dPR2_LimitCcw;
      sMotor[(int)enumMotorName.PR3].dLimitSoftCcw = cSys.dPR3_LimitCcw;
      sMotor[(int)enumMotorName.PR4].dLimitSoftCcw = cSys.dPR4_LimitCcw;
      sMotor[(int)enumMotorName.UPX].dLimitSoftCcw = cSys.dUPX_LimitCcw;
      sMotor[(int)enumMotorName.UPY].dLimitSoftCcw = cSys.dUPY_LimitCcw;
      sMotor[(int)enumMotorName.UE1].dLimitSoftCcw = cSys.dUE1_LimitCcw;
      sMotor[(int)enumMotorName.UE2].dLimitSoftCcw = cSys.dUE2_LimitCcw;
      sMotor[(int)enumMotorName.UE3].dLimitSoftCcw = cSys.dUE3_LimitCcw;
      sMotor[(int)enumMotorName.UE4].dLimitSoftCcw = cSys.dUE4_LimitCcw;

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        CMotionVo.SetMotorStatus(sMotor[i], (enumMotorName)i);
      }

      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1000_LE_Teaching_Spd, (int)(cSys.dLE_Normal_Spd * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1002_LE_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1004_UE1_Teaching_Spd, (int)(cSys.dUE1_Normal_Spd * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1006_UE1_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1008_UE2_Teaching_Spd, (int)(cSys.dUE2_Normal_Spd * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100A_UE2_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100C_UE3_Teaching_Spd, (int)(cSys.dUE3_Normal_Spd * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W100E_UE3_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1010_UE4_Teaching_Spd, (int)(cSys.dUE4_Normal_Spd * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1012_UE4_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1014_BCX_Teaching_Spd, (int)(cSys.dBCX_Normal_Spd * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1016_BCX_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1018_BCY_Teaching_Spd, (int)(cSys.dBCY_Normal_Spd * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101A_BCY_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101C_LP_Teaching_Spd, (int)(cSys.dLP_Normal_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W101E_LP_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1020_UPX_Teaching_Spd, (int)(cSys.dUPX_Normal_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1022_UPX_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1024_UPY_Teaching_Spd, (int)(cSys.dUPY_Normal_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1026_UPY_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1030_ALX_Teaching_Spd, (int)(cSys.dALX_Normal_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1032_ALX_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1034_ALY_Teaching_Spd, (int)(cSys.dALY_Normal_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1036_ALY_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1038_X1_Teaching_Spd, (int)(cSys.dX1_Normal_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103A_X1_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103C_X2_Teaching_Spd, (int)(cSys.dX2_Normal_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W103E_X2_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1040_PR1_Teaching_Spd, (int)(cSys.dPR1_Normal_Spd * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1042_PR1_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1044_PR2_Teaching_Spd, (int)(cSys.dPR2_Normal_Spd * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1046_PR2_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1048_PR3_Teaching_Spd, (int)(cSys.dPR3_Normal_Spd * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104A_PR3_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104C_PR4_Teaching_Spd, (int)(cSys.dPR4_Normal_Spd * sMotor[(int)enumMotorName.PR4].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W104E_PR4_Teaching_Pos, (int)(0 * sMotor[(int)enumMotorName.PR4].dLimitScale));

      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1080_LE_Jog_Spd, (int)(cSys.dLE_Low_Spd * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1082_UE1_Jog_Spd, (int)(cSys.dUE1_Low_Spd * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1084_UE2_Jog_Spd, (int)(cSys.dUE2_Low_Spd * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1086_UE3_Jog_Spd, (int)(cSys.dUE3_Low_Spd * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1088_UE4_Jog_Spd, (int)(cSys.dUE4_Low_Spd * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108A_BCX_Jog_Spd, (int)(cSys.dBCX_Low_Spd * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108C_BCY_Jog_Spd, (int)(cSys.dBCY_Low_Spd * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W108E_LP_Jog_Spd, (int)(cSys.dLP_Low_Spd * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1090_UPX_Jog_Spd, (int)(cSys.dUPX_Low_Spd * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1092_UPY_Jog_Spd, (int)(cSys.dUPY_Low_Spd * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1094_Z1_Jog_Spd, (int)(cSys.dZ1_Low_Spd * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1096_Z2_Jog_Spd, (int)(cSys.dZ2_Low_Spd * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1098_ALX_Jog_Spd, (int)(cSys.dALX_Low_Spd * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109A_ALY_Jog_Spd, (int)(cSys.dALY_Low_Spd * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109C_X1_Jog_Spd, (int)(cSys.dX2_Low_Spd * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W109E_X2_Jog_Spd, (int)(cSys.dX1_Low_Spd * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A0_PR1_Jog_Spd, (int)(cSys.dPR1_Low_Spd * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A2_PR2_Jog_Spd, (int)(cSys.dPR2_Low_Spd * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A4_PR3_Jog_Spd, (int)(cSys.dPR3_Low_Spd * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W10A6_PR4_Jog_Spd, (int)(cSys.dPR4_Low_Spd * sMotor[(int)enumMotorName.PR4].dLimitScale));

      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C0_LE_Scan_Start_Pos, (int)(cSys.dLE_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C2_LE_Scan_Complete_Pos, (int)(cSys.dLE_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C4_LE_Cassette_Wait_Pos, (int)(cSys.dLE_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C6_BCX_Ready_Pos, (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10C8_BCY_Ready_Pos, (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CA_BCX_Read_Pos, (int)(cRcp.dPCB_Barcode_BCX_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CC_BCY_Read_Pos, (int)(cRcp.dPCB_Barcode_BCY_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10D8_LE_Spd, (int)(cSys.dLE_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DA_LE_Scan_Spd, (int)(cSys.dLE_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DC_BCX_Spd, (int)(cSys.dBCX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DE_BCY_Spd, (int)(cSys.dBCY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));

      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10E0_UE1_Scan_Start_Pos, (int)(cSys.dUE1_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10E2_UE1_Scan_Complete_Pos, (int)(cSys.dUE1_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10E4_UE1_Cassete_Wait_Pos, (int)(cSys.dUE1_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10F8_UE1_Spd, (int)(cSys.dUE1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10FA_UE1_Scan_Spd, (int)(cSys.dUE1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));

      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W1100_UE2_Scan_Start_Pos, (int)(cSys.dUE2_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W1102_UE2_Scan_Complete_Pos, (int)(cSys.dUE2_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W1104_UE2_Cassete_Wait_Pos, (int)(cSys.dUE2_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W1118_UE2_Spd, (int)(cSys.dUE2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W111A_UE2_Scan_Spd, (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));

      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W1120_UE3_Scan_Start_Pos, (int)(cSys.dUE3_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W1122_UE3_Scan_Complete_Pos, (int)(cSys.dUE3_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W1124_UE3_Cassete_Wait_Pos, (int)(cSys.dUE3_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W1138_UE3_Spd, (int)(cSys.dUE3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W113A_UE3_Scan_Spd, (int)(cSys.dUE3_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));

      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W1140_UE4_Scan_Start_Pos, (int)(cSys.dUE4_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W1142_UE4_Scan_Complete_Pos, (int)(cSys.dUE4_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W1144_UE4_Cassete_Wait_Pos, (int)(cSys.dUE4_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W1158_UE4_Spd, (int)(cSys.dUE4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W115A_UE4_Scan_Spd, (int)(cSys.dUE4_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));

      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1160_LP_LE_Pos, (int)(cSys.dLP_LE_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1164_BCX_Ready_Pos, (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1166_BCY_Ready_Pos, (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W116C_LE_Down_Offset_Rel, (int)(cSys.dLE_DownOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1172_LP_Shake_Count, (int)(cSys.iShakeCount));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1178_LP_Spd, (int)(cSys.dLP_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));

      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1180_LP_AL_Loading_Pos, (int)(cSys.dLP_AL_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1182_ALX_Ready_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1184_ALY_Ready_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));

      CIoVo.Set_WW_Align(enumWW_Align.W11A0_ALX_Befor_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11A2_ALY_Befor_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11A4_ALX_Align_Pos, (int)(cRcp.dPCB_Align_ALX_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11A6_ALY_Align_Pos, (int)(cRcp.dPCB_Align_ALY_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11A8_ALX_Back_Offset, (int)(cSys.dALX_AlignBackOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11AA_ALY_Back_Offset, (int)(cSys.dALY_AlignBackOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11B8_ALX_Low_Spd, (int)(cSys.dALX_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BA_ALY_Low_Spd, (int)(cSys.dALY_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BC_ALX_Spd, (int)(cSys.dALX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BE_ALY_Spd, (int)(cSys.dALY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));

      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C0_LP_Align_Unload_Pos, (int)(cSys.dLP_AL_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C2_ALX_Ready_Pos, (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C4_ALY_Ready_Pos, (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));

      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11E0_LP_Stage1_Pos, (int)(cSys.dLP_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11E2_Z1_Ready_Pos, (int)(cSys.dZ1_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11E4_Z1_Loading_Pos, (int)(cSys.dZ1_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11E6_X1_Loading_Pos, (int)(cSys.dX1_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11F8_Z1_Low_Spd, (int)(cSys.dZ1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FA_Z1_Spd, (int)(cSys.dZ1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FC_X1_Spd, (int)(cSys.dX1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));

      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1200_LP_Stage2_Pos, (int)(cSys.dLP_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1202_Z2_Ready_Pos, (int)(cSys.dZ2_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1204_Z2_Loading_Pos, (int)(cSys.dZ2_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1206_X2_Loading_Pos, (int)(cSys.dX2_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1218_Z2_Low_Spd, (int)(cSys.dZ2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121A_Z2_Spd, (int)(cSys.dZ2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121C_X2_Spd, (int)(cSys.dX2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));

      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1220_Z1_Zero_Pos, (int)(cSys.dZ1_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1222_X1_Zero_Pos, (int)((cSys.dX1_Center_Pos + 10) * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1224_PR1_Zero_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1226_PR2_Zero_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1238_PR1_Spd, (int)(cSys.dPR1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W123A_PR2_Spd, (int)(cSys.dPR2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1230_Z1_Safety_Pos, (int)(cSys.dZ1_Safety_Limit * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));

      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1240_Z2_Zero_Pos, (int)(cSys.dZ2_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1242_X2_Zero_Pos, (int)((cSys.dX2_Center_Pos + 10) * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1244_PR3_Zero_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1246_PR4_Zero_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1258_PR3_Spd, (int)(cSys.dPR3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W125A_PR4_Spd, (int)(cSys.dPR4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1250_Z2_Safety_Pos, (int)(cSys.dZ2_Safety_Limit * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));

      CIoVo.Set_WW_Stage1_Measure(enumWW_Stage1_Measure.W1260_Z1_Measure_Pos, (int)(cSys.dZ1_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_Stage1_Measure(enumWW_Stage1_Measure.W1262_X1_Measure_Pos, (int)(cSys.dX1_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_Measure(enumWW_Stage1_Measure.W1264_PR1_Measure_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale));
      CIoVo.Set_WW_Stage1_Measure(enumWW_Stage1_Measure.W1266_PR2_Measure_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale));

      CIoVo.Set_WW_Stage2_Measure(enumWW_Stage2_Measure.W1280_Z2_Measure_Pos, (int)(cSys.dZ2_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_Stage2_Measure(enumWW_Stage2_Measure.W1282_X2_Measure_Pos, (int)(cSys.dX2_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage2_Measure(enumWW_Stage2_Measure.W1284_PR3_Measure_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale));
      CIoVo.Set_WW_Stage2_Measure(enumWW_Stage2_Measure.W1286_PR4_Measure_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale));

      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12A0_UPX_Stage1_Pos, (int)(cSys.dUPX_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12A2_UPY_Stage1_Pos, (int)(cSys.dUPY_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12A4_Z1_Unload_Pos, (int)(cSys.dZ1_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12A6_X1_Unload_Pos, (int)(cSys.dX1_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12B8_UPX_Spd, (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12BA_UPY_Spd, (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));

      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12C0_UPX_Stage2_Pos, (int)(cSys.dUPX_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12C2_UPY_Stage2_Pos, (int)(cSys.dUPY_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12C4_Z2_Unload_Pos, (int)(cSys.dZ2_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12C6_X2_Unload_Pos, (int)(cSys.dX2_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12D8_UPX_Spd, (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12DA_UPY_Spd, (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));

      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12E0_UPX_UE1_Unload_Pos, (int)(cSys.dUPX_UE1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12E2_UPX_UE2_Unload_Pos, (int)(cSys.dUPX_UE2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12E4_UPX_UE3_Unload_Pos, (int)(cSys.dUPX_UE3_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12E6_UPX_UE4_Unload_Pos, (int)(cSys.dUPX_UE4_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12E8_UPY_UE1_Unload_Pos, (int)(cSys.dUPY_UE1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12EA_UPY_UE2_Unload_Pos, (int)(cSys.dUPY_UE2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12EC_UPY_UE3_Unload_Pos, (int)(cSys.dUPY_UE3_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12EE_UPY_UE4_Unload_Pos, (int)(cSys.dUPY_UE4_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F0_UPX_Ready_Pos, (int)(cSys.dUPX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F2_UPY_Ready_Pos, (int)(cSys.dUPY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F8_UP_Unload_Pos_Number, 1);

      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1300_Z1_Clean_Pos, (int)(cSys.dZ1_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1302_X1_Clean_Start_Pos, (int)(cSys.dX1_CleanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1304_X1_Clean_End_Pos, (int)(cSys.dX1_CleanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1306_X1_Probe_Clean_Pos, (int)(cSys.dX1_CleanProbe_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1308_PR1_Clean_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W130A_PR2_Clean_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W1318_CleanMode, 0);
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W131A_CleanCount, cSys.iStageCleanCount);
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W131C_X1_Low_Spd, (int)(cSys.dX1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));

      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1320_Z2_Clean_Pos, (int)(cSys.dZ2_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1322_X2_Clean_Start_Pos, (int)(cSys.dX2_CleanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1324_X2_Clean_End_Pos, (int)(cSys.dX2_CleanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1326_X2_Probe_Clean_Pos, (int)(cSys.dX2_CleanProbe_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1328_PR3_Clean_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W132A_PR4_Clean_Pos, (int)(0 * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W1338_CleanMode, 0);
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W133A_CleanCount, cSys.iStageCleanCount);
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W133C_X2_Low_Spd, (int)(cSys.dX2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));


      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1360_MainAir_Min_Error_Value, (int)(cSys.dMainAir_CylinderLimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1362_MainAir_Vaccum_Min_Error_Value, (int)(cSys.dMainAir_VaccumLimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1364_LP_Air_Max_Error_Value, (int)(cSys.dLP_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1366_LP_Air_Min_Error_Value, (int)(cSys.dLP_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1368_UP_Air_Max_Error_Value, (int)(cSys.dUP_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136A_UP_Air_Min_Error_Value, (int)(cSys.dUP_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136C_STAGE1_Air_Max_Error_Value, (int)(cSys.dStage1_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136E_STAGE1_Air_Min_Error_Value, (int)(cSys.dStage1_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1370_STAGE2_Air_Max_Error_Value, (int)(cSys.dStage2_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1372_STAGE2_Air_Min_Error_Value, (int)(cSys.dStage2_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A0_LE_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.LE].dLimitSoftCw * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A2_LE_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.LE].dLimitSoftCcw * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A4_UE1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE1].dLimitSoftCw * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A6_UE1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE1].dLimitSoftCcw * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A8_UE2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE2].dLimitSoftCw * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AA_UE2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE2].dLimitSoftCcw * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AC_UE3_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE3].dLimitSoftCw * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AE_UE3_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE3].dLimitSoftCcw * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B0_UE4_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE4].dLimitSoftCw * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B2_UE4_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE4].dLimitSoftCcw * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B4_BCX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCX].dLimitSoftCw * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B6_BCX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCX].dLimitSoftCcw * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B8_BCY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCY].dLimitSoftCw * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BA_BCY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCY].dLimitSoftCcw * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BC_LP_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.LP].dLimitSoftCw * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BE_LP_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.LP].dLimitSoftCcw * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C0_UPX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPX].dLimitSoftCw * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C2_UPX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPX].dLimitSoftCcw * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C4_UPY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPY].dLimitSoftCw * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C6_UPY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPY].dLimitSoftCcw * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C8_Z1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z1].dLimitSoftCw * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CA_Z1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z1].dLimitSoftCcw * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CC_Z2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z2].dLimitSoftCw * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CE_Z2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z2].dLimitSoftCcw * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D0_ALX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALX].dLimitSoftCw * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D2_ALX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALX].dLimitSoftCcw * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D4_ALY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALY].dLimitSoftCw * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D6_ALY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALY].dLimitSoftCcw * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D8_X1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.X1].dLimitSoftCw * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DA_X1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.X1].dLimitSoftCcw * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DC_X2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.X2].dLimitSoftCw * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DE_X2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.X2].dLimitSoftCcw * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E0_PR1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR1].dLimitSoftCw * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E2_PR1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR1].dLimitSoftCcw * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E4_PR2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR2].dLimitSoftCw * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E6_PR2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR2].dLimitSoftCcw * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E8_PR3_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR3].dLimitSoftCw * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EA_PR3_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR3].dLimitSoftCcw * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EC_PR4_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR4].dLimitSoftCw * sMotor[(int)enumMotorName.PR4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EE_PR4_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR4].dLimitSoftCcw * sMotor[(int)enumMotorName.PR4].dLimitScale));

      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1400_PR1_Interlock_pos, (int)(cSys.dPR1_Change_Pos * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1402_PR2_Interlock_pos, (int)(cSys.dPR2_Change_Pos * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1404_PR3_Interlock_pos, (int)(cSys.dPR3_Change_Pos * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1406_PR4_Interlock_pos, (int)(cSys.dPR4_Change_Pos * sMotor[(int)enumMotorName.PR4].dLimitScale));

      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1420_Setup_Mode, 0);
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1422_Teaching_Mode, 0);
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1424_LE_Air_Mode, cSys.iLEAirBlowMode);
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1426_LP_Shaking_Mode, cSys.bUseLoadingShake ? 1 : 0);
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1440_Cylinder_Error_Time, (int)(cSys.iErrorDelayTime_Cylinder / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1442_LP_Air_Error_Time, (int)(cSys.iErrorDelayTime_LPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1444_UP_Air_Error_Time, (int)(cSys.iErrorDelayTime_UPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1446_Stage1_Air_Error_Time, (int)(cSys.iErrorDelayTime_Stage1Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1448_Stage2_Air_Error_Time, (int)(cSys.iErrorDelayTime_Stage2Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1450_Cylinder_Check_Time, (int)(cSys.iDelayTime_Cylinder / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1452_LP_Air_Check_Time, (int)(cSys.iDelayTime_LPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1454_UP_Air_Check_Time, (int)(cSys.iDelayTime_UPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1456_Stage1_Air_Check_Time, (int)(cSys.iDelayTime_Stage1Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1458_Stage2_Air_Check_Time, (int)(cSys.iDelayTime_Stage2Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W145E_Run_TimiOut_Error_Time, (int)(cSys.dCycleTimeOut / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1460_Measure_Delay_Time, (int)(cSys.iDelayTime_Measure / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1462_Align_Delay_Time, (int)(cSys.iDelayTime_Align / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1464_LE_Air_Blow_Time, (int)(cSys.iRunTime_AirBlow / CVo.iTimeScale));
      Send_All();
    }

    public static void Send_All()
    {
      Send_ReadyPos();
      Send_AirLimit();
      Send_MotorLimit();
      Send_Error_Delay_Time();
      Send_Delay_Time();
      Send_Run_Time();
      Send_Mode();
    }

    public static void Send_ReadyPos()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * sMotor[(int)enumMotorName.LE].dLimitScale));
    }
    public static void Send_Low_Spd()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DA_LE_Scan_Spd, (int)(cSys.dLE_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10FA_UE1_Scan_Spd, (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W111A_UE2_Scan_Spd, (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W113A_UE3_Scan_Spd, (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W115A_UE4_Scan_Spd, (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11B8_ALX_Low_Spd, (int)(cSys.dALX_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BA_ALY_Low_Spd, (int)(cSys.dALY_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11F8_Z1_Low_Spd, (int)(cSys.dZ1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1218_Z2_Low_Spd, (int)(cSys.dZ2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_Stage1_Clean(enumWW_Stage1_Clean.W131C_X1_Low_Spd, (int)(cSys.dX1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_Stage2_Clean(enumWW_Stage2_Clean.W133C_X2_Low_Spd, (int)(cSys.dX2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
    
    }
    public static void Send_Normal_Spd()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DC_BCX_Spd, (int)(cSys.dBCX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10DE_BCY_Spd, (int)(cSys.dBCY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10D8_LE_Spd, (int)(cSys.dLE_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale));
      CIoVo.Set_WW_UE1_Align_Ready(enumWW_UE1_Align_Ready.W10F8_UE1_Spd, (int)(cSys.dUE1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale));
      CIoVo.Set_WW_UE2_Align_Ready(enumWW_UE2_Align_Ready.W1118_UE2_Spd, (int)(cSys.dUE2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale));
      CIoVo.Set_WW_UE3_Align_Ready(enumWW_UE3_Align_Ready.W1138_UE3_Spd, (int)(cSys.dUE3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale));
      CIoVo.Set_WW_UE4_Align_Ready(enumWW_UE4_Align_Ready.W1158_UE4_Spd, (int)(cSys.dUE4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale));
      CIoVo.Set_WW_LE_to_LP(enumWW_LE_to_LP.W1178_LP_Spd, (int)(cSys.dLP_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BC_ALX_Spd, (int)(cSys.dALX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale));
      CIoVo.Set_WW_Align(enumWW_Align.W11BE_ALY_Spd, (int)(cSys.dALY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FA_Z1_Spd, (int)(cSys.dZ1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FC_X1_Spd, (int)(cSys.dX1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121A_Z2_Spd, (int)(cSys.dZ2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121C_X2_Spd, (int)(cSys.dX2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1238_PR1_Spd, (int)(cSys.dPR1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale));
      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W123A_PR2_Spd, (int)(cSys.dPR2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1258_PR3_Spd, (int)(cSys.dPR3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W125A_PR4_Spd, (int)(cSys.dPR4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12B8_UPX_Spd, (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage1_to_UL(enumWW_Stage1_to_UL.W12BA_UPY_Spd, (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12D8_UPX_Spd, (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_Stage2_to_UL(enumWW_Stage2_to_UL.W12DA_UPY_Spd, (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F0_UPX_Ready_Pos, (int)(cSys.dUPX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale));
      CIoVo.Set_WW_UL_to_UE(enumWW_UL_to_UE.W12F2_UPY_Ready_Pos, (int)(cSys.dUPY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale));
    
    }
    public static void Send_AirLimit()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1360_MainAir_Min_Error_Value, (int)(cSys.dMainAir_CylinderLimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1362_MainAir_Vaccum_Min_Error_Value, (int)(cSys.dMainAir_VaccumLimitMinus * CVo.iAirScale));      
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1364_LP_Air_Max_Error_Value, (int)(cSys.dLP_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1366_LP_Air_Min_Error_Value, (int)(cSys.dLP_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1368_UP_Air_Max_Error_Value, (int)(cSys.dUP_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136A_UP_Air_Min_Error_Value, (int)(cSys.dUP_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136C_STAGE1_Air_Max_Error_Value, (int)(cSys.dStage1_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W136E_STAGE1_Air_Min_Error_Value, (int)(cSys.dStage1_Vacuum_LimitMinus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1370_STAGE2_Air_Max_Error_Value, (int)(cSys.dStage2_Vacuum_LimitPlus * CVo.iAirScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1372_STAGE2_Air_Min_Error_Value, (int)(cSys.dStage2_Vacuum_LimitMinus * CVo.iAirScale));
    }
    public static void Send_MotorLimit()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      sMotor[(int)enumMotorName.LE].dLimitSoftCw = cSys.dLE_LimitCw;
      sMotor[(int)enumMotorName.LP].dLimitSoftCw = cSys.dLP_LimitCw;
      sMotor[(int)enumMotorName.BCX].dLimitSoftCw = cSys.dBCX_LimitCw;
      sMotor[(int)enumMotorName.BCY].dLimitSoftCw = cSys.dBCY_LimitCw;
      sMotor[(int)enumMotorName.ALX].dLimitSoftCw = cSys.dALX_LimitCw;
      sMotor[(int)enumMotorName.ALY].dLimitSoftCw = cSys.dALY_LimitCw;
      sMotor[(int)enumMotorName.X1].dLimitSoftCw = cSys.dX1_LimitCw;
      sMotor[(int)enumMotorName.X2].dLimitSoftCw = cSys.dX2_LimitCw;
      sMotor[(int)enumMotorName.Z1].dLimitSoftCw = cSys.dZ1_LimitCw;
      sMotor[(int)enumMotorName.Z2].dLimitSoftCw = cSys.dZ2_LimitCw;
      sMotor[(int)enumMotorName.PR1].dLimitSoftCw = cSys.dPR1_LimitCw;
      sMotor[(int)enumMotorName.PR2].dLimitSoftCw = cSys.dPR2_LimitCw;
      sMotor[(int)enumMotorName.PR3].dLimitSoftCw = cSys.dPR3_LimitCw;
      sMotor[(int)enumMotorName.PR4].dLimitSoftCw = cSys.dPR4_LimitCw;
      sMotor[(int)enumMotorName.UPX].dLimitSoftCw = cSys.dUPX_LimitCw;
      sMotor[(int)enumMotorName.UPY].dLimitSoftCw = cSys.dUPY_LimitCw;
      sMotor[(int)enumMotorName.UE1].dLimitSoftCw = cSys.dUE1_LimitCw;
      sMotor[(int)enumMotorName.UE2].dLimitSoftCw = cSys.dUE2_LimitCw;
      sMotor[(int)enumMotorName.UE3].dLimitSoftCw = cSys.dUE3_LimitCw;
      sMotor[(int)enumMotorName.UE4].dLimitSoftCw = cSys.dUE4_LimitCw;

      sMotor[(int)enumMotorName.LE].dLimitSoftCcw = cSys.dLE_LimitCcw;
      sMotor[(int)enumMotorName.LP].dLimitSoftCcw = cSys.dLP_LimitCcw;
      sMotor[(int)enumMotorName.BCX].dLimitSoftCcw = cSys.dBCX_LimitCcw;
      sMotor[(int)enumMotorName.BCY].dLimitSoftCcw = cSys.dBCY_LimitCcw;
      sMotor[(int)enumMotorName.ALX].dLimitSoftCcw = cSys.dALX_LimitCcw;
      sMotor[(int)enumMotorName.ALY].dLimitSoftCcw = cSys.dALY_LimitCcw;
      sMotor[(int)enumMotorName.X1].dLimitSoftCcw = cSys.dX1_LimitCcw;
      sMotor[(int)enumMotorName.X2].dLimitSoftCcw = cSys.dX2_LimitCcw;
      sMotor[(int)enumMotorName.Z1].dLimitSoftCcw = cSys.dZ1_LimitCcw;
      sMotor[(int)enumMotorName.Z2].dLimitSoftCcw = cSys.dZ2_LimitCcw;
      sMotor[(int)enumMotorName.PR1].dLimitSoftCcw = cSys.dPR1_LimitCcw;
      sMotor[(int)enumMotorName.PR2].dLimitSoftCcw = cSys.dPR2_LimitCcw;
      sMotor[(int)enumMotorName.PR3].dLimitSoftCcw = cSys.dPR3_LimitCcw;
      sMotor[(int)enumMotorName.PR4].dLimitSoftCcw = cSys.dPR4_LimitCcw;
      sMotor[(int)enumMotorName.UPX].dLimitSoftCcw = cSys.dUPX_LimitCcw;
      sMotor[(int)enumMotorName.UPY].dLimitSoftCcw = cSys.dUPY_LimitCcw;
      sMotor[(int)enumMotorName.UE1].dLimitSoftCcw = cSys.dUE1_LimitCcw;
      sMotor[(int)enumMotorName.UE2].dLimitSoftCcw = cSys.dUE2_LimitCcw;
      sMotor[(int)enumMotorName.UE3].dLimitSoftCcw = cSys.dUE3_LimitCcw;
      sMotor[(int)enumMotorName.UE4].dLimitSoftCcw = cSys.dUE4_LimitCcw;


      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        CMotionVo.SetMotorStatus(sMotor[i], (enumMotorName)i);
      }

      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A0_LE_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.LE].dLimitSoftCw * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A2_LE_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.LE].dLimitSoftCcw * sMotor[(int)enumMotorName.LE].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A4_UE1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE1].dLimitSoftCw * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A6_UE1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE1].dLimitSoftCcw * sMotor[(int)enumMotorName.UE1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13A8_UE2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE2].dLimitSoftCw * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AA_UE2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE2].dLimitSoftCcw * sMotor[(int)enumMotorName.UE2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AC_UE3_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE3].dLimitSoftCw * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13AE_UE3_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE3].dLimitSoftCcw * sMotor[(int)enumMotorName.UE3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B0_UE4_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE4].dLimitSoftCw * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B2_UE4_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UE4].dLimitSoftCcw * sMotor[(int)enumMotorName.UE4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B4_BCX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCX].dLimitSoftCw * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B6_BCX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCX].dLimitSoftCcw * sMotor[(int)enumMotorName.BCX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13B8_BCY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCY].dLimitSoftCw * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BA_BCY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.BCY].dLimitSoftCcw * sMotor[(int)enumMotorName.BCY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BC_LP_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.LP].dLimitSoftCw * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13BE_LP_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.LP].dLimitSoftCcw * sMotor[(int)enumMotorName.LP].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C0_UPX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPX].dLimitSoftCw * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C2_UPX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPX].dLimitSoftCcw * sMotor[(int)enumMotorName.UPX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C4_UPY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPY].dLimitSoftCw * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C6_UPY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.UPY].dLimitSoftCcw * sMotor[(int)enumMotorName.UPY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13C8_Z1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z1].dLimitSoftCw * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CA_Z1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z1].dLimitSoftCcw * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CC_Z2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z2].dLimitSoftCw * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13CE_Z2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.Z2].dLimitSoftCcw * sMotor[(int)enumMotorName.Z2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D0_ALX_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALX].dLimitSoftCw * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D2_ALX_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALX].dLimitSoftCcw * sMotor[(int)enumMotorName.ALX].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D4_ALY_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALY].dLimitSoftCw * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D6_ALY_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.ALY].dLimitSoftCcw * sMotor[(int)enumMotorName.ALY].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13D8_X1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.X1].dLimitSoftCw * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DA_X1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.X1].dLimitSoftCcw * sMotor[(int)enumMotorName.X1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DC_X2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.X2].dLimitSoftCw * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13DE_X2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.X2].dLimitSoftCcw * sMotor[(int)enumMotorName.X2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E0_PR1_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR1].dLimitSoftCw * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E2_PR1_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR1].dLimitSoftCcw * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E4_PR2_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR2].dLimitSoftCw * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E6_PR2_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR2].dLimitSoftCcw * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13E8_PR3_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR3].dLimitSoftCw * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EA_PR3_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR3].dLimitSoftCcw * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EC_PR4_Cw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR4].dLimitSoftCw * sMotor[(int)enumMotorName.PR4].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W13EE_PR4_Ccw_Max_Pos, (int)(sMotor[(int)enumMotorName.PR4].dLimitSoftCcw * sMotor[(int)enumMotorName.PR4].dLimitScale));

      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1400_PR1_Interlock_pos, (int)(cSys.dPR1_Change_Pos * sMotor[(int)enumMotorName.PR1].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1402_PR2_Interlock_pos, (int)(cSys.dPR2_Change_Pos * sMotor[(int)enumMotorName.PR2].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1404_PR3_Interlock_pos, (int)(cSys.dPR3_Change_Pos * sMotor[(int)enumMotorName.PR3].dLimitScale));
      CIoVo.Set_WW_ErrorValue_Allow(enumWW_ErrorValue_Allow_Data.W1406_PR4_Interlock_pos, (int)(cSys.dPR4_Change_Pos * sMotor[(int)enumMotorName.PR4].dLimitScale));
    
    }
    public static void Send_Error_Delay_Time() 
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
     // ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1440_Cylinder_Error_Time, (int)(cSys.iErrorDelayTime_Cylinder / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1442_LP_Air_Error_Time, (int)(cSys.iErrorDelayTime_LPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1444_UP_Air_Error_Time, (int)(cSys.iErrorDelayTime_UPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1446_Stage1_Air_Error_Time, (int)(cSys.iErrorDelayTime_Stage1Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1448_Stage2_Air_Error_Time, (int)(cSys.iErrorDelayTime_Stage2Vacuum / CVo.iTimeScale));
    }
    public static void Send_Delay_Time() 
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1450_Cylinder_Check_Time, (int)(cSys.iDelayTime_Cylinder / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1452_LP_Air_Check_Time, (int)(cSys.iDelayTime_LPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1454_UP_Air_Check_Time, (int)(cSys.iDelayTime_UPVacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1456_Stage1_Air_Check_Time, (int)(cSys.iDelayTime_Stage1Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1458_Stage2_Air_Check_Time, (int)(cSys.iDelayTime_Stage2Vacuum / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W145E_Run_TimiOut_Error_Time, (int)(cSys.dCycleTimeOut / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1460_Measure_Delay_Time, (int)(cSys.iDelayTime_Measure / CVo.iTimeScale));
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1462_Align_Delay_Time, (int)(cSys.iDelayTime_Align / CVo.iTimeScale));
    }
    public static void Send_Run_Time() 
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1464_LE_Air_Blow_Time, (int)(cSys.iRunTime_AirBlow / CVo.iTimeScale));
    }
    public static void Send_Mode() 
    { 
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      //ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1424_LE_Air_Mode, cSys.iLEAirBlowMode);
      CIoVo.Set_WW_Select_Section(enumWW_Select_Section.W1426_LP_Shaking_Mode, cSys.bUseLoadingShake ? 1 : 0);
    }
    public static void Send_Safety_Z_Pos()
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      structMotorStatus[] sMotor = new structMotorStatus[Enum.GetNames(typeof(enumMotorName)).Length];
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        sMotor[i] = CMotionVo.GetMotorStatus((enumMotorName)i);
      }

      CIoVo.Set_WW_Stage1_Zero(enumWW_Stage1_Zero.W1230_Z1_Safety_Pos, (int)(cSys.dZ1_Safety_Limit * sMotor[(int)enumMotorName.Z1].dLimitScale));
      CIoVo.Set_WW_Stage2_Zero(enumWW_Stage2_Zero.W1250_Z2_Safety_Pos, (int)(cSys.dZ2_Safety_Limit * sMotor[(int)enumMotorName.Z2].dLimitScale));
    }


    #endregion

    #endregion

    #region IO File Control
    public static void Init_Io()
    {
      for (int i = 0; i < Enum.GetNames(typeof(enumBitInput)).Length; i++)
      {
        sInput[i].strName = ((enumBitInput)i).ToString();
        sInput[i].bOriginSignal = false;
        sInput[i].bContactSetting = false;
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumBitOutput)).Length; i++)
      {
        sOutput[i].strName = ((enumBitOutput)i).ToString();
        sOutput[i].bOriginSignal = false;
        sOutput[i].bContactSetting = false;
      }
    } // Initialize IO
    public static bool Create_IoList()
    {
      string strPathInput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_INPUT;
      string strPathOutput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_OUTPUT;
      bool bExistInput = false;
      bool bExistOutput = false;
      if (!System.IO.Directory.Exists(CVo.SYSTEM_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }
      bExistInput = System.IO.File.Exists(strPathInput);
      bExistOutput = System.IO.File.Exists(strPathOutput);

      if (bExistInput && bExistOutput)
      {
        return true;
      }
      bool bResult = true;
      System.IO.StreamWriter sw = null;
      if (bExistInput == false)
      {
        try
        {
          sw = new System.IO.StreamWriter(strPathInput, true, System.Text.Encoding.UTF8);
          string strData = "NO,LABEL,NAME,CONTACT";
          sw.WriteLine(strData);
          for (int i = 0; i < Enum.GetNames(typeof(enumBitInput)).Length; i++)
          {
            strData = "";
            strData =
              i.ToString() + ","
              + ((enumBitInput)i).ToString() + ","
              + sInput[i].strName + ","
              + sInput[i].bContactSetting.ToString();
            sw.WriteLine(strData);
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }

      if (bExistOutput == false)
      {
        try
        {
          sw = new System.IO.StreamWriter(strPathOutput, true, System.Text.Encoding.UTF8);
          string strData = "NO,LABEL,NAME,CONTACT";
          sw.WriteLine(strData);
          for (int i = 0; i < Enum.GetNames(typeof(enumBitOutput)).Length; i++)
          {
            strData = "";
            strData =
              i.ToString() + ","
              + ((enumBitOutput)i).ToString() + ","
              + sOutput[i].strName + ","
              + sOutput[i].bContactSetting.ToString();
            sw.WriteLine(strData);
          }
        }
        catch (Exception ex)
        {
          CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
          bResult = false;
        }
        finally
        {
          sw.Close();
          sw = null;
        }
      }

      if (bResult == false)
      {
        return false;
      }
      return true;
    } // Create IO to File
    public static bool Load_IoList()
    {
      string strPathInput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_INPUT;
      string strPathOutput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_OUTPUT;
      bool bExistInput = false;
      bool bExistOutput = false;
      if (!System.IO.Directory.Exists(CVo.SYSTEM_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }
      bExistInput = System.IO.File.Exists(strPathInput);
      bExistOutput = System.IO.File.Exists(strPathOutput);
      if (bExistInput == false || bExistOutput == false)
      {
        Create_IoList();
      }

      bool bResult = true;
      System.IO.StreamReader sr = null;
      try
      {
        string strRead = "";
        string[] strData = null;
        sr = new System.IO.StreamReader(strPathInput, System.Text.Encoding.UTF8, true);
        sr.ReadLine(); //Throw away Filst line (Title)
        for (int i = 0; i < Enum.GetNames(typeof(enumBitInput)).Length; i++)
        {
          strRead = sr.ReadLine();
          strData = strRead.Split(',');
          if (strData.Length != 4)
          {
            bResult = false;
            break;
          }
          sInput[Convert.ToInt32(strData[0])].strName = strData[2];
          sInput[Convert.ToInt32(strData[0])].bContactSetting = Convert.ToBoolean(strData[3]);
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        sr.Close();
        sr = null;
      }
      if (bResult == false)
      {
        return false;
      }

      try
      {
        string strRead = "";
        string[] strData = null;
        sr = new System.IO.StreamReader(strPathOutput, System.Text.Encoding.UTF8, true);
        sr.ReadLine(); //Throw away Filst line (Title)
        for (int i = 0; i < Enum.GetNames(typeof(enumBitOutput)).Length; i++)
        {
          strRead = sr.ReadLine();
          strData = strRead.Split(',');
          if (strData.Length != 4)
          {
            bResult = false;
            break;
          }
          sOutput[Convert.ToInt32(strData[0])].strName = strData[2];
          sOutput[Convert.ToInt32(strData[0])].bContactSetting = Convert.ToBoolean(strData[3]);
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      finally
      {
        sr.Close();
        sr = null;
      }
      if (bResult == false)
      {
        return false;
      }

      return true;
    } // Load IO from File
    public static bool Delete_IoList()
    {
      string strPathInput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_INPUT;
      string strPathOutput = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_OUTPUT;
      if (!System.IO.Directory.Exists(CVo.SYSTEM_PATH))
      {
        System.IO.Directory.CreateDirectory(CVo.SYSTEM_PATH);
      }
      bool bResult = true;
      try
      {
        if (System.IO.File.Exists(strPathInput))
        {
          System.IO.File.Delete(strPathInput);
        }
        if (System.IO.File.Exists(strPathOutput))
        {
          System.IO.File.Delete(strPathOutput);
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        bResult = false;
      }
      if (bResult == false)
      {
        return false;
      }

      return true;
    } // Delete IO File
    #endregion
  }
}
