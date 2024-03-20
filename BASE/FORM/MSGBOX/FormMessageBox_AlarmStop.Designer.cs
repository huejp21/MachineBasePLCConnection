namespace BASE.FORM.MSGBOX
{
  partial class FormMessageBox_AlarmStop
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox_AlarmStop));
      this.pnlMessageBoxAlarmStopTop = new System.Windows.Forms.Panel();
      this.lblMessageBoxAlarmStopTitle = new System.Windows.Forms.Label();
      this.pnlMessageBoxAlarmStopCenter = new System.Windows.Forms.Panel();
      this.lblMessageBoxAlarmStopInfo = new System.Windows.Forms.Label();
      this.pnlMessageBoxAlarmStopBottom = new System.Windows.Forms.Panel();
      this.btnMessageBoxAlarmStopBuzzOff = new System.Windows.Forms.Button();
      this.imglist_AlarmStop = new System.Windows.Forms.ImageList(this.components);
      this.btnMessageBoxAlarmStopClose = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.listMessageBoxAlarmStopCurrentAlarm = new System.Windows.Forms.ListBox();
      this.tmr_AlarmStop = new System.Windows.Forms.Timer(this.components);
      this.pnlMessageBoxAlarmStopTop.SuspendLayout();
      this.pnlMessageBoxAlarmStopCenter.SuspendLayout();
      this.pnlMessageBoxAlarmStopBottom.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMessageBoxAlarmStopTop
      // 
      this.pnlMessageBoxAlarmStopTop.Controls.Add(this.lblMessageBoxAlarmStopTitle);
      this.pnlMessageBoxAlarmStopTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMessageBoxAlarmStopTop.Name = "pnlMessageBoxAlarmStopTop";
      this.pnlMessageBoxAlarmStopTop.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxAlarmStopTop.TabIndex = 4;
      // 
      // lblMessageBoxAlarmStopTitle
      // 
      this.lblMessageBoxAlarmStopTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessageBoxAlarmStopTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxAlarmStopTitle.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxAlarmStopTitle.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxAlarmStopTitle.Name = "lblMessageBoxAlarmStopTitle";
      this.lblMessageBoxAlarmStopTitle.Size = new System.Drawing.Size(384, 50);
      this.lblMessageBoxAlarmStopTitle.TabIndex = 0;
      this.lblMessageBoxAlarmStopTitle.Text = "Title";
      this.lblMessageBoxAlarmStopTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlMessageBoxAlarmStopCenter
      // 
      this.pnlMessageBoxAlarmStopCenter.Controls.Add(this.lblMessageBoxAlarmStopInfo);
      this.pnlMessageBoxAlarmStopCenter.Location = new System.Drawing.Point(0, 50);
      this.pnlMessageBoxAlarmStopCenter.Name = "pnlMessageBoxAlarmStopCenter";
      this.pnlMessageBoxAlarmStopCenter.Size = new System.Drawing.Size(384, 161);
      this.pnlMessageBoxAlarmStopCenter.TabIndex = 6;
      // 
      // lblMessageBoxAlarmStopInfo
      // 
      this.lblMessageBoxAlarmStopInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessageBoxAlarmStopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxAlarmStopInfo.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxAlarmStopInfo.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxAlarmStopInfo.Name = "lblMessageBoxAlarmStopInfo";
      this.lblMessageBoxAlarmStopInfo.Size = new System.Drawing.Size(384, 161);
      this.lblMessageBoxAlarmStopInfo.TabIndex = 1;
      this.lblMessageBoxAlarmStopInfo.Text = "Title";
      this.lblMessageBoxAlarmStopInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlMessageBoxAlarmStopBottom
      // 
      this.pnlMessageBoxAlarmStopBottom.Controls.Add(this.btnMessageBoxAlarmStopBuzzOff);
      this.pnlMessageBoxAlarmStopBottom.Controls.Add(this.btnMessageBoxAlarmStopClose);
      this.pnlMessageBoxAlarmStopBottom.Location = new System.Drawing.Point(0, 511);
      this.pnlMessageBoxAlarmStopBottom.Name = "pnlMessageBoxAlarmStopBottom";
      this.pnlMessageBoxAlarmStopBottom.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxAlarmStopBottom.TabIndex = 7;
      // 
      // btnMessageBoxAlarmStopBuzzOff
      // 
      this.btnMessageBoxAlarmStopBuzzOff.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxAlarmStopBuzzOff.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxAlarmStopBuzzOff.ImageIndex = 1;
      this.btnMessageBoxAlarmStopBuzzOff.ImageList = this.imglist_AlarmStop;
      this.btnMessageBoxAlarmStopBuzzOff.Location = new System.Drawing.Point(184, 0);
      this.btnMessageBoxAlarmStopBuzzOff.Name = "btnMessageBoxAlarmStopBuzzOff";
      this.btnMessageBoxAlarmStopBuzzOff.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxAlarmStopBuzzOff.TabIndex = 1;
      this.btnMessageBoxAlarmStopBuzzOff.Text = "Buzz Stop";
      this.btnMessageBoxAlarmStopBuzzOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxAlarmStopBuzzOff.UseVisualStyleBackColor = true;
      this.btnMessageBoxAlarmStopBuzzOff.Click += new System.EventHandler(this.btnMessageBoxAlarmStopBuzzOff_Click);
      // 
      // imglist_AlarmStop
      // 
      this.imglist_AlarmStop.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_AlarmStop.ImageStream")));
      this.imglist_AlarmStop.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_AlarmStop.Images.SetKeyName(0, "100p_Cinema-X-Men-icon.png");
      this.imglist_AlarmStop.Images.SetKeyName(1, "100p_Buzzer off.png");
      // 
      // btnMessageBoxAlarmStopClose
      // 
      this.btnMessageBoxAlarmStopClose.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxAlarmStopClose.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxAlarmStopClose.ImageIndex = 0;
      this.btnMessageBoxAlarmStopClose.ImageList = this.imglist_AlarmStop;
      this.btnMessageBoxAlarmStopClose.Location = new System.Drawing.Point(284, 0);
      this.btnMessageBoxAlarmStopClose.Name = "btnMessageBoxAlarmStopClose";
      this.btnMessageBoxAlarmStopClose.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxAlarmStopClose.TabIndex = 0;
      this.btnMessageBoxAlarmStopClose.Text = "Close";
      this.btnMessageBoxAlarmStopClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxAlarmStopClose.UseVisualStyleBackColor = true;
      this.btnMessageBoxAlarmStopClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMessageBoxAlarmStopClose_MouseDown);
      this.btnMessageBoxAlarmStopClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMessageBoxAlarmStopClose_MouseUp);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.listMessageBoxAlarmStopCurrentAlarm);
      this.panel1.Location = new System.Drawing.Point(0, 211);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(384, 300);
      this.panel1.TabIndex = 8;
      // 
      // listMessageBoxAlarmStopCurrentAlarm
      // 
      this.listMessageBoxAlarmStopCurrentAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listMessageBoxAlarmStopCurrentAlarm.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.listMessageBoxAlarmStopCurrentAlarm.FormattingEnabled = true;
      this.listMessageBoxAlarmStopCurrentAlarm.HorizontalScrollbar = true;
      this.listMessageBoxAlarmStopCurrentAlarm.ItemHeight = 24;
      this.listMessageBoxAlarmStopCurrentAlarm.Location = new System.Drawing.Point(0, 0);
      this.listMessageBoxAlarmStopCurrentAlarm.Name = "listMessageBoxAlarmStopCurrentAlarm";
      this.listMessageBoxAlarmStopCurrentAlarm.ScrollAlwaysVisible = true;
      this.listMessageBoxAlarmStopCurrentAlarm.Size = new System.Drawing.Size(384, 300);
      this.listMessageBoxAlarmStopCurrentAlarm.TabIndex = 0;
      this.listMessageBoxAlarmStopCurrentAlarm.SelectedIndexChanged += new System.EventHandler(this.listMessageBoxAlarmStopCurrentAlarm_SelectedIndexChanged);
      // 
      // tmr_AlarmStop
      // 
      this.tmr_AlarmStop.Enabled = true;
      this.tmr_AlarmStop.Tick += new System.EventHandler(this.tmr_AlarmStop_Tick);
      // 
      // FormMessageBox_AlarmStop
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 561);
      this.ControlBox = false;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pnlMessageBoxAlarmStopTop);
      this.Controls.Add(this.pnlMessageBoxAlarmStopBottom);
      this.Controls.Add(this.pnlMessageBoxAlarmStopCenter);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMessageBox_AlarmStop";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormMessageBox_AlarmStop";
      this.TopMost = true;
      this.pnlMessageBoxAlarmStopTop.ResumeLayout(false);
      this.pnlMessageBoxAlarmStopCenter.ResumeLayout(false);
      this.pnlMessageBoxAlarmStopBottom.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMessageBoxAlarmStopTop;
    private System.Windows.Forms.Label lblMessageBoxAlarmStopTitle;
    private System.Windows.Forms.Panel pnlMessageBoxAlarmStopCenter;
    private System.Windows.Forms.Label lblMessageBoxAlarmStopInfo;
    private System.Windows.Forms.Panel pnlMessageBoxAlarmStopBottom;
    private System.Windows.Forms.Button btnMessageBoxAlarmStopClose;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ListBox listMessageBoxAlarmStopCurrentAlarm;
    private System.Windows.Forms.ImageList imglist_AlarmStop;
    private System.Windows.Forms.Timer tmr_AlarmStop;
    private System.Windows.Forms.Button btnMessageBoxAlarmStopBuzzOff;
  }
}