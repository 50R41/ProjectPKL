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
    public partial class FormPebimbing : Form
    {
        PKLEntities saada;
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

        private void FormPebimbing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Guru' table. You can move, or remove it, as needed.
            this.guruTableAdapter.Fill(this.pKLDataSet.Guru);
            LoadTheme();
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            saada = new PKLEntities();
            guruBindingSource.DataSource = saada.Gurus.ToList();
            Auto();
            Autoinstansi();
            btnRefresh.PerformClick();
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
        private void Auto()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama, instansi_nama FROM Guru", con);
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
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            btnTambah.Visible = true;
            btnEditShow.Visible = true;
            guruBindingSource.ResetBindings(false);
            try
            {
                foreach (DbEntityEntry entry in saada.ChangeTracker.Entries())
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
                    using (SqlCommand Cmd = new SqlCommand("SELECT nama FROM Instansi Where nama= '" + txtInstansi.Text + "'", cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;
                        if (i > 0)
                        {
                            using (SqlCommand Cmda = new SqlCommand("SELECT nama FROM Guru Where nama= '" + txtNama.Text + "'", cn))
                            {
                                SqlDataAdapter dad = new SqlDataAdapter(Cmda);
                                DataSet dsd = new DataSet();
                                dad.Fill(dsd);
                                int ia = dsd.Tables[0].Rows.Count;
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
                                            Guru s = new Guru();
                                            s.nip = Convert.ToInt64(txtNIP.Text);
                                            s.nama = txtNama.Text;
                                            s.alamat = txtAlamat.Text;
                                            s.no_hp = Convert.ToInt64(txtNoHp.Text);
                                            s.instansi_nama = txtInstansi.Text;
                                            s.foto_guru = ConvertFoto(this.pbImage.ImageLocation);
                                            saada.Gurus.Add(s);
                                            saada.SaveChanges();
                                            if (MessageBox.Show("Berhasil Menginput Data !", "PROPLACE MEA", MessageBoxButtons.OK) == DialogResult.OK)
                                            {
                                                txtID.Text = "";
                                                txtInstansi.Text = "";
                                                txtNoHp.Text = "";
                                                txtNama.Text = "";
                                                txtAlamat.Text = "";
                                                txtNIP.Text = "";
                                                pbImage.ImageLocation = null;
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

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtAlamat.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Tolong masukan data yang ingin di edit ! atau bisa click datanya di bawah !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (Sd > 0)
                        {
                            try
                            {
                                if (cn.State == ConnectionState.Closed)
                                {
                                    cn.Open();
                                    using (DataTable dt = new DataTable("Guru"))
                                    {
                                        using (SqlCommand cmds = new SqlCommand("UPDATE Guru SET nip=@nip, nama=@Nama , alamat=@Alamat , no_hp=@no, instansi_nama=@instansi , foto_guru=@foto WHERE id=@ID", cn))
                                        {

                                            cmds.Parameters.AddWithValue("ID", txtID.Text);
                                            cmds.Parameters.AddWithValue("nip", txtNIP.Text);
                                            cmds.Parameters.AddWithValue("Nama", txtNama.Text);
                                            cmds.Parameters.AddWithValue("Alamat", txtAlamat.Text);
                                            cmds.Parameters.AddWithValue("no", txtNoHp.Text);
                                            cmds.Parameters.AddWithValue("instansi", txtInstansi.Text);
                                            cmds.Parameters.AddWithValue("foto", ConvertFoto(this.pbImage.ImageLocation));
                                            cmds.ExecuteNonQuery();
                                            if (MessageBox.Show("Berhasil Mengupdate data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                            {
                                                txtID.Text = "";
                                                txtInstansi.Text = "";
                                                txtNoHp.Text = "";
                                                txtNama.Text = "";
                                                txtAlamat.Text = "";
                                                txtNIP.Text = "";
                                                pbImage.Image = null;
                                                btnCancel.Visible = false;
                                                btnSimpan.Visible = false;
                                                btnEdit.Visible = false;
                                                btnEditShow.Visible = true;
                                                btnTambah.Visible = true;
                                                btnRefresh.PerformClick();
                                            }
                                        }
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                txtNIP.Text = "";
                txtNama.Text = "";
                txtAlamat.Text = "";
                txtInstansi.Text = "";
                txtNoHp.Text = "";
                btnSimpan.Visible = true;
                btnCancel.Visible = true;
                panel.Enabled = true;
                pbImage.Image = null;
                btnEditShow.Visible = false;
                txtNIP.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        using (DataTable dt = new DataTable("Guru"))
                        {
                            using (SqlCommand cmda = new SqlCommand("SELECT * FROM Guru ORDER BY id ASC", cn))
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
            if (txtCari.Text == "Cari . . .")
            {
                MessageBox.Show("Masukan nama yang ingin di cari !" , "PROPLACE MEA" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                            using (DataTable dt = new DataTable("Guru"))
                            {
                                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Guru Where nama=@nama", cn))
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow gridView = dataGridView1.Rows[e.RowIndex];
                    txtID.Text = gridView.Cells[0].Value.ToString();
                    txtNIP.Text = gridView.Cells[1].Value.ToString();
                    txtNama.Text = gridView.Cells[2].Value.ToString();
                    txtNoHp.Text = gridView.Cells[4].Value.ToString();
                    txtAlamat.Text = gridView.Cells[3].Value.ToString();
                    txtInstansi.Text = gridView.Cells[5].Value.ToString();
                    var data = (Byte[])(gridView.Cells[6].Value);
                    var stream = new MemoryStream(data);
                    pbImage.Image = Image.FromStream(stream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pilih datanya dulu di DataGrid !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        saada.Siswas.Remove(guruBindingSource.Current as Siswa);
                        guruBindingSource.RemoveCurrent();
                        saada.SaveChangesAsync();
                        MessageBox.Show("Data berhasil di hapus !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
