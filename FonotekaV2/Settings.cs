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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            lblserver.Text = Properties.Settings.Default.AppServer;
            lbldb.Text = Properties.Settings.Default.AppDB;
            lbluser.Text = Properties.Settings.Default.DBuser;
            lblpass.Text = Properties.Settings.Default.DBpassword;
            lblport.Text = Properties.Settings.Default.Dbport;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            string tex;
            tex = Interaction.InputBox("Сервер :");
            if (tex !=null || tex !="")
            {
                MessageBox.Show(tex);
                Properties.Settings.Default.AppServer = tex;
                Properties.Settings.Default.Save();
                lblserver.Text = Properties.Settings.Default.AppServer;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            string tex;
            tex = Interaction.InputBox("База данных :");
            if (tex != null)
            {
                Properties.Settings.Default.AppDB = tex;
                Properties.Settings.Default.Save();
                lbldb.Text = Properties.Settings.Default.AppDB;
            }

        }

        private void label14_Click(object sender, EventArgs e)
        {
            string tex;
            tex = Interaction.InputBox("Пользователь база данных :");
            if (tex != null)
            {
                Properties.Settings.Default.DBuser = tex;
                Properties.Settings.Default.Save();
                lbluser.Text = Properties.Settings.Default.DBuser;
            }    
        }

        private void label15_Click(object sender, EventArgs e)
        {
            string tex;
            tex = Interaction.InputBox("Пароль база данных :");
            if (tex != null)
            {
                Properties.Settings.Default.DBpassword = tex;
                Properties.Settings.Default.Save();
                lblpass.Text = Properties.Settings.Default.DBpassword;
            }
           
        }

        private void label16_Click(object sender, EventArgs e)
        {
            string tex;
            tex = Interaction.InputBox("Порт база данных :");
            if (tex != null)
            {
                Properties.Settings.Default.Dbport = tex;
                Properties.Settings.Default.Save();
                lblport.Text = Properties.Settings.Default.Dbport;
            }
           
        }
    }
}
