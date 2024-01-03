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
    public partial class Stu_Activity : Form
    {
        public Stu_Activity()
        {
            InitializeComponent();
            fillgrid();
            issue();
            returnn();
        }
        SqlConnection con = new SqlConnection("server=BENINSHA_R; database=LMS1; uid=sa; pwd=User@123");
        BaseConnection conn = new BaseConnection();

        public void issue()
        {
            
            string query = "SELECT COUNT(*) FROM issue WHERE stuid='" + Program.userid + "'";
            SqlDataReader dr = conn.ret_dr(query);
            if (dr.Read())
            {
                label3.Text = dr[0].ToString();
            }

        }
        public void returnn()
        {
            string query = "SELECT COUNT(*) FROM [Return] WHERE stuid='" + Program.userid + "'";
            SqlDataReader dr = conn.ret_dr(query);
            if (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
        }

        public void fillgrid()
        {
            {
                con.Open();
                string query = "select * from issue where stuid='" + Program.userid + "'";
                string query1 = "select * from [Return] where stuid='" + Program.userid + "'";
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
                SqlDataAdapter sqlda1 = new SqlDataAdapter(query1, con);
                sqlda.Fill(ds);
                sqlda1.Fill(ds1);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                d2.DataSource = ds1.Tables[0].DefaultView;
                con.Close();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
