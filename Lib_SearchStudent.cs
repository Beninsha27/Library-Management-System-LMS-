using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Lib_SearchStudent : Form
    {
        public Lib_SearchStudent()
        {
            InitializeComponent();
            fillcombo();
        }
        SqlConnection con = new SqlConnection("server=BENINSHA_R; database=LMS1; uid=sa; pwd=User@123");
        public void fillcombo()
        {
            con.Open();
            comboBox1.Items.Clear();
            string str = "select distinct[Department] from registration";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader sd = cmd.ExecuteReader();
            while (sd.Read())
            {
                comboBox1.Items.Add(sd[0].ToString());
            }
            con.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label16.Text = "";
            {
                dataGridView1.CurrentRow.Selected = true;
                label12.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                lbl_Name.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                lbl_Department.Text = dataGridView1.Rows[e.RowIndex].Cells["Department"].FormattedValue.ToString();
                lbl_Age.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].FormattedValue.ToString();
                lbl_Gender.Text = dataGridView1.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString();
                lbl_dob.Text = dataGridView1.Rows[e.RowIndex].Cells["DOB"].FormattedValue.ToString();
                lbl_Address.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                lbl_Mobile.Text = dataGridView1.Rows[e.RowIndex].Cells["Mobile"].FormattedValue.ToString();
                lbl_Email.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                lbl_UserName.Text = dataGridView1.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                lbl_Password.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string str = "select * from registration where Department ='" + comboBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void label12_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT COUNT(*) FROM issue WHERE stuid='" + label12.Text + "'";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                int recordCount = (int)command.ExecuteScalar(); 
                label16.Text += recordCount.ToString(); 

            }
            con.Close() ;
        }
    }
}
