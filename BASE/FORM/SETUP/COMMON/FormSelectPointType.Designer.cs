namespace BASE.FORM.SETUP.COMMON
{
  partial class FormSelectPointType
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
      this.lbl_PointType_Info = new System.Windows.Forms.Label();
      this.lbl_PointType_CurrentPoint = new System.Windows.Forms.Label();
      this.lbl_PointType_CurrentPointValue = new System.Windows.Forms.Label();
      this.btn_PointType_Dummy = new System.Windows.Forms.Button();
      this.btn_PointType_Unit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbl_PointType_Info
      // 
      this.lbl_PointType_Info.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lbl_PointType_Info.Location = new System.Drawing.Point(10, 10);
      this.lbl_PointType_Info.Name = "lbl_PointType_Info";
      this.lbl_PointType_Info.Size = new System.Drawing.Size(297, 36);
      this.lbl_PointType_Info.TabIndex = 0;
      this.lbl_PointType_Info.Text = "Select Point Type";
      this.lbl_PointType_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbl_PointType_CurrentPoint
      // 
      this.lbl_PointType_CurrentPoint.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lbl_PointType_CurrentPoint.Location = new System.Drawing.Point(10, 46);
      this.lbl_PointType_CurrentPoint.Name = "lbl_PointType_CurrentPoint";
      this.lbl_PointType_CurrentPoint.Size = new System.Drawing.Size(194, 36);
      this.lbl_PointType_CurrentPoint.TabIndex = 1;
      this.lbl_PointType_CurrentPoint.Text = "Current Point:";
      this.lbl_PointType_CurrentPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lbl_PointType_CurrentPointValue
      // 
      this.lbl_PointType_CurrentPointValue.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lbl_PointType_CurrentPointValue.Location = new System.Drawing.Point(209, 46);
      this.lbl_PointType_CurrentPointValue.Name = "lbl_PointType_CurrentPointValue";
      this.lbl_PointType_CurrentPointValue.Size = new System.Drawing.Size(98, 36);
      this.lbl_PointType_CurrentPointValue.TabIndex = 2;
      this.lbl_PointType_CurrentPointValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_PointType_Dummy
      // 
      this.btn_PointType_Dummy.BackColor = System.Drawing.Color.Magenta;
      this.btn_PointType_Dummy.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btn_PointType_Dummy.ForeColor = System.Drawing.Color.White;
      this.btn_PointType_Dummy.Location = new System.Drawing.Point(14, 85);
      this.btn_PointType_Dummy.Name = "btn_PointType_Dummy";
      this.btn_PointType_Dummy.Size = new System.Drawing.Size(135, 82);
      this.btn_PointType_Dummy.TabIndex = 3;
      this.btn_PointType_Dummy.Text = "Dummy";
      this.btn_PointType_Dummy.UseVisualStyleBackColor = false;
      this.btn_PointType_Dummy.Click += new System.EventHandler(this.btn_PointType_Dummy_Click);
      // 
      // btn_PointType_Unit
      // 
      this.btn_PointType_Unit.BackColor = System.Drawing.Color.Blue;
      this.btn_PointType_Unit.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btn_PointType_Unit.ForeColor = System.Drawing.Color.White;
      this.btn_PointType_Unit.Location = new System.Drawing.Point(172, 85);
      this.btn_PointType_Unit.Name = "btn_PointType_Unit";
      this.btn_PointType_Unit.Size = new System.Drawing.Size(135, 82);
      this.btn_PointType_Unit.TabIndex = 4;
      this.btn_PointType_Unit.Text = "Unit";
      this.btn_PointType_Unit.UseVisualStyleBackColor = false;
      this.btn_PointType_Unit.Click += new System.EventHandler(this.btn_PointType_Unit_Click);
      // 
      // FormSelectPointType
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(317, 179);
      this.ControlBox = false;
      this.Controls.Add(this.btn_PointType_Unit);
      this.Controls.Add(this.btn_PointType_Dummy);
      this.Controls.Add(this.lbl_PointType_CurrentPointValue);
      this.Controls.Add(this.lbl_PointType_CurrentPoint);
      this.Controls.Add(this.lbl_PointType_Info);
      this.MaximizeBox = false;
      this.Name = "FormSelectPointType";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormSelectPointType";
      this.TopMost = true;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lbl_PointType_Info;
    private System.Windows.Forms.Label lbl_PointType_CurrentPoint;
    private System.Windows.Forms.Label lbl_PointType_CurrentPointValue;
    private System.Windows.Forms.Button btn_PointType_Dummy;
    private System.Windows.Forms.Button btn_PointType_Unit;
  }
}