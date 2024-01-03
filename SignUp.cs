using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LMS
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        BaseConnection con=new BaseConnection();
        private void btn_register_Click(object sender, EventArgs e)
        {
            string query = "insert into Registration values ('" + txtId.Text + "','" + txtName.Text + "','" + txtDepartment.Text + "'," + txtAge.Text + ",'" + cbGender.Text + "','" + dateTimePicker1.Text + "','" + txtAddress.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Registration Successfull");
                txtId.Text = "";
                txtName.Text = "";
                txtDepartment.Text = "";
                txtAge.Text = "";
                cbGender.Text = "";
                dateTimePicker1.Text = "";
                txtAddress.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Registration Failed");
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDepartment.Text = "";
            txtAge.Text = "";
            cbGender.Text = "";
            dateTimePicker1.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}
