using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQueenalya.SiswaDashboardForm
{
    public partial class Absen : Form
    {
        /*Queryable=*/ //SELECT Absen.kehadiran , Absen.nama_siswa , COUNT(*) AS 'Jumlah' FROM Absen, Login WHERE Absen.nama_siswa = Login.nama AND Login.status = 'True' GROUP BY Absen.kehadiran , Absen.nama_siswa
        public Absen()
        {
            InitializeComponent();
        }
        private void Absen_Load(object sender, EventArgs e)
        {
            LoadTheme();
            panel.Enabled = false;
            btnBatal.Visible = false;
            btnSimpan.Visible = false;
        }
        private void LoadTheme()
        {
            foreach (Control btna in panel.Controls)
            {
                if (btna.GetType() == typeof(Button))
                {
                    Button btnsa = (Button)btna;
                    btnsa.BackColor = ThemeColor.PrimaryColor;
                    btnsa.ForeColor = Color.White;
                    btnsa.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            btnBatal.Visible = true;
            btnSimpan.Visible = true;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            if (!(panel.Enabled == true))
            {
                btnBatal.Visible = false;
                btnSimpan.Visible = false;
                comboBox1.Text = "";
                button3.Visible = true;
            }
        }
    }
}
