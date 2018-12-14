using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace FonotekaV2
{
    public partial class Index : Form
    {
        string connStr = "Server=" + Properties.Settings.Default.AppServer + ";Database=" +
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword;
        //";port=" + Properties.Settings.Default.Dbport + 


        public Index()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Index_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlConnection conn2 = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT * FROM records ,genres , themes, sections WHERE records.Genre = genres.id AND themes.id = records.Theme and sections.id = records.Section ";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                string janr = "", tematika="", otdel="", variant;
                string sqlJ, sqlt, sqlo;
                conn2.Open();
                sqlJ = "SELECT Name FROM genres WHERE id = " + reader["Genre"].ToString();
                sqlt = "SELECT Name FROM themes WHERE id = " + reader["Theme"].ToString();
                sqlo = "SELECT Name FROM sections WHERE id = " + reader["Section"].ToString();
                MySqlCommand commandJ = new MySqlCommand(sqlJ, conn2);
                MySqlDataReader readerJ = command.ExecuteReader();
                while (readerJ.Read())
                {
                    janr = readerJ["Name"].ToString(); 
                }
                readerJ.Close();
                MySqlCommand commandt = new MySqlCommand(sqlt, conn2);
                MySqlDataReader readert = command.ExecuteReader();
                while (readert.Read())
                {
                    tematika = readert["Name"].ToString();
                }
                readert.Close();
                MySqlCommand commando = new MySqlCommand(sqlo, conn2);
                MySqlDataReader readero = command.ExecuteReader();
                while (readero.Read())
                {
                    otdel = readero["Name"].ToString();
                }
                readero.Close();
                conn2.Close();
                if (reader["RecType"].ToString() == "0")
                {
                    variant = "Моно";
                }
                else
                {
                    variant = "Стерео";
                }
                dataGridView1.Rows.Add(
                reader["id"].ToString(), 
                reader["DVDNO"].ToString(), 
                reader["CDNo"].ToString(), 
                reader["RecNo"].ToString(),
                reader["LastNo"].ToString(), 
                reader["Rubrika"].ToString(), 
                reader["Title"].ToString(), 
                reader["Composer"].ToString(),
                reader["Author"].ToString(), 
                reader["Performer"].ToString(), 
                reader["Accompaniment"].ToString(), 
                reader["IssueYear"].ToString(),
                janr, 
                reader["Phonation"].ToString(),
                tematika,
                otdel,
                variant, 
                reader["Comment"].ToString()
                    );
            }
            //dataGridView1.DataSource = table;
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
    
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                listBox4.Items.Add(row.Cells["namerecord"].Value.ToString());
                listBox5.Text = row.Cells[5].Value.ToString();
                listBox6.Text = row.Cells["comment"].Value.ToString();
                MessageBox.Show("dfdf");
            }
          MessageBox.Show(e.RowIndex.ToString());
        }
    }
}
