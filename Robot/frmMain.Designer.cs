namespace Robot
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbTinh = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnProvinces = new System.Windows.Forms.ToolStripButton();
            this.btnCareers = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progBar = new System.Windows.Forms.ToolStripProgressBar();
            this.colIdRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbTinh,
            this.toolStripSeparator1,
            this.btnStart,
            this.btnProvinces,
            this.btnCareers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(778, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel1.Text = "P:";
            this.toolStripLabel1.ToolTipText = "Province";
            // 
            // cmbTinh
            // 
            this.cmbTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTinh.Name = "cmbTinh";
            this.cmbTinh.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Image = global::Robot.Properties.Resources.ic_resultset_next;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(51, 22);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnProvinces
            // 
            this.btnProvinces.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnProvinces.Image = global::Robot.Properties.Resources.ic_flag_red;
            this.btnProvinces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProvinces.Name = "btnProvinces";
            this.btnProvinces.Size = new System.Drawing.Size(78, 22);
            this.btnProvinces.Text = "Provinces";
            this.btnProvinces.Click += new System.EventHandler(this.btnProvinces_Click);
            // 
            // btnCareers
            // 
            this.btnCareers.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCareers.Image = global::Robot.Properties.Resources.ic_tag_blue_edit;
            this.btnCareers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCareers.Name = "btnCareers";
            this.btnCareers.Size = new System.Drawing.Size(66, 22);
            this.btnCareers.Text = "Careers";
            this.btnCareers.Click += new System.EventHandler(this.btnCareers_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRec,
            this.colCode,
            this.colPosition,
            this.colSalary,
            this.colPlace,
            this.colExpiry,
            this.colSave,
            this.colUrl});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(778, 409);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // progBar
            // 
            this.progBar.Maximum = 15;
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(100, 16);
            this.progBar.Step = 1;
            this.progBar.Visible = false;
            // 
            // colIdRec
            // 
            this.colIdRec.DataPropertyName = "IdRec";
            this.colIdRec.HeaderText = "IdRec";
            this.colIdRec.Name = "colIdRec";
            this.colIdRec.ReadOnly = true;
            this.colIdRec.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.FillWeight = 50F;
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colSalary
            // 
            this.colSalary.DataPropertyName = "Salary";
            this.colSalary.FillWeight = 50F;
            this.colSalary.HeaderText = "Salary";
            this.colSalary.Name = "colSalary";
            this.colSalary.ReadOnly = true;
            // 
            // colPlace
            // 
            this.colPlace.DataPropertyName = "Place";
            this.colPlace.HeaderText = "Place";
            this.colPlace.Name = "colPlace";
            this.colPlace.ReadOnly = true;
            // 
            // colExpiry
            // 
            this.colExpiry.DataPropertyName = "Expiry";
            this.colExpiry.FillWeight = 50F;
            this.colExpiry.HeaderText = "Expiry";
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.ReadOnly = true;
            // 
            // colSave
            // 
            this.colSave.DataPropertyName = "Saved";
            this.colSave.FillWeight = 30F;
            this.colSave.HeaderText = "Save";
            this.colSave.Name = "colSave";
            this.colSave.ReadOnly = true;
            // 
            // colUrl
            // 
            this.colUrl.DataPropertyName = "Url";
            this.colUrl.HeaderText = "URL";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            this.colUrl.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 456);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox cmbTinh;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progBar;
        private System.Windows.Forms.ToolStripButton btnProvinces;
        private System.Windows.Forms.ToolStripButton btnCareers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiry;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
    }
}

