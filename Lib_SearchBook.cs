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
    public partial class Lib_SearchBook : Form
    {
        public Lib_SearchBook()
        {
            InitializeComponent();
            fillcombo();
        }
        SqlConnection con = new SqlConnection("server=BENINSHA_R; database=LMS1; uid=sa; pwd=User@123");
        public void fillcombo()
        {
            con.Open();
            comboBox1.Items.Clear();
            string str = "select distinct[department] from book";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader sd = cmd.ExecuteReader();
            while (sd.Read())
            {
                comboBox1.Items.Add(sd[0].ToString());
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                lblid.Text = dataGridView1.Rows[e.RowIndex].Cells["BookId"].FormattedValue.ToString();
                lblname.Text = dataGridView1.Rows[e.RowIndex].Cells["BookName"].FormattedValue.ToString();
                lbldept.Text = dataGridView1.Rows[e.RowIndex].Cells["Department"].FormattedValue.ToString();
                lblauther.Text = dataGridView1.Rows[e.RowIndex].Cells["Auther"].FormattedValue.ToString();
                lblpublication.Text = dataGridView1.Rows[e.RowIndex].Cells["publication"].FormattedValue.ToString();
                lbldetails.Text = dataGridView1.Rows[e.RowIndex].Cells["Detail"].FormattedValue.ToString();
                lblquantity.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString();
                lblAvailable.Text = dataGridView1.Rows[e.RowIndex].Cells["AvailableQty"].FormattedValue.ToString();
                pictureBox1.ImageLocation = Application.StartupPath + dataGridView1.Rows[e.RowIndex].Cells["Image"].FormattedValue.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select * from book where department='" + comboBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lib_SearchBook_Load(object sender, EventArgs e)
        {

        }
    }
    
}
