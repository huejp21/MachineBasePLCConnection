namespace BASE.FORM.MSGBOX
{
  partial class FormMessageBox_Alarm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox_Alarm));
      this.pnlMessageBoxAlarmCenter = new System.Windows.Forms.Panel();
      this.lblMessageBoxAlarmInfo = new System.Windows.Forms.Label();
      this.pnlMessageBoxAlarmBottom = new System.Windows.Forms.Panel();
      this.btnMessageBoxAlarmClose = new System.Windows.Forms.Button();
      this.imglist_Alarm = new System.Windows.Forms.ImageList(this.components);
      this.pnlMessageBoxAlarmTop = new System.Windows.Forms.Panel();
      this.lblMessageBoxAlarmTitle = new System.Windows.Forms.Label();
      this.tmr_Alarm = new System.Windows.Forms.Timer(this.components);
      this.pnlMessageBoxAlarmCenter.SuspendLayout();
      this.pnlMessageBoxAlarmBottom.SuspendLayout();
      this.pnlMessageBoxAlarmTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMessageBoxAlarmCenter
      // 
      this.pnlMessageBoxAlarmCenter.Controls.Add(this.lblMessageBoxAlarmInfo);
      this.pnlMessageBoxAlarmCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMessageBoxAlarmCenter.Location = new System.Drawing.Point(0, 50);
      this.pnlMessageBoxAlarmCenter.Name = "pnlMessageBoxAlarmCenter";
      this.pnlMessageBoxAlarmCenter.Size = new System.Drawing.Size(384, 161);
      this.pnlMessageBoxAlarmCenter.TabIndex = 5;
      // 
      // lblMessageBoxAlarmInfo
      // 
      this.lblMessageBoxAlarmInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblMessageBoxAlarmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxAlarmInfo.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxAlarmInfo.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxAlarmInfo.Name = "lblMessageBoxAlarmInfo";
      this.lblMessageBoxAlarmInfo.Size = new System.Drawing.Size(384, 161);
      this.lblMessageBoxAlarmInfo.TabIndex = 1;
      this.lblMessageBoxAlarmInfo.Text = "Information";
      this.lblMessageBoxAlarmInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlMessageBoxAlarmBottom
      // 
      this.pnlMessageBoxAlarmBottom.Controls.Add(this.btnMessageBoxAlarmClose);
      this.pnlMessageBoxAlarmBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMessageBoxAlarmBottom.Location = new System.Drawing.Point(0, 211);
      this.pnlMessageBoxAlarmBottom.Name = "pnlMessageBoxAlarmBottom";
      this.pnlMessageBoxAlarmBottom.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxAlarmBottom.TabIndex = 4;
      // 
      // btnMessageBoxAlarmClose
      // 
      this.btnMessageBoxAlarmClose.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxAlarmClose.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxAlarmClose.ImageIndex = 0;
      this.btnMessageBoxAlarmClose.ImageList = this.imglist_Alarm;
      this.btnMessageBoxAlarmClose.Location = new System.Drawing.Point(284, 0);
      this.btnMessageBoxAlarmClose.Name = "btnMessageBoxAlarmClose";
      this.btnMessageBoxAlarmClose.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxAlarmClose.TabIndex = 0;
      this.btnMessageBoxAlarmClose.Text = "Close";
      this.btnMessageBoxAlarmClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxAlarmClose.UseVisualStyleBackColor = true;
      this.btnMessageBoxAlarmClose.Click += new System.EventHandler(this.btnMessageBoxAlarmClose_Click);
      // 
      // imglist_Alarm
      // 
      this.imglist_Alarm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Alarm.ImageStream")));
      this.imglist_Alarm.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Alarm.Images.SetKeyName(0, "100p_Cinema-X-Men-icon.png");
      // 
      // pnlMessageBoxAlarmTop
      // 
      this.pnlMessageBoxAlarmTop.Controls.Add(this.lblMessageBoxAlarmTitle);
      this.pnlMessageBoxAlarmTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMessageBoxAlarmTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMessageBoxAlarmTop.Name = "pnlMessageBoxAlarmTop";
      this.pnlMessageBoxAlarmTop.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxAlarmTop.TabIndex = 3;
      // 
      // lblMessageBoxAlarmTitle
      // 
      this.lblMessageBoxAlarmTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessageBoxAlarmTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxAlarmTitle.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxAlarmTitle.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxAlarmTitle.Name = "lblMessageBoxAlarmTitle";
      this.lblMessageBoxAlarmTitle.Size = new System.Drawing.Size(384, 50);
      this.lblMessageBoxAlarmTitle.TabIndex = 0;
      this.lblMessageBoxAlarmTitle.Text = "Title";
      this.lblMessageBoxAlarmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tmr_Alarm
      // 
      this.tmr_Alarm.Enabled = true;
      this.tmr_Alarm.Tick += new System.EventHandler(this.tmr_Alarm_Tick);
      // 
      // FormMessageBox_Alarm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 261);
      this.ControlBox = false;
      this.Controls.Add(this.pnlMessageBoxAlarmCenter);
      this.Controls.Add(this.pnlMessageBoxAlarmBottom);
      this.Controls.Add(this.pnlMessageBoxAlarmTop);
      this.Location = new System.Drawing.Point(0, 600);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMessageBox_Alarm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormMessageBox_Alarm";
      this.TopMost = true;
      this.pnlMessageBoxAlarmCenter.ResumeLayout(false);
      this.pnlMessageBoxAlarmBottom.ResumeLayout(false);
      this.pnlMessageBoxAlarmTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMessageBoxAlarmCenter;
    private System.Windows.Forms.Panel pnlMessageBoxAlarmBottom;
    private System.Windows.Forms.Button btnMessageBoxAlarmClose;
    private System.Windows.Forms.Panel pnlMessageBoxAlarmTop;
    private System.Windows.Forms.Label lblMessageBoxAlarmTitle;
    private System.Windows.Forms.Label lblMessageBoxAlarmInfo;
    private System.Windows.Forms.ImageList imglist_Alarm;
    private System.Windows.Forms.Timer tmr_Alarm;
  }
}