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
using System.IO;

namespace ProjectQueenalya.AdminDashboardForm
{
    public partial class FormInstansi : Form
    {
        PKLEntities test;
        public FormInstansi()
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
        private void FormInstansi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pKLDataSet.Instansi' table. You can move, or remove it, as needed.
            this.instansiTableAdapter.Fill(this.pKLDataSet.Instansi);
            LoadTheme();
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            test = new PKLEntities();
            instansiBindingSource.DataSource = test.Instansis.ToList();
            Auto();
            btnRefresh.PerformClick();
        }
        private void Auto()
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            panel.Enabled = false;
            btnSimpan.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = false;
            btnTambah.Visible = true;
            btnEditShow.Visible = true;
            instansiBindingSource.ResetBindings(false);
            txtID.Undo();
            try
            {
                foreach (DbEntityEntry entry in test.ChangeTracker.Entries())
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                btnTambah.Visible = false;
                btnEdit.Visible = false;
                txtID.Visible = false;
                txtNama.Clear();
                txtAlamat.Clear();
                btnSimpan.Visible = true;
                btnCancel.Visible = true;
                panel.Enabled = true;
                btnEditShow.Visible = false;
                label1.Visible = false;
                txtNama.Focus();
            }
            catch (Exception)
            {
                throw;
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
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    using (SqlCommand Cmd = new SqlCommand("SELECT nama FROM Instansi Where nama= '" + txtNama.Text + "'", cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;
                        if (i > 0)
                        {
                            MessageBox.Show("Nama : " + txtNama.Text + " Sudah ada !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            try
                            {
                                if (MessageBox.Show("Apakah kamu yakin dan sudah di pastikan semua datanya benar ?", "Tabungan Siwa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Instansi s = new Instansi();
                                    s.nama = txtNama.Text;
                                    s.alamat = txtAlamat.Text;
                                    s.foto_instansi = ConvertFoto(this.pbImage.ImageLocation);
                                    test.Instansis.Add(s);
                                    test.SaveChanges();
                                    if (MessageBox.Show("Berhasil Menginput Data !", "PROPLACE MEA", MessageBoxButtons.OK) == DialogResult.OK)
                                    {
                                        txtID.Text = "";
                                        txtNama.Text = "";
                                        txtAlamat.Text = "";
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
                                MessageBox.Show("Periksa lagi data yang ingin disimpan !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                    try
                    {
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                            using (DataTable dt = new DataTable("Instansi"))
                            {
                                using (SqlCommand cmds = new SqlCommand("UPDATE Instansi SET nama=@Nama , alamat=@Alamat , foto_instansi=@foto WHERE id=@ID", cn))
                                {

                                    cmds.Parameters.AddWithValue("ID", txtID.Text);
                                    cmds.Parameters.AddWithValue("Nama", txtNama.Text);
                                    cmds.Parameters.AddWithValue("Alamat", txtAlamat.Text);
                                    cmds.Parameters.AddWithValue("foto" , ConvertFoto(this.pbImage.ImageLocation));
                                    cmds.ExecuteNonQuery();
                                    if (MessageBox.Show("Berhasil Mengupdate data !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                    {
                                        txtID.Text = "";
                                        txtNama.Text = "";
                                        txtAlamat.Text = "";
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    txtNama.Text = gridView.Cells[1].Value.ToString();
                    txtAlamat.Text = gridView.Cells[2].Value.ToString();
                    var data = (Byte[])(gridView.Cells[3].Value);
                    var stream = new MemoryStream(data);
                    pbImage.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        test.Instansis.Remove(instansiBindingSource.Current as Instansi);
                        instansiBindingSource.RemoveCurrent();
                        test.SaveChangesAsync();
                        MessageBox.Show("Data berhasil di hapus !" , "PROPLACE MEA" , MessageBoxButtons.OK , MessageBoxIcon.Information);
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
                        using (DataTable dt = new DataTable("Instansi"))
                        {
                            using (SqlCommand cmda = new SqlCommand("SELECT * FROM Instansi ORDER BY id ASC", cn))
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
                        using (DataTable dt = new DataTable("Instansi"))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Instansi Where nama=@nama", cn))
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
                        MessageBox.Show("Error ! Gambar terlalu besar . . . Dimensinya maksimal 255x330 !" , "PROPLACE MEA" , MessageBoxButtons.OK , MessageBoxIcon.Error);
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
