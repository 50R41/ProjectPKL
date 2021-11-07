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

namespace ProjectQueenalya.SiswaDashboardForm
{
    public partial class Absen : Form
    {
        //INSERT INTO Absen(kehadiran, tanggal , nama_siswa ) SELECT 'hadir' , GETDATE() , nama FROM Siswa WHERE NOT EXISTS(SELECT 1 FROM Absen WHERE tanggal = CAST(GETDATE() as DATE)) //ini untuk job di sql server agent 
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
            lblNama.Text = LoginStatus.nama;
            loadSakit();
            loadAlfa();
            loadIzin();
        }
        void loadSakit()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(kehadiran) AS 'Jumlah' FROM Absen WHERE Absen.nama_siswa = '"+ lblNama.Text +"' AND Absen.kehadiran = 'Sakit'", con))
                    {
                        con.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Read();
                        lblSakit.Text = dataReader["Jumlah"].ToString();
                        con.Close();
                    }
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
        }
        void loadIzin()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(kehadiran) AS 'Jumlah' FROM Absen WHERE Absen.nama_siswa = '" + lblNama.Text + "' AND Absen.kehadiran = 'Izin'", con))
                    {
                        con.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Read();
                        lblIzin.Text = dataReader["Jumlah"].ToString();
                        con.Close();
                    }
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
        }
        void loadAlfa()
        {
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(kehadiran) AS 'Jumlah' FROM Absen WHERE Absen.nama_siswa = '" + lblNama.Text + "' AND Absen.kehadiran = 'Alfa'", con))
                    {
                        con.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Read();
                        lblAlfa.Text = dataReader["Jumlah"].ToString();
                        con.Close();
                    }
                }
            }
            catch (Exception ead)
            {
                MessageBox.Show(ead.Message);
            }
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
                comboBoxAbsen.Text = "";
                button3.Visible = true;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PklConSTR"].ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    using (SqlCommand Cmdss = new SqlCommand("SELECT Siswa.nama FROM Siswa Where Siswa.nama='"+ lblNama.Text +"'", cn))
                    {
                        SqlDataAdapter dass = new SqlDataAdapter(Cmdss);
                        DataSet dsss = new DataSet();
                        dass.Fill(dsss);
                        int i = dsss.Tables[0].Rows.Count;
                        if (i > 0)
                        {
                            using (SqlCommand Cmd = new SqlCommand("SELECT nama_siswa, tanggal FROM Absen Where tanggal= CAST(GETDATE() as DATE) AND nama_siswa='"+ lblNama.Text +"'", cn))
                            {
                                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                int ai = ds.Tables[0].Rows.Count;
                                if (ai > 0)
                                {
                                    MessageBox.Show("Kamu sudah absen !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    using (SqlCommand cmds = new SqlCommand("INSERT INTO Absen(kehadiran, tanggal , nama_siswa ) VALUES ( @hadir, GETDATE(), @Nama)", cn))
                                    {

                                        cmds.Parameters.AddWithValue("hadir", comboBoxAbsen.Text);
                                        cmds.Parameters.AddWithValue("Nama", lblNama.Text);
                                        cmds.ExecuteNonQuery();
                                        MessageBox.Show("Berhasil melakukan absen !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nama tidak ada di database !", "PROPLACE MEA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } 
                }
            }
        }
    }
}
