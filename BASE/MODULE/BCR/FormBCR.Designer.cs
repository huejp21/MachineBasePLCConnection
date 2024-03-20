namespace BASE.MODULE.BCR
{
  partial class FormBCR
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
      this.picBCR = new System.Windows.Forms.PictureBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      this.btnDisconnect = new System.Windows.Forms.Button();
      this.btnLiveOff = new System.Windows.Forms.Button();
      this.btnLiveOn = new System.Windows.Forms.Button();
      this.btnRead = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.btnSaveROI = new System.Windows.Forms.Button();
      this.tmr_BCR = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.lblReadingTime = new System.Windows.Forms.Label();
      this.btnROI_MLeft = new System.Windows.Forms.Button();
      this.btnROI_VBig = new System.Windows.Forms.Button();
      this.btnROI_MUp = new System.Windows.Forms.Button();
      this.btnROI_VSmall = new System.Windows.Forms.Button();
      this.btnROI_MRight = new System.Windows.Forms.Button();
      this.btnROI_HSmall = new System.Windows.Forms.Button();
      this.btnROI_MDown = new System.Windows.Forms.Button();
      this.btnROI_HBig = new System.Windows.Forms.Button();
      this.btnROI_Reset = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.picBCR)).BeginInit();
      this.SuspendLayout();
      // 
      // picBCR
      // 
      this.picBCR.Location = new System.Drawing.Point(10, 10);
      this.picBCR.Name = "picBCR";
      this.picBCR.Size = new System.Drawing.Size(640, 480);
      this.picBCR.TabIndex = 0;
      this.picBCR.TabStop = false;
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(656, 450);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(183, 40);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(656, 328);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(90, 51);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnDisconnect
      // 
      this.btnDisconnect.Location = new System.Drawing.Point(752, 328);
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.Size = new System.Drawing.Size(90, 51);
      this.btnDisconnect.TabIndex = 3;
      this.btnDisconnect.Text = "Disconnect";
      this.btnDisconnect.UseVisualStyleBackColor = true;
      this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
      // 
      // btnLiveOff
      // 
      this.btnLiveOff.Location = new System.Drawing.Point(752, 10);
      this.btnLiveOff.Name = "btnLiveOff";
      this.btnLiveOff.Size = new System.Drawing.Size(90, 51);
      this.btnLiveOff.TabIndex = 5;
      this.btnLiveOff.Text = "Live Off";
      this.btnLiveOff.UseVisualStyleBackColor = true;
      this.btnLiveOff.Click += new System.EventHandler(this.btnLiveOff_Click);
      // 
      // btnLiveOn
      // 
      this.btnLiveOn.Location = new System.Drawing.Point(656, 10);
      this.btnLiveOn.Name = "btnLiveOn";
      this.btnLiveOn.Size = new System.Drawing.Size(90, 51);
      this.btnLiveOn.TabIndex = 4;
      this.btnLiveOn.Text = "Live On";
      this.btnLiveOn.UseVisualStyleBackColor = true;
      this.btnLiveOn.Click += new System.EventHandler(this.btnLiveOn_Click);
      // 
      // btnRead
      // 
      this.btnRead.Location = new System.Drawing.Point(656, 67);
      this.btnRead.Name = "btnRead";
      this.btnRead.Size = new System.Drawing.Size(186, 51);
      this.btnRead.TabIndex = 6;
      this.btnRead.Text = "Read Onece";
      this.btnRead.UseVisualStyleBackColor = true;
      this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(656, 423);
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(183, 21);
      this.txtResult.TabIndex = 7;
      // 
      // btnSaveROI
      // 
      this.btnSaveROI.Location = new System.Drawing.Point(656, 271);
      this.btnSaveROI.Name = "btnSaveROI";
      this.btnSaveROI.Size = new System.Drawing.Size(186, 51);
      this.btnSaveROI.TabIndex = 8;
      this.btnSaveROI.Text = "Save ROI";
      this.btnSaveROI.UseVisualStyleBackColor = true;
      this.btnSaveROI.Click += new System.EventHandler(this.btnSaveROI_Click);
      // 
      // tmr_BCR
      // 
      this.tmr_BCR.Enabled = true;
      this.tmr_BCR.Interval = 1;
      this.tmr_BCR.Tick += new System.EventHandler(this.tmr_BCR_Tick);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(654, 408);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 12);
      this.label1.TabIndex = 9;
      this.label1.Text = "Reading Time:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblReadingTime
      // 
      this.lblReadingTime.Location = new System.Drawing.Point(751, 408);
      this.lblReadingTime.Name = "lblReadingTime";
      this.lblReadingTime.Size = new System.Drawing.Size(88, 12);
      this.lblReadingTime.TabIndex = 10;
      this.lblReadingTime.Text = "0000.0000m/s";
      this.lblReadingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnROI_MLeft
      // 
      this.btnROI_MLeft.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_MLeft.Location = new System.Drawing.Point(684, 174);
      this.btnROI_MLeft.Name = "btnROI_MLeft";
      this.btnROI_MLeft.Size = new System.Drawing.Size(40, 40);
      this.btnROI_MLeft.TabIndex = 11;
      this.btnROI_MLeft.Text = "←";
      this.btnROI_MLeft.UseVisualStyleBackColor = true;
      this.btnROI_MLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_MLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_VBig
      // 
      this.btnROI_VBig.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_VBig.Location = new System.Drawing.Point(776, 128);
      this.btnROI_VBig.Name = "btnROI_VBig";
      this.btnROI_VBig.Size = new System.Drawing.Size(40, 40);
      this.btnROI_VBig.TabIndex = 12;
      this.btnROI_VBig.Text = "▲";
      this.btnROI_VBig.UseVisualStyleBackColor = true;
      this.btnROI_VBig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_VBig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_MUp
      // 
      this.btnROI_MUp.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_MUp.Location = new System.Drawing.Point(730, 128);
      this.btnROI_MUp.Name = "btnROI_MUp";
      this.btnROI_MUp.Size = new System.Drawing.Size(40, 40);
      this.btnROI_MUp.TabIndex = 13;
      this.btnROI_MUp.Text = "↑";
      this.btnROI_MUp.UseVisualStyleBackColor = true;
      this.btnROI_MUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_MUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_VSmall
      // 
      this.btnROI_VSmall.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_VSmall.Location = new System.Drawing.Point(684, 128);
      this.btnROI_VSmall.Name = "btnROI_VSmall";
      this.btnROI_VSmall.Size = new System.Drawing.Size(40, 40);
      this.btnROI_VSmall.TabIndex = 14;
      this.btnROI_VSmall.Text = "▼";
      this.btnROI_VSmall.UseVisualStyleBackColor = true;
      this.btnROI_VSmall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_VSmall.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_MRight
      // 
      this.btnROI_MRight.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_MRight.Location = new System.Drawing.Point(776, 174);
      this.btnROI_MRight.Name = "btnROI_MRight";
      this.btnROI_MRight.Size = new System.Drawing.Size(40, 40);
      this.btnROI_MRight.TabIndex = 15;
      this.btnROI_MRight.Text = "→";
      this.btnROI_MRight.UseVisualStyleBackColor = true;
      this.btnROI_MRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_MRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_HSmall
      // 
      this.btnROI_HSmall.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_HSmall.Location = new System.Drawing.Point(684, 220);
      this.btnROI_HSmall.Name = "btnROI_HSmall";
      this.btnROI_HSmall.Size = new System.Drawing.Size(40, 40);
      this.btnROI_HSmall.TabIndex = 16;
      this.btnROI_HSmall.Text = "◀";
      this.btnROI_HSmall.UseVisualStyleBackColor = true;
      this.btnROI_HSmall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_HSmall.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_MDown
      // 
      this.btnROI_MDown.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_MDown.Location = new System.Drawing.Point(730, 220);
      this.btnROI_MDown.Name = "btnROI_MDown";
      this.btnROI_MDown.Size = new System.Drawing.Size(40, 40);
      this.btnROI_MDown.TabIndex = 17;
      this.btnROI_MDown.Text = "↓";
      this.btnROI_MDown.UseVisualStyleBackColor = true;
      this.btnROI_MDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_MDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_HBig
      // 
      this.btnROI_HBig.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_HBig.Location = new System.Drawing.Point(776, 220);
      this.btnROI_HBig.Name = "btnROI_HBig";
      this.btnROI_HBig.Size = new System.Drawing.Size(40, 40);
      this.btnROI_HBig.TabIndex = 18;
      this.btnROI_HBig.Text = "▶";
      this.btnROI_HBig.UseVisualStyleBackColor = true;
      this.btnROI_HBig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseDown);
      this.btnROI_HBig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnROI_MouseUp);
      // 
      // btnROI_Reset
      // 
      this.btnROI_Reset.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnROI_Reset.Location = new System.Drawing.Point(730, 174);
      this.btnROI_Reset.Name = "btnROI_Reset";
      this.btnROI_Reset.Size = new System.Drawing.Size(40, 40);
      this.btnROI_Reset.TabIndex = 19;
      this.btnROI_Reset.Text = "●";
      this.btnROI_Reset.UseVisualStyleBackColor = true;
      this.btnROI_Reset.Click += new System.EventHandler(this.btnROI_Reset_Click);
      // 
      // FormBCR
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(849, 502);
      this.ControlBox = false;
      this.Controls.Add(this.btnROI_Reset);
      this.Controls.Add(this.btnROI_HBig);
      this.Controls.Add(this.btnROI_MDown);
      this.Controls.Add(this.btnROI_HSmall);
      this.Controls.Add(this.btnROI_MRight);
      this.Controls.Add(this.btnROI_VSmall);
      this.Controls.Add(this.btnROI_MUp);
      this.Controls.Add(this.btnROI_VBig);
      this.Controls.Add(this.btnROI_MLeft);
      this.Controls.Add(this.lblReadingTime);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnSaveROI);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnRead);
      this.Controls.Add(this.btnLiveOff);
      this.Controls.Add(this.btnLiveOn);
      this.Controls.Add(this.btnDisconnect);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.picBCR);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormBCR";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormBCR";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.FormBCR_Load);
      this.Shown += new System.EventHandler(this.FormBCR_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormBCR_VisibleChanged);
      ((System.ComponentModel.ISupportInitialize)(this.picBCR)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picBCR;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnDisconnect;
    private System.Windows.Forms.Button btnLiveOff;
    private System.Windows.Forms.Button btnLiveOn;
    private System.Windows.Forms.Button btnRead;
    private System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnSaveROI;
    private System.Windows.Forms.Timer tmr_BCR;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblReadingTime;
    private System.Windows.Forms.Button btnROI_MLeft;
    private System.Windows.Forms.Button btnROI_VBig;
    private System.Windows.Forms.Button btnROI_MUp;
    private System.Windows.Forms.Button btnROI_VSmall;
    private System.Windows.Forms.Button btnROI_MRight;
    private System.Windows.Forms.Button btnROI_HSmall;
    private System.Windows.Forms.Button btnROI_MDown;
    private System.Windows.Forms.Button btnROI_HBig;
    private System.Windows.Forms.Button btnROI_Reset;
  }
}