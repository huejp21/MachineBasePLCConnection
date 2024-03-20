namespace BASE.FORM.PAGE
{
  partial class FormPageTestCycle
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tabTestCycle = new System.Windows.Forms.TabControl();
      this.tabpTest = new System.Windows.Forms.TabPage();
      this.group_Test = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtTestGap2 = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtTestRepeat2 = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtTestGap1 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtTestRepeat1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbo_Test2Mode = new System.Windows.Forms.ComboBox();
      this.cbo_Test1Mode = new System.Windows.Forms.ComboBox();
      this.btnTestZero2 = new System.Windows.Forms.Button();
      this.btnTestMeasure2 = new System.Windows.Forms.Button();
      this.btnTestZero1 = new System.Windows.Forms.Button();
      this.btnTestMeasure1 = new System.Windows.Forms.Button();
      this.tmr_Test = new System.Windows.Forms.Timer(this.components);
      this.tabTestCycle.SuspendLayout();
      this.tabpTest.SuspendLayout();
      this.group_Test.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabTestCycle
      // 
      this.tabTestCycle.Controls.Add(this.tabpTest);
      this.tabTestCycle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabTestCycle.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabTestCycle.Location = new System.Drawing.Point(0, 0);
      this.tabTestCycle.Name = "tabTestCycle";
      this.tabTestCycle.SelectedIndex = 0;
      this.tabTestCycle.Size = new System.Drawing.Size(1074, 814);
      this.tabTestCycle.TabIndex = 0;
      // 
      // tabpTest
      // 
      this.tabpTest.Controls.Add(this.group_Test);
      this.tabpTest.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabpTest.Location = new System.Drawing.Point(4, 34);
      this.tabpTest.Name = "tabpTest";
      this.tabpTest.Padding = new System.Windows.Forms.Padding(3);
      this.tabpTest.Size = new System.Drawing.Size(1066, 776);
      this.tabpTest.TabIndex = 1;
      this.tabpTest.Text = "Test";
      this.tabpTest.UseVisualStyleBackColor = true;
      // 
      // group_Test
      // 
      this.group_Test.Controls.Add(this.label6);
      this.group_Test.Controls.Add(this.txtTestGap2);
      this.group_Test.Controls.Add(this.label8);
      this.group_Test.Controls.Add(this.txtTestRepeat2);
      this.group_Test.Controls.Add(this.label10);
      this.group_Test.Controls.Add(this.label4);
      this.group_Test.Controls.Add(this.txtTestGap1);
      this.group_Test.Controls.Add(this.label3);
      this.group_Test.Controls.Add(this.txtTestRepeat1);
      this.group_Test.Controls.Add(this.label1);
      this.group_Test.Controls.Add(this.cbo_Test2Mode);
      this.group_Test.Controls.Add(this.cbo_Test1Mode);
      this.group_Test.Controls.Add(this.btnTestZero2);
      this.group_Test.Controls.Add(this.btnTestMeasure2);
      this.group_Test.Controls.Add(this.btnTestZero1);
      this.group_Test.Controls.Add(this.btnTestMeasure1);
      this.group_Test.Location = new System.Drawing.Point(8, 6);
      this.group_Test.Name = "group_Test";
      this.group_Test.Size = new System.Drawing.Size(330, 285);
      this.group_Test.TabIndex = 245;
      this.group_Test.TabStop = false;
      this.group_Test.Text = "Test";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(283, 105);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(39, 23);
      this.label6.TabIndex = 249;
      this.label6.Text = "mSec";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label6.Visible = false;
      // 
      // txtTestGap2
      // 
      this.txtTestGap2.Location = new System.Drawing.Point(216, 107);
      this.txtTestGap2.Name = "txtTestGap2";
      this.txtTestGap2.ReadOnly = true;
      this.txtTestGap2.Size = new System.Drawing.Size(61, 21);
      this.txtTestGap2.TabIndex = 248;
      this.txtTestGap2.Text = "100";
      this.txtTestGap2.Visible = false;
      this.txtTestGap2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_IntMouseDown);
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(167, 108);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(59, 20);
      this.label8.TabIndex = 247;
      this.label8.Text = "Gap:";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label8.Visible = false;
      // 
      // txtTestRepeat2
      // 
      this.txtTestRepeat2.Location = new System.Drawing.Point(216, 80);
      this.txtTestRepeat2.Name = "txtTestRepeat2";
      this.txtTestRepeat2.ReadOnly = true;
      this.txtTestRepeat2.Size = new System.Drawing.Size(106, 21);
      this.txtTestRepeat2.TabIndex = 246;
      this.txtTestRepeat2.Text = "20";
      this.txtTestRepeat2.Visible = false;
      this.txtTestRepeat2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_IntMouseDown);
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(167, 81);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(59, 20);
      this.label10.TabIndex = 245;
      this.label10.Text = "Repeat:";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label10.Visible = false;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(122, 105);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(39, 23);
      this.label4.TabIndex = 244;
      this.label4.Text = "mSec";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label4.Visible = false;
      // 
      // txtTestGap1
      // 
      this.txtTestGap1.Location = new System.Drawing.Point(55, 107);
      this.txtTestGap1.Name = "txtTestGap1";
      this.txtTestGap1.ReadOnly = true;
      this.txtTestGap1.Size = new System.Drawing.Size(61, 21);
      this.txtTestGap1.TabIndex = 243;
      this.txtTestGap1.Text = "100";
      this.txtTestGap1.Visible = false;
      this.txtTestGap1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_IntMouseDown);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(6, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 20);
      this.label3.TabIndex = 242;
      this.label3.Text = "Gap:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label3.Visible = false;
      // 
      // txtTestRepeat1
      // 
      this.txtTestRepeat1.Location = new System.Drawing.Point(55, 80);
      this.txtTestRepeat1.Name = "txtTestRepeat1";
      this.txtTestRepeat1.ReadOnly = true;
      this.txtTestRepeat1.Size = new System.Drawing.Size(106, 21);
      this.txtTestRepeat1.TabIndex = 241;
      this.txtTestRepeat1.Text = "20";
      this.txtTestRepeat1.Visible = false;
      this.txtTestRepeat1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_IntMouseDown);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(6, 81);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 20);
      this.label1.TabIndex = 240;
      this.label1.Text = "Repeat:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label1.Visible = false;
      // 
      // cbo_Test2Mode
      // 
      this.cbo_Test2Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbo_Test2Mode.FormattingEnabled = true;
      this.cbo_Test2Mode.Location = new System.Drawing.Point(167, 31);
      this.cbo_Test2Mode.Name = "cbo_Test2Mode";
      this.cbo_Test2Mode.Size = new System.Drawing.Size(155, 20);
      this.cbo_Test2Mode.TabIndex = 239;
      this.cbo_Test2Mode.Visible = false;
      this.cbo_Test2Mode.SelectedIndexChanged += new System.EventHandler(this.cbo_TestMode_SelectedIndexChanged);
      // 
      // cbo_Test1Mode
      // 
      this.cbo_Test1Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbo_Test1Mode.FormattingEnabled = true;
      this.cbo_Test1Mode.Location = new System.Drawing.Point(6, 31);
      this.cbo_Test1Mode.Name = "cbo_Test1Mode";
      this.cbo_Test1Mode.Size = new System.Drawing.Size(155, 20);
      this.cbo_Test1Mode.TabIndex = 250;
      this.cbo_Test1Mode.Visible = false;
      this.cbo_Test1Mode.SelectedIndexChanged += new System.EventHandler(this.cbo_TestMode_SelectedIndexChanged);
      // 
      // btnTestZero2
      // 
      this.btnTestZero2.Location = new System.Drawing.Point(167, 215);
      this.btnTestZero2.Name = "btnTestZero2";
      this.btnTestZero2.Size = new System.Drawing.Size(155, 60);
      this.btnTestZero2.TabIndex = 237;
      this.btnTestZero2.Text = "Stage2 ZeroSet Test";
      this.btnTestZero2.UseVisualStyleBackColor = true;
      this.btnTestZero2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTest_MouseDown);
      // 
      // btnTestMeasure2
      // 
      this.btnTestMeasure2.Location = new System.Drawing.Point(167, 149);
      this.btnTestMeasure2.Name = "btnTestMeasure2";
      this.btnTestMeasure2.Size = new System.Drawing.Size(155, 60);
      this.btnTestMeasure2.TabIndex = 236;
      this.btnTestMeasure2.Text = "Stage2 Measure Test";
      this.btnTestMeasure2.UseVisualStyleBackColor = true;
      this.btnTestMeasure2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTest_MouseDown);
      // 
      // btnTestZero1
      // 
      this.btnTestZero1.Location = new System.Drawing.Point(6, 215);
      this.btnTestZero1.Name = "btnTestZero1";
      this.btnTestZero1.Size = new System.Drawing.Size(155, 60);
      this.btnTestZero1.TabIndex = 235;
      this.btnTestZero1.Text = "Stage1 ZeroSet Test";
      this.btnTestZero1.UseVisualStyleBackColor = true;
      this.btnTestZero1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTest_MouseDown);
      // 
      // btnTestMeasure1
      // 
      this.btnTestMeasure1.Location = new System.Drawing.Point(6, 149);
      this.btnTestMeasure1.Name = "btnTestMeasure1";
      this.btnTestMeasure1.Size = new System.Drawing.Size(155, 60);
      this.btnTestMeasure1.TabIndex = 234;
      this.btnTestMeasure1.Text = "Stage1 Measure Test";
      this.btnTestMeasure1.UseVisualStyleBackColor = true;
      this.btnTestMeasure1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTest_MouseDown);
      // 
      // tmr_Test
      // 
      this.tmr_Test.Enabled = true;
      this.tmr_Test.Tick += new System.EventHandler(this.tmr_Test_Tick);
      // 
      // FormPageTestCycle
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1074, 814);
      this.ControlBox = false;
      this.Controls.Add(this.tabTestCycle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormPageTestCycle";
      this.Text = "FormPageTestCycle";
      this.Load += new System.EventHandler(this.FormPageTestCycle_Load);
      this.tabTestCycle.ResumeLayout(false);
      this.tabpTest.ResumeLayout(false);
      this.group_Test.ResumeLayout(false);
      this.group_Test.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabTestCycle;
    private System.Windows.Forms.TabPage tabpTest;
    private System.Windows.Forms.GroupBox group_Test;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtTestGap2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtTestRepeat2;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtTestGap1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtTestRepeat1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbo_Test2Mode;
    private System.Windows.Forms.ComboBox cbo_Test1Mode;
    private System.Windows.Forms.Button btnTestZero2;
    private System.Windows.Forms.Button btnTestMeasure2;
    private System.Windows.Forms.Button btnTestZero1;
    private System.Windows.Forms.Button btnTestMeasure1;
    private System.Windows.Forms.Timer tmr_Test;
  }
}