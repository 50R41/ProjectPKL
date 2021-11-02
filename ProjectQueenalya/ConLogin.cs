 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProjectQueenalya
{
    class ConLogin
    {
        SqlConnection conn = null;
        string strkoneksi = "Data Source=localhost;Initial Catalog=PKL;Integrated Security=True;";
        SqlDataReader dr = null;
        SqlCommand cmd = null;
        public DataTable BukaTable(string opokoe)
        {
            conn = new SqlConnection(strkoneksi);
            try
            {
                conn.Open();
                cmd = new SqlCommand(opokoe, conn);
                dr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
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
