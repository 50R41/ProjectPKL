using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormAkun : Form
    {
        PKLEntities dsf;
        public FormAkun()
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

        private void FormAkun_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.pKLDataSet.Login);
            LoadTheme();
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            dsf = new PKLEntities();
            loginBindingSource.DataSource = dsf.Logins.ToList();
            Auto();
            btnRefresh.PerformClick();
            AutoNama();
            AutoID();
        }
        private void Auto()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama FROM Login", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["nama"].ToString());
                    }
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
        private void AutoNama()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Guru.nama AS Gurua, Siswa.nama AS Siswad FROM Guru, Siswa", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["Gurua"].ToString());
                        MyCollection.Add(reader["Siswad"].ToString());
                    }
                    txtNama.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNama.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNama.AutoCompleteCustomSource = MyCollection;
                    con.Close();
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
        }
        private void AutoID()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nip, nis FROM Guru, Siswa", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["nip"].ToString());
                    }
                    txtUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtUser.AutoCompleteCustomSource = MyCollection;
                    con.Close();
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                txtNama.Clear();
                txtPass.Clear();
                txtUser.Clear();
                btnSimpan.Visible = true;
                btnCancel.Visible = true;
                panel.Enabled = true;
                btnEditShow.Visible = false;
                txtNama.Focus();
                lblSts.Visible = false;
                comboBoxStatus.Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditShow_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            panel.Enabled = true;
            btnEdit.Visible = true;
            btnEditShow.Visible = false;
            btnTambah.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            btnTambah.Visible = true;
            btnEditShow.Visible = true;
            lblSts.Visible = true;
            comboBoxStatus.Visible = true;
            loginBindingSource.ResetBindings(false);
            try
            {
                foreach (DbEntityEntry entry in dsf.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    using (SqlCommand Cmd = new SqlCommand("SELECT Guru.nama, Siswa.nama FROM Guru, Siswa Where Guru.nama= '" + txtNama.Text + "' OR Siswa.nama='"+ txtNama.Text +"'", cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;
                        if (i > 0)
                        {
                            try
                            {
                                if (MessageBox.Show("Apakah kamu yakin dan sudah di pastikan semua datanya benar ?", "Tabungan Siwa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Login s = new Login();
                                    s.nama = txtNama.Text;
                                    s.username = txtUser.Text;
                                    s.password = txtPass.Text;
                                    s.role = comboBoxRole.Text;
                                    dsf.Logins.Add(s);
                                    dsf.SaveChanges();
                                    if (MessageBox.Show("Berhasil Menginput Data !", "PROPLACE MEA", MessageBoxButtons.OK) == DialogResult.OK)
                                    {
                                        txtID.Text = "";
                                        txtNama.Text = "";
                                        txtUser.Text = "";
                                        txtPass.Text = "";
                                        btnCancel.Visible = false;
                                        btnSimpan.Visible = false;
                                        btnEdit.Visible = false;
                                        btnEditShow.Visible = true;
                                        btnTambah.Visible = true;
                                        btnRefresh.PerformClick();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Periksa lagi data yang ingin disimpan !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nama : " + txtNama.Text + " Belum ada !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtID.Text == "" || comboBoxRole.SelectedIndex == -1 || comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Tolong masukan data yang ingin di edit ! atau bisa click datanya di bawah !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            using (DataTable dt = new DataTable("Login"))
                            {
                                using (SqlCommand cmds = new SqlCommand("UPDATE Login SET nama=@Nama , username=@user , password=@pass , role=@role , status=@status WHERE id=@ID", cn))
                                {

                                    cmds.Parameters.AddWithValue("ID", txtID.Text);
                                    cmds.Parameters.AddWithValue("Nama", txtNama.Text);
                                    cmds.Parameters.AddWithValue("user" , txtUser.Text);
                                    cmds.Parameters.AddWithValue("pass", txtPass.Text);
                                    cmds.Parameters.AddWithValue("role", comboBoxRole.Text);
                                    cmds.Parameters.AddWithValue("status" , comboBoxStatus.Text);
                                    cmds.ExecuteNonQuery();
                                    if (MessageBox.Show("Berhasil Mengupdate data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                    {
                                        txtID.Text = "";
                                        txtNama.Text = "";
                                        txtUser.Text = "";
                                        txtPass.Text = "";
                                        btnCancel.Visible = false;
                                        btnSimpan.Visible = false;
                                        btnEdit.Visible = false;
                                        btnEditShow.Visible = true;
                                        btnTambah.Visible = true;
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                        using (DataTable dt = new DataTable("Login"))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login Where nama=@nama", cn))
                            {
                                cmd.Parameters.AddWithValue("nama", txtCari.Text);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                        using (DataTable dt = new DataTable("Login"))
                        {
                            using (SqlCommand cmda = new SqlCommand("SELECT * FROM Login ORDER BY id ASC", cn))
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow gridView = dataGridView1.Rows[e.RowIndex];
                    txtID.Text = gridView.Cells[0].Value.ToString();
                    txtNama.Text = gridView.Cells[1].Value.ToString();
                    txtUser.Text = gridView.Cells[2].Value.ToString();
                    txtPass.Text = gridView.Cells[3].Value.ToString();
                    comboBoxRole.Text = gridView.Cells[4].Value.ToString();
                    comboBoxStatus.Text = gridView.Cells[5].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Apakah Kamu yakin ingin menghapusnya ?", "PROPLACE MEA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dsf.Logins.Remove(loginBindingSource.Current as Login);
                        loginBindingSource.RemoveCurrent();
                        dsf.SaveChangesAsync();
                        MessageBox.Show("Data berhasil di hapus !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
