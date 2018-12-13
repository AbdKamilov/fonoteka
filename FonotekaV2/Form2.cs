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
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT * FROM records ORDER BY id DESC ";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                //Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                dataGridView1.Rows.Add(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),
                    reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(),
                    reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(),
                    reader[16].ToString(), reader[17].ToString(),reader[18].ToString()
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
