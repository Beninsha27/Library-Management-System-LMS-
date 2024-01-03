using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Lib_Home : Form
    {
        public Lib_Home()
        {
            InitializeComponent();
        }

        private void lbl_Addbook_Click(object sender, EventArgs e)
        {
            
            Lib_AddBook obj= new Lib_AddBook();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Viewbooks_Click(object sender, EventArgs e)
        {
           
            Lib_ViewBooks obj= new Lib_ViewBooks();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Viewstudent_Click(object sender, EventArgs e)
        {
            
            Lib_ViewStudent obj = new Lib_ViewStudent();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_Searchbook_Click(object sender, EventArgs e)
        {
           
            Lib_SearchBook obj = new Lib_SearchBook();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Searchstudent_Click(object sender, EventArgs e)
        {
            
            Lib_SearchStudent obj = new Lib_SearchStudent();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Issuebook_Click(object sender, EventArgs e)
        {
            
            Lib_IssueBook obj = new Lib_IssueBook();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Returnbook_Click(object sender, EventArgs e)
        {
            
            Lib_ReturnBook obj = new Lib_ReturnBook();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Viewreport_Click(object sender, EventArgs e)
        {
            
            Lib_ViewReport obj = new Lib_ViewReport();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void lbl_Panalty_Click(object sender, EventArgs e)
        {
            
            Lib_Penalty obj = new Lib_Penalty();
            obj.TopLevel = false;
            panel_Librarian.Controls.Add(obj);
            obj.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Librarian_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
