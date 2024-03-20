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
using BASE.MASTER;
using BASE.MODULE.MOTION;

namespace BASE.FORM.PAGE
{
  public partial class FormPageSetup : Form
  {
    private ClassSystemPara cTempSystem = new ClassSystemPara();
    private double dLampTimer = 0;


    public FormPageSetup()
    {
      InitializeComponent();
    }

    private void FormPageSetup_Load(object sender, EventArgs e)
    {
      cboProbe1_Com.Items.Clear();
      for (int i = 0; i < 10; i++)
      {
        cboProbe1_Com.Items.Add(i.ToString());
      }
      cboProbe1_Com.SelectedIndex = 0;

      cboProbe1_Baudrate.Items.Clear();
      cboProbe1_Baudrate.Items.Add("9600");
      cboProbe1_Baudrate.Items.Add("14400");
      cboProbe1_Baudrate.Items.Add("19200");
      cboProbe1_Baudrate.Items.Add("38400");
      cboProbe1_Baudrate.Items.Add("38400");
      cboProbe1_Baudrate.Items.Add("57600");
      cboProbe1_Baudrate.Items.Add("115200");
      cboProbe1_Baudrate.Items.Add("128000");
      cboProbe1_Baudrate.SelectedIndex = 0;

      cboProbe2_Com.Items.Clear();
      for (int i = 0; i < 10; i++)
      {
        cboProbe2_Com.Items.Add(i.ToString());
      }
      cboProbe2_Com.SelectedIndex = 0;

      cboProbe2_Baudrate.Items.Clear();
      cboProbe2_Baudrate.Items.Add("9600");
      cboProbe2_Baudrate.Items.Add("14400");
      cboProbe2_Baudrate.Items.Add("19200");
      cboProbe2_Baudrate.Items.Add("38400");
      cboProbe2_Baudrate.Items.Add("38400");
      cboProbe2_Baudrate.Items.Add("57600");
      cboProbe2_Baudrate.Items.Add("115200");
      cboProbe2_Baudrate.Items.Add("128000");
      cboProbe1_Baudrate.SelectedIndex = 0;

      cboData_LampStatus.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumMachineStatus)).Length; i++)
      {
        cboData_LampStatus.Items.Add(((enumMachineStatus)i).ToString());
      }
      cboData_LampStatus.SelectedIndex = 0;

      cboLanguage.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumLanguageType)).Length; i++)
      {
        cboLanguage.Items.Add(((enumLanguageType)i).ToString());
      }
    }

    private void GetParam()
    {
      cTempSystem = CVo.cParaSys.GetValues();
    }

    private void Display_Refresh()
    {
      for (int i = 0; i < cboProbe1_Com.Items.Count; i++)
      {
        if (cboProbe1_Com.Items[i].ToString().CompareTo(cTempSystem.strProbe1_Com) == 0)
        {
          cboProbe1_Com.SelectedIndex = i;
          break;
        }
      }
      for (int i = 0; i < cboProbe1_Baudrate.Items.Count; i++)
      {
        if (cboProbe1_Baudrate.Items[i].ToString().CompareTo(cTempSystem.strProbe1_Baudrate) == 0)
        {
          cboProbe1_Baudrate.SelectedIndex = i;
          break;
        }
      }

      for (int i = 0; i < cboProbe2_Com.Items.Count; i++)
      {
        if (cboProbe2_Com.Items[i].ToString().CompareTo(cTempSystem.strProbe2_Com) == 0)
        {
          cboProbe2_Com.SelectedIndex = i;
          break;
        }
      }
      for (int i = 0; i < cboProbe2_Baudrate.Items.Count; i++)
      {
        if (cboProbe2_Baudrate.Items[i].ToString().CompareTo(cTempSystem.strProbe2_Baudrate) == 0)
        {
          cboProbe2_Baudrate.SelectedIndex = i;
          break;
        }
      }


      if (cTempSystem.strBCR_IPAddress.Split('.').Length >= 4)
      {
        txtBCRAddress_1.Text = cTempSystem.strBCR_IPAddress.Split('.')[0];
        txtBCRAddress_2.Text = cTempSystem.strBCR_IPAddress.Split('.')[1];
        txtBCRAddress_3.Text = cTempSystem.strBCR_IPAddress.Split('.')[2];
        txtBCRAddress_4.Text = cTempSystem.strBCR_IPAddress.Split('.')[3];
      }

      txtPlcStation.Text = cTempSystem.iPLC_StationNumber.ToString();
      if (cTempSystem.strPLC_HostAddress.Split('.').Length >= 4)
      {
        txtPlcAddress_1.Text = cTempSystem.strPLC_HostAddress.Split('.')[0];
        txtPlcAddress_2.Text = cTempSystem.strPLC_HostAddress.Split('.')[1];
        txtPlcAddress_3.Text = cTempSystem.strPLC_HostAddress.Split('.')[2];
        txtPlcAddress_4.Text = cTempSystem.strPLC_HostAddress.Split('.')[3];
      }
      txtPlcIoNumber.Text = cTempSystem.iPLC_IONumber.ToString();
      txtPlcCpuType.Text = cTempSystem.iPLC_CpuType.ToString();
      txtPlcTimeout.Text = cTempSystem.iPLC_TimeOut.ToString();




      txtReadyPos_LE.Text = cTempSystem.dLE_Ready_Pos.ToString();
      txtReadyPos_LP.Text = cTempSystem.dLP_Ready_Pos.ToString();
      txtReadyPos_BCX.Text = cTempSystem.dBCX_Ready_Pos.ToString();
      txtReadyPos_BCY.Text = cTempSystem.dBCY_Ready_Pos.ToString();
      txtReadyPos_ALX.Text = cTempSystem.dALX_Ready_Pos.ToString();
      txtReadyPos_ALY.Text = cTempSystem.dALY_Ready_Pos.ToString();
      txtReadyPos_X1.Text = cTempSystem.dX1_Ready_Pos.ToString();
      txtReadyPos_X2.Text = cTempSystem.dX2_Ready_Pos.ToString();
      txtReadyPos_Z1.Text = cTempSystem.dZ1_Ready_Pos.ToString();
      txtReadyPos_Z2.Text = cTempSystem.dZ2_Ready_Pos.ToString();
      txtReadyPos_PR1.Text = cTempSystem.dPR1_Ready_Pos.ToString();
      txtReadyPos_PR2.Text = cTempSystem.dPR2_Ready_Pos.ToString();
      txtReadyPos_PR3.Text = cTempSystem.dPR3_Ready_Pos.ToString();
      txtReadyPos_PR4.Text = cTempSystem.dPR4_Ready_Pos.ToString();
      txtReadyPos_UPX.Text = cTempSystem.dUPX_Ready_Pos.ToString();
      txtReadyPos_UPY.Text = cTempSystem.dUPY_Ready_Pos.ToString();
      txtReadyPos_UE1.Text = cTempSystem.dUE1_Ready_Pos.ToString();
      txtReadyPos_UE2.Text = cTempSystem.dUE2_Ready_Pos.ToString();
      txtReadyPos_UE3.Text = cTempSystem.dUE3_Ready_Pos.ToString();
      txtReadyPos_UE4.Text = cTempSystem.dUE4_Ready_Pos.ToString();

      txtNormalSpd_LE.Text = cTempSystem.dLE_Normal_Spd.ToString();
      txtNormalSpd_LP.Text = cTempSystem.dLP_Normal_Spd.ToString();
      txtNormalSpd_BCX.Text = cTempSystem.dBCX_Normal_Spd.ToString();
      txtNormalSpd_BCY.Text = cTempSystem.dBCY_Normal_Spd.ToString();
      txtNormalSpd_ALX.Text = cTempSystem.dALX_Normal_Spd.ToString();
      txtNormalSpd_ALY.Text = cTempSystem.dALY_Normal_Spd.ToString();
      txtNormalSpd_X1.Text = cTempSystem.dX1_Normal_Spd.ToString();
      txtNormalSpd_X2.Text = cTempSystem.dX2_Normal_Spd.ToString();
      txtNormalSpd_Z1.Text = cTempSystem.dZ1_Normal_Spd.ToString();
      txtNormalSpd_Z2.Text = cTempSystem.dZ2_Normal_Spd.ToString();
      txtNormalSpd_PR1.Text = cTempSystem.dPR1_Normal_Spd.ToString();
      txtNormalSpd_PR2.Text = cTempSystem.dPR2_Normal_Spd.ToString();
      txtNormalSpd_PR3.Text = cTempSystem.dPR3_Normal_Spd.ToString();
      txtNormalSpd_PR4.Text = cTempSystem.dPR4_Normal_Spd.ToString();
      txtNormalSpd_UPX.Text = cTempSystem.dUPX_Normal_Spd.ToString();
      txtNormalSpd_UPY.Text = cTempSystem.dUPY_Normal_Spd.ToString();
      txtNormalSpd_UE1.Text = cTempSystem.dUE1_Normal_Spd.ToString();
      txtNormalSpd_UE2.Text = cTempSystem.dUE2_Normal_Spd.ToString();
      txtNormalSpd_UE3.Text = cTempSystem.dUE3_Normal_Spd.ToString();
      txtNormalSpd_UE4.Text = cTempSystem.dUE4_Normal_Spd.ToString();

      txtLowSpd_LE.Text = cTempSystem.dLE_Low_Spd.ToString();
      txtLowSpd_LP.Text = cTempSystem.dLP_Low_Spd.ToString();
      txtLowSpd_BCX.Text = cTempSystem.dBCX_Low_Spd.ToString();
      txtLowSpd_BCY.Text = cTempSystem.dBCY_Low_Spd.ToString();
      txtLowSpd_ALX.Text = cTempSystem.dALX_Low_Spd.ToString();
      txtLowSpd_ALY.Text = cTempSystem.dALY_Low_Spd.ToString();
      txtLowSpd_X1.Text = cTempSystem.dX1_Low_Spd.ToString();
      txtLowSpd_X2.Text = cTempSystem.dX2_Low_Spd.ToString();
      txtLowSpd_Z1.Text = cTempSystem.dZ1_Low_Spd.ToString();
      txtLowSpd_Z2.Text = cTempSystem.dZ2_Low_Spd.ToString();
      txtLowSpd_PR1.Text = cTempSystem.dPR1_Low_Spd.ToString();
      txtLowSpd_PR2.Text = cTempSystem.dPR2_Low_Spd.ToString();
      txtLowSpd_PR3.Text = cTempSystem.dPR3_Low_Spd.ToString();
      txtLowSpd_PR4.Text = cTempSystem.dPR4_Low_Spd.ToString();
      txtLowSpd_UPX.Text = cTempSystem.dUPX_Low_Spd.ToString();
      txtLowSpd_UPY.Text = cTempSystem.dUPY_Low_Spd.ToString();
      txtLowSpd_UE1.Text = cTempSystem.dUE1_Low_Spd.ToString();
      txtLowSpd_UE2.Text = cTempSystem.dUE2_Low_Spd.ToString();
      txtLowSpd_UE3.Text = cTempSystem.dUE3_Low_Spd.ToString();
      txtLowSpd_UE4.Text = cTempSystem.dUE4_Low_Spd.ToString();

      txtScanStartPos_LE.Text = cTempSystem.dLE_ScanStart_Pos.ToString();
      txtScanStartPos_UE1.Text = cTempSystem.dUE1_ScanStart_Pos.ToString();
      txtScanStartPos_UE2.Text = cTempSystem.dUE2_ScanStart_Pos.ToString();
      txtScanStartPos_UE3.Text = cTempSystem.dUE3_ScanStart_Pos.ToString();
      txtScanStartPos_UE4.Text = cTempSystem.dUE4_ScanStart_Pos.ToString();

      txtScanEndPos_LE.Text = cTempSystem.dLE_ScanEnd_Pos.ToString();
      txtScanEndPos_UE1.Text = cTempSystem.dUE1_ScanEnd_Pos.ToString();
      txtScanEndPos_UE2.Text = cTempSystem.dUE2_ScanEnd_Pos.ToString();
      txtScanEndPos_UE3.Text = cTempSystem.dUE3_ScanEnd_Pos.ToString();
      txtScanEndPos_UE4.Text = cTempSystem.dUE4_ScanEnd_Pos.ToString();

      txtCassetteWaitPos_LE.Text = cTempSystem.dLE_Cassette_Wait_Pos.ToString();
      txtCassetteWaitPos_UE1.Text = cTempSystem.dUE1_Cassette_Wait_Pos.ToString();
      txtCassetteWaitPos_UE2.Text = cTempSystem.dUE2_Cassette_Wait_Pos.ToString();
      txtCassetteWaitPos_UE3.Text = cTempSystem.dUE3_Cassette_Wait_Pos.ToString();
      txtCassetteWaitPos_UE4.Text = cTempSystem.dUE4_Cassette_Wait_Pos.ToString();

      txtDownOffset_LE.Text = cTempSystem.dLE_DownOffset_Pos.ToString();

      txtCenter_PR1.Text = cTempSystem.dPR1_Center_Pos.ToString();
      txtCenter_PR2.Text = cTempSystem.dPR2_Center_Pos.ToString();
      txtCenter_PR3.Text = cTempSystem.dPR3_Center_Pos.ToString();
      txtCenter_PR4.Text = cTempSystem.dPR4_Center_Pos.ToString();
      txtClean_PR1.Text = cTempSystem.dPR1_Clean_Pos.ToString();
      txtClean_PR2.Text = cTempSystem.dPR2_Clean_Pos.ToString();
      txtClean_PR3.Text = cTempSystem.dPR3_Clean_Pos.ToString();
      txtClean_PR4.Text = cTempSystem.dPR4_Clean_Pos.ToString();
      txtChange_PR1.Text = cTempSystem.dPR1_Change_Pos.ToString();
      txtChange_PR2.Text = cTempSystem.dPR2_Change_Pos.ToString();
      txtChange_PR3.Text = cTempSystem.dPR3_Change_Pos.ToString();
      txtChange_PR4.Text = cTempSystem.dPR4_Change_Pos.ToString();

      txtLoadingPos_ALX.Text = cTempSystem.dALX_Loading_Pos.ToString();
      txtLoadingPos_ALY.Text = cTempSystem.dALY_Loading_Pos.ToString();

      txtUnloadingPos_ALX.Text = cTempSystem.dALX_Unloading_Pos.ToString();
      txtUnloadingPos_ALY.Text = cTempSystem.dALY_Unloading_Pos.ToString();

      txtAlignBackOffset_ALX.Text = cTempSystem.dALX_AlignBackOffset_Pos.ToString();
      txtAlignBackOffset_ALY.Text = cTempSystem.dALY_AlignBackOffset_Pos.ToString();

      txtAlignStartPos_ALX.Text = cTempSystem.dALX_AlignStart_Pos.ToString();
      txtAlignStartPos_ALY.Text = cTempSystem.dALY_AlignStart_Pos.ToString();

      txtLEPos_LP.Text = cTempSystem.dLP_LE_Pos.ToString();
      txtAlignPos_LP.Text = cTempSystem.dLP_AL_Pos.ToString();
      txtAlignUnloadingPos_LP.Text = cTempSystem.dLP_AL_Unloading_Pos.ToString();      
      txtX1Pos_LP.Text = cTempSystem.dLP_Stage1_Pos.ToString();
      txtX2Pos_LP.Text = cTempSystem.dLP_Stage2_Pos.ToString();

      txtUnloaderUE1_UPX.Text = cTempSystem.dUPX_UE1_Pos.ToString();
      txtUnloaderUE2_UPX.Text = cTempSystem.dUPX_UE2_Pos.ToString();
      txtUnloaderUE3_UPX.Text = cTempSystem.dUPX_UE3_Pos.ToString();
      txtUnloaderUE4_UPX.Text = cTempSystem.dUPX_UE4_Pos.ToString();
      txtUnloaderX1_UPX.Text = cTempSystem.dUPX_Stage1_Pos.ToString();
      txtUnloaderX2_UPX.Text = cTempSystem.dUPX_Stage2_Pos.ToString();

      txtUnloaderUE1_UPY.Text = cTempSystem.dUPY_UE1_Pos.ToString();
      txtUnloaderUE2_UPY.Text = cTempSystem.dUPY_UE2_Pos.ToString();
      txtUnloaderUE3_UPY.Text = cTempSystem.dUPY_UE3_Pos.ToString();
      txtUnloaderUE4_UPY.Text = cTempSystem.dUPY_UE4_Pos.ToString();
      txtUnloaderX1_UPY.Text = cTempSystem.dUPY_Stage1_Pos.ToString();
      txtUnloaderX2_UPY.Text = cTempSystem.dUPY_Stage2_Pos.ToString();

      txtStageLoading_X1.Text = cTempSystem.dX1_Loading_Pos.ToString();
      txtStageUnloading_X1.Text = cTempSystem.dX1_Unloading_Pos.ToString();
      txtStageCenter_X1.Text = cTempSystem.dX1_Center_Pos.ToString();
      txtStageCleanStart_X1.Text = cTempSystem.dX1_CleanStart_Pos.ToString();
      txtStageCleanEnd_X1.Text = cTempSystem.dX1_CleanEnd_Pos.ToString();
      txtStageProbeClean_X1.Text = cTempSystem.dX1_CleanProbe_Pos.ToString();
      txtStageInterlockMinus_X1.Text = cTempSystem.dX1_Interlock_Minus.ToString();
      txtStageInterlockPlus_X1.Text = cTempSystem.dX1_Interlock_Plus.ToString();

      txtStageLoading_X2.Text = cTempSystem.dX2_Loading_Pos.ToString();
      txtStageUnloading_X2.Text = cTempSystem.dX2_Unloading_Pos.ToString();
      txtStageCenter_X2.Text = cTempSystem.dX2_Center_Pos.ToString();
      txtStageCleanStart_X2.Text = cTempSystem.dX2_CleanStart_Pos.ToString();
      txtStageCleanEnd_X2.Text = cTempSystem.dX2_CleanEnd_Pos.ToString();
      txtStageProbeClean_X2.Text = cTempSystem.dX2_CleanProbe_Pos.ToString();
      txtStageInterlockMinus_X2.Text = cTempSystem.dX2_Interlock_Minus.ToString();
      txtStageInterlockPlus_X2.Text = cTempSystem.dX2_Interlock_Plus.ToString();

      txtZLoading_Z1.Text = cTempSystem.dZ1_Loading_Pos.ToString();
      txtZUnloading_Z1.Text = cTempSystem.dZ1_Unloading_Pos.ToString();
      txtZCenter_Z1.Text = cTempSystem.dZ1_Center_Pos.ToString();

      txtZLoading_Z2.Text = cTempSystem.dZ2_Loading_Pos.ToString();
      txtZUnloading_Z2.Text = cTempSystem.dZ2_Unloading_Pos.ToString();
      txtZCenter_Z2.Text = cTempSystem.dZ2_Center_Pos.ToString();

      txtData_LoadingShakeCount.Text = cTempSystem.iShakeCount.ToString();
      cboLEAirBlowMode.SelectedIndex = cTempSystem.iLEAirBlowMode;
      txtData_ZeroSetPeriod.Text = cTempSystem.iZerosetPeriod.ToString();
      txtData_StageCleanCount.Text = cTempSystem.iStageCleanCount.ToString();
      txtData_ProbeCleanCount.Text = cTempSystem.iProbeCleanCount.ToString();
      txtData_ReMeasureCount.Text = cTempSystem.iReMeasureCount.ToString();
      txtData_PreStageCleanCount.Text = cTempSystem.iPreStageCleanCount.ToString();
      txtData_AfterStageCleanCount.Text = cTempSystem.iAfterStageCleanCount.ToString();

      cboLanguage.SelectedIndex = cTempSystem.iLanguage;
      txtData_LogDeletePeriod.Text = cTempSystem.iDeleteLogPeriod.ToString(); ;

      txtCwLimit_LE.Text = cTempSystem.dLE_LimitCw.ToString();
      txtCwLimit_LP.Text = cTempSystem.dLP_LimitCw.ToString();
      txtCwLimit_BCX.Text = cTempSystem.dBCX_LimitCw.ToString();
      txtCwLimit_BCY.Text = cTempSystem.dBCY_LimitCw.ToString();
      txtCwLimit_ALX.Text = cTempSystem.dALX_LimitCw.ToString();
      txtCwLimit_ALY.Text = cTempSystem.dALY_LimitCw.ToString();
      txtCwLimit_X1.Text = cTempSystem.dX1_LimitCw.ToString();
      txtCwLimit_X2.Text = cTempSystem.dX2_LimitCw.ToString();
      txtCwLimit_Z1.Text = cTempSystem.dZ1_LimitCw.ToString();
      txtCwLimit_Z2.Text = cTempSystem.dZ2_LimitCw.ToString();
      txtCwLimit_PR1.Text = cTempSystem.dPR1_LimitCw.ToString();
      txtCwLimit_PR2.Text = cTempSystem.dPR2_LimitCw.ToString();
      txtCwLimit_PR3.Text = cTempSystem.dPR3_LimitCw.ToString();
      txtCwLimit_PR4.Text = cTempSystem.dPR4_LimitCw.ToString();
      txtCwLimit_UPX.Text = cTempSystem.dUPX_LimitCw.ToString();
      txtCwLimit_UPY.Text = cTempSystem.dUPY_LimitCw.ToString();
      txtCwLimit_UE1.Text = cTempSystem.dUE1_LimitCw.ToString();
      txtCwLimit_UE2.Text = cTempSystem.dUE2_LimitCw.ToString();
      txtCwLimit_UE3.Text = cTempSystem.dUE3_LimitCw.ToString();
      txtCwLimit_UE4.Text = cTempSystem.dUE4_LimitCw.ToString();

      txtCcwLimit_LE.Text = cTempSystem.dLE_LimitCcw.ToString();
      txtCcwLimit_LP.Text = cTempSystem.dLP_LimitCcw.ToString();
      txtCcwLimit_BCX.Text = cTempSystem.dBCX_LimitCcw.ToString();
      txtCcwLimit_BCY.Text = cTempSystem.dBCY_LimitCcw.ToString();
      txtCcwLimit_ALX.Text = cTempSystem.dALX_LimitCcw.ToString();
      txtCcwLimit_ALY.Text = cTempSystem.dALY_LimitCcw.ToString();
      txtCcwLimit_X1.Text = cTempSystem.dX1_LimitCcw.ToString();
      txtCcwLimit_X2.Text = cTempSystem.dX2_LimitCcw.ToString();
      txtCcwLimit_Z1.Text = cTempSystem.dZ1_LimitCcw.ToString();
      txtCcwLimit_Z2.Text = cTempSystem.dZ2_LimitCcw.ToString();
      txtCcwLimit_PR1.Text = cTempSystem.dPR1_LimitCcw.ToString();
      txtCcwLimit_PR2.Text = cTempSystem.dPR2_LimitCcw.ToString();
      txtCcwLimit_PR3.Text = cTempSystem.dPR3_LimitCcw.ToString();
      txtCcwLimit_PR4.Text = cTempSystem.dPR4_LimitCcw.ToString();
      txtCcwLimit_UPX.Text = cTempSystem.dUPX_LimitCcw.ToString();
      txtCcwLimit_UPY.Text = cTempSystem.dUPY_LimitCcw.ToString();
      txtCcwLimit_UE1.Text = cTempSystem.dUE1_LimitCcw.ToString();
      txtCcwLimit_UE2.Text = cTempSystem.dUE2_LimitCcw.ToString();
      txtCcwLimit_UE3.Text = cTempSystem.dUE3_LimitCcw.ToString();
      txtCcwLimit_UE4.Text = cTempSystem.dUE4_LimitCcw.ToString();

      txtLimitMinus_MainAir.Text = cTempSystem.dMainAir_CylinderLimitMinus.ToString();
      txtLimitMinus_MainAir_Vaccum.Text = cTempSystem.dMainAir_VaccumLimitMinus.ToString();
      txtLimitMinus_LPVacuum.Text = cTempSystem.dLP_Vacuum_LimitMinus.ToString();
      txtLimitMinus_UPVacuum.Text = cTempSystem.dUP_Vacuum_LimitMinus.ToString();
      txtLimitMinus_Stage1Vacuum.Text = cTempSystem.dStage1_Vacuum_LimitMinus.ToString();
      txtLimitMinus_Stage2Vacuum.Text = cTempSystem.dStage2_Vacuum_LimitMinus.ToString();

      txtLimitPlus_LPVacuum.Text = cTempSystem.dLP_Vacuum_LimitPlus.ToString();
      txtLimitPlus_UPVacuum.Text = cTempSystem.dUP_Vacuum_LimitPlus.ToString();
      txtLimitPlus_Stage1Vacuum.Text = cTempSystem.dStage1_Vacuum_LimitPlus.ToString();
      txtLimitPlus_Stage2Vacuum.Text = cTempSystem.dStage2_Vacuum_LimitPlus.ToString();

      txtErrorDelay_Cylinder.Text = cTempSystem.iErrorDelayTime_Cylinder.ToString();
      txtErrorDelay_LPVacuum.Text = cTempSystem.iErrorDelayTime_LPVacuum.ToString();
      txtErrorDelay_UPVacuum.Text = cTempSystem.iErrorDelayTime_UPVacuum.ToString();
      txtErrorDelay_Stage1Vacuum.Text = cTempSystem.iErrorDelayTime_Stage1Vacuum.ToString();
      txtErrorDelay_Stage2Vacuum.Text = cTempSystem.iErrorDelayTime_Stage2Vacuum.ToString();

      txtDelayTime_Cylinder.Text = cTempSystem.iDelayTime_Cylinder.ToString();
      txtDelayTime_LPVacuum.Text = cTempSystem.iDelayTime_LPVacuum.ToString();
      txtDelayTime_UPVacuum.Text = cTempSystem.iDelayTime_UPVacuum.ToString();
      txtDelayTime_Stage1Vacuum.Text = cTempSystem.iDelayTime_Stage1Vacuum.ToString();
      txtDelayTime_Stage2Vacuum.Text = cTempSystem.iDelayTime_Stage2Vacuum.ToString();
      txtDelayTime_Measure.Text = cTempSystem.iDelayTime_Measure.ToString();
      txtDelayTime_Align.Text = cTempSystem.iDelayTime_Align.ToString();

      txtRunTime_AirBlow.Text = cTempSystem.iRunTime_AirBlow.ToString();

      chkUse_PB1.Checked = cTempSystem.bUsePB1;
      chkUse_PB2.Checked = cTempSystem.bUsePB2;
      chkUse_PB3.Checked = cTempSystem.bUsePB3;
      chkUse_PB4.Checked = cTempSystem.bUsePB4;

      btn_Color_Max.BackColor = Color.FromArgb(cTempSystem.iMaxDisplayColor);
      btn_Color_Min.BackColor = Color.FromArgb(cTempSystem.iMinDisplayColor);

      chkUse_BCR_1D.Checked = cTempSystem.bUseBarcode_1D;
      chkUse_BCR.Checked = cTempSystem.bUseBarcode_2D;
      chkUse_LoadingShake.Checked = cTempSystem.bUseLoadingShake;

      txtOffset_Probe1.Text = cTempSystem.dProbeOffset_1.ToString("0.000");
      txtOffset_Probe2.Text = cTempSystem.dProbeOffset_2.ToString("0.000");
      txtOffset_Probe3.Text = cTempSystem.dProbeOffset_3.ToString("0.000");
      txtOffset_Probe4.Text = cTempSystem.dProbeOffset_4.ToString("0.000");

      txtValueAverage_Count.Text = cTempSystem.iProbeValueAverageCount.ToString();
      txtValueAverage_MinCount.Text = cTempSystem.iProbeValueAverageMin.ToString();
      txtValueAverage_MaxCount.Text = cTempSystem.iProbeValueAverageMax.ToString();

      txtSafetyLimitPos_Z1.Text = cTempSystem.dZ1_Safety_Limit.ToString();
      txtSafetyLimitPos_Z2.Text = cTempSystem.dZ2_Safety_Limit.ToString();

      txtSafetyLimitPos_Probe_Stage1.Text = cTempSystem.dProbe_Stage1_Safety_Gap.ToString();
      txtSafetyLimitPos_Probe_Stage2.Text = cTempSystem.dProbe_Stage2_Safety_Gap.ToString();

      switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
      {
        case enumMachineStatus.None:
          txtDataLampBlinkTime.Text = cTempSystem.iLampNone_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampNone_R, cTempSystem.iLampNone_Y, cTempSystem.iLampNone_G);
          SetBuzz(cTempSystem.iBuzzNone_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzNone_Time.ToString();
          break;
        case enumMachineStatus.Initial:
          txtDataLampBlinkTime.Text = cTempSystem.iLampInitail_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampInitail_R, cTempSystem.iLampInitail_Y, cTempSystem.iLampInitail_G);
          SetBuzz(cTempSystem.iBuzzInitail_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzInitail_Time.ToString();
          break;
        case enumMachineStatus.Idle:
          txtDataLampBlinkTime.Text = cTempSystem.iLampIdle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampIdle_R, cTempSystem.iLampIdle_Y, cTempSystem.iLampIdle_G);
          SetBuzz(cTempSystem.iBuzzIdle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzIdle_Time.ToString();
          break;
        case enumMachineStatus.Auto:
          txtDataLampBlinkTime.Text = cTempSystem.iLampAuto_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampAuto_R, cTempSystem.iLampAuto_Y, cTempSystem.iLampAuto_G);
          SetBuzz(cTempSystem.iBuzzAuto_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzAuto_Time.ToString();
          break;
        case enumMachineStatus.Stop:
          txtDataLampBlinkTime.Text = cTempSystem.iLampStop_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampStop_R, cTempSystem.iLampStop_Y, cTempSystem.iLampStop_G);
          SetBuzz(cTempSystem.iBuzzStop_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzStop_Time.ToString();
          break;
        case enumMachineStatus.ErrorAuto:
          txtDataLampBlinkTime.Text = cTempSystem.iLampErrorAuto_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampErrorAuto_R, cTempSystem.iLampErrorAuto_Y, cTempSystem.iLampErrorAuto_G);
          SetBuzz(cTempSystem.iBuzzErrorAuto_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzErrorAuto_Time.ToString();
          break;
        case enumMachineStatus.Error:
          txtDataLampBlinkTime.Text = cTempSystem.iLampErrorCycle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampErrorCycle_R, cTempSystem.iLampErrorCycle_Y, cTempSystem.iLampErrorCycle_G);
          SetBuzz(cTempSystem.iBuzzErrorCycle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzErrorCycle_Time.ToString();
          break;
        case enumMachineStatus.Cycle:
          txtDataLampBlinkTime.Text = cTempSystem.iLampCycle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampCycle_R, cTempSystem.iLampCycle_Y, cTempSystem.iLampCycle_G);
          SetBuzz(cTempSystem.iBuzzCycle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzCycle_Time.ToString();
          break;
        default:
          break;
      }
    }

    private void SetLamp(int r, int y, int g)
    {
      switch ((enumTowerLamp)r)
      {
        case enumTowerLamp.On:
          rdoR_On.Checked = true;
          rdoR_Blink.Checked = false;
          rdoR_Off.Checked = false;
          break;
        case enumTowerLamp.Blink:
          rdoR_On.Checked = false;
          rdoR_Blink.Checked = true;
          rdoR_Off.Checked = false;
          break;
        case enumTowerLamp.Off:
          rdoR_On.Checked = false;
          rdoR_Blink.Checked = false;
          rdoR_Off.Checked = true;
          break;
        default:
          break;
      }
      switch ((enumTowerLamp)y)
      {
        case enumTowerLamp.On:
          rdoY_On.Checked = true;
          rdoY_Blink.Checked = false;
          rdoY_Off.Checked = false;
          break;
        case enumTowerLamp.Blink:
          rdoY_On.Checked = false;
          rdoY_Blink.Checked = true;
          rdoY_Off.Checked = false;
          break;
        case enumTowerLamp.Off:
          rdoY_On.Checked = false;
          rdoY_Blink.Checked = false;
          rdoY_Off.Checked = true;
          break;
        default:
          break;
      }
      switch ((enumTowerLamp)g)
      {
        case enumTowerLamp.On:
          rdoG_On.Checked = true;
          rdoG_Blink.Checked = false;
          rdoG_Off.Checked = false;
          break;
        case enumTowerLamp.Blink:
          rdoG_On.Checked = false;
          rdoG_Blink.Checked = true;
          rdoG_Off.Checked = false;
          break;
        case enumTowerLamp.Off:
          rdoG_On.Checked = false;
          rdoG_Blink.Checked = false;
          rdoG_Off.Checked = true;
          break;
        default:
          break;
      }
    }

    private void SetBuzz(int mode)
    {
      switch ((enumBuzzer)mode)
      {
        case enumBuzzer.End:
          rdoBuzz_End.Checked = true;
          rdoBuzz_Error.Checked = false;
          rdoBuzz_Off.Checked = false;
          break;
        case enumBuzzer.Error:
          rdoBuzz_End.Checked = false;
          rdoBuzz_Error.Checked = true;
          rdoBuzz_Off.Checked = false;
          break;
        case enumBuzzer.Off:
          rdoBuzz_End.Checked = false;
          rdoBuzz_Error.Checked = false;
          rdoBuzz_Off.Checked = true;
          break;
        default:
          break;
      }
    }
    private bool Save_Std_Elevator()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLE_ScanStart_Pos = cTempSystem.dLE_ScanStart_Pos;
      cReplace.dUE1_ScanStart_Pos = cTempSystem.dUE1_ScanStart_Pos;
      cReplace.dUE2_ScanStart_Pos = cTempSystem.dUE2_ScanStart_Pos;
      cReplace.dUE3_ScanStart_Pos = cTempSystem.dUE3_ScanStart_Pos;
      cReplace.dUE4_ScanStart_Pos = cTempSystem.dUE4_ScanStart_Pos;

      cReplace.dLE_ScanEnd_Pos = cTempSystem.dLE_ScanEnd_Pos;
      cReplace.dUE1_ScanEnd_Pos = cTempSystem.dUE1_ScanEnd_Pos;
      cReplace.dUE2_ScanEnd_Pos = cTempSystem.dUE2_ScanEnd_Pos;
      cReplace.dUE3_ScanEnd_Pos = cTempSystem.dUE3_ScanEnd_Pos;
      cReplace.dUE4_ScanEnd_Pos = cTempSystem.dUE4_ScanEnd_Pos;

      cReplace.dLE_Cassette_Wait_Pos = cTempSystem.dLE_Cassette_Wait_Pos;
      cReplace.dUE1_Cassette_Wait_Pos = cTempSystem.dUE1_Cassette_Wait_Pos;
      cReplace.dUE2_Cassette_Wait_Pos = cTempSystem.dUE2_Cassette_Wait_Pos;
      cReplace.dUE3_Cassette_Wait_Pos = cTempSystem.dUE3_Cassette_Wait_Pos;
      cReplace.dUE4_Cassette_Wait_Pos = cTempSystem.dUE4_Cassette_Wait_Pos;

      cReplace.dLE_DownOffset_Pos = cTempSystem.dLE_DownOffset_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Z()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dZ1_Loading_Pos = cTempSystem.dZ1_Loading_Pos;
      cReplace.dZ1_Unloading_Pos = cTempSystem.dZ1_Unloading_Pos;
      cReplace.dZ1_Center_Pos = cTempSystem.dZ1_Center_Pos;

      cReplace.dZ2_Loading_Pos = cTempSystem.dZ2_Loading_Pos;
      cReplace.dZ2_Unloading_Pos = cTempSystem.dZ2_Unloading_Pos;
      cReplace.dZ2_Center_Pos = cTempSystem.dZ2_Center_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Unloader()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dUPX_UE1_Pos = cTempSystem.dUPX_UE1_Pos;
      cReplace.dUPX_UE2_Pos = cTempSystem.dUPX_UE2_Pos;
      cReplace.dUPX_UE3_Pos = cTempSystem.dUPX_UE3_Pos;
      cReplace.dUPX_UE4_Pos = cTempSystem.dUPX_UE4_Pos;
      cReplace.dUPX_Stage1_Pos = cTempSystem.dUPX_Stage1_Pos;
      cReplace.dUPX_Stage2_Pos = cTempSystem.dUPX_Stage2_Pos;

      cReplace.dUPY_UE1_Pos = cTempSystem.dUPY_UE1_Pos;
      cReplace.dUPY_UE2_Pos = cTempSystem.dUPY_UE2_Pos;
      cReplace.dUPY_UE3_Pos = cTempSystem.dUPY_UE3_Pos;
      cReplace.dUPY_UE4_Pos = cTempSystem.dUPY_UE4_Pos;
      cReplace.dUPY_Stage1_Pos = cTempSystem.dUPY_Stage1_Pos;
      cReplace.dUPY_Stage2_Pos = cTempSystem.dUPY_Stage2_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Stage()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      if (cTempSystem.dX1_Interlock_Minus >= cTempSystem.dX1_Interlock_Plus)
      {
        return false;
      }
      if (cTempSystem.dX2_Interlock_Minus >= cTempSystem.dX2_Interlock_Plus)
      {
        return false;
      }

      cReplace.dX1_Loading_Pos = cTempSystem.dX1_Loading_Pos;
      cReplace.dX1_Unloading_Pos = cTempSystem.dX1_Unloading_Pos;
      cReplace.dX1_Center_Pos = cTempSystem.dX1_Center_Pos;
      cReplace.dX1_CleanStart_Pos = cTempSystem.dX1_CleanStart_Pos;
      cReplace.dX1_CleanEnd_Pos = cTempSystem.dX1_CleanEnd_Pos;
      cReplace.dX1_CleanProbe_Pos = cTempSystem.dX1_CleanProbe_Pos;
      cReplace.dX1_Interlock_Minus = cTempSystem.dX1_Interlock_Minus;
      cReplace.dX1_Interlock_Plus = cTempSystem.dX1_Interlock_Plus;

      cReplace.dX2_Loading_Pos = cTempSystem.dX2_Loading_Pos;
      cReplace.dX2_Unloading_Pos = cTempSystem.dX2_Unloading_Pos;
      cReplace.dX2_Center_Pos = cTempSystem.dX2_Center_Pos;
      cReplace.dX2_CleanStart_Pos = cTempSystem.dX2_CleanStart_Pos;
      cReplace.dX2_CleanEnd_Pos = cTempSystem.dX2_CleanEnd_Pos;
      cReplace.dX2_CleanProbe_Pos = cTempSystem.dX2_CleanProbe_Pos;
      cReplace.dX2_Interlock_Minus = cTempSystem.dX2_Interlock_Minus;
      cReplace.dX2_Interlock_Plus = cTempSystem.dX2_Interlock_Plus;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Loader()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLP_LE_Pos = cTempSystem.dLP_LE_Pos;
      cReplace.dLP_AL_Pos = cTempSystem.dLP_AL_Pos;
      cReplace.dLP_AL_Unloading_Pos = cTempSystem.dLP_AL_Unloading_Pos;
      cReplace.dLP_Stage1_Pos = cTempSystem.dLP_Stage1_Pos;
      cReplace.dLP_Stage2_Pos = cTempSystem.dLP_Stage2_Pos;

      cTempSystem.dLP_Ready_Pos = cTempSystem.dLP_AL_Pos;
      cReplace.dLP_Ready_Pos = cTempSystem.dLP_Ready_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Probe()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dPR1_Center_Pos = cTempSystem.dPR1_Center_Pos;
      cReplace.dPR2_Center_Pos = cTempSystem.dPR2_Center_Pos;
      cReplace.dPR3_Center_Pos = cTempSystem.dPR3_Center_Pos;
      cReplace.dPR4_Center_Pos = cTempSystem.dPR4_Center_Pos;
      cReplace.dPR1_Clean_Pos = cTempSystem.dPR1_Clean_Pos;
      cReplace.dPR2_Clean_Pos = cTempSystem.dPR2_Clean_Pos;
      cReplace.dPR3_Clean_Pos = cTempSystem.dPR3_Clean_Pos;
      cReplace.dPR4_Clean_Pos = cTempSystem.dPR4_Clean_Pos;
      cReplace.dPR1_Change_Pos = cTempSystem.dPR1_Change_Pos;
      cReplace.dPR2_Change_Pos = cTempSystem.dPR2_Change_Pos;
      cReplace.dPR3_Change_Pos = cTempSystem.dPR3_Change_Pos;
      cReplace.dPR4_Change_Pos = cTempSystem.dPR4_Change_Pos;
      

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_MotorLimit();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Std_Align()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dALX_Loading_Pos = cTempSystem.dALX_Loading_Pos;
      cReplace.dALY_Loading_Pos = cTempSystem.dALY_Loading_Pos;

      cReplace.dALX_Unloading_Pos = cTempSystem.dALX_Unloading_Pos;
      cReplace.dALY_Unloading_Pos = cTempSystem.dALY_Unloading_Pos;

      cReplace.dALX_AlignBackOffset_Pos = cTempSystem.dALX_AlignBackOffset_Pos;
      cReplace.dALY_AlignBackOffset_Pos = cTempSystem.dALY_AlignBackOffset_Pos;

      cReplace.dALX_AlignStart_Pos = cTempSystem.dALX_AlignStart_Pos;
      cReplace.dALY_AlignStart_Pos = cTempSystem.dALY_AlignStart_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_ReadyPos()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLE_Ready_Pos = cTempSystem.dLE_Ready_Pos;
      //cReplace.dLP_Ready_Pos = cTempSystem.dLP_Ready_Pos;
      cReplace.dBCX_Ready_Pos = cTempSystem.dBCX_Ready_Pos;
      cReplace.dBCY_Ready_Pos = cTempSystem.dBCY_Ready_Pos;
      cReplace.dALX_Ready_Pos = cTempSystem.dALX_Ready_Pos;
      cReplace.dALY_Ready_Pos = cTempSystem.dALY_Ready_Pos;
      cReplace.dX1_Ready_Pos = cTempSystem.dX1_Ready_Pos;
      cReplace.dX2_Ready_Pos = cTempSystem.dX2_Ready_Pos;
      cReplace.dZ1_Ready_Pos = cTempSystem.dZ1_Ready_Pos;
      cReplace.dZ2_Ready_Pos = cTempSystem.dZ2_Ready_Pos;
      cReplace.dPR1_Ready_Pos = cTempSystem.dPR1_Ready_Pos;
      cReplace.dPR2_Ready_Pos = cTempSystem.dPR2_Ready_Pos;
      cReplace.dPR3_Ready_Pos = cTempSystem.dPR3_Ready_Pos;
      cReplace.dPR4_Ready_Pos = cTempSystem.dPR4_Ready_Pos;
      cReplace.dUPX_Ready_Pos = cTempSystem.dUPX_Ready_Pos;
      cReplace.dUPY_Ready_Pos = cTempSystem.dUPY_Ready_Pos;
      cReplace.dUE1_Ready_Pos = cTempSystem.dUE1_Ready_Pos;
      cReplace.dUE2_Ready_Pos = cTempSystem.dUE2_Ready_Pos;
      cReplace.dUE3_Ready_Pos = cTempSystem.dUE3_Ready_Pos;
      cReplace.dUE4_Ready_Pos = cTempSystem.dUE4_Ready_Pos;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_ReadyPos();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_NormalSpd()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLE_Normal_Spd = cTempSystem.dLE_Normal_Spd;
      cReplace.dLP_Normal_Spd = cTempSystem.dLP_Normal_Spd;
      cReplace.dBCX_Normal_Spd = cTempSystem.dBCX_Normal_Spd;
      cReplace.dBCY_Normal_Spd = cTempSystem.dBCY_Normal_Spd;
      cReplace.dALX_Normal_Spd = cTempSystem.dALX_Normal_Spd;
      cReplace.dALY_Normal_Spd = cTempSystem.dALY_Normal_Spd;
      cReplace.dX1_Normal_Spd = cTempSystem.dX1_Normal_Spd;
      cReplace.dX2_Normal_Spd = cTempSystem.dX2_Normal_Spd;
      cReplace.dZ1_Normal_Spd = cTempSystem.dZ1_Normal_Spd;
      cReplace.dZ2_Normal_Spd = cTempSystem.dZ2_Normal_Spd;
      cReplace.dPR1_Normal_Spd = cTempSystem.dPR1_Normal_Spd;
      cReplace.dPR2_Normal_Spd = cTempSystem.dPR2_Normal_Spd;
      cReplace.dPR3_Normal_Spd = cTempSystem.dPR3_Normal_Spd;
      cReplace.dPR4_Normal_Spd = cTempSystem.dPR4_Normal_Spd;
      cReplace.dUPX_Normal_Spd = cTempSystem.dUPX_Normal_Spd;
      cReplace.dUPY_Normal_Spd = cTempSystem.dUPY_Normal_Spd;
      cReplace.dUE1_Normal_Spd = cTempSystem.dUE1_Normal_Spd;
      cReplace.dUE2_Normal_Spd = cTempSystem.dUE2_Normal_Spd;
      cReplace.dUE3_Normal_Spd = cTempSystem.dUE3_Normal_Spd;
      cReplace.dUE4_Normal_Spd = cTempSystem.dUE4_Normal_Spd;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Normal_Spd();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_LowSpd()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLE_Low_Spd = cTempSystem.dLE_Low_Spd;
      cReplace.dLP_Low_Spd = cTempSystem.dLP_Low_Spd;
      cReplace.dBCX_Low_Spd = cTempSystem.dBCX_Low_Spd;
      cReplace.dBCY_Low_Spd = cTempSystem.dBCY_Low_Spd;
      cReplace.dALX_Low_Spd = cTempSystem.dALX_Low_Spd;
      cReplace.dALY_Low_Spd = cTempSystem.dALY_Low_Spd;
      cReplace.dX1_Low_Spd = cTempSystem.dX1_Low_Spd;
      cReplace.dX2_Low_Spd = cTempSystem.dX2_Low_Spd;
      cReplace.dZ1_Low_Spd = cTempSystem.dZ1_Low_Spd;
      cReplace.dZ2_Low_Spd = cTempSystem.dZ2_Low_Spd;
      cReplace.dPR1_Low_Spd = cTempSystem.dPR1_Low_Spd;
      cReplace.dPR2_Low_Spd = cTempSystem.dPR2_Low_Spd;
      cReplace.dPR3_Low_Spd = cTempSystem.dPR3_Low_Spd;
      cReplace.dPR4_Low_Spd = cTempSystem.dPR4_Low_Spd;
      cReplace.dUPX_Low_Spd = cTempSystem.dUPX_Low_Spd;
      cReplace.dUPY_Low_Spd = cTempSystem.dUPY_Low_Spd;
      cReplace.dUE1_Low_Spd = cTempSystem.dUE1_Low_Spd;
      cReplace.dUE2_Low_Spd = cTempSystem.dUE2_Low_Spd;
      cReplace.dUE3_Low_Spd = cTempSystem.dUE3_Low_Spd;
      cReplace.dUE4_Low_Spd = cTempSystem.dUE4_Low_Spd;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Low_Spd();
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_Limit_Motor()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dLE_LimitCw = cTempSystem.dLE_LimitCw;
      cReplace.dLP_LimitCw = cTempSystem.dLP_LimitCw;
      cReplace.dBCX_LimitCw = cTempSystem.dBCX_LimitCw;
      cReplace.dBCY_LimitCw = cTempSystem.dBCY_LimitCw;
      cReplace.dALX_LimitCw = cTempSystem.dALX_LimitCw;
      cReplace.dALY_LimitCw = cTempSystem.dALY_LimitCw;
      cReplace.dX1_LimitCw = cTempSystem.dX1_LimitCw;
      cReplace.dX2_LimitCw = cTempSystem.dX2_LimitCw;
      cReplace.dZ1_LimitCw = cTempSystem.dZ1_LimitCw;
      cReplace.dZ2_LimitCw = cTempSystem.dZ2_LimitCw;
      cReplace.dPR1_LimitCw = cTempSystem.dPR1_LimitCw;
      cReplace.dPR2_LimitCw = cTempSystem.dPR2_LimitCw;
      cReplace.dPR3_LimitCw = cTempSystem.dPR3_LimitCw;
      cReplace.dPR4_LimitCw = cTempSystem.dPR4_LimitCw;
      cReplace.dUPX_LimitCw = cTempSystem.dUPX_LimitCw;
      cReplace.dUPY_LimitCw = cTempSystem.dUPY_LimitCw;
      cReplace.dUE1_LimitCw = cTempSystem.dUE1_LimitCw;
      cReplace.dUE2_LimitCw = cTempSystem.dUE2_LimitCw;
      cReplace.dUE3_LimitCw = cTempSystem.dUE3_LimitCw;
      cReplace.dUE4_LimitCw = cTempSystem.dUE4_LimitCw;

      cReplace.dLE_LimitCcw = cTempSystem.dLE_LimitCcw;
      cReplace.dLP_LimitCcw = cTempSystem.dLP_LimitCcw;
      cReplace.dBCX_LimitCcw = cTempSystem.dBCX_LimitCcw;
      cReplace.dBCY_LimitCcw = cTempSystem.dBCY_LimitCcw;
      cReplace.dALX_LimitCcw = cTempSystem.dALX_LimitCcw;
      cReplace.dALY_LimitCcw = cTempSystem.dALY_LimitCcw;
      cReplace.dX1_LimitCcw = cTempSystem.dX1_LimitCcw;
      cReplace.dX2_LimitCcw = cTempSystem.dX2_LimitCcw;
      cReplace.dZ1_LimitCcw = cTempSystem.dZ1_LimitCcw;
      cReplace.dZ2_LimitCcw = cTempSystem.dZ2_LimitCcw;
      cReplace.dPR1_LimitCcw = cTempSystem.dPR1_LimitCcw;
      cReplace.dPR2_LimitCcw = cTempSystem.dPR2_LimitCcw;
      cReplace.dPR3_LimitCcw = cTempSystem.dPR3_LimitCcw;
      cReplace.dPR4_LimitCcw = cTempSystem.dPR4_LimitCcw;
      cReplace.dUPX_LimitCcw = cTempSystem.dUPX_LimitCcw;
      cReplace.dUPY_LimitCcw = cTempSystem.dUPY_LimitCcw;
      cReplace.dUE1_LimitCcw = cTempSystem.dUE1_LimitCcw;
      cReplace.dUE2_LimitCcw = cTempSystem.dUE2_LimitCcw;
      cReplace.dUE3_LimitCcw = cTempSystem.dUE3_LimitCcw;
      cReplace.dUE4_LimitCcw = cTempSystem.dUE4_LimitCcw;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_MotorLimit();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Limit_Air()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dMainAir_CylinderLimitMinus = cTempSystem.dMainAir_CylinderLimitMinus;
      cReplace.dMainAir_VaccumLimitMinus = cTempSystem.dMainAir_VaccumLimitMinus;
      cReplace.dLP_Vacuum_LimitMinus = cTempSystem.dLP_Vacuum_LimitMinus;
      cReplace.dUP_Vacuum_LimitMinus = cTempSystem.dUP_Vacuum_LimitMinus;
      cReplace.dStage1_Vacuum_LimitMinus = cTempSystem.dStage1_Vacuum_LimitMinus;
      cReplace.dStage2_Vacuum_LimitMinus = cTempSystem.dStage2_Vacuum_LimitMinus;

      cReplace.dLP_Vacuum_LimitPlus = cTempSystem.dLP_Vacuum_LimitPlus;
      cReplace.dUP_Vacuum_LimitPlus = cTempSystem.dUP_Vacuum_LimitPlus;
      cReplace.dStage1_Vacuum_LimitPlus = cTempSystem.dStage1_Vacuum_LimitPlus;
      cReplace.dStage2_Vacuum_LimitPlus = cTempSystem.dStage2_Vacuum_LimitPlus;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_AirLimit();
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_Time_ErrorDelay()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iErrorDelayTime_Cylinder = cTempSystem.iErrorDelayTime_Cylinder;
      cReplace.iErrorDelayTime_LPVacuum = cTempSystem.iErrorDelayTime_LPVacuum;
      cReplace.iErrorDelayTime_UPVacuum = cTempSystem.iErrorDelayTime_UPVacuum;
      cReplace.iErrorDelayTime_Stage1Vacuum = cTempSystem.iErrorDelayTime_Stage1Vacuum;
      cReplace.iErrorDelayTime_Stage2Vacuum = cTempSystem.iErrorDelayTime_Stage2Vacuum;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Error_Delay_Time();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Time_Delay()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iDelayTime_Cylinder = cTempSystem.iDelayTime_Cylinder;
      cReplace.iDelayTime_LPVacuum = cTempSystem.iDelayTime_LPVacuum;
      cReplace.iDelayTime_UPVacuum = cTempSystem.iDelayTime_UPVacuum;
      cReplace.iDelayTime_Stage1Vacuum = cTempSystem.iDelayTime_Stage1Vacuum;
      cReplace.iDelayTime_Stage2Vacuum = cTempSystem.iDelayTime_Stage2Vacuum;
      cReplace.iDelayTime_Measure = cTempSystem.iDelayTime_Measure;
      cReplace.iDelayTime_Align = cTempSystem.iDelayTime_Align;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Delay_Time();
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool Save_Time_RunTime()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iRunTime_AirBlow = cTempSystem.iRunTime_AirBlow;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Run_Time();
        return true;
      }
      else
      {
        return false;
      }
    }


    private void FormPageSetup_Shown(object sender, EventArgs e)
    {
      GetParam();
      Display_Refresh();
    }

    private void FormPageSetup_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        GetParam();
        Display_Refresh();
      }
    }

    private void tabSetup_SelectedIndexChanged(object sender, EventArgs e)
    {
      GetParam();
      Display_Refresh();
    }

    private void txt_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "Number");

      if (strData.Trim().CompareTo("") == 0)
      {
        // 값없음
        return;
      }
      double dTemp;
      if (double.TryParse(strData, out dTemp) == false)
      {
        // 숫자아님
        return;
      }

      switch (ctrl.Name)
      {
        case "txtReadyPos_LE": if (CVo.Allow_Limit(enumMotorName.LE, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLE_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_BCX": if (CVo.Allow_Limit(enumMotorName.BCX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dBCX_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_BCY": if (CVo.Allow_Limit(enumMotorName.BCY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dBCY_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_ALX": if (CVo.Allow_Limit(enumMotorName.ALX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALX_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_ALY": if (CVo.Allow_Limit(enumMotorName.ALY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALY_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_Z1": if (CVo.Allow_Limit(enumMotorName.Z1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ1_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_Z2": if (CVo.Allow_Limit(enumMotorName.Z2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ2_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_PR1": if (CVo.Allow_Limit(enumMotorName.PR1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR1_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_PR2": if (CVo.Allow_Limit(enumMotorName.PR2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR2_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_PR3": if (CVo.Allow_Limit(enumMotorName.PR3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR3_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_PR4": if (CVo.Allow_Limit(enumMotorName.PR4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR4_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UE1": if (CVo.Allow_Limit(enumMotorName.UE1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE1_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UE2": if (CVo.Allow_Limit(enumMotorName.UE2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE2_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UE3": if (CVo.Allow_Limit(enumMotorName.UE3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE3_Ready_Pos = Convert.ToDouble(strData); break;
        case "txtReadyPos_UE4": if (CVo.Allow_Limit(enumMotorName.UE4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE4_Ready_Pos = Convert.ToDouble(strData); break;

        case "txtNormalSpd_LE": cTempSystem.dLE_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_LP": cTempSystem.dLP_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_BCX": cTempSystem.dBCX_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_BCY": cTempSystem.dBCY_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_ALX": cTempSystem.dALX_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_ALY": cTempSystem.dALY_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_X1": cTempSystem.dX1_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_X2": cTempSystem.dX2_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_Z1": cTempSystem.dZ1_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_Z2": cTempSystem.dZ2_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_PR1": cTempSystem.dPR1_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_PR2": cTempSystem.dPR2_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_PR3": cTempSystem.dPR3_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_PR4": cTempSystem.dPR4_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UPX": cTempSystem.dUPX_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UPY": cTempSystem.dUPY_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UE1": cTempSystem.dUE1_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UE2": cTempSystem.dUE2_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UE3": cTempSystem.dUE3_Normal_Spd = Convert.ToDouble(strData); break;
        case "txtNormalSpd_UE4": cTempSystem.dUE4_Normal_Spd = Convert.ToDouble(strData); break;

        case "txtLowSpd_LE": cTempSystem.dLE_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_LP": cTempSystem.dLP_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_BCX": cTempSystem.dBCX_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_BCY": cTempSystem.dBCY_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_ALX": cTempSystem.dALX_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_ALY": cTempSystem.dALY_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_X1": cTempSystem.dX1_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_X2": cTempSystem.dX2_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_Z1": cTempSystem.dZ1_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_Z2": cTempSystem.dZ2_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_PR1": cTempSystem.dPR1_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_PR2": cTempSystem.dPR2_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_PR3": cTempSystem.dPR3_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_PR4": cTempSystem.dPR4_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UPX": cTempSystem.dUPX_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UPY": cTempSystem.dUPY_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UE1": cTempSystem.dUE1_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UE2": cTempSystem.dUE2_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UE3": cTempSystem.dUE3_Low_Spd = Convert.ToDouble(strData); break;
        case "txtLowSpd_UE4": cTempSystem.dUE4_Low_Spd = Convert.ToDouble(strData); break;

        case "txtScanStartPos_LE": if (CVo.Allow_Limit(enumMotorName.LE, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLE_ScanStart_Pos = Convert.ToDouble(strData); break;
        case "txtScanStartPos_UE1": if (CVo.Allow_Limit(enumMotorName.UE1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE1_ScanStart_Pos = Convert.ToDouble(strData); break;
        case "txtScanStartPos_UE2": if (CVo.Allow_Limit(enumMotorName.UE2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE2_ScanStart_Pos = Convert.ToDouble(strData); break;
        case "txtScanStartPos_UE3": if (CVo.Allow_Limit(enumMotorName.UE3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE3_ScanStart_Pos = Convert.ToDouble(strData); break;
        case "txtScanStartPos_UE4": if (CVo.Allow_Limit(enumMotorName.UE4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE4_ScanStart_Pos = Convert.ToDouble(strData); break;

        case "txtScanEndPos_LE": if (CVo.Allow_Limit(enumMotorName.LE, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLE_ScanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtScanEndPos_UE1": if (CVo.Allow_Limit(enumMotorName.UE1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE1_ScanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtScanEndPos_UE2": if (CVo.Allow_Limit(enumMotorName.UE2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE2_ScanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtScanEndPos_UE3": if (CVo.Allow_Limit(enumMotorName.UE3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE3_ScanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtScanEndPos_UE4": if (CVo.Allow_Limit(enumMotorName.UE4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE4_ScanEnd_Pos = Convert.ToDouble(strData); break;

        case "txtCassetteWaitPos_LE": if (CVo.Allow_Limit(enumMotorName.LE, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLE_Cassette_Wait_Pos = Convert.ToDouble(strData); break;
        case "txtCassetteWaitPos_UE1": if (CVo.Allow_Limit(enumMotorName.UE1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE1_Cassette_Wait_Pos = Convert.ToDouble(strData); break;
        case "txtCassetteWaitPos_UE2": if (CVo.Allow_Limit(enumMotorName.UE2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE2_Cassette_Wait_Pos = Convert.ToDouble(strData); break;
        case "txtCassetteWaitPos_UE3": if (CVo.Allow_Limit(enumMotorName.UE3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE3_Cassette_Wait_Pos = Convert.ToDouble(strData); break;
        case "txtCassetteWaitPos_UE4": if (CVo.Allow_Limit(enumMotorName.UE4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUE4_Cassette_Wait_Pos = Convert.ToDouble(strData); break;

        case "txtDownOffset_LE": cTempSystem.dLE_DownOffset_Pos = Convert.ToDouble(strData); break;

        case "txtCenter_PR1": if (CVo.Allow_Limit(enumMotorName.PR1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR1_Center_Pos = Convert.ToDouble(strData); break;
        case "txtCenter_PR2": if (CVo.Allow_Limit(enumMotorName.PR2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR2_Center_Pos = Convert.ToDouble(strData); break;
        case "txtCenter_PR3": if (CVo.Allow_Limit(enumMotorName.PR3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR3_Center_Pos = Convert.ToDouble(strData); break;
        case "txtCenter_PR4": if (CVo.Allow_Limit(enumMotorName.PR4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR4_Center_Pos = Convert.ToDouble(strData); break;
        case "txtClean_PR1": if (CVo.Allow_Limit(enumMotorName.PR1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR1_Clean_Pos = Convert.ToDouble(strData); break;
        case "txtClean_PR2": if (CVo.Allow_Limit(enumMotorName.PR2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR2_Clean_Pos = Convert.ToDouble(strData); break;
        case "txtClean_PR3": if (CVo.Allow_Limit(enumMotorName.PR3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR3_Clean_Pos = Convert.ToDouble(strData); break;
        case "txtClean_PR4": if (CVo.Allow_Limit(enumMotorName.PR4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR4_Clean_Pos = Convert.ToDouble(strData); break;
        case "txtChange_PR1": if (CVo.Allow_Limit(enumMotorName.PR1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR1_Change_Pos = Convert.ToDouble(strData); break;
        case "txtChange_PR2": if (CVo.Allow_Limit(enumMotorName.PR2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR2_Change_Pos = Convert.ToDouble(strData); break;
        case "txtChange_PR3": if (CVo.Allow_Limit(enumMotorName.PR3, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR3_Change_Pos = Convert.ToDouble(strData); break;
        case "txtChange_PR4": if (CVo.Allow_Limit(enumMotorName.PR4, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dPR4_Change_Pos = Convert.ToDouble(strData); break;



        case "txtLoadingPos_ALX": if (CVo.Allow_Limit(enumMotorName.ALX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALX_Loading_Pos = Convert.ToDouble(strData); break;
        case "txtLoadingPos_ALY": if (CVo.Allow_Limit(enumMotorName.ALY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALY_Loading_Pos = Convert.ToDouble(strData); break;

        case "txtUnloadingPos_ALX": if (CVo.Allow_Limit(enumMotorName.ALX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALX_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtUnloadingPos_ALY": if (CVo.Allow_Limit(enumMotorName.ALY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALY_Unloading_Pos = Convert.ToDouble(strData); break;

        case "txtAlignBackOffset_ALX": if (CVo.Allow_Limit(enumMotorName.ALX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALX_AlignBackOffset_Pos = Convert.ToDouble(strData); break;
        case "txtAlignBackOffset_ALY": if (CVo.Allow_Limit(enumMotorName.ALY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALY_AlignBackOffset_Pos = Convert.ToDouble(strData); break;

        case "txtAlignStartPos_ALX": if (CVo.Allow_Limit(enumMotorName.ALX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALX_AlignStart_Pos = Convert.ToDouble(strData); break;
        case "txtAlignStartPos_ALY": if (CVo.Allow_Limit(enumMotorName.ALY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dALY_AlignStart_Pos = Convert.ToDouble(strData); break;

        case "txtLEPos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_LE_Pos = Convert.ToDouble(strData); break;
        case "txtAlignPos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_AL_Pos = Convert.ToDouble(strData); break;
        case "txtAlignUnloadingPos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_AL_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtX1Pos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_Stage1_Pos = Convert.ToDouble(strData); break;
        case "txtX2Pos_LP": if (CVo.Allow_Limit(enumMotorName.LP, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dLP_Stage2_Pos = Convert.ToDouble(strData); break;

        case "txtUnloaderUE1_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_UE1_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE2_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_UE2_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE3_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_UE3_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE4_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_UE4_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderX1_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_Stage1_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderX2_UPX": if (CVo.Allow_Limit(enumMotorName.UPX, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPX_Stage2_Pos = Convert.ToDouble(strData); break;

        case "txtUnloaderUE1_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_UE1_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE2_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_UE2_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE3_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_UE3_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderUE4_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_UE4_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderX1_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_Stage1_Pos = Convert.ToDouble(strData); break;
        case "txtUnloaderX2_UPY": if (CVo.Allow_Limit(enumMotorName.UPY, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dUPY_Stage2_Pos = Convert.ToDouble(strData); break;

        case "txtStageLoading_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Loading_Pos = Convert.ToDouble(strData); break;
        case "txtStageUnloading_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtStageCenter_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Center_Pos = Convert.ToDouble(strData); break;
        case "txtStageCleanStart_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_CleanStart_Pos = Convert.ToDouble(strData); break;
        case "txtStageCleanEnd_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_CleanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtStageProbeClean_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_CleanProbe_Pos = Convert.ToDouble(strData); break;
        case "txtStageInterlockMinus_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Interlock_Minus = Convert.ToDouble(strData); break;
        case "txtStageInterlockPlus_X1": if (CVo.Allow_Limit(enumMotorName.X1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX1_Interlock_Plus = Convert.ToDouble(strData); break;

        case "txtStageLoading_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Loading_Pos = Convert.ToDouble(strData); break;
        case "txtStageUnloading_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtStageCenter_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Center_Pos = Convert.ToDouble(strData); break;
        case "txtStageCleanStart_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_CleanStart_Pos = Convert.ToDouble(strData); break;
        case "txtStageCleanEnd_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_CleanEnd_Pos = Convert.ToDouble(strData); break;
        case "txtStageProbeClean_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_CleanProbe_Pos = Convert.ToDouble(strData); break;
        case "txtStageInterlockMinus_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Interlock_Minus = Convert.ToDouble(strData); break;
        case "txtStageInterlockPlus_X2": if (CVo.Allow_Limit(enumMotorName.X2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dX2_Interlock_Plus = Convert.ToDouble(strData); break;

        case "txtZLoading_Z1": if (CVo.Allow_Limit(enumMotorName.Z1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ1_Loading_Pos = Convert.ToDouble(strData); break;
        case "txtZUnloading_Z1": if (CVo.Allow_Limit(enumMotorName.Z1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ1_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtZCenter_Z1": if (CVo.Allow_Limit(enumMotorName.Z1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ1_Center_Pos = Convert.ToDouble(strData); break;

        case "txtZLoading_Z2": if (CVo.Allow_Limit(enumMotorName.Z2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ2_Loading_Pos = Convert.ToDouble(strData); break;
        case "txtZUnloading_Z2": if (CVo.Allow_Limit(enumMotorName.Z2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ2_Unloading_Pos = Convert.ToDouble(strData); break;
        case "txtZCenter_Z2": if (CVo.Allow_Limit(enumMotorName.Z2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ2_Center_Pos = Convert.ToDouble(strData); break;

        case "txtCwLimit_LE": cTempSystem.dLE_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_LP": cTempSystem.dLP_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_BCX": cTempSystem.dBCX_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_BCY": cTempSystem.dBCY_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_ALX": cTempSystem.dALX_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_ALY": cTempSystem.dALY_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_X1": cTempSystem.dX1_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_X2": cTempSystem.dX2_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_Z1": cTempSystem.dZ1_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_Z2": cTempSystem.dZ2_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_PR1": cTempSystem.dPR1_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_PR2": cTempSystem.dPR2_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_PR3": cTempSystem.dPR3_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_PR4": cTempSystem.dPR4_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UPX": cTempSystem.dUPX_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UPY": cTempSystem.dUPY_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UE1": cTempSystem.dUE1_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UE2": cTempSystem.dUE2_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UE3": cTempSystem.dUE3_LimitCw = Convert.ToDouble(strData); break;
        case "txtCwLimit_UE4": cTempSystem.dUE4_LimitCw = Convert.ToDouble(strData); break;

        case "txtCcwLimit_LE": cTempSystem.dLE_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_LP": cTempSystem.dLP_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_BCX": cTempSystem.dBCX_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_BCY": cTempSystem.dBCY_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_ALX": cTempSystem.dALX_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_ALY": cTempSystem.dALY_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_X1": cTempSystem.dX1_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_X2": cTempSystem.dX2_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_Z1": cTempSystem.dZ1_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_Z2": cTempSystem.dZ2_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_PR1": cTempSystem.dPR1_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_PR2": cTempSystem.dPR2_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_PR3": cTempSystem.dPR3_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_PR4": cTempSystem.dPR4_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UPX": cTempSystem.dUPX_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UPY": cTempSystem.dUPY_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UE1": cTempSystem.dUE1_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UE2": cTempSystem.dUE2_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UE3": cTempSystem.dUE3_LimitCcw = Convert.ToDouble(strData); break;
        case "txtCcwLimit_UE4": cTempSystem.dUE4_LimitCcw = Convert.ToDouble(strData); break;

        case "txtLimitMinus_MainAir": cTempSystem.dMainAir_CylinderLimitMinus = Convert.ToDouble(strData); break;
        case "txtLimitMinus_MainAir_Vaccum": cTempSystem.dMainAir_VaccumLimitMinus = Convert.ToDouble(strData); break;
        case "txtLimitMinus_LPVacuum": cTempSystem.dLP_Vacuum_LimitMinus = Convert.ToDouble(strData); break;
        case "txtLimitMinus_UPVacuum": cTempSystem.dUP_Vacuum_LimitMinus = Convert.ToDouble(strData); break;
        case "txtLimitMinus_Stage1Vacuum": cTempSystem.dStage1_Vacuum_LimitMinus = Convert.ToDouble(strData); break;
        case "txtLimitMinus_Stage2Vacuum": cTempSystem.dStage2_Vacuum_LimitMinus = Convert.ToDouble(strData); break;

        case "txtLimitPlus_LPVacuum": cTempSystem.dLP_Vacuum_LimitPlus = Convert.ToDouble(strData); break;
        case "txtLimitPlus_UPVacuum": cTempSystem.dUP_Vacuum_LimitPlus = Convert.ToDouble(strData); break;
        case "txtLimitPlus_Stage1Vacuum": cTempSystem.dStage1_Vacuum_LimitPlus = Convert.ToDouble(strData); break;
        case "txtLimitPlus_Stage2Vacuum": cTempSystem.dStage2_Vacuum_LimitPlus = Convert.ToDouble(strData); break;

        case "txtOffset_Probe1": cTempSystem.dProbeOffset_1 = Convert.ToDouble(strData); break;
        case "txtOffset_Probe2": cTempSystem.dProbeOffset_2 = Convert.ToDouble(strData); break;
        case "txtOffset_Probe3": cTempSystem.dProbeOffset_3 = Convert.ToDouble(strData); break;
        case "txtOffset_Probe4": cTempSystem.dProbeOffset_4 = Convert.ToDouble(strData); break;

        case "txtSafetyLimitPos_Z1": if (CVo.Allow_Limit(enumMotorName.Z1, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ1_Safety_Limit = Convert.ToDouble(strData); break;
        case "txtSafetyLimitPos_Z2": if (CVo.Allow_Limit(enumMotorName.Z2, Convert.ToDouble(strData)) == false) { break; } cTempSystem.dZ2_Safety_Limit = Convert.ToDouble(strData); break;

        case "txtSafetyLimitPos_Probe_Stage1": cTempSystem.dProbe_Stage1_Safety_Gap = Convert.ToDouble(strData); break;
        case "txtSafetyLimitPos_Probe_Stage2": cTempSystem.dProbe_Stage2_Safety_Gap = Convert.ToDouble(strData); break;
        
        default:
          break;
      }

      Display_Refresh();
    }

    private void txt_IntMouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "Number");

      if (strData.Trim().CompareTo("") == 0)
      {
        //  값없음
        return;
      }
      int iTemp;
      if (int.TryParse(strData, out iTemp) == false)
      {
        // 숫자아님
        return;
      }

      switch (ctrl.Name)
      {
        case "txtData_LoadingShakeCount": cTempSystem.iShakeCount = Convert.ToInt32(strData); break;
        case "txtErrorDelay_Cylinder": cTempSystem.iErrorDelayTime_Cylinder = Convert.ToInt32(strData); break;
        case "txtErrorDelay_LPVacuum": cTempSystem.iErrorDelayTime_LPVacuum = Convert.ToInt32(strData); break;
        case "txtErrorDelay_UPVacuum": cTempSystem.iErrorDelayTime_UPVacuum = Convert.ToInt32(strData); break;
        case "txtErrorDelay_Stage1Vacuum": cTempSystem.iErrorDelayTime_Stage1Vacuum = Convert.ToInt32(strData); break;
        case "txtErrorDelay_Stage2Vacuum": cTempSystem.iErrorDelayTime_Stage2Vacuum = Convert.ToInt32(strData); break;

        case "txtDelayTime_Cylinder": cTempSystem.iDelayTime_Cylinder = Convert.ToInt32(strData); break;
        case "txtDelayTime_LPVacuum": cTempSystem.iDelayTime_LPVacuum = Convert.ToInt32(strData); break;
        case "txtDelayTime_UPVacuum": cTempSystem.iDelayTime_UPVacuum = Convert.ToInt32(strData); break;
        case "txtDelayTime_Stage1Vacuum": cTempSystem.iDelayTime_Stage1Vacuum = Convert.ToInt32(strData); break;
        case "txtDelayTime_Stage2Vacuum": cTempSystem.iDelayTime_Stage2Vacuum = Convert.ToInt32(strData); break;
        case "txtDelayTime_Measure": cTempSystem.iDelayTime_Measure = Convert.ToInt32(strData); break;
        case "txtDelayTime_Align": cTempSystem.iDelayTime_Align = Convert.ToInt32(strData); break;
        case "txtData_LogDeletePeriod" : cTempSystem.iDeleteLogPeriod = Convert.ToInt32(strData); break;

        case "txtRunTime_AirBlow": cTempSystem.iRunTime_AirBlow = Convert.ToInt32(strData); break;
        case "txtData_ZeroSetPeriod": cTempSystem.iZerosetPeriod = Convert.ToInt32(strData); break;
        case "txtData_StageCleanCount": cTempSystem.iStageCleanCount = Convert.ToInt32(strData); break;
        case "txtData_ProbeCleanCount": cTempSystem.iProbeCleanCount = Convert.ToInt32(strData); break;
        case "txtData_ReMeasureCount": cTempSystem.iReMeasureCount = Convert.ToInt32(strData); break;

        case "txtValueAverage_Count": cTempSystem.iProbeValueAverageCount = Convert.ToInt32(strData); break;
        case "txtValueAverage_MinCount": cTempSystem.iProbeValueAverageMin = Convert.ToInt32(strData); break;
        case "txtValueAverage_MaxCount": cTempSystem.iProbeValueAverageMax = Convert.ToInt32(strData); break;

        case "txtData_PreStageCleanCount": cTempSystem.iPreStageCleanCount = Convert.ToInt32(strData); break;
        case "txtData_AfterStageCleanCount": cTempSystem.iAfterStageCleanCount = Convert.ToInt32(strData); break;

        case "txtDataLampBlinkTime":
          switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
          {
            case enumMachineStatus.None: cTempSystem.iLampNone_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Initial: cTempSystem.iLampInitail_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Idle: cTempSystem.iLampIdle_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Auto: cTempSystem.iLampAuto_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Stop: cTempSystem.iLampStop_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.ErrorAuto: cTempSystem.iLampErrorAuto_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Error: cTempSystem.iLampErrorCycle_BlinkTime = Convert.ToInt32(strData); break;
            case enumMachineStatus.Cycle: cTempSystem.iLampCycle_BlinkTime = Convert.ToInt32(strData); break;
            default: break;
          }
          break;
        case "txtDataLampBuzzTime":
          switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
          {
            case enumMachineStatus.None: cTempSystem.iBuzzNone_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Initial: cTempSystem.iBuzzInitail_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Idle: cTempSystem.iBuzzIdle_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Auto: cTempSystem.iBuzzAuto_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Stop: cTempSystem.iBuzzStop_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.ErrorAuto: cTempSystem.iBuzzErrorAuto_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Error: cTempSystem.iBuzzErrorCycle_Time = Convert.ToInt32(strData); break;
            case enumMachineStatus.Cycle: cTempSystem.iBuzzCycle_Time = Convert.ToInt32(strData); break;
            default: break;
          }
          break;
        default: break;
      }

      Display_Refresh();
    }

    private void chkUseProbe_CheckedChanged(object sender, EventArgs e)
    {
      //cTempSystem.bUsePB1 = chkUse_PB1.Checked;
      //cTempSystem.bUsePB2 = chkUse_PB2.Checked;
      //cTempSystem.bUsePB3 = chkUse_PB3.Checked;
      //cTempSystem.bUsePB4 = chkUse_PB4.Checked;

      //cTempSystem.bUseBarcode_1D = chkUse_BCR_1D.Checked;
      //cTempSystem.bUseBarcode_2D = chkUse_BCR.Checked;
      //cTempSystem.bUseLoadingShake = chkUse_LoadingShake.Checked;

      //Display_Refresh();
    }

    private void btn_Standard_Save_Elevator_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Elevator())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdElevatorSaveFail);
      }
    }

    private void btn_Standard_Save_Z_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Z())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdZSaveFail);
      }
    }

    private void btn_Standard_Save_Unloader_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Unloader())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdUnloaderSaveFail);
      }
    }

    private void btn_Standard_Save_Stage_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Stage())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdStageSaveFail);
      }
    }

    private void btn_Standard_Save_Loader_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Loader())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdLoaderSaveFail);
      }
    }

    private void btn_Standard_Save_Probe_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Probe())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdProbeSaveFail);
      }
    }

    private void btn_Standard_Save_Align_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Align())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAlignSaveFail);
      }
    }

    private void btn_Standard_Save_All_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Std_Elevator() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Z() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Unloader() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Stage() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Loader() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Probe() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      if (Save_Std_Align() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemStdAllSaveFail);
        return;
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_ReadyPos_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();

      if (Save_ReadyPos())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemReadyPosSaveFail);
      }
    }

    private void btn_NormalSpd_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();

      if (Save_NormalSpd())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemNormalSpdSaveFail);
      }
    }

    private void btn_LowSpd_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_LowSpd())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemLowSpdSaveFail);
      }
    }

    private void btn_Axis_All_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_ReadyPos() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemAxisAllSaveFail);
        return;
      }
      if (Save_NormalSpd() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemAxisAllSaveFail);
        return;
      }
      if (Save_LowSpd() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemAxisAllSaveFail);
        return;
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }



    private void btn_MotorLimit_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Limit_Motor())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemLimitMotorSaveFail);
      }
    }

    private void btn_AirLimit_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Limit_Air())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemLimitAirSaveFail);
      }
    }

    private void btn_Limit_All_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Limit_Motor() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemLimitAllSaveFail);
        return;
      }
      if (Save_Limit_Air() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemLimitAllSaveFail);
        return;
      }
      if (Save_Safety_Probe_Pos() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemSafetyProbePosSaveFail);
        return;
      }
      if (Save_Safety_Z_Pos() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemSafetyZPosSaveFail);
        return;
      }

      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void cboLEAirBlowMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTempSystem.iLEAirBlowMode = cboLEAirBlowMode.SelectedIndex;
    }

    private void btn_ErrorDelay_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Time_ErrorDelay())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeErrorDelaySaveFail);
      }
    }

    private void btn_DelayTime_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Time_Delay())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeDelaySaveFail);
      }
    }

    private void btn_RunTime_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Time_RunTime())
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeRunTimeSaveFail);
      }
    }

    private void btn_Time_All_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Time_ErrorDelay() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeAllSaveFail);
        return;
      }
      if (Save_Time_Delay() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeAllSaveFail);
        return;
      }
      if (Save_Time_RunTime() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemTimeAllSaveFail);
        return;
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void cboData_LampStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
      {
        case enumMachineStatus.None:
          txtDataLampBlinkTime.Text = cTempSystem.iLampNone_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampNone_R, cTempSystem.iLampNone_Y, cTempSystem.iLampNone_G);
          SetBuzz(cTempSystem.iBuzzNone_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzNone_Time.ToString();
          break;
        case enumMachineStatus.Initial:
          txtDataLampBlinkTime.Text = cTempSystem.iLampInitail_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampInitail_R, cTempSystem.iLampInitail_Y, cTempSystem.iLampInitail_G);
          SetBuzz(cTempSystem.iBuzzInitail_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzInitail_Time.ToString();
          break;
        case enumMachineStatus.Idle:
          txtDataLampBlinkTime.Text = cTempSystem.iLampIdle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampIdle_R, cTempSystem.iLampIdle_Y, cTempSystem.iLampIdle_G);
          SetBuzz(cTempSystem.iBuzzIdle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzIdle_Time.ToString();
          break;
        case enumMachineStatus.Auto:
          txtDataLampBlinkTime.Text = cTempSystem.iLampAuto_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampAuto_R, cTempSystem.iLampAuto_Y, cTempSystem.iLampAuto_G);
          SetBuzz(cTempSystem.iBuzzAuto_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzAuto_Time.ToString();
          break;
        case enumMachineStatus.Stop:
          txtDataLampBlinkTime.Text = cTempSystem.iLampStop_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampStop_R, cTempSystem.iLampStop_Y, cTempSystem.iLampStop_G);
          SetBuzz(cTempSystem.iBuzzStop_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzStop_Time.ToString();
          break;
        case enumMachineStatus.ErrorAuto:
          txtDataLampBlinkTime.Text = cTempSystem.iLampErrorAuto_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampErrorAuto_R, cTempSystem.iLampErrorAuto_Y, cTempSystem.iLampErrorAuto_G);
          SetBuzz(cTempSystem.iBuzzErrorAuto_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzErrorAuto_Time.ToString();
          break;
        case enumMachineStatus.Error:
          txtDataLampBlinkTime.Text = cTempSystem.iLampErrorCycle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampErrorCycle_R, cTempSystem.iLampErrorCycle_Y, cTempSystem.iLampErrorCycle_G);
          SetBuzz(cTempSystem.iBuzzErrorCycle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzErrorCycle_Time.ToString();
          break;
        case enumMachineStatus.Cycle:
          txtDataLampBlinkTime.Text = cTempSystem.iLampCycle_BlinkTime.ToString();
          SetLamp(cTempSystem.iLampCycle_R, cTempSystem.iLampCycle_Y, cTempSystem.iLampCycle_G);
          SetBuzz(cTempSystem.iBuzzCycle_Mode);
          txtDataLampBuzzTime.Text = cTempSystem.iBuzzCycle_Time.ToString();
          break;
        default:
          break;
      }
    }
    private void rdoBuzz_CheckedChanged(object sender, EventArgs e)
    {
      switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
      {
        case enumMachineStatus.None:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzNone_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzNone_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzNone_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Initial:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzInitail_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzInitail_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzInitail_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Idle:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzIdle_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzIdle_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzIdle_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Auto:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzAuto_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzAuto_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzAuto_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Stop:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzStop_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzStop_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzStop_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.ErrorAuto:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzErrorAuto_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzErrorAuto_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzErrorAuto_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Error:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzErrorCycle_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzErrorCycle_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzErrorCycle_Mode = (int)enumBuzzer.Off;
          }
          break;
        case enumMachineStatus.Cycle:
          if (rdoBuzz_End.Checked)
          {
            cTempSystem.iBuzzCycle_Mode = (int)enumBuzzer.End;
          }
          if (rdoBuzz_Error.Checked)
          {
            cTempSystem.iBuzzCycle_Mode = (int)enumBuzzer.Error;
          }
          if (rdoBuzz_Off.Checked)
          {
            cTempSystem.iBuzzCycle_Mode = (int)enumBuzzer.Off;
          }
          break;
        default:
          break;
      }
    }

    private void rdoLamp_CheckedChanged(object sender, EventArgs e)
    {
      switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
      {
        case enumMachineStatus.None:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampNone_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampNone_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampNone_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampNone_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampNone_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampNone_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampNone_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampNone_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampNone_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Initial:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampInitail_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampInitail_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampInitail_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampInitail_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampInitail_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampInitail_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampInitail_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampInitail_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampInitail_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Idle:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampIdle_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampIdle_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampIdle_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampIdle_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampIdle_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampIdle_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampIdle_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampIdle_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampIdle_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Auto:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampAuto_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampAuto_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampAuto_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampAuto_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampAuto_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampAuto_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampAuto_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampAuto_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampAuto_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Stop:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampStop_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampStop_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampStop_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampStop_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampStop_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampStop_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampStop_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampStop_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampStop_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.ErrorAuto:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampErrorAuto_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampErrorAuto_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampErrorAuto_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampErrorAuto_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampErrorAuto_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampErrorAuto_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampErrorAuto_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampErrorAuto_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampErrorAuto_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Error:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampErrorCycle_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampErrorCycle_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampErrorCycle_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampErrorCycle_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampErrorCycle_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampErrorCycle_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampErrorCycle_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampErrorCycle_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampErrorCycle_G = (int)enumTowerLamp.Off;
          }
          break;
        case enumMachineStatus.Cycle:
          if (rdoR_On.Checked)
          {
            cTempSystem.iLampCycle_R = (int)enumTowerLamp.On;
          }
          if (rdoR_Blink.Checked)
          {
            cTempSystem.iLampCycle_R = (int)enumTowerLamp.Blink;
          }
          if (rdoR_Off.Checked)
          {
            cTempSystem.iLampCycle_R = (int)enumTowerLamp.Off;
          }

          if (rdoY_On.Checked)
          {
            cTempSystem.iLampCycle_Y = (int)enumTowerLamp.On;
          }
          if (rdoY_Blink.Checked)
          {
            cTempSystem.iLampCycle_Y = (int)enumTowerLamp.Blink;
          }
          if (rdoY_Off.Checked)
          {
            cTempSystem.iLampCycle_Y = (int)enumTowerLamp.Off;
          }

          if (rdoG_On.Checked)
          {
            cTempSystem.iLampCycle_G = (int)enumTowerLamp.On;
          }
          if (rdoG_Blink.Checked)
          {
            cTempSystem.iLampCycle_G = (int)enumTowerLamp.Blink;
          }
          if (rdoG_Off.Checked)
          {
            cTempSystem.iLampCycle_G = (int)enumTowerLamp.Off;
          }
          break;
        default:
          break;
      }
    }

    private bool Save_Data()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iShakeCount = cTempSystem.iShakeCount;
      cReplace.iLEAirBlowMode = cTempSystem.iLEAirBlowMode;
      cReplace.iZerosetPeriod = cTempSystem.iZerosetPeriod;
      cReplace.iStageCleanCount = cTempSystem.iStageCleanCount;
      cReplace.iProbeCleanCount = cTempSystem.iProbeCleanCount;
      cReplace.iReMeasureCount = cTempSystem.iReMeasureCount;
      cReplace.iLanguage = cTempSystem.iLanguage;
      cReplace.iDeleteLogPeriod = cTempSystem.iDeleteLogPeriod;
      cReplace.iPreStageCleanCount = cTempSystem.iPreStageCleanCount;
      cReplace.iAfterStageCleanCount = cTempSystem.iAfterStageCleanCount;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        if (CVo.cParaSys.GetValues().iLanguage != cOld.GetValues().iLanguage)
        {
          CForm.Change_Language((enumLanguageType)CVo.cParaSys.iLanguage);
          CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.LanguageChanged);
        }
        CIoVo.Send_Mode();
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_UseProbe()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.bUsePB1 = cTempSystem.bUsePB1;
      cReplace.bUsePB2 = cTempSystem.bUsePB2;
      cReplace.bUsePB3 = cTempSystem.bUsePB3;
      cReplace.bUsePB4 = cTempSystem.bUsePB4;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_Lamp()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iLampNone_R = cTempSystem.iLampNone_R;
      cReplace.iLampNone_Y = cTempSystem.iLampNone_Y;
      cReplace.iLampNone_G = cTempSystem.iLampNone_G;
      cReplace.iLampNone_BlinkTime = cTempSystem.iLampNone_BlinkTime;
      cReplace.iBuzzNone_Mode = cTempSystem.iBuzzNone_Mode;
      cReplace.iBuzzNone_Time = cTempSystem.iBuzzNone_Time;

      cReplace.iLampInitail_R = cTempSystem.iLampInitail_R;
      cReplace.iLampInitail_Y = cTempSystem.iLampInitail_Y;
      cReplace.iLampInitail_G = cTempSystem.iLampInitail_G;
      cReplace.iLampInitail_BlinkTime = cTempSystem.iLampInitail_BlinkTime;
      cReplace.iBuzzInitail_Mode = cTempSystem.iBuzzInitail_Mode;
      cReplace.iBuzzInitail_Time = cTempSystem.iBuzzInitail_Time;

      cReplace.iLampIdle_R = cTempSystem.iLampIdle_R;
      cReplace.iLampIdle_Y = cTempSystem.iLampIdle_Y;
      cReplace.iLampIdle_G = cTempSystem.iLampIdle_G;
      cReplace.iLampIdle_BlinkTime = cTempSystem.iLampIdle_BlinkTime;
      cReplace.iBuzzIdle_Mode = cTempSystem.iBuzzIdle_Mode;
      cReplace.iBuzzIdle_Time = cTempSystem.iBuzzIdle_Time;

      cReplace.iLampAuto_R = cTempSystem.iLampAuto_R;
      cReplace.iLampAuto_Y = cTempSystem.iLampAuto_Y;
      cReplace.iLampAuto_G = cTempSystem.iLampAuto_G;
      cReplace.iLampAuto_BlinkTime = cTempSystem.iLampAuto_BlinkTime;
      cReplace.iBuzzAuto_Mode = cTempSystem.iBuzzAuto_Mode;
      cReplace.iBuzzAuto_Time = cTempSystem.iBuzzAuto_Time;

      cReplace.iLampStop_R = cTempSystem.iLampStop_R;
      cReplace.iLampStop_Y = cTempSystem.iLampStop_Y;
      cReplace.iLampStop_G = cTempSystem.iLampStop_G;
      cReplace.iLampStop_BlinkTime = cTempSystem.iLampStop_BlinkTime;
      cReplace.iBuzzStop_Mode = cTempSystem.iBuzzStop_Mode;
      cReplace.iBuzzStop_Time = cTempSystem.iBuzzStop_Time;

      cReplace.iLampErrorAuto_R = cTempSystem.iLampErrorAuto_R;
      cReplace.iLampErrorAuto_Y = cTempSystem.iLampErrorAuto_Y;
      cReplace.iLampErrorAuto_G = cTempSystem.iLampErrorAuto_G;
      cReplace.iLampErrorAuto_BlinkTime = cTempSystem.iLampErrorAuto_BlinkTime;
      cReplace.iBuzzErrorAuto_Mode = cTempSystem.iBuzzErrorAuto_Mode;
      cReplace.iBuzzErrorAuto_Time = cTempSystem.iBuzzErrorAuto_Time;

      cReplace.iLampErrorCycle_R = cTempSystem.iLampErrorCycle_R;
      cReplace.iLampErrorCycle_Y = cTempSystem.iLampErrorCycle_Y;
      cReplace.iLampErrorCycle_G = cTempSystem.iLampErrorCycle_G;
      cReplace.iLampErrorCycle_BlinkTime = cTempSystem.iLampErrorCycle_BlinkTime;
      cReplace.iBuzzErrorCycle_Mode = cTempSystem.iBuzzErrorCycle_Mode;
      cReplace.iBuzzErrorCycle_Time = cTempSystem.iBuzzErrorCycle_Time;

      cReplace.iLampCycle_R = cTempSystem.iLampCycle_R;
      cReplace.iLampCycle_Y = cTempSystem.iLampCycle_Y;
      cReplace.iLampCycle_G = cTempSystem.iLampCycle_G;
      cReplace.iLampCycle_BlinkTime = cTempSystem.iLampCycle_BlinkTime;
      cReplace.iBuzzCycle_Mode = cTempSystem.iBuzzCycle_Mode;
      cReplace.iBuzzCycle_Time = cTempSystem.iBuzzCycle_Time;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void btn_Data_Save_All_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Lamp() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataAllSaveFail);
        return;
      }
      if (Save_UseProbe() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataAllSaveFail);
        return;
      }
      if (Save_Data() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataAllSaveFail);
        return;
      }
      if (Save_UseSkip() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataAllSaveFail);
        return;
      }
      if (Save_ProbeOffset() ==false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataAllSaveFail);
        return;
      }
      if (Save_DisplayColor() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataDisplayColor);
        return;
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_Data_Data_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Data() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataDataSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_Data_Lamp_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Lamp() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataLampSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_Data_Probe_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_UseProbe() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataUseProbeSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void tmr_Setup_Tick(object sender, EventArgs e)
    {
      tmr_Setup.Enabled = false;
      Timer();
      tmr_Setup.Enabled = true;
    }

    private void Timer()
    {
      if (CMaster.cPlc.IsOpen())
      {
        btnOpen_PLC.Enabled = false;
        btnClose_PLC.Enabled = true;
      }
      else
      {
        btnOpen_PLC.Enabled = true;
        btnClose_PLC.Enabled = false;
      }

      if (CMaster.cBCR.Check_Open())
      {
        btnOpen_BCR.Enabled = false;
        btnClose_BCR.Enabled = true;
      }
      else
      {
        btnOpen_BCR.Enabled = true;
        btnClose_BCR.Enabled = false;
      }

      if (CMaster.cProbe1.Check_Open())
      {
        btnOpen1_Probe.Enabled = false;
        btnClose1_Probe.Enabled = true;

        txtProbeReadData1.Text = CMaster.cProbe1.GetData(1).ToString("0.000");
        txtProbeReadData2.Text = CMaster.cProbe1.GetData(2).ToString("0.000");
      }
      else
      {
        btnOpen1_Probe.Enabled = true;
        btnClose1_Probe.Enabled = false;
      }

      if (CMaster.cProbe2.Check_Open())
      {
        btnOpen2_Probe.Enabled = false;
        btnClose2_Probe.Enabled = true;

        txtProbeReadData3.Text = CMaster.cProbe2.GetData(1).ToString("0.000");
        txtProbeReadData4.Text = CMaster.cProbe2.GetData(2).ToString("0.000");
      }
      else
      {
        btnOpen2_Probe.Enabled = true;
        btnClose2_Probe.Enabled = false;
      }


      

      enumBuzzer eBuzz = enumBuzzer.Off;
      int iBuzzTime = 0;

      enumTowerLamp eR = enumTowerLamp.Off;
      enumTowerLamp eY = enumTowerLamp.Off;
      enumTowerLamp eG = enumTowerLamp.Off;
      int iBlankTime = 0;
      switch ((enumMachineStatus)cboData_LampStatus.SelectedIndex)
      {
        case enumMachineStatus.None:
          eR = (enumTowerLamp)cTempSystem.iLampNone_R;
          eY = (enumTowerLamp)cTempSystem.iLampNone_Y;
          eG = (enumTowerLamp)cTempSystem.iLampNone_G;
          iBlankTime = cTempSystem.iLampNone_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzNone_Mode;
          iBuzzTime = cTempSystem.iBuzzNone_Time;
          break;
        case enumMachineStatus.Initial:
          eR = (enumTowerLamp)cTempSystem.iLampInitail_R;
          eY = (enumTowerLamp)cTempSystem.iLampInitail_Y;
          eG = (enumTowerLamp)cTempSystem.iLampInitail_G;
          iBlankTime = cTempSystem.iLampInitail_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzInitail_Mode;
          iBuzzTime = cTempSystem.iBuzzInitail_Time;
          break;
        case enumMachineStatus.Idle:
          eR = (enumTowerLamp)cTempSystem.iLampIdle_R;
          eY = (enumTowerLamp)cTempSystem.iLampIdle_Y;
          eG = (enumTowerLamp)cTempSystem.iLampIdle_G;
          iBlankTime = cTempSystem.iLampIdle_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzIdle_Mode;
          iBuzzTime = cTempSystem.iBuzzIdle_Time;
          break;
        case enumMachineStatus.Auto:
          eR = (enumTowerLamp)cTempSystem.iLampAuto_R;
          eY = (enumTowerLamp)cTempSystem.iLampAuto_Y;
          eG = (enumTowerLamp)cTempSystem.iLampAuto_G;
          iBlankTime = cTempSystem.iLampAuto_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzAuto_Mode;
          iBuzzTime = cTempSystem.iBuzzAuto_Time;
          break;
        case enumMachineStatus.Stop:
          eR = (enumTowerLamp)cTempSystem.iLampStop_R;
          eY = (enumTowerLamp)cTempSystem.iLampStop_Y;
          eG = (enumTowerLamp)cTempSystem.iLampStop_G;
          iBlankTime = cTempSystem.iLampStop_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzStop_Mode;
          iBuzzTime = cTempSystem.iBuzzStop_Time;
          break;
        case enumMachineStatus.ErrorAuto:
          eR = (enumTowerLamp)cTempSystem.iLampErrorAuto_R;
          eY = (enumTowerLamp)cTempSystem.iLampErrorAuto_Y;
          eG = (enumTowerLamp)cTempSystem.iLampErrorAuto_G;
          iBlankTime = cTempSystem.iLampErrorAuto_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzErrorAuto_Mode;
          iBuzzTime = cTempSystem.iBuzzErrorAuto_Time;
          break;
        case enumMachineStatus.Error:
          eR = (enumTowerLamp)cTempSystem.iLampErrorCycle_R;
          eY = (enumTowerLamp)cTempSystem.iLampErrorCycle_Y;
          eG = (enumTowerLamp)cTempSystem.iLampErrorCycle_G;
          iBlankTime = cTempSystem.iLampErrorCycle_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzErrorCycle_Mode;
          iBuzzTime = cTempSystem.iBuzzErrorCycle_Time;
          break;
        case enumMachineStatus.Cycle:
          eR = (enumTowerLamp)cTempSystem.iLampCycle_R;
          eY = (enumTowerLamp)cTempSystem.iLampCycle_Y;
          eG = (enumTowerLamp)cTempSystem.iLampCycle_G;
          iBlankTime = cTempSystem.iLampCycle_BlinkTime;
          eBuzz = (enumBuzzer)cTempSystem.iBuzzCycle_Mode;
          iBuzzTime = cTempSystem.iBuzzCycle_Time;
          break;
        default:
          break;
      }
      if (eR == enumTowerLamp.On) { pnlDataTowerR.BackColor = Color.Red; }
      else if (eR == enumTowerLamp.Off) { pnlDataTowerR.BackColor = Color.Maroon; }
      if (eY == enumTowerLamp.On) { pnlDataTowerY.BackColor = Color.Yellow; }
      else if (eY == enumTowerLamp.Off) { pnlDataTowerY.BackColor = Color.DarkGoldenrod; }
      if (eG == enumTowerLamp.On) { pnlDataTowerG.BackColor = Color.Lime; }
      else if (eG == enumTowerLamp.Off) { pnlDataTowerG.BackColor = Color.DarkGreen; }


      dLampTimer += 100;
      if (dLampTimer < iBlankTime / 2)
      {
        if (eR == enumTowerLamp.Blink) { pnlDataTowerR.BackColor = Color.Red; }
        if (eY == enumTowerLamp.Blink) { pnlDataTowerY.BackColor = Color.Yellow; }
        if (eG == enumTowerLamp.Blink) { pnlDataTowerG.BackColor = Color.Lime; }
      }
      if (dLampTimer > iBlankTime / 2)
      {
        if (eR == enumTowerLamp.Blink) { pnlDataTowerR.BackColor = Color.Maroon; }
        if (eY == enumTowerLamp.Blink) { pnlDataTowerY.BackColor = Color.DarkGoldenrod; }
        if (eG == enumTowerLamp.Blink) { pnlDataTowerG.BackColor = Color.DarkGreen; }
      }

      if (dLampTimer >= iBlankTime)
      {
        dLampTimer = 0;
      }
    }

    private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTempSystem.iLanguage = cboLanguage.SelectedIndex;
    }

    private void cboProbe_Com_SelectedIndexChanged(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      switch (ctrl.Name)
      {
        case "cboProbe1_Com": cTempSystem.strProbe1_Com = ctrl.Text; break;
        case "cboProbe2_Com": cTempSystem.strProbe2_Com = ctrl.Text; break;
      }
    }

    private void btnSave_Probe_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();

      if (Save_Probe() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemComunicationFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private bool Save_Probe()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.strProbe1_Com = cTempSystem.strProbe1_Com;
      cReplace.strProbe1_Baudrate = cTempSystem.strProbe1_Baudrate;
      cReplace.strProbe2_Com = cTempSystem.strProbe2_Com;
      cReplace.strProbe2_Baudrate = cTempSystem.strProbe2_Baudrate;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void btnOpen1_Probe_Click(object sender, EventArgs e)
    {
      CMaster.cProbe1.Open_Port(cTempSystem.strProbe1_Com, cTempSystem.strProbe1_Baudrate);
    }

    private void btnClose1_Probe_Click(object sender, EventArgs e)
    {
      CMaster.cProbe1.Close_Port();
    }

    private void btnOpen2_Probe_Click(object sender, EventArgs e)
    {
      CMaster.cProbe2.Open_Port(cTempSystem.strProbe2_Com, cTempSystem.strProbe2_Baudrate);

    }

    private void btnClose2_Probe_Click(object sender, EventArgs e)
    {
      CMaster.cProbe2.Close_Port();
    }

    private void cboProbe_Baudrate_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
        switch (ctrl.Name)
        {
            case "cboProbe1_Baudrate": cTempSystem.strProbe1_Baudrate = ctrl.Text; break;
            case "cboProbe2_Baudrate": cTempSystem.strProbe2_Baudrate = ctrl.Text; break;
        }
    }

    private void btn_Data_UseSkip_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_UseSkip() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataUseSkipSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_Data_ProbeOffset_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_ProbeOffset() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataProbeOffsetSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private bool Save_ProbeOffset()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dProbeOffset_1 = cTempSystem.dProbeOffset_1;
      cReplace.dProbeOffset_2 = cTempSystem.dProbeOffset_2;
      cReplace.dProbeOffset_3 = cTempSystem.dProbeOffset_3;
      cReplace.dProbeOffset_4 = cTempSystem.dProbeOffset_4;

      cReplace.iProbeValueAverageCount = cTempSystem.iProbeValueAverageCount;
      cReplace.iProbeValueAverageMin = cTempSystem.iProbeValueAverageMin;
      cReplace.iProbeValueAverageMax = cTempSystem.iProbeValueAverageMax;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_UseSkip()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.bUseBarcode_1D = cTempSystem.bUseBarcode_1D;
      cReplace.bUseBarcode_2D = cTempSystem.bUseBarcode_2D;
      cReplace.bUseLoadingShake = cTempSystem.bUseLoadingShake;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Mode();
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_Safety_Z_Pos()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dZ1_Safety_Limit = cTempSystem.dZ1_Safety_Limit;
      cReplace.dZ2_Safety_Limit = cTempSystem.dZ2_Safety_Limit;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        CIoVo.Send_Safety_Z_Pos();
        return true;
      }
      else
      {
        return false;
      }
    }

    private void btn_Z_SaftyPos_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Safety_Z_Pos() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemSafetyZPosSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btn_Probe_SaftyPos_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_Safety_Probe_Pos() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemSafetyProbePosSaveFail);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private bool Save_Safety_Probe_Pos()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.dProbe_Stage1_Safety_Gap = cTempSystem.dProbe_Stage1_Safety_Gap;
      cReplace.dProbe_Stage2_Safety_Gap = cTempSystem.dProbe_Stage2_Safety_Gap;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void chkUse_Data_Click(object sender, EventArgs e)
    {
      cTempSystem.bUsePB1 = chkUse_PB1.Checked;
      cTempSystem.bUsePB2 = chkUse_PB2.Checked;
      cTempSystem.bUsePB3 = chkUse_PB3.Checked;
      cTempSystem.bUsePB4 = chkUse_PB4.Checked;

      cTempSystem.bUseBarcode_1D = chkUse_BCR_1D.Checked;
      cTempSystem.bUseBarcode_2D = chkUse_BCR.Checked;
      cTempSystem.bUseLoadingShake = chkUse_LoadingShake.Checked;

      Display_Refresh();
    }

    private void btn_Color_Min_Click(object sender, EventArgs e)
    {
      ColorDialog cd = new ColorDialog();
      if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        cTempSystem.iMinDisplayColor = cd.Color.ToArgb();
        btn_Color_Min.BackColor = Color.FromArgb(cTempSystem.iMinDisplayColor);
      }
    }

    private void btn_Color_Max_Click(object sender, EventArgs e)
    {
      ColorDialog cd = new ColorDialog();
      if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        cTempSystem.iMaxDisplayColor = cd.Color.ToArgb();
        btn_Color_Max.BackColor = Color.FromArgb(cTempSystem.iMaxDisplayColor);
      }
    }

    private void btn_Data_Color_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (Save_DisplayColor() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.SystemDataDisplayColor);
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private bool Save_DisplayColor()
    {
      ClassSystemPara cOld = CVo.cParaSys.GetValues();
      ClassSystemPara cReplace = CVo.cParaSys.GetValues();

      cReplace.iMaxDisplayColor = cTempSystem.iMaxDisplayColor;
      cReplace.iMinDisplayColor = cTempSystem.iMinDisplayColor;

      bool bResult = CVo.Change_Parameter_System(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

  }
}
