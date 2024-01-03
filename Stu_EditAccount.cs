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
    public partial class Stu_EditAccount : Form
    {
        public Stu_EditAccount()
        {
            InitializeComponent();
            filldata();
        }
        BaseConnection con=new BaseConnection();
        public void filldata()
        {
            string str = "select * from registration where id='" + Program.userid + "'";

            SqlDataReader sd = con.ret_dr(str);

            if (sd.Read())
            {
                txtId.Text = sd[0].ToString();
                txtName.Text = sd[1].ToString();
                txtDepartment.Text = sd[2].ToString();
                txtAge.Text = sd[3].ToString();
                comboBox1.Text = sd[4].ToString();
                dateTimePicker1.Text = sd[5].ToString();
                txtAddress.Text = sd[6].ToString();
                txtMoobile.Text = sd[7].ToString();
                txtEmail.Text = sd[8].ToString();
                txtUserName.Text = sd[9].ToString();
                txtPassword.Text = sd[10].ToString();
            }
        }

        private void Stu_EditAccount_Load(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string query = "update Registration set id='" + txtId.Text + "',name ='" + txtName.Text + "',department = '" + txtDepartment.Text + "',age =" + txtAge.Text + ", gender = '" + comboBox1.Text + "',dob = '" + dateTimePicker1.Text + "', address ='" + txtAddress.Text + "', mobile = '" + txtMoobile.Text + "',email = '" + txtEmail.Text + "',username ='" + txtUserName.Text + "',password = '" + txtPassword.Text + "' where id='" + txtId.Text + "'";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Details Updated");

            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
