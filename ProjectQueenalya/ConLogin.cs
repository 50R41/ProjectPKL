using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProjectQueenalya
{
    class ConLogin
    {
        MySqlConnection conn = null;
        string strkoneksi = "Data Source=localhost;port=3306;username=root;password=;database=test_login_queena;";
        MySqlDataReader dr = null;
        MySqlCommand cmd = null;
        public DataTable BukaTable(string opokoe)
        {
            conn = new MySqlConnection(strkoneksi);
            try
            {
                conn.Open();
                cmd = new MySqlCommand(opokoe, conn);
                dr = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            conn.Close();
            return dt;
        }
    }
}
