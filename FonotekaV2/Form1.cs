using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FonotekaV2
{
    public partial class Form1 : Form
    {
        string connStr = "Server=" + Properties.Settings.Default.AppServer + ";Database=" +
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword + ";port=" + Properties.Settings.Default.Dbport + ";CharSet=utf8";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            if (("ФоноКыр" == txtLogin.Text && "2019К" == txtPassword.Text) || ("ФоноРус" == txtLogin.Text && "2019Р" == txtPassword.Text))
            {
                Index ob = new Index();
                this.Hide();
                ob.Show();
            }
            else if ("ФоноПоиск" == txtLogin.Text && "2019Поиск" == txtPassword.Text)
            {
                Index ob = new Index();
                this.Hide();
                ob.StatusUser();
                ob.Show();
            }
            else
                MessageBox.Show("Вы ввели неправильно логин или пароль!");
            //Form ob = new Index();
            //this.Hide();
            //ob.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string pass;
            pass = Interaction.InputBox("Секртеный код Администратора :");
            if(pass == "717494")
            {
                Settings st = new Settings();
                st.ShowDialog();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для восстановление пароля обратитесь к вашему программисту!","Восстановление пароля.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
