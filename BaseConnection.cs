using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class BaseConnection
    {
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public SqlConnection con()
        {
            SqlConnection con = new SqlConnection("server=BENINSHA_R; database=LMS1; uid=sa; pwd=User@123");
            con.Open();
            return con;
        }
        public void exec(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            cmd.ExecuteNonQuery();
        }
        public int exec1(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            return cmd.ExecuteNonQuery();
        }
        public SqlDataReader ret_dr(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            return cmd.ExecuteReader();
        }
        public DataSet ret_ds(string str)
        {

            SqlDataAdapter sqlda = new SqlDataAdapter(str, con());
            sqlda.Fill(ds);
            return ds;
        }
    }
}
