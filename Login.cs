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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        BaseConnection con= new BaseConnection();

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Librarian")
            {
                if (txtUserName.Text == "admin" && txtPassword.Text == "pwd")
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    comboBox1.Text = "";
                    Lib_Home obj = new Lib_Home();
                    ActiveForm.Hide();
                    obj.Show();


                }
                else
                {
                    MessageBox.Show("UserName or Password Incorrect");
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    comboBox1.Text = "";
                }
            }

            else if (comboBox1.Text == "Student")
            {
                String query = "select * from Registration where UserName = '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'";
                SqlDataReader sd = con.ret_dr(query);
                if (sd.Read())
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    comboBox1.Text = "";
                    Program.userid = sd[0].ToString();
                    Program.name = sd[1].ToString();
                    Student_Home obj = new Student_Home();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("UserName or Password Incorrect");
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    comboBox1.Text = "";
                }

            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            comboBox1.Text = "";
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
