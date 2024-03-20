namespace BASE.FORM
{
  partial class FormControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControl));
      this.btnControlStart = new System.Windows.Forms.Button();
      this.imglist_Control = new System.Windows.Forms.ImageList(this.components);
      this.btnControlStop = new System.Windows.Forms.Button();
      this.btnControlReset = new System.Windows.Forms.Button();
      this.btnControlInitialize = new System.Windows.Forms.Button();
      this.btn_control_location = new System.Windows.Forms.Button();
      this.tmrControl = new System.Windows.Forms.Timer(this.components);
      this.btn_control_Mode = new System.Windows.Forms.Button();
      this.btnControlLotCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnControlStart
      // 
      this.btnControlStart.BackColor = System.Drawing.Color.Gainsboro;
      this.btnControlStart.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnControlStart.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnControlStart.ImageIndex = 0;
      this.btnControlStart.ImageList = this.imglist_Control;
      this.btnControlStart.Location = new System.Drawing.Point(0, 0);
      this.btnControlStart.Name = "btnControlStart";
      this.btnControlStart.Size = new System.Drawing.Size(200, 100);
      this.btnControlStart.TabIndex = 0;
      this.btnControlStart.Text = "Start";
      this.btnControlStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnControlStart.UseVisualStyleBackColor = false;
      this.btnControlStart.Click += new System.EventHandler(this.btn_control_start_Click);
      // 
      // imglist_Control
      // 
      this.imglist_Control.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Control.ImageStream")));
      this.imglist_Control.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Control.Images.SetKeyName(0, "100p_Media-Controls-Next-icon.png");
      this.imglist_Control.Images.SetKeyName(1, "100p_Media-Controls-Pause-icon.png");
      this.imglist_Control.Images.SetKeyName(2, "100p_Computer-Hardware-Restart-icon.png");
      this.imglist_Control.Images.SetKeyName(3, "100p_Business-Process-icon.png");
      this.imglist_Control.Images.SetKeyName(4, "100p_Arrows-Left-Arrow-icon.png");
      this.imglist_Control.Images.SetKeyName(5, "100p_Arrows-Right-Arrow-icon.png");
      this.imglist_Control.Images.SetKeyName(6, "100p_padlock-lock-icon.png");
      this.imglist_Control.Images.SetKeyName(7, "100p_padlock-unlock-icon.png");
      this.imglist_Control.Images.SetKeyName(8, "100p_Editing-Rotate-icon.png");
      // 
      // btnControlStop
      // 
      this.btnControlStop.BackColor = System.Drawing.Color.Gainsboro;
      this.btnControlStop.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnControlStop.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnControlStop.ImageIndex = 1;
      this.btnControlStop.ImageList = this.imglist_Control;
      this.btnControlStop.Location = new System.Drawing.Point(0, 100);
      this.btnControlStop.Name = "btnControlStop";
      this.btnControlStop.Size = new System.Drawing.Size(200, 100);
      this.btnControlStop.TabIndex = 1;
      this.btnControlStop.Text = "Stop";
      this.btnControlStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnControlStop.UseVisualStyleBackColor = false;
      this.btnControlStop.Click += new System.EventHandler(this.btnControlStop_Click);
      // 
      // btnControlReset
      // 
      this.btnControlReset.BackColor = System.Drawing.Color.Gainsboro;
      this.btnControlReset.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnControlReset.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnControlReset.ImageIndex = 2;
      this.btnControlReset.ImageList = this.imglist_Control;
      this.btnControlReset.Location = new System.Drawing.Point(0, 200);
      this.btnControlReset.Name = "btnControlReset";
      this.btnControlReset.Size = new System.Drawing.Size(200, 100);
      this.btnControlReset.TabIndex = 2;
      this.btnControlReset.Text = "Reset";
      this.btnControlReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnControlReset.UseVisualStyleBackColor = false;
      this.btnControlReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnControlReset_MouseDown);
      this.btnControlReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnControlReset_MouseUp);
      // 
      // btnControlInitialize
      // 
      this.btnControlInitialize.BackColor = System.Drawing.Color.Gainsboro;
      this.btnControlInitialize.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnControlInitialize.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnControlInitialize.ImageIndex = 3;
      this.btnControlInitialize.ImageList = this.imglist_Control;
      this.btnControlInitialize.Location = new System.Drawing.Point(0, 300);
      this.btnControlInitialize.Name = "btnControlInitialize";
      this.btnControlInitialize.Size = new System.Drawing.Size(200, 100);
      this.btnControlInitialize.TabIndex = 3;
      this.btnControlInitialize.Text = "Initialize";
      this.btnControlInitialize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnControlInitialize.UseVisualStyleBackColor = false;
      this.btnControlInitialize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnControlInitialize_MouseDown);
      this.btnControlInitialize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnControlInitialize_MouseUp);
      // 
      // btn_control_location
      // 
      this.btn_control_location.BackColor = System.Drawing.Color.Gainsboro;
      this.btn_control_location.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_control_location.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btn_control_location.ImageIndex = 4;
      this.btn_control_location.ImageList = this.imglist_Control;
      this.btn_control_location.Location = new System.Drawing.Point(0, 714);
      this.btn_control_location.Name = "btn_control_location";
      this.btn_control_location.Size = new System.Drawing.Size(200, 100);
      this.btn_control_location.TabIndex = 4;
      this.btn_control_location.Text = "Left";
      this.btn_control_location.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_control_location.UseVisualStyleBackColor = false;
      this.btn_control_location.Click += new System.EventHandler(this.btn_control_location_Click);
      // 
      // tmrControl
      // 
      this.tmrControl.Enabled = true;
      this.tmrControl.Interval = 50;
      this.tmrControl.Tick += new System.EventHandler(this.timer_control_Tick);
      // 
      // btn_control_Mode
      // 
      this.btn_control_Mode.BackColor = System.Drawing.Color.Gainsboro;
      this.btn_control_Mode.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_control_Mode.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btn_control_Mode.ImageIndex = 6;
      this.btn_control_Mode.ImageList = this.imglist_Control;
      this.btn_control_Mode.Location = new System.Drawing.Point(0, 614);
      this.btn_control_Mode.Name = "btn_control_Mode";
      this.btn_control_Mode.Size = new System.Drawing.Size(200, 100);
      this.btn_control_Mode.TabIndex = 5;
      this.btn_control_Mode.Text = "Safety Mode";
      this.btn_control_Mode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_control_Mode.UseVisualStyleBackColor = false;
      this.btn_control_Mode.Click += new System.EventHandler(this.btn_control_Mode_Click);
      // 
      // btnControlLotCancel
      // 
      this.btnControlLotCancel.BackColor = System.Drawing.Color.Gainsboro;
      this.btnControlLotCancel.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnControlLotCancel.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnControlLotCancel.ImageIndex = 8;
      this.btnControlLotCancel.ImageList = this.imglist_Control;
      this.btnControlLotCancel.Location = new System.Drawing.Point(0, 400);
      this.btnControlLotCancel.Name = "btnControlLotCancel";
      this.btnControlLotCancel.Size = new System.Drawing.Size(200, 100);
      this.btnControlLotCancel.TabIndex = 6;
      this.btnControlLotCancel.Text = "Lot Clear";
      this.btnControlLotCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnControlLotCancel.UseVisualStyleBackColor = false;
      this.btnControlLotCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnControlLotCancel_MouseDown);
      // 
      // FormControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.Gainsboro;
      this.ClientSize = new System.Drawing.Size(200, 814);
      this.ControlBox = false;
      this.Controls.Add(this.btnControlLotCancel);
      this.Controls.Add(this.btn_control_Mode);
      this.Controls.Add(this.btn_control_location);
      this.Controls.Add(this.btnControlInitialize);
      this.Controls.Add(this.btnControlReset);
      this.Controls.Add(this.btnControlStop);
      this.Controls.Add(this.btnControlStart);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormControl";
      this.Text = "FRM_Control";
      this.TopMost = true;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnControlStart;
    private System.Windows.Forms.Button btnControlStop;
    private System.Windows.Forms.Button btnControlReset;
    private System.Windows.Forms.Button btnControlInitialize;
    private System.Windows.Forms.Button btn_control_location;
    private System.Windows.Forms.Timer tmrControl;
    private System.Windows.Forms.ImageList imglist_Control;
    private System.Windows.Forms.Button btn_control_Mode;
    private System.Windows.Forms.Button btnControlLotCancel;
  }
}