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
using DGVPrinterHelper;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormSiswa : Form
    {
        PKLEntities tes;
        public FormSiswa()
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

        private void FormSiswa_Load(object sender, EventArgs e)
        {
            LoadTheme();
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            btnHapus.Visible = false;
            tes = new PKLEntities();
            Auto();
            Autoinstansi();
            btnRefresh.PerformClick();
            load_table();
        }
        void load_table()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) FROM Siswa JOIN Guru on Siswa.instansi_nama = Guru.instansi_nama GROUP BY Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) ORDER BY Siswa.id", con))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        BindingSource bs = new BindingSource();
                        bs.DataSource = dt;
                        dataGridView1.DataSource = bs;
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "NIS";
                        dataGridView1.Columns[2].HeaderText = "Nama";
                        dataGridView1.Columns[3].HeaderText = "Kelas";
                        dataGridView1.Columns[4].HeaderText = "Alamat";
                        dataGridView1.Columns[5].HeaderText = "Nomor Ponsel";
                        dataGridView1.Columns[6].HeaderText = "Menempati Instansi";
                        dataGridView1.Columns[7].HeaderText = "Guru Pebimbing";
                        dataGridView1.Columns[8].HeaderText = "Foto Siswa";
                        dataGridView1.Columns[0].FillWeight = 7F;
                        dataGridView1.Columns[1].FillWeight = 12F;
                        dataGridView1.Columns[2].FillWeight = 30F;
                        dataGridView1.Columns[3].FillWeight = 12F;
                        dataGridView1.Columns[4].FillWeight = 45F;
                        dataGridView1.Columns[5].FillWeight = 28F;
                        dataGridView1.Columns[6].FillWeight = 30F;
                        dataGridView1.Columns[7].FillWeight = 30F;
                        dataGridView1.Columns[8].FillWeight = 70F;
                        sda.Update(dt);
                    }
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
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
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Tolong masukan data yang ingin di simpan !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        MessageBox.Show("Nama : " + txtNama.Text + " Sudah ada !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                                if (MessageBox.Show("Berhasil Menginput Data !", "PROPLACE MEA", MessageBoxButtons.OK) == DialogResult.OK)
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
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Lihat lagi datanya, apakah ada yang belum ke input atau enggak !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Instansi : " + txtInstansi.Text + " Belum ada !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Tolong masukan data yang ingin di edit ! atau bisa klik datanya di bawah !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    if (MessageBox.Show("Berhasil Mengupdate data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                            catch (Exception)
                            {
                                MessageBox.Show("Masukan fotonya kembali untuk mengonfirmasi editnya !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Instansi : " + txtInstansi.Text + " Belum ada !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnHapus.Visible = false;
            txtID.Undo();
        }

        private void btnEditShow_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            panel.Enabled = true;
            btnEdit.Visible = true;
            btnEditShow.Visible = false;
            btnTambah.Visible = false;
            btnHapus.Visible = true;
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
                            using (SqlCommand cmda = new SqlCommand("SELECT Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) FROM Siswa JOIN Guru on Siswa.instansi_nama = Guru.instansi_nama GROUP BY Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) ORDER BY Siswa.id", cn))
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
                        using (DataTable dt = new DataTable("Siswa"))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) FROM Siswa JOIN Guru on Siswa.instansi_nama = Guru.instansi_nama WHERE Siswa.instansi_nama=@instansi OR Siswa.nama=@nama GROUP BY Siswa.id, Siswa.nis, Siswa.nama, Siswa.kelas, Siswa.alamat, Siswa.no_hp , Siswa.instansi_nama , Guru.nama , CAST(foto_siswa AS varbinary(MAX)) ORDER BY Siswa.id", cn))
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
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var data = (Byte[])(gridView.Cells[8].Value);
                    var stream = new MemoryStream(data);
                    pbImage.Image = Image.FromStream(stream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pilih datanya dulu di DataGrid !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        validDimensions = (image.Width <= 255) && (image.Height <= 330);
                    }

                    if (!validDimensions || !validFilesize)
                    {
                        MessageBox.Show("Error ! Gambar terlalu besar . . . Dimensinya maksimal 255x330 !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //try
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (MessageBox.Show("Apakah Kamu yakin ingin menghapusnya ?", "PROPLACE MEA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            tes.Siswas.Remove(siswaBindingSource.Current as Siswa);
            //            siswaBindingSource.RemoveCurrent();
            //            tes.SaveChangesAsync();
            //            MessageBox.Show("Data berhasil di hapus !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Data Siswa";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Today);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "PROPLACE MEA";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void btnHapus_Click(object sender, EventArgs e)
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
                            using (SqlCommand cmd = new SqlCommand("DELETE Siswa WHERE nama=@nama AND nis=@nis", cn))
                            {
                                cmd.Parameters.AddWithValue("nama", txtNama.Text);
                                cmd.Parameters.AddWithValue("nis", Convert.ToInt64(txtNIS.Text));
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Berhasil menghapus data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
