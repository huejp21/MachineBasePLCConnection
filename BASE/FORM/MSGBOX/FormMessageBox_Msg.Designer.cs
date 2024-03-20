namespace BASE.FORM.MSGBOX
{
  partial class FormMessageBox_Msg
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox_Msg));
      this.pnlMessageBoxMsgCenter = new System.Windows.Forms.Panel();
      this.lblMessageBoxMsgInfo = new System.Windows.Forms.Label();
      this.picbMessageBoxMsgIcon = new System.Windows.Forms.PictureBox();
      this.pnlMessageBoxMsgBottom = new System.Windows.Forms.Panel();
      this.btnMessageBoxMsg_3 = new System.Windows.Forms.Button();
      this.imglist_Msg = new System.Windows.Forms.ImageList(this.components);
      this.btnMessageBoxMsg_2 = new System.Windows.Forms.Button();
      this.btnMessageBoxMsg_1 = new System.Windows.Forms.Button();
      this.pnlMessageBoxMsgTop = new System.Windows.Forms.Panel();
      this.lblMessageBoxMsgTitle = new System.Windows.Forms.Label();
      this.tmr_Msg = new System.Windows.Forms.Timer(this.components);
      this.pnlMessageBoxMsgCenter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picbMessageBoxMsgIcon)).BeginInit();
      this.pnlMessageBoxMsgBottom.SuspendLayout();
      this.pnlMessageBoxMsgTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMessageBoxMsgCenter
      // 
      this.pnlMessageBoxMsgCenter.Controls.Add(this.lblMessageBoxMsgInfo);
      this.pnlMessageBoxMsgCenter.Controls.Add(this.picbMessageBoxMsgIcon);
      this.pnlMessageBoxMsgCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMessageBoxMsgCenter.Location = new System.Drawing.Point(0, 50);
      this.pnlMessageBoxMsgCenter.Name = "pnlMessageBoxMsgCenter";
      this.pnlMessageBoxMsgCenter.Size = new System.Drawing.Size(384, 162);
      this.pnlMessageBoxMsgCenter.TabIndex = 8;
      // 
      // lblMessageBoxMsgInfo
      // 
      this.lblMessageBoxMsgInfo.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxMsgInfo.Location = new System.Drawing.Point(3, 62);
      this.lblMessageBoxMsgInfo.Name = "lblMessageBoxMsgInfo";
      this.lblMessageBoxMsgInfo.Size = new System.Drawing.Size(378, 97);
      this.lblMessageBoxMsgInfo.TabIndex = 1;
      this.lblMessageBoxMsgInfo.Text = "Title";
      this.lblMessageBoxMsgInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // picbMessageBoxMsgIcon
      // 
      this.picbMessageBoxMsgIcon.Location = new System.Drawing.Point(5, 6);
      this.picbMessageBoxMsgIcon.Name = "picbMessageBoxMsgIcon";
      this.picbMessageBoxMsgIcon.Size = new System.Drawing.Size(63, 53);
      this.picbMessageBoxMsgIcon.TabIndex = 0;
      this.picbMessageBoxMsgIcon.TabStop = false;
      // 
      // pnlMessageBoxMsgBottom
      // 
      this.pnlMessageBoxMsgBottom.Controls.Add(this.btnMessageBoxMsg_3);
      this.pnlMessageBoxMsgBottom.Controls.Add(this.btnMessageBoxMsg_2);
      this.pnlMessageBoxMsgBottom.Controls.Add(this.btnMessageBoxMsg_1);
      this.pnlMessageBoxMsgBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMessageBoxMsgBottom.Location = new System.Drawing.Point(0, 212);
      this.pnlMessageBoxMsgBottom.Name = "pnlMessageBoxMsgBottom";
      this.pnlMessageBoxMsgBottom.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxMsgBottom.TabIndex = 7;
      // 
      // btnMessageBoxMsg_3
      // 
      this.btnMessageBoxMsg_3.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxMsg_3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxMsg_3.ImageIndex = 1;
      this.btnMessageBoxMsg_3.ImageList = this.imglist_Msg;
      this.btnMessageBoxMsg_3.Location = new System.Drawing.Point(114, 0);
      this.btnMessageBoxMsg_3.Name = "btnMessageBoxMsg_3";
      this.btnMessageBoxMsg_3.Size = new System.Drawing.Size(90, 50);
      this.btnMessageBoxMsg_3.TabIndex = 2;
      this.btnMessageBoxMsg_3.Text = "Caption3";
      this.btnMessageBoxMsg_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxMsg_3.UseVisualStyleBackColor = true;
      this.btnMessageBoxMsg_3.Click += new System.EventHandler(this.btnMessageBoxMsg_3_Click);
      // 
      // imglist_Msg
      // 
      this.imglist_Msg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Msg.ImageStream")));
      this.imglist_Msg.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Msg.Images.SetKeyName(0, "100p_Cinema-X-Men-icon.png");
      this.imglist_Msg.Images.SetKeyName(1, "100p_success-icon.png");
      this.imglist_Msg.Images.SetKeyName(2, "100p_prohibit-icon.png");
      this.imglist_Msg.Images.SetKeyName(3, "100p_alert-icon.png");
      this.imglist_Msg.Images.SetKeyName(4, "100p_cancel-icon.png");
      this.imglist_Msg.Images.SetKeyName(5, "100p_Computer-Hardware-Restart-icon.png");
      // 
      // btnMessageBoxMsg_2
      // 
      this.btnMessageBoxMsg_2.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxMsg_2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxMsg_2.ImageIndex = 2;
      this.btnMessageBoxMsg_2.ImageList = this.imglist_Msg;
      this.btnMessageBoxMsg_2.Location = new System.Drawing.Point(204, 0);
      this.btnMessageBoxMsg_2.Name = "btnMessageBoxMsg_2";
      this.btnMessageBoxMsg_2.Size = new System.Drawing.Size(90, 50);
      this.btnMessageBoxMsg_2.TabIndex = 1;
      this.btnMessageBoxMsg_2.Text = "Caption2";
      this.btnMessageBoxMsg_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxMsg_2.UseVisualStyleBackColor = true;
      this.btnMessageBoxMsg_2.Click += new System.EventHandler(this.btnMessageBoxMsg_2_Click);
      // 
      // btnMessageBoxMsg_1
      // 
      this.btnMessageBoxMsg_1.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxMsg_1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxMsg_1.ImageIndex = 0;
      this.btnMessageBoxMsg_1.ImageList = this.imglist_Msg;
      this.btnMessageBoxMsg_1.Location = new System.Drawing.Point(294, 0);
      this.btnMessageBoxMsg_1.Name = "btnMessageBoxMsg_1";
      this.btnMessageBoxMsg_1.Size = new System.Drawing.Size(90, 50);
      this.btnMessageBoxMsg_1.TabIndex = 0;
      this.btnMessageBoxMsg_1.Text = "Caption1";
      this.btnMessageBoxMsg_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxMsg_1.UseVisualStyleBackColor = true;
      this.btnMessageBoxMsg_1.Click += new System.EventHandler(this.btnMessageBoxMsg_1_Click);
      // 
      // pnlMessageBoxMsgTop
      // 
      this.pnlMessageBoxMsgTop.Controls.Add(this.lblMessageBoxMsgTitle);
      this.pnlMessageBoxMsgTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMessageBoxMsgTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMessageBoxMsgTop.Name = "pnlMessageBoxMsgTop";
      this.pnlMessageBoxMsgTop.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxMsgTop.TabIndex = 6;
      // 
      // lblMessageBoxMsgTitle
      // 
      this.lblMessageBoxMsgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxMsgTitle.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxMsgTitle.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxMsgTitle.Name = "lblMessageBoxMsgTitle";
      this.lblMessageBoxMsgTitle.Size = new System.Drawing.Size(384, 50);
      this.lblMessageBoxMsgTitle.TabIndex = 0;
      this.lblMessageBoxMsgTitle.Text = "Title";
      this.lblMessageBoxMsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tmr_Msg
      // 
      this.tmr_Msg.Enabled = true;
      this.tmr_Msg.Tick += new System.EventHandler(this.tmr_Msg_Tick);
      // 
      // FormMessageBox_Msg
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 262);
      this.ControlBox = false;
      this.Controls.Add(this.pnlMessageBoxMsgCenter);
      this.Controls.Add(this.pnlMessageBoxMsgBottom);
      this.Controls.Add(this.pnlMessageBoxMsgTop);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMessageBox_Msg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Message Dialog Box";
      this.TopMost = true;
      this.pnlMessageBoxMsgCenter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picbMessageBoxMsgIcon)).EndInit();
      this.pnlMessageBoxMsgBottom.ResumeLayout(false);
      this.pnlMessageBoxMsgTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMessageBoxMsgCenter;
    private System.Windows.Forms.Panel pnlMessageBoxMsgBottom;
    private System.Windows.Forms.Button btnMessageBoxMsg_2;
    private System.Windows.Forms.Button btnMessageBoxMsg_1;
    private System.Windows.Forms.Panel pnlMessageBoxMsgTop;
    private System.Windows.Forms.Label lblMessageBoxMsgTitle;
    private System.Windows.Forms.PictureBox picbMessageBoxMsgIcon;
    private System.Windows.Forms.Button btnMessageBoxMsg_3;
    private System.Windows.Forms.Label lblMessageBoxMsgInfo;
    private System.Windows.Forms.ImageList imglist_Msg;
    private System.Windows.Forms.Timer tmr_Msg;
  }
}