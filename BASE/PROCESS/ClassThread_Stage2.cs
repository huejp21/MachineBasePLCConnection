using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MASTER;
using BASE.MODULE.MOTION;
using BASE.FORM;

namespace BASE.PROCESS
{
  public class ClassThread_Stage2
  {
    private static ClassThread_Stage2 cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_Stage2()
    {
      Check_Thread();
    }

    public static ClassThread_Stage2 Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_Stage2();
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
        th = new Thread(Run);
        th.Start();
      }
    }

    public void Abort_Thread()
    {
      th.Abort();
      bThread = false;
      th = null;
    } // Kill All Thread

    private void Run()
    {
      while (bThread)
      {
        lock (this)
        {
          Thread.Sleep(50);
          ClassSystemPara cSys = CVo.cParaSys.GetValues();
          ClassRecipePara cRcp = CVo.cParaRcp.GetValues();

          //////////////////////////
          // Stage2_Measure 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage2_Measure))
          {
            // 외부 입력 확인
            if (CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Measure);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Measure);
              continue;
            }
            bool bAutoStart = (CVo.eMachineStatus == enumMachineStatus.Auto);
            CVo.bStage2_Measuring = true;
            CVo.CycleStatus_Moving(enumCycleStatus.Stage2_Measure);
            // 측정
            bool bError = false;

            // Cycle 동작시 인덱스 꼬임을 방지하기 위해 맨 마지막 인덱스를 이용하여 연산한다.
            int iCycleIndex = 9999;
            int iPCBIndex = (CVo.eMachineStatus == enumMachineStatus.Cycle) ? iCycleIndex : CVo.iPCBIndex_Stage2;
            CVo.sPCBData[iPCBIndex].StageNumber = 1; // 스테이지 번호


            if (CVo.sPCBData[iPCBIndex].BCR_OK == false && bAutoStart)
            {
              switch ((enumRejectZone)cRcp.iRejectZone)
              {
                case enumRejectZone.A: CVo.sPCBData[iPCBIndex].Result = enumPCBResult.A; break;
                case enumRejectZone.B: CVo.sPCBData[iPCBIndex].Result = enumPCBResult.B; break;
                case enumRejectZone.C: CVo.sPCBData[iPCBIndex].Result = enumPCBResult.C; break;
                case enumRejectZone.D:
                default: CVo.sPCBData[iPCBIndex].Result = enumPCBResult.D; break;
              }
              CVo.CycleStatus_Complete(enumCycleStatus.Stage2_Measure);
              CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
              CVo.bStage2_Measuring = false;
              CVo.bWaitStage2_to_UP = true;
              continue;
            }


            // 결과 NG로 초기화 한다.
            enumUEUseMode eUEMode = (enumUEUseMode)cRcp.iUEMode;
            switch (eUEMode)
            {
              case enumUEUseMode.USE_1:
                CVo.sPCBData[iPCBIndex].Result = enumPCBResult.A;
                break;
              case enumUEUseMode.USE_2:
                CVo.sPCBData[iPCBIndex].Result = enumPCBResult.B;
                break;
              case enumUEUseMode.USE_3:
                CVo.sPCBData[iPCBIndex].Result = enumPCBResult.C;
                break;
              case enumUEUseMode.USE_4:
              default:
                CVo.sPCBData[iPCBIndex].Result = enumPCBResult.D;
                break;
            }
            CVo.sPCBData[iPCBIndex].PointIndex.Clear(); // 포인트 인덱스 초기화 하고 시작
            CVo.sPCBData[iPCBIndex].MeasurePointValue.Clear(); // 측정값 저장할 버퍼도 클리어 하고 시작

            if (bAutoStart)
            {
              if (0 < cSys.iAfterStageCleanCount)
              {
                if (CMaster.cMotion.cAction.Stage2_Clean(cSys.iAfterStageCleanCount, 0) == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.bStage2_Measuring = false;
                  CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                  bError = true;
                  continue;
                }
              }
            }

            for (int i = 0; i < CVo.iPointMax; i++)
            {
              // 측정 값 저장 인덱스
              int iPointIndex1 = (i * 2);
              int iPointIndex2 = (i * 2) + 1;

              // 측정 루프 시작
              if (cSys.bUsePB3 && cSys.bUsePB4 && cRcp.abUsePointX[i])
              {
                // 프로브 둘다 사용하는 경우 
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY1[i] : cSys.dPR3_Center_Pos;
                double dPB4 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY2[i] : cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Measure(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.bStage2_Measuring = false;
                  CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                  bError = true;
                  break;
                }

                List<double> list1 = new List<double>();
                List<double> list2 = new List<double>();
                list1.Clear();
                list2.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                { 
                  if (cRcp.abUsePointY_Two[i])
                  {
                    list1.Add(CMaster.cProbe2.GetData(1));
                  }
                  list2.Add(CMaster.cProbe2.GetData(2));
                }
                if (cRcp.abUsePointY_Two[i])
                {
                  double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex1] = dValue1;
                  CVo.sPCBData[iPCBIndex].X_Index[iPointIndex1] = i;
                  CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex1] = enumPoint.Y1;
                  CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex1] = enumProbe.PR3;
                  CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex1);
                  //CVo.Save_DLMTest(list1, dValue1, CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex1]);
                }
                double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex2] = dValue2;
                CVo.sPCBData[iPCBIndex].X_Index[iPointIndex2] = i;
                CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex2] = cRcp.abUsePointY_Two[i] ? enumPoint.Y2 : enumPoint.Y1;
                CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex2] = enumProbe.PR4;
                CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex2);
                //CVo.Save_DLMTest(list2, dValue2, CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex2]);
              }
              else if (cSys.bUsePB3 && cSys.bUsePB4 == false && cRcp.abUsePointX[i])
              {
                // 프로브 1번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cRcp.adPointY1[i];
                double dPB4 = -cSys.dPR4_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Measure(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.bStage2_Measuring = false;
                  CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                  bError = true;
                  break;
                }
                List<double> list1 = new List<double>();
                list1.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                {
                  list1.Add(CMaster.cProbe2.GetData(1));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);

                CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex1] = dValue1;
                CVo.sPCBData[iPCBIndex].X_Index[iPointIndex1] = i;
                CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex1] = enumPoint.Y1;
                CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex1] = enumProbe.PR3;
                CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex1);

                if (cRcp.abUsePointY_Two[i])
                {
                  // 두번째 포인트 설정되어 있는 경우에
                  dX1 = cRcp.adPointX[i];
                  dPB3 = cRcp.adPointY2[i];
                  dPB4 = -cSys.dPR4_Center_Pos;
                  bCycleResult = CMaster.cMotion.cAction.Stage2_Measure(dX1, dPB3, dPB4);
                  if (bCycleResult == false)
                  {
                    // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                    CVo.bStage2_Measuring = false;
                    CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                    bError = true;
                    break;
                  }
                  List<double> list2 = new List<double>();
                  list2.Clear();

                  for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                  {
                    list2.Add(CMaster.cProbe2.GetData(1));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex2] = dValue2;
                  CVo.sPCBData[iPCBIndex].X_Index[iPointIndex2] = i;
                  CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex2] = enumProbe.PR3;
                  CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex2] = enumPoint.Y2;
                  CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex2);
                }
              }
              else if (cSys.bUsePB3 == false && cSys.bUsePB4 && cRcp.abUsePointX[i])
              {
                // 프로브 2번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cSys.dPR3_Center_Pos;
                double dPB4 = cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Measure(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  CVo.bStage2_Measuring = false;
                  CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                  bError = true;
                  break;
                }
                List<double> list1 = new List<double>();
                list1.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                {
                  list1.Add(CMaster.cProbe2.GetData(2));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex1] = dValue1;
                CVo.sPCBData[iPCBIndex].X_Index[iPointIndex1] = i;
                CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex1] = enumPoint.Y1;
                CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex1] = enumProbe.PR4;
                CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex1);

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB3 = cSys.dPR3_Center_Pos;
                  dPB4 = cRcp.adPointY2[i];

                  bCycleResult = CMaster.cMotion.cAction.Stage2_Measure(dX1, dPB3, dPB4);
                  if (bCycleResult == false)
                  {
                    // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                    CVo.bStage2_Measuring = false;
                    CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                    bError = true;
                    break;
                  }
                  List<double> list2 = new List<double>();
                  list2.Clear();
                  for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                  {
                    list2.Add(CMaster.cProbe2.GetData(2));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);

                  CVo.sPCBData[iPCBIndex].OriginValue[iPointIndex2] = dValue2;
                  CVo.sPCBData[iPCBIndex].X_Index[iPointIndex2] = i;
                  CVo.sPCBData[iPCBIndex].PointInfo[iPointIndex2] = enumPoint.Y2;
                  CVo.sPCBData[iPCBIndex].ProbeInfo[iPointIndex2] = enumProbe.PR4;
                  CVo.sPCBData[iPCBIndex].PointIndex.Add(iPointIndex2);
                }
              }
            } // 측정 루프 끝
            if (bError)
            {
              CVo.bStage2_Measuring = false;
              continue;
            }

            // 판정
            CVo.sPCBData[iPCBIndex].Result = CMaster.cDataMgr.Get_Result(iPCBIndex);

            // Cycle 이면 바코드 부분에 Cycle 동작이라고 써준다.
            if (bAutoStart == false)
            {
              CVo.sPCBData[iPCBIndex].BCR = "Cycle";
              CVo.Save_MeasureData(iPCBIndex);
              CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
            }

            // 측정 작업 이후에 Z축을 내린다.
            structMotorStatus sMotor = CMotionVo.GetMotorStatus(enumMotorName.Z2);
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Ready_Pos * sMotor.dLimitScale));
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor.dLimitScale));
            CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
            CIoVo.Set_Address_Bit("B210B", false);
            Thread.Sleep(200);
            bError = false;
            for (int i = 0; i < 2000; i++)
            {
              Thread.Sleep(1);
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running))
              {
                break;
              }
            }
            while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210B_Z2_Teaching_Complete) == false)
            {
              System.Threading.Thread.Sleep(1);
              if (CVo.Check_MachineStatus() == false)
              {
                CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                bError = true;
                break;
              }
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running) == false
                && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210B_Z2_Teaching_Complete) == false)
              {
                CVo.CycleStatus_Error(enumCycleStatus.Stage2_Measure);
                bError = true;
                break;
              }
            }
            //if (bError)
            //{
            //  CVo.bStage2_Measuring = false;
            //  continue;
            //}

            CVo.CycleStatus_Complete(enumCycleStatus.Stage2_Measure);
            CVo.iStage2_ZeroSetCount++;

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              // 결과에 따라 다음동작으로 넘기거나 프로브 청소작업을 하고 재측정 한다.
              switch (eUEMode)
              {
                case enumUEUseMode.USE_1:
                  CVo.Save_MeasureData(iPCBIndex);
                  CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                  CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                  CVo.bStage2_Measuring = false;
                  CVo.bWaitStage2_to_UP = true;
                  if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                  {
                    CVo.bWaitStage2ZeroSet = true;
                  }
                  break;
                case enumUEUseMode.USE_2:
                  if (CVo.sPCBData[iPCBIndex].Result >= enumPCBResult.B)
                  {
                    if (cSys.iReMeasureCount <= CVo.iStage2_Cur_ReMeasure_Count)
                    {
                      CVo.Save_MeasureData(iPCBIndex);
                      CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                      CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                      CVo.bStage2_Measuring = false;
                      CVo.bWaitStage2_to_UP = true;
                      if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                      {
                        CVo.bWaitStage2ZeroSet = true;
                      }
                    }
                    else
                    {
                      CVo.iStage2_Cur_ReMeasure_Count++;
                      CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Probe_Clean;
                      CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bCycleStart = true;
                    }
                  }
                  else
                  {
                    CVo.Save_MeasureData(iPCBIndex);
                    CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                    CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                    CVo.bStage2_Measuring = false;
                    CVo.bWaitStage2_to_UP = true;
                    if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                    {
                      CVo.bWaitStage2ZeroSet = true;
                    }
                  }
                  break;
                case enumUEUseMode.USE_3:
                  if (CVo.sPCBData[iPCBIndex].Result >= enumPCBResult.C)
                  {
                    if (cSys.iReMeasureCount <= CVo.iStage2_Cur_ReMeasure_Count)
                    {
                      CVo.Save_MeasureData(iPCBIndex);
                      CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                      CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                      CVo.bStage2_Measuring = false;
                      CVo.bWaitStage2_to_UP = true;
                      if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                      {
                        CVo.bWaitStage2ZeroSet = true;
                      }
                    }
                    else
                    {
                      CVo.iStage2_Cur_ReMeasure_Count++;
                      CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Probe_Clean;
                      CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bCycleStart = true;
                    }
                  }
                  else
                  {
                    CVo.Save_MeasureData(iPCBIndex);
                    CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                    CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                    CVo.bStage2_Measuring = false;
                    CVo.bWaitStage2_to_UP = true;
                    if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                    {
                      CVo.bWaitStage2ZeroSet = true;
                    }
                  }
                  break;
                case enumUEUseMode.USE_4:
                default:
                  if (CVo.sPCBData[iPCBIndex].Result >= enumPCBResult.D)
                  {
                    if (cSys.iReMeasureCount <= CVo.iStage2_Cur_ReMeasure_Count)
                    {
                      CVo.Save_MeasureData(iPCBIndex);
                      CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                      CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                      CVo.bStage2_Measuring = false;
                      CVo.bWaitStage2_to_UP = true;
                      if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                      {
                        CVo.bWaitStage2ZeroSet = true;
                      }
                    }
                    else
                    {
                      CVo.iStage2_Cur_ReMeasure_Count++;
                      CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Probe_Clean;
                      CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Probe_Clean].bCycleStart = true;
                    }
                  }
                  else
                  {
                    CVo.Save_MeasureData(iPCBIndex);
                    CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iPCBIndex]);
                    CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
                    CVo.bStage2_Measuring = false;
                    CVo.bWaitStage2_to_UP = true;
                    if (CVo.iStage2_ZeroSetCount >= cSys.iZerosetPeriod)
                    {
                      CVo.bWaitStage2ZeroSet = true;
                    }
                  }
                  break;
              }
            }
            else
            {
              // Auto 아니고 다른 상태일때
              CVo.bStage2_Measuring = false;
            }
          }

          //////////////////////////
          // Stage2_ZeroSet 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage2_Zero))
          {
            // 외부 입력 확인
            if (CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Zero);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Zero);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Stage2_Zero);
            CVo.Reset_ZeroSetData(1); // 제로셋 테이터 초기화
            // 측정
            bool bError = false;
            for (int i = 0; i < CVo.iPointMax; i++)
            {
              // 측정 값 저장 인덱스
              int iPointIndex1 = (i * 2);
              int iPointIndex2 = (i * 2) + 1;

              // 측정 루프 시작
              if (cSys.bUsePB3 && cSys.bUsePB4 && cRcp.abUsePointX[i])
              {
                // 프로브 둘다 사용하는 경우 
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY1[i] : cSys.dPR3_Center_Pos;
                double dPB4 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY2[i] : cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Zero(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  bError = true;
                  break;
                }
                List<double> list1 = new List<double>();
                List<double> list2 = new List<double>();
                list1.Clear();
                list2.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                {
                  if (cRcp.abUsePointY_Two[i])
                  {
                    list1.Add(CMaster.cProbe2.GetData(1));
                  }
                  list2.Add(CMaster.cProbe2.GetData(2));
                }
                if (cRcp.abUsePointY_Two[i])
                {
                  double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  CVo.asZeroData_Stage2[iPointIndex1].Value = dValue1;
                  CVo.asZeroData_Stage2[iPointIndex1].X = i;
                  CVo.asZeroData_Stage2[iPointIndex1].PointType = enumPoint.Y1;
                  CVo.asZeroData_Stage2[iPointIndex1].ProbeType = enumProbe.PR3;
                }
                double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                CVo.asZeroData_Stage2[iPointIndex2].Value = dValue2;
                CVo.asZeroData_Stage2[iPointIndex2].X = i;
                CVo.asZeroData_Stage2[iPointIndex2].PointType = cRcp.abUsePointY_Two[i] ? enumPoint.Y2 : enumPoint.Y1;
                CVo.asZeroData_Stage2[iPointIndex2].ProbeType = enumProbe.PR4;
              }
              else if (cSys.bUsePB3 && cSys.bUsePB4 == false && cRcp.abUsePointX[i])
              {
                // 프로브 1번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cRcp.adPointY1[i];
                double dPB4 = -cSys.dPR4_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Zero(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  bError = true;
                  break;
                }
                List<double> list1 = new List<double>();
                list1.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                {
                  list1.Add(CMaster.cProbe2.GetData(1));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                CVo.asZeroData_Stage2[iPointIndex1].Value = dValue1;
                CVo.asZeroData_Stage2[iPointIndex1].X = i;
                CVo.asZeroData_Stage2[iPointIndex1].PointType = enumPoint.Y1;
                CVo.asZeroData_Stage2[iPointIndex1].ProbeType = enumProbe.PR3;

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB3 = cRcp.adPointY2[i];
                  dPB4 = -cSys.dPR4_Center_Pos;

                  bCycleResult = CMaster.cMotion.cAction.Stage2_Zero(dX1, dPB3, dPB4);
                  if (bCycleResult == false)
                  {
                    // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                    bError = true;
                    break;
                  }
                  List<double> list2 = new List<double>();
                  list2.Clear();
                  for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                  {
                    list2.Add(CMaster.cProbe2.GetData(1));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  CVo.asZeroData_Stage2[iPointIndex2].Value = dValue2;
                  CVo.asZeroData_Stage2[iPointIndex2].X = i;
                  CVo.asZeroData_Stage2[iPointIndex2].PointType = enumPoint.Y2;
                  CVo.asZeroData_Stage2[iPointIndex2].ProbeType = enumProbe.PR3;
                }
              }
              else if (cSys.bUsePB3 == false && cSys.bUsePB4 && cRcp.abUsePointX[i])
              {
                // 프로브 2번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB3 = cSys.dPR3_Center_Pos;
                double dPB4 = cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage2_Zero(dX1, dPB3, dPB4);
                if (bCycleResult == false)
                {
                  // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                  bError = true;
                  break;
                }
                List<double> list1 = new List<double>();
                list1.Clear();
                for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                {
                  list1.Add(CMaster.cProbe2.GetData(2));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                CVo.asZeroData_Stage2[iPointIndex1].Value = dValue1;
                CVo.asZeroData_Stage2[iPointIndex1].X = i;
                CVo.asZeroData_Stage2[iPointIndex1].PointType = enumPoint.Y1;
                CVo.asZeroData_Stage2[iPointIndex1].ProbeType = enumProbe.PR4;

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB3 = cSys.dPR1_Center_Pos;
                  dPB4 = cRcp.adPointY2[i];
                  bCycleResult = CMaster.cMotion.cAction.Stage2_Zero(dX1, dPB3, dPB4);
                  if (bCycleResult == false)
                  {
                    // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
                    bError = true;
                    break;
                  }
                  List<double> list2 = new List<double>();
                  list2.Clear();
                  for (int j = 0; j < cSys.iProbeValueAverageCount; j++)
                  {
                    list2.Add(CMaster.cProbe2.GetData(2));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  CVo.asZeroData_Stage2[iPointIndex2].Value = dValue2;
                  CVo.asZeroData_Stage2[iPointIndex2].X = i;
                  CVo.asZeroData_Stage2[iPointIndex2].PointType = enumPoint.Y2;
                  CVo.asZeroData_Stage2[iPointIndex2].ProbeType = enumProbe.PR4;
                }
              }
            } // 측정 루프 끝
            if (bError)
            {
              CVo.CycleStatus_Error(enumCycleStatus.Stage2_Zero);
              continue;
            }
            CVo.bZeroSetStatus_Stage2 = true; // 제로셋 저장됨 비트 온
            CVo.iStage2_ZeroSetCount = 0;

            structMotorStatus sMotor = CMotionVo.GetMotorStatus(enumMotorName.Z2);
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102E_Z2_Teaching_Pos, (int)(cSys.dZ2_Ready_Pos * sMotor.dLimitScale));
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102C_Z2_Teaching_Spd, (int)(cSys.dZ2_Normal_Spd * sMotor.dLimitScale));
            CIoVo.Set_WB_OutFlag(enumFlagOut.B102B_Z2_Teaching_Start, true);
            CIoVo.Set_Address_Bit("B210B", false);
            bError = false;
            Thread.Sleep(200);
            for (int i = 0; i < 2000; i++)
            {
              Thread.Sleep(1);
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running))
              {
                break;
              }
            }
            while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210B_Z2_Teaching_Complete) == false)
            {
              System.Threading.Thread.Sleep(1);
              if (CVo.Check_MachineStatus() == false)
              {
                CVo.CycleStatus_Error(enumCycleStatus.Stage2_Zero);
                bError = true;
                break;
              }
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running) == false
                && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210B_Z2_Teaching_Complete) == false)
              {
                CVo.CycleStatus_Error(enumCycleStatus.Stage2_Zero);
                bError = true;
                break;
              }
            }
            //if (bError)
            //{
            //  continue;
            //}

            CVo.CycleStatus_Complete(enumCycleStatus.Stage2_Zero);
            CVo.bWaitStage2ZeroSet = false;
            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.eNextSeq_Stage2 == enumCycleStatus.Stage2_Zero)
              {
                CVo.eNextSeq_Stage2 = enumCycleStatus.NONE;
              }
            }
          }

          //////////////////////////
          // Stage2_Probe_Clean 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage2_Probe_Clean))
          {
            // 외부 입력 확인
            if (CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Probe_Clean);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Probe_Clean);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Stage2_Probe_Clean);
            bool bCycleResult = CMaster.cMotion.cAction.Stage2_Clean(cSys.iProbeCleanCount, 1);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.Stage2_Probe_Clean);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.Stage2_Probe_Clean);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {
              if (CVo.bStage2_Measuring)
              {
                CVo.bStage2_Measuring = false;
                CVo.eNextSeq_Stage2 = enumCycleStatus.Stage2_Measure;
                CVo.sCycleStatus[(int)enumCycleStatus.Stage2_Measure].bCycleStart = true;
              }
            }
          }

          //////////////////////////
          // Stage2_Stage_Clean 동작
          //////////////////////////
          if (CVo.Check_CycleStart(enumCycleStatus.Stage2_Clean))
          {
            // 외부 입력 확인
            if (CVo.bRunningStage2 == false)
            {
              // 현재 동작중이 아니면 상태 초기화
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Clean);
            }
            else
            {
              // 동작중 이면 빠져나감
              continue;
            }
            // 오토나 싸이클이 아니면 빠져나감
            if (CVo.Check_MachineStatus() == false)
            {
              CVo.CycleStatus_Reset(enumCycleStatus.Stage2_Clean);
              continue;
            }
            CVo.CycleStatus_Moving(enumCycleStatus.Stage2_Clean);
            bool bCycleResult = CMaster.cMotion.cAction.Stage2_Clean(cSys.iStageCleanCount, 0);
            if (bCycleResult == false)
            {
              // 동작 에러면 빠져나감 에러처리는 에러 모니터 스레드에서 처리
              CVo.CycleStatus_Error(enumCycleStatus.Stage2_Clean);
              continue;
            }
            CVo.CycleStatus_Complete(enumCycleStatus.Stage2_Clean);

            if (CVo.eMachineStatus == enumMachineStatus.Auto)
            {

            }
          }


        }
      }
    }
  }
}
