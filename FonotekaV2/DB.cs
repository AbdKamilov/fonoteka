using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonotekaV2
{
    class DB
    {
        string Db_name;
        string Db_user;
        string Db_password;
        string Db_server;
        string Db_port;

        public DB() {
                Db_server = Properties.Settings.Default.AppServer;
                Db_name = Properties.Settings.Default.AppDB;
                Db_user = Properties.Settings.Default.DBuser;
                Db_password = Properties.Settings.Default.DBpassword;
                Db_port = Properties.Settings.Default.Dbport;
            }
    }
}
