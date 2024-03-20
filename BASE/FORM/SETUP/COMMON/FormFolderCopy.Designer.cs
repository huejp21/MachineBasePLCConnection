namespace BASE.FORM.SETUP.COMMON
{
  partial class FormFolderCopy
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.lblNewName = new System.Windows.Forms.Label();
      this.txtNewName = new System.Windows.Forms.TextBox();
      this.groupNew = new System.Windows.Forms.GroupBox();
      this.groupSource = new System.Windows.Forms.GroupBox();
      this.cboSourceName = new System.Windows.Forms.ComboBox();
      this.lblSourceName = new System.Windows.Forms.Label();
      this.groupNew.SuspendLayout();
      this.groupSource.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(282, 194);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(90, 50);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(186, 194);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(90, 50);
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // lblNewName
      // 
      this.lblNewName.AutoSize = true;
      this.lblNewName.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblNewName.Location = new System.Drawing.Point(6, 39);
      this.lblNewName.Name = "lblNewName";
      this.lblNewName.Size = new System.Drawing.Size(75, 24);
      this.lblNewName.TabIndex = 5;
      this.lblNewName.Text = "Name:";
      // 
      // txtNewName
      // 
      this.txtNewName.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtNewName.Location = new System.Drawing.Point(92, 28);
      this.txtNewName.Name = "txtNewName";
      this.txtNewName.Size = new System.Drawing.Size(262, 35);
      this.txtNewName.TabIndex = 4;
      this.txtNewName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNewName_MouseDown);
      // 
      // groupNew
      // 
      this.groupNew.Controls.Add(this.txtNewName);
      this.groupNew.Controls.Add(this.lblNewName);
      this.groupNew.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.groupNew.Location = new System.Drawing.Point(12, 95);
      this.groupNew.Name = "groupNew";
      this.groupNew.Size = new System.Drawing.Size(360, 77);
      this.groupNew.TabIndex = 8;
      this.groupNew.TabStop = false;
      this.groupNew.Text = "New";
      // 
      // groupSource
      // 
      this.groupSource.Controls.Add(this.cboSourceName);
      this.groupSource.Controls.Add(this.lblSourceName);
      this.groupSource.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.groupSource.Location = new System.Drawing.Point(12, 12);
      this.groupSource.Name = "groupSource";
      this.groupSource.Size = new System.Drawing.Size(360, 77);
      this.groupSource.TabIndex = 9;
      this.groupSource.TabStop = false;
      this.groupSource.Text = "Source";
      // 
      // cboSourceName
      // 
      this.cboSourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboSourceName.FormattingEnabled = true;
      this.cboSourceName.Location = new System.Drawing.Point(92, 28);
      this.cboSourceName.Name = "cboSourceName";
      this.cboSourceName.Size = new System.Drawing.Size(262, 32);
      this.cboSourceName.TabIndex = 7;
      // 
      // lblSourceName
      // 
      this.lblSourceName.AutoSize = true;
      this.lblSourceName.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblSourceName.Location = new System.Drawing.Point(6, 36);
      this.lblSourceName.Name = "lblSourceName";
      this.lblSourceName.Size = new System.Drawing.Size(75, 24);
      this.lblSourceName.TabIndex = 6;
      this.lblSourceName.Text = "Name:";
      // 
      // FormFolderCopy
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(384, 256);
      this.ControlBox = false;
      this.Controls.Add(this.groupSource);
      this.Controls.Add(this.groupNew);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormFolderCopy";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Copy";
      this.TopMost = true;
      this.Shown += new System.EventHandler(this.FormFolderCopy_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormFolderCopy_VisibleChanged);
      this.groupNew.ResumeLayout(false);
      this.groupNew.PerformLayout();
      this.groupSource.ResumeLayout(false);
      this.groupSource.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label lblNewName;
    private System.Windows.Forms.TextBox txtNewName;
    private System.Windows.Forms.GroupBox groupNew;
    private System.Windows.Forms.GroupBox groupSource;
    private System.Windows.Forms.ComboBox cboSourceName;
    private System.Windows.Forms.Label lblSourceName;
  }
}