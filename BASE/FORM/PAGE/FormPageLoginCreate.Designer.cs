namespace BASE.FORM.PAGE
{
  partial class FormPageLoginCreate
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPageLoginCreate));
      this.tabLoginCreate = new System.Windows.Forms.TabControl();
      this.tabpCreate = new System.Windows.Forms.TabPage();
      this.btnCreateBack = new System.Windows.Forms.Button();
      this.imglist_LoginCreate = new System.Windows.Forms.ImageList(this.components);
      this.btnCreateCreate = new System.Windows.Forms.Button();
      this.lblCreateInfo = new System.Windows.Forms.Label();
      this.txtCreateInfo = new System.Windows.Forms.TextBox();
      this.lblCreatePasswordC = new System.Windows.Forms.Label();
      this.txtCreatePasswordC = new System.Windows.Forms.TextBox();
      this.lblCreatePassword = new System.Windows.Forms.Label();
      this.lblCreateId = new System.Windows.Forms.Label();
      this.txtCreatePassword = new System.Windows.Forms.TextBox();
      this.txtCreateId = new System.Windows.Forms.TextBox();
      this.tabLoginCreate.SuspendLayout();
      this.tabpCreate.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabLoginCreate
      // 
      this.tabLoginCreate.Controls.Add(this.tabpCreate);
      this.tabLoginCreate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabLoginCreate.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabLoginCreate.Location = new System.Drawing.Point(0, 0);
      this.tabLoginCreate.Name = "tabLoginCreate";
      this.tabLoginCreate.SelectedIndex = 0;
      this.tabLoginCreate.Size = new System.Drawing.Size(1074, 814);
      this.tabLoginCreate.TabIndex = 1;
      // 
      // tabpCreate
      // 
      this.tabpCreate.BackColor = System.Drawing.Color.DarkGray;
      this.tabpCreate.Controls.Add(this.btnCreateBack);
      this.tabpCreate.Controls.Add(this.btnCreateCreate);
      this.tabpCreate.Controls.Add(this.lblCreateInfo);
      this.tabpCreate.Controls.Add(this.txtCreateInfo);
      this.tabpCreate.Controls.Add(this.lblCreatePasswordC);
      this.tabpCreate.Controls.Add(this.txtCreatePasswordC);
      this.tabpCreate.Controls.Add(this.lblCreatePassword);
      this.tabpCreate.Controls.Add(this.lblCreateId);
      this.tabpCreate.Controls.Add(this.txtCreatePassword);
      this.tabpCreate.Controls.Add(this.txtCreateId);
      this.tabpCreate.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabpCreate.Location = new System.Drawing.Point(4, 34);
      this.tabpCreate.Name = "tabpCreate";
      this.tabpCreate.Padding = new System.Windows.Forms.Padding(3);
      this.tabpCreate.Size = new System.Drawing.Size(1066, 776);
      this.tabpCreate.TabIndex = 0;
      this.tabpCreate.Text = "Create";
      // 
      // btnCreateBack
      // 
      this.btnCreateBack.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnCreateBack.ImageIndex = 1;
      this.btnCreateBack.ImageList = this.imglist_LoginCreate;
      this.btnCreateBack.Location = new System.Drawing.Point(816, 662);
      this.btnCreateBack.Name = "btnCreateBack";
      this.btnCreateBack.Size = new System.Drawing.Size(244, 108);
      this.btnCreateBack.TabIndex = 9;
      this.btnCreateBack.Text = "Back to login";
      this.btnCreateBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCreateBack.UseVisualStyleBackColor = true;
      this.btnCreateBack.Click += new System.EventHandler(this.btnCreateBack_Click);
      // 
      // imglist_LoginCreate
      // 
      this.imglist_LoginCreate.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_LoginCreate.ImageStream")));
      this.imglist_LoginCreate.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_LoginCreate.Images.SetKeyName(0, "100p_add-icon.png");
      this.imglist_LoginCreate.Images.SetKeyName(1, "100p_Arrows-Undo-icon.png");
      // 
      // btnCreateCreate
      // 
      this.btnCreateCreate.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnCreateCreate.ImageIndex = 0;
      this.btnCreateCreate.ImageList = this.imglist_LoginCreate;
      this.btnCreateCreate.Location = new System.Drawing.Point(649, 466);
      this.btnCreateCreate.Name = "btnCreateCreate";
      this.btnCreateCreate.Size = new System.Drawing.Size(244, 108);
      this.btnCreateCreate.TabIndex = 8;
      this.btnCreateCreate.Text = "Create";
      this.btnCreateCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCreateCreate.UseVisualStyleBackColor = true;
      this.btnCreateCreate.Click += new System.EventHandler(this.btnCreateCreate_Click);
      // 
      // lblCreateInfo
      // 
      this.lblCreateInfo.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblCreateInfo.Location = new System.Drawing.Point(28, 397);
      this.lblCreateInfo.Name = "lblCreateInfo";
      this.lblCreateInfo.Size = new System.Drawing.Size(362, 63);
      this.lblCreateInfo.TabIndex = 7;
      this.lblCreateInfo.Text = "Information:";
      // 
      // txtCreateInfo
      // 
      this.txtCreateInfo.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtCreateInfo.Location = new System.Drawing.Point(396, 397);
      this.txtCreateInfo.Name = "txtCreateInfo";
      this.txtCreateInfo.ReadOnly = true;
      this.txtCreateInfo.Size = new System.Drawing.Size(497, 63);
      this.txtCreateInfo.TabIndex = 6;
      this.txtCreateInfo.Click += new System.EventHandler(this.txtBox_Click);
      this.txtCreateInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // lblCreatePasswordC
      // 
      this.lblCreatePasswordC.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblCreatePasswordC.Location = new System.Drawing.Point(28, 328);
      this.lblCreatePasswordC.Name = "lblCreatePasswordC";
      this.lblCreatePasswordC.Size = new System.Drawing.Size(362, 63);
      this.lblCreatePasswordC.TabIndex = 5;
      this.lblCreatePasswordC.Text = "Confirm PW(*):";
      // 
      // txtCreatePasswordC
      // 
      this.txtCreatePasswordC.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtCreatePasswordC.Location = new System.Drawing.Point(396, 328);
      this.txtCreatePasswordC.Name = "txtCreatePasswordC";
      this.txtCreatePasswordC.ReadOnly = true;
      this.txtCreatePasswordC.Size = new System.Drawing.Size(497, 63);
      this.txtCreatePasswordC.TabIndex = 4;
      this.txtCreatePasswordC.UseSystemPasswordChar = true;
      this.txtCreatePasswordC.Click += new System.EventHandler(this.txtBox_Click);
      this.txtCreatePasswordC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // lblCreatePassword
      // 
      this.lblCreatePassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblCreatePassword.Location = new System.Drawing.Point(28, 259);
      this.lblCreatePassword.Name = "lblCreatePassword";
      this.lblCreatePassword.Size = new System.Drawing.Size(362, 63);
      this.lblCreatePassword.TabIndex = 3;
      this.lblCreatePassword.Text = "PW(*):";
      // 
      // lblCreateId
      // 
      this.lblCreateId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblCreateId.Location = new System.Drawing.Point(28, 190);
      this.lblCreateId.Name = "lblCreateId";
      this.lblCreateId.Size = new System.Drawing.Size(362, 63);
      this.lblCreateId.TabIndex = 2;
      this.lblCreateId.Text = "ID(*):";
      // 
      // txtCreatePassword
      // 
      this.txtCreatePassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtCreatePassword.Location = new System.Drawing.Point(396, 259);
      this.txtCreatePassword.Name = "txtCreatePassword";
      this.txtCreatePassword.ReadOnly = true;
      this.txtCreatePassword.Size = new System.Drawing.Size(497, 63);
      this.txtCreatePassword.TabIndex = 1;
      this.txtCreatePassword.UseSystemPasswordChar = true;
      this.txtCreatePassword.Click += new System.EventHandler(this.txtBox_Click);
      this.txtCreatePassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // txtCreateId
      // 
      this.txtCreateId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtCreateId.Location = new System.Drawing.Point(396, 190);
      this.txtCreateId.Name = "txtCreateId";
      this.txtCreateId.ReadOnly = true;
      this.txtCreateId.Size = new System.Drawing.Size(497, 63);
      this.txtCreateId.TabIndex = 0;
      this.txtCreateId.Click += new System.EventHandler(this.txtBox_Click);
      this.txtCreateId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // FormPageLoginCreate
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1074, 814);
      this.ControlBox = false;
      this.Controls.Add(this.tabLoginCreate);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPageLoginCreate";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPageLoginCreate";
      this.tabLoginCreate.ResumeLayout(false);
      this.tabpCreate.ResumeLayout(false);
      this.tabpCreate.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabLoginCreate;
    private System.Windows.Forms.TabPage tabpCreate;
    private System.Windows.Forms.Label lblCreateInfo;
    private System.Windows.Forms.TextBox txtCreateInfo;
    private System.Windows.Forms.Label lblCreatePasswordC;
    private System.Windows.Forms.TextBox txtCreatePasswordC;
    private System.Windows.Forms.Label lblCreatePassword;
    private System.Windows.Forms.Label lblCreateId;
    private System.Windows.Forms.TextBox txtCreatePassword;
    private System.Windows.Forms.TextBox txtCreateId;
    private System.Windows.Forms.Button btnCreateBack;
    private System.Windows.Forms.Button btnCreateCreate;
    private System.Windows.Forms.ImageList imglist_LoginCreate;
  }
}