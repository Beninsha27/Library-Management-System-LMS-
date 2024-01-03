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
    public partial class Stu_Personal : Form
    {
        public Stu_Personal()
        {
            InitializeComponent();
            filldata();
        }
        BaseConnection con= new BaseConnection();
        public void filldata()
        {
            string str = "select * from registration where id='" + Program.userid + "'";

            SqlDataReader sd = con.ret_dr(str);

            if (sd.Read())
            {
                lbl_Name.Text = sd[1].ToString();
                lbl_Department.Text = sd[2].ToString();
                lbl_Age.Text = sd[3].ToString();
                lbl_Gender.Text = sd[4].ToString();
                lbl_dob.Text = sd[5].ToString();
                lbl_Address.Text = sd[6].ToString();
                lbl_Mobile.Text = sd[7].ToString();
                lbl_Email.Text = sd[8].ToString();
                lbl_UserName.Text = sd[9].ToString();
                lbl_Password.Text = sd[10].ToString();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stu_Personal_Load(object sender, EventArgs e)
        {

        }
    }
}
