using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Lib_AddBook : Form
    {
        public Lib_AddBook()
        {
            InitializeComponent();
        }
        BaseConnection con=new BaseConnection();
        private void btn_add_Click(object sender, EventArgs e)
        {
            string[] filelist = Directory.GetFiles(Application.StartupPath + "\\books");
            int i = filelist.Length;
            i = i + 1;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.Save(Application.StartupPath + "\\books\\" + i.ToString() + ".png", ImageFormat.Png);
            string filename = "\\books\\" + i.ToString() + ".png";
            string query = "insert into Book values ('" + txtId.Text + "','" + txtName.Text + "','" + txtDepartment.Text + "','" + txtAuthor.Text + "','" + txtPublication.Text + "','" + txtDetails.Text + "'," + txtQuantity.Text + "," + txtAvailable.Text + ",'" + filename + "')";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Book Added Sucessfully");
                txtId.Text = "";
                txtName.Text = "";
                txtDepartment.Text = "";
                txtAuthor.Text = "";
                txtPublication.Text = "";
                txtDetails.Text = "";
                txtQuantity.Text = "";
                txtAvailable.Text = "";
                pictureBox1.Image = null;

            }
            else
            {
                MessageBox.Show("Book Added Failed");
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lib_AddBook_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            txtAvailable.Text= txtQuantity.Text;
        }
    }
}
