using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using BASE.VO;
using BASE.MASTER;

using BASE.FORM;

namespace BASE.MODULE.MOTION
{

  public class ClassMotionControl
  {
    private static ClassMotionControl cInstatnce;
    private static object syncLock = new object();

    //private static System.Threading.Thread thMotion = null;
    //private static bool bThreadMotion = true;

    protected ClassMotionControl()
    {

    }

    public static ClassMotionControl Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassMotionControl();
          }
        }
      }
      return cInstatnce;
    }


    #region "아진 보드 관련 함수 "
    public bool Sub_Get_Motion_Ajin(int index) // 모션 상태 읽어오기  
    {
      structMotorStatus sMotorStatus = new structMotorStatus();        // 내부 모션 반영 구조체 
      sMotorStatus = CMotionVo.GetMotorStatus((enumMotorName)index);    // 설정된 내부 상태를 반영 

      if (CMotionVo.bAjinConnect == false) //가상모드
      {
        if (sMotorStatus.bCmdHome == true) //원점복귀 동작중 체크 
        {
          sMotorStatus.bCmdHome = false;
          sMotorStatus.bHomeComplete = true;
        }
        CMotionVo.SetMotorStatus(sMotorStatus, (enumMotorName)index);    // 변경된 상태를 내부에 적용 
        return true;
      }
      uint uReturn = 0;
      MOTION_INFO MotionStatus = new MOTION_INFO();                     // 아진 구조체 선언    
      MotionStatus.uMask = 0x1F;                                        // 아진 모션상태 반환 
      uReturn = CAXM.AxmStatusReadMotionInfo(index, ref MotionStatus);  // 아진 모션 상태 읽어오기 
      if (uReturn != 0) return false;
      sMotorStatus.dCmdPosition = MotionStatus.dCmdPos; //지령 위치 
      if (sMotorStatus.bEncNot) //엔코더 미사용 
        sMotorStatus.dCurrentPos = MotionStatus.dCmdPos; //지령 위치 
      else
        sMotorStatus.dCurrentPos = MotionStatus.dActPos; //엔코더 위치 
      sMotorStatus.dCurrentGap = Math.Abs(sMotorStatus.dCurrentPos - sMotorStatus.dCmdPosition);
      //  모션보드 MECHANICAL_SIGNAL 신호 상태 반환
      bool bstate = false;
      bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_ORG_LEVEL) == 0) ? false : true; // 모션보드 원점센서  
      sMotorStatus.bSensorHome = bstate;
      bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_PELM_LEVEL) == 0) ? false : true; // 모션보드 + 리미트센서   
      sMotorStatus.bSensorCw = bstate;
      bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_NELM_LEVEL) == 0) ? false : true; // 모션보드 - 리미트센서   
      sMotorStatus.bSensorCcw = bstate;
      bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_ALARM_LEVEL) == 0) ? false : true; // 모션보드 알람신호   
      sMotorStatus.bAlarm = bstate;
      //  bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_EXMP_LEVEL) == 0) ? false : true; // 모션보드 MPG EXMP신호   
      //  bstate = ((MotionStatus.uMechSig & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_EXPP_LEVEL) == 0) ? false : true; // 모션보드 MPG 신호  

      //  모션보드 Driver Status 신호 상태 반환
      bstate = ((MotionStatus.uDrvStat & (uint)AXT_MOTION_QIDRIVE_STATUS.QIDRIVE_STATUS_0) == 0) ? false : true; // 모션보드 인포지션 Bit 0, BUSY(드라이브 구동 중)
      sMotorStatus.bInPosition = bstate;

      //  모션보드 Signal Output 신호 상태 반환
      //  istate = ((MotionStatus.uOutput & (uint)0x01) == 0) ? (int)0 : (int)1; // 모션보드 출력 서보온    
      uint uStatus = 0;
      CAXM.AxmSignalIsServoOn(index, ref uStatus); // 지정축 서보온 상태 반환 
      if (uStatus == 0)
        bstate = false;
      else
        bstate = true;
      sMotorStatus.bServoOn = bstate;

      if (sMotorStatus.bCmdHome == true) //원점복귀 동작중 체크 
      {
        if (!Sub_Set_MoveCheck(index)) //구동중 상태 체크 
        {
          sMotorStatus.bCmdHome = false;
        }
        CAXM.AxmHomeGetResult(index, ref uStatus);
        if (uStatus == 1) // 콘텍 완료 
        {
          sMotorStatus.bCmdHome = false;
          sMotorStatus.bHomeComplete = true;
        }
      }

      CMotionVo.SetMotorStatus(sMotorStatus, (enumMotorName)index);    // 변경된 상태를 내부에 적용 
      return true;
    }

    public bool Sub_Set_SvOn(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmSignalServoOn(index, 1);
      return true;
    }

    public bool Sub_Set_SvOff(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmSignalServoOn(index, 0);
      return true;
    }

    public bool Sub_Set_SvResetOn(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmSignalServoAlarmReset(index, 1);
      return true;
    }

    public bool Sub_Set_SvResetOff(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmSignalServoAlarmReset(index, 0);
      return true;
    }

    public bool Sub_Set_MoveCheck(int index)
    {
      // if () return true; // 노트북 모드 스킵 
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == true) return true;
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bServoOn == false)
        Sub_Set_SvOn(index);
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bAlarm) //모터 구동시 알람이 있으면 에러 발생 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrServoAlarm, (enumMotorName)index, true);
        return false;
      }
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bSensorCw) //모터 구동시 정방향센서 입력시 에러 발생 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCw, (enumMotorName)index, true);
        return false;
      }
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bSensorCcw) //모터 구동시 역방향센서 입력시 에러 발생 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCcw, (enumMotorName)index, true);
        return false;
      }
      return true;
    }

    public bool Sub_Set_SvStop(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmMoveEStop(index);// 급정지
      return true;
    }

    public bool Sub_Set_JogStop(int index)
    {
      if (CMotionVo.bAjinConnect == false) return true;
      CAXM.AxmMoveSStop(index); // 감속정지
      return true;
    }

    public bool Sub_Set_CwJog(int index, double dSpeed) //정방향 조그 
    {
      if (CMotionVo.bAjinConnect == false) return true;
      if (!Sub_Set_MoveCheck(index)) //구동전 상태 체크 
        return false;
      double dPosition = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCw;
      double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitJogSpd;
      if (dLimitSpeed < dSpeed)
        dSpeed = dLimitSpeed;
      if (dSpeed == 0)
        dSpeed = 0.1;
      if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
      {

      }
      else
      {
        uint uState = CAXM.AxmMoveStartPos(index, dPosition, dSpeed, dSpeed * 10, dSpeed * 10);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index, true);
          return false;
        }
      }
      return true;
    }

    public bool Sub_Set_CcwJog(int index, double dSpeed) //역방향 조그 
    {
      if (CMotionVo.bAjinConnect == false) return true;
      if (!Sub_Set_MoveCheck(index)) //구동전 상태 체크
        return false;
      double dPosition = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCcw;
      double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitJogSpd;
      if (dLimitSpeed < dSpeed)
        dSpeed = dLimitSpeed;
      if (dSpeed == 0)
        dSpeed = 0.1;
      if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
      {

      }
      else
      {
        uint uState = CAXM.AxmMoveStartPos(index, dPosition, dSpeed, dSpeed * 10, dSpeed * 10);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index, true);
          return false;
        }
      }
      return true;
    }

    public bool Sub_Set_Pitch(int index, double dPitch, double dSpeed) // 피치 이송 
    {
      if (CMotionVo.bAjinConnect == false) return true;
      if (!Sub_Set_MoveCheck(index)) //구동전 상태 체크
        return false;
      double dPositionMax = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCw;
      double dPositionMin = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCcw;
      double dPosition = CMotionVo.GetMotorStatus((enumMotorName)index).dCurrentPos + dPitch;
      if (dPositionMax < dPosition) // 이동 거리가 리미트를 벗어남 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCw, (enumMotorName)index, true);
        return false;
      }
      if (dPositionMin > dPosition) // 이동 거리가 리미트를 벗어남 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCcw, (enumMotorName)index, true);
        return false;
      }

      double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSpeed;
      if (dLimitSpeed < dSpeed)
        dSpeed = dLimitSpeed;
      if (dSpeed == 0)
        dSpeed = 0.1;
      if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index, dPosition);
      }
      else
      {
        uint uState = CAXM.AxmMoveStartPos(index, dPosition, dSpeed, dSpeed * 10, dSpeed * 10);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index, true);
          return false;
        }
      }
      return true;
    }

    public bool Sub_Set_Home(int index)
    {
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bMotorSkip == true) return true;
      if (!CMotionVo.GetMotorStatus((enumMotorName)index).bServoOn)
        Sub_Set_SvOn(index);
      if (CMotionVo.GetMotorStatus((enumMotorName)index).bAlarm) //모터 구동시 알람이 있으면 에러 발생 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrServoAlarm, (enumMotorName)index, true);
        return false;
      }
      CMotionVo.SetMotorStatus(enumSetMotorStatus.bCmdHome, (enumMotorName)index, true);
      CMotionVo.SetMotorStatus(enumSetMotorStatus.bHomeComplete, (enumMotorName)index, false);
      if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index, 0);
      }
      else
      {
        uint uState = CAXM.AxmHomeSetStart(index);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index, true);
          return false;
        }
      }
      return true;
    }

    public bool Sub_Set_DirectMove(int index, double dPosition, double dSpeed) // 다이렉트 이송 
    {
      if (!Sub_Set_MoveCheck(index)) //구동전 상태 체크
        return false;
      double dPositionMax = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCw;
      double dPositionMin = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSoftCcw;

      if (dPositionMax < dPosition) // 이동 거리가 리미트를 벗어남 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCw, (enumMotorName)index, true);
        return false;
      }
      if (dPositionMin > dPosition) // 이동 거리가 리미트를 벗어남 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCcw, (enumMotorName)index, true);
        return false;
      }

      double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index).dLimitSpeed;
      if (dLimitSpeed < dSpeed)
        dSpeed = dLimitSpeed;
      if (dSpeed == 0)
        dSpeed = 0.1;
      if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
      {
        CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index, dPosition);
      }
      else
      {
        CAXM.AxmMotSetAbsRelMode(index, 0); //절대모드 = 0 , 상대모드 = 1
        CAXM.AxmMotSetProfileMode(index, 0); //대칭Trapezode = 0, 비대칭Trapezode = 1, 대칭 Quasi-S Curve = 2(PCI-N404/804는 지원안함.) , 대칭 S Curve = 3, 비대칭 S Curve = 4
        uint uState = CAXM.AxmMoveStartPos(index, dPosition, dSpeed, dSpeed * 10, dSpeed * 10);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index, true);
          return false;
        }
      }
      return true;
    }

    public bool Sub_Set_MoveMuitil(int[] index, int[] iPoint) //  이송 
    {
      bool bErrCheck = false; // 구동중 에러상태 변경후 모터 급정지 
      DateTime[] dateStartTime = new DateTime[index.Length]; // 모션 시작 시간 

      structMData sGetData;
      for (int iloop = 0; iloop < index.Length; iloop++)
      {
        if (Sub_Set_MoveCheck(index[iloop]) == false) //구동전 상태 체크
          bErrCheck = true;
        double dPositionMax = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCw;
        double dPositionMin = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCcw;
        sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
        double dPosition = sGetData.dPosition;
        double dSpeed = sGetData.dSpeed;
        double dAcc = sGetData.dAcc;
        double dDcc = sGetData.dDcc;
        dateStartTime[iloop] = DateTime.Now;
        if (dPositionMax < dPosition) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        if (dPositionMin > dPosition) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCcw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        double dMoveDistance = Math.Abs(sGetData.dPosition - CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentPos); // 이동하려는 거리 
        if (dMoveDistance > 10) //추후 가감속 때문에 최소 거리 구분시 사용 
        {
        }

        double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSpeed;
        if (dLimitSpeed < dSpeed)
          dSpeed = dLimitSpeed;
        if (dSpeed == 0)
          dSpeed = 0.1;
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], false);
        if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index[iloop], dPosition);
        }
        else
        {
          CAXM.AxmMotSetAbsRelMode(index[iloop], 0); //절대모드 = 0 , 상대모드 = 1
          CAXM.AxmMotSetProfileMode(index[iloop], 0); //대칭Trapezode = 0, 비대칭Trapezode = 1, 대칭 Quasi-S Curve = 2(PCI-N404/804는 지원안함.) , 대칭 S Curve = 3, 비대칭 S Curve = 4
          uint uState = CAXM.AxmMoveStartPos(index[iloop], dPosition, dSpeed, dAcc, dDcc);
          if (0 != uState) // 보드 명령에러
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
        }
        if (bErrCheck == true) // 멀티 구동중 명령에러로 인한 연동축 정지
        {
          for (int iloopin = 0; iloopin < index.Length; iloopin++)
          {
            Sub_Set_SvStop(index[iloopin]);
          }
          return false;
        }
      }
      // 모션 구동후 상태 체크 
      int[] iMoveComplete = new int[index.Length]; // 모션 완료 체크 
      bool[] bMoveWait = new bool[index.Length];     // 모션 구동완료 대기중 
      DateTime[] DateMoveComplete = new DateTime[index.Length]; // 모션 구동완료 시간 
      bool bWaitCheck = true;
      Thread.Sleep(100); // 초기 모션 구동후 상태값 읽기 전까지 쓰레드 딜레이 택에 영향이 없음 
      bErrCheck = false; // 구동중 에러상태 변경후 모터 급정지 

      while (bWaitCheck) // 구동 완료시 까지 무한루프 
      {
        Thread.Sleep(1);
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bAlarm) //모터 구동시 알람이 있으면 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrServoAlarm, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 정방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 역방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCcw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bEmgStop) //구동중 급정지 스위치
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrEmgStop, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }

          double dTimeOut = sGetData.dTimeOut;
          double dDiffTime = DateDiff(E_Interval.s, dateStartTime[iloop], DateTime.Now);
          if (dDiffTime > dTimeOut) // 구동 허가시간을 초과시 알람 
          {
            if ((CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) && // 지령 과 피드백을 체크 할떄 
               (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap))
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOutGap, (enumMotorName)index[iloop], true);
            else
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOut, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }

          if (bErrCheck)
          {
            for (int iloopin = 0; iloopin < index.Length; iloopin++)
            {
              Sub_Set_SvStop(index[iloopin]);
            }
            return false;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) // 지령 과 피드백을 체크 할떄 
          {
            if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap)
            {   // 지령 과 피드백에 오차가 허용범위를 벗어나서 리턴     
              continue;
            }
          }
          if (!CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bInPosition && !bMoveWait[iloop]) // 인포지션이 false 이면 구동완료 
          {
            bMoveWait[iloop] = true;
            DateMoveComplete[iloop] = DateTime.Now;
          }
          dDiffTime = DateDiff(E_Interval.s, DateMoveComplete[iloop], DateTime.Now);
          if (bMoveWait[iloop] && (dDiffTime > sGetData.dDelay) && (iMoveComplete[iloop] == 0)) //구동 완료후 설정된 딜레이를 범어서면 구동완료 
          {
            iMoveComplete[iloop] = 1;
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], true);
          }
        }
        int iCompleteCount = 0;
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          iCompleteCount += iMoveComplete[iloop];
        }
        if (iCompleteCount >= index.Length)
        { //전체 구동완료 
          bWaitCheck = false;
        }
      }

      return true;
    }


    public bool Sub_Set_MoveMuitilBorad(int[] index, int[] iPoint) //  연결된 보드일떄만 사용가능 이송 
    {
      DateTime[] dateStartTime = new DateTime[index.Length]; // 모션 시작 시간 
      double[] dPosition = new double[index.Length];
      double[] dSpeed = new double[index.Length];
      double[] dAcc = new double[index.Length];
      double[] dDcc = new double[index.Length];
      bool bErrCheck = false; // 구동중 에러상태 변경후 모터 급정지 

      structMData sGetData;
      for (int iloop = 0; iloop < index.Length; iloop++)
      {
        if (!Sub_Set_MoveCheck(index[iloop])) //구동전 상태 체크
          bErrCheck = true;
        double dPositionMax = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCw;
        double dPositionMin = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCcw;
        sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
        dPosition[iloop] = sGetData.dPosition;
        dSpeed[iloop] = sGetData.dSpeed;
        dAcc[iloop] = sGetData.dAcc;
        dDcc[iloop] = sGetData.dDcc;
        dateStartTime[iloop] = DateTime.Now;
        if (dPositionMax < dPosition[iloop]) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        if (dPositionMin > dPosition[iloop]) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCcw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        double dMoveDistance = Math.Abs(sGetData.dPosition - CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentPos); // 이동하려는 거리 
        if (dMoveDistance > 10) //추후 가감속 때문에 최소 거리 구분시 사용 
        {

        }
        double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSpeed;
        if (dLimitSpeed < dSpeed[iloop])
          dSpeed[iloop] = dLimitSpeed;
        if (dSpeed[iloop] == 0)
          dSpeed[iloop] = 0.1;
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], false);
        if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index[iloop], dPosition[iloop]);
        }
        else
        {
          CAXM.AxmMotSetAbsRelMode(index[iloop], 0); //절대모드 = 0 , 상대모드 = 1
          CAXM.AxmMotSetProfileMode(index[iloop], 0); //대칭Trapezode = 0, 비대칭Trapezode = 1, 대칭 Quasi-S Curve = 2(PCI-N404/804는 지원안함.) , 대칭 S Curve = 3, 비대칭 S Curve = 4
        }
      }
      if (CMotionVo.bAjinConnect == true) // 아진보드 연결시만 명령 
      {
        uint uState = CAXM.AxmMoveStartMultiPos(index.Length, index, dPosition, dSpeed, dAcc, dDcc);
        if (0 != uState) // 보드 명령에러
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index[0], true); // 멀티보드 명령에러시는 초기축만 에러로 변경
          bErrCheck = true;
        }
      }
      if (bErrCheck == true) // 멀티 구동중 명령에러로 인한 연동축 정지
      {
        for (int iloopin = 0; iloopin < index.Length; iloopin++)
        {
          Sub_Set_SvStop(index[iloopin]);
        }
        return false;
      }

      // 모션 구동후 상태 체크 
      int[] iMoveComplete = new int[index.Length]; // 모션 완료 체크 
      bool[] bMoveWait = new bool[index.Length];     // 모션 구동완료 대기중 
      DateTime[] DateMoveComplete = new DateTime[index.Length]; // 모션 구동완료 시간 
      bool bWaitCheck = true;
      Thread.Sleep(100); // 초기 모션 구동후 상태값 읽기 전까지 쓰레드 딜레이 택에 영향이 없음 
      bErrCheck = false;

      while (bWaitCheck) // 구동 완료시 까지 무한루프 
      {
        Thread.Sleep(1);
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bAlarm) //모터 구동시 알람이 있으면 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrServoAlarm, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 정방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 역방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCcw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bEmgStop) //구동중 급정지 스위치
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrEmgStop, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }

          double dTimeOut = sGetData.dTimeOut;
          double dDiffTime = DateDiff(E_Interval.s, dateStartTime[iloop], DateTime.Now);
          if (dDiffTime > dTimeOut) // 구동 허가시간을 초과시 알람 
          {
            if ((CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) && // 지령 과 피드백을 체크 할떄 
               (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap))
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOutGap, (enumMotorName)index[iloop], true);
            else
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOut, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (bErrCheck)
          {
            for (int iloopin = 0; iloopin < index.Length; iloopin++)
            {
              Sub_Set_SvStop(index[iloopin]);
            }
            return false;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) // 지령 과 피드백을 체크 할떄 
          {
            if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap)
            {   // 지령 과 피드백에 오차가 허용범위를 벗어나서 리턴     
              continue;
            }
          }
          if (!CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bInPosition && !bMoveWait[iloop]) // 인포지션이 false 이면 구동완료 
          {
            bMoveWait[iloop] = true;
            DateMoveComplete[iloop] = DateTime.Now;
          }
          dDiffTime = DateDiff(E_Interval.s, DateMoveComplete[iloop], DateTime.Now);
          if (bMoveWait[iloop] && (dDiffTime > sGetData.dDelay) && (iMoveComplete[iloop] == 0)) //구동 완료후 설정된 딜레이를 범어서면 구동완료 
          {
            iMoveComplete[iloop] = 1;
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], true);
          }
        }
        int iCompleteCount = 0;
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          iCompleteCount += iMoveComplete[iloop];
        }
        if (iCompleteCount >= index.Length)
        { //전체 구동완료 
          bWaitCheck = false;
        }
      }

      return true;
    }
    #endregion

    #region "이지 서보 관련 함수"
    public bool Sub_Get_Motion_EzServo(int index) // 모션 상태 읽어오기  
    {
      structMotorStatus sMotorStatus = new structMotorStatus();        // 내부 모션 반영 구조체 
      sMotorStatus = CMotionVo.GetMotorStatus((enumMotorName)index);    // 설정된 내부 상태를 반영 



      CMotionVo.SetMotorStatus(sMotorStatus, (enumMotorName)index);    // 변경된 상태를 내부에 적용 
      return false;
    }
    #endregion

    #region "PLC 관련 함수"
    public bool Sub_Get_Motion_PLC(int index)  // 모션 상태 읽어오기  
    {
      structMotorStatus sMotorStatus = new structMotorStatus();        // 내부 모션 반영 구조체 
      sMotorStatus = CMotionVo.GetMotorStatus((enumMotorName)index);    // 설정된 내부 상태를 반영 

      sMotorStatus.dCurrentPos = CIoVo.Get_RW_CurPos(enumWR_CurPos.W1560_LE_Cur_Pos);
      //?????

      CMotionVo.SetMotorStatus(sMotorStatus, (enumMotorName)index);    // 변경된 상태를 내부에 적용 
      return false;
    }

    public bool Sub_Set_MoveMuitil_PLC(int[] index, int[] iPoint) //  이송 
    {
      bool bErrCheck = false; // 구동중 에러상태 변경후 모터 급정지 
      DateTime[] dateStartTime = new DateTime[index.Length]; // 모션 시작 시간 

      structMData sGetData;
      for (int iloop = 0; iloop < index.Length; iloop++)
      {
        if (Sub_Set_MoveCheck(index[iloop]) == false) //구동전 상태 체크
          bErrCheck = true;
        double dPositionMax = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCw;
        double dPositionMin = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSoftCcw;
        sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
        double dPosition = sGetData.dPosition;
        double dSpeed = sGetData.dSpeed;
        double dAcc = sGetData.dAcc;
        double dDcc = sGetData.dDcc;
        dateStartTime[iloop] = DateTime.Now;
        if (dPositionMax < dPosition) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        if (dPositionMin > dPosition) // 이동 거리가 리미트를 벗어남 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitSwCcw, (enumMotorName)index[iloop], true);
          bErrCheck = true;
        }
        double dMoveDistance = Math.Abs(sGetData.dPosition - CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentPos); // 이동하려는 거리 
        if (dMoveDistance > 10) //추후 가감속 때문에 최소 거리 구분시 사용 
        {
        }

        double dLimitSpeed = CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitSpeed;
        if (dLimitSpeed < dSpeed)
          dSpeed = dLimitSpeed;
        if (dSpeed == 0)
          dSpeed = 0.1;
        CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], false);
        if (CMotionVo.bAjinConnect == false) //가상모드이면 현재 지령으로 엔코더를 변경 
        {
          CMotionVo.SetMotorStatus(enumSetMotorStatus.dCurrentPos, (enumMotorName)index[iloop], dPosition);
        }
        else
        {
          CAXM.AxmMotSetAbsRelMode(index[iloop], 0); //절대모드 = 0 , 상대모드 = 1
          CAXM.AxmMotSetProfileMode(index[iloop], 0); //대칭Trapezode = 0, 비대칭Trapezode = 1, 대칭 Quasi-S Curve = 2(PCI-N404/804는 지원안함.) , 대칭 S Curve = 3, 비대칭 S Curve = 4
          uint uState = CAXM.AxmMoveStartPos(index[iloop], dPosition, dSpeed, dAcc, dDcc);
          if (0 != uState) // 보드 명령에러
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrBorad, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
        }
        if (bErrCheck == true) // 멀티 구동중 명령에러로 인한 연동축 정지
        {
          for (int iloopin = 0; iloopin < index.Length; iloopin++)
          {
            Sub_Set_SvStop(index[iloopin]);
          }
          return false;
        }
      }
      // 모션 구동후 상태 체크 
      int[] iMoveComplete = new int[index.Length]; // 모션 완료 체크 
      bool[] bMoveWait = new bool[index.Length];     // 모션 구동완료 대기중 
      DateTime[] DateMoveComplete = new DateTime[index.Length]; // 모션 구동완료 시간 
      bool bWaitCheck = true;
      Thread.Sleep(100); // 초기 모션 구동후 상태값 읽기 전까지 쓰레드 딜레이 택에 영향이 없음 
      bErrCheck = false; // 구동중 에러상태 변경후 모터 급정지 

      while (bWaitCheck) // 구동 완료시 까지 무한루프 
      {
        Thread.Sleep(1);
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          sGetData = CMotionVo.GetMotorData((enumMotorName)index[iloop], iPoint[iloop]); // 설정된 위치 데이터 가져오기 
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bAlarm) //모터 구동시 알람이 있으면 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrServoAlarm, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 정방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bSensorCw) //모터 구동시 역방향센서 입력시 에러 발생 
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrLimitCcw, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bEmgStop) //구동중 급정지 스위치
          {
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrEmgStop, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }

          double dTimeOut = sGetData.dTimeOut;
          double dDiffTime = DateDiff(E_Interval.s, dateStartTime[iloop], DateTime.Now);
          if (dDiffTime > dTimeOut) // 구동 허가시간을 초과시 알람 
          {
            if ((CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) && // 지령 과 피드백을 체크 할떄 
               (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap))
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOutGap, (enumMotorName)index[iloop], true);
            else
              CMotionVo.SetMotorStatus(enumSetMotorStatus.bErrTimeOut, (enumMotorName)index[iloop], true);
            bErrCheck = true;
          }

          if (bErrCheck)
          {
            for (int iloopin = 0; iloopin < index.Length; iloopin++)
            {
              Sub_Set_SvStop(index[iloopin]);
            }
            return false;
          }
          if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap > 0) // 지령 과 피드백을 체크 할떄 
          {
            if (CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dCurrentGap > CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).dLimitGap)
            {   // 지령 과 피드백에 오차가 허용범위를 벗어나서 리턴     
              continue;
            }
          }
          if (!CMotionVo.GetMotorStatus((enumMotorName)index[iloop]).bInPosition && !bMoveWait[iloop]) // 인포지션이 false 이면 구동완료 
          {
            bMoveWait[iloop] = true;
            DateMoveComplete[iloop] = DateTime.Now;
          }
          dDiffTime = DateDiff(E_Interval.s, DateMoveComplete[iloop], DateTime.Now);
          if (bMoveWait[iloop] && (dDiffTime > sGetData.dDelay) && (iMoveComplete[iloop] == 0)) //구동 완료후 설정된 딜레이를 범어서면 구동완료 
          {
            iMoveComplete[iloop] = 1;
            CMotionVo.SetMotorStatus(enumSetMotorStatus.bMoveComplete, (enumMotorName)index[iloop], true);
          }
        }
        int iCompleteCount = 0;
        for (int iloop = 0; iloop < index.Length; iloop++)
        {
          iCompleteCount += iMoveComplete[iloop];
        }
        if (iCompleteCount >= index.Length)
        { //전체 구동완료 
          bWaitCheck = false;
        }
      }

      return true;
    }
    #endregion


    public enum E_Interval
    {
      y = 0,
      m = 1,
      d = 2,
      h = 3,
      n = 4,
      s = 5,
      ms = 6
    }
    public double DateDiff(E_Interval Interval, DateTime Date1, DateTime Date2) // 두시간의 차이를 입력 조건 Interval형식으로 반환한다.
    {

      double diff = 0;
      TimeSpan ts = Date2 - Date1;

      switch (Interval)
      {

        case E_Interval.y:

          ts = DateTime.Parse(Date2.ToString("yyyy-01-01")) - DateTime.Parse(Date1.ToString("yyyy-01-01"));
          diff = Convert.ToDouble(ts.TotalDays / 365);
          break;

        case E_Interval.m:

          ts = DateTime.Parse(Date2.ToString("yyyy-MM-01")) - DateTime.Parse(Date1.ToString("yyyy-MM-01"));
          diff = Convert.ToDouble((ts.TotalDays / 365) * 12);
          break;

        case E_Interval.d:

          ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd"));
          diff = ts.Days;
          break;

        case E_Interval.h:

          ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:00:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:00:00"));
          diff = ts.TotalHours;
          break;

        case E_Interval.n:

          ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:00"));
          diff = ts.TotalMinutes;
          break;

        case E_Interval.s:

          ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:ss"));
          diff = ts.TotalSeconds;
          break;

        case E_Interval.ms:

          diff = Math.Round(ts.TotalMilliseconds, 2);
          break;

      }
      return diff;
    }

  }
}
