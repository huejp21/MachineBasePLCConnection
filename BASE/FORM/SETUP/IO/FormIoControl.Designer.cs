namespace BASE.FORM.SETUP.IO
{
  partial class FormIoControl
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.pnlIoInput = new System.Windows.Forms.Panel();
      this.gridIoInput = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlIoTitle = new System.Windows.Forms.Panel();
      this.btnIoSave = new System.Windows.Forms.Button();
      this.btnIoClose = new System.Windows.Forms.Button();
      this.pnlIoOutput = new System.Windows.Forms.Panel();
      this.gridIoOutput = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tmrIo = new System.Windows.Forms.Timer(this.components);
      this.pnlIoInput.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridIoInput)).BeginInit();
      this.pnlIoTitle.SuspendLayout();
      this.pnlIoOutput.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridIoOutput)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlIoInput
      // 
      this.pnlIoInput.Controls.Add(this.gridIoInput);
      this.pnlIoInput.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlIoInput.Location = new System.Drawing.Point(0, 56);
      this.pnlIoInput.Name = "pnlIoInput";
      this.pnlIoInput.Size = new System.Drawing.Size(522, 565);
      this.pnlIoInput.TabIndex = 0;
      // 
      // gridIoInput
      // 
      this.gridIoInput.AllowUserToAddRows = false;
      this.gridIoInput.AllowUserToDeleteRows = false;
      this.gridIoInput.AllowUserToResizeColumns = false;
      this.gridIoInput.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.gridIoInput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.gridIoInput.BackgroundColor = System.Drawing.Color.FloralWhite;
      this.gridIoInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridIoInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.gridIoInput.ColumnHeadersHeight = 30;
      this.gridIoInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridIoInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
      this.gridIoInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridIoInput.GridColor = System.Drawing.Color.Silver;
      this.gridIoInput.Location = new System.Drawing.Point(0, 0);
      this.gridIoInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridIoInput.MultiSelect = false;
      this.gridIoInput.Name = "gridIoInput";
      this.gridIoInput.ReadOnly = true;
      this.gridIoInput.RowHeadersVisible = false;
      this.gridIoInput.RowHeadersWidth = 25;
      this.gridIoInput.RowTemplate.Height = 23;
      this.gridIoInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.gridIoInput.ShowCellErrors = false;
      this.gridIoInput.ShowEditingIcon = false;
      this.gridIoInput.ShowRowErrors = false;
      this.gridIoInput.Size = new System.Drawing.Size(522, 565);
      this.gridIoInput.StandardTab = true;
      this.gridIoInput.TabIndex = 833;
      this.gridIoInput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridIoInput_CellClick);
      this.gridIoInput.DoubleClick += new System.EventHandler(this.gridIoInput_DoubleClick);
      // 
      // Column1
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column1.HeaderText = "No";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column1.Width = 35;
      // 
      // Column2
      // 
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
      this.Column2.HeaderText = "Input Number";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 110;
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Name";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column3.Width = 300;
      // 
      // Column4
      // 
      this.Column4.HeaderText = "Type";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column4.Width = 50;
      // 
      // pnlIoTitle
      // 
      this.pnlIoTitle.Controls.Add(this.btnIoSave);
      this.pnlIoTitle.Controls.Add(this.btnIoClose);
      this.pnlIoTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlIoTitle.Location = new System.Drawing.Point(0, 0);
      this.pnlIoTitle.Name = "pnlIoTitle";
      this.pnlIoTitle.Size = new System.Drawing.Size(1044, 56);
      this.pnlIoTitle.TabIndex = 1;
      // 
      // btnIoSave
      // 
      this.btnIoSave.Location = new System.Drawing.Point(722, 0);
      this.btnIoSave.Name = "btnIoSave";
      this.btnIoSave.Size = new System.Drawing.Size(158, 56);
      this.btnIoSave.TabIndex = 1;
      this.btnIoSave.Text = "Save";
      this.btnIoSave.UseVisualStyleBackColor = true;
      this.btnIoSave.Click += new System.EventHandler(this.btnIoSave_Click);
      // 
      // btnIoClose
      // 
      this.btnIoClose.Location = new System.Drawing.Point(886, 0);
      this.btnIoClose.Name = "btnIoClose";
      this.btnIoClose.Size = new System.Drawing.Size(158, 56);
      this.btnIoClose.TabIndex = 0;
      this.btnIoClose.Text = "Close";
      this.btnIoClose.UseVisualStyleBackColor = true;
      this.btnIoClose.Click += new System.EventHandler(this.btnIoClose_Click);
      // 
      // pnlIoOutput
      // 
      this.pnlIoOutput.Controls.Add(this.gridIoOutput);
      this.pnlIoOutput.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlIoOutput.Location = new System.Drawing.Point(522, 56);
      this.pnlIoOutput.Name = "pnlIoOutput";
      this.pnlIoOutput.Size = new System.Drawing.Size(522, 565);
      this.pnlIoOutput.TabIndex = 2;
      // 
      // gridIoOutput
      // 
      this.gridIoOutput.AllowUserToAddRows = false;
      this.gridIoOutput.AllowUserToDeleteRows = false;
      this.gridIoOutput.AllowUserToResizeColumns = false;
      this.gridIoOutput.AllowUserToResizeRows = false;
      dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.gridIoOutput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
      this.gridIoOutput.BackgroundColor = System.Drawing.Color.FloralWhite;
      this.gridIoOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridIoOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.gridIoOutput.ColumnHeadersHeight = 30;
      this.gridIoOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridIoOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
      this.gridIoOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridIoOutput.GridColor = System.Drawing.Color.Silver;
      this.gridIoOutput.Location = new System.Drawing.Point(0, 0);
      this.gridIoOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridIoOutput.MultiSelect = false;
      this.gridIoOutput.Name = "gridIoOutput";
      this.gridIoOutput.ReadOnly = true;
      this.gridIoOutput.RowHeadersVisible = false;
      this.gridIoOutput.RowHeadersWidth = 25;
      this.gridIoOutput.RowTemplate.Height = 23;
      this.gridIoOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.gridIoOutput.ShowCellErrors = false;
      this.gridIoOutput.ShowEditingIcon = false;
      this.gridIoOutput.ShowRowErrors = false;
      this.gridIoOutput.Size = new System.Drawing.Size(522, 565);
      this.gridIoOutput.StandardTab = true;
      this.gridIoOutput.TabIndex = 833;
      this.gridIoOutput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridIoOutput_CellClick);
      this.gridIoOutput.DoubleClick += new System.EventHandler(this.gridIoOutput_DoubleClick);
      // 
      // dataGridViewTextBoxColumn1
      // 
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
      this.dataGridViewTextBoxColumn1.HeaderText = "No";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTextBoxColumn1.Width = 35;
      // 
      // dataGridViewTextBoxColumn2
      // 
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
      this.dataGridViewTextBoxColumn2.HeaderText = "Output Number";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTextBoxColumn2.Width = 110;
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.HeaderText = "Name";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTextBoxColumn3.Width = 300;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.HeaderText = "Type";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTextBoxColumn4.Width = 50;
      // 
      // tmrIo
      // 
      this.tmrIo.Tick += new System.EventHandler(this.tmrIo_Tick);
      // 
      // FormIoControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1044, 621);
      this.ControlBox = false;
      this.Controls.Add(this.pnlIoOutput);
      this.Controls.Add(this.pnlIoInput);
      this.Controls.Add(this.pnlIoTitle);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormIoControl";
      this.Text = "I/O";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.FormIoControl_Load);
      this.Shown += new System.EventHandler(this.FormIoControl_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormIoControl_VisibleChanged);
      this.pnlIoInput.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridIoInput)).EndInit();
      this.pnlIoTitle.ResumeLayout(false);
      this.pnlIoOutput.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridIoOutput)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlIoInput;
    internal System.Windows.Forms.DataGridView gridIoInput;
    private System.Windows.Forms.Panel pnlIoTitle;
    private System.Windows.Forms.Button btnIoSave;
    private System.Windows.Forms.Button btnIoClose;
    private System.Windows.Forms.Panel pnlIoOutput;
    internal System.Windows.Forms.DataGridView gridIoOutput;
    private System.Windows.Forms.Timer tmrIo;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
  }
}