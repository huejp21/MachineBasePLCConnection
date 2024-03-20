namespace BASE
{
  partial class FormMother
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
      this.pnlMotherTop = new System.Windows.Forms.Panel();
      this.pnlMotherBottom = new System.Windows.Forms.Panel();
      this.pnlMotherControl = new System.Windows.Forms.Panel();
      this.pnlMotherMain = new System.Windows.Forms.Panel();
      this.timer_mother = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // pnlMotherTop
      // 
      this.pnlMotherTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMotherTop.BackColor = System.Drawing.Color.White;
      this.pnlMotherTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlMotherTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMotherTop.ForeColor = System.Drawing.Color.Black;
      this.pnlMotherTop.Location = new System.Drawing.Point(0, 0);
      this.pnlMotherTop.Name = "pnlMotherTop";
      this.pnlMotherTop.Size = new System.Drawing.Size(1274, 75);
      this.pnlMotherTop.TabIndex = 19;
      // 
      // pnlMotherBottom
      // 
      this.pnlMotherBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMotherBottom.BackColor = System.Drawing.Color.White;
      this.pnlMotherBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlMotherBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlMotherBottom.ForeColor = System.Drawing.Color.Black;
      this.pnlMotherBottom.Location = new System.Drawing.Point(0, 889);
      this.pnlMotherBottom.Name = "pnlMotherBottom";
      this.pnlMotherBottom.Size = new System.Drawing.Size(1274, 100);
      this.pnlMotherBottom.TabIndex = 20;
      // 
      // pnlMotherControl
      // 
      this.pnlMotherControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMotherControl.BackColor = System.Drawing.Color.White;
      this.pnlMotherControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlMotherControl.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlMotherControl.ForeColor = System.Drawing.Color.Black;
      this.pnlMotherControl.Location = new System.Drawing.Point(1074, 75);
      this.pnlMotherControl.Name = "pnlMotherControl";
      this.pnlMotherControl.Size = new System.Drawing.Size(200, 814);
      this.pnlMotherControl.TabIndex = 21;
      // 
      // pnlMotherMain
      // 
      this.pnlMotherMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlMotherMain.BackColor = System.Drawing.Color.White;
      this.pnlMotherMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlMotherMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMotherMain.ForeColor = System.Drawing.Color.Black;
      this.pnlMotherMain.Location = new System.Drawing.Point(0, 75);
      this.pnlMotherMain.Name = "pnlMotherMain";
      this.pnlMotherMain.Size = new System.Drawing.Size(1074, 814);
      this.pnlMotherMain.TabIndex = 22;
      // 
      // timer_mother
      // 
      this.timer_mother.Enabled = true;
      this.timer_mother.Interval = 1;
      this.timer_mother.Tick += new System.EventHandler(this.timer_mother_Tick);
      // 
      // FormMother
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(1274, 989);
      this.Controls.Add(this.pnlMotherMain);
      this.Controls.Add(this.pnlMotherControl);
      this.Controls.Add(this.pnlMotherBottom);
      this.Controls.Add(this.pnlMotherTop);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormMother";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Project";
      this.Load += new System.EventHandler(this.FRM_MOTHER_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer_mother;
    public System.Windows.Forms.Panel pnlMotherControl;
    public System.Windows.Forms.Panel pnlMotherMain;
    public System.Windows.Forms.Panel pnlMotherTop;
    public System.Windows.Forms.Panel pnlMotherBottom;
  }
}

