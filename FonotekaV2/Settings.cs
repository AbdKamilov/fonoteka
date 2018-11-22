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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string DefaultServer = Properties.Settings.Default.AppServer;
            string DefaultServerDB = Properties.Settings.Default.AppDB;
            string DefaultUsername = Properties.Settings.Default.DBuser;
            string DefaultPassword = Properties.Settings.Default.DBpassword;
            string DefaultPort = Properties.Settings.Default.Dbport;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            string DefaultServer = Properties.Settings.Default.AppServer;
            string DefaultServerDB = Properties.Settings.Default.AppDB;
            string DefaultUsername = Properties.Settings.Default.DBuser;
            string DefaultPassword = Properties.Settings.Default.DBpassword;
            string DefaultPort = Properties.Settings.Default.Dbport;

            //PostTracker.Properties.Settings.Default.Save(); // Important for saving
        }
    }
}
