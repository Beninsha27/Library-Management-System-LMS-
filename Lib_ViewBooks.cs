using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LMS
{
    public partial class Lib_ViewBooks : Form
    {
        public Lib_ViewBooks()
        {
            InitializeComponent();
            filgrid();
        }
        BaseConnection con=new BaseConnection();

        public void filgrid()
        {
            string query = "select * from book";
            DataSet ds = con.ret_ds(query);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string query = "update book set BookId='" + txtID.Text + "',BookName ='" + txtName.Text + "',Department = '" + txtDepartment.Text + "', Auther = '" + txtAuthor.Text + "', publication = '" + txtPublication.Text + "',Detail = '" + txtDetails.Text + "', Quantity =" + txtQuantity.Text + ", AvailableQty =" + textBox1.Text + " where BookId='" + txtID.Text + "'";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Book Updated successfully");
                filgrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Book Not Updated ");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["BookId"].FormattedValue.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["BookName"].FormattedValue.ToString();
                txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells["Department"].FormattedValue.ToString();
                txtAuthor.Text = dataGridView1.Rows[e.RowIndex].Cells["Auther"].FormattedValue.ToString();
                txtPublication.Text = dataGridView1.Rows[e.RowIndex].Cells["publication"].FormattedValue.ToString();
                txtDetails.Text = dataGridView1.Rows[e.RowIndex].Cells["Detail"].FormattedValue.ToString();
                txtQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["AvailableQty"].FormattedValue.ToString();
                pictureBox1.ImageLocation = Application.StartupPath + dataGridView1.Rows[e.RowIndex].Cells["Image"].FormattedValue.ToString();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query = "delete from book where BookId ='" + txtID.Text + "'";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Book Deleted Successfully");
                filgrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Book Not Deleted");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
