
namespace ProjectQueenalya.AdminDashboardForm
{
    partial class FormAbsen
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
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namasiswaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kehadiranDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pKLDataSet = new ProjectQueenalya.PKLDataSet();
            this.btnEditShow = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHapusTanggal = new System.Windows.Forms.Button();
            this.btnHapusAll = new System.Windows.Forms.Button();
            this.absenTableAdapter = new ProjectQueenalya.PKLDataSetTableAdapters.AbsenTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKLDataSet)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCari
            // 
            this.txtCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.ForeColor = System.Drawing.Color.Silver;
            this.txtCari.Location = new System.Drawing.Point(299, 138);
            this.txtCari.MaximumSize = new System.Drawing.Size(400, 20);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(171, 20);
            this.txtCari.TabIndex = 68;
            this.txtCari.Text = "Cari . . .";
            this.txtCari.Enter += new System.EventHandler(this.txtCari_Enter);
            this.txtCari.Leave += new System.EventHandler(this.txtCari_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID         :";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(71, 16);
            this.txtID.MaximumSize = new System.Drawing.Size(600, 42);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(222, 20);
            this.txtID.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(467, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 30);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(527, 136);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 23);
            this.btnRefresh.TabIndex = 62;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Location = new System.Drawing.Point(476, 136);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(45, 23);
            this.btnCari.TabIndex = 61;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.namasiswaDataGridViewTextBoxColumn,
            this.kehadiranDataGridViewTextBoxColumn,
            this.tanggalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.absenBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(287, 387);
            this.dataGridView1.TabIndex = 59;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // namasiswaDataGridViewTextBoxColumn
            // 
            this.namasiswaDataGridViewTextBoxColumn.DataPropertyName = "nama_siswa";
            this.namasiswaDataGridViewTextBoxColumn.HeaderText = "Nama Siswa";
            this.namasiswaDataGridViewTextBoxColumn.Name = "namasiswaDataGridViewTextBoxColumn";
            // 
            // kehadiranDataGridViewTextBoxColumn
            // 
            this.kehadiranDataGridViewTextBoxColumn.DataPropertyName = "kehadiran";
            this.kehadiranDataGridViewTextBoxColumn.HeaderText = "Kehadiran";
            this.kehadiranDataGridViewTextBoxColumn.Name = "kehadiranDataGridViewTextBoxColumn";
            // 
            // tanggalDataGridViewTextBoxColumn
            // 
            this.tanggalDataGridViewTextBoxColumn.DataPropertyName = "tanggal";
            this.tanggalDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            this.tanggalDataGridViewTextBoxColumn.Name = "tanggalDataGridViewTextBoxColumn";
            // 
            // absenBindingSource
            // 
            this.absenBindingSource.DataMember = "Absen";
            this.absenBindingSource.DataSource = this.pKLDataSet;
            // 
            // pKLDataSet
            // 
            this.pKLDataSet.DataSetName = "PKLDataSet";
            this.pKLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnEditShow
            // 
            this.btnEditShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditShow.Location = new System.Drawing.Point(527, 164);
            this.btnEditShow.Name = "btnEditShow";
            this.btnEditShow.Size = new System.Drawing.Size(48, 30);
            this.btnEditShow.TabIndex = 67;
            this.btnEditShow.Text = "Edit";
            this.btnEditShow.UseVisualStyleBackColor = true;
            this.btnEditShow.Click += new System.EventHandler(this.btnEditShow_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.dateTimePicker1);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.btnHapusTanggal);
            this.panel.Controls.Add(this.btnHapusAll);
            this.panel.Controls.Add(this.txtID);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(288, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(299, 124);
            this.panel.TabIndex = 69;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(71, 46);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 75;
            this.dateTimePicker1.Value = new System.DateTime(2021, 11, 2, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Tanggal  :";
            // 
            // btnHapusTanggal
            // 
            this.btnHapusTanggal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapusTanggal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusTanggal.Location = new System.Drawing.Point(49, 81);
            this.btnHapusTanggal.Name = "btnHapusTanggal";
            this.btnHapusTanggal.Size = new System.Drawing.Size(152, 30);
            this.btnHapusTanggal.TabIndex = 72;
            this.btnHapusTanggal.Text = "Hapus yang tanggal merah";
            this.btnHapusTanggal.UseVisualStyleBackColor = true;
            this.btnHapusTanggal.Click += new System.EventHandler(this.btnHapusTanggal_Click);
            // 
            // btnHapusAll
            // 
            this.btnHapusAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapusAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusAll.Location = new System.Drawing.Point(207, 81);
            this.btnHapusAll.Name = "btnHapusAll";
            this.btnHapusAll.Size = new System.Drawing.Size(79, 30);
            this.btnHapusAll.TabIndex = 71;
            this.btnHapusAll.Text = "Reset Absen";
            this.btnHapusAll.UseVisualStyleBackColor = true;
            this.btnHapusAll.Click += new System.EventHandler(this.btnHapusAll_Click);
            // 
            // absenTableAdapter
            // 
            this.absenTableAdapter.ClearBeforeFill = true;
            // 
            // FormAbsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 387);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEditShow);
            this.Name = "FormAbsen";
            this.Text = "Absen";
            this.Load += new System.EventHandler(this.FormAbsen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKLDataSet)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditShow;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnHapusAll;
        private System.Windows.Forms.Button btnHapusTanggal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private PKLDataSet pKLDataSet;
        private System.Windows.Forms.BindingSource absenBindingSource;
        private PKLDataSetTableAdapters.AbsenTableAdapter absenTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namasiswaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kehadiranDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
    }
}