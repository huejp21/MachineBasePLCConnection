namespace BASE.FORM
{
  partial class FormNavigation
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNavigation));
      this.btnNavigationExit = new System.Windows.Forms.Button();
      this.imglist_Navigation = new System.Windows.Forms.ImageList(this.components);
      this.btnNavigationAuto = new System.Windows.Forms.Button();
      this.btnNavigationManual = new System.Windows.Forms.Button();
      this.btnNavigationRecipe = new System.Windows.Forms.Button();
      this.btnNavigationDatalog = new System.Windows.Forms.Button();
      this.btnNavigationSetup = new System.Windows.Forms.Button();
      this.btnNavigationAlarm = new System.Windows.Forms.Button();
      this.btnNavigationDebug = new System.Windows.Forms.Button();
      this.tmr_Navigation = new System.Windows.Forms.Timer(this.components);
      this.statusStrip_ = new System.Windows.Forms.StatusStrip();
      this.lblStatusStrip_Notice = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblStatusStrip_Image1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblStatusStrip_Connection = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblStatusStrip_Alarm = new System.Windows.Forms.ToolStripStatusLabel();
      this.pnl_Navigation_Back = new System.Windows.Forms.Panel();
      this.btnNavigationTestCycle = new System.Windows.Forms.Button();
      this.lmgList_Connection = new System.Windows.Forms.ImageList(this.components);
      this.ImgList_Button = new System.Windows.Forms.ImageList(this.components);
      this.statusStrip_.SuspendLayout();
      this.pnl_Navigation_Back.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnNavigationExit
      // 
      this.btnNavigationExit.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationExit.BackgroundImage")));
      this.btnNavigationExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationExit.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationExit.ImageIndex = 8;
      this.btnNavigationExit.ImageList = this.imglist_Navigation;
      this.btnNavigationExit.Location = new System.Drawing.Point(1174, 0);
      this.btnNavigationExit.Name = "btnNavigationExit";
      this.btnNavigationExit.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationExit.TabIndex = 0;
      this.btnNavigationExit.Text = "Exit";
      this.btnNavigationExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationExit.UseVisualStyleBackColor = false;
      this.btnNavigationExit.Click += new System.EventHandler(this.btn_navigation_exit_Click);
      // 
      // imglist_Navigation
      // 
      this.imglist_Navigation.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Navigation.ImageStream")));
      this.imglist_Navigation.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Navigation.Images.SetKeyName(0, "100p_Industry-Factory-icon.png");
      this.imglist_Navigation.Images.SetKeyName(1, "100p_Files-View-File-icon.png");
      this.imglist_Navigation.Images.SetKeyName(2, "100p_Very-Basic-Support-icon.png");
      this.imglist_Navigation.Images.SetKeyName(3, "100p_Industry-Automatic-icon.png");
      this.imglist_Navigation.Images.SetKeyName(4, "100p_Business-Statistics-icon.png");
      this.imglist_Navigation.Images.SetKeyName(5, "100p_City-Siren-icon.png");
      this.imglist_Navigation.Images.SetKeyName(6, "100p_faq-icon.png");
      this.imglist_Navigation.Images.SetKeyName(7, "100p_Programming-Bug-icon.png");
      this.imglist_Navigation.Images.SetKeyName(8, "100p_delete-icon.png");
      // 
      // btnNavigationAuto
      // 
      this.btnNavigationAuto.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationAuto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationAuto.BackgroundImage")));
      this.btnNavigationAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationAuto.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationAuto.ImageIndex = 0;
      this.btnNavigationAuto.ImageList = this.imglist_Navigation;
      this.btnNavigationAuto.Location = new System.Drawing.Point(0, 0);
      this.btnNavigationAuto.Name = "btnNavigationAuto";
      this.btnNavigationAuto.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationAuto.TabIndex = 1;
      this.btnNavigationAuto.Text = "Auto";
      this.btnNavigationAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationAuto.UseVisualStyleBackColor = false;
      this.btnNavigationAuto.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationManual
      // 
      this.btnNavigationManual.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationManual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationManual.BackgroundImage")));
      this.btnNavigationManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationManual.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationManual.ImageIndex = 2;
      this.btnNavigationManual.ImageList = this.imglist_Navigation;
      this.btnNavigationManual.Location = new System.Drawing.Point(200, 0);
      this.btnNavigationManual.Name = "btnNavigationManual";
      this.btnNavigationManual.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationManual.TabIndex = 20;
      this.btnNavigationManual.Text = "Manual";
      this.btnNavigationManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationManual.UseVisualStyleBackColor = false;
      this.btnNavigationManual.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationRecipe
      // 
      this.btnNavigationRecipe.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationRecipe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationRecipe.BackgroundImage")));
      this.btnNavigationRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationRecipe.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationRecipe.ImageIndex = 1;
      this.btnNavigationRecipe.ImageList = this.imglist_Navigation;
      this.btnNavigationRecipe.Location = new System.Drawing.Point(100, -1);
      this.btnNavigationRecipe.Name = "btnNavigationRecipe";
      this.btnNavigationRecipe.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationRecipe.TabIndex = 3;
      this.btnNavigationRecipe.Text = "Recipe";
      this.btnNavigationRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationRecipe.UseVisualStyleBackColor = false;
      this.btnNavigationRecipe.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationDatalog
      // 
      this.btnNavigationDatalog.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationDatalog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationDatalog.BackgroundImage")));
      this.btnNavigationDatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationDatalog.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationDatalog.ImageIndex = 4;
      this.btnNavigationDatalog.ImageList = this.imglist_Navigation;
      this.btnNavigationDatalog.Location = new System.Drawing.Point(824, 0);
      this.btnNavigationDatalog.Name = "btnNavigationDatalog";
      this.btnNavigationDatalog.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationDatalog.TabIndex = 4;
      this.btnNavigationDatalog.Text = "Datalog";
      this.btnNavigationDatalog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationDatalog.UseVisualStyleBackColor = false;
      this.btnNavigationDatalog.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationSetup
      // 
      this.btnNavigationSetup.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationSetup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationSetup.BackgroundImage")));
      this.btnNavigationSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationSetup.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationSetup.ImageIndex = 3;
      this.btnNavigationSetup.ImageList = this.imglist_Navigation;
      this.btnNavigationSetup.Location = new System.Drawing.Point(300, 0);
      this.btnNavigationSetup.Name = "btnNavigationSetup";
      this.btnNavigationSetup.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationSetup.TabIndex = 5;
      this.btnNavigationSetup.Text = "Setup";
      this.btnNavigationSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationSetup.UseVisualStyleBackColor = false;
      this.btnNavigationSetup.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationAlarm
      // 
      this.btnNavigationAlarm.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationAlarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationAlarm.BackgroundImage")));
      this.btnNavigationAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationAlarm.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationAlarm.ImageIndex = 5;
      this.btnNavigationAlarm.ImageList = this.imglist_Navigation;
      this.btnNavigationAlarm.Location = new System.Drawing.Point(924, 0);
      this.btnNavigationAlarm.Name = "btnNavigationAlarm";
      this.btnNavigationAlarm.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationAlarm.TabIndex = 6;
      this.btnNavigationAlarm.Text = "Alarm";
      this.btnNavigationAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationAlarm.UseVisualStyleBackColor = false;
      this.btnNavigationAlarm.Click += new System.EventHandler(this.btnClick);
      // 
      // btnNavigationDebug
      // 
      this.btnNavigationDebug.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationDebug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationDebug.BackgroundImage")));
      this.btnNavigationDebug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationDebug.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationDebug.ImageIndex = 7;
      this.btnNavigationDebug.ImageList = this.imglist_Navigation;
      this.btnNavigationDebug.Location = new System.Drawing.Point(1074, 0);
      this.btnNavigationDebug.Name = "btnNavigationDebug";
      this.btnNavigationDebug.Size = new System.Drawing.Size(100, 75);
      this.btnNavigationDebug.TabIndex = 8;
      this.btnNavigationDebug.Text = "Debug";
      this.btnNavigationDebug.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationDebug.UseVisualStyleBackColor = false;
      this.btnNavigationDebug.Click += new System.EventHandler(this.btnClick);
      // 
      // tmr_Navigation
      // 
      this.tmr_Navigation.Enabled = true;
      this.tmr_Navigation.Tick += new System.EventHandler(this.tmr_Navigation_Tick);
      // 
      // statusStrip_
      // 
      this.statusStrip_.AutoSize = false;
      this.statusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusStrip_Notice,
            this.toolStripStatusLabel1,
            this.lblStatusStrip_Image1,
            this.lblStatusStrip_Connection,
            this.lblStatusStrip_Alarm});
      this.statusStrip_.Location = new System.Drawing.Point(0, 78);
      this.statusStrip_.Name = "statusStrip_";
      this.statusStrip_.Size = new System.Drawing.Size(1274, 22);
      this.statusStrip_.TabIndex = 21;
      this.statusStrip_.Text = "statusStrip1";
      // 
      // lblStatusStrip_Notice
      // 
      this.lblStatusStrip_Notice.AutoSize = false;
      this.lblStatusStrip_Notice.Name = "lblStatusStrip_Notice";
      this.lblStatusStrip_Notice.Size = new System.Drawing.Size(300, 17);
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // lblStatusStrip_Image1
      // 
      this.lblStatusStrip_Image1.AutoSize = false;
      this.lblStatusStrip_Image1.Name = "lblStatusStrip_Image1";
      this.lblStatusStrip_Image1.Size = new System.Drawing.Size(17, 17);
      // 
      // lblStatusStrip_Connection
      // 
      this.lblStatusStrip_Connection.AutoSize = false;
      this.lblStatusStrip_Connection.Name = "lblStatusStrip_Connection";
      this.lblStatusStrip_Connection.Size = new System.Drawing.Size(100, 17);
      this.lblStatusStrip_Connection.Text = "Disconnected";
      // 
      // lblStatusStrip_Alarm
      // 
      this.lblStatusStrip_Alarm.AutoSize = false;
      this.lblStatusStrip_Alarm.Name = "lblStatusStrip_Alarm";
      this.lblStatusStrip_Alarm.Size = new System.Drawing.Size(500, 17);
      // 
      // pnl_Navigation_Back
      // 
      this.pnl_Navigation_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationTestCycle);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationAlarm);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationDebug);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationDatalog);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationSetup);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationAuto);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationManual);
      this.pnl_Navigation_Back.Controls.Add(this.btnNavigationRecipe);
      this.pnl_Navigation_Back.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnl_Navigation_Back.Location = new System.Drawing.Point(0, 0);
      this.pnl_Navigation_Back.Name = "pnl_Navigation_Back";
      this.pnl_Navigation_Back.Size = new System.Drawing.Size(1274, 75);
      this.pnl_Navigation_Back.TabIndex = 22;
      // 
      // btnNavigationTestCycle
      // 
      this.btnNavigationTestCycle.BackColor = System.Drawing.Color.Transparent;
      this.btnNavigationTestCycle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavigationTestCycle.BackgroundImage")));
      this.btnNavigationTestCycle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnNavigationTestCycle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnNavigationTestCycle.Location = new System.Drawing.Point(1024, 0);
      this.btnNavigationTestCycle.Name = "btnNavigationTestCycle";
      this.btnNavigationTestCycle.Size = new System.Drawing.Size(50, 75);
      this.btnNavigationTestCycle.TabIndex = 21;
      this.btnNavigationTestCycle.Text = "Test";
      this.btnNavigationTestCycle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnNavigationTestCycle.UseVisualStyleBackColor = false;
      this.btnNavigationTestCycle.Click += new System.EventHandler(this.btnClick);
      // 
      // lmgList_Connection
      // 
      this.lmgList_Connection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lmgList_Connection.ImageStream")));
      this.lmgList_Connection.TransparentColor = System.Drawing.Color.Transparent;
      this.lmgList_Connection.Images.SetKeyName(0, "conn16_V1.ico");
      this.lmgList_Connection.Images.SetKeyName(1, "conn20_V1.bmp");
      // 
      // ImgList_Button
      // 
      this.ImgList_Button.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList_Button.ImageStream")));
      this.ImgList_Button.TransparentColor = System.Drawing.Color.Transparent;
      this.ImgList_Button.Images.SetKeyName(0, "Bottom_Button_Back.png");
      this.ImgList_Button.Images.SetKeyName(1, "Bottom_Button_Back_On.png");
      // 
      // FormNavigation
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(1274, 100);
      this.Controls.Add(this.statusStrip_);
      this.Controls.Add(this.btnNavigationExit);
      this.Controls.Add(this.pnl_Navigation_Back);
      this.ForeColor = System.Drawing.Color.Black;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormNavigation";
      this.Text = "FRM_Navigation";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.FormNavigation_Load);
      this.statusStrip_.ResumeLayout(false);
      this.statusStrip_.PerformLayout();
      this.pnl_Navigation_Back.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnNavigationExit;
    private System.Windows.Forms.Button btnNavigationAuto;
    private System.Windows.Forms.Button btnNavigationManual;
    private System.Windows.Forms.Button btnNavigationRecipe;
    private System.Windows.Forms.Button btnNavigationDatalog;
    private System.Windows.Forms.Button btnNavigationSetup;
    private System.Windows.Forms.Button btnNavigationAlarm;
    private System.Windows.Forms.Button btnNavigationDebug;
    private System.Windows.Forms.Timer tmr_Navigation;
    private System.Windows.Forms.ImageList imglist_Navigation;
    private System.Windows.Forms.StatusStrip statusStrip_;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip_Notice;
    private System.Windows.Forms.Panel pnl_Navigation_Back;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip_Connection;
    private System.Windows.Forms.ImageList lmgList_Connection;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip_Image1;
    private System.Windows.Forms.Button btnNavigationTestCycle;
    private System.Windows.Forms.ImageList ImgList_Button;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip_Alarm;

  }
}