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
    public partial class Student_Home : Form
    {
        public Student_Home()
        {
            InitializeComponent();
            label12.Text = Program.name;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Stu_Personal obj = new Stu_Personal();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Stu_EditAccount obj = new Stu_EditAccount();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Stu_Activity obj = new Stu_Activity();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Lib_SearchBook obj = new Lib_SearchBook();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Stu_PenaltyReport obj = new Stu_PenaltyReport();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
