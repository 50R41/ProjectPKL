namespace ProjectQueenalya.SiswaDashboardForm
{
    partial class Absen
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
            this.panel = new System.Windows.Forms.Panel();
            this.lblNama = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.lblIzin = new System.Windows.Forms.Label();
            this.lblSakit = new System.Windows.Forms.Label();
            this.lblAlfa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAbsen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.lblNama);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.btnBatal);
            this.panel.Controls.Add(this.btnSimpan);
            this.panel.Controls.Add(this.lblIzin);
            this.panel.Controls.Add(this.lblSakit);
            this.panel.Controls.Add(this.lblAlfa);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.comboBoxAbsen);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(1, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(417, 203);
            this.panel.TabIndex = 0;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(50, 3);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(0, 13);
            this.lblNama.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nama :";
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Location = new System.Drawing.Point(204, 163);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(50, 23);
            this.btnBatal.TabIndex = 8;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Location = new System.Drawing.Point(260, 163);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // lblIzin
            // 
            this.lblIzin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIzin.AutoSize = true;
            this.lblIzin.Location = new System.Drawing.Point(124, 40);
            this.lblIzin.Name = "lblIzin";
            this.lblIzin.Size = new System.Drawing.Size(13, 13);
            this.lblIzin.TabIndex = 6;
            this.lblIzin.Text = "0";
            // 
            // lblSakit
            // 
            this.lblSakit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSakit.AutoSize = true;
            this.lblSakit.Location = new System.Drawing.Point(124, 67);
            this.lblSakit.Name = "lblSakit";
            this.lblSakit.Size = new System.Drawing.Size(13, 13);
            this.lblSakit.TabIndex = 5;
            this.lblSakit.Text = "0";
            // 
            // lblAlfa
            // 
            this.lblAlfa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAlfa.AutoSize = true;
            this.lblAlfa.Location = new System.Drawing.Point(124, 92);
            this.lblAlfa.Name = "lblAlfa";
            this.lblAlfa.Size = new System.Drawing.Size(13, 13);
            this.lblAlfa.TabIndex = 4;
            this.lblAlfa.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sakit :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alfa   :";
            // 
            // comboBoxAbsen
            // 
            this.comboBoxAbsen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxAbsen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAbsen.FormattingEnabled = true;
            this.comboBoxAbsen.Items.AddRange(new object[] {
            "Hadir",
            "Izin",
            "Sakit",
            "Alfa"});
            this.comboBoxAbsen.Location = new System.Drawing.Point(83, 129);
            this.comboBoxAbsen.Name = "comboBoxAbsen";
            this.comboBoxAbsen.Size = new System.Drawing.Size(252, 21);
            this.comboBoxAbsen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izin   :";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(330, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Absen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Absen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 285);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel);
            this.Name = "Absen";
            this.Text = "Absen";
            this.Load += new System.EventHandler(this.Absen_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label lblIzin;
        private System.Windows.Forms.Label lblSakit;
        private System.Windows.Forms.Label lblAlfa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAbsen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label7;
    }
}