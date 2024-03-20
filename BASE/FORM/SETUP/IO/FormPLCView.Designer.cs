namespace BASE.FORM.SETUP.IO
{
  partial class FormPLCView
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      this.pnlIoTitle = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.pnlIoInput = new System.Windows.Forms.Panel();
      this.gridIoInput = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlIoOutput = new System.Windows.Forms.Panel();
      this.gridIoOutput = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.gridDataInput = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel2 = new System.Windows.Forms.Panel();
      this.gridDataOutput = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tmr_PLCData = new System.Windows.Forms.Timer(this.components);
      this.pnlIoTitle.SuspendLayout();
      this.pnlIoInput.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridIoInput)).BeginInit();
      this.pnlIoOutput.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridIoOutput)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridDataInput)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridDataOutput)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlIoTitle
      // 
      this.pnlIoTitle.Controls.Add(this.btnClose);
      this.pnlIoTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlIoTitle.Location = new System.Drawing.Point(0, 0);
      this.pnlIoTitle.Name = "pnlIoTitle";
      this.pnlIoTitle.Size = new System.Drawing.Size(820, 56);
      this.pnlIoTitle.TabIndex = 3;
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(662, 0);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(158, 56);
      this.btnClose.TabIndex = 0;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // pnlIoInput
      // 
      this.pnlIoInput.Controls.Add(this.gridIoInput);
      this.pnlIoInput.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlIoInput.Location = new System.Drawing.Point(0, 56);
      this.pnlIoInput.Name = "pnlIoInput";
      this.pnlIoInput.Size = new System.Drawing.Size(130, 565);
      this.pnlIoInput.TabIndex = 4;
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
            this.Column1});
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
      this.gridIoInput.Size = new System.Drawing.Size(130, 565);
      this.gridIoInput.StandardTab = true;
      this.gridIoInput.TabIndex = 833;
      // 
      // Column1
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column1.HeaderText = "Input No";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // pnlIoOutput
      // 
      this.pnlIoOutput.Controls.Add(this.gridIoOutput);
      this.pnlIoOutput.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlIoOutput.Location = new System.Drawing.Point(130, 56);
      this.pnlIoOutput.Name = "pnlIoOutput";
      this.pnlIoOutput.Size = new System.Drawing.Size(130, 565);
      this.pnlIoOutput.TabIndex = 5;
      // 
      // gridIoOutput
      // 
      this.gridIoOutput.AllowUserToAddRows = false;
      this.gridIoOutput.AllowUserToDeleteRows = false;
      this.gridIoOutput.AllowUserToResizeColumns = false;
      this.gridIoOutput.AllowUserToResizeRows = false;
      dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.gridIoOutput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
      this.gridIoOutput.BackgroundColor = System.Drawing.Color.FloralWhite;
      this.gridIoOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridIoOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.gridIoOutput.ColumnHeadersHeight = 30;
      this.gridIoOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridIoOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
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
      this.gridIoOutput.Size = new System.Drawing.Size(130, 565);
      this.gridIoOutput.StandardTab = true;
      this.gridIoOutput.TabIndex = 833;
      this.gridIoOutput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridIoOutput_CellClick);
      // 
      // dataGridViewTextBoxColumn1
      // 
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
      this.dataGridViewTextBoxColumn1.HeaderText = "Output No";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.gridDataInput);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(260, 56);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(280, 565);
      this.panel1.TabIndex = 6;
      // 
      // gridDataInput
      // 
      this.gridDataInput.AllowUserToAddRows = false;
      this.gridDataInput.AllowUserToDeleteRows = false;
      this.gridDataInput.AllowUserToResizeColumns = false;
      this.gridDataInput.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.gridDataInput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      this.gridDataInput.BackgroundColor = System.Drawing.Color.FloralWhite;
      this.gridDataInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridDataInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
      this.gridDataInput.ColumnHeadersHeight = 30;
      this.gridDataInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridDataInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column2});
      this.gridDataInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridDataInput.GridColor = System.Drawing.Color.Silver;
      this.gridDataInput.Location = new System.Drawing.Point(0, 0);
      this.gridDataInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridDataInput.MultiSelect = false;
      this.gridDataInput.Name = "gridDataInput";
      this.gridDataInput.ReadOnly = true;
      this.gridDataInput.RowHeadersVisible = false;
      this.gridDataInput.RowHeadersWidth = 25;
      this.gridDataInput.RowTemplate.Height = 23;
      this.gridDataInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.gridDataInput.ShowCellErrors = false;
      this.gridDataInput.ShowEditingIcon = false;
      this.gridDataInput.ShowRowErrors = false;
      this.gridDataInput.Size = new System.Drawing.Size(280, 565);
      this.gridDataInput.StandardTab = true;
      this.gridDataInput.TabIndex = 833;
      // 
      // dataGridViewTextBoxColumn2
      // 
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
      this.dataGridViewTextBoxColumn2.HeaderText = "Input No";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column2
      // 
      dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle10;
      this.Column2.HeaderText = "Data";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 150;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.gridDataOutput);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel2.Location = new System.Drawing.Point(540, 56);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(280, 565);
      this.panel2.TabIndex = 7;
      // 
      // gridDataOutput
      // 
      this.gridDataOutput.AllowUserToAddRows = false;
      this.gridDataOutput.AllowUserToDeleteRows = false;
      this.gridDataOutput.AllowUserToResizeColumns = false;
      this.gridDataOutput.AllowUserToResizeRows = false;
      dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.gridDataOutput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
      this.gridDataOutput.BackgroundColor = System.Drawing.Color.FloralWhite;
      this.gridDataOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.gridDataOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
      this.gridDataOutput.ColumnHeadersHeight = 30;
      this.gridDataOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridDataOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
      this.gridDataOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridDataOutput.GridColor = System.Drawing.Color.Silver;
      this.gridDataOutput.Location = new System.Drawing.Point(0, 0);
      this.gridDataOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridDataOutput.MultiSelect = false;
      this.gridDataOutput.Name = "gridDataOutput";
      this.gridDataOutput.ReadOnly = true;
      this.gridDataOutput.RowHeadersVisible = false;
      this.gridDataOutput.RowHeadersWidth = 25;
      this.gridDataOutput.RowTemplate.Height = 23;
      this.gridDataOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.gridDataOutput.ShowCellErrors = false;
      this.gridDataOutput.ShowEditingIcon = false;
      this.gridDataOutput.ShowRowErrors = false;
      this.gridDataOutput.Size = new System.Drawing.Size(280, 565);
      this.gridDataOutput.StandardTab = true;
      this.gridDataOutput.TabIndex = 833;
      this.gridDataOutput.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDataOutput_CellClick);
      // 
      // dataGridViewTextBoxColumn3
      // 
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle13;
      this.dataGridViewTextBoxColumn3.HeaderText = "Output No";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn4
      // 
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
      this.dataGridViewTextBoxColumn4.HeaderText = "Data";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTextBoxColumn4.Width = 150;
      // 
      // tmr_PLCData
      // 
      this.tmr_PLCData.Interval = 1;
      this.tmr_PLCData.Tick += new System.EventHandler(this.tmr_PLCData_Tick);
      // 
      // FormPLCView
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(820, 621);
      this.ControlBox = false;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pnlIoOutput);
      this.Controls.Add(this.pnlIoInput);
      this.Controls.Add(this.pnlIoTitle);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormPLCView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPLCData";
      this.Shown += new System.EventHandler(this.FormPLCData_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormPLCData_VisibleChanged);
      this.pnlIoTitle.ResumeLayout(false);
      this.pnlIoInput.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridIoInput)).EndInit();
      this.pnlIoOutput.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridIoOutput)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridDataInput)).EndInit();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridDataOutput)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlIoTitle;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Panel pnlIoInput;
    internal System.Windows.Forms.DataGridView gridIoInput;
    private System.Windows.Forms.Panel pnlIoOutput;
    internal System.Windows.Forms.DataGridView gridIoOutput;
    private System.Windows.Forms.Panel panel1;
    internal System.Windows.Forms.DataGridView gridDataInput;
    private System.Windows.Forms.Panel panel2;
    internal System.Windows.Forms.DataGridView gridDataOutput;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.Timer tmr_PLCData;
  }
}