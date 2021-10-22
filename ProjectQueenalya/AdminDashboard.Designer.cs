namespace ProjectQueenalya
{
    partial class AdminDashboard
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnCloseChild = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAkun = new System.Windows.Forms.Button();
            this.btnInstansi = new System.Windows.Forms.Button();
            this.btnSiswa = new System.Windows.Forms.Button();
            this.btnPebimbing = new System.Windows.Forms.Button();
            this.btnSlide = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnAkun);
            this.panelMenu.Controls.Add(this.btnInstansi);
            this.panelMenu.Controls.Add(this.btnSiswa);
            this.panelMenu.Controls.Add(this.btnPebimbing);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(144, 429);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.btnSlide);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(144, 55);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnCloseChild);
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(144, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(587, 42);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(541, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 29);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.Text = "O";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Location = new System.Drawing.Point(567, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(20, 29);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.Text = "O";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 9.77F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(78, 17);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "BERANDA";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(144, 42);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(587, 387);
            this.panelDesktop.TabIndex = 2;
            // 
            // btnCloseChild
            // 
            this.btnCloseChild.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChild.FlatAppearance.BorderSize = 0;
            this.btnCloseChild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChild.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseChild.ForeColor = System.Drawing.Color.White;
            this.btnCloseChild.Image = global::ProjectQueenalya.Properties.Resources.Beranda_24x241;
            this.btnCloseChild.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChild.Name = "btnCloseChild";
            this.btnCloseChild.Size = new System.Drawing.Size(20, 42);
            this.btnCloseChild.TabIndex = 7;
            this.btnCloseChild.UseVisualStyleBackColor = true;
            this.btnCloseChild.Click += new System.EventHandler(this.btnCloseChild_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Verdana", 8.6F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::ProjectQueenalya.Properties.Resources.logout;
            this.btnLogout.Location = new System.Drawing.Point(0, 381);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.btnLogout.Size = new System.Drawing.Size(144, 48);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Tag = "   Keluar";
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAkun
            // 
            this.btnAkun.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAkun.FlatAppearance.BorderSize = 0;
            this.btnAkun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAkun.Font = new System.Drawing.Font("Verdana", 8.6F);
            this.btnAkun.ForeColor = System.Drawing.Color.White;
            this.btnAkun.Image = global::ProjectQueenalya.Properties.Resources.user_3_;
            this.btnAkun.Location = new System.Drawing.Point(0, 199);
            this.btnAkun.Name = "btnAkun";
            this.btnAkun.Size = new System.Drawing.Size(144, 48);
            this.btnAkun.TabIndex = 3;
            this.btnAkun.Tag = "    Akun";
            this.btnAkun.Text = "Pengguna";
            this.btnAkun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAkun.UseVisualStyleBackColor = true;
            this.btnAkun.Click += new System.EventHandler(this.btnAkun_Click);
            // 
            // btnInstansi
            // 
            this.btnInstansi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInstansi.FlatAppearance.BorderSize = 0;
            this.btnInstansi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstansi.Font = new System.Drawing.Font("Verdana", 8.6F);
            this.btnInstansi.ForeColor = System.Drawing.Color.White;
            this.btnInstansi.Image = global::ProjectQueenalya.Properties.Resources.overload;
            this.btnInstansi.Location = new System.Drawing.Point(0, 151);
            this.btnInstansi.Name = "btnInstansi";
            this.btnInstansi.Size = new System.Drawing.Size(144, 48);
            this.btnInstansi.TabIndex = 2;
            this.btnInstansi.Tag = "   Instansi";
            this.btnInstansi.Text = "Instansi";
            this.btnInstansi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstansi.UseVisualStyleBackColor = true;
            this.btnInstansi.Click += new System.EventHandler(this.btnInstansi_Click);
            // 
            // btnSiswa
            // 
            this.btnSiswa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSiswa.FlatAppearance.BorderSize = 0;
            this.btnSiswa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiswa.Font = new System.Drawing.Font("Verdana", 8.6F);
            this.btnSiswa.ForeColor = System.Drawing.Color.White;
            this.btnSiswa.Image = global::ProjectQueenalya.Properties.Resources.man_user;
            this.btnSiswa.Location = new System.Drawing.Point(0, 103);
            this.btnSiswa.Name = "btnSiswa";
            this.btnSiswa.Size = new System.Drawing.Size(144, 48);
            this.btnSiswa.TabIndex = 1;
            this.btnSiswa.Tag = "   Siswa";
            this.btnSiswa.Text = "         Siswa";
            this.btnSiswa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiswa.UseVisualStyleBackColor = true;
            this.btnSiswa.Click += new System.EventHandler(this.btnSiswa_Click);
            // 
            // btnPebimbing
            // 
            this.btnPebimbing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPebimbing.FlatAppearance.BorderSize = 0;
            this.btnPebimbing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPebimbing.Font = new System.Drawing.Font("Verdana", 8.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPebimbing.ForeColor = System.Drawing.Color.White;
            this.btnPebimbing.Image = global::ProjectQueenalya.Properties.Resources._2_users;
            this.btnPebimbing.Location = new System.Drawing.Point(0, 55);
            this.btnPebimbing.Name = "btnPebimbing";
            this.btnPebimbing.Size = new System.Drawing.Size(144, 48);
            this.btnPebimbing.TabIndex = 0;
            this.btnPebimbing.Tag = " Pembimbing";
            this.btnPebimbing.Text = "Pebimbing";
            this.btnPebimbing.UseVisualStyleBackColor = true;
            this.btnPebimbing.Click += new System.EventHandler(this.btnPebimbing_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSlide.FlatAppearance.BorderSize = 0;
            this.btnSlide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlide.ForeColor = System.Drawing.Color.White;
            this.btnSlide.Image = global::ProjectQueenalya.Properties.Resources.menu_2_;
            this.btnSlide.Location = new System.Drawing.Point(113, 0);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(31, 55);
            this.btnSlide.TabIndex = 0;
            this.btnSlide.UseVisualStyleBackColor = true;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 46);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 429);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.Resize += new System.EventHandler(this.AdminDashboard_Resize);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPebimbing;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAkun;
        private System.Windows.Forms.Button btnInstansi;
        private System.Windows.Forms.Button btnSiswa;
        private System.Windows.Forms.Button btnSlide;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnCloseChild;
    }
}