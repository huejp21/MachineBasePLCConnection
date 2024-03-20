namespace BASE.FORM.MSGBOX
{
  partial class FormMessageBox_Info
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox_Info));
      this.pnlMessageBoxInfoTop = new System.Windows.Forms.Panel();
      this.lblMessageBoxInfoTitle = new System.Windows.Forms.Label();
      this.pnlMessageBoxInfoBottom = new System.Windows.Forms.Panel();
      this.btnMessageBoxInfoClose = new System.Windows.Forms.Button();
      this.imglist_Info = new System.Windows.Forms.ImageList(this.components);
      this.pnlMessageBoxInfoCenter = new System.Windows.Forms.Panel();
      this.ttmr_Info = new System.Windows.Forms.Timer(this.components);
      this.pnlMessageBoxInfoTop.SuspendLayout();
      this.pnlMessageBoxInfoBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMessageBoxInfoTop
      // 
      this.pnlMessageBoxInfoTop.Controls.Add(this.lblMessageBoxInfoTitle);
      this.pnlMessageBoxInfoTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMessageBoxInfoTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMessageBoxInfoTop.Name = "pnlMessageBoxInfoTop";
      this.pnlMessageBoxInfoTop.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxInfoTop.TabIndex = 0;
      // 
      // lblMessageBoxInfoTitle
      // 
      this.lblMessageBoxInfoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxInfoTitle.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblMessageBoxInfoTitle.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxInfoTitle.Name = "lblMessageBoxInfoTitle";
      this.lblMessageBoxInfoTitle.Size = new System.Drawing.Size(384, 50);
      this.lblMessageBoxInfoTitle.TabIndex = 0;
      this.lblMessageBoxInfoTitle.Text = "Title";
      this.lblMessageBoxInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlMessageBoxInfoBottom
      // 
      this.pnlMessageBoxInfoBottom.Controls.Add(this.btnMessageBoxInfoClose);
      this.pnlMessageBoxInfoBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMessageBoxInfoBottom.Location = new System.Drawing.Point(0, 212);
      this.pnlMessageBoxInfoBottom.Name = "pnlMessageBoxInfoBottom";
      this.pnlMessageBoxInfoBottom.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxInfoBottom.TabIndex = 1;
      // 
      // btnMessageBoxInfoClose
      // 
      this.btnMessageBoxInfoClose.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxInfoClose.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxInfoClose.ImageIndex = 0;
      this.btnMessageBoxInfoClose.ImageList = this.imglist_Info;
      this.btnMessageBoxInfoClose.Location = new System.Drawing.Point(284, 0);
      this.btnMessageBoxInfoClose.Name = "btnMessageBoxInfoClose";
      this.btnMessageBoxInfoClose.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxInfoClose.TabIndex = 0;
      this.btnMessageBoxInfoClose.Text = "Close";
      this.btnMessageBoxInfoClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxInfoClose.UseVisualStyleBackColor = true;
      this.btnMessageBoxInfoClose.Click += new System.EventHandler(this.btn_messageBox_info_close_Click);
      // 
      // imglist_Info
      // 
      this.imglist_Info.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Info.ImageStream")));
      this.imglist_Info.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Info.Images.SetKeyName(0, "100p_Cinema-X-Men-icon.png");
      // 
      // pnlMessageBoxInfoCenter
      // 
      this.pnlMessageBoxInfoCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMessageBoxInfoCenter.Location = new System.Drawing.Point(0, 50);
      this.pnlMessageBoxInfoCenter.Name = "pnlMessageBoxInfoCenter";
      this.pnlMessageBoxInfoCenter.Size = new System.Drawing.Size(384, 162);
      this.pnlMessageBoxInfoCenter.TabIndex = 2;
      // 
      // ttmr_Info
      // 
      this.ttmr_Info.Enabled = true;
      this.ttmr_Info.Tick += new System.EventHandler(this.ttmr_Info_Tick);
      // 
      // FormMessageBox_Info
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 262);
      this.ControlBox = false;
      this.Controls.Add(this.pnlMessageBoxInfoCenter);
      this.Controls.Add(this.pnlMessageBoxInfoBottom);
      this.Controls.Add(this.pnlMessageBoxInfoTop);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMessageBox_Info";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Information Dialog Box";
      this.TopMost = true;
      this.pnlMessageBoxInfoTop.ResumeLayout(false);
      this.pnlMessageBoxInfoBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMessageBoxInfoTop;
    private System.Windows.Forms.Label lblMessageBoxInfoTitle;
    private System.Windows.Forms.Panel pnlMessageBoxInfoBottom;
    private System.Windows.Forms.Button btnMessageBoxInfoClose;
    private System.Windows.Forms.Panel pnlMessageBoxInfoCenter;
    private System.Windows.Forms.ImageList imglist_Info;
    private System.Windows.Forms.Timer ttmr_Info;
  }
}