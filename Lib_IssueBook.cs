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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LMS
{
    public partial class Lib_IssueBook : Form
    {
        BaseConnection con=new BaseConnection();
        public Lib_IssueBook()
        {
            InitializeComponent();
            fillcombo_Book();
            fillcombo_Id();
            filldates();
        }

        public void filldata()
        {
            string q = "select * from registration where id='" + comboBox1.Text + "'";

            SqlDataReader sd = con.ret_dr(q);

            if (sd.Read())
            {
                lbl_Name.Text = sd[1].ToString();
                lbl_Department.Text = sd[2].ToString();
                lbl_Mobile.Text = sd[7].ToString();
                lbl_Email.Text = sd[8].ToString();

            }
        }

        public void filldates()
        {
            txt_issuedate.Text = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(txt_issuedate.Text);
            DateTime dt2 = dt.AddDays(7);
            txt_duedate.Text = dt2.ToShortDateString();
        }

        void fillcombo_Id()
        {
            comboBox1.Items.Clear();
            string str = "select distinct[id] from registration";
            SqlDataReader sd = con.ret_dr(str);
            while (sd.Read())
            {
                comboBox1.Items.Add(sd[0].ToString());
            }
        }
        public void fillcombo_Book()
        {
            cb_BookName.Items.Clear();
            string str = "select distinct[bookname] from book";
            SqlDataReader sd = con.ret_dr(str);
            while (sd.Read())
            {
                cb_BookName.Items.Add(sd[0].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filldata();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            int availableqty = 0;
            string st = "select * from book where bookname='" + cb_BookName.Text + "'";
            SqlDataReader sd = con.ret_dr(st);
            while (sd.Read())
            {
                availableqty = Convert.ToInt32(sd["availableqty"].ToString());
            }
            if (availableqty > 0)
            {
                string str = "update book set availableqty=availableqty-1 where bookname='" + cb_BookName.Text + "'";
                con.exec1(str);

                string query = "insert into issue values ('" + comboBox1.Text + "','" + txt_IssueID.Text + "','" + lbl_Name.Text + "','" + lbl_Department.Text + "','" + lbl_Mobile.Text + "','" + lbl_Email.Text + "','" + cb_BookName.Text + "'," + lbl_Quantity.Text + ",'" + txt_issuedate.Text + "','" + txt_duedate.Text + "')";
                if (con.exec1(query) > 0)
                {
                    MessageBox.Show("Book Issued Successfully");
                    
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Book Not Available");
                this.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q = "select * from book where bookname='" + cb_BookName.Text + "'";

            SqlDataReader sd = con.ret_dr(q);

            if (sd.Read())
            {
                lbl_Quantity.Text = sd[7].ToString();
            }
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            filldata();
        }
    }
}
