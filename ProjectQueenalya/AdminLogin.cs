﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace ProjectQueenalya
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtUSER.Text == "" || txtPASS.Text == "")
                {
                    MessageBox.Show("Harap masukkan username dan password anda..");
                }
                else
                {
                    ConLogin bukaFungsi = new ConLogin();
                    DataTable dt = new DataTable();
                    string query = "select username,password,usertype from login where username='{0}'and password='{1}'";
                    query = string.Format(query, txtUSER.Text, txtPASS.Text);
                    dt = bukaFungsi.BukaTable(query);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login berhasil ! , anda login sebagai : " + dt.Rows[0][2].ToString() + "" , "PKL SMKN 2 SUKABUMI" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                        if (dt.Rows[0][2].ToString() == "admin")
                        {
                            AdminDashboard sd = new AdminDashboard();
                            sd.Show();
                            this.Hide();
                        }
                        else if (dt.Rows[0][2].ToString() == "pebimbing")
                        {
                            PebimbingDashboard sd = new PebimbingDashboard();
                            sd.Show();
                            this.Hide();
                        }
                        else if (dt.Rows[0][2].ToString() == "siswa")
                        {
                            SiswaDashboard sd = new SiswaDashboard();
                            sd.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau password anda salah.." , "PKL SMKN 2 SUKABUMI" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "PKL SMKN 2 SUKABUMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AdminLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
