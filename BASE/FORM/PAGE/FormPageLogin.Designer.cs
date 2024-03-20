namespace BASE.FORM.PAGE
{
  partial class FormPageLogin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPageLogin));
      this.tabLogin = new System.Windows.Forms.TabControl();
      this.tabpLogin = new System.Windows.Forms.TabPage();
      this.btnLoginManage = new System.Windows.Forms.Button();
      this.imglist_Login = new System.Windows.Forms.ImageList(this.components);
      this.btnLoginCreate = new System.Windows.Forms.Button();
      this.btnLoginLogin = new System.Windows.Forms.Button();
      this.lblLoginPassword = new System.Windows.Forms.Label();
      this.lblLoginId = new System.Windows.Forms.Label();
      this.txtLoginPassword = new System.Windows.Forms.TextBox();
      this.txtLoginId = new System.Windows.Forms.TextBox();
      this.tabLogin.SuspendLayout();
      this.tabpLogin.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabLogin
      // 
      this.tabLogin.Controls.Add(this.tabpLogin);
      this.tabLogin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabLogin.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabLogin.Location = new System.Drawing.Point(0, 0);
      this.tabLogin.Name = "tabLogin";
      this.tabLogin.SelectedIndex = 0;
      this.tabLogin.Size = new System.Drawing.Size(1074, 814);
      this.tabLogin.TabIndex = 0;
      this.tabLogin.VisibleChanged += new System.EventHandler(this.tabLogin_VisibleChanged);
      // 
      // tabpLogin
      // 
      this.tabpLogin.BackColor = System.Drawing.Color.DarkGray;
      this.tabpLogin.Controls.Add(this.btnLoginManage);
      this.tabpLogin.Controls.Add(this.btnLoginCreate);
      this.tabpLogin.Controls.Add(this.btnLoginLogin);
      this.tabpLogin.Controls.Add(this.lblLoginPassword);
      this.tabpLogin.Controls.Add(this.lblLoginId);
      this.tabpLogin.Controls.Add(this.txtLoginPassword);
      this.tabpLogin.Controls.Add(this.txtLoginId);
      this.tabpLogin.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabpLogin.Location = new System.Drawing.Point(4, 34);
      this.tabpLogin.Name = "tabpLogin";
      this.tabpLogin.Padding = new System.Windows.Forms.Padding(3);
      this.tabpLogin.Size = new System.Drawing.Size(1066, 776);
      this.tabpLogin.TabIndex = 0;
      this.tabpLogin.Text = "Login";
      // 
      // btnLoginManage
      // 
      this.btnLoginManage.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnLoginManage.ImageIndex = 2;
      this.btnLoginManage.ImageList = this.imglist_Login;
      this.btnLoginManage.Location = new System.Drawing.Point(555, 455);
      this.btnLoginManage.Name = "btnLoginManage";
      this.btnLoginManage.Size = new System.Drawing.Size(244, 108);
      this.btnLoginManage.TabIndex = 6;
      this.btnLoginManage.Text = "Manage";
      this.btnLoginManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnLoginManage.UseVisualStyleBackColor = true;
      this.btnLoginManage.Click += new System.EventHandler(this.btnLoginManage_Click);
      // 
      // imglist_Login
      // 
      this.imglist_Login.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Login.ImageStream")));
      this.imglist_Login.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_Login.Images.SetKeyName(0, "100p_success-icon.png");
      this.imglist_Login.Images.SetKeyName(1, "100p_add-icon.png");
      this.imglist_Login.Images.SetKeyName(2, "100p_Business-Conference-Call-icon.png");
      // 
      // btnLoginCreate
      // 
      this.btnLoginCreate.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnLoginCreate.ImageIndex = 1;
      this.btnLoginCreate.ImageList = this.imglist_Login;
      this.btnLoginCreate.Location = new System.Drawing.Point(302, 455);
      this.btnLoginCreate.Name = "btnLoginCreate";
      this.btnLoginCreate.Size = new System.Drawing.Size(244, 108);
      this.btnLoginCreate.TabIndex = 5;
      this.btnLoginCreate.Text = "Create";
      this.btnLoginCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnLoginCreate.UseVisualStyleBackColor = true;
      this.btnLoginCreate.Click += new System.EventHandler(this.btnLoginCreate_Click);
      // 
      // btnLoginLogin
      // 
      this.btnLoginLogin.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnLoginLogin.ImageIndex = 0;
      this.btnLoginLogin.ImageList = this.imglist_Login;
      this.btnLoginLogin.Location = new System.Drawing.Point(805, 247);
      this.btnLoginLogin.Name = "btnLoginLogin";
      this.btnLoginLogin.Size = new System.Drawing.Size(153, 316);
      this.btnLoginLogin.TabIndex = 4;
      this.btnLoginLogin.Text = "Login";
      this.btnLoginLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnLoginLogin.UseVisualStyleBackColor = true;
      this.btnLoginLogin.Click += new System.EventHandler(this.btnLoginLogin_Click);
      // 
      // lblLoginPassword
      // 
      this.lblLoginPassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblLoginPassword.Location = new System.Drawing.Point(42, 359);
      this.lblLoginPassword.Name = "lblLoginPassword";
      this.lblLoginPassword.Size = new System.Drawing.Size(254, 63);
      this.lblLoginPassword.TabIndex = 3;
      this.lblLoginPassword.Text = "Password:";
      // 
      // lblLoginId
      // 
      this.lblLoginId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblLoginId.Location = new System.Drawing.Point(42, 247);
      this.lblLoginId.Name = "lblLoginId";
      this.lblLoginId.Size = new System.Drawing.Size(254, 63);
      this.lblLoginId.TabIndex = 2;
      this.lblLoginId.Text = "ID:";
      // 
      // txtLoginPassword
      // 
      this.txtLoginPassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtLoginPassword.Location = new System.Drawing.Point(302, 359);
      this.txtLoginPassword.Name = "txtLoginPassword";
      this.txtLoginPassword.ReadOnly = true;
      this.txtLoginPassword.Size = new System.Drawing.Size(497, 63);
      this.txtLoginPassword.TabIndex = 1;
      this.txtLoginPassword.UseSystemPasswordChar = true;
      this.txtLoginPassword.Click += new System.EventHandler(this.txtBox_Click);
      // 
      // txtLoginId
      // 
      this.txtLoginId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtLoginId.Location = new System.Drawing.Point(302, 247);
      this.txtLoginId.Name = "txtLoginId";
      this.txtLoginId.ReadOnly = true;
      this.txtLoginId.Size = new System.Drawing.Size(497, 63);
      this.txtLoginId.TabIndex = 0;
      this.txtLoginId.Click += new System.EventHandler(this.txtBox_Click);
      // 
      // FormPageLogin
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1074, 814);
      this.ControlBox = false;
      this.Controls.Add(this.tabLogin);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPageLogin";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPageLogin";
      this.TopMost = true;
      this.Shown += new System.EventHandler(this.FormPageLogin_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormPageLogin_VisibleChanged);
      this.tabLogin.ResumeLayout(false);
      this.tabpLogin.ResumeLayout(false);
      this.tabpLogin.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabLogin;
    private System.Windows.Forms.TabPage tabpLogin;
    private System.Windows.Forms.Button btnLoginManage;
    private System.Windows.Forms.Button btnLoginCreate;
    private System.Windows.Forms.Button btnLoginLogin;
    private System.Windows.Forms.Label lblLoginPassword;
    private System.Windows.Forms.Label lblLoginId;
    private System.Windows.Forms.TextBox txtLoginPassword;
    private System.Windows.Forms.TextBox txtLoginId;
    private System.Windows.Forms.ImageList imglist_Login;
  }
}