using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Lib_ViewReport : Form
    {
        public Lib_ViewReport()
        {
            InitializeComponent();
            issue();
            retur();
        }
        SqlConnection con = new SqlConnection("server=BENINSHA_R; database=LMS1; uid=sa; pwd=User@123");
        BaseConnection conn = new BaseConnection();

        public void issue()
        {

            string query = "SELECT COUNT(*) FROM issue";
            SqlDataReader dr = conn.ret_dr(query);
            if (dr.Read())
            {
                label3.Text = dr[0].ToString();
            }

        }

        public void retur()
        {

            string query = "SELECT COUNT(*) FROM [Return]";
            SqlDataReader dr = conn.ret_dr(query);
            if (dr.Read())
            {
                label2.Text = dr[0].ToString();
            }

        }

        private void Lib_ViewReport_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from issue";
            string query1 = "select * from [Return]";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            SqlDataAdapter sqlda1 = new SqlDataAdapter(query1, con);
            sqlda.Fill(ds);
            sqlda1.Fill(ds1);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView2.DataSource = ds1.Tables[0].DefaultView;
            con.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
