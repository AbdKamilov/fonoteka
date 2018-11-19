using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FonotekaV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set to no text.  
            txtPassword.Text = "";
            // The password character is an asterisk.  
            txtPassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.  
            txtPassword.MaxLength = 14;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtLogin.Text == "nurik" && this.txtPassword.Text == "123")
            {
                Form ob = new Index();
                this.Hide();
                ob.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
