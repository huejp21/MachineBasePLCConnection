namespace BASE.FORM.PAGE
{
  partial class FormPageLoginManage
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPageLoginManage));
      this.tabLoginManage = new System.Windows.Forms.TabControl();
      this.tabpManage = new System.Windows.Forms.TabPage();
      this.txtManageId = new System.Windows.Forms.TextBox();
      this.btnManageDelete = new System.Windows.Forms.Button();
      this.imglist_LoginManage = new System.Windows.Forms.ImageList(this.components);
      this.btnManageBack = new System.Windows.Forms.Button();
      this.btnManageApply = new System.Windows.Forms.Button();
      this.lblManageLevel = new System.Windows.Forms.Label();
      this.cboManageLevel = new System.Windows.Forms.ComboBox();
      this.lblManageInfo = new System.Windows.Forms.Label();
      this.txtManageInfo = new System.Windows.Forms.TextBox();
      this.lblManagePasswordC = new System.Windows.Forms.Label();
      this.txtManagePasswordC = new System.Windows.Forms.TextBox();
      this.lblManagePassword = new System.Windows.Forms.Label();
      this.lblManageId = new System.Windows.Forms.Label();
      this.txtManagePassword = new System.Windows.Forms.TextBox();
      this.listManage = new System.Windows.Forms.ListBox();
      this.tabLoginManage.SuspendLayout();
      this.tabpManage.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabLoginManage
      // 
      this.tabLoginManage.Controls.Add(this.tabpManage);
      this.tabLoginManage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabLoginManage.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabLoginManage.Location = new System.Drawing.Point(0, 0);
      this.tabLoginManage.Name = "tabLoginManage";
      this.tabLoginManage.SelectedIndex = 0;
      this.tabLoginManage.Size = new System.Drawing.Size(1074, 814);
      this.tabLoginManage.TabIndex = 2;
      // 
      // tabpManage
      // 
      this.tabpManage.BackColor = System.Drawing.Color.DarkGray;
      this.tabpManage.Controls.Add(this.txtManageId);
      this.tabpManage.Controls.Add(this.btnManageDelete);
      this.tabpManage.Controls.Add(this.btnManageBack);
      this.tabpManage.Controls.Add(this.btnManageApply);
      this.tabpManage.Controls.Add(this.lblManageLevel);
      this.tabpManage.Controls.Add(this.cboManageLevel);
      this.tabpManage.Controls.Add(this.lblManageInfo);
      this.tabpManage.Controls.Add(this.txtManageInfo);
      this.tabpManage.Controls.Add(this.lblManagePasswordC);
      this.tabpManage.Controls.Add(this.txtManagePasswordC);
      this.tabpManage.Controls.Add(this.lblManagePassword);
      this.tabpManage.Controls.Add(this.lblManageId);
      this.tabpManage.Controls.Add(this.txtManagePassword);
      this.tabpManage.Controls.Add(this.listManage);
      this.tabpManage.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tabpManage.Location = new System.Drawing.Point(4, 34);
      this.tabpManage.Name = "tabpManage";
      this.tabpManage.Padding = new System.Windows.Forms.Padding(3);
      this.tabpManage.Size = new System.Drawing.Size(1066, 776);
      this.tabpManage.TabIndex = 0;
      this.tabpManage.Text = "Manage";
      // 
      // txtManageId
      // 
      this.txtManageId.BackColor = System.Drawing.Color.DimGray;
      this.txtManageId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtManageId.ForeColor = System.Drawing.Color.White;
      this.txtManageId.Location = new System.Drawing.Point(684, 40);
      this.txtManageId.Name = "txtManageId";
      this.txtManageId.ReadOnly = true;
      this.txtManageId.Size = new System.Drawing.Size(374, 63);
      this.txtManageId.TabIndex = 21;
      this.txtManageId.Text = "ID";
      // 
      // btnManageDelete
      // 
      this.btnManageDelete.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnManageDelete.ImageIndex = 1;
      this.btnManageDelete.ImageList = this.imglist_LoginManage;
      this.btnManageDelete.Location = new System.Drawing.Point(458, 665);
      this.btnManageDelete.Name = "btnManageDelete";
      this.btnManageDelete.Size = new System.Drawing.Size(244, 108);
      this.btnManageDelete.TabIndex = 20;
      this.btnManageDelete.Text = "Delete";
      this.btnManageDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnManageDelete.UseVisualStyleBackColor = true;
      this.btnManageDelete.Click += new System.EventHandler(this.btnManageDelete_Click);
      // 
      // imglist_LoginManage
      // 
      this.imglist_LoginManage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_LoginManage.ImageStream")));
      this.imglist_LoginManage.TransparentColor = System.Drawing.Color.Transparent;
      this.imglist_LoginManage.Images.SetKeyName(0, "100p_success-icon.png");
      this.imglist_LoginManage.Images.SetKeyName(1, "100p_Business-Bad-Decision-icon.png");
      this.imglist_LoginManage.Images.SetKeyName(2, "100p_Arrows-Undo-icon.png");
      // 
      // btnManageBack
      // 
      this.btnManageBack.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnManageBack.ImageIndex = 2;
      this.btnManageBack.ImageList = this.imglist_LoginManage;
      this.btnManageBack.Location = new System.Drawing.Point(816, 665);
      this.btnManageBack.Name = "btnManageBack";
      this.btnManageBack.Size = new System.Drawing.Size(244, 108);
      this.btnManageBack.TabIndex = 19;
      this.btnManageBack.Text = "Back to login";
      this.btnManageBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnManageBack.UseVisualStyleBackColor = true;
      this.btnManageBack.Click += new System.EventHandler(this.btnCreateBack_Click);
      // 
      // btnManageApply
      // 
      this.btnManageApply.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.btnManageApply.ImageIndex = 0;
      this.btnManageApply.ImageList = this.imglist_LoginManage;
      this.btnManageApply.Location = new System.Drawing.Point(684, 378);
      this.btnManageApply.Name = "btnManageApply";
      this.btnManageApply.Size = new System.Drawing.Size(374, 108);
      this.btnManageApply.TabIndex = 18;
      this.btnManageApply.Text = "Apply";
      this.btnManageApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnManageApply.UseVisualStyleBackColor = true;
      this.btnManageApply.Click += new System.EventHandler(this.btnManageApply_Click);
      // 
      // lblManageLevel
      // 
      this.lblManageLevel.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblManageLevel.Location = new System.Drawing.Point(458, 324);
      this.lblManageLevel.Name = "lblManageLevel";
      this.lblManageLevel.Size = new System.Drawing.Size(220, 48);
      this.lblManageLevel.TabIndex = 17;
      this.lblManageLevel.Text = "Level:";
      // 
      // cboManageLevel
      // 
      this.cboManageLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboManageLevel.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.cboManageLevel.FormattingEnabled = true;
      this.cboManageLevel.Location = new System.Drawing.Point(684, 316);
      this.cboManageLevel.Name = "cboManageLevel";
      this.cboManageLevel.Size = new System.Drawing.Size(374, 56);
      this.cboManageLevel.TabIndex = 16;
      // 
      // lblManageInfo
      // 
      this.lblManageInfo.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblManageInfo.Location = new System.Drawing.Point(458, 262);
      this.lblManageInfo.Name = "lblManageInfo";
      this.lblManageInfo.Size = new System.Drawing.Size(220, 48);
      this.lblManageInfo.TabIndex = 15;
      this.lblManageInfo.Text = "Info:";
      // 
      // txtManageInfo
      // 
      this.txtManageInfo.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtManageInfo.Location = new System.Drawing.Point(684, 247);
      this.txtManageInfo.Name = "txtManageInfo";
      this.txtManageInfo.ReadOnly = true;
      this.txtManageInfo.Size = new System.Drawing.Size(374, 63);
      this.txtManageInfo.TabIndex = 14;
      this.txtManageInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // lblManagePasswordC
      // 
      this.lblManagePasswordC.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblManagePasswordC.Location = new System.Drawing.Point(458, 193);
      this.lblManagePasswordC.Name = "lblManagePasswordC";
      this.lblManagePasswordC.Size = new System.Drawing.Size(220, 48);
      this.lblManagePasswordC.TabIndex = 13;
      this.lblManagePasswordC.Text = "C PW(*):";
      // 
      // txtManagePasswordC
      // 
      this.txtManagePasswordC.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtManagePasswordC.Location = new System.Drawing.Point(684, 178);
      this.txtManagePasswordC.Name = "txtManagePasswordC";
      this.txtManagePasswordC.ReadOnly = true;
      this.txtManagePasswordC.Size = new System.Drawing.Size(374, 63);
      this.txtManagePasswordC.TabIndex = 12;
      this.txtManagePasswordC.UseSystemPasswordChar = true;
      this.txtManagePasswordC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // lblManagePassword
      // 
      this.lblManagePassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblManagePassword.Location = new System.Drawing.Point(458, 124);
      this.lblManagePassword.Name = "lblManagePassword";
      this.lblManagePassword.Size = new System.Drawing.Size(220, 48);
      this.lblManagePassword.TabIndex = 11;
      this.lblManagePassword.Text = "PW(*):";
      // 
      // lblManageId
      // 
      this.lblManageId.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lblManageId.Location = new System.Drawing.Point(458, 55);
      this.lblManageId.Name = "lblManageId";
      this.lblManageId.Size = new System.Drawing.Size(220, 48);
      this.lblManageId.TabIndex = 10;
      this.lblManageId.Text = "ID(*):";
      // 
      // txtManagePassword
      // 
      this.txtManagePassword.Font = new System.Drawing.Font("Gulim", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtManagePassword.Location = new System.Drawing.Point(684, 109);
      this.txtManagePassword.Name = "txtManagePassword";
      this.txtManagePassword.ReadOnly = true;
      this.txtManagePassword.Size = new System.Drawing.Size(374, 63);
      this.txtManagePassword.TabIndex = 9;
      this.txtManagePassword.UseSystemPasswordChar = true;
      this.txtManagePassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
      // 
      // listManage
      // 
      this.listManage.Font = new System.Drawing.Font("Gulim", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.listManage.FormattingEnabled = true;
      this.listManage.ItemHeight = 27;
      this.listManage.Location = new System.Drawing.Point(39, 40);
      this.listManage.Name = "listManage";
      this.listManage.Size = new System.Drawing.Size(413, 733);
      this.listManage.TabIndex = 0;
      this.listManage.Click += new System.EventHandler(this.listManage_Click);
      // 
      // FormPageLoginManage
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1074, 814);
      this.ControlBox = false;
      this.Controls.Add(this.tabLoginManage);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPageLoginManage";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPageLoginManage";
      this.Load += new System.EventHandler(this.FormPageLoginManage_Load);
      this.Shown += new System.EventHandler(this.FormPageLoginManage_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormPageLoginManage_VisibleChanged);
      this.tabLoginManage.ResumeLayout(false);
      this.tabpManage.ResumeLayout(false);
      this.tabpManage.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabLoginManage;
    private System.Windows.Forms.TabPage tabpManage;
    private System.Windows.Forms.ListBox listManage;
    private System.Windows.Forms.Label lblManageLevel;
    private System.Windows.Forms.ComboBox cboManageLevel;
    private System.Windows.Forms.Label lblManageInfo;
    private System.Windows.Forms.TextBox txtManageInfo;
    private System.Windows.Forms.Label lblManagePasswordC;
    private System.Windows.Forms.TextBox txtManagePasswordC;
    private System.Windows.Forms.Label lblManagePassword;
    private System.Windows.Forms.Label lblManageId;
    private System.Windows.Forms.TextBox txtManagePassword;
    private System.Windows.Forms.Button btnManageBack;
    private System.Windows.Forms.Button btnManageApply;
    private System.Windows.Forms.Button btnManageDelete;
    private System.Windows.Forms.TextBox txtManageId;
    private System.Windows.Forms.ImageList imglist_LoginManage;
  }
}