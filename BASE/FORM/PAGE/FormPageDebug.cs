using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BASE.UTIL;
using BASE.VO;
using BASE.MASTER;
using BASE.MODULE.MOTION;

namespace BASE.FORM.PAGE
{
  public partial class FormPageDebug : Form
  {
    public List<string> listDebug = new List<string>();
    public FormPageDebug()
    {
      InitializeComponent();
    }

    private void btnDebugRefreshLanguageDB_Click(object sender, EventArgs e)
    {
      bool Result = CForm.Organize_Language();
      System.Windows.Forms.MessageBox.Show(Result ? "OK" : "Fail");
    }

    private void btnDebugRefreshAlarm_Click(object sender, EventArgs e)
    {
      bool Result = CVo.Organize_Alarm();
      System.Windows.Forms.MessageBox.Show(Result ? "OK" : "Fail");
    }

    private void btnDebugRefreshMessage_Click(object sender, EventArgs e)
    {
      bool Result = CVo.Organize_Msg();
      System.Windows.Forms.MessageBox.Show(Result ? "OK" : "Fail");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      ColorDialog cd = new ColorDialog();
      if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        int i = cd.Color.R;

        int sdfs = cd.Color.ToArgb();
        string str = cd.Color.ToString();
        button1.BackColor = Color.FromArgb(sdfs);
      }
      
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //List<string> list = new List<string>();
      //if (System.IO.Directory.Exists(CVo.LOG_PATH_ALARM_STOP))
      //{ 
      //    foreach (string f in System.IO.Directory.GetFiles(CVo.LOG_PATH_ALARM_STOP))
      //    {
      //      list.Add(System.IO.Path.GetFileName(f));
      //    }
      //}
      //string str = "";
      //for (int i = 0; i < list.Count; i++)
      //{
      //  str += (list[i] + "\r\n");
      //}
      //System.Windows.Forms.MessageBox.Show(str);

      CForm.frmMessageAlarmStop.Show_Stop(enumAlarmStop.B2140_PLC_AW_LE_Ready_Error);
    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {
      int iIndex = 0;
      CVo.sPCBData[iIndex].PointIndex.Clear(); // 포인트 인덱스 초기화 하고 시작
      CVo.sPCBData[iIndex].MeasurePointValue.Clear(); // 측정값 저장할 버퍼도 클리어 하고 시작
      CVo.sPCBData[iIndex].StageNumber = 0;
      CVo.sPCBData[iIndex].PerfectlyOut = true;
      CVo.sPCBData[iIndex].BCR = "B12345678 0101";
      CVo.sPCBData[iIndex].BCR_OK = true;
      for (int i = 0; i < CVo.MAX_POINT / 2; i++)
      {
        int index1 = i * 2;
        int index2 = i * 2 + 1;
        double dValue1 = 0.1;
        CVo.sPCBData[iIndex].OriginValue[index1] = dValue1;
        CVo.sPCBData[iIndex].X_Index[index1] = i;
        CVo.sPCBData[iIndex].PointInfo[index1] = enumPoint.Y1;
        CVo.sPCBData[iIndex].ProbeInfo[index1] = enumProbe.PR1;
        CVo.sPCBData[iIndex].PointIndex.Add(index1);
        double dValue2 = 0.2;
        CVo.sPCBData[iIndex].OriginValue[index2] = dValue2;
        CVo.sPCBData[iIndex].X_Index[index2] = i;
        CVo.sPCBData[iIndex].PointInfo[index2] = enumPoint.Y1;
        CVo.sPCBData[iIndex].ProbeInfo[index2] = enumProbe.PR2;
        CVo.sPCBData[iIndex].PointIndex.Add(index2);
      }
      CVo.sPCBData[iIndex].Result = CMaster.cDataMgr.Get_Result(iIndex);
      CVo.Save_MeasureData(iIndex);
      CForm.frmPageAuto.Add_PCBData(CVo.sPCBData[iIndex]);
      CVo.Save_Lot_Log();

    }

    private void button5_Click(object sender, EventArgs e)
    {
    }

    private void button6_Click(object sender, EventArgs e)
    {
    }

    private void button7_Click(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Enabled = false;
      listBox1.Items.Clear();
      for (int i = 0; i < listDebug.Count; i++)
      {
        listBox1.Items.Add(listDebug[i]);
      }
      timer1.Enabled = true;
    }

    private void button8_Click(object sender, EventArgs e)
    {
     CVo.iDebug_Open_Index = Convert.ToInt32(textBox1.Text);
    }

    private void button9_Click(object sender, EventArgs e)
    {
      CVo.iDebug_Write_Index = Convert.ToInt32(textBox2.Text);
    }
  }
}
