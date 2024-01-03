using LMS;
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
    public partial class Home_Page : Form
    {
        private const int WS_EX_COMPOSITED = 0x02000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }
        public Home_Page()
        {
            InitializeComponent();
        }

        private void lblsignup_Click(object sender, EventArgs e)
        {
            SignUp obj = new SignUp();
            obj.Show();
        }

        private void lbllogin_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }

        private void labelShutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }   
    
}
