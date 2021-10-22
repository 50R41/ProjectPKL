using System;
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
                string myConnection = "Data Source=localhost;port=3306;username=root;password=;database=test_login_queena";
                string Query = "Select * From login where username='" + txtUSER.Text + "' and password='" + txtPASS.Text + "' and usertype='" + txtType.Text + "'";
                MySqlConnection con = new MySqlConnection(myConnection);
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (txtUSER.Text == "" || txtPASS.Text == "")
                {
                    MessageBox.Show("Tolong masukan username dan passwordnya");
                    return;

                }
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Kamu login sebagai " + txtType.Text);
                    AdminDashboard ss = new AdminDashboard();
                    ss.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid username or password" , "PKL SMKN 2 SUKABUMI" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message , "PKL SMKN 2 SUKABUMI" , MessageBoxButtons.OK , MessageBoxIcon.Information);
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
