using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormAbsen : Form
    {
        PKLEntities dfs;
        public FormAbsen()
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
            foreach (Control btns in panel.Controls)
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
        private void FormAbsen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Absen' table. You can move, or remove it, as needed.
            this.absenTableAdapter.Fill(this.pKLDataSet.Absen);
            panel.Enabled = false;
            dfs = new PKLEntities();
            absenBindingSource.DataSource = dfs.Instansis.ToList();
            LoadTheme();
            btnRefresh.PerformClick();
            btnCancel.Visible = false;
            AutoID();
        }
        private void AutoID()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama_siswa FROM Absen", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["nama_siswa"].ToString());
                    }
                    txtID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtID.AutoCompleteCustomSource = MyCollection;
                    txtCari.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtCari.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCari.AutoCompleteCustomSource = MyCollection;
                    con.Close();
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                        using (DataTable dt = new DataTable("Absen"))
                        {
                            using (SqlCommand cmda = new SqlCommand("SELECT * FROM Absen ORDER BY id ASC", cn))
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter(cmda);
                                DataTable dsa = new DataTable();
                                adapter.Fill(dsa);
                                dataGridView1.DataSource = dsa;
                            }
                        }
                    }
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                        using (DataTable dt = new DataTable("Absen"))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Absen Where siswa_id=@siswa_id", cn))
                            {
                                cmd.Parameters.AddWithValue("siswa_id", txtCari.Text);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnCancel.Visible = false;
            btnEditShow.Visible = true;
        }

        private void btnEditShow_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            btnCancel.Visible = true;
            btnEditShow.Visible = false;
        }

        private void txtCari_Leave(object sender, EventArgs e)
        {
            if (txtCari.Text == "")
            {
                txtCari.Text = "Cari . . .";
                txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtCari.ForeColor = Color.Silver;
            }
        }

        private void txtCari_Enter(object sender, EventArgs e)
        {
            if (txtCari.Text == "Cari . . .")
            {
                txtCari.Text = "";
                txtCari.ForeColor = Color.Black;
                this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnHapusAll_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Tolong masukan id siswa yang ingin di hapus !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                            using (DataTable dt = new DataTable("Absen"))
                            {
                                using (SqlCommand cmds = new SqlCommand("DELETE Absen WHERE siswa_id=@ID", cn))
                                {

                                    cmds.Parameters.AddWithValue("ID", txtID.Text);
                                    cmds.ExecuteNonQuery();
                                    if (MessageBox.Show("Berhasil Menghapus data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                    {
                                        txtID.Text = "";
                                        btnCancel.Visible = false;
                                        btnEditShow.Visible = true;
                                        panel.Enabled = false;
                                        btnRefresh.PerformClick();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHapusTanggal_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Tolong masukan id siswa yang ingin di hapus !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                            using (DataTable dt = new DataTable("Absen"))
                            {
                                if (MessageBox.Show("Apakah tanggalnya sudah benar ?", "PROPLACE MEA", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    using (SqlCommand cmds = new SqlCommand("DELETE Absen WHERE siswa_id=@ID AND tanggal=@tgl", cn))
                                    {

                                        cmds.Parameters.AddWithValue("ID", txtID.Text);
                                        cmds.Parameters.AddWithValue("tgl" , dateTimePicker1.Value.Date);
                                        cmds.ExecuteNonQuery();
                                        if (MessageBox.Show("Berhasil Menghapus data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                        {
                                            txtID.Text = "";
                                            btnCancel.Visible = false;
                                            btnEditShow.Visible = true;
                                            panel.Enabled = false;
                                            btnRefresh.PerformClick();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
