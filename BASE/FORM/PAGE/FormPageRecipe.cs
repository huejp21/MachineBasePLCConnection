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

namespace BASE.FORM.PAGE
{
  public struct structRangeData
  {
    public double Range_Max_A;
    public double Range_Min_A;
    public double Range_Max_B;
    public double Range_Min_B;
    public double Range_Max_C;
    public double Range_Min_C;
  }

  public partial class FormPageRecipe : Form
  {
    private List<System.Windows.Forms.Control> arrPointTxt_X = new List<Control>();
    private List<System.Windows.Forms.Control> arrPointBtn_Y = new List<Control>();
    private List<System.Windows.Forms.Control> arrPointTxt_Y1 = new List<Control>();
    private List<System.Windows.Forms.Control> arrPointTxt_Y2 = new List<Control>();

    private List<System.Windows.Forms.Control> arrStage1_Y1_Offset = new List<Control>();
    private List<System.Windows.Forms.Control> arrStage1_Y2_Offset = new List<Control>();
    private List<System.Windows.Forms.Control> arrStage2_Y1_Offset = new List<Control>();
    private List<System.Windows.Forms.Control> arrStage2_Y2_Offset = new List<Control>();

    private List<System.Windows.Forms.Control> arrRangeBtn_Y1 = new List<Control>();
    private List<System.Windows.Forms.Control> arrRangeBtn_Y2 = new List<Control>();
    private int iSelectedRangeX = 0; // X 번호 (0~19)
    private int iSelectedRangeY = 0; // Y 번호 (0~1)

    private List<System.Windows.Forms.Control> arrPointType_Y1 = new List<Control>(); // Y1 포인트 타입
    private List<System.Windows.Forms.Control> arrPointType_Y2 = new List<Control>(); // Y1 포인트 타입

    private ClassRecipePara cTempRecipe = new ClassRecipePara();


    private structRangeData sRangeData = new structRangeData();


    private void Get_Param()
    {
      cTempRecipe = CVo.cParaRcp.GetValues();
    }

    public FormPageRecipe()
    {
      InitializeComponent();
    }

    public void Display_RecipeList()
    {
      List<string> list = Load_RecipeList();
      listRecipe.Items.Clear();
      for (int i = 0; i < list.Count; i++)
      {
        listRecipe.Items.Add(list[i]);
      }

      listRecipe.SelectedIndex = 0;
      for (int i = 0; i < listRecipe.Items.Count; i++)
      {
        if (listRecipe.Items[i].ToString().CompareTo(CVo.RECIPE_CURRENT.Replace("\\", "")) == 0)
        {
          listRecipe.SelectedIndex = i;
        }
      }
      txtRecipeSelect.Text = listRecipe.Items[listRecipe.SelectedIndex].ToString();
      Get_Param();
      Refresh_MeasurePoint();
      RefreshRangeData();
      Update_RangeCopyData();
      RefreshRangeCopyData();
      RefreshPointType();
    }

    public List<string> Get_RecipeList()
    {
      List<string> list = new List<string>();
      for (int i = 0; i < listRecipe.Items.Count; i++)
      {
        list.Add(listRecipe.Items[i].ToString());
      }
      return list;
    }

    private List<string> Load_RecipeList()
    {
      List<string> list = new List<string>();
      list.Clear();
      if (!System.IO.Directory.Exists(CVo.RECIPE_PATH))
      {
        return list;
      }
      try
      {
        System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(CVo.RECIPE_PATH);
        if (Info.Exists)
        {
          System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);
          foreach (System.IO.DirectoryInfo info in CInfo)
          {
            list.Add(info.Name);
          }
        }
      }
      catch (Exception ex)
      {
        CMaster.cLogMgr.Add_Exception(System.Reflection.MethodBase.GetCurrentMethod().Name, new System.Diagnostics.StackTrace(ex, true), ex);
        list.Clear();
        return list;
      }
      return list;
    }

    private void FormPageRecipe_Load(object sender, EventArgs e) //Load Init
    {

      arrPointTxt_X.Clear();
      arrPointBtn_Y.Clear();
      arrPointTxt_Y1.Clear();
      arrPointTxt_Y2.Clear();

      arrPointTxt_X.Add(txtPoint_X_1);  
      arrPointTxt_X.Add(txtPoint_X_2);  
      arrPointTxt_X.Add(txtPoint_X_3);  
      arrPointTxt_X.Add(txtPoint_X_4);  
      arrPointTxt_X.Add(txtPoint_X_5);  
      arrPointTxt_X.Add(txtPoint_X_6);  
      arrPointTxt_X.Add(txtPoint_X_7);  
      arrPointTxt_X.Add(txtPoint_X_8);  
      arrPointTxt_X.Add(txtPoint_X_9);  
      arrPointTxt_X.Add(txtPoint_X_10); 
      arrPointTxt_X.Add(txtPoint_X_11); 
      arrPointTxt_X.Add(txtPoint_X_12); 
      arrPointTxt_X.Add(txtPoint_X_13); 
      arrPointTxt_X.Add(txtPoint_X_14); 
      arrPointTxt_X.Add(txtPoint_X_15); 
      arrPointTxt_X.Add(txtPoint_X_16); 
      arrPointTxt_X.Add(txtPoint_X_17); 
      arrPointTxt_X.Add(txtPoint_X_18); 
      arrPointTxt_X.Add(txtPoint_X_19); 
      arrPointTxt_X.Add(txtPoint_X_20); 

      arrPointBtn_Y.Add(btnPoint_Y_1); 
      arrPointBtn_Y.Add(btnPoint_Y_2); 
      arrPointBtn_Y.Add(btnPoint_Y_3); 
      arrPointBtn_Y.Add(btnPoint_Y_4); 
      arrPointBtn_Y.Add(btnPoint_Y_5); 
      arrPointBtn_Y.Add(btnPoint_Y_6); 
      arrPointBtn_Y.Add(btnPoint_Y_7); 
      arrPointBtn_Y.Add(btnPoint_Y_8); 
      arrPointBtn_Y.Add(btnPoint_Y_9); 
      arrPointBtn_Y.Add(btnPoint_Y_10);
      arrPointBtn_Y.Add(btnPoint_Y_11);
      arrPointBtn_Y.Add(btnPoint_Y_12);
      arrPointBtn_Y.Add(btnPoint_Y_13);
      arrPointBtn_Y.Add(btnPoint_Y_14);
      arrPointBtn_Y.Add(btnPoint_Y_15);
      arrPointBtn_Y.Add(btnPoint_Y_16);
      arrPointBtn_Y.Add(btnPoint_Y_17);
      arrPointBtn_Y.Add(btnPoint_Y_18);
      arrPointBtn_Y.Add(btnPoint_Y_19);
      arrPointBtn_Y.Add(btnPoint_Y_20);

      arrPointTxt_Y1.Add(txtPoint_Y1_1);
      arrPointTxt_Y1.Add(txtPoint_Y1_2);
      arrPointTxt_Y1.Add(txtPoint_Y1_3);
      arrPointTxt_Y1.Add(txtPoint_Y1_4);
      arrPointTxt_Y1.Add(txtPoint_Y1_5);
      arrPointTxt_Y1.Add(txtPoint_Y1_6);
      arrPointTxt_Y1.Add(txtPoint_Y1_7);
      arrPointTxt_Y1.Add(txtPoint_Y1_8);
      arrPointTxt_Y1.Add(txtPoint_Y1_9);
      arrPointTxt_Y1.Add(txtPoint_Y1_10);
      arrPointTxt_Y1.Add(txtPoint_Y1_11);
      arrPointTxt_Y1.Add(txtPoint_Y1_12);
      arrPointTxt_Y1.Add(txtPoint_Y1_13);
      arrPointTxt_Y1.Add(txtPoint_Y1_14);
      arrPointTxt_Y1.Add(txtPoint_Y1_15);
      arrPointTxt_Y1.Add(txtPoint_Y1_16);
      arrPointTxt_Y1.Add(txtPoint_Y1_17);
      arrPointTxt_Y1.Add(txtPoint_Y1_18);
      arrPointTxt_Y1.Add(txtPoint_Y1_19);
      arrPointTxt_Y1.Add(txtPoint_Y1_20);

      arrPointTxt_Y2.Add(txtPoint_Y2_1);
      arrPointTxt_Y2.Add(txtPoint_Y2_2);
      arrPointTxt_Y2.Add(txtPoint_Y2_3);
      arrPointTxt_Y2.Add(txtPoint_Y2_4);
      arrPointTxt_Y2.Add(txtPoint_Y2_5);
      arrPointTxt_Y2.Add(txtPoint_Y2_6);
      arrPointTxt_Y2.Add(txtPoint_Y2_7);
      arrPointTxt_Y2.Add(txtPoint_Y2_8);
      arrPointTxt_Y2.Add(txtPoint_Y2_9);
      arrPointTxt_Y2.Add(txtPoint_Y2_10);
      arrPointTxt_Y2.Add(txtPoint_Y2_11);
      arrPointTxt_Y2.Add(txtPoint_Y2_12);
      arrPointTxt_Y2.Add(txtPoint_Y2_13);
      arrPointTxt_Y2.Add(txtPoint_Y2_14);
      arrPointTxt_Y2.Add(txtPoint_Y2_15);
      arrPointTxt_Y2.Add(txtPoint_Y2_16);
      arrPointTxt_Y2.Add(txtPoint_Y2_17);
      arrPointTxt_Y2.Add(txtPoint_Y2_18);
      arrPointTxt_Y2.Add(txtPoint_Y2_19);
      arrPointTxt_Y2.Add(txtPoint_Y2_20);

      arrStage1_Y1_Offset.Clear();
      arrStage1_Y2_Offset.Clear();
      arrStage2_Y1_Offset.Clear();
      arrStage2_Y2_Offset.Clear();

      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_1);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_2);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_3);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_4);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_5);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_6);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_7);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_8);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_9);  
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_10); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_11); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_12); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_13); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_14); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_15); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_16); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_17); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_18); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_19); 
      arrStage1_Y1_Offset.Add(txtStage1_Y1_Offset_20);

      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_1);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_2);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_3);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_4);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_5);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_6);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_7);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_8);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_9);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_10);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_11);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_12);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_13);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_14);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_15);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_16);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_17);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_18);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_19);
      arrStage1_Y2_Offset.Add(txtStage1_Y2_Offset_20);

      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_1);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_2);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_3);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_4);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_5);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_6);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_7);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_8);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_9);  
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_10); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_11); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_12); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_13); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_14); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_15); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_16); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_17); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_18); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_19); 
      arrStage2_Y1_Offset.Add(txtStage2_Y1_Offset_20);

      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_1);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_2);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_3);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_4);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_5);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_6);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_7);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_8);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_9);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_10);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_11);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_12);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_13);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_14);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_15);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_16);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_17);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_18);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_19);
      arrStage2_Y2_Offset.Add(txtStage2_Y2_Offset_20);

      arrRangeBtn_Y1.Clear();
      arrRangeBtn_Y2.Clear();

      arrRangeBtn_Y1.Add(btnRangeY1_1);
      arrRangeBtn_Y1.Add(btnRangeY1_2);
      arrRangeBtn_Y1.Add(btnRangeY1_3);
      arrRangeBtn_Y1.Add(btnRangeY1_4);
      arrRangeBtn_Y1.Add(btnRangeY1_5);
      arrRangeBtn_Y1.Add(btnRangeY1_6);
      arrRangeBtn_Y1.Add(btnRangeY1_7);
      arrRangeBtn_Y1.Add(btnRangeY1_8);
      arrRangeBtn_Y1.Add(btnRangeY1_9);
      arrRangeBtn_Y1.Add(btnRangeY1_10);
      arrRangeBtn_Y1.Add(btnRangeY1_11);
      arrRangeBtn_Y1.Add(btnRangeY1_12);
      arrRangeBtn_Y1.Add(btnRangeY1_13);
      arrRangeBtn_Y1.Add(btnRangeY1_14);
      arrRangeBtn_Y1.Add(btnRangeY1_15);
      arrRangeBtn_Y1.Add(btnRangeY1_16);
      arrRangeBtn_Y1.Add(btnRangeY1_17);
      arrRangeBtn_Y1.Add(btnRangeY1_18);
      arrRangeBtn_Y1.Add(btnRangeY1_19);
      arrRangeBtn_Y1.Add(btnRangeY1_20);

      arrRangeBtn_Y2.Add(btnRangeY2_1);
      arrRangeBtn_Y2.Add(btnRangeY2_2);
      arrRangeBtn_Y2.Add(btnRangeY2_3);
      arrRangeBtn_Y2.Add(btnRangeY2_4);
      arrRangeBtn_Y2.Add(btnRangeY2_5);
      arrRangeBtn_Y2.Add(btnRangeY2_6);
      arrRangeBtn_Y2.Add(btnRangeY2_7);
      arrRangeBtn_Y2.Add(btnRangeY2_8);
      arrRangeBtn_Y2.Add(btnRangeY2_9);
      arrRangeBtn_Y2.Add(btnRangeY2_10);
      arrRangeBtn_Y2.Add(btnRangeY2_11);
      arrRangeBtn_Y2.Add(btnRangeY2_12);
      arrRangeBtn_Y2.Add(btnRangeY2_13);
      arrRangeBtn_Y2.Add(btnRangeY2_14);
      arrRangeBtn_Y2.Add(btnRangeY2_15);
      arrRangeBtn_Y2.Add(btnRangeY2_16);
      arrRangeBtn_Y2.Add(btnRangeY2_17);
      arrRangeBtn_Y2.Add(btnRangeY2_18);
      arrRangeBtn_Y2.Add(btnRangeY2_19);
      arrRangeBtn_Y2.Add(btnRangeY2_20);

      iSelectedRangeX = 0;
      iSelectedRangeY = 0;
      RefreashButtonChange(arrRangeBtn_Y1[0]);

      cboUEMode.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumUEUseMode)).Length; i++)
      {
        cboUEMode.Items.Add(((enumUEUseMode)i).ToString());
      }
      cboUEMode.SelectedIndex = 0;

      cboRejectZone.Items.Clear();
      for (int i = 0; i < Enum.GetNames(typeof(enumRejectZone)).Length; i++)
      {
        cboRejectZone.Items.Add((enumRejectZone)i);
      }
      cboRejectZone.SelectedIndex = 0;

      arrPointType_Y1.Clear();
      arrPointType_Y2.Clear();

      arrPointType_Y1.Add(btnPointType_Y1_1);
      arrPointType_Y1.Add(btnPointType_Y1_2);
      arrPointType_Y1.Add(btnPointType_Y1_3);
      arrPointType_Y1.Add(btnPointType_Y1_4);
      arrPointType_Y1.Add(btnPointType_Y1_5);
      arrPointType_Y1.Add(btnPointType_Y1_6);
      arrPointType_Y1.Add(btnPointType_Y1_7);
      arrPointType_Y1.Add(btnPointType_Y1_8);
      arrPointType_Y1.Add(btnPointType_Y1_9);
      arrPointType_Y1.Add(btnPointType_Y1_10);
      arrPointType_Y1.Add(btnPointType_Y1_11);
      arrPointType_Y1.Add(btnPointType_Y1_12);
      arrPointType_Y1.Add(btnPointType_Y1_13);
      arrPointType_Y1.Add(btnPointType_Y1_14);
      arrPointType_Y1.Add(btnPointType_Y1_15);
      arrPointType_Y1.Add(btnPointType_Y1_16);
      arrPointType_Y1.Add(btnPointType_Y1_17);
      arrPointType_Y1.Add(btnPointType_Y1_18);
      arrPointType_Y1.Add(btnPointType_Y1_19);
      arrPointType_Y1.Add(btnPointType_Y1_20);

      arrPointType_Y2.Add(btnPointType_Y2_1);
      arrPointType_Y2.Add(btnPointType_Y2_2);
      arrPointType_Y2.Add(btnPointType_Y2_3);
      arrPointType_Y2.Add(btnPointType_Y2_4);
      arrPointType_Y2.Add(btnPointType_Y2_5);
      arrPointType_Y2.Add(btnPointType_Y2_6);
      arrPointType_Y2.Add(btnPointType_Y2_7);
      arrPointType_Y2.Add(btnPointType_Y2_8);
      arrPointType_Y2.Add(btnPointType_Y2_9);
      arrPointType_Y2.Add(btnPointType_Y2_10);
      arrPointType_Y2.Add(btnPointType_Y2_11);
      arrPointType_Y2.Add(btnPointType_Y2_12);
      arrPointType_Y2.Add(btnPointType_Y2_13);
      arrPointType_Y2.Add(btnPointType_Y2_14);
      arrPointType_Y2.Add(btnPointType_Y2_15);
      arrPointType_Y2.Add(btnPointType_Y2_16);
      arrPointType_Y2.Add(btnPointType_Y2_17);
      arrPointType_Y2.Add(btnPointType_Y2_18);
      arrPointType_Y2.Add(btnPointType_Y2_19);
      arrPointType_Y2.Add(btnPointType_Y2_20);

      Display_RecipeList();
    }

    private bool Refresh_MeasurePoint()
    {
      txtPcb_Width.Text = cTempRecipe.dPCB_Width.ToString();
      txtPcb_Height.Text = cTempRecipe.dPCB_Height.ToString();
      txtPcb_Thick.Text = cTempRecipe.dPCB_Thick.ToString();
      txtPcb_BCR_BCX.Text = cTempRecipe.dPCB_Barcode_BCX_Pos.ToString();
      txtPcb_BCR_BCY.Text = cTempRecipe.dPCB_Barcode_BCY_Pos.ToString();
      txtPcb_Align_ALX.Text = cTempRecipe.dPCB_Align_ALX_Pos.ToString();
      txtPcb_Align_ALY.Text = cTempRecipe.dPCB_Align_ALY_Pos.ToString();
      cboUEMode.SelectedIndex = cTempRecipe.iUEMode;
      cboRejectZone.SelectedIndex = cTempRecipe.iRejectZone;
      switch ((enumUEUseMode)cTempRecipe.iUEMode)
      {
        case enumUEUseMode.USE_1:
          txtRangeMinA.Visible = false;
          txtRangeMinB.Visible = false;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = false;
          txtRangeMaxB.Visible = false;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_2:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = false;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = false;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_3:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_4:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = true;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = true;
          break;
        default:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = true;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = true;
          break;
      }

      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        arrPointTxt_X[i].Text = cTempRecipe.adPointX[i].ToString();
        arrPointBtn_Y[i].Text = cTempRecipe.abUsePointY_Two[i] ? "O" : "X";
        arrPointTxt_Y1[i].Text = cTempRecipe.adPointY1[i].ToString();
        arrPointTxt_Y2[i].Text = cTempRecipe.adPointY2[i].ToString();

        arrStage1_Y1_Offset[i].Text = cTempRecipe.adPointY1_Stage1_Offset[i].ToString("0.000");
        arrStage1_Y2_Offset[i].Text = cTempRecipe.adPointY2_Stage1_Offset[i].ToString("0.000");
        arrStage2_Y1_Offset[i].Text = cTempRecipe.adPointY1_Stage2_Offset[i].ToString("0.000");
        arrStage2_Y2_Offset[i].Text = cTempRecipe.adPointY2_Stage2_Offset[i].ToString("0.000");

        if (cTempRecipe.abUsePointX[i])
        {
          arrPointTxt_X[i].Visible = true;
          arrPointBtn_Y[i].Visible = true;
          arrPointTxt_Y1[i].Visible = true;
          arrPointTxt_Y2[i].Visible = cTempRecipe.abUsePointY_Two[i];

          arrStage1_Y1_Offset[i].Visible = true;
          arrStage1_Y2_Offset[i].Visible = cTempRecipe.abUsePointY_Two[i];
          arrStage2_Y1_Offset[i].Visible = true;
          arrStage2_Y2_Offset[i].Visible = cTempRecipe.abUsePointY_Two[i];

          arrRangeBtn_Y1[i].Visible = true;
          arrRangeBtn_Y2[i].Visible = cTempRecipe.abUsePointY_Two[i];

          arrPointType_Y1[i].Visible = true;
          arrPointType_Y2[i].Visible = cTempRecipe.abUsePointY_Two[i];
        }
        else
        {
          arrPointTxt_X[i].Visible = false;
          arrPointBtn_Y[i].Visible = false;
          arrPointTxt_Y1[i].Visible = false;
          arrPointTxt_Y2[i].Visible = false;

          arrStage1_Y1_Offset[i].Visible = false;
          arrStage1_Y2_Offset[i].Visible = false;
          arrStage2_Y1_Offset[i].Visible = false;
          arrStage2_Y2_Offset[i].Visible = false;

          arrRangeBtn_Y1[i].Visible = false;
          arrRangeBtn_Y2[i].Visible = false;

          arrPointType_Y1[i].Visible = false;
          arrPointType_Y2[i].Visible = false;
        }
      }
      txtPointCount.Text = cTempRecipe.iPointCount.ToString();

      return true;
    }

    private void FormPageRecipe_Shown(object sender, EventArgs e)
    {
      Display_RecipeList();
      tabRecipe.SelectedTab = tabpRecipe;
    }

    private void FormPageRecipe_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        Display_RecipeList();
        tabRecipe.SelectedTab = tabpRecipe;
      }
    }

    private void tabRecipe_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (CVo.eCurrentUserLevel < enumUserLevel.Maintenance)
      {
        tabRecipe.SelectedTab = tabpRecipe;
        return;
      }

      Display_RecipeList();
      Refresh_MeasurePoint();
    }

    private void btnRecipeNew_Click(object sender, EventArgs e)
    {

      string strNewRecipe = CForm.frmCreate.Show_("");
      if (strNewRecipe.CompareTo("(CANCEL)") == 0)
      {
        return;
      }
      if (strNewRecipe.CompareTo("") == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeFileNameIsNull);
        return;
      }
      string strNewRecipePath = CVo.RECIPE_PATH + strNewRecipe + "\\";
      if (System.IO.Directory.Exists(strNewRecipePath))
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeFileNameIsNull);
        return;
      }

      System.IO.Directory.CreateDirectory(strNewRecipePath);
      string strCurrentRecipePath = CVo.RECIPE_PATH + CVo.RECIPE_CURRENT;
      var files = System.IO.Directory.GetFiles(strCurrentRecipePath);
      foreach (var item in files)
      {
        System.IO.File.Copy(item, System.IO.Path.Combine(strNewRecipePath, System.IO.Path.GetFileName(item)), true);
      }
      Display_RecipeList();
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btnRecipeOpen_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.ChangeRecipe_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      string strSelectedRecipe = txtRecipeSelect.Text + "\\";
      string strSelectedRecipePath = CVo.RECIPE_PATH + strSelectedRecipe;
      bool bExsit = false;
      for (int i = 0; i < listRecipe.Items.Count; i++)
      {
        if (listRecipe.Items[i].ToString().CompareTo(txtRecipeSelect.Text) == 0)
        {
          bExsit = true;
          break;
        }
      }
      if (bExsit == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoExist);
        return;
      }
      if (CVo.RECIPE_CURRENT.CompareTo(strSelectedRecipe) == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeCanNotOpenCurrent);
        return;
      }
      if (System.IO.Directory.Exists(strSelectedRecipePath) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoExist);
        return;
      }
      string strRecipeOld = CVo.RECIPE_CURRENT;
      CVo.RECIPE_CURRENT = strSelectedRecipe;
      bool bResult = CVo.Load_Parameter_Recipe();
      if (bResult == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeLoadFail);
        CVo.RECIPE_CURRENT = strRecipeOld;
        CVo.Load_Parameter_Recipe();
        return;
      }
      CVo.Set_Recipe_Buffer();
      // 레시피오픈 성공시 변경해줘야하는 상태들 이곳에서 변경
      if (CMaster.cBCR.Check_Open())
      {
        ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
        Rectangle rt = new Rectangle();
        rt = new Rectangle(cRcp.iBCR_SX, cRcp.iBCR_SY, cRcp.iBCR_EX - cRcp.iBCR_SX, cRcp.iBCR_EY - cRcp.iBCR_SY);
        CMaster.cBCR.SetROI(rt);
      }
      CVo.Reset_LotData();
      CVo.Reset_ZeroSetData(0);
      CVo.Reset_ZeroSetData(1);
      Display_RecipeList(); // 화면갱신
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void btnRecipeCopy_Click(object sender, EventArgs e)
    {
      List<string> strList = new List<string>();
      strList.Clear();
      for (int i = 0; i < listRecipe.Items.Count; i++)
      {
        strList.Add(listRecipe.Items[i].ToString());
      }
      CForm.frmCopy.Show_(strList, "");
    }

    private void btnRecipeDelete_Click(object sender, EventArgs e)
    {
      string strSelectedRecipe = txtRecipeSelect.Text + "\\";
      string strSelectedRecipePath = CVo.RECIPE_PATH + strSelectedRecipe;
      bool bExsit = false;
      for (int i = 0; i < listRecipe.Items.Count; i++)
      {
        if (listRecipe.Items[i].ToString().CompareTo(txtRecipeSelect.Text) == 0)
        {
          bExsit = true;
          break;
        }
      }
      if (bExsit == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoExist);
        return;
      }
      if (CVo.RECIPE_CURRENT.CompareTo(strSelectedRecipe) == 0)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeCanNotDeleteCurrent);
        return;
      }
      if (System.IO.Directory.Exists(strSelectedRecipePath) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeNoExist);
        return;
      }
      if (CForm.frmMessageMsg.Show_(enumMsg.RecipeDelete_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }

      System.IO.Directory.Delete(strSelectedRecipePath, true);
      Display_RecipeList();
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void listRecipe_SelectedIndexChanged(object sender, EventArgs e)
    {
      int iIndex = listRecipe.SelectedIndex;
      if (iIndex < 0 || listRecipe.Items.Count <= iIndex)
      {
        return;
      }
      txtRecipeSelect.Text = listRecipe.SelectedItem.ToString();
    }

    private void btnUse_Y_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrPointBtn_Y[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 <= iIndex && iIndex < CVo.MAX_POINT)
      {
        cTempRecipe.abUsePointY_Two[iIndex] = !cTempRecipe.abUsePointY_Two[iIndex];
      }
      Refresh_MeasurePoint();
    }

    private void btnMeasureOptionSave_Click(object sender, EventArgs e)
    {
      ClassRecipePara cOld = CVo.cParaRcp.GetValues();
      ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

      cReplace.iPointCount = cTempRecipe.iPointCount;
      cReplace.abUsePointX = cTempRecipe.abUsePointX;

      bool bResult = CVo.Change_Parameter_Recipe(cReplace.GetValues());
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeMeasureSaveFail);
      }
    }

    private void btnMeasurePointSave_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if (CVo.Check_PointTypeSelected(cTempRecipe) == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeMeasurePointTypeNotSelected);
        return;
      }
      bool bResult = Save_MeasurePoint();
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeMeasureSaveFail);
      }
    }

    private void btnMeasureAllSave_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      if(Save_MeasurePoint() == false)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeMeasureSaveFail);
        return;
      }
      CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
    }

    private void txt_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
        case "txtPcb_Width": cTempRecipe.dPCB_Width = Convert.ToDouble(strData); break;
        case "txtPcb_Height": cTempRecipe.dPCB_Height = Convert.ToDouble(strData); break;
        case "txtPcb_Thick": cTempRecipe.dPCB_Thick = Convert.ToDouble(strData); break;
        case "txtPcb_BCR_BCX": cTempRecipe.dPCB_Barcode_BCX_Pos = Convert.ToDouble(strData); break;
        case "txtPcb_BCR_BCY": cTempRecipe.dPCB_Barcode_BCY_Pos = Convert.ToDouble(strData); break;
        case "txtPcb_Align_ALX": cTempRecipe.dPCB_Align_ALX_Pos = Convert.ToDouble(strData); break;
        case "txtPcb_Align_ALY": cTempRecipe.dPCB_Align_ALY_Pos = Convert.ToDouble(strData); break;
        default:
          break;
      }
      Refresh_MeasurePoint();
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
        //case "txtPcb_LotCount": cTempRecipe.iLotCount = Convert.ToInt32(strData); break;
        default:
          break;
      }
      Refresh_MeasurePoint();
    }

    private void txtPoint_Count_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      cTempRecipe.iPointCount = Convert.ToInt32(strData);
      txtPointCount.Text = strData;
      for (int i = 0; i < cTempRecipe.abUsePointX.Length; i++)
      {
        if (i < cTempRecipe.iPointCount)
        {
          cTempRecipe.abUsePointX[i] = true;
        }
        else
        {
          cTempRecipe.abUsePointX[i] = false;
        }
      }
      Refresh_MeasurePoint();
    }

    private void txtPoint_X_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrPointTxt_X[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        //  알수없는 오류
        return;
      }
      cTempRecipe.adPointX[iIndex] = Convert.ToDouble(strData);
      arrPointTxt_X[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtPoint_Y1_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrPointTxt_Y1[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        //  알수없는 오류
        return;
      }
      if (cTempRecipe.adPointY2[iIndex] > Convert.ToDouble(strData))
      {
        return;
      }
      cTempRecipe.adPointY1[iIndex] = Convert.ToDouble(strData);
      arrPointTxt_Y1[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtPoint_Y2_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrPointTxt_Y2[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        // 알수없는 오류
        return;
      }
      if (cTempRecipe.adPointY1[iIndex] < Convert.ToDouble(strData))
      {
        return;
      }
      cTempRecipe.adPointY2[iIndex] = Convert.ToDouble(strData);
      arrPointTxt_Y2[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtStage1_Y1_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrStage1_Y1_Offset[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        //  알수없는 오류
        return;
      }
      cTempRecipe.adPointY1_Stage1_Offset[iIndex] = Convert.ToDouble(strData);
      arrStage1_Y1_Offset[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtStage1_Y2_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrStage1_Y2_Offset[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        // 알수없는 오류
        return;
      }
      cTempRecipe.adPointY2_Stage1_Offset[iIndex] = Convert.ToDouble(strData);
      arrStage1_Y2_Offset[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtStage2_Y1_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

      if (strData.Trim().CompareTo("") == 0)
      {
        // 값없음
        return;
      }
      double dTemp;
      if (double.TryParse(strData, out dTemp) == false)
      {
        //숫자아님
        return;
      }
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrStage2_Y1_Offset[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        // 알수없는 오류
        return;
      }
      cTempRecipe.adPointY1_Stage2_Offset[iIndex] = Convert.ToDouble(strData);
      arrStage2_Y1_Offset[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void txtStage2_Y2_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = -1;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrStage2_Y2_Offset[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          break;
        }
      }
      if (0 > iIndex)
      {
        //  알수없는 오류
        return;
      }
      cTempRecipe.adPointY2_Stage2_Offset[iIndex] = Convert.ToDouble(strData);
      arrStage2_Y2_Offset[iIndex].Text = strData;
      Refresh_MeasurePoint();
    }

    private void btnPointCountUp_Click(object sender, EventArgs e)
    {
      if (CVo.MAX_POINT <= cTempRecipe.iPointCount)
      {
        return;
      }
      cTempRecipe.iPointCount += 1;
      for (int i = 0; i < cTempRecipe.abUsePointX.Length; i++)
      {
        if (i < cTempRecipe.iPointCount)
        {
          cTempRecipe.abUsePointX[i] = true;
        }
        else
        {
          cTempRecipe.abUsePointX[i] = false;
        }
      }
      Refresh_MeasurePoint();
    }

    private void btnPointCountDown_Click(object sender, EventArgs e)
    {
      if (cTempRecipe.iPointCount <= 0)
      {
        return;
      }
      cTempRecipe.iPointCount -= 1;
      for (int i = 0; i < cTempRecipe.abUsePointX.Length; i++)
      {
        if (i < cTempRecipe.iPointCount)
        {
          cTempRecipe.abUsePointX[i] = true;
        }
        else
        {
          cTempRecipe.abUsePointX[i] = false;
        }
      }

      Refresh_MeasurePoint();
    }

    private void btn_PCB_Info_Save_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();

      ClassRecipePara cOld = CVo.cParaRcp.GetValues();
      ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

      cReplace.dPCB_Width = cTempRecipe.dPCB_Width;
      cReplace.dPCB_Height = cTempRecipe.dPCB_Height;
      cReplace.dPCB_Thick = cTempRecipe.dPCB_Thick;
      cReplace.dPCB_Barcode_BCX_Pos = cTempRecipe.dPCB_Barcode_BCX_Pos;
      cReplace.dPCB_Barcode_BCY_Pos = cTempRecipe.dPCB_Barcode_BCY_Pos;
      cReplace.dPCB_Align_ALX_Pos = cTempRecipe.dPCB_Align_ALX_Pos;
      cReplace.dPCB_Align_ALY_Pos = cTempRecipe.dPCB_Align_ALY_Pos;
      cReplace.iUEMode = cTempRecipe.iUEMode;
      cReplace.iRejectZone = cTempRecipe.iRejectZone;

      bool bResult = CVo.Change_Parameter_Recipe(cReplace.GetValues());
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipePCBInfoSaveFail);
      }
    }

    private void tmr_Display_Tick(object sender, EventArgs e)
    {
      tmr_Display.Enabled = false;
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      int iWidth = (int)cRcp.dPCB_Width;
      int iHeight = (int)cRcp.dPCB_Height;

      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      CForm.Draw_PCBMap(this, pic_PCBMap, lblPCBMapSize); // 측정 포인트 셋팅창 맵 그리기
      CForm.Draw_PCBMap(this, pic_PCBMap_Offset, lblPCBMapSize_Offset); // 옵셋 셋팅창 맵 그리기
      CForm.Draw_PCBMap(this, pic_PCBMap_Range, lblPCBMapSize_Range); // 옵셋 셋팅창 맵 그리기

      tmr_Display.Enabled = true;
    }

    private void btn_BCR_Info_Click(object sender, EventArgs e)
    {
      CForm.frmBCR.Show_();
    }

    private void cboUEMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTempRecipe.iUEMode = cboUEMode.SelectedIndex;
      switch ((enumUEUseMode)cTempRecipe.iUEMode)
      {
        case enumUEUseMode.USE_1:
          txtRangeMinA.Visible = false;
          txtRangeMinB.Visible = false;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = false;
          txtRangeMaxB.Visible = false;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_2:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = false;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = false;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_3:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = false;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = false;
          break;
        case enumUEUseMode.USE_4:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = true;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = true;
          break;
        default:
          txtRangeMinA.Visible = true;
          txtRangeMinB.Visible = true;
          txtRangeMinC.Visible = true;
          txtRangeMaxA.Visible = true;
          txtRangeMaxB.Visible = true;
          txtRangeMaxC.Visible = true;
          break;
      }
    }

    #region Save 함수
    private bool Save_MeasurePoint()
    {
      CVo.bZeroSetStatus_Stage1 = false;
      CVo.bZeroSetStatus_Stage2 = false;
      ClassSystemPara cSys = CVo.cParaSys.GetValues();

      ClassRecipePara cOld = CVo.cParaRcp.GetValues();
      ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

      cReplace.iPointCount = cTempRecipe.iPointCount;
      cReplace.abUsePointX = cTempRecipe.abUsePointX;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (i < cTempRecipe.iPointCount)
        {
          cTempRecipe.abUsePointX[i] = true;
        }
        else
        {
          cTempRecipe.abUsePointX[i] = false;
        }
      }


      double dPR1_Interlock = cSys.dPR1_Change_Pos;
      double dPR2_Interlock = cSys.dPR2_Change_Pos;
      double dPR3_Interlock = cSys.dPR3_Change_Pos;
      double dPR4_Interlock = cSys.dPR4_Change_Pos;

      double dX1_Interlock_Minus = cSys.dX1_Interlock_Minus;
      double dX1_Interlock_Plus = cSys.dX1_Interlock_Plus;
      double dX2_Interlock_Minus = cSys.dX2_Interlock_Minus;
      double dX2_Interlock_Plus = cSys.dX2_Interlock_Plus;

      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (cTempRecipe.abUsePointX[i])
        {
          // X 인터락 확인
          double dX1_ABS = cSys.dX1_Center_Pos + cTempRecipe.adPointX[i];
          double dX2_ABS = cSys.dX2_Center_Pos + cTempRecipe.adPointX[i];
          if (dX1_ABS < dX1_Interlock_Minus)
          {
            return false;
          }
          if (dX1_ABS > dX1_Interlock_Plus)
          {
            return false;
          }
          if (dX2_ABS < dX2_Interlock_Minus)
          {
            return false;
          }
          if (dX2_ABS > dX2_Interlock_Plus)
          {
            return false;
          }

          if (cTempRecipe.abUsePointY_Two[i])
          {
            // 2 포인트 쓸때
            double dPR1_ABS = cSys.dPR1_Center_Pos - cTempRecipe.adPointY1[i];
            double dPR2_ABS = cSys.dPR2_Center_Pos + cTempRecipe.adPointY2[i];
            double dPR3_ABS = cSys.dPR3_Center_Pos - cTempRecipe.adPointY1[i];
            double dPR4_ABS = cSys.dPR4_Center_Pos + cTempRecipe.adPointY2[i];
            if (dPR1_ABS < dPR1_Interlock)
            {
              return false;
            }
            if (dPR2_ABS < dPR2_Interlock)
            {
              return false;
            }
            if (dPR3_ABS < dPR3_Interlock)
            {
              return false;
            }
            if (dPR4_ABS < dPR4_Interlock)
            {
              return false;
            }

            if (cTempRecipe.adPointY1[i] == 0 && cTempRecipe.adPointY2[i] == 0)
            {
              return false;
            }
            if ((cTempRecipe.adPointY1[i] - cTempRecipe.adPointY2[i]) < cSys.dProbe_Stage1_Safety_Gap)
            {
              return false;
            }
          }
          else
          {
            // 1 포인트 쓸때
            double dPR1_ABS = cSys.dPR1_Center_Pos - cTempRecipe.adPointY1[i];
            double dPR3_ABS = cSys.dPR3_Center_Pos - cTempRecipe.adPointY1[i];
            if (dPR1_ABS < dPR1_Interlock)
            {
              return false;
            }
            if (dPR3_ABS < dPR3_Interlock)
            {
              return false;
            }
          }
        }
        cReplace.adPointX[i] = cTempRecipe.adPointX[i];
        cReplace.adPointY1[i] = cTempRecipe.adPointY1[i];
        cReplace.adPointY2[i] = cTempRecipe.adPointY2[i];
        cReplace.abUsePointX[i] = cTempRecipe.abUsePointX[i];
        cReplace.abUsePointY_Two[i] = cTempRecipe.abUsePointY_Two[i];
      }

      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        cReplace.aiPointY1_Type[i] = cTempRecipe.aiPointY1_Type[i];
        cReplace.aiPointY2_Type[i] = cTempRecipe.aiPointY2_Type[i];
      }

      bool bResult = CVo.Change_Parameter_Recipe(cReplace.GetValues());
      if (bResult)
      {
        CVo.bZeroSetStatus_Stage1 = false;
        CVo.bZeroSetStatus_Stage2 = false;
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool Save_Offset()
    {
      CVo.bZeroSetStatus_Stage1 = false;
      CVo.bZeroSetStatus_Stage2 = false;

      ClassRecipePara cOld = CVo.cParaRcp.GetValues();
      ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        cReplace.adPointY1_Stage1_Offset[i] = cTempRecipe.adPointY1_Stage1_Offset[i];
        cReplace.adPointY2_Stage1_Offset[i] = cTempRecipe.adPointY2_Stage1_Offset[i];
        cReplace.adPointY1_Stage2_Offset[i] = cTempRecipe.adPointY1_Stage2_Offset[i];
        cReplace.adPointY2_Stage2_Offset[i] = cTempRecipe.adPointY2_Stage2_Offset[i];
      }

      bool bResult = CVo.Change_Parameter_Recipe(cReplace.GetValues());
      if (bResult)
      {
        CVo.bZeroSetStatus_Stage1 = false;
        CVo.bZeroSetStatus_Stage2 = false;
        return true;
      }
      else
      {
        return false;
      }
    }
    #endregion

    private void btnPointOffsetlSave_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      bool bResult = Save_Offset();
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeOffsetSaveFail);
      }
    }

    private void RefreashButtonChange(System.Windows.Forms.Control btn)
    {
      string strName = btn.Name;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrRangeBtn_Y1[i].Name.CompareTo(strName) == 0)
        {
          arrRangeBtn_Y1[i].BackColor = System.Drawing.Color.Lime;
        }
        else
        {
          arrRangeBtn_Y1[i].BackColor = System.Drawing.Color.Transparent;
        }

        if (arrRangeBtn_Y2[i].Name.CompareTo(strName) == 0)
        {
          arrRangeBtn_Y2[i].BackColor = System.Drawing.Color.Lime;
        }
        else
        {
          arrRangeBtn_Y2[i].BackColor = System.Drawing.Color.Transparent;
        }
      }
    }

    private void RefreshRangeData()
    { 
      ClassRecipePara cRcp = CVo.cParaRcp.GetValues();
      int iIndex = iSelectedRangeX * 2 + iSelectedRangeY;

      txtRangeMaxA.Text = cTempRecipe.abPointY_Range_Max_A[iIndex].ToString("0.000");
      txtRangeMinA.Text = cTempRecipe.abPointY_Range_Min_A[iIndex].ToString("0.000");
      txtRangeMaxB.Text = cTempRecipe.abPointY_Range_Max_B[iIndex].ToString("0.000");
      txtRangeMinB.Text = cTempRecipe.abPointY_Range_Min_B[iIndex].ToString("0.000");
      txtRangeMaxC.Text = cTempRecipe.abPointY_Range_Max_C[iIndex].ToString("0.000");
      txtRangeMinC.Text = cTempRecipe.abPointY_Range_Min_C[iIndex].ToString("0.000");
    }

    private void Update_RangeCopyData()
    {
      int iIndex = iSelectedRangeX * 2 + iSelectedRangeY;
      sRangeData.Range_Max_A = cTempRecipe.abPointY_Range_Max_A[iIndex];
      sRangeData.Range_Min_A = cTempRecipe.abPointY_Range_Min_A[iIndex];
      sRangeData.Range_Max_B = cTempRecipe.abPointY_Range_Max_B[iIndex];
      sRangeData.Range_Min_B = cTempRecipe.abPointY_Range_Min_B[iIndex];
      sRangeData.Range_Max_C = cTempRecipe.abPointY_Range_Max_C[iIndex];
      sRangeData.Range_Min_C = cTempRecipe.abPointY_Range_Min_C[iIndex];
    }

    private void RefreshRangeCopyData()
    {
      txtRangeCopyMaxA.Text = sRangeData.Range_Max_A.ToString("0.000");
      txtRangeCopyMinA.Text = sRangeData.Range_Min_A.ToString("0.000");
      txtRangeCopyMaxB.Text = sRangeData.Range_Max_B.ToString("0.000");
      txtRangeCopyMinB.Text = sRangeData.Range_Min_B.ToString("0.000");
      txtRangeCopyMaxC.Text = sRangeData.Range_Max_C.ToString("0.000");
      txtRangeCopyMinC.Text = sRangeData.Range_Min_C.ToString("0.000");
    }

    private void RefreshPointType()
    {
      System.Drawing.Color cNone = System.Drawing.Color.LightGray;
      System.Drawing.Color cDummy = System.Drawing.Color.Magenta;
      System.Drawing.Color cUnit = System.Drawing.Color.Blue;

      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        switch ((enumPointType)cTempRecipe.aiPointY1_Type[i])
        {
          case enumPointType.Dummy: arrPointType_Y1[i].BackColor = cDummy; break;
          case enumPointType.Unit: arrPointType_Y1[i].BackColor = cUnit; break;
          case enumPointType.NONE:
          default: arrPointType_Y1[i].BackColor = cNone; break;
        }

        switch ((enumPointType)cTempRecipe.aiPointY2_Type[i])
        {
          case enumPointType.Dummy: arrPointType_Y2[i].BackColor = cDummy; break;
          case enumPointType.Unit: arrPointType_Y2[i].BackColor = cUnit; break;
          case enumPointType.NONE:
          default: arrPointType_Y2[i].BackColor = cNone; break;
        }
      }
    }

    private void btnRange_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      RefreashButtonChange(ctrl);
      for (int i = 0; i < arrRangeBtn_Y1.Count; i++)
      {
        if (arrRangeBtn_Y1[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iSelectedRangeX = i; // X 번호 (0~19)
          iSelectedRangeY = 0; // Y 번호 (0~1)
          break;
        }
        if (arrRangeBtn_Y2[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iSelectedRangeX = i; // X 번호 (0~19)
          iSelectedRangeY = 1; // Y 번호 (0~1)
          break;
        }
      }
      RefreshRangeData();
      Update_RangeCopyData();
      RefreshRangeCopyData();
    }

    private void txtRange_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = iSelectedRangeX * 2 + iSelectedRangeY;
      switch (ctrl.Name)
      {
        case "txtRangeMaxA": cTempRecipe.abPointY_Range_Max_A[iIndex] = Convert.ToDouble(strData); break;
        case "txtRangeMinA": cTempRecipe.abPointY_Range_Min_A[iIndex] = Convert.ToDouble(strData); break;
        case "txtRangeMaxB": cTempRecipe.abPointY_Range_Max_B[iIndex] = Convert.ToDouble(strData); break;
        case "txtRangeMinB": cTempRecipe.abPointY_Range_Min_B[iIndex] = Convert.ToDouble(strData); break;
        case "txtRangeMaxC": cTempRecipe.abPointY_Range_Max_C[iIndex] = Convert.ToDouble(strData); break;
        case "txtRangeMinC": cTempRecipe.abPointY_Range_Min_C[iIndex] = Convert.ToDouble(strData); break;
        default:
          break;
      }
      RefreshRangeData();
    }

    private void txtRangeCopy_MouseDown(object sender, MouseEventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      string strData = CForm.frmKeypadNum.Show_(ctrl.Text, "");

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
      int iIndex = iSelectedRangeX * 2 + iSelectedRangeY;
      switch (ctrl.Name)
      {
        case "txtRangeCopyMaxA": sRangeData.Range_Max_A = Convert.ToDouble(strData); break;
        case "txtRangeCopyMinA": sRangeData.Range_Min_A = Convert.ToDouble(strData); break;
        case "txtRangeCopyMaxB": sRangeData.Range_Max_B = Convert.ToDouble(strData); break;
        case "txtRangeCopyMinB": sRangeData.Range_Min_B = Convert.ToDouble(strData); break;
        case "txtRangeCopyMaxC": sRangeData.Range_Max_C = Convert.ToDouble(strData); break;
        case "txtRangeCopyMinC": sRangeData.Range_Min_C = Convert.ToDouble(strData); break;
        default:
          break;
      }
      RefreshRangeCopyData();
    }

    private bool Save_Range()
    {
      ClassRecipePara cOld = CVo.cParaRcp.GetValues();
      ClassRecipePara cReplace = CVo.cParaRcp.GetValues();

      for (int i = 0; i < CVo.MAX_POINT * 2; i++)
      {
        cReplace.abPointY_Range_Max_A[i] = cTempRecipe.abPointY_Range_Max_A[i];
        cReplace.abPointY_Range_Min_A[i] = cTempRecipe.abPointY_Range_Min_A[i];
        cReplace.abPointY_Range_Max_B[i] = cTempRecipe.abPointY_Range_Max_B[i];
        cReplace.abPointY_Range_Min_B[i] = cTempRecipe.abPointY_Range_Min_B[i];
        cReplace.abPointY_Range_Max_C[i] = cTempRecipe.abPointY_Range_Max_C[i];
        cReplace.abPointY_Range_Min_C[i] = cTempRecipe.abPointY_Range_Min_C[i];
      }

      bool bResult = CVo.Change_Parameter_Recipe(cReplace.GetValues());
      if (bResult)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private void btn_Save_Range_Click(object sender, EventArgs e)
    {
      if (CForm.frmMessageMsg.Show_(enumMsg.DataSaveCheck_E) != System.Windows.Forms.DialogResult.Yes)
      {
        return;
      }
      CVo.Reset_LotData();
      bool bResult = Save_Range();
      if (bResult)
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.OK);
      }
      else
      {
        CForm.frmMessageAlarm.Show_Warn(enumAlarmWarn.RecipeRangeSaveFail);
      }
    }

    private void btnPointCopyY1toY2_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < CVo.MAX_POINT; i++)
			{
        cTempRecipe.adPointY2[i] = cTempRecipe.adPointY1[i] * -1.0;
			}
      Refresh_MeasurePoint();      
    }

    private void btnPointCopyY2toY1_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        cTempRecipe.adPointY1[i] = cTempRecipe.adPointY2[i] * -1.0;
      }
      Refresh_MeasurePoint();
    }

    private void btn_Copy_Range_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < CVo.MAX_POINT * 2; i++)
      {
        cTempRecipe.abPointY_Range_Max_A[i] = sRangeData.Range_Max_A;
        cTempRecipe.abPointY_Range_Min_A[i] = sRangeData.Range_Min_A;
        cTempRecipe.abPointY_Range_Max_B[i] = sRangeData.Range_Max_B;
        cTempRecipe.abPointY_Range_Min_B[i] = sRangeData.Range_Min_B;
        cTempRecipe.abPointY_Range_Max_C[i] = sRangeData.Range_Max_C;
        cTempRecipe.abPointY_Range_Min_C[i] = sRangeData.Range_Min_C;
      }
      RefreshRangeData();
      RefreshRangeCopyData();
    }

    private void btnPointType_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
      int iIndex = -1;
      string strInfo;
      for (int i = 0; i < CVo.MAX_POINT; i++)
      {
        if (arrPointType_Y1[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          strInfo = string.Format("{0}-1", (iIndex + 1));
          cTempRecipe.aiPointY1_Type[iIndex] = (int)CForm.frmPointType.Show_(strInfo);
          break;
        }
        if (arrPointType_Y2[i].Name.CompareTo(ctrl.Name) == 0)
        {
          iIndex = i;
          strInfo = string.Format("{0}-2", (iIndex + 1));
          cTempRecipe.aiPointY2_Type[iIndex] = (int)CForm.frmPointType.Show_(strInfo);
          break;
        }
      }
      RefreshPointType();
    }

    private void cboRejectZone_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTempRecipe.iRejectZone = cboRejectZone.SelectedIndex;
    }

  }
}
