using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASE.FORM;
using BASE.VO;
using BASE.MASTER;

namespace BASE.UTIL
{
  public class ClassDataMgr
  {
    private static ClassDataMgr cInstatnce;
    private static object syncLock = new object();

    protected ClassDataMgr()
    { 
    
    }

    public static ClassDataMgr Get_Instance()
    {
      if (cInstatnce == null)
      {
        lock (syncLock)
        {
          if (cInstatnce == null)
          {
            cInstatnce = new ClassDataMgr();
          }
        }
      }
      return cInstatnce;
    }

    public double Average_Calculate(double[] values, int minCount, int maxCount)
    {
      if (values.Length <= (minCount + maxCount))
      {
        return values.Average();
      }
      List<double> listValues = new List<double>();
      listValues.Clear();
      for (int i = 0; i < values.Length; i++)
      {
        listValues.Add(values[i]);
      }
      for (int i = 0; i < maxCount; i++)
      {
        listValues.Remove(listValues.Max());
      }
      for (int i = 0; i < minCount; i++)
      {
        listValues.Remove(listValues.Min());
      }
      double dResult = listValues.Average();
      return dResult;
    }

    public List<int> Get_PointIndex(int stageNum/*0:Stage1 1:Stage2*/) // 스테이지별 측정 포인트 인덱스
    {
      List<int> listIndex = new List<int>();
      listIndex.Clear();

      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      if (stageNum == 0)
      {
        for (int i = 0; i < CVo.iPointMax; i++)
        {
          if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i])
          {
            listIndex.Add(i * 2);
            listIndex.Add(i * 2 + 1);
          }
          else if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i] == false)
          {
            listIndex.Add(i * 2);
          }
        }
      }
      else if (stageNum == 1)
      {
        for (int i = 0; i < CVo.iPointMax; i++)
        {
          if (cSys.bUsePB3 && cSys.bUsePB4)
          {
            if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i])
            {
              listIndex.Add(i * 2);
              listIndex.Add(i * 2 + 1);
            }
            else if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i] == false)
            {
              listIndex.Add(i * 2 + 1);
            }
          }
          else
          {
            if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i])
            {
              listIndex.Add(i * 2);
              listIndex.Add(i * 2 + 1);
            }
            else if (cRcp.abUsePointX[i] && cRcp.abUsePointY_Two[i] == false)
            {
              listIndex.Add(i * 2);
            }
          }
        }
      }

      return listIndex;
    }

    public enumPCBResult Get_Result(int PCBIndex/*제품 인덱스*/)
    {
      enumPCBResult eResult = enumPCBResult.NONE;
      int iStageNum = CVo.sPCBData[PCBIndex].StageNumber; // 스테이지 번호

      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      enumUEUseMode UEMode = (enumUEUseMode)cRcp.iUEMode;
      if (iStageNum == 0)
      {
        CVo.sPCBData[PCBIndex].MeasurePointValue.Clear();
        CVo.sPCBData[PCBIndex].PointType.Clear();
        // 스테이지1 에서 측정된 데이터 산출
        for (int i = 0; i < CVo.MAX_POINT * 2; i++)
        {
          CVo.sPCBData[PCBIndex].ZeroValue[i] = CVo.asZeroData_Stage1[i].Value;
        }
        for (int i = 0; i < CVo.sPCBData[PCBIndex].PointIndex.Count; i++)
        {
          int iIndex = CVo.sPCBData[PCBIndex].PointIndex[i];
          double dPointOffset = 0.0;
          double dProbeOffset= 0.0;
          switch (CVo.sPCBData[PCBIndex].ProbeInfo[iIndex])
          {
            case enumProbe.PR1: dProbeOffset = cSys.dProbeOffset_1; break;
            case enumProbe.PR2: dProbeOffset = cSys.dProbeOffset_2; break;
            case enumProbe.PR3: dProbeOffset = cSys.dProbeOffset_3; break;
            case enumProbe.PR4: dProbeOffset = cSys.dProbeOffset_4; break;
            case enumProbe.NONE:
            default:
              break;
          }
          switch (CVo.sPCBData[PCBIndex].PointInfo[iIndex])
          {
            case enumPoint.Y1:
              dPointOffset = cRcp.adPointY1_Stage1_Offset[CVo.sPCBData[PCBIndex].X_Index[iIndex]];
              CVo.sPCBData[PCBIndex].PointType.Add((enumPointType)cRcp.aiPointY1_Type[CVo.sPCBData[PCBIndex].X_Index[iIndex]]);
              break;
            case enumPoint.Y2:
              dPointOffset = cRcp.adPointY2_Stage1_Offset[CVo.sPCBData[PCBIndex].X_Index[iIndex]];
              CVo.sPCBData[PCBIndex].PointType.Add((enumPointType)cRcp.aiPointY2_Type[CVo.sPCBData[PCBIndex].X_Index[iIndex]]);
              break;
            case enumPoint.NONE:
            default:
              break;
          }

          // 영점값 - 측정값 + 프로브 옵셋 + 포인트 옵셋
          CVo.sPCBData[PCBIndex].MeasureValue[iIndex] = CVo.sPCBData[PCBIndex].OriginValue[iIndex] - CVo.sPCBData[PCBIndex].ZeroValue[iIndex] + dProbeOffset + dPointOffset;
          CVo.sPCBData[PCBIndex].MeasurePointValue.Add(CVo.sPCBData[PCBIndex].MeasureValue[iIndex]);

          //System.IO.StreamWriter sw = null;
          //try
          //{
          //  string strPath = "D:\\DLM\\";
          //  string strName = "Log.csv";
          //  string strFullPath = strPath + strName;
          //  if (System.IO.Directory.Exists(strPath) == false)
          //  {
          //    System.IO.Directory.CreateDirectory(strPath);
          //  }
          //  sw = new System.IO.StreamWriter(strFullPath, true, System.Text.Encoding.UTF8);
          //  string strWriteData = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
          //    , System.DateTime.Now.ToString("yyyyMMddHHmmss")
          //    , CVo.sPCBData[PCBIndex].BCR
          //    , CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
          //    , CVo.sPCBData[PCBIndex].StageNumber
          //    , CVo.sPCBData[PCBIndex].OriginValue[iIndex]
          //    , CVo.sPCBData[PCBIndex].ZeroValue[iIndex]
          //    , dProbeOffset
          //    , dPointOffset);
          //  sw.WriteLine(strWriteData);

          //}
          //catch (Exception)
          //{

          //}
          //finally
          //{
          //  if (sw != null)
          //  {
          //    sw.Close();
          //  }
          //}

          switch (UEMode) // 측정 결과 초기화 및 결과 산출
          {
            case enumUEUseMode.USE_1: 
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              break;
            case enumUEUseMode.USE_2: 
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;
              if (cRcp.abPointY_Range_Min_A[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              break;
            case enumUEUseMode.USE_3: 
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.C;
              if (cRcp.abPointY_Range_Min_A[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              else if (cRcp.abPointY_Range_Min_B[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_B[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;                
              }
              break;
            case enumUEUseMode.USE_4:
            default:
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.D; 
              if (cRcp.abPointY_Range_Min_A[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              else if (cRcp.abPointY_Range_Min_B[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_B[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;
              }
              else if (cRcp.abPointY_Range_Min_C[iIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_C[iIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.C;
              }
              break;
          }
          if (eResult == enumPCBResult.NONE) // 첫 결과가 나오면 최종결과 갱신
          {
            eResult = CVo.sPCBData[PCBIndex].PointResult[iIndex];
          }
          else if (eResult < CVo.sPCBData[PCBIndex].PointResult[iIndex]) // 이후에는 안좋은 결과로 갱신
          {
            eResult = CVo.sPCBData[PCBIndex].PointResult[iIndex];
          }
        }
        if (CVo.sPCBData[PCBIndex].MeasurePointValue.Count > 0)
        {
          // 결과 데이터 취합
          CVo.sPCBData[PCBIndex].Min = CVo.sPCBData[PCBIndex].MeasurePointValue.Min();
          CVo.sPCBData[PCBIndex].Max = CVo.sPCBData[PCBIndex].MeasurePointValue.Max();
          CVo.sPCBData[PCBIndex].Total = CVo.sPCBData[PCBIndex].MeasurePointValue.Sum();
          CVo.sPCBData[PCBIndex].Average = CVo.sPCBData[PCBIndex].MeasurePointValue.Average();
          CVo.sPCBData[PCBIndex].Gap = CVo.sPCBData[PCBIndex].Max - CVo.sPCBData[PCBIndex].Min;
        }
      }
      if (iStageNum == 1)
      {
        CVo.sPCBData[PCBIndex].MeasurePointValue.Clear();
        CVo.sPCBData[PCBIndex].PointType.Clear();
        // 스테이지2 에서 측정된 데이터 산출
        for (int i = 0; i < CVo.MAX_POINT * 2; i++)
        {
          CVo.sPCBData[PCBIndex].ZeroValue[i] = CVo.asZeroData_Stage2[i].Value;
        }
        for (int i = 0; i < CVo.sPCBData[PCBIndex].PointIndex.Count; i++)
        {
          int iIndex = CVo.sPCBData[PCBIndex].PointIndex[i];
          double dPointOffset = 0.0;
          double dProbeOffset = 0.0;
          switch (CVo.sPCBData[PCBIndex].ProbeInfo[iIndex])
          {
            case enumProbe.PR1: dProbeOffset = cSys.dProbeOffset_1; break;
            case enumProbe.PR2: dProbeOffset = cSys.dProbeOffset_2; break;
            case enumProbe.PR3: dProbeOffset = cSys.dProbeOffset_3; break;
            case enumProbe.PR4: dProbeOffset = cSys.dProbeOffset_4; break;
            case enumProbe.NONE:
            default:
              break;
          }
          switch (CVo.sPCBData[PCBIndex].PointInfo[iIndex])
          {
            case enumPoint.Y1:
              dPointOffset = cRcp.adPointY1_Stage2_Offset[CVo.sPCBData[PCBIndex].X_Index[iIndex]];
              CVo.sPCBData[PCBIndex].PointType.Add((enumPointType)cRcp.aiPointY1_Type[CVo.sPCBData[PCBIndex].X_Index[iIndex]]);
              break;
            case enumPoint.Y2:
              dPointOffset = cRcp.adPointY2_Stage2_Offset[CVo.sPCBData[PCBIndex].X_Index[iIndex]];
              CVo.sPCBData[PCBIndex].PointType.Add((enumPointType)cRcp.aiPointY2_Type[CVo.sPCBData[PCBIndex].X_Index[iIndex]]);
              break;
            case enumPoint.NONE:
            default:
              break;
          }

          // 영점값 - 측정값 + 프로브 옵셋 + 포인트 옵셋
          CVo.sPCBData[PCBIndex].MeasureValue[iIndex] = CVo.sPCBData[PCBIndex].OriginValue[iIndex] - CVo.sPCBData[PCBIndex].ZeroValue[iIndex] + dProbeOffset + dPointOffset;
          CVo.sPCBData[PCBIndex].MeasurePointValue.Add(CVo.sPCBData[PCBIndex].MeasureValue[iIndex]);

          //System.IO.StreamWriter sw = null;
          //try
          //{
          //  string strPath = "D:\\DLM\\";
          //  string strName = "Log.csv";
          //  string strFullPath = strPath + strName;
          //  if (System.IO.Directory.Exists(strPath) == false)
          //  {
          //    System.IO.Directory.CreateDirectory(strPath);
          //  }
          //  sw = new System.IO.StreamWriter(strFullPath, true, System.Text.Encoding.UTF8);
          //  string strWriteData = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
          //    , System.DateTime.Now.ToString("yyyyMMddHHmmss")
          //    , CVo.sPCBData[PCBIndex].BCR
          //    , CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
          //    , CVo.sPCBData[PCBIndex].StageNumber
          //    , CVo.sPCBData[PCBIndex].OriginValue[iIndex]
          //    , CVo.sPCBData[PCBIndex].ZeroValue[iIndex]
          //    , dProbeOffset
          //    , dPointOffset);
          //  sw.WriteLine(strWriteData);

          //}
          //catch (Exception)
          //{

          //}
          //finally
          //{
          //  if (sw != null)
          //  {
          //    sw.Close();
          //  }
          //}

          int iRangeIndex = 0;
          if (true)
          {
              int x = CVo.sPCBData[PCBIndex].X_Index[iIndex];
              int y = CVo.sPCBData[PCBIndex].PointInfo[iIndex] == enumPoint.Y1 ? 0 : 1;
              iRangeIndex = x * 2 + y;
          }
          double dRange_Min_A = cRcp.abPointY_Range_Min_A[iRangeIndex];
          double dRange_Max_A = cRcp.abPointY_Range_Max_A[iRangeIndex];
          double dRange_Min_B = cRcp.abPointY_Range_Min_B[iRangeIndex];
          double dRange_Max_B = cRcp.abPointY_Range_Max_B[iRangeIndex];
          double dRange_Min_C = cRcp.abPointY_Range_Min_C[iRangeIndex];
          double dRange_Max_C = cRcp.abPointY_Range_Max_C[iRangeIndex];

          switch (UEMode) // 측정 결과 초기화 및 결과 산출
          {
            case enumUEUseMode.USE_1:
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              break;
            case enumUEUseMode.USE_2:
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;
              if (cRcp.abPointY_Range_Min_A[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              break;
            case enumUEUseMode.USE_3:
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.C;
              if (cRcp.abPointY_Range_Min_A[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              else if (cRcp.abPointY_Range_Min_B[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_B[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;
              }
              break;
            case enumUEUseMode.USE_4:
            default:
              CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.D;
              if (cRcp.abPointY_Range_Min_A[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
               && cRcp.abPointY_Range_Max_A[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.A;
              }
              else if (cRcp.abPointY_Range_Min_B[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_B[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.B;
              }
              else if (cRcp.abPointY_Range_Min_C[iRangeIndex] <= CVo.sPCBData[PCBIndex].MeasureValue[iIndex]
                    && cRcp.abPointY_Range_Max_C[iRangeIndex] >= CVo.sPCBData[PCBIndex].MeasureValue[iIndex])
              {
                CVo.sPCBData[PCBIndex].PointResult[iIndex] = enumPCBResult.C;
              }
              break;
          }
          if (eResult == enumPCBResult.NONE) // 첫 결과가 나오면 최종결과 갱신
          {
            eResult = CVo.sPCBData[PCBIndex].PointResult[iIndex];
          }
          else if (eResult < CVo.sPCBData[PCBIndex].PointResult[iIndex]) // 이후에는 안좋은 결과로 갱신
          {
            eResult = CVo.sPCBData[PCBIndex].PointResult[iIndex];
          }
        }

        if (CVo.sPCBData[PCBIndex].MeasurePointValue.Count > 0)
        {
          // 결과 데이터 취합
          CVo.sPCBData[PCBIndex].Min = CVo.sPCBData[PCBIndex].MeasurePointValue.Min();
          CVo.sPCBData[PCBIndex].Max = CVo.sPCBData[PCBIndex].MeasurePointValue.Max();
          CVo.sPCBData[PCBIndex].Total = CVo.sPCBData[PCBIndex].MeasurePointValue.Sum();
          CVo.sPCBData[PCBIndex].Average = CVo.sPCBData[PCBIndex].MeasurePointValue.Average();
          CVo.sPCBData[PCBIndex].Gap = CVo.sPCBData[PCBIndex].Max - CVo.sPCBData[PCBIndex].Min;
        }
      }


      return eResult;
    }
  }
}
