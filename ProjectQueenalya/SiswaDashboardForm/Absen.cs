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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            if (!(panel.Enabled == true))
            {
                btnBatal.Visible = false;
                btnSimpan.Visible = false;
                comboBox1.Text = "";
            }
        }
    }
}
