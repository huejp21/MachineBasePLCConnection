namespace BASE.FORM
{
  partial class FormTitle
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTitle));
      this.lblTitleTime = new System.Windows.Forms.Label();
      this.btnTitleLogin = new System.Windows.Forms.Button();
      this.imglist_Title = new System.Windows.Forms.ImageList(this.components);
      this.btnTitleBuzzStop = new System.Windows.Forms.Button();
      this.pnlTitleTowerG = new System.Windows.Forms.Panel();
      this.pnlTitleTowerY = new System.Windows.Forms.Panel();
      this.pnlTitleTowerR = new System.Windows.Forms.Panel();
      this.lblTitleRecipe = new System.Windows.Forms.Label();
      this.tmrDisplay = new System.Windows.Forms.Timer(this.components);
      this.pnl_title_PLC = new System.Windows.Forms.Panel();
      this.lblTitleMachineStatus = new System.Windows.Forms.Label();
      this.btnTitleMotor = new System.Windows.Forms.Button();
      this.btnTitleIO = new System.Windows.Forms.Button();
      this.lblTitle_Connect_PLC = new System.Windows.Forms.Label();
      this.lblTitle_Connect_Probe1 = new System.Windows.Forms.Label();
      this.lblTitle_Connect_BCR = new System.Windows.Forms.Label();
      this.lblTitleVersion = new System.Windows.Forms.Label();
      this.lblTitle_Connect_Probe2 = new System.Windows.Forms.Label();
      this.pic_Title_MachineName = new System.Windows.Forms.PictureBox();
      this.lblMachineName = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pic_Title_MachineName)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTitleTime
      // 
      this.lblTitleTime.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitleTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTitleTime.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitleTime.ForeColor = System.Drawing.Color.Black;
      this.lblTitleTime.Location = new System.Drawing.Point(999, 56);
      this.lblTitleTime.Name = "lblTitleTime";
      this.lblTitleTime.Size = new System.Drawing.Size(139, 15);
      this.lblTitleTime.TabIndex = 0;
      this.lblTitleTime.Text = "yyyy/MM/dd hh:mm:ss";
      this.lblTitleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnTitleLogin
      // 
      this.btnTitleLogin.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnTitleLogin.ImageIndex = 2;
      this.btnTitleLogin.ImageList = this.imglist_Title;
      this.btnTitleLogin.Location = new System.Drawing.Point(1144, 0);
      this.btnTitleLogin.Name = "btnTitleLogin";
      this.btnTitleLogin.Size = new System.Drawing.Size(100, 75);
      this.btnTitleLogin.TabIndex = 3;
      this.btnTitleLogin.Text = "Login\r\nHere";
      this.btnTitleLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnTitleLogin.UseVisualStyleBackColor = true;
      this.btnTitleLogin.Click += new System.EventHandler(this.btnTitleLogin_Click);
      // 
      // imglist_Title
      // 
      this.imglist_Title.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Title.ImageStream")));
      this.imglist_Title.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Title.Images.SetKeyName(0, "100p_Buzzer off.png");
      this.imglist_Title.Images.SetKeyName(1, "100p_Business-Businessman-icon.png");
      this.imglist_Title.Images.SetKeyName(2, "100p_Business-Neutral-Decision-icon.png");
      // 
      // btnTitleBuzzStop
      // 
      this.btnTitleBuzzStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnTitleBuzzStop.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnTitleBuzzStop.ForeColor = System.Drawing.Color.Black;
      this.btnTitleBuzzStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnTitleBuzzStop.ImageIndex = 0;
      this.btnTitleBuzzStop.ImageList = this.imglist_Title;
      this.btnTitleBuzzStop.Location = new System.Drawing.Point(132, 0);
      this.btnTitleBuzzStop.Name = "btnTitleBuzzStop";
      this.btnTitleBuzzStop.Size = new System.Drawing.Size(100, 75);
      this.btnTitleBuzzStop.TabIndex = 4;
      this.btnTitleBuzzStop.Text = "BuzzStop";
      this.btnTitleBuzzStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnTitleBuzzStop.UseVisualStyleBackColor = true;
      this.btnTitleBuzzStop.Click += new System.EventHandler(this.btnTitleBuzzStop_Click);
      // 
      // pnlTitleTowerG
      // 
      this.pnlTitleTowerG.BackColor = System.Drawing.Color.DarkGreen;
      this.pnlTitleTowerG.Location = new System.Drawing.Point(1250, 50);
      this.pnlTitleTowerG.Name = "pnlTitleTowerG";
      this.pnlTitleTowerG.Size = new System.Drawing.Size(21, 23);
      this.pnlTitleTowerG.TabIndex = 146;
      // 
      // pnlTitleTowerY
      // 
      this.pnlTitleTowerY.BackColor = System.Drawing.Color.DarkGoldenrod;
      this.pnlTitleTowerY.Location = new System.Drawing.Point(1250, 26);
      this.pnlTitleTowerY.Name = "pnlTitleTowerY";
      this.pnlTitleTowerY.Size = new System.Drawing.Size(21, 23);
      this.pnlTitleTowerY.TabIndex = 145;
      // 
      // pnlTitleTowerR
      // 
      this.pnlTitleTowerR.BackColor = System.Drawing.Color.Maroon;
      this.pnlTitleTowerR.Location = new System.Drawing.Point(1250, 2);
      this.pnlTitleTowerR.Name = "pnlTitleTowerR";
      this.pnlTitleTowerR.Size = new System.Drawing.Size(21, 23);
      this.pnlTitleTowerR.TabIndex = 144;
      // 
      // lblTitleRecipe
      // 
      this.lblTitleRecipe.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitleRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTitleRecipe.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitleRecipe.ForeColor = System.Drawing.Color.Black;
      this.lblTitleRecipe.Location = new System.Drawing.Point(863, 2);
      this.lblTitleRecipe.Name = "lblTitleRecipe";
      this.lblTitleRecipe.Size = new System.Drawing.Size(157, 32);
      this.lblTitleRecipe.TabIndex = 148;
      this.lblTitleRecipe.Text = "Recipe";
      this.lblTitleRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tmrDisplay
      // 
      this.tmrDisplay.Enabled = true;
      this.tmrDisplay.Interval = 1;
      this.tmrDisplay.Tick += new System.EventHandler(this.tmrDisplay_Tick);
      // 
      // pnl_title_PLC
      // 
      this.pnl_title_PLC.Location = new System.Drawing.Point(0, 0);
      this.pnl_title_PLC.Name = "pnl_title_PLC";
      this.pnl_title_PLC.Size = new System.Drawing.Size(10, 75);
      this.pnl_title_PLC.TabIndex = 151;
      // 
      // lblTitleMachineStatus
      // 
      this.lblTitleMachineStatus.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitleMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTitleMachineStatus.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitleMachineStatus.ForeColor = System.Drawing.Color.Black;
      this.lblTitleMachineStatus.Location = new System.Drawing.Point(12, 0);
      this.lblTitleMachineStatus.Name = "lblTitleMachineStatus";
      this.lblTitleMachineStatus.Size = new System.Drawing.Size(114, 75);
      this.lblTitleMachineStatus.TabIndex = 152;
      this.lblTitleMachineStatus.Text = "ErrorStop";
      this.lblTitleMachineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnTitleMotor
      // 
      this.btnTitleMotor.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnTitleMotor.Location = new System.Drawing.Point(234, 0);
      this.btnTitleMotor.Name = "btnTitleMotor";
      this.btnTitleMotor.Size = new System.Drawing.Size(100, 35);
      this.btnTitleMotor.TabIndex = 153;
      this.btnTitleMotor.Text = "Motor";
      this.btnTitleMotor.UseVisualStyleBackColor = true;
      this.btnTitleMotor.Click += new System.EventHandler(this.btnTitleMotor_Click);
      // 
      // btnTitleIO
      // 
      this.btnTitleIO.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnTitleIO.Location = new System.Drawing.Point(234, 40);
      this.btnTitleIO.Name = "btnTitleIO";
      this.btnTitleIO.Size = new System.Drawing.Size(100, 35);
      this.btnTitleIO.TabIndex = 154;
      this.btnTitleIO.Text = "IO";
      this.btnTitleIO.UseVisualStyleBackColor = true;
      this.btnTitleIO.Click += new System.EventHandler(this.btnTitleIO_Click);
      // 
      // lblTitle_Connect_PLC
      // 
      this.lblTitle_Connect_PLC.BackColor = System.Drawing.Color.Red;
      this.lblTitle_Connect_PLC.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitle_Connect_PLC.Location = new System.Drawing.Point(1085, 26);
      this.lblTitle_Connect_PLC.Name = "lblTitle_Connect_PLC";
      this.lblTitle_Connect_PLC.Size = new System.Drawing.Size(53, 22);
      this.lblTitle_Connect_PLC.TabIndex = 2;
      this.lblTitle_Connect_PLC.Text = "PLC";
      this.lblTitle_Connect_PLC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTitle_Connect_Probe1
      // 
      this.lblTitle_Connect_Probe1.BackColor = System.Drawing.Color.Red;
      this.lblTitle_Connect_Probe1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitle_Connect_Probe1.Location = new System.Drawing.Point(1026, 0);
      this.lblTitle_Connect_Probe1.Name = "lblTitle_Connect_Probe1";
      this.lblTitle_Connect_Probe1.Size = new System.Drawing.Size(53, 22);
      this.lblTitle_Connect_Probe1.TabIndex = 1;
      this.lblTitle_Connect_Probe1.Text = "Probe1";
      this.lblTitle_Connect_Probe1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTitle_Connect_BCR
      // 
      this.lblTitle_Connect_BCR.BackColor = System.Drawing.Color.Red;
      this.lblTitle_Connect_BCR.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitle_Connect_BCR.Location = new System.Drawing.Point(1085, 0);
      this.lblTitle_Connect_BCR.Name = "lblTitle_Connect_BCR";
      this.lblTitle_Connect_BCR.Size = new System.Drawing.Size(53, 22);
      this.lblTitle_Connect_BCR.TabIndex = 0;
      this.lblTitle_Connect_BCR.Text = "BCR";
      this.lblTitle_Connect_BCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTitleVersion
      // 
      this.lblTitleVersion.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitleVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTitleVersion.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitleVersion.ForeColor = System.Drawing.Color.Black;
      this.lblTitleVersion.Location = new System.Drawing.Point(863, 41);
      this.lblTitleVersion.Name = "lblTitleVersion";
      this.lblTitleVersion.Size = new System.Drawing.Size(130, 32);
      this.lblTitleVersion.TabIndex = 155;
      this.lblTitleVersion.Text = "20170518_Measure";
      this.lblTitleVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTitle_Connect_Probe2
      // 
      this.lblTitle_Connect_Probe2.BackColor = System.Drawing.Color.Red;
      this.lblTitle_Connect_Probe2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblTitle_Connect_Probe2.Location = new System.Drawing.Point(1026, 26);
      this.lblTitle_Connect_Probe2.Name = "lblTitle_Connect_Probe2";
      this.lblTitle_Connect_Probe2.Size = new System.Drawing.Size(53, 22);
      this.lblTitle_Connect_Probe2.TabIndex = 156;
      this.lblTitle_Connect_Probe2.Text = "Probe2";
      this.lblTitle_Connect_Probe2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pic_Title_MachineName
      // 
      this.pic_Title_MachineName.BackColor = System.Drawing.Color.Transparent;
      this.pic_Title_MachineName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pic_Title_MachineName.Location = new System.Drawing.Point(486, 2);
      this.pic_Title_MachineName.Name = "pic_Title_MachineName";
      this.pic_Title_MachineName.Size = new System.Drawing.Size(321, 61);
      this.pic_Title_MachineName.TabIndex = 157;
      this.pic_Title_MachineName.TabStop = false;
      this.pic_Title_MachineName.DoubleClick += new System.EventHandler(this.pic_Title_MachineName_DoubleClick);
      // 
      // lblMachineName
      // 
      this.lblMachineName.BackColor = System.Drawing.Color.Transparent;
      this.lblMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMachineName.Location = new System.Drawing.Point(486, 2);
      this.lblMachineName.Name = "lblMachineName";
      this.lblMachineName.Size = new System.Drawing.Size(321, 64);
      this.lblMachineName.TabIndex = 158;
      this.lblMachineName.Text = "Machine Name";
      this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblMachineName.DoubleClick += new System.EventHandler(this.lblMachineName_DoubleClick);
      // 
      // FormTitle
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(1274, 75);
      this.ControlBox = false;
      this.Controls.Add(this.lblMachineName);
      this.Controls.Add(this.pic_Title_MachineName);
      this.Controls.Add(this.lblTitle_Connect_Probe2);
      this.Controls.Add(this.lblTitleVersion);
      this.Controls.Add(this.lblTitle_Connect_PLC);
      this.Controls.Add(this.lblTitle_Connect_Probe1);
      this.Controls.Add(this.pnl_title_PLC);
      this.Controls.Add(this.lblTitle_Connect_BCR);
      this.Controls.Add(this.btnTitleIO);
      this.Controls.Add(this.btnTitleMotor);
      this.Controls.Add(this.lblTitleMachineStatus);
      this.Controls.Add(this.lblTitleRecipe);
      this.Controls.Add(this.pnlTitleTowerG);
      this.Controls.Add(this.pnlTitleTowerY);
      this.Controls.Add(this.pnlTitleTowerR);
      this.Controls.Add(this.btnTitleBuzzStop);
      this.Controls.Add(this.btnTitleLogin);
      this.Controls.Add(this.lblTitleTime);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormTitle";
      this.Text = "FRM_Title";
      this.TopMost = true;
      ((System.ComponentModel.ISupportInitialize)(this.pic_Title_MachineName)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblTitleTime;
    private System.Windows.Forms.Button btnTitleLogin;
    private System.Windows.Forms.Button btnTitleBuzzStop;
    internal System.Windows.Forms.Panel pnlTitleTowerG;
    internal System.Windows.Forms.Panel pnlTitleTowerY;
    internal System.Windows.Forms.Panel pnlTitleTowerR;
    private System.Windows.Forms.Label lblTitleRecipe;
    private System.Windows.Forms.Timer tmrDisplay;
    public System.Windows.Forms.Panel pnl_title_PLC;
    private System.Windows.Forms.Label lblTitleMachineStatus;
    private System.Windows.Forms.Button btnTitleMotor;
    private System.Windows.Forms.Button btnTitleIO;
    private System.Windows.Forms.Label lblTitle_Connect_PLC;
    private System.Windows.Forms.Label lblTitle_Connect_Probe1;
    private System.Windows.Forms.Label lblTitle_Connect_BCR;
    private System.Windows.Forms.ImageList imglist_Title;
    private System.Windows.Forms.Label lblTitleVersion;
    private System.Windows.Forms.Label lblTitle_Connect_Probe2;
    private System.Windows.Forms.PictureBox pic_Title_MachineName;
    private System.Windows.Forms.Label lblMachineName;
  }
}