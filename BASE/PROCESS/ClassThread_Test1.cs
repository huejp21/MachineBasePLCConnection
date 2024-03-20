using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using BASE.VO;
using BASE.MASTER;
using BASE.MODULE.MOTION;

namespace BASE.PROCESS
{
  public class ClassThread_Test1
  {
    private static ClassThread_Test1 cInstatnce;
    private static object syncLock = new object();

    private static System.Threading.Thread th = null;
    private static bool bThread = true;

    protected ClassThread_Test1()
    {
      Check_Thread();
    }

    public static ClassThread_Test1 Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassThread_Test1();
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
          System.Threading.Thread.Sleep(50);
          ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
          ClassSystemPara cSys = CVo.cParaSys.GetValues();

          bool bStage1Running
            = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208A_Z1_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208E_X1_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2090_PR1_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2091_PR2_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209D_Measure_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AE_X1_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B0_PR1_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B1_PR2_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CE_LP_to_Stage1_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D0_Stage1_Zero_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D2_Stage1_Measure_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D4_Stage1_to_UP_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D7_Stage1_Clean_Running);

          bool bStage2Running
            = CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208B_Z2_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B208F_X2_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2092_PR3_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B2093_PR4_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209D_Measure_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B209F_All_Homming)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AB_Z2_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AF_X2_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B2_PR3_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20B3_PR4_Teaching_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20CF_LP_to_Stage2_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D1_Stage2_Zero_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D3_Stage2_Measure_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D5_Stage2_to_UP_Running)
           || CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20D8_Stage2_Clean_Running);

          bool bErrorAll = false;
          for (int i = 0; i < Enum.GetNames(typeof(enumError)).Length; i++)
          {
            if (CIoVo.Get_RB_Error((enumError)i))
            {
              bErrorAll = true;
              break;
            }
          }

          if (CVo.bTestMeasure1)
          {
            // 테스트 측정
            if (bStage1Running)
            {
              continue;
            }
            if (bErrorAll)
            {
              continue;
            }
            if (cSys.bUsePB1 == false && cSys.bUsePB2 == false)
            {
              continue;
            }
            structPCBData sData = new structPCBData();

            //  텍타임 데이터 초기화
            sData.Total_StartTime = System.DateTime.Now;
            sData.Total_EndTime = System.DateTime.Now;
            sData.LE_StartTime = System.DateTime.Now;
            sData.LE_EndTime = System.DateTime.Now;
            sData.Barcode_StartTime = System.DateTime.Now;
            sData.Barcode_EndTime = System.DateTime.Now;
            sData.LEtoLP_StartTime = System.DateTime.Now;
            sData.LEtoLP_EndTime = System.DateTime.Now;
            sData.LPtoAL_StartTime = System.DateTime.Now;
            sData.LPtoAL_EndTime = System.DateTime.Now;
            sData.AL_StartTime = System.DateTime.Now;
            sData.AL_EndTime = System.DateTime.Now;
            sData.ALtoLP_StartTime = System.DateTime.Now;
            sData.ALtoLP_EndTime = System.DateTime.Now;
            sData.LPtoStage_StartTime = System.DateTime.Now;
            sData.LPtoStage_EndTime = System.DateTime.Now;
            sData.Measure_StartTime = System.DateTime.Now;
            sData.Measure_EndTime = System.DateTime.Now;
            sData.Zeroset_StartTime = System.DateTime.Now;
            sData.Zeroset_EndTime = System.DateTime.Now;
            sData.ProbeClean_StartTime = System.DateTime.Now;
            sData.ProbeClean_EndTime = System.DateTime.Now;
            sData.StagetoUP_StartTime = System.DateTime.Now;
            sData.StagetoUP_EndTime = System.DateTime.Now;
            sData.UPtoUE_StartTime = System.DateTime.Now;
            sData.UPtoUE_EndTime = System.DateTime.Now;

            //  결과 데이터 초기화
            sData.PerfectlyOut = false; // 생산완료가 된 제품인지 확인하는 비트
            sData.BCR = ""; // 바코드 정보
            sData.MeasurePointValue = new List<double>(); ; // 측정이 된 값만 순차 적으로 저장할 버퍼
            sData.MeasurePointValue.Clear(); // 측정이 된 값만 순차 적으로 저장할 버퍼
            sData.PointIndex = new List<int>(); // 포인트 인덱스 저장 버퍼
            sData.PointIndex.Clear(); // 포인트 인덱스 저장 버퍼
            sData.Result = enumPCBResult.NONE; // 최종 결과 정보
            sData.StageNumber = -1; // 생산된 스테이지 번호
            sData.ProbeInfo = new enumProbe[CVo.iPointMax * 2]; // 각 포인트 측정한 프로브 정보
            sData.X_Index = new int[CVo.iPointMax * 2]; // X 인덱스 정보
            sData.PointInfo = new enumPoint[CVo.iPointMax * 2]; // 각 포인트 정보
            sData.PointResult = new enumPCBResult[CVo.iPointMax * 2]; // 각 포인트 결과 정보
            sData.MeasureValue = new double[CVo.iPointMax * 2]; // 측정 포인트 값
            sData.OriginValue = new double[CVo.iPointMax * 2]; // 측정 포인트 프로브 절대값
            sData.PointOffset = new double[CVo.iPointMax * 2]; // 측정 포인트 옵셋
            sData.ZeroValue = new double[CVo.iPointMax * 2]; // 측정 포인트에 저장된 제로값
            for (int j = 0; j < CVo.iPointMax * 2; j++)
            {
              sData.ProbeInfo[j] = enumProbe.NONE; // 각 포인트 측정한 프로브 정보
              sData.X_Index[j] = -1; // X 인덱스 정보
              sData.PointInfo[j] = enumPoint.NONE; // 각 포인트 정보
              sData.PointResult[j] = enumPCBResult.NONE; // 각 포인트 결과 정보
              sData.MeasureValue[j] = double.MinValue; // 측정 포인트 값
              sData.OriginValue[j] = double.MinValue; // 측정 포인트 프로브 절대값
              sData.PointOffset[j] = double.MinValue; // 측정 포인트 옵셋
              sData.ZeroValue[j] = double.MinValue; // 측정 포인트에 저장된 제로값
            }
            sData.Min = double.MaxValue;
            sData.Max = double.MinValue;
            sData.Total = 0;
            sData.Average = 0;
            sData.Gap = 0;

            sData.StageNumber = 0; // 스테이지 번호

            // 결과 NG로 초기화 한다.
            enumUEUseMode eUEMode = (enumUEUseMode)cRcp.iUEMode;
            sData.Result = enumPCBResult.NONE;
            sData.PointIndex.Clear(); // 포인트 인덱스 초기화 하고 시작
            sData.MeasurePointValue.Clear(); // 측정값 저장할 버퍼도 클리어 하고 시작


            ////////////////
            bool bError = false;
            for (int i = 0; i < CVo.iPointMax; i++)
            {
              // 측정 값 저장 인덱스
              int iPointIndex1 = (i * 2);
              int iPointIndex2 = (i * 2) + 1;

              // 측정 루프 시작
              if (cSys.bUsePB1 && cSys.bUsePB2 && cRcp.abUsePointX[i])
              {
                // 프로브 둘다 사용하는 경우 
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cRcp.adPointY1[i];
                double dPB2 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY2[i] : -cSys.dPR2_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Measure(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(1));
                  if (cRcp.abUsePointY_Two[i])
                  {
                    list2.Add(CMaster.cProbe1.GetData(2));
                  }
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                sData.OriginValue[iPointIndex1] = dValue1;
                sData.X_Index[iPointIndex1] = i;
                sData.PointInfo[iPointIndex1] = enumPoint.Y1;
                sData.ProbeInfo[iPointIndex1] = enumProbe.PR1;
                sData.PointIndex.Add(iPointIndex1);

                if (cRcp.abUsePointY_Two[i])
                {
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  sData.OriginValue[iPointIndex2] = dValue2;
                  sData.X_Index[iPointIndex2] = i;
                  sData.PointInfo[iPointIndex2] = enumPoint.Y2;
                  sData.ProbeInfo[iPointIndex2] = enumProbe.PR2;
                  sData.PointIndex.Add(iPointIndex2);
                }
              }
              else if (cSys.bUsePB1 && cSys.bUsePB2 == false && cRcp.abUsePointX[i])
              {
                // 프로브 1번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cRcp.adPointY1[i];
                double dPB2 = -cSys.dPR2_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Measure(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(1));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);

                sData.OriginValue[iPointIndex1] = dValue1;
                sData.X_Index[iPointIndex1] = i;
                sData.PointInfo[iPointIndex1] = enumPoint.Y1;
                sData.ProbeInfo[iPointIndex1] = enumProbe.PR1;
                sData.PointIndex.Add(iPointIndex1);

                if (cRcp.abUsePointY_Two[i])
                {
                  // 두번째 포인트 설정되어 있는 경우에
                  dX1 = cRcp.adPointX[i];
                  dPB1 = cRcp.adPointY2[i];
                  dPB2 = -cSys.dPR2_Center_Pos;
                  bCycleResult = CMaster.cMotion.cAction.Stage1_Measure(dX1, dPB1, dPB2);
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
                    list2.Add(CMaster.cProbe1.GetData(1));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  sData.OriginValue[iPointIndex2] = dValue2;
                  sData.X_Index[iPointIndex2] = i;
                  sData.ProbeInfo[iPointIndex2] = enumProbe.PR1;
                  sData.PointInfo[iPointIndex2] = enumPoint.Y2;
                  sData.PointIndex.Add(iPointIndex2);
                }
              }
              else if (cSys.bUsePB1 == false && cSys.bUsePB2 && cRcp.abUsePointX[i])
              {
                // 프로브 2번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cSys.dPR1_Center_Pos;
                double dPB2 = cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Measure(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(2));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                sData.OriginValue[iPointIndex1] = dValue1;
                sData.X_Index[iPointIndex1] = i;
                sData.PointInfo[iPointIndex1] = enumPoint.Y1;
                sData.ProbeInfo[iPointIndex1] = enumProbe.PR2;
                sData.PointIndex.Add(iPointIndex1);

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB1 = cSys.dPR1_Center_Pos;
                  dPB2 = cRcp.adPointY2[i];

                  bCycleResult = CMaster.cMotion.cAction.Stage1_Measure(dX1, dPB1, dPB2);
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
                    list2.Add(CMaster.cProbe1.GetData(2));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);

                  sData.OriginValue[iPointIndex2] = dValue2;
                  sData.X_Index[iPointIndex2] = i;
                  sData.PointInfo[iPointIndex2] = enumPoint.Y2;
                  sData.ProbeInfo[iPointIndex2] = enumProbe.PR2;
                  sData.PointIndex.Add(iPointIndex2);
                }
              }
            } // 측정 루프 끝
            if (bError)
            {
              continue;
            }

            // 데이터 정리
            sData.MeasurePointValue.Clear();
            // 스테이지1 에서 측정된 데이터 산출
            for (int i = 0; i < CVo.MAX_POINT * 2; i++)
            {
              sData.ZeroValue[i] = CVo.asZeroData_Stage1[i].Value;
            }
            for (int i = 0; i < sData.PointIndex.Count; i++)
            {
              int iIndex = sData.PointIndex[i];
              double dPointOffset = 0.0;
              double dProbeOffset = 0.0;
              switch (sData.ProbeInfo[iIndex])
              {
                case enumProbe.PR1: dProbeOffset = cSys.dProbeOffset_1; break;
                case enumProbe.PR2: dProbeOffset = cSys.dProbeOffset_2; break;
                case enumProbe.PR3: dProbeOffset = cSys.dProbeOffset_3; break;
                case enumProbe.PR4: dProbeOffset = cSys.dProbeOffset_4; break;
                case enumProbe.NONE:
                default:
                  break;
              }
              switch (sData.PointInfo[iIndex])
              {
                case enumPoint.Y1:
                  dPointOffset = cRcp.adPointY1_Stage1_Offset[sData.X_Index[iIndex]];
                  break;
                case enumPoint.Y2:
                  dPointOffset = cRcp.adPointY2_Stage1_Offset[sData.X_Index[iIndex]];
                  break;
                case enumPoint.NONE:
                default:
                  break;
              }

              // 영점값 - 측정값 + 프로브 옵셋 + 포인트 옵셋
              sData.MeasureValue[iIndex] = sData.OriginValue[iIndex] - sData.ZeroValue[iIndex] + dProbeOffset + dPointOffset;
              sData.MeasurePointValue.Add(sData.MeasureValue[iIndex]);
              switch (eUEMode) // 측정 결과 초기화 및 결과 산출
              {
                case enumUEUseMode.USE_1:
                  sData.PointResult[iIndex] = enumPCBResult.A;
                  break;
                case enumUEUseMode.USE_2:
                  sData.PointResult[iIndex] = enumPCBResult.B;
                  if (cRcp.abPointY_Range_Min_A[iIndex] <= sData.MeasureValue[iIndex]
                   && cRcp.abPointY_Range_Max_A[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.A;
                  }
                  break;
                case enumUEUseMode.USE_3:
                  sData.PointResult[iIndex] = enumPCBResult.C;
                  if (cRcp.abPointY_Range_Min_A[iIndex] <= sData.MeasureValue[iIndex]
                   && cRcp.abPointY_Range_Max_A[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.A;
                  }
                  else if (cRcp.abPointY_Range_Min_B[iIndex] <= sData.MeasureValue[iIndex]
                        && cRcp.abPointY_Range_Max_B[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.B;
                  }
                  break;
                case enumUEUseMode.USE_4:
                default:
                  sData.PointResult[iIndex] = enumPCBResult.D;
                  if (cRcp.abPointY_Range_Min_A[iIndex] <= sData.MeasureValue[iIndex]
                   && cRcp.abPointY_Range_Max_A[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.A;
                  }
                  else if (cRcp.abPointY_Range_Min_B[iIndex] <= sData.MeasureValue[iIndex]
                        && cRcp.abPointY_Range_Max_B[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.B;
                  }
                  else if (cRcp.abPointY_Range_Min_C[iIndex] <= sData.MeasureValue[iIndex]
                        && cRcp.abPointY_Range_Max_C[iIndex] >= sData.MeasureValue[iIndex])
                  {
                    sData.PointResult[iIndex] = enumPCBResult.C;
                  }
                  break;
              }
              if (sData.Result == enumPCBResult.NONE) // 첫 결과가 나오면 최종결과 갱신
              {
                sData.Result = sData.PointResult[iIndex];
              }
              else if (sData.Result < sData.PointResult[iIndex]) // 이후에는 안좋은 결과로 갱신
              {
                sData.Result = sData.PointResult[iIndex];
              }
            }

            // 결과 데이터 취합
            sData.Min = sData.MeasurePointValue.Min();
            sData.Max = sData.MeasurePointValue.Max();
            sData.Total = sData.MeasurePointValue.Sum();
            sData.Average = sData.MeasurePointValue.Average();
            sData.Gap = sData.Max - sData.Min;


            System.IO.StreamWriter sw = null;
            try
            {
              string strFileFullPath = CVo.LOG_PATH_TEST + CVo.LOG_NAME_TEST_MEASURE1;
              if (System.IO.Directory.Exists(CVo.LOG_PATH_TEST) == false)
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_TEST);
              }
              string strData = "";
              bool bExistFile = System.IO.File.Exists(strFileFullPath);
              sw = new System.IO.StreamWriter(strFileFullPath, true, System.Text.Encoding.UTF8);
              if (bExistFile == false)
              {
                strData = "Stage";
                for (int i = 0; i < 40; i++)
                {
                  strData += ("," + (i + 1).ToString());
                }
                sw.WriteLine(strData);
              }
              strData = (sData.StageNumber + 1).ToString();
              for (int i = 0; i < sData.MeasurePointValue.Count; i++)
              {
                strData += ("," + sData.MeasurePointValue[i].ToString("0.000"));
              }
              sw.WriteLine(strData);
              sw.Close();
            }
            catch (Exception ex)
            {
              if (sw != null)
              {
                sw.Close();
              }
            }

            structMotorStatus sMotor = CMotionVo.GetMotorStatus(enumMotorName.Z1);
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Ready_Pos * sMotor.dLimitScale));
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor.dLimitScale));
            CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
            bError = false;
            for (int i = 0; i < 200; i++)
            {
              Thread.Sleep(1);
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running))
              {
                break;
              }
            }
            while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210A_Z1_Teaching_Complete) == false)
            {
              System.Threading.Thread.Sleep(1);
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running) == false
                && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210A_Z1_Teaching_Complete) == false)
              {
                bError = true;
                break;
              }
            }
            if (bError)
            {
              continue;
            }

          } // 테스트 측정

          if (CVo.bTestZeroSet1)
          {
            // 테스트 제로셋
            if (bStage1Running)
            {
              continue;
            }
            if (bErrorAll)
            {
              continue;
            }
            if (cSys.bUsePB1 == false && cSys.bUsePB2 == false)
            {
              continue;
            }
            structZeroSetData[] sZeroData = new structZeroSetData[CVo.iPointMax * 2];
            for (int i = 0; i < CVo.iPointMax * 2; i++)
            {
              sZeroData[i].PointType = enumPoint.NONE;
              sZeroData[i].ProbeType = enumProbe.NONE;
              sZeroData[i].Value = double.MinValue;
            }

            bool bError = false;
            for (int i = 0; i < CVo.iPointMax; i++)
            {
              // 측정 값 저장 인덱스
              int iPointIndex1 = (i * 2);
              int iPointIndex2 = (i * 2) + 1;

              // 측정 루프 시작
              if (cSys.bUsePB1 && cSys.bUsePB2 && cRcp.abUsePointX[i])
              {
                // 프로브 둘다 사용하는 경우 
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cRcp.adPointY1[i];
                double dPB2 = cRcp.abUsePointY_Two[i] ? cRcp.adPointY2[i] : -cSys.dPR2_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Zero(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(1));
                  if (cRcp.abUsePointY_Two[i])
                  {
                    list2.Add(CMaster.cProbe1.GetData(2));
                  }
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                sZeroData[iPointIndex1].Value = dValue1;
                sZeroData[iPointIndex1].X = i;
                sZeroData[iPointIndex1].PointType = enumPoint.Y1;
                sZeroData[iPointIndex1].ProbeType = enumProbe.PR1;

                if (cRcp.abUsePointY_Two[i])
                {
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  sZeroData[iPointIndex2].Value = dValue2;
                  sZeroData[iPointIndex2].X = i;
                  sZeroData[iPointIndex2].PointType = enumPoint.Y2;
                  sZeroData[iPointIndex2].ProbeType = enumProbe.PR2;
                }
              }
              else if (cSys.bUsePB1 && cSys.bUsePB2 == false && cRcp.abUsePointX[i])
              {
                // 프로브 1번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cRcp.adPointY1[i];
                double dPB2 = -cSys.dPR2_Center_Pos;
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Zero(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(1));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                sZeroData[iPointIndex1].Value = dValue1;
                sZeroData[iPointIndex1].X = i;
                sZeroData[iPointIndex1].PointType = enumPoint.Y1;
                sZeroData[iPointIndex1].ProbeType = enumProbe.PR1;

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB1 = cRcp.adPointY2[i];
                  dPB2 = -cSys.dPR2_Center_Pos;

                  bCycleResult = CMaster.cMotion.cAction.Stage1_Zero(dX1, dPB1, dPB2);
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
                    list2.Add(CMaster.cProbe1.GetData(1));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  sZeroData[iPointIndex2].Value = dValue2;
                  sZeroData[iPointIndex2].X = i;
                  sZeroData[iPointIndex2].PointType = enumPoint.Y2;
                  sZeroData[iPointIndex2].ProbeType = enumProbe.PR1;
                }
              }
              else if (cSys.bUsePB1 == false && cSys.bUsePB2 && cRcp.abUsePointX[i])
              {
                // 프로브 2번만 사용하는 경우
                double dX1 = cRcp.adPointX[i];
                double dPB1 = cSys.dPR1_Center_Pos;
                double dPB2 = cRcp.adPointY1[i];
                bool bCycleResult = CMaster.cMotion.cAction.Stage1_Zero(dX1, dPB1, dPB2);
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
                  list1.Add(CMaster.cProbe1.GetData(2));
                }
                double dValue1 = CMaster.cDataMgr.Average_Calculate(list1.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                sZeroData[iPointIndex1].Value = dValue1;
                sZeroData[iPointIndex1].X = i;
                sZeroData[iPointIndex1].PointType = enumPoint.Y1;
                sZeroData[iPointIndex1].ProbeType = enumProbe.PR2;

                if (cRcp.abUsePointY_Two[i])
                {
                  dX1 = cRcp.adPointX[i];
                  dPB1 = cSys.dPR1_Center_Pos;
                  dPB2 = cRcp.adPointY2[i];
                  bCycleResult = CMaster.cMotion.cAction.Stage1_Zero(dX1, dPB1, dPB2);
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
                    list2.Add(CMaster.cProbe1.GetData(2));
                  }
                  double dValue2 = CMaster.cDataMgr.Average_Calculate(list2.ToArray(), cSys.iProbeValueAverageMin, cSys.iProbeValueAverageMax);
                  sZeroData[iPointIndex2].Value = dValue2;
                  sZeroData[iPointIndex2].X = i;
                  sZeroData[iPointIndex2].PointType = enumPoint.Y2;
                  sZeroData[iPointIndex2].ProbeType = enumProbe.PR2;
                }
              }
            } // 측정 루프 끝
            if (bError)
            {
              continue;
            }

            System.IO.StreamWriter sw = null;
            try
            {
              string strFileFullPath = CVo.LOG_PATH_TEST + CVo.LOG_NAME_TEST_ZEROSET1;
              if (System.IO.Directory.Exists(CVo.LOG_PATH_TEST) == false)
              {
                System.IO.Directory.CreateDirectory(CVo.LOG_PATH_TEST);
              }
              string strData = "";
              bool bExistFile = System.IO.File.Exists(strFileFullPath);
              sw = new System.IO.StreamWriter(strFileFullPath, true, System.Text.Encoding.UTF8);
              if (bExistFile == false)
              {
                strData = "Stage";
                for (int i = 0; i < 40; i++)
                {
                  strData += ("," + (i + 1).ToString());
                }
                sw.WriteLine(strData);
              }
              strData = 1.ToString();
              for (int i = 0; i < sZeroData.Length; i++)
              {
                strData += ("," + sZeroData[i].Value.ToString("0.000"));
              }
              sw.WriteLine(strData);
              sw.Close();
            }
            catch (Exception ex)
            {
              if (sw != null)
              {
                sw.Close();
              }
            }

            structMotorStatus sMotor = CMotionVo.GetMotorStatus(enumMotorName.Z1);
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W102A_Z1_Teaching_Pos, (int)(cSys.dZ1_Ready_Pos * sMotor.dLimitScale));
            CIoVo.Set_WW_Teaching_Jog(enumWW_Teaching_Jog_Data.W1028_Z1_Teaching_Spd, (int)(cSys.dZ1_Normal_Spd * sMotor.dLimitScale));
            CIoVo.Set_WB_OutFlag(enumFlagOut.B102A_Z1_Teaching_Start, true);
            bError = false;
            for (int i = 0; i < 200; i++)
            {
              Thread.Sleep(1);
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running))
              {
                break;
              }
            }
            while (CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210A_Z1_Teaching_Complete) == false)
            {
              System.Threading.Thread.Sleep(1);
              if (CVo.Check_MachineStatus() == false)
              {
                bError = true;
                break;
              }
              if (CIoVo.Get_RB_RunningFlag(enumFlagRunning.B20AA_Z1_Teaching_Running) == false
                && CIoVo.Get_RB_CompleteFlag(enumFlagComplete.B210A_Z1_Teaching_Complete) == false)
              {
                bError = true;
                break;
              }
            }
            if (bError)
            {
              continue;
            }

          // 테스트 제로셋
          }

          if (CVo.bTestMeasure_Bust1)
          {
            if (bStage1Running)
            {
              continue;
            }
            if (bErrorAll)
            {
              continue;
            }
            if (cSys.bUsePB1 == false && cSys.bUsePB2 == false)
            {
              continue;
            }
            if (CVo.iTestRepeat_Bust1 < 0)
            {
              continue;
            }

          }

          if (CVo.bTestZeroSet_Bust1)
          {
            if (bStage1Running)
            {
              continue;
            }
            if (bErrorAll)
            {
              continue;
            }
            if (cSys.bUsePB1 == false && cSys.bUsePB2 == false)
            {
              continue;
            }
          }
        }
      }
    }
  }
}
