using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE.MASTER;
using BASE.VO;
using System.Windows.Forms;
using System.Threading;

namespace BASE.MODULE.MOTION
{
  public class ClassMotionAction
  {
    private static ClassMotionAction cInstatnce;
    private static object syncLock = new object();
    //public ClassMotionControl cCtrl = ClassMotionControl.Get_Instance();

    protected ClassMotionAction()
    {

    }

    public static ClassMotionAction Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassMotionAction();
          }
        }
      }
      return cInstatnce;
    }

    private static int iWaitDelay = 5000;

    #region Parameter
    public bool Motion_Initial()  // 모션 초기화 함수 
    {
      try
      {
        #region "아진 모션 이니셜"
        string sMsg = "";
        if (CAXL.AxlOpen(7) == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
        {
          CMotionVo.bAjinConnect = true;
          sMsg = "LIBRARY SUCCESS";
        } //초기화 성공
        else { } //초기화 실패 노트북모드로 변경 
        if (CAXL.AxlIsOpened() == 1) { sMsg = sMsg + "-> LIBRARY SUCCESS OK"; }
        else { }

        string strPath = CVo.SYSTEM_PATH + CVo.SYSTEM_NAME_Ajin;

        if (System.IO.File.Exists(strPath))
          CAXM.AxmMotLoadParaAll(strPath);
        else
          MessageBox.Show("Not found Ajin motion parameter file");
        // 모션 초기화 후에 모터별 세부 설정은 여기서 진행 
        for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
        {

        }

        #endregion


        return false;

      }

      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        return false;
      }
    }
    #endregion

    #region "통합 모션 제어"
    //public bool Get_Motion(int index)
    //{

    //  switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //  {
    //    case (int)enumMotorType.Ajin:
    //      cCtrl.Sub_Get_Motion_Ajin(index);
    //      break;
    //    case (int)enumMotorType.EzServo:
    //      cCtrl.Sub_Get_Motion_EzServo(index);
    //      break;
    //    case (int)enumMotorType.PLC:
    //      cCtrl.Sub_Get_Motion_PLC(index);
    //      break;
    //  }
    //  return true;
    //}

    //public bool Set_SvOn(int index, bool bAll)  // 서보 온 
    //{
    //  if (bAll) // 전체 서보 온
    //  {
    //    for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
    //    {
    //      if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //          CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //      {
    //        switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //        {
    //          case (int)enumMotorType.Ajin:
    //            cCtrl.Sub_Set_SvOn(index);
    //            break;
    //          case (int)enumMotorType.EzServo:
    //            break;
    //          case (int)enumMotorType.PLC:
    //            break;
    //        }
    //      }
    //    }
    //  }
    //  else // 개별 서보 온 
    //  {
    //    if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //        CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //    {
    //      switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //      {
    //        case (int)enumMotorType.Ajin:
    //          cCtrl.Sub_Set_SvOn(index);
    //          break;
    //        case (int)enumMotorType.EzServo:
    //          break;
    //        case (int)enumMotorType.PLC:
    //          break;
    //      }
    //    }
    //  }
    //  Thread.Sleep(200);
    //  return true;
    //}

    //public bool Set_SvOff(int index, bool bAll)  // 서보 오프
    //{
    //  if (bAll) // 전체 서보 오프
    //  {
    //    for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
    //    {
    //      if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //          CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //      {
    //        switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //        {
    //          case (int)enumMotorType.Ajin:
    //            cCtrl.Sub_Set_SvOff(index);
    //            break;
    //          case (int)enumMotorType.EzServo:
    //            break;
    //          case (int)enumMotorType.PLC:
    //            break;
    //        }
    //      }
    //    }
    //  }
    //  else // 개별 서보 오프
    //  {
    //    if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //        CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //    {
    //      switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //      {
    //        case (int)enumMotorType.Ajin:
    //          cCtrl.Sub_Set_SvOff(index);
    //          break;
    //        case (int)enumMotorType.EzServo:
    //          break;
    //        case (int)enumMotorType.PLC:
    //          break;
    //      }
    //    }
    //  }
    //  Thread.Sleep(200);
    //  return true;
    //}

    //public bool Set_SvReset(int index, bool bAll)  // 서보 리셋
    //{
    //  if (bAll) // 전체 서보 오프
    //  {
    //    for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
    //    {
    //      switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //      {
    //        case (int)enumMotorType.Ajin:
    //          cCtrl.Sub_Set_SvResetOn(index);
    //          break;
    //        case (int)enumMotorType.EzServo:
    //          break;
    //        case (int)enumMotorType.PLC:
    //          break;
    //      }
    //    }
    //    Thread.Sleep(1000);
    //    for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
    //    {
    //      switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //      {
    //        case (int)enumMotorType.Ajin:
    //          cCtrl.Sub_Set_SvResetOff(index);
    //          break;
    //        case (int)enumMotorType.EzServo:
    //          break;
    //        case (int)enumMotorType.PLC:
    //          break;
    //      }
    //    }
    //  }
    //  else // 개별 서보 오프
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        cCtrl.Sub_Set_SvResetOn(index);
    //        Thread.Sleep(1000);
    //        cCtrl.Sub_Set_SvResetOff(index);
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }

    //  return true;
    //}

    //public bool Set_JogCw_Run(int index, double dspeed)  // 정방향 조그
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        cCtrl.Sub_Set_CwJog(index, dspeed);
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_JogCcw_Run(int index, double dspeed)  // 역방향 조그
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        cCtrl.Sub_Set_CcwJog(index, dspeed);
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_Jog_Stop(int index)  // 조그 정지
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        cCtrl.Sub_Set_JogStop(index);
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_Move_Stop(int index)  // 이동 정지
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        cCtrl.Sub_Set_SvStop(index);
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_Home(int index) // 원점 복귀 
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        if (cCtrl.Sub_Set_Home(index) == false)
    //          return false;
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_DirectMove(int index, double dPosition, double dSpeed) // 바로 이동
    //{
    //  if (CMotionVo.GetMotorStatus((enumMotorName)index).bSpare == false &&
    //      CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //  {
    //    switch (CMotionVo.GetMotorStatus((enumMotorName)index).iCoaxial) // 모터 타입 체크 
    //    {
    //      case (int)enumMotorType.Ajin:
    //        if (cCtrl.Sub_Set_DirectMove(index, dPosition, dSpeed) == false)
    //          return false;
    //        break;
    //      case (int)enumMotorType.EzServo:
    //        break;
    //      case (int)enumMotorType.PLC:
    //        break;
    //    }
    //  }
    //  return true;
    //}

    //public bool Set_Move_Muiti(int[] index, int[] iPoint, string Comment) // 축별 선언된 포인트 멀티 이송  
    //{
    //  int iloopMax = 1; // 멀티에서는 처음 선언된 모터 타입을 체크 
    //  for (int iloop = 0; iloop < iloopMax /*index.Length*/; iloop++)
    //  {
    //    bool btest = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSpare;
    //    if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSpare == false &&
    //        CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bMotorSkip == false) // 전 축중에 사용하는 축만  
    //    {
    //      switch (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).iCoaxial) // 모터 타입 체크 
    //      {
    //        case (int)enumMotorType.Ajin:
    //          if (cCtrl.Sub_Set_MoveMuitil(index, iPoint) == false)
    //            return false;
    //          break;
    //        case (int)enumMotorType.EzServo:
    //          break;
    //        case (int)enumMotorType.PLC:
    //          break;
    //      }
    //    }
    //  }
    //  return true;
    //}
    #endregion

    #region 모션별 멀티 명령





    //public bool LoaderReadyMove() // 로더 대기위치 이송 
    //{
    //  string sComment = "Loader Ready Move";
    //  int[] Axis = { (int)enumMotorName.LE, (int)enumMotorName.LP };
    //  int[] Point = { (int)enumPos_LE.Ready, (int)enumPos_LP.Ready };

    //  if (Set_Move_Muiti(Axis, Point, sComment) == false)
    //    return false;

    //  return true;
    //}

    #endregion

    #region PLC 개별운전
    public bool LE_Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2120", false);

      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C0_LP_Align_Unload_Pos, (int)(cSys.dLP_AL_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1180_LP_AL_Loading_Pos, (int)(cSys.dLP_AL_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));

      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LE_Align_Ready.W10CE_LP_ReadyPos] = (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C0_LE_Scan_Start_Pos] = (int)(cSys.dLE_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C2_LE_Scan_Complete_Pos] = (int)(cSys.dLE_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C4_LE_Cassette_Wait_Pos] = (int)(cSys.dLE_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C6_BCX_Ready_Pos] = (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C8_BCY_Ready_Pos] = (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CA_BCX_Read_Pos] = (int)(cRcp.dPCB_Barcode_BCX_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CC_BCY_Read_Pos] = (int)(cRcp.dPCB_Barcode_BCY_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CE_LP_ReadyPos] = (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10D8_LE_Spd] = (int)(cSys.dLE_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DA_LE_Scan_Spd] = (int)(cSys.dLE_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DC_BCX_Spd] = (int)(cSys.dBCX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DE_BCY_Spd] = (int)(cSys.dBCY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      CIoVo.Set_WA_LE_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        if (CVo.bPCB_Empty)
        {
          return false;
        }
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2120_LE_Align_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1040_LE_Align_Start, true);
      

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2120_LE_Align_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1040_LE_Align_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2260_BH_Door_Open_Error_LEAlignReady;
      int iErrorEnd = (int)enumError.B227F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running))
      {
        if (CVo.eMachineStatus == enumMachineStatus.Error || CVo.eMachineStatus == enumMachineStatus.ErrorAuto)
        {
          return false;
        } //  상시 에러가 발생하면 그냥 나간다.
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2120_LE_Align_Complete))
      {
        if (CVo.eMachineStatus == enumMachineStatus.Error || CVo.eMachineStatus == enumMachineStatus.ErrorAuto)
        {
          return false;
        } //  상시 에러가 발생하면 그냥 나간다.
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C0_LE_Align_Running) == false
         && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2120_LE_Align_Complete) == false)
        {
          return false;
        }
      }
      return true;
    }
    public bool LE_Cassette_Wait()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2121", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LE_Align_Ready.W10C0_LE_Scan_Start_Pos] = (int)(cSys.dLE_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C2_LE_Scan_Complete_Pos] = (int)(cSys.dLE_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C4_LE_Cassette_Wait_Pos] = (int)(cSys.dLE_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C6_BCX_Ready_Pos] = (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10C8_BCY_Ready_Pos] = (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CA_BCX_Read_Pos] = (int)(cRcp.dPCB_Barcode_BCX_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CC_BCY_Read_Pos] = (int)(cRcp.dPCB_Barcode_BCY_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10CE_LP_ReadyPos] = (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10D8_LE_Spd] = (int)(cSys.dLE_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DA_LE_Scan_Spd] = (int)(cSys.dLE_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DC_BCX_Spd] = (int)(cSys.dBCX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_Align_Ready.W10DE_BCY_Spd] = (int)(cSys.dBCY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      CIoVo.Set_WA_LE_Align_Ready(WData);
                                                               
      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2121_LE_Cassette_Wait_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1041_LE_Cassette_Wait_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2121_LE_Cassette_Wait_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1041_LE_Cassette_Wait_Start, false);


      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2260_BH_Door_Open_Error_LEAlignReady;
      int iErrorEnd = (int)enumError.B227F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2121_LE_Cassette_Wait_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C1_LE_Cassette_Waiting) == false
         && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2121_LE_Cassette_Wait_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE1_Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2122", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE1_Align_Ready.W10E0_UE1_Scan_Start_Pos] = (int)(cSys.dUE1_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10E2_UE1_Scan_Complete_Pos] =  (int)(cSys.dUE1_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10E4_UE1_Cassete_Wait_Pos] =  (int)(cSys.dUE1_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10F8_UE1_Spd] =  (int)(cSys.dUE1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10FA_UE1_Scan_Spd] =  (int)(cSys.dUE1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      CIoVo.Set_WA_UE1_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      
      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2122_UE1_Align_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1042_UE1_Align_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2122_UE1_Align_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1042_UE1_Align_Start, false);


      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2280_BH_Door_Open_Error_UE1AlignReady;
      int iErrorEnd = (int)enumError.B229F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2122_UE1_Align_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C2_UE1_Align_Running) == false
 && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2122_UE1_Align_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE1_Cassette_Wait()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2123", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE1_Align_Ready.W10E0_UE1_Scan_Start_Pos] = (int)(cSys.dUE1_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10E2_UE1_Scan_Complete_Pos] = (int)(cSys.dUE1_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10E4_UE1_Cassete_Wait_Pos] = (int)(cSys.dUE1_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10F8_UE1_Spd] = (int)(cSys.dUE1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      WData[(int)enumWW_UE1_Align_Ready.W10FA_UE1_Scan_Spd] = (int)(cSys.dUE1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE1).dLimitScale);
      CIoVo.Set_WA_UE1_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }
      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2123_UE1_Cassette_Wait_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1043_UE1_Cassette_Wait_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2123_UE1_Cassette_Wait_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1043_UE1_Cassette_Wait_Start, false);


      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2280_BH_Door_Open_Error_UE1AlignReady;
      int iErrorEnd = (int)enumError.B229F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2123_UE1_Cassette_Wait_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C3_UE1_Cassette_Waiting) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2123_UE1_Cassette_Wait_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE2_Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2124", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE2_Align_Ready.W1100_UE2_Scan_Start_Pos] = (int)(cSys.dUE2_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1102_UE2_Scan_Complete_Pos] = (int)(cSys.dUE2_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1104_UE2_Cassete_Wait_Pos] = (int)(cSys.dUE2_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1118_UE2_Spd] = (int)(cSys.dUE2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W111A_UE2_Scan_Spd] = (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      CIoVo.Set_WA_UE2_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2124_UE2_Align_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1044_UE2_Align_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2124_UE2_Align_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1044_UE2_Align_Start, false);


      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22A0_BH_Door_Open_Error_UE2AlignReady;
      int iErrorEnd = (int)enumError.B22BF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2124_UE2_Align_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C4_UE2_Align_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2124_UE2_Align_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE2_Cassette_Wait()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2125", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE2_Align_Ready.W1100_UE2_Scan_Start_Pos] = (int)(cSys.dUE2_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1102_UE2_Scan_Complete_Pos] = (int)(cSys.dUE2_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1104_UE2_Cassete_Wait_Pos] = (int)(cSys.dUE2_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W1118_UE2_Spd] = (int)(cSys.dUE2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      WData[(int)enumWW_UE2_Align_Ready.W111A_UE2_Scan_Spd] = (int)(cSys.dUE2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE2).dLimitScale);
      CIoVo.Set_WA_UE2_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2125_UE2_Cassette_Wait_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1045_UE2_Cassette_Wait_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2125_UE2_Cassette_Wait_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1045_UE2_Cassette_Wait_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22A0_BH_Door_Open_Error_UE2AlignReady;
      int iErrorEnd = (int)enumError.B22BF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2125_UE2_Cassette_Wait_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C5_UE2_Cassette_Waiting) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2125_UE2_Cassette_Wait_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE3_Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2126", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE3_Align_Ready.W1120_UE3_Scan_Start_Pos] = (int)(cSys.dUE3_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1122_UE3_Scan_Complete_Pos] = (int)(cSys.dUE3_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1124_UE3_Cassete_Wait_Pos] = (int)(cSys.dUE3_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1138_UE3_Spd] = (int)(cSys.dUE3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W113A_UE3_Scan_Spd] = (int)(cSys.dUE3_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      CIoVo.Set_WA_UE3_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2126_UE3_Align_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1046_UE3_Align_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2126_UE3_Align_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1046_UE3_Align_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22C0_BH_Door_Open_Error_UE3AlignReady;
      int iErrorEnd = (int)enumError.B22DF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2126_UE3_Align_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C6_UE3_Align_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2126_UE3_Align_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE3_Cassette_Wait()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2127", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE3_Align_Ready.W1120_UE3_Scan_Start_Pos] = (int)(cSys.dUE3_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1122_UE3_Scan_Complete_Pos] = (int)(cSys.dUE3_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1124_UE3_Cassete_Wait_Pos] = (int)(cSys.dUE3_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W1138_UE3_Spd] = (int)(cSys.dUE3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      WData[(int)enumWW_UE3_Align_Ready.W113A_UE3_Scan_Spd] = (int)(cSys.dUE3_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE3).dLimitScale);
      CIoVo.Set_WA_UE3_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2127_UE3_Cassette_Wait_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1047_UE3_Cassette_Wait_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2127_UE3_Cassette_Wait_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1047_UE3_Cassette_Wait_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22C0_BH_Door_Open_Error_UE3AlignReady;
      int iErrorEnd = (int)enumError.B22DF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2127_UE3_Cassette_Wait_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C7_UE3_Cassette_Waiting) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2127_UE3_Cassette_Wait_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE4_Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2128", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE4_Align_Ready.W1140_UE4_Scan_Start_Pos] = (int)(cSys.dUE4_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1142_UE4_Scan_Complete_Pos] = (int)(cSys.dUE4_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1144_UE4_Cassete_Wait_Pos] = (int)(cSys.dUE4_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1158_UE4_Spd] = (int)(cSys.dUE4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W115A_UE4_Scan_Spd] = (int)(cSys.dUE4_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      CIoVo.Set_WA_UE4_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2128_UE4_Align_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1048_UE4_Align_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2128_UE4_Align_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1048_UE4_Align_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22E0_BH_Door_Open_Error_UE4AlignReady;
      int iErrorEnd = (int)enumError.B22FF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2128_UE4_Align_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C8_UE4_Align_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2128_UE4_Align_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UE4_Cassette_Wait()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2129", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UE4_Align_Ready.W1140_UE4_Scan_Start_Pos] = (int)(cSys.dUE4_ScanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1142_UE4_Scan_Complete_Pos] = (int)(cSys.dUE4_ScanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1144_UE4_Cassete_Wait_Pos] = (int)(cSys.dUE4_Cassette_Wait_Pos * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W1158_UE4_Spd] = (int)(cSys.dUE4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      WData[(int)enumWW_UE4_Align_Ready.W115A_UE4_Scan_Spd] = (int)(cSys.dUE4_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.UE4).dLimitScale);
      CIoVo.Set_WA_UE4_Align_Ready(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2129_UE4_Cassette_Wait_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1049_UE4_Cassette_Wait_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2129_UE4_Cassette_Wait_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1049_UE4_Cassette_Wait_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B22E0_BH_Door_Open_Error_UE4AlignReady;
      int iErrorEnd = (int)enumError.B22FF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2129_UE4_Cassette_Wait_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20C9_UE4_Cassette_Waiting) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2129_UE4_Cassette_Wait_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool LE_to_LP()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212A", false);
      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C0_LP_Align_Unload_Pos, (int)(cSys.dLP_AL_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1180_LP_AL_Loading_Pos, (int)(cSys.dLP_AL_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));

      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LE_to_LP.W1160_LP_LE_Pos] = (int)(cSys.dLP_LE_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LE_to_LP.W1164_BCX_Ready_Pos] = (int)(cSys.dBCX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCX).dLimitScale);
      WData[(int)enumWW_LE_to_LP.W1166_BCY_Ready_Pos] = (int)(cSys.dBCY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.BCY).dLimitScale);
      WData[(int)enumWW_LE_to_LP.W116C_LE_Down_Offset_Rel] = (int)(cSys.dLE_DownOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.LE).dLimitScale);
      WData[(int)enumWW_LE_to_LP.W1172_LP_Shake_Count] = (int)(cSys.iShakeCount);
      WData[(int)enumWW_LE_to_LP.W1178_LP_Spd] = (int)(cSys.dLP_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      CIoVo.Set_WA_LE_to_LP(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212A_LE_to_LP_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104A_LE_to_LP_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212A_LE_to_LP_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104A_LE_to_LP_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2300_BH_Door_Open_Error_LEtoLP;
      int iErrorEnd = (int)enumError.B231F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212A_LE_to_LP_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CA_LE_to_LP_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212A_LE_to_LP_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool LP_to_AL()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212B", false);
      CIoVo.Set_WW_AL_to_LP(enumWW_AL_to_LP.W11C0_LP_Align_Unload_Pos, (int)(cSys.dLP_AL_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));

      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LP_to_AL.W1180_LP_AL_Loading_Pos] = (int)(cSys.dLP_AL_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LP_to_AL.W1182_ALX_Ready_Pos] = (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_LP_to_AL.W1184_ALY_Ready_Pos] = (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      CIoVo.Set_WA_LP_to_AL(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212B_LP_to_AL_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104B_LP_to_AL_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212B_LP_to_AL_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104B_LP_to_AL_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2320_BH_Door_Open_Error_LPtoAL;
      int iErrorEnd = (int)enumError.B233F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212B_LP_to_AL_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CB_LP_to_AL_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212B_LP_to_AL_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Align()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212C", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Align.W11A0_ALX_Befor_Pos] = (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_Align.W11A2_ALY_Befor_Pos] = (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      WData[(int)enumWW_Align.W11A4_ALX_Align_Pos] = (int)(cRcp.dPCB_Align_ALX_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_Align.W11A6_ALY_Align_Pos] = (int)(cRcp.dPCB_Align_ALY_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      WData[(int)enumWW_Align.W11A8_ALX_Back_Offset] = (int)(cSys.dALX_AlignBackOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_Align.W11AA_ALY_Back_Offset] = (int)(cSys.dALY_AlignBackOffset_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      WData[(int)enumWW_Align.W11B8_ALX_Low_Spd] = (int)(cSys.dALX_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_Align.W11BA_ALY_Low_Spd] = (int)(cSys.dALY_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      WData[(int)enumWW_Align.W11BC_ALX_Spd] = (int)(cSys.dALX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_Align.W11BE_ALY_Spd] = (int)(cSys.dALY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      CIoVo.Set_WA_Align(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212C_AL_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104C_Align_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CC_AL_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212C_AL_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104C_Align_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2340_BH_Door_Open_Error_AL;
      int iErrorEnd = (int)enumError.B235F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CC_AL_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212C_AL_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CC_AL_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212C_AL_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool AL_to_LP_Start()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212D", false);
      CIoVo.Set_WW_LP_to_AL(enumWW_LP_to_AL.W1180_LP_AL_Loading_Pos, (int)(cSys.dLP_AL_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));
      CIoVo.Set_WW_LE_Align_Ready(enumWW_LE_Align_Ready.W10CE_LP_ReadyPos, (int)(cSys.dLP_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale));

      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_AL_to_LP.W11C0_LP_Align_Unload_Pos] = (int)(cSys.dLP_AL_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_AL_to_LP.W11C2_ALX_Ready_Pos] = (int)(cSys.dALX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALX).dLimitScale);
      WData[(int)enumWW_AL_to_LP.W11C4_ALY_Ready_Pos] = (int)(cSys.dALY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.ALY).dLimitScale);
      CIoVo.Set_WA_AL_to_LP(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212D_AL_to_LP_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104D_AL_to_LP_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212D_AL_to_LP_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104D_AL_to_LP_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2360_BH_Door_Open_Error_ALtoLP;
      int iErrorEnd = (int)enumError.B237F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212D_AL_to_LP_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CD_AL_to_LP_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212D_AL_to_LP_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool LP_to_Stage1_Start()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212E", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LP_to_Stage1.W11E0_LP_Stage1_Pos] = (int)(cSys.dLP_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11E2_Z1_Ready_Pos] = (int)(cSys.dZ1_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11E4_Z1_Loading_Pos] = (int)(cSys.dZ1_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11E6_X1_Loading_Pos] = (int)(cSys.dX1_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11F8_Z1_Low_Spd] = (int)(cSys.dZ1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11FA_Z1_Spd] = (int)(cSys.dZ1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_LP_to_Stage1.W11FC_X1_Spd] = (int)(cSys.dX1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      CIoVo.Set_WA_LP_to_Stage1(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212E_LP_to_Stage1_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104E_LP_to_Stage1_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212E_LP_to_Stage1_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104E_LP_to_Stage1_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2380_BH_Door_Open_Error_LPtoStage1;
      int iErrorEnd = (int)enumError.B239F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212E_LP_to_Stage1_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212E_LP_to_Stage1_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool LP_to_Stage2_Start()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B212F", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_LP_to_Stage2.W1200_LP_Stage2_Pos] = (int)(cSys.dLP_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.LP).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W1202_Z2_Ready_Pos] = (int)(cSys.dZ2_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W1204_Z2_Loading_Pos] = (int)(cSys.dZ2_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W1206_X2_Loading_Pos] = (int)(cSys.dX2_Loading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W1218_Z2_Low_Spd] = (int)(cSys.dZ2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W121A_Z2_Spd] = (int)(cSys.dZ2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_LP_to_Stage2.W121C_X2_Spd] = (int)(cSys.dX2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      CIoVo.Set_WA_LP_to_Stage2(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212F_LP_to_Stage2_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104F_LP_to_Stage2_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212F_LP_to_Stage2_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B104F_LP_to_Stage2_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B23A0_BH_Door_Open_Error_LPtoStage2;
      int iErrorEnd = (int)enumError.B23BF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212F_LP_to_Stage2_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B212F_LP_to_Stage2_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage1_Zero(double x, double y1, double y2)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      double dMotorPosX = cSys.dX1_Center_Pos - x;
      double dMotorPosY1 = cSys.dPR1_Center_Pos - y1;
      double dMotorPosY2 = cSys.dPR2_Center_Pos + y2;

      CIoVo.Set_Address_Bit("B2130", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage1_Zero.W1220_Z1_Zero_Pos] = (int)(cSys.dZ1_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W1222_X1_Zero_Pos] = (int)(dMotorPosX * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W1224_PR1_Zero_Pos] = (int)(dMotorPosY1 * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W1226_PR2_Zero_Pos] = (int)(dMotorPosY2 * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W1238_PR1_Spd] = (int)(cSys.dPR1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W123A_PR2_Spd] = (int)(cSys.dPR2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale);
      WData[(int)enumWW_Stage1_Zero.W1230_Z1_Safety_Pos] = (int)(cSys.dZ1_Safety_Limit * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      CIoVo.Set_WA_Stage1_Zero(WData);

      // X, Z 속도 갱신시킨다
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11F8_Z1_Low_Spd, (int)(cSys.dZ1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FA_Z1_Spd, (int)(cSys.dZ1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FC_X1_Spd, (int)(cSys.dX1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
        if (CVo.bLaptopTestMode)
        {
          System.Threading.Thread.Sleep(500);
          return true;
        }

        while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2130_Stage1_Zero_Complete))
        {
          System.Threading.Thread.Sleep(100);
        }
        CIoVo.Set_WB_OutFlag(enumFlagOut.B1050_Stage1_Zero_Start, true);

        string strLogData = string.Format("X:{0} Z:{1} Y1:{2} Y2:{3} {4}", dMotorPosX.ToString("0.000"), cSys.dZ1_Center_Pos.ToString("0.000"), dMotorPosY1.ToString("0.000"), dMotorPosY2.ToString("0.000"), sComment);
        CMaster.cLogMgr.Add_MotionEvent(strLogData, CVo.eMachineStatus);
        for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
        {
          System.Threading.Thread.Sleep(1);
          if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running))
          {
            break;
          }
          if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2130_Stage1_Zero_Complete))
          {
            break;
          }
        }
        CIoVo.Set_WB_OutFlag(enumFlagOut.B1050_Stage1_Zero_Start, false);

        double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B23C0_BH_Door_Open_Error_Stage1Zero;
      int iErrorEnd = (int)enumError.B23DF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2130_Stage1_Zero_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2130_Stage1_Zero_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage2_Zero(double x, double y1, double y2)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      double dMotorPosX = cSys.dX2_Center_Pos - x;
      double dMotorPosY1 = cSys.dPR3_Center_Pos - y1;
      double dMotorPosY2 = cSys.dPR4_Center_Pos + y2;

      CIoVo.Set_Address_Bit("B2131", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage2_Zero.W1240_Z2_Zero_Pos] = (int)(cSys.dZ2_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W1242_X2_Zero_Pos] = (int)(dMotorPosX * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W1244_PR3_Zero_Pos] = (int)(dMotorPosY1 * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W1246_PR4_Zero_Pos] = (int)(dMotorPosY2 * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W1258_PR3_Spd] = (int)(cSys.dPR3_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W125A_PR4_Spd] = (int)(cSys.dPR4_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale);
      WData[(int)enumWW_Stage2_Zero.W1250_Z2_Safety_Pos] = (int)(cSys.dZ2_Safety_Limit * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      CIoVo.Set_WA_Stage2_Zero(WData);
      // X, Z 속도 갱신시킨다
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1218_Z2_Low_Spd, (int)(cSys.dZ2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121A_Z2_Spd, (int)(cSys.dZ2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121C_X2_Spd, (int)(cSys.dX2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
        if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

        while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2131_Stage2_Zero_Complete))
        {
          System.Threading.Thread.Sleep(100);
        }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1051_Stage2_Zero_Start, true);

      string strLogData = string.Format("X:{0} Z:{1} Y1:{2} Y2:{3} {4}", dMotorPosX.ToString("0.000"), cSys.dZ1_Center_Pos.ToString("0.000"), dMotorPosY1.ToString("0.000"), dMotorPosY2.ToString("0.000"), sComment);
      CMaster.cLogMgr.Add_MotionEvent(strLogData, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2131_Stage2_Zero_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1051_Stage2_Zero_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B23E0_BH_Door_Open_Error_Stage2Zero;
      int iErrorEnd = (int)enumError.B23FF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2131_Stage2_Zero_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2131_Stage2_Zero_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage1_Measure(double x, double y1, double y2)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      double dMotorPosX = cSys.dX1_Center_Pos - x;
      double dMotorPosY1 = cSys.dPR1_Center_Pos - y1;
      double dMotorPosY2 = cSys.dPR2_Center_Pos + y2;

      CIoVo.Set_Address_Bit("B2132", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage1_Measure.W1260_Z1_Measure_Pos] = (int)(cSys.dZ1_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_Stage1_Measure.W1262_X1_Measure_Pos] = (int)(dMotorPosX * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_Measure.W1264_PR1_Measure_Pos] = (int)(dMotorPosY1 * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale);
      WData[(int)enumWW_Stage1_Measure.W1266_PR2_Measure_Pos] = (int)(dMotorPosY2 * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale);
      CIoVo.Set_WA_Stage1_Measure(WData);

        // X, Z 속도 갱신시킨다
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11F8_Z1_Low_Spd, (int)(cSys.dZ1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FA_Z1_Spd, (int)(cSys.dZ1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage1(enumWW_LP_to_Stage1.W11FC_X1_Spd, (int)(cSys.dX1_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale));
      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2132_Stage1_Measure_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1052_Stage1_Measure_Start, true);

      string strLogData = string.Format("X:{0} Z:{1} Y1:{2} Y2:{3} {4}", dMotorPosX.ToString("0.000"), cSys.dZ1_Center_Pos.ToString("0.000"), dMotorPosY1.ToString("0.000"), dMotorPosY2.ToString("0.000"), sComment);
      CMaster.cLogMgr.Add_MotionEvent(strLogData, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2132_Stage1_Measure_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1052_Stage1_Measure_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B2400_BH_Door_Open_Error_Stage1Measure;
      int iErrorEnd = (int)enumError.B241F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2132_Stage1_Measure_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2132_Stage1_Measure_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage2_Measure(double x, double y1, double y2)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      double dMotorPosX = cSys.dX2_Center_Pos - x;
      double dMotorPosY1 = cSys.dPR3_Center_Pos - y1;
      double dMotorPosY2 = cSys.dPR4_Center_Pos + y2;

      CIoVo.Set_Address_Bit("B2133", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage2_Measure.W1280_Z2_Measure_Pos] = (int)(cSys.dZ2_Center_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_Stage2_Measure.W1282_X2_Measure_Pos] = (int)(dMotorPosX * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_Stage2_Measure.W1284_PR3_Measure_Pos] = (int)(dMotorPosY1 * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale);
      WData[(int)enumWW_Stage2_Measure.W1286_PR4_Measure_Pos] = (int)(dMotorPosY2 * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale);
      CIoVo.Set_WA_Stage2_Measure(WData);

      // X, Z 속도 갱신시킨다
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W1218_Z2_Low_Spd, (int)(cSys.dZ2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121A_Z2_Spd, (int)(cSys.dZ2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale));
      CIoVo.Set_WW_LP_to_Stage2(enumWW_LP_to_Stage2.W121C_X2_Spd, (int)(cSys.dX2_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale));
      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2133_Stage2_Measure_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1053_Stage2_Measure_Start, true);

      string strLogData = string.Format("X:{0} Z:{1} Y1:{2} Y2:{3} {4}", dMotorPosX.ToString("0.000"), cSys.dZ1_Center_Pos.ToString("0.000"), dMotorPosY1.ToString("0.000"), dMotorPosY2.ToString("0.000"), sComment);
      CMaster.cLogMgr.Add_MotionEvent(strLogData, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2133_Stage2_Measure_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1053_Stage2_Measure_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B2420_BH_Door_Open_Error_Stage2Measure;
      int iErrorEnd = (int)enumError.B243F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2133_Stage2_Measure_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2133_Stage2_Measure_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage1_to_UP()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2134", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage1_to_UL.W12A0_UPX_Stage1_Pos] = (int)(cSys.dUPX_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_Stage1_to_UL.W12A2_UPY_Stage1_Pos] = (int)(cSys.dUPY_Stage1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_Stage1_to_UL.W12A4_Z1_Unload_Pos] = (int)(cSys.dZ1_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_Stage1_to_UL.W12A6_X1_Unload_Pos] = (int)(cSys.dX1_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_to_UL.W12B8_UPX_Spd] = (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_Stage1_to_UL.W12BA_UPY_Spd] = (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      CIoVo.Set_WA_Stage1_to_UL(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }


      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2134_Stage1_to_UP_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1054_Stage1_to_UP_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2134_Stage1_to_UP_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1054_Stage1_to_UP_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B2440_BH_Door_Open_Error_Stage1toUP;
      int iErrorEnd = (int)enumError.B245F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2134_Stage1_to_UP_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2134_Stage1_to_UP_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage2_to_UP()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2135", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage2_to_UL.W12C0_UPX_Stage2_Pos] = (int)(cSys.dUPX_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_Stage2_to_UL.W12C2_UPY_Stage2_Pos] = (int)(cSys.dUPY_Stage2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_Stage2_to_UL.W12C4_Z2_Unload_Pos] = (int)(cSys.dZ2_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_Stage2_to_UL.W12C6_X2_Unload_Pos] = (int)(cSys.dX2_Unloading_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_Stage2_to_UL.W12D8_UPX_Spd] = (int)(cSys.dUPX_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_Stage2_to_UL.W12DA_UPY_Spd] = (int)(cSys.dUPY_Normal_Spd * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      CIoVo.Set_WA_Stage2_to_UL(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2135_Stage2_to_UP_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1055_Stage2_to_UP_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2135_Stage2_to_UP_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1055_Stage2_to_UP_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B2460_BH_Door_Open_Error_Stage2toUP;
      int iErrorEnd = (int)enumError.B247F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2135_Stage2_to_UP_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2135_Stage2_to_UP_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool UP_to_UE(int num/*1~4*/)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      CIoVo.Set_Address_Bit("B2136", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_UL_to_UE.W12E0_UPX_UE1_Unload_Pos] = (int)(cSys.dUPX_UE1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12E2_UPX_UE2_Unload_Pos] = (int)(cSys.dUPX_UE2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12E4_UPX_UE3_Unload_Pos] = (int)(cSys.dUPX_UE3_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12E6_UPX_UE4_Unload_Pos] = (int)(cSys.dUPX_UE4_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12E8_UPY_UE1_Unload_Pos] = (int)(cSys.dUPY_UE1_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12EA_UPY_UE2_Unload_Pos] = (int)(cSys.dUPY_UE2_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12EC_UPY_UE3_Unload_Pos] = (int)(cSys.dUPY_UE3_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12EE_UPY_UE4_Unload_Pos] = (int)(cSys.dUPY_UE4_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12F0_UPX_Ready_Pos] = (int)(cSys.dUPX_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPX).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12F2_UPY_Ready_Pos] = (int)(cSys.dUPY_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.UPY).dLimitScale);
      WData[(int)enumWW_UL_to_UE.W12F8_UP_Unload_Pos_Number] = num;
      CIoVo.Set_WA_UL_to_UE(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2136_UP_to_UE_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1056_UP_to_UE_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2136_UP_to_UE_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1056_UP_to_UE_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;


      int iErrorStart = (int)enumError.B2480_BH_Door_Open_Error_UPtoUE;
      int iErrorEnd = (int)enumError.B249F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2136_UP_to_UE_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D6_UP_to_UE_Running) == false
         && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2136_UP_to_UE_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage1_Clean(int count, int mode/*0:Stage 1:Probe*/, int PCBExist = 0 /*0: Empty 1: Exist*/)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      int iCount = 0;

      double dPR1_CleanPos = cSys.bUsePB1 ? cSys.dPR1_Clean_Pos : 0.0;
      double dPR2_CleanPos = cSys.bUsePB2 ? cSys.dPR2_Clean_Pos : 0.0;
      double dPR3_CleanPos = cSys.bUsePB3 ? cSys.dPR3_Clean_Pos : 0.0;
      double dPR4_CleanPos = cSys.bUsePB4 ? cSys.dPR4_Clean_Pos : 0.0;

      switch (mode)
      {
        case 0: iCount = cSys.iStageCleanCount; break;
        case 1: iCount = cSys.iProbeCleanCount; break;
        default: iCount = cSys.iStageCleanCount; break;
      }

      int iExist = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213C_X1_PCB_Exist) ?  1 : 0;

      CIoVo.Set_Address_Bit("B2137", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage1_Clean.W1300_Z1_Clean_Pos] = (int)(cSys.dZ1_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z1).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W1302_X1_Clean_Start_Pos] = (int)(cSys.dX1_CleanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W1304_X1_Clean_End_Pos] = (int)(cSys.dX1_CleanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W1306_X1_Probe_Clean_Pos] = (int)(cSys.dX1_CleanProbe_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W1308_PR1_Clean_Pos] = (int)(dPR1_CleanPos * CMotionVo.GetMotorStatus(enumMotorName.PR1).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W130A_PR2_Clean_Pos] = (int)(dPR2_CleanPos * CMotionVo.GetMotorStatus(enumMotorName.PR2).dLimitScale);
      WData[(int)enumWW_Stage1_Clean.W1316_PCB_Exist] = iExist;
      WData[(int)enumWW_Stage1_Clean.W1318_CleanMode] = mode;
      WData[(int)enumWW_Stage1_Clean.W131A_CleanCount] = count;
      WData[(int)enumWW_Stage1_Clean.W131C_X1_Low_Spd] = (int)(cSys.dX1_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      CIoVo.Set_WA_Stage1_Clean(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2137_Stage1_Clean_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1057_Stage1_Clean_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2137_Stage1_Clean_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1057_Stage1_Clean_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B24A0_BH_Door_Open_Error_Stage1Clean;
      int iErrorEnd = (int)enumError.B24BF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2137_Stage1_Clean_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2137_Stage1_Clean_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Stage2_Clean(int count, int mode/*0:Stage 1:Probe*/, int PCBExist = 0 /*0: Empty 1: Exist*/)
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      int iCount = 0;

      double dPR1_CleanPos = cSys.bUsePB1 ? cSys.dPR1_Clean_Pos : 0.0;
      double dPR2_CleanPos = cSys.bUsePB2 ? cSys.dPR2_Clean_Pos : 0.0;
      double dPR3_CleanPos = cSys.bUsePB3 ? cSys.dPR3_Clean_Pos : 0.0;
      double dPR4_CleanPos = cSys.bUsePB4 ? cSys.dPR4_Clean_Pos : 0.0;

      switch (mode)
      {
        case 0: iCount = cSys.iStageCleanCount; break;
        case 1: iCount = cSys.iProbeCleanCount; break;
        default: iCount = cSys.iStageCleanCount; break;
      }

      int iExist = CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B213D_X2_PCB_Exist) ? 1 : 0;

      CIoVo.Set_Address_Bit("B2138", false);
      int[] WData = new int[16];
      Array.Clear(WData, 0, WData.Length);
      WData[(int)enumWW_Stage2_Clean.W1320_Z2_Clean_Pos] = (int)(cSys.dZ2_Ready_Pos * CMotionVo.GetMotorStatus(enumMotorName.Z2).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W1322_X2_Clean_Start_Pos] = (int)(cSys.dX2_CleanStart_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W1324_X2_Clean_End_Pos] = (int)(cSys.dX2_CleanEnd_Pos * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W1326_X2_Probe_Clean_Pos] = (int)(cSys.dX2_CleanProbe_Pos * CMotionVo.GetMotorStatus(enumMotorName.X1).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W1328_PR3_Clean_Pos] = (int)(dPR3_CleanPos * CMotionVo.GetMotorStatus(enumMotorName.PR3).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W132A_PR4_Clean_Pos] = (int)(dPR4_CleanPos * CMotionVo.GetMotorStatus(enumMotorName.PR4).dLimitScale);
      WData[(int)enumWW_Stage2_Clean.W1336_PCB_Exist] = iExist;
      WData[(int)enumWW_Stage2_Clean.W1338_CleanMode] = mode;
      WData[(int)enumWW_Stage2_Clean.W133A_CleanCount] = count;
      WData[(int)enumWW_Stage2_Clean.W133C_X2_Low_Spd] = (int)(cSys.dX2_Low_Spd * CMotionVo.GetMotorStatus(enumMotorName.X2).dLimitScale);
      CIoVo.Set_WA_Stage2_Clean(WData);

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2138_Stage2_Clean_Complete))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1058_Stage2_Clean_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2138_Stage2_Clean_Complete))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1058_Stage2_Clean_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B24C0_BH_Door_Open_Error_Stage2Clean;
      int iErrorEnd = (int)enumError.B24DF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2138_Stage2_Clean_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2138_Stage2_Clean_Complete) == false)
        {
          return false;
        }
      }

      return true;
    }
    public bool Probe_Change()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_Address_Bit("B2139", false);
      while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2139_ProbeChange))
      {
        System.Threading.Thread.Sleep(100);
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1059_Probe_Change_Start, true);

      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      for (int i = 0; i < iWaitDelay; i++) // 구동 시작 대기 시간
      {
        System.Threading.Thread.Sleep(1);
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D9_ProbeChange_Running))
        {
          break;
        }
        if (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2139_ProbeChange))
        {
          break;
        }
      }
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1059_Probe_Change_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        return true;
      }

      int iErrorStart = (int)enumError.B24E0_BH_Door_Open_Error_ProbeChange;
      int iErrorEnd = (int)enumError.B24FF_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D9_ProbeChange_Running))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2139_ProbeChange))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D9_ProbeChange_Running) == false
         && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B2139_ProbeChange) == false)
        {
          return false;
        }
      }

      return true;
    }
    #endregion

    #region PLC Home
    public bool Home_Select(enumMotorName name)
    {
      bool bResult = false;
      switch (name)
      {
        case enumMotorName.LE:
          bResult = Home_LE();
          break;
        case enumMotorName.LP:
          bResult = Home_LP();
          break;
        case enumMotorName.BCX:
          bResult = Home_BCX();
          break;
        case enumMotorName.BCY:
          bResult = Home_BCY();
          break;
        case enumMotorName.ALX:
          bResult = Home_ALX();
          break;
        case enumMotorName.ALY:
          bResult = Home_ALY();
          break;
        case enumMotorName.X1:
          bResult = Home_X1();
          break;
        case enumMotorName.X2:
          bResult = Home_X2();
          break;
        case enumMotorName.Z1:
          bResult = Home_Z1();
          break;
        case enumMotorName.Z2:
          bResult = Home_Z2();
          break;
        case enumMotorName.PR1:
          bResult = Home_PR1();
          break;
        case enumMotorName.PR2:
          bResult = Home_PR2();
          break;
        case enumMotorName.PR3:
          bResult = Home_PR3();
          break;
        case enumMotorName.PR4:
          bResult = Home_PR4();
          break;
        case enumMotorName.UPX:
          bResult = Home_UPX();
          break;
        case enumMotorName.UPY:
          bResult = Home_UPY();
          break;
        case enumMotorName.UE1:
          bResult = Home_UE1();
          break;
        case enumMotorName.UE2:
          bResult = Home_UE2();
          break;
        case enumMotorName.UE3:
          bResult = Home_UE3();
          break;
        case enumMotorName.UE4:
          bResult = Home_UE4();
          break;
        default:
          bResult = false;
          break;
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      return bResult;
    }
    public void Home_Select_Direct(enumMotorName name)
    {
      switch (name)
      {
        case enumMotorName.LE: CIoVo.Set_WB_OutFlag(enumFlagOut.B1000_LE_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1000_LE_Home_Start, false); break;
        case enumMotorName.LP: CIoVo.Set_WB_OutFlag(enumFlagOut.B1007_LP_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1007_LP_Home_Start, false); break;
        case enumMotorName.BCX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1005_BCX_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1005_BCX_Home_Start, false); break;
        case enumMotorName.BCY: CIoVo.Set_WB_OutFlag(enumFlagOut.B1006_BCY_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1006_BCY_Home_Start, false); break;
        case enumMotorName.ALX: CIoVo.Set_WB_OutFlag(enumFlagOut.B100C_ALX_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100C_ALX_Home_Start, false); break;
        case enumMotorName.ALY: CIoVo.Set_WB_OutFlag(enumFlagOut.B100D_ALY_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100D_ALY_Home_Start, false); break;
        case enumMotorName.X1: CIoVo.Set_WB_OutFlag(enumFlagOut.B100E_X1_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100E_X1_Home_Start, false); break;
        case enumMotorName.X2: CIoVo.Set_WB_OutFlag(enumFlagOut.B100F_X2_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100F_X2_Home_Start, false); break;
        case enumMotorName.Z1: CIoVo.Set_WB_OutFlag(enumFlagOut.B100A_Z1_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100A_Z1_Home_Start, false); break;
        case enumMotorName.Z2: CIoVo.Set_WB_OutFlag(enumFlagOut.B100B_Z2_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B100B_Z2_Home_Start, false); break;
        case enumMotorName.PR1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1010_PR1_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1010_PR1_Home_Start, false); break;
        case enumMotorName.PR2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1011_PR2_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1011_PR2_Home_Start, false); break;
        case enumMotorName.PR3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1012_PR3_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1012_PR3_Home_Start, false); break;
        case enumMotorName.PR4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1013_PR4_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1013_PR4_Home_Start, false); break;
        case enumMotorName.UPX: CIoVo.Set_WB_OutFlag(enumFlagOut.B1008_UPX_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1008_UPX_Home_Start, false); break;
        case enumMotorName.UPY: CIoVo.Set_WB_OutFlag(enumFlagOut.B1009_UPY_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1009_UPY_Home_Start, false); break;
        case enumMotorName.UE1: CIoVo.Set_WB_OutFlag(enumFlagOut.B1001_UE1_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1001_UE1_Home_Start, false); break;
        case enumMotorName.UE2: CIoVo.Set_WB_OutFlag(enumFlagOut.B1002_UE2_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1002_UE2_Home_Start, false); break;
        case enumMotorName.UE3: CIoVo.Set_WB_OutFlag(enumFlagOut.B1003_UE3_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1003_UE3_Home_Start, false); break;
        case enumMotorName.UE4: CIoVo.Set_WB_OutFlag(enumFlagOut.B1004_UE4_Home_Start, true); System.Threading.Thread.Sleep(200); CIoVo.Set_WB_OutFlag(enumFlagOut.B1004_UE4_Home_Start, false); break;
        default: break;
      }
    }

    public bool Home_All()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus((enumMotorName)i);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, (enumMotorName)i);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B101F_All_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B101F_All_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus((enumMotorName)i);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, (enumMotorName)i);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FF_All_Home_Complete) == false)
        {
          return false;
        }
      }
      for (int i = 0; i < Enum.GetNames(typeof(enumMotorName)).Length; i++)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus((enumMotorName)i);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, (enumMotorName)i);
      }

      return true;
    }

    public bool Home_LE()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LE);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.LE);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1000_LE_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1000_LE_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LE);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.LE);
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2080_LE_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E0_LE_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2080_LE_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E0_LE_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LE);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.LE);
      }
      return true;
    }
    public bool Home_LP()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;

      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LP);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.LP);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }


      CIoVo.Set_WB_OutFlag(enumFlagOut.B1007_LP_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1007_LP_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LP);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.LP);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2087_LP_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E7_LP_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2087_LP_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E7_LP_Home_Complete) == false)
        {
          return false;
        }
      }

      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.LP);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.LP);
      }
      return true;
    }
    public bool Home_BCX()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCX);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCX);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1005_BCX_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1005_BCX_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCX);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCX);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2085_BCX_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E5_BCX_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2085_BCX_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E5_BCX_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCX);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCX);
      }
      return true;
    }
    public bool Home_BCY()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCY);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCY);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1006_BCY_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1006_BCY_Home_Start, false);


      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCY);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCY);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2086_BCY_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E6_BCY_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2086_BCY_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E6_BCY_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.BCY);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.BCY);
      }
      return true;
    }
    public bool Home_ALX()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALX);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALX);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100C_ALX_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100C_ALX_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALX);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALX);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208C_ALX_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EC_ALX_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208C_ALX_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EC_ALX_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALX);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALX);
      }
      return true;
    }
    public bool Home_ALY()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALY);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALY);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100D_ALY_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100D_ALY_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALY);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALY);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208D_ALY_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20ED_ALY_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208D_ALY_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20ED_ALY_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.ALY);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.ALY);
      }
      return true;
    }
    public bool Home_X1()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X1);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.X1);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100E_X1_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100E_X1_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X1);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.X1);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208E_X1_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EE_X1_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208E_X1_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EE_X1_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X1);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.X1);
      }
      return true;
    }
    public bool Home_X2()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X2);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.X2);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100F_X2_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100F_X2_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X2);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.X2);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208F_X2_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EF_X2_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208F_X2_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EF_X2_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.X2);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.X2);
      }
      return true;
    }
    public bool Home_Z1()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z1);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z1);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100A_Z1_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100A_Z1_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z1);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z1);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208A_Z1_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EA_Z1_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208A_Z1_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EA_Z1_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z1);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z1);
      }
      return true;
    }
    public bool Home_Z2()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z2);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z2);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B100B_Z2_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B100B_Z2_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z2);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z2);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208B_Z2_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EB_Z2_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208B_Z2_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20EB_Z2_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.Z2);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.Z2);
      }
      return true;
    }
    public bool Home_PR1()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR1);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR1);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1010_PR1_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1010_PR1_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR1);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR1);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2090_PR1_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F0_PR1_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2090_PR1_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F0_PR1_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR1);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR1);
      }
      return true;
    }
    public bool Home_PR2()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR2);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR2);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1011_PR2_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1011_PR2_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR2);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR2);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2091_PR2_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F1_PR2_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2091_PR2_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F1_PR2_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR2);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR2);
      }
      return true;
    }
    public bool Home_PR3()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR3);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR3);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1012_PR3_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1012_PR3_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR3);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR3);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2092_PR3_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F2_PR3_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2092_PR3_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F2_PR3_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR3);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR3);
      }
      return true;
    }
    public bool Home_PR4()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR4);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR4);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1013_PR4_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1013_PR4_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR4);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR4);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2093_PR4_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F3_PR4_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2093_PR4_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20F3_PR4_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.PR4);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.PR4);
      }
      return true;
    }
    public bool Home_UPX()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPX);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPX);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1008_UPX_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1008_UPX_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPX);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPX);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2088_UPX_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E8_UPX_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2088_UPX_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E8_UPX_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPX);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPX);
      }
      return true;
    }
    public bool Home_UPY()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPY);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPY);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1009_UPY_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1009_UPY_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPY);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPY);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2089_UPY_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E9_UPY_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2089_UPY_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E9_UPY_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UPY);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UPY);
      }
      return true;
    }
    public bool Home_UE1()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE1);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE1);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1001_UE1_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1001_UE1_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE1);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE1);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2081_UE1_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E1_UE1_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2081_UE1_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E1_UE1_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE1);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE1);
      }
      return true;
    }
    public bool Home_UE2()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE2);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE2);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1002_UE2_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1002_UE2_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE2);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE2);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2082_UE2_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E2_UE2_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2082_UE2_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E2_UE2_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE2);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE2);
      }
      return true;
    }
    public bool Home_UE3()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE3);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE3);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1003_UE3_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1003_UE3_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE3);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE3);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2083_UE3_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E3_UE3_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2083_UE3_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E3_UE3_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE3);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE3);
      }
      return true;
    }
    public bool Home_UE4()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE4);
        sTemp.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE4);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B1004_UE4_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B1004_UE4_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE4);
          sTemp.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE4);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2084_UE4_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E4_UE4_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2084_UE4_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20E4_UE4_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp = CMotionVo.GetMotorStatus(enumMotorName.UE4);
        sTemp.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp, enumMotorName.UE4);
      }
      return true;
    }

    public bool Home_Loading()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.LE);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.BCX);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.BCY);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.LP);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.ALX);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.ALY);
        sTemp1.bHomeComplete = false;
        sTemp2.bHomeComplete = false;
        sTemp3.bHomeComplete = false;
        sTemp4.bHomeComplete = false;
        sTemp5.bHomeComplete = false;
        sTemp6.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.LE);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.BCX);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.BCY);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.LP);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.ALX);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.ALY);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B101C_Loading_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B101C_Loading_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.LE);
          structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.BCX);
          structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.BCY);
          structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.LP);
          structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.ALX);
          structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.ALY);
          sTemp1.bHomeComplete = true;
          sTemp2.bHomeComplete = true;
          sTemp3.bHomeComplete = true;
          sTemp4.bHomeComplete = true;
          sTemp5.bHomeComplete = true;
          sTemp6.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp1, enumMotorName.LE);
          CMotionVo.SetMotorStatus(sTemp2, enumMotorName.BCX);
          CMotionVo.SetMotorStatus(sTemp3, enumMotorName.BCY);
          CMotionVo.SetMotorStatus(sTemp4, enumMotorName.LP);
          CMotionVo.SetMotorStatus(sTemp5, enumMotorName.ALX);
          CMotionVo.SetMotorStatus(sTemp6, enumMotorName.ALY);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209C_Loading_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FC_Loading_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209C_Loading_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FC_Loading_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.LE);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.BCX);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.BCY);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.LP);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.ALX);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.ALY);
        sTemp1.bHomeComplete = true;
        sTemp2.bHomeComplete = true;
        sTemp3.bHomeComplete = true;
        sTemp4.bHomeComplete = true;
        sTemp5.bHomeComplete = true;
        sTemp6.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.LE);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.BCX);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.BCY);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.LP);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.ALX);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.ALY);
      }
      return true;
    }
    public bool Home_Measure()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.X1);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.X2);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.Z1);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.Z2);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.PR1);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.PR2);
        structMotorStatus sTemp7 = CMotionVo.GetMotorStatus(enumMotorName.PR3);
        structMotorStatus sTemp8 = CMotionVo.GetMotorStatus(enumMotorName.PR4);
        sTemp1.bHomeComplete = false;
        sTemp2.bHomeComplete = false;
        sTemp3.bHomeComplete = false;
        sTemp4.bHomeComplete = false;
        sTemp5.bHomeComplete = false;
        sTemp6.bHomeComplete = false;
        sTemp7.bHomeComplete = false;
        sTemp8.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.X1);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.X2);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.Z1);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.Z2);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.PR1);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.PR2);
        CMotionVo.SetMotorStatus(sTemp7, enumMotorName.PR3);
        CMotionVo.SetMotorStatus(sTemp8, enumMotorName.PR4);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B101D_Measurement_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B101D_Measurement_Home_Start, false);

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.X1);
          structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.X2);
          structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.Z1);
          structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.Z2);
          structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.PR1);
          structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.PR2);
          structMotorStatus sTemp7 = CMotionVo.GetMotorStatus(enumMotorName.PR3);
          structMotorStatus sTemp8 = CMotionVo.GetMotorStatus(enumMotorName.PR4);
          sTemp1.bHomeComplete = true;
          sTemp2.bHomeComplete = true;
          sTemp3.bHomeComplete = true;
          sTemp4.bHomeComplete = true;
          sTemp5.bHomeComplete = true;
          sTemp6.bHomeComplete = true;
          sTemp7.bHomeComplete = true;
          sTemp8.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp1, enumMotorName.X1);
          CMotionVo.SetMotorStatus(sTemp2, enumMotorName.X2);
          CMotionVo.SetMotorStatus(sTemp3, enumMotorName.Z1);
          CMotionVo.SetMotorStatus(sTemp4, enumMotorName.Z2);
          CMotionVo.SetMotorStatus(sTemp5, enumMotorName.PR1);
          CMotionVo.SetMotorStatus(sTemp6, enumMotorName.PR2);
          CMotionVo.SetMotorStatus(sTemp7, enumMotorName.PR3);
          CMotionVo.SetMotorStatus(sTemp8, enumMotorName.PR4);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209D_Measure_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FD_Measure_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209D_Measure_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FD_Measure_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.X1);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.X2);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.Z1);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.Z2);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.PR1);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.PR2);
        structMotorStatus sTemp7 = CMotionVo.GetMotorStatus(enumMotorName.PR3);
        structMotorStatus sTemp8 = CMotionVo.GetMotorStatus(enumMotorName.PR4);
        sTemp1.bHomeComplete = true;
        sTemp2.bHomeComplete = true;
        sTemp3.bHomeComplete = true;
        sTemp4.bHomeComplete = true;
        sTemp5.bHomeComplete = true;
        sTemp6.bHomeComplete = true;
        sTemp7.bHomeComplete = true;
        sTemp8.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.X1);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.X2);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.Z1);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.Z2);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.PR1);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.PR2);
        CMotionVo.SetMotorStatus(sTemp7, enumMotorName.PR3);
        CMotionVo.SetMotorStatus(sTemp8, enumMotorName.PR4);
      }
      return true;
    }
    public bool Home_Unloading()
    {
      string sComment = System.Reflection.MethodBase.GetCurrentMethod().Name;
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.UPX);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.UPY);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.UE1);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.UE2);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.UE3);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.UE4);
        sTemp1.bHomeComplete = false;
        sTemp2.bHomeComplete = false;
        sTemp3.bHomeComplete = false;
        sTemp4.bHomeComplete = false;
        sTemp5.bHomeComplete = false;
        sTemp6.bHomeComplete = false;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.UPX);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.UPY);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.UE1);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.UE2);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.UE3);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.UE4);
      }

      if (CVo.bLaptopTestMode)
      {
        System.Threading.Thread.Sleep(500);
        return true;
      }

      CIoVo.Set_WB_OutFlag(enumFlagOut.B101E_Unloding_Home_Start, true);
      CMaster.cLogMgr.Add_MotionEvent(sComment, CVo.eMachineStatus);
      System.Threading.Thread.Sleep(iWaitDelay); // 구동 시작 대기 시간
      CIoVo.Set_WB_OutFlag(enumFlagOut.B101E_Unloding_Home_Start, false);      

      double dTimeOut = CVo.cParaSys.dCycleTimeOut;
      double dStartTime = 0;
      double dEndTime = 0;
      double dRunningTime = 0;
      if (CVo.bLaptopTestMode)
      {
        if (true)
        {
          structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.UPX);
          structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.UPY);
          structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.UE1);
          structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.UE2);
          structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.UE3);
          structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.UE4);
          sTemp1.bHomeComplete = true;
          sTemp2.bHomeComplete = true;
          sTemp3.bHomeComplete = true;
          sTemp4.bHomeComplete = true;
          sTemp5.bHomeComplete = true;
          sTemp6.bHomeComplete = true;
          CMotionVo.SetMotorStatus(sTemp1, enumMotorName.UPX);
          CMotionVo.SetMotorStatus(sTemp2, enumMotorName.UPY);
          CMotionVo.SetMotorStatus(sTemp3, enumMotorName.UE1);
          CMotionVo.SetMotorStatus(sTemp4, enumMotorName.UE2);
          CMotionVo.SetMotorStatus(sTemp5, enumMotorName.UE3);
          CMotionVo.SetMotorStatus(sTemp6, enumMotorName.UE4);
        }
        return true;
      }

      int iErrorStart = (int)enumError.B2220_BH_Door_Open_Error_Home;
      int iErrorEnd = (int)enumError.B223F_;

      dStartTime = System.Environment.TickCount;
      while (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209E_Unloading_Homming))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
      }

      dStartTime = System.Environment.TickCount;
      while (!CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FE_Unloading_Home_Complete))
      {
        for (int i = iErrorStart; i <= iErrorEnd; i++)
        {
          if (CIoVo.Get_RB_Error((enumError)i))
          {
            return false;
          }
        }
        System.Threading.Thread.Sleep(1);
        dEndTime = System.Environment.TickCount;
        dRunningTime = dEndTime - dStartTime;
        if (dTimeOut <= dRunningTime)
        {
          return false;
        }
        if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209E_Unloading_Homming) == false
&& CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B20FE_Unloading_Home_Complete) == false)
        {
          return false;
        }
      }
      if (true)
      {
        structMotorStatus sTemp1 = CMotionVo.GetMotorStatus(enumMotorName.UPX);
        structMotorStatus sTemp2 = CMotionVo.GetMotorStatus(enumMotorName.UPY);
        structMotorStatus sTemp3 = CMotionVo.GetMotorStatus(enumMotorName.UE1);
        structMotorStatus sTemp4 = CMotionVo.GetMotorStatus(enumMotorName.UE2);
        structMotorStatus sTemp5 = CMotionVo.GetMotorStatus(enumMotorName.UE3);
        structMotorStatus sTemp6 = CMotionVo.GetMotorStatus(enumMotorName.UE4);
        sTemp1.bHomeComplete = true;
        sTemp2.bHomeComplete = true;
        sTemp3.bHomeComplete = true;
        sTemp4.bHomeComplete = true;
        sTemp5.bHomeComplete = true;
        sTemp6.bHomeComplete = true;
        CMotionVo.SetMotorStatus(sTemp1, enumMotorName.UPX);
        CMotionVo.SetMotorStatus(sTemp2, enumMotorName.UPY);
        CMotionVo.SetMotorStatus(sTemp3, enumMotorName.UE1);
        CMotionVo.SetMotorStatus(sTemp4, enumMotorName.UE2);
        CMotionVo.SetMotorStatus(sTemp5, enumMotorName.UE3);
        CMotionVo.SetMotorStatus(sTemp6, enumMotorName.UE4);
      }
      return true;
    }
    #endregion

    #region PLC 실린더 동작
    public bool Cylinder_Loader(bool down) // 로더 실린더
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1114_LoadingPickerUpSol, !down);
      CIoVo.Set_WB_Output(enumBitOutput.B1115_LoadingPickerDownSol, down);
      return true;
    }

    public bool Cylinder_Unloader(bool down) // 언로더 실린더
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B111A_UnloadingPickerUpSol, !down);
      CIoVo.Set_WB_Output(enumBitOutput.B111B_UnloadingPickerDownSol, down);
      return true;
    }

    public bool Vaccum_Loader(bool on) // 로더 버큠
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1120_LoadingPickerVacuumSol, on);
      return true;
    }

    public bool Vaccum_Unloader(bool on) // 언로더 버큠
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1121_UnLoadingPickerVacuumSol, on);
      return true;
    }

    public bool Vaccume_Stage1(bool on) // 스테이지1 버큠 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1122_Chuck1VacuumSol_Rear, on);
      return true;
    }

    public bool Vaccume_Stage2(bool on) // 스테이지2 버큠 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1123_Chuck2VacuumSol_Front, on);
      return true;
    }

    public bool Sol_Probe1(bool on) // 프로브클린 솔1 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1118_ProbeAirBlowSol1_Rear, on);
      return true;
    }

    public bool Sol_Probe2(bool on) // 프로브클린 솔2 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1119_ProbeAirBlowSol2_Front, on);
      return true;
    }

    public bool Sol_Stage1(bool on) // 스테이지클린 솔1 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1116_Chuck1AirBlow_Rear, on);
      return true;
    }

    public bool Sol_Stage2(bool on) // 스테이지클린 솔2 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1117_Chuck2AirBlow_Front, on);
      return true;
    }

    public bool Sol_Loader(bool on) // 2매방지 솔 on:off
    {
      ClassSystemPara cSys = CVo.cParaSys.GetValues();
      CIoVo.Set_WB_Output(enumBitOutput.B1113_LoadingAirBlowSol, on);
      return true;
    }
    #endregion
  }
}
