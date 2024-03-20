namespace BASE.FORM
{
  partial class FormStartUp
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
      this.pnl_logo = new System.Windows.Forms.Panel();
      this.pnl_StartupMain = new System.Windows.Forms.Panel();
      this.pnl_StartupMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnl_logo
      // 
      this.pnl_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnl_logo.Location = new System.Drawing.Point(3, 3);
      this.pnl_logo.Name = "pnl_logo";
      this.pnl_logo.Size = new System.Drawing.Size(537, 156);
      this.pnl_logo.TabIndex = 148;
      // 
      // pnl_StartupMain
      // 
      this.pnl_StartupMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnl_StartupMain.Controls.Add(this.pnl_logo);
      this.pnl_StartupMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnl_StartupMain.Location = new System.Drawing.Point(0, 0);
      this.pnl_StartupMain.Name = "pnl_StartupMain";
      this.pnl_StartupMain.Size = new System.Drawing.Size(545, 162);
      this.pnl_StartupMain.TabIndex = 154;
      // 
      // FormStartUp
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.CornflowerBlue;
      this.ClientSize = new System.Drawing.Size(545, 162);
      this.ControlBox = false;
      this.Controls.Add(this.pnl_StartupMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormStartUp";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormStartUp";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.FormStartUp_Load);
      this.pnl_StartupMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnl_logo;
    private System.Windows.Forms.Panel pnl_StartupMain;
  }
}