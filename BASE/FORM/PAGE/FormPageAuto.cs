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
using BASE.MODULE.MOTION;

namespace BASE.FORM.PAGE
{
  public partial class FormPageAuto : Form
  {
    private int iMachinePeriod = 6;
    private int iMachineTimer = 0;

    public delegate bool del_Add_PCBData(structPCBData PCBData);
    public delegate void del_Set_BCR_Image(Image img);

    private ClassSystemPara cTempSystem = new ClassSystemPara();

    public FormPageAuto()
    {
      InitializeComponent();
    }

    private void GetParam()
    {
      cTempSystem = CVo.cParaSys.GetValues();
    }

    private void Refresh_Info()
    {
      int iPCBCount = 0;
      for (int i = 0; i < CVo.sPCBData.Length; i++)
      {
        if (CVo.sPCBData[i].PerfectlyOut)
        {
          iPCBCount++;
        }
      }

      grid_Main_CycleInfo.RowCount = 3;

      grid_Main_CycleInfo.Rows[0].Cells[0].Value = "1";
      grid_Main_CycleInfo.Rows[0].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "최근 배출 텍타임" : "Current Tact Time";
      grid_Main_CycleInfo.Rows[0].Cells[2].Value = (CVo.sCurrentOutTime - CVo.sPreviousOutTime).TotalSeconds.ToString("0.000");

      grid_Main_CycleInfo.Rows[1].Cells[0].Value = "2";
      grid_Main_CycleInfo.Rows[1].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "Lot 배출 수량" : "Lot Count";
      grid_Main_CycleInfo.Rows[1].Cells[2].Value = iPCBCount.ToString();

      grid_Main_CycleInfo.Rows[2].Cells[0].Value = "3";
      grid_Main_CycleInfo.Rows[2].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "총 배출 수량" : "Lot Count";
      grid_Main_CycleInfo.Rows[2].Cells[2].Value = CVo.uiProductTotalCount.ToString();

      //grid_Main_CycleInfo.Rows[0].Cells[0].Value = "1";
      //grid_Main_CycleInfo.Rows[0].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "총 시간" : "Total Time";
      //grid_Main_CycleInfo.Rows[0].Cells[2].Value = CVo.dTactTime_Total.ToString("0.000");

      //grid_Main_CycleInfo.Rows[1].Cells[0].Value = "2";
      //grid_Main_CycleInfo.Rows[1].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "1장 평균 시간" : "Average Time";
      //grid_Main_CycleInfo.Rows[1].Cells[2].Value = CVo.dTactTime_Average.ToString("0.000");

      //grid_Main_CycleInfo.Rows[5].Cells[0].Value = "3";
      //grid_Main_CycleInfo.Rows[5].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "이전 1장 생산시간" : "Previous Time";
      //grid_Main_CycleInfo.Rows[5].Cells[2].Value = CVo.dTactTime_Previous.ToString("0.000");

      //grid_Main_CycleInfo.Rows[6].Cells[0].Value = "4";
      //grid_Main_CycleInfo.Rows[6].Cells[1].Value = (CVo.eCurrentLanguage == enumLanguageType.Korean) ? "최근 1장 생산시간" : "Current Time";
      //grid_Main_CycleInfo.Rows[6].Cells[2].Value = CVo.dTactTime_Currnet.ToString("0.000");
    }

    private void tmr_Main_Tick(object sender, EventArgs e)
    {
      tmr_Main.Enabled = false;

      if (CVo.bRefreshInfo)
      {
        CVo.bRefreshInfo = false;
        Refresh_Info();
      }


      int iUP_to_UE_Number = CIoVo.Get_WW_UL_to_UE(enumWW_UL_to_UE.W12F8_UP_Unload_Pos_Number);

      bool bErrorLEAlign = CheckError(enumError.B2260_BH_Door_Open_Error_LEAlignReady, enumError.B227F_);
      bool bErrorLEtoLP = CheckError(enumError.B2300_BH_Door_Open_Error_LEtoLP, enumError.B231F_);
      bool bErrorLPtoAL = CheckError(enumError.B2320_BH_Door_Open_Error_LPtoAL, enumError.B233F_);
      bool bErrorAlign = CheckError(enumError.B2340_BH_Door_Open_Error_AL, enumError.B235F_);
      bool bErrorALtoLP = CheckError(enumError.B2360_BH_Door_Open_Error_ALtoLP, enumError.B237F_);
      bool bErrorLPtoSt1 = CheckError(enumError.B2380_BH_Door_Open_Error_LPtoStage1, enumError.B239F_);
      bool bErrorLPtoSt2 = CheckError(enumError.B23A0_BH_Door_Open_Error_LPtoStage2, enumError.B23BF_);
      bool bErrorStage1Zero = CheckError(enumError.B23C0_BH_Door_Open_Error_Stage1Zero, enumError.B23DF_);
      bool bErrorStage2Zero = CheckError(enumError.B23E0_BH_Door_Open_Error_Stage2Zero, enumError.B23FF_);
      bool bErrorStage1Measure = CheckError(enumError.B2400_BH_Door_Open_Error_Stage1Measure, enumError.B241F_);
      bool bErrorStage2Measure = CheckError(enumError.B2420_BH_Door_Open_Error_Stage2Measure, enumError.B243F_);
      bool bErrorStage1toUP = CheckError(enumError.B2440_BH_Door_Open_Error_Stage1toUP, enumError.B245F_);
      bool bErrorStage2toUP = CheckError(enumError.B2460_BH_Door_Open_Error_Stage2toUP, enumError.B247F_);
      bool bErrorUP_to_UE1 = CheckError(enumError.B2480_BH_Door_Open_Error_UPtoUE, enumError.B249F_) && (iUP_to_UE_Number == 1);
      bool bErrorUP_to_UE2 = CheckError(enumError.B2480_BH_Door_Open_Error_UPtoUE, enumError.B249F_) && (iUP_to_UE_Number == 2);
      bool bErrorUP_to_UE3 = CheckError(enumError.B2480_BH_Door_Open_Error_UPtoUE, enumError.B249F_) && (iUP_to_UE_Number == 3);
      bool bErrorUP_to_UE4 = CheckError(enumError.B2480_BH_Door_Open_Error_UPtoUE, enumError.B249F_) && (iUP_to_UE_Number == 4);
      bool bErrorStage1Clean = CheckError(enumError.B24A0_BH_Door_Open_Error_Stage1Clean, enumError.B24BF_);
      bool bErrorStage2Clean = CheckError(enumError.B24C0_BH_Door_Open_Error_Stage2Clean, enumError.B24DF_);
      bool bErrorUE1Align = CheckError(enumError.B2280_BH_Door_Open_Error_UE1AlignReady, enumError.B229F_);
      bool bErrorUE2Align = CheckError(enumError.B22A0_BH_Door_Open_Error_UE2AlignReady, enumError.B22BF_);
      bool bErrorUE3Align = CheckError(enumError.B22C0_BH_Door_Open_Error_UE3AlignReady, enumError.B22DF_);
      bool bErrorUE4Align = CheckError(enumError.B22E0_BH_Door_Open_Error_UE4AlignReady, enumError.B22FF_);

      bool bErrorAll = CheckError(enumError.B2140_AW_LE_Ready_Error, enumError.B225F_); // 상시알람, 원점복귀, 티칭

      bool bRunningLEAlign = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting);
      bool bRunningLEtoLP = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running);
      bool bRunningLPtoAL = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running);
      bool bRunningAlign = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CC_AL_Running);
      bool bRunningALtoLP = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running);
      bool bRunningLPtoSt1 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running);
      bool bRunningLPtoSt2 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running);
      bool bRunningStage1Zero = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running);
      bool bRunningStage2Zero = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running);
      bool bRunningStage1Measure = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running);
      bool bRunningStage2Measure = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running);
      bool bRunningStage1toUP = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running);
      bool bRunningStage2toUP = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running);
      bool bRunningUP_to_UE1 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) && (iUP_to_UE_Number == 1);
      bool bRunningUP_to_UE2 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) && (iUP_to_UE_Number == 2);
      bool bRunningUP_to_UE3 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) && (iUP_to_UE_Number == 3);
      bool bRunningUP_to_UE4 = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) && (iUP_to_UE_Number == 4);
      bool bRunningStage1Clean = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running);
      bool bRunningStage2Clean = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running);
      bool bRunningUE1Align = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting);
      bool bRunningUE2Align = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting);
      bool bRunningUE3Align = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting);
      bool bRunningUE4Align = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running) || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting);

      bool bAlarm_LE = bErrorAll || bErrorLEAlign || bErrorLEtoLP;
      bool bAlarm_LP = bErrorAll || bErrorLEtoLP || bErrorLPtoAL || bErrorALtoLP || bErrorLPtoSt1 || bErrorLPtoSt2;
      bool bAlarm_AL = bErrorAll || bErrorLPtoAL || bErrorAlign || bErrorALtoLP;
      bool bAlarm_ST1 = bErrorAll || bErrorLPtoSt1 || bErrorStage1Zero || bErrorStage1Measure || bErrorStage1Clean || bErrorStage1toUP;
      bool bAlarm_ST2 = bErrorAll || bErrorLPtoSt2 || bErrorStage2Zero || bErrorStage2Measure || bErrorStage2Clean || bErrorStage2toUP;
      bool bAlarm_UP = bErrorAll || bErrorStage1toUP || bErrorUP_to_UE1 || bErrorUP_to_UE2 || bErrorUP_to_UE3 || bErrorUP_to_UE4;
      bool bAlarm_UE1 = bErrorAll || bErrorUP_to_UE1 || bErrorUE1Align;
      bool bAlarm_UE2 = bErrorAll || bErrorUP_to_UE2 || bErrorUE2Align;
      bool bAlarm_UE3 = bErrorAll || bErrorUP_to_UE3 || bErrorUE3Align;
      bool bAlarm_UE4 = bErrorAll || bErrorUP_to_UE4 || bErrorUE4Align;

      bool bRun_LE =  bRunningLEAlign || bRunningLEtoLP;
      bool bRun_LP = bRunningLEtoLP || bRunningLPtoAL || bRunningALtoLP || bRunningLPtoSt1 || bRunningLPtoSt2;
      bool bRun_AL =  bRunningLPtoAL || bRunningAlign || bRunningALtoLP;
      bool bRun_ST1 = bRunningLPtoSt1 || bRunningStage1Zero || bRunningStage1Measure || bRunningStage1Clean || bRunningStage1toUP;
      bool bRun_ST2 = bRunningLPtoSt2 || bRunningStage2Zero || bRunningStage2Measure || bRunningStage2Clean || bRunningStage2toUP;
      bool bRun_UP =  bRunningStage1toUP || bRunningUP_to_UE1 || bRunningUP_to_UE2 || bRunningUP_to_UE3 || bRunningUP_to_UE4;
      bool bRun_UE1 = bRunningUP_to_UE1 || bRunningUE1Align;
      bool bRun_UE2 = bRunningUP_to_UE2 || bRunningUE2Align;
      bool bRun_UE3 = bRunningUP_to_UE3 || bRunningUE3Align;
      bool bRun_UE4 = bRunningUP_to_UE4 || bRunningUE4Align;

      System.Drawing.Color sColor_LE = bAlarm_LE ? Color.Red : (bRun_LE ? Color.Lime : Color.White);
      System.Drawing.Color sColor_LP = bAlarm_LP ? Color.Red : (bRun_LP ? Color.Lime : Color.White);
      System.Drawing.Color sColor_AL = bAlarm_AL ? Color.Red : (bRun_AL ? Color.Lime : Color.White);
      System.Drawing.Color sColor_ST1 = bAlarm_ST1 ? Color.Red : (bRun_ST1 ? Color.Lime : Color.White);
      System.Drawing.Color sColor_ST2 = bAlarm_ST2 ? Color.Red : (bRun_ST2 ? Color.Lime : Color.White);
      System.Drawing.Color sColor_UP = bAlarm_UP ? Color.Red : (bRun_UP ? Color.Lime : Color.White);
      System.Drawing.Color sColor_UE1 = bAlarm_UE1 ? Color.Red : (bRun_UE1 ? Color.Lime : Color.White);
      System.Drawing.Color sColor_UE2 = bAlarm_UE2 ? Color.Red : (bRun_UE2 ? Color.Lime : Color.White);
      System.Drawing.Color sColor_UE3 = bAlarm_UE3 ? Color.Red : (bRun_UE3 ? Color.Lime : Color.White);
      System.Drawing.Color sColor_UE4 = bAlarm_UE4 ? Color.Red : (bRun_UE4 ? Color.Lime : Color.White);

      System.Drawing.Color sColorEMO_Front = CIoVo.Get_RB_Input(enumBitInput.B2000_EMO1Switch) ? Color.White : Color.Red;
      System.Drawing.Color sColorEMO_Left = CIoVo.Get_RB_Input(enumBitInput.B2001_EMO2Switch) ? Color.White : Color.Red;
      System.Drawing.Color sColorEMO_Back = CIoVo.Get_RB_Input(enumBitInput.B2002_EMO3Switch) ? Color.White : Color.Red;
      System.Drawing.Color sColorEMO_Right = CIoVo.Get_RB_Input(enumBitInput.B2003_EMO4Switch) ? Color.White : Color.Red;

      System.Drawing.Color sColor_LotEndWait = CVo.bLotEndWait ? Color.Purple : Color.White;

      iMachineTimer++;
      bool bBlink = (iMachineTimer % 2) == 0;
      //lbl_Main_Machine_LE.BackColor = bBlink ? Color.White : sColor_LE;
      //lbl_Main_Machine_LP.BackColor = bBlink ? Color.White : sColor_LP;
      //lbl_Main_Machine_AL.BackColor = bBlink ? Color.White : sColor_AL;
      //lbl_Main_Machine_ST1.BackColor = bBlink ? Color.White : sColor_ST1;
      //lbl_Main_Machine_ST2.BackColor = bBlink ? Color.White : sColor_ST2;
      //lbl_Main_Machine_UP.BackColor = bBlink ? Color.White : sColor_UP;
      //lbl_Main_Machine_UE1.BackColor = bBlink ? Color.White : sColor_UE1;
      //lbl_Main_Machine_UE2.BackColor = bBlink ? Color.White : sColor_UE2;
      //lbl_Main_Machine_UE3.BackColor = bBlink ? Color.White : sColor_UE3;
      //lbl_Main_Machine_UE4.BackColor = bBlink ? Color.White : sColor_UE4;

      //lbl_EMO_Front.BackColor = bBlink ? Color.White : sColorEMO_Front;
      //lbl_EMO_Left.BackColor = bBlink ? Color.White : sColorEMO_Left;
      //lbl_EMO_Right.BackColor = bBlink ? Color.White : sColorEMO_Right;
      //lbl_EMO_Back.BackColor = bBlink ? Color.White : sColorEMO_Back;

      lbl_Auto_LotEndWait.BackColor = bBlink ? Color.White : sColor_LotEndWait;

      if (iMachineTimer > iMachinePeriod)
      {
        iMachineTimer = 0;
      }

      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      string strBCR = string.Format("BCR: {0}", CVo.strLotBCR);
      btn_Auto_BCRManual.Text = strBCR;


      lbl_LE_NoExist.BackColor = CIoVo.Get_RB_Input(enumBitInput.B2030_Loading_Material_CheckSensor) ? Color.Lime : Color.White;
      tmr_Main.Enabled = true;
    }

    private void FormPageAuto_Load(object sender, EventArgs e)
    {
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      grid_Main_PCBInfo.RowCount = 0;
      GetParam();
      grid_Main_CycleInfo.RowCount = 3;
      Display_Refresh();
    }

    private bool CheckError(enumError start, enumError end)
    {
      // 알람이 발생하면 true 반환
      if ((int)start > (int)end)
      {
        return true;
      }
      bool bResult = false;
      for (int i = (int)start; i < (int)end; i++)
      {
        if (CIoVo.Get_RB_Error((enumError)i))
        {
          bResult = true;
          break;
        }
      }
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void btnCountAmount_Save_Click(object sender, EventArgs e)
    {
      if (Save_CountAmount())
      {
        grid_Main_PCBInfo.RowCount = 0;
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemAutoCountAmountSaveFail);
      }
    }

    private void txtCountAmount_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "Number");

      if (strData.Trim().CompareTo("") == 0)
      {
        // 값없음
        return;
      }
      int iTemp;
      if (int.TryParse(strData, out iTemp) == false)
      {
        // 숫자아님
        return;
      }

      cTempSystem.iCountAmount = Convert.ToInt32(strData);
      Display_Refresh();
    }

    private void Display_Refresh()
    {
      txtCountAmount.Text = cTempSystem.iCountAmount.ToString();
    }

    private void FormPageAuto_Shown(object sender, EventArgs e)
    {
      GetParam();
      Display_Refresh();
    }

    private void FormPageAuto_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        GetParam();
        Display_Refresh();
      }
    }

    private bool Save_CountAmount()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iCountAmount = cTempSystem.iCountAmount;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        grid_Main_PCBInfo.RowCount = 0;
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool Add_PCBData(structPCBData PCBData)
    {
      if (this.InvokeRequired)
      {
        del_Add_PCBData Add_PCBData_ = new del_Add_PCBData(Add_PCBData);
        object obj = this.Invoke(Add_PCBData_, new object[] { PCBData });
        return (bool)obj;
      }
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      List<string> listData = new List<string>();
      listData.Clear();

      for (int i = 0; i < grid_Main_PCBInfo.RowCount; i++)
      {
        string strData = "";
        for (int j = 0; j < grid_Main_PCBInfo.ColumnCount; j++)
        {
          if (j == 0)
          {
            if (grid_Main_PCBInfo.Rows[i].Cells[j].Value != null)
            {
              strData += grid_Main_PCBInfo.Rows[i].Cells[j].Value.ToString();              
            }
          }
          else
          {
            if (grid_Main_PCBInfo.Rows[i].Cells[j].Value != null)
            {
              strData += ("," + grid_Main_PCBInfo.Rows[i].Cells[j].Value.ToString());
            }
          }
        }
        listData.Add(strData);
      }

      string strResult = "";
      switch (PCBData.Result)
      {
        case enumPCBResult.A:
          strResult = "OK";
          break;
        case enumPCBResult.B:
        case enumPCBResult.C:
        case enumPCBResult.D:
        case enumPCBResult.NONE:
        default:
          strResult = "NG";
          break;
      }
      string strNewData = "0";
      strNewData += ("," + PCBData.BCR.ToString());
      strNewData += ("," + strResult);
      //strNewData += ("," + PCBData.Result.ToString()); // 결과값 바꿔줄수도,
      strNewData += ("," + PCBData.Max.ToString("0.000"));
      strNewData += ("," + PCBData.Min.ToString("0.000"));
      strNewData += ("," + PCBData.Gap.ToString("0.000"));
      for (int i = 0; i < PCBData.MeasurePointValue.Count; i++)
      {
        strNewData += ("," + PCBData.MeasurePointValue[i].ToString("0.000"));
      }
      listData.Add(strNewData);
      if (listData.Count > cSys.iCountAmount)
      {
        listData.RemoveAt(0);
      }
      grid_Main_PCBInfo.RowCount = listData.Count;
      for (int i = 0; i < listData.Count; i++)
      {
        string[] arrStrData = listData[i].Split(',');
        for (int j = 0; j < arrStrData.Length; j++)
        {
          if (j == 0)
          {
            grid_Main_PCBInfo.Rows[i].Cells[j].Value = (i + 1).ToString();
          }
          else
          {
            grid_Main_PCBInfo.Rows[i].Cells[j].Value = arrStrData[j].ToString();
          }
        }
      }

      System.Drawing.Color cBlank = System.Drawing.Color.Black;
      System.Drawing.Color cMin = Color.FromArgb(CVo.cParaSys.iMinDisplayColor);
      System.Drawing.Color cMax = Color.FromArgb(CVo.cParaSys.iMaxDisplayColor);
      System.Drawing.Color cNormal = System.Drawing.Color.White;



      int iColStartIndex = 6; // 앞쪽에 다른데이터 갯수(측정값 시작 인덱스)
      int iMinIndex = 3; // Min 표기 인덱스
      int iMaxIndex = 4; // Max 표기 인덱스
      for (int i = 0; i < grid_Main_PCBInfo.RowCount; i++)
      {
        for (int j = iColStartIndex; j < grid_Main_PCBInfo.ColumnCount; j++)
        {
          if (grid_Main_PCBInfo.Rows[i].Cells[j].Value == null)
          {
            grid_Main_PCBInfo.Rows[i].Cells[j].Style.BackColor = cBlank;
          }
          else
          {
            if (grid_Main_PCBInfo.Rows[i].Cells[j].Value.ToString().Trim().CompareTo("") == 0)
            {
              grid_Main_PCBInfo.Rows[i].Cells[j].Style.BackColor = cBlank;
            }
            else
            {
              double dMin = 0;
              double dMax = 0;
              double dValue = 0;
              double.TryParse(grid_Main_PCBInfo.Rows[i].Cells[iMinIndex].Value.ToString(), out dMin);
              double.TryParse(grid_Main_PCBInfo.Rows[i].Cells[iMaxIndex].Value.ToString(), out dMax);
              double.TryParse(grid_Main_PCBInfo.Rows[i].Cells[j].Value.ToString(), out dValue);
              if (dMin == dValue)
              {
                grid_Main_PCBInfo.Rows[i].Cells[j].Style.BackColor = cMin;
              }
              else if (dMax == dValue)
              {
                grid_Main_PCBInfo.Rows[i].Cells[j].Style.BackColor = cMax;
              }
              else
              {
                grid_Main_PCBInfo.Rows[i].Cells[j].Style.BackColor = cNormal;
              }
            }
          }
        }
      }


      return true;
    }

    private void btn_Auto_LossManual_Click(object sender, EventArgs e)
    {
      if (CVo.eMachineStatus == enumMachineStatus.Auto
       || CVo.eMachineStatus == enumMachineStatus.Cycle
       || CVo.eMachineStatus == enumMachineStatus.Initial
       || CVo.bRunning_All)
      {
        return;
      }
    }

    private void btn_Auto_BCRManual_Click(object sender, EventArgs e)
    {
      if (CVo.eMachineStatus == enumMachineStatus.Auto
       || CVo.eMachineStatus == enumMachineStatus.Cycle
       || CVo.eMachineStatus == enumMachineStatus.Initial
       || CVo.bRunning_All)
      {
        return;
      }
      CVo.strLotBCR = "";
      string strLotBCR_Data = CForm.frmBCR_Lot.Show_();
      if (strLotBCR_Data.CompareTo("Cancel") != 0)
      {
        CVo.strLotBCR = strLotBCR_Data;
      }
    }

    private void tmr_Main_Map_Tick(object sender, EventArgs e)
    {
      tmr_Main_Map.Enabled = false;
      CForm.Draw_PCBMap_Number(this, pic_AutoMap, new Label());


      tmr_Main_Map.Enabled = true;
    }

    public void Set_BCR_Image(Image img)
    {
      if (this.InvokeRequired)
      {
        del_Set_BCR_Image Set_BCR_Image_ = new del_Set_BCR_Image(Set_BCR_Image);
        object obj = this.Invoke(Set_BCR_Image_, new object[] { img });
        return;
      }
      if (img != null)
      {
        Bitmap resizeImg = new Bitmap(img, pic_BCR.Width, pic_BCR.Height);
        pic_BCR.Image = resizeImg;
      }
    }
  }
}
