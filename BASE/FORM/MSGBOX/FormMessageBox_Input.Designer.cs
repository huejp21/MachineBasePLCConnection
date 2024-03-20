namespace BASE.FORM.MSGBOX
{
  partial class FormMessageBox_Input
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox_Input));
      this.pnlMessageBoxInputCenter = new System.Windows.Forms.Panel();
      this.pnlMessageBoxInputBottom = new System.Windows.Forms.Panel();
      this.btnMessageBoxInputOk = new System.Windows.Forms.Button();
      this.imglist_Input = new System.Windows.Forms.ImageList(this.components);
      this.btnMessageBoxInputCancel = new System.Windows.Forms.Button();
      this.pnlMessageBoxInputTop = new System.Windows.Forms.Panel();
      this.lblMessageBoxInputTitle = new System.Windows.Forms.Label();
      this.tmr_Input = new System.Windows.Forms.Timer(this.components);
      this.pnlMessageBoxInputBottom.SuspendLayout();
      this.pnlMessageBoxInputTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMessageBoxInputCenter
      // 
      this.pnlMessageBoxInputCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMessageBoxInputCenter.Location = new System.Drawing.Point(0, 50);
      this.pnlMessageBoxInputCenter.Name = "pnlMessageBoxInputCenter";
      this.pnlMessageBoxInputCenter.Size = new System.Drawing.Size(384, 162);
      this.pnlMessageBoxInputCenter.TabIndex = 5;
      // 
      // pnlMessageBoxInputBottom
      // 
      this.pnlMessageBoxInputBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMessageBoxInputBottom.Controls.Add(this.btnMessageBoxInputOk);
      this.pnlMessageBoxInputBottom.Controls.Add(this.btnMessageBoxInputCancel);
      this.pnlMessageBoxInputBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMessageBoxInputBottom.Location = new System.Drawing.Point(0, 212);
      this.pnlMessageBoxInputBottom.Name = "pnlMessageBoxInputBottom";
      this.pnlMessageBoxInputBottom.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxInputBottom.TabIndex = 4;
      // 
      // btnMessageBoxInputOk
      // 
      this.btnMessageBoxInputOk.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxInputOk.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxInputOk.ImageIndex = 1;
      this.btnMessageBoxInputOk.ImageList = this.imglist_Input;
      this.btnMessageBoxInputOk.Location = new System.Drawing.Point(184, 0);
      this.btnMessageBoxInputOk.Name = "btnMessageBoxInputOk";
      this.btnMessageBoxInputOk.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxInputOk.TabIndex = 1;
      this.btnMessageBoxInputOk.Text = "Ok";
      this.btnMessageBoxInputOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxInputOk.UseVisualStyleBackColor = true;
      // 
      // imglist_Input
      // 
      this.imglist_Input.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Input.ImageStream")));
      this.imglist_Input.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Input.Images.SetKeyName(0, "100p_Cinema-X-Men-icon.png");
      this.imglist_Input.Images.SetKeyName(1, "100p_success-icon.png");
      // 
      // btnMessageBoxInputCancel
      // 
      this.btnMessageBoxInputCancel.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMessageBoxInputCancel.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnMessageBoxInputCancel.ImageIndex = 0;
      this.btnMessageBoxInputCancel.ImageList = this.imglist_Input;
      this.btnMessageBoxInputCancel.Location = new System.Drawing.Point(284, 0);
      this.btnMessageBoxInputCancel.Name = "btnMessageBoxInputCancel";
      this.btnMessageBoxInputCancel.Size = new System.Drawing.Size(100, 50);
      this.btnMessageBoxInputCancel.TabIndex = 0;
      this.btnMessageBoxInputCancel.Text = "Cancel";
      this.btnMessageBoxInputCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnMessageBoxInputCancel.UseVisualStyleBackColor = true;
      // 
      // pnlMessageBoxInputTop
      // 
      this.pnlMessageBoxInputTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMessageBoxInputTop.Controls.Add(this.lblMessageBoxInputTitle);
      this.pnlMessageBoxInputTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMessageBoxInputTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMessageBoxInputTop.Name = "pnlMessageBoxInputTop";
      this.pnlMessageBoxInputTop.Size = new System.Drawing.Size(384, 50);
      this.pnlMessageBoxInputTop.TabIndex = 3;
      // 
      // lblMessageBoxInputTitle
      // 
      this.lblMessageBoxInputTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessageBoxInputTitle.Location = new System.Drawing.Point(0, 0);
      this.lblMessageBoxInputTitle.Name = "lblMessageBoxInputTitle";
      this.lblMessageBoxInputTitle.Size = new System.Drawing.Size(384, 50);
      this.lblMessageBoxInputTitle.TabIndex = 0;
      this.lblMessageBoxInputTitle.Text = "Title";
      this.lblMessageBoxInputTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tmr_Input
      // 
      this.tmr_Input.Enabled = true;
      this.tmr_Input.Tick += new System.EventHandler(this.tmr_Input_Tick);
      // 
      // FormMessageBox_Input
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 262);
      this.ControlBox = false;
      this.Controls.Add(this.pnlMessageBoxInputCenter);
      this.Controls.Add(this.pnlMessageBoxInputBottom);
      this.Controls.Add(this.pnlMessageBoxInputTop);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMessageBox_Input";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Input/Selection Dialog Box";
      this.TopMost = true;
      this.pnlMessageBoxInputBottom.ResumeLayout(false);
      this.pnlMessageBoxInputTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlMessageBoxInputCenter;
    private System.Windows.Forms.Panel pnlMessageBoxInputBottom;
    private System.Windows.Forms.Button btnMessageBoxInputOk;
    private System.Windows.Forms.Button btnMessageBoxInputCancel;
    private System.Windows.Forms.Panel pnlMessageBoxInputTop;
    private System.Windows.Forms.Label lblMessageBoxInputTitle;
    private System.Windows.Forms.ImageList imglist_Input;
    private System.Windows.Forms.Timer tmr_Input;
  }
}