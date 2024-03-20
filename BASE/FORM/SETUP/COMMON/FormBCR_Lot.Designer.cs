namespace BASE.FORM.SETUP.COMMON
{
  partial class FormBCR_Lot
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
      this.btn_Clear = new System.Windows.Forms.Button();
      this.txtBCR = new System.Windows.Forms.TextBox();
      this.lbl_BCR = new System.Windows.Forms.Label();
      this.btn_Ok = new System.Windows.Forms.Button();
      this.btn_Close = new System.Windows.Forms.Button();
      this.tmr_BCR_Lot = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // btn_Clear
      // 
      this.btn_Clear.Location = new System.Drawing.Point(12, 34);
      this.btn_Clear.Name = "btn_Clear";
      this.btn_Clear.Size = new System.Drawing.Size(130, 57);
      this.btn_Clear.TabIndex = 0;
      this.btn_Clear.Text = "Clear";
      this.btn_Clear.UseVisualStyleBackColor = true;
      this.btn_Clear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Clear_MouseDown);
      // 
      // txtBCR
      // 
      this.txtBCR.Location = new System.Drawing.Point(118, 10);
      this.txtBCR.Name = "txtBCR";
      this.txtBCR.Size = new System.Drawing.Size(358, 21);
      this.txtBCR.TabIndex = 1;
      this.txtBCR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBCR_KeyDown);
      this.txtBCR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBCR_KeyPress);
      // 
      // lbl_BCR
      // 
      this.lbl_BCR.Location = new System.Drawing.Point(12, 10);
      this.lbl_BCR.Name = "lbl_BCR";
      this.lbl_BCR.Size = new System.Drawing.Size(100, 21);
      this.lbl_BCR.TabIndex = 2;
      this.lbl_BCR.Text = "BCR:";
      this.lbl_BCR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_Ok
      // 
      this.btn_Ok.Location = new System.Drawing.Point(210, 37);
      this.btn_Ok.Name = "btn_Ok";
      this.btn_Ok.Size = new System.Drawing.Size(130, 57);
      this.btn_Ok.TabIndex = 3;
      this.btn_Ok.Text = "OK";
      this.btn_Ok.UseVisualStyleBackColor = true;
      this.btn_Ok.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Ok_MouseDown);
      // 
      // btn_Close
      // 
      this.btn_Close.Location = new System.Drawing.Point(346, 37);
      this.btn_Close.Name = "btn_Close";
      this.btn_Close.Size = new System.Drawing.Size(130, 57);
      this.btn_Close.TabIndex = 4;
      this.btn_Close.Text = "Close";
      this.btn_Close.UseVisualStyleBackColor = true;
      this.btn_Close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Close_MouseDown);
      // 
      // tmr_BCR_Lot
      // 
      this.tmr_BCR_Lot.Enabled = true;
      this.tmr_BCR_Lot.Interval = 1;
      this.tmr_BCR_Lot.Tick += new System.EventHandler(this.tmr_BCR_Lot_Tick);
      // 
      // FormBCR_Lot
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(483, 103);
      this.ControlBox = false;
      this.Controls.Add(this.btn_Close);
      this.Controls.Add(this.btn_Ok);
      this.Controls.Add(this.lbl_BCR);
      this.Controls.Add(this.txtBCR);
      this.Controls.Add(this.btn_Clear);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormBCR_Lot";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormBCR_Lot";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_Clear;
    private System.Windows.Forms.TextBox txtBCR;
    private System.Windows.Forms.Label lbl_BCR;
    private System.Windows.Forms.Button btn_Ok;
    private System.Windows.Forms.Button btn_Close;
    private System.Windows.Forms.Timer tmr_BCR_Lot;
  }
}