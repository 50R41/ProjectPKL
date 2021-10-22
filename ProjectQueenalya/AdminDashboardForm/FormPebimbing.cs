using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormPebimbing : Form
    {
        public FormPebimbing()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
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

        private void FormPebimbing_Load(object sender, EventArgs e)
        {
            LoadTheme();
            panel.Enabled = false;
            btnTambah.Visible = false;
            btnEdit.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            if (!(panel.Enabled == true))
            {
                btnCancel.Visible = false;
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                btnAddEdit.Visible = true;
                txtNIP.Text = "";
                txtNama.Text = "";
                txtInstansi.Text = "";
                txtAlamat.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            if (!(panel.Enabled == false))
            {
                btnCancel.Visible = true;
                btnTambah.Visible = true;
                btnEdit.Visible = true;
                btnAddEdit.Visible = false;
            }
        }
    }
}
