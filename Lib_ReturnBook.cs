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
    public partial class Lib_ReturnBook : Form
    {
        public Lib_ReturnBook()
        {
            InitializeComponent();
            fillcombo_Id();
            filldates();
        }
        BaseConnection conn= new BaseConnection();

        public void filldates()
        {
            txt_return.Text = System.DateTime.Now.ToShortDateString();
            DateTime dt = Convert.ToDateTime(txt_return.Text);

        }

        void fillcombo_Id()
        {
            comboBox1.Items.Clear();
            string str = "select distinct[stuid] from issue";
            SqlDataReader sd = conn.ret_dr(str);
            while (sd.Read())
            {
                comboBox1.Items.Add(sd[0].ToString());
            }
        }

        void fillcombo_Name()
        {
            comboBox2.Items.Clear();
            string str = "select distinct[bookname] from issue where stuid='"+comboBox1.Text+"'";
            SqlDataReader sd = conn.ret_dr(str);
            while (sd.Read())
            {
                comboBox2.Items.Add(sd[0].ToString());
            }
        }

        private void Lib_ReturnBook_Load(object sender, EventArgs e)
        {

        }

        public void filldata()
        {
            string q = "select * from issue where stuid='" + comboBox1.Text + "' and bookname='"+comboBox2.Text+"'";
            SqlDataReader sd = conn.ret_dr(q);
            if (sd.Read())
            {
                lbl_Name.Text = sd[2].ToString();
                lbl_Department.Text = sd[3].ToString();
                lbl_returnid.Text = sd[1].ToString();
                lbl_dueDate.Text = sd[9].ToString();
            }
        }

        

        private void btn_Search_Click(object sender, EventArgs e)
        {
            filldata();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcombo_Name();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dueDate = Convert.ToDateTime(lbl_dueDate.Text);
            DateTime returnDate = Convert.ToDateTime(System.DateTime.Now);

            TimeSpan timeDifference = returnDate - dueDate;
            int daysLate = Math.Max(0, timeDifference.Days); 

            int penaltyRate = 10;
            int penaltyAmount = daysLate * penaltyRate;

            if (returnDate > dueDate)
            {
                txt_penalty.Text = "YES";
            }
            else
            {
                txt_penalty.Text = "NO";
            }
            txt_Amount.Text = penaltyAmount.ToString();
            txt_LateDay.Text = daysLate.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txt_penalty.Text == "NO")
            {
                int availableqty = 0;
                string st = "select * from book where bookname='" + comboBox2.Text + "'";
                SqlDataReader sd = conn.ret_dr(st);
                while (sd.Read())
                {
                    availableqty = Convert.ToInt32(sd["availableqty"].ToString());
                }
                if (availableqty >= 0)
                {
                    string str = "update book set availableqty=availableqty+1 where bookname='" + comboBox2.Text + "'";
                    conn.exec1(str);

                    string query = "insert into [Return] values ('" + comboBox1.Text + "','" + lbl_returnid.Text + "','" + comboBox2.Text + "','" + lbl_Name.Text + "','" + lbl_Department.Text + "','" + lbl_dueDate.Text + "','" + txt_return.Text + "','" + txt_penalty.Text + "'," + txt_LateDay.Text + "," + txt_Amount.Text + ")";
                    if (conn.exec1(query) > 0)
                    {
                        MessageBox.Show("Book Returned Successfully");
                        string st1 = "delete from issue where issueid='" + lbl_returnid.Text + "'";
                        conn.exec1(st1);
                        this.Close();
                    }
                    
                }
                
            }

            else
            {
                MessageBox.Show("Please pay Penalty, and Return Book");
            }
        }

        private void btn_payretutn_Click(object sender, EventArgs e)
        {
            if (txt_penalty.Text == "YES")
            {
                int availableqty = 0;
                string st = "select * from book where bookname='" + comboBox2.Text + "'";
                SqlDataReader sd = conn.ret_dr(st);
                while (sd.Read())
                {
                    availableqty = Convert.ToInt32(sd["availableqty"].ToString());
                }
                if (availableqty >= 0)
                {
                    string str = "update book set availableqty=availableqty+1 where bookname='" + comboBox2.Text + "'";
                    conn.exec1(str);

                    string query = "insert into [Return] values ('" + comboBox1.Text + "','" + lbl_returnid.Text + "','" + comboBox2.Text + "','" + lbl_Name.Text + "','" + lbl_Department.Text + "','" + lbl_dueDate.Text + "','" + txt_return.Text + "','" + txt_penalty.Text + "'," + txt_LateDay.Text + "," + txt_Amount.Text + ")";
                    if (conn.exec1(query) > 0)
                    {
                        MessageBox.Show("Book Returned Successfully");
                        string st2 = "delete from issue where issueid='" + lbl_returnid.Text + "'";
                        conn.exec1(st2);
                        this.Close();
                    }
                }
                

            }

            else
            {
                MessageBox.Show("You have no Panalty");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            fillcombo_Name();
        }
    }
}
