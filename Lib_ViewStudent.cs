using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Lib_ViewStudent : Form
    {
        public Lib_ViewStudent()
        {
            InitializeComponent();
            filgrid();
        }
        BaseConnection con=new BaseConnection();
        public void filgrid()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }

            string query = "select * from Registration";
            DataSet ds = con.ret_ds(query);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }


        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string query = "update Registration set id='" + txtId.Text + "',name ='" + txtName.Text + "',department = '" + txtDepartment.Text + "',age =" + txtAge.Text + ", gender = '" + comboBox1.Text + "',dob = '" + dateTimePicker1.Text + "', address ='" + txtAddress.Text + "', mobile = '" + txtMoobile.Text + "',email = '" + txtEmail.Text + "',username ='" + txtUserName.Text + "',password = '" + txtPassword.Text + "' where id='" + txtId.Text + "'";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Details Updated");
                this.Close();
                filgrid();

            }
            else
            {
                MessageBox.Show("Details Not Updated");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells["Department"].FormattedValue.ToString();
                txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["DOB"].FormattedValue.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                txtMoobile.Text = dataGridView1.Rows[e.RowIndex].Cells["Mobile"].FormattedValue.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string query = "delete from registration where id ='" + txtId.Text + "'";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Detailes Deleted");
                this.Close();
                filgrid();

            }
            else
            {
                MessageBox.Show("Details not Deleted");
            }
        }
    }
}
