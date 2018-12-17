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
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword + ";port=" + Properties.Settings.Default.Dbport;


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
            Object selectedItemj = comboBox1.SelectedItem;
            Object selectedItemt = comboBox3.SelectedItem;
            Object selectedItems = comboBox2.SelectedItem;
            string strJ = selectedItemj.ToString();
            string strT = selectedItemt.ToString();
            string strS = selectedItems.ToString();

            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT r.*, g.*, t.*, s.* FROM records as r  " +
                "JOIN genres as g ON r.Genre = g.id " +
                "JOIN themes as t ON t.id = r.Theme " +
                "JOIN sections as s ON s.id = r.Section " +
                "WHERE " +
                "r.Title LIKE '%"+textBox1.Text+"%' AND " +
                "r.Performer LIKE '%"+textBox2.Text+"%' AND " +
                "r.Composer like '%"+textBox3.Text+"%' AND " +
                "r.Author like '%"+textBox4.Text+"%' AND " +
                "g.Name like '%"+ strJ + "%' AND " +
                "s.Name LIKE '%"+ strS + "%' AND " +
                "t.Name LIKE '%"+ strT + "%' AND " +
                "r.Rubrika LIKE '%"+textBox5.Text+"%' AND " +
                "r.IssueYear LIKE '%"+textBox6.Text+"%' AND " +
                "r.CDNo LIKE '%"+textBox7.Text+"%' AND " +
                "r.RecNo LIKE '%"+textBox8.Text+"%' AND " +
                "r.LastNo LIKE '%"+textBox9.Text+"%' AND " +
                "r.Accompaniment LIKE '%"+textBox10.Text+"%'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            // читаем результат
            while (reader.Read())
            {
                string variant;
                if (reader["RecType"].ToString() == "0")
                {
                    variant = "Моно";
                }
                else
                {
                    variant = "Стерео";
                }
                dataGridView1.Rows.Add(
                reader[0].ToString(),
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
                reader[21].ToString(),
                reader["Phonation"].ToString(),
                reader[23].ToString(),
                reader[25].ToString(),
                variant,
                reader["Comment"].ToString()
                    );
            }
            //dataGridView1.DataSource = table;
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
            dataGridView1.Refresh();
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
            string sql = "SELECT r.*, g.*, t.*, s.* FROM records as r  " +
                "JOIN genres as g ON r.Genre = g.id " +
                "JOIN themes as t ON t.id = r.Theme " +
                "JOIN sections as s ON s.id = r.Section " +
                "ORDER BY r.id DESC";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                string variant = "*";
                if (reader["RecType"].ToString() == "0")
                {
                    variant = "Моно";
                }
                else if (reader["RecType"].ToString() == "1")
                {
                    variant = "Стерео";
                }
                dataGridView1.Rows.Add(
                reader[0].ToString(),
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
                reader[21].ToString(),
                reader["Phonation"].ToString(),
                reader[23].ToString(),
                reader[25].ToString(),
                variant,
                reader["Comment"].ToString()
                    );
            }
            //dataGridView1.DataSource = table;
            reader.Close(); // закрываем reader

            string sqlg = "select * from genres";
            string sqlt = "select * from themes";
            string sqls = "select * from sections";

            MySqlCommand commandg = new MySqlCommand(sqlg, conn);
            MySqlDataReader readerg = commandg.ExecuteReader();
            comboBox1.Items.Add("");
            while (readerg.Read())
            {
                comboBox1.Items.Add(readerg["Name"].ToString());
            }
            readerg.Close();

            MySqlCommand commandt = new MySqlCommand(sqlt, conn);
            MySqlDataReader readert = commandt.ExecuteReader();
            comboBox3.Items.Add("");
            while (readert.Read())
            {
                comboBox3.Items.Add(readert["Name"].ToString());
            }
            readert.Close();

            MySqlCommand commandS = new MySqlCommand(sqls, conn);
            MySqlDataReader readers = commandS.ExecuteReader();
            comboBox2.Items.Add("");
            while (readers.Read())
            {
                comboBox2.Items.Add(readers["Name"].ToString());
            }
            readers.Close();
            // закрываем соединение с БД
            conn.Close();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Fonoform add = new Fonoform();
            add.ShowDialog();
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
