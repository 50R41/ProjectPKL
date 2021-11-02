using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormSiswa : Form
    {
        PKLEntities tes;
        public FormSiswa()
        {
            InitializeComponent();
        }
        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            if (!(panel.Enabled == false))
            {
                btnCancel.Visible = true;
                btnTambah.Visible = true;
                btnEdit.Visible = true;;
            }
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

        private void FormSiswa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Siswa' table. You can move, or remove it, as needed.
            this.siswaTableAdapter.Fill(this.pKLDataSet.Siswa);
            LoadTheme();
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            tes = new PKLEntities();
            siswaBindingSource.DataSource = tes.Siswas.ToList();
            Auto();
            Autoinstansi();
        }
        private void Auto()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama, instansi_nama FROM Siswa", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["nama"].ToString());
                        MyCollection.Add(reader["instansi_nama"].ToString());
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
        private void Autoinstansi()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama FROM Instansi", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader["nama"].ToString());
                    }
                    txtInstansi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtInstansi.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtInstansi.AutoCompleteCustomSource = MyCollection;
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
                txtNIS.Text = "";
                txtNama.Text = "";
                txtAlamat.Text = "";
                txtInstansi.Text = "";
                txtNoHP.Text = "";
                btnSimpan.Visible = true;
                btnCancel.Visible = true;
                panel.Enabled = true;
                btnEditShow.Visible = false;
                txtNIS.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] ConvertFoto(string sPath)
        {
            byte[] data = null;
            FileInfo fileInfo = new FileInfo(sPath);
            long num = fileInfo.Length;
            FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes((int)num);
            return data;
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtAlamat.Text == "" || txtInstansi.Text == "" || comboBoxKelas.SelectedIndex == -1 || txtNoHP.Text == "" || txtNIS.Text == "")
            {
                MessageBox.Show("Tolong masukan data yang ingin di simpan !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                        using (SqlCommand cmk = new SqlCommand("SELECT nama FROM Instansi Where nama= '" + txtInstansi.Text + "'", cn))
                        {
                            SqlDataAdapter daa = new SqlDataAdapter(cmk);
                            DataSet dsa = new DataSet();
                            daa.Fill(dsa);
                            int i = dsa.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                using (SqlCommand Cmd = new SqlCommand("SELECT nama FROM Siswa Where nama= '" + txtNama.Text + "'", cn))
                                {
                                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                                    DataSet ds = new DataSet();
                                    da.Fill(ds);
                                    int ia = ds.Tables[0].Rows.Count;
                                    if (ia > 0)
                                    {
                                        MessageBox.Show("Nama : " + txtNama.Text + " Sudah ada !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (MessageBox.Show("Apakah kamu yakin dan sudah di pastikan semua datanya benar ?", "Tabungan Siwa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                Siswa s = new Siswa();
                                                s.nis = Convert.ToInt64(txtNIS.Text);
                                                s.nama = txtNama.Text;
                                                s.kelas = comboBoxKelas.Text;
                                                s.alamat = txtAlamat.Text;
                                                s.instansi_nama = txtInstansi.Text;
                                                s.no_hp = Convert.ToInt64(txtNoHP.Text);
                                                s.foto_siswa = ConvertFoto(this.pbImage.ImageLocation);
                                                tes.Siswas.Add(s);
                                                tes.SaveChanges();
                                                panel.Enabled = false;
                                                if (MessageBox.Show("Berhasil Menginput Data !", "PERJAKA MEA", MessageBoxButtons.OK) == DialogResult.OK)
                                                {
                                                    txtNIS.Text = "";
                                                    txtNama.Text = "";
                                                    txtAlamat.Text = "";
                                                    txtNoHP.Text = "";
                                                    txtInstansi.Text = "";
                                                    btnCancel.Visible = false;
                                                    btnSimpan.Visible = false;
                                                    btnEdit.Visible = false;
                                                    btnEditShow.Visible = true;
                                                    btnTambah.Visible = true;
                                                }
                                            }
                                        }
                                        catch (Exception sa)
                                        {
                                            MessageBox.Show(/*"Lihat lagi datanya, apakah ada yang belum ke input atau enggak !"*/ sa.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Instansi : " + txtInstansi.Text + " Belum ada !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ( txtID.Text == "" || txtNama.Text == "" || txtAlamat.Text == "" || txtInstansi.Text == "" || comboBoxKelas.SelectedIndex == -1)
            {
                MessageBox.Show("Tolong masukan data yang ingin di edit ! atau bisa klik datanya di bawah !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                {
                    using (SqlCommand cmk = new SqlCommand("SELECT nama FROM Instansi Where nama= '" + txtInstansi.Text + "'", cn))
                    {
                        SqlDataAdapter daa = new SqlDataAdapter(cmk);
                        DataSet dsa = new DataSet();
                        daa.Fill(dsa);
                        int Sd = dsa.Tables[0].Rows.Count;
                        if ( Sd > 0)
                        {
                            try
                            {
                                using (SqlCommand Cmd = new SqlCommand("SELECT nama FROM Siswa Where nama= '" + txtNama.Text + "'", cn))
                                {
                                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                                    DataSet ds = new DataSet();
                                    da.Fill(ds);
                                    int Cda = ds.Tables[0].Rows.Count;
                                    if (Cda > 0)
                                    {
                                        MessageBox.Show("Nama : " + txtNama.Text + " Sudah ada !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (cn.State == ConnectionState.Closed)
                                        {
                                            cn.Open();
                                            using (DataTable dt = new DataTable("Siswa"))
                                            {
                                                using (SqlCommand cmds = new SqlCommand("UPDATE Siswa SET nis=@nis, nama=@Nama , kelas=@kelas , alamat=@Alamat , no_hp=@no , instansi_nama=@instansi , foto_siswa=@foto WHERE id=@id", cn))
                                                {
                                                    cmds.Parameters.AddWithValue("id", txtID.Text);
                                                    cmds.Parameters.AddWithValue("nis", txtNIS.Text);
                                                    cmds.Parameters.AddWithValue("Nama", txtNama.Text);
                                                    cmds.Parameters.AddWithValue("kelas", comboBoxKelas.Text);
                                                    cmds.Parameters.AddWithValue("Alamat", txtAlamat.Text);
                                                    cmds.Parameters.AddWithValue("no", txtNoHP.Text);
                                                    cmds.Parameters.AddWithValue("instansi", txtInstansi.Text);
                                                    cmds.Parameters.AddWithValue("foto", ConvertFoto(this.pbImage.ImageLocation));
                                                    cmds.ExecuteNonQuery();
                                                    if (MessageBox.Show("Berhasil Mengupdate data !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                                    {
                                                        txtNIS.Text = "";
                                                        txtNama.Text = "";
                                                        txtAlamat.Text = "";
                                                        txtNoHP.Text = "";
                                                        txtInstansi.Text = "";
                                                        btnCancel.Visible = false;
                                                        btnSimpan.Visible = false;
                                                        btnEdit.Visible = false;
                                                        btnEditShow.Visible = true;
                                                        btnTambah.Visible = true;
                                                        panel.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }   
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Instansi : " + txtInstansi.Text + " Belum ada !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            btnTambah.Visible = true;
            btnEditShow.Visible = true;
            siswaBindingSource.ResetBindings(false);
            txtID.Undo();
            try
            {
                foreach (DbEntityEntry entry in tes.ChangeTracker.Entries())
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

        private void btnEditShow_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            panel.Enabled = true;
            btnEdit.Visible = true;
            btnEditShow.Visible = false;
            btnTambah.Visible = false;
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
                        using (DataTable dt = new DataTable("Siswa"))
                        {
                            using (SqlCommand cmda = new SqlCommand("SELECT * FROM Siswa ORDER BY id ASC", cn))
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
                MessageBox.Show(ms.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        using (DataTable dt = new DataTable("Siswa"))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Siswa Where nama=@nama OR instansi_nama=@instansi", cn))
                            {
                                cmd.Parameters.AddWithValue("nama", txtCari.Text);
                                cmd.Parameters.AddWithValue("instansi", txtCari.Text);
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
                MessageBox.Show(ex.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtNIS.Text = gridView.Cells[1].Value.ToString();
                    txtNama.Text = gridView.Cells[2].Value.ToString();
                    comboBoxKelas.SelectedItem = gridView.Cells[3].Value.ToString();
                    txtAlamat.Text = gridView.Cells[4].Value.ToString();
                    txtNoHP.Text = gridView.Cells[5].Value.ToString();
                    txtInstansi.Text = gridView.Cells[6].Value.ToString();
                    var data = (Byte[])(gridView.Cells[7].Value);
                    var stream = new MemoryStream(data);
                    pbImage.Image = Image.FromStream(stream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pilih datanya dulu di DataGrid !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File(*.jpe; *.jpeg; *.bmp; *.png; *.jpg) | *.jpe;*.jpeg;*.bmp;*.png;*.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileSize = new FileInfo(openFileDialog.FileName);
                    var validFilesize = fileSize.Length <= 1024 * 100; // 100 kilo bytes
                    var validDimensions = false;

                    // free the file once we get the dimensions
                    using (Image image = Image.FromFile(openFileDialog.FileName))
                    {
                        validDimensions = (image.Width <= 350) && (image.Height <= 350);
                    }

                    if (!validDimensions || !validFilesize)
                    {
                        MessageBox.Show("Error ! Gambar terlalu besar . . . Dimensinya maksimal 350x350 !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.pbImage.ImageLocation = openFileDialog.FileName;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Apakah Kamu yakin ingin menghapusnya ?", "PERJAKA MEA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tes.Siswas.Remove(siswaBindingSource.Current as Siswa);
                        siswaBindingSource.RemoveCurrent();
                        tes.SaveChangesAsync();
                        MessageBox.Show("Data berhasil di hapus !", "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PERJAKA MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCari_Enter(object sender, EventArgs e)
        {
            if(txtCari.Text == "Cari . . .")
            {
                txtCari.Text = "";
                txtCari.ForeColor = Color.Black;
                this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
    }
}
