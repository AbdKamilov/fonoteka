using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace FonotekaV2
{
    public partial class Index : Form
    {
        public int sectedRow;

        string connStr = "Server=" + Properties.Settings.Default.AppServer + ";Database=" +
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword + ";port=" + Properties.Settings.Default.Dbport + ";CharSet=utf8";


        public Index()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            
        }

        //public void StartForm()
        //{
        //    //using (ProgressLoad prog = new ProgressLoad())
        //    //{
        //    //    prog.ShowDialog(this);
        //    //}
        //    //Application.Run(new ProgressLoad());
        //}

        // search
        private void search_Click(object sender, EventArgs e)
        {
            Object selectedItemj = comboBox1.SelectedItem;
            Object selectedItemt = comboBox3.SelectedItem;
            Object selectedItems = comboBox2.SelectedItem;
            string strJ;
            string strT;
            string strS;
            if (selectedItemj == null)
                strJ = "";
            else
                strJ = selectedItemj.ToString();
            if (selectedItemt == null)
                strT = "";
            else
                strT = selectedItemt.ToString();
            if (selectedItems == null)
                strS = "";
            else
                strS = selectedItems.ToString();

            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);

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
                "r.Accompaniment LIKE '%"+textBox10.Text+ "%' ORDER BY r.id ASC";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dataGridView1.Refresh();
            // читаем результат
            //reader.Read();
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
            //t.Abort();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);

            //dataGridView1.Rows.Add(
            //    1,
            //    23,
            //    343,
            //    333,
            //    4444,
            //    "fdgf",
            //    "auyytor",
            //   "Composer",
            //    "Author",
            //    "Performer",
            //    "Accompaniment",
            //    "IssueYear",
            //    21,
            //   "Phonation",
            //    23,
            //    25,
            //    123321,
            //    "Comment"
            //        );

            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlConnection conn2 = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT r.*, g.*, t.*, s.* FROM records as r  " +
                "JOIN genres as g ON r.Genre = g.id " +
                "JOIN themes as t ON t.id = r.Theme " +
                "JOIN sections as s ON s.id = r.Section ORDER BY r.id ASC";
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

            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            //comboBox3.SelectedIndex = 0;
            //t.Abort();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
    
            if (e.RowIndex >= 0)
            {
                this.sectedRow = int.Parse(e.RowIndex.ToString());
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                row.Selected = true;
                textBox11.Text = "Запис: "+row.Cells["namerecord"].Value.ToString()+
                    Environment.NewLine + "Исролнитель: "+row.Cells["executor"].Value.ToString()+
                    Environment.NewLine + "Автор музыки: " + row.Cells["musicauthor"].Value.ToString()+
                    Environment.NewLine + "Жанр: " + row.Cells["style"].Value.ToString() +
                    Environment.NewLine + "Теаматика: " + row.Cells["subject"].Value.ToString() +
                    Environment.NewLine + "Отдел: " + row.Cells["department"].Value.ToString() +
                    Environment.NewLine + "Звучание: " + row.Cells["sounding"].Value.ToString()
                    ;
                textBox12.Text = "Сопровождение: " + row.Cells["escort"].Value.ToString();
                textBox13.Text = row.Cells["comment"].Value.ToString();
            }
          //MessageBox.Show(e.RowIndex.ToString());
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
            if (add.insertStatus)
            {
                Obnovit();
            }
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (sectedRow != null)
            {
                FormEdit edit = new FormEdit();
                DataGridViewRow row = dataGridView1.Rows[sectedRow];
                edit.dvd = row.Cells[1].Value.ToString();
                edit.cd = row.Cells[2].Value.ToString();
                edit.noOriginal = row.Cells[3].Value.ToString();
                edit.noFond = row.Cells[4].Value.ToString();
                edit.NameTitle = row.Cells[6].Value.ToString();
                edit.authorM = row.Cells[7].Value.ToString();
                edit.authorS = row.Cells[8].Value.ToString();
                edit.ispol = row.Cells[9].Value.ToString();
                edit.rubrika = row.Cells[5].Value.ToString();
                edit.janr = row.Cells[12].Value.ToString();
                edit.zvuchanie = row.Cells[13].Value.ToString();
                edit.year= row.Cells[11].Value.ToString();
                edit.otdel = row.Cells[15].Value.ToString();
                edit.type = row.Cells[16].Value.ToString();
                edit.theme = row.Cells[14].Value.ToString();
                edit.sopro = row.Cells[10].Value.ToString();
                edit.dopol = row.Cells[17].Value.ToString();
                edit.dataID = row.Cells[0].Value.ToString();
                edit.ShowDialog();
                if (edit.updateStatus)
                {
                    string[] array = new string[18];
                    array = edit.getValues();
                    DataGridViewRow newDataRow = dataGridView1.Rows[sectedRow];
                    newDataRow.Cells[0].Value = array[0];
                    newDataRow.Cells[1].Value = array[1];
                    newDataRow.Cells[2].Value = array[2];
                    newDataRow.Cells[3].Value = array[3];
                    newDataRow.Cells[4].Value = array[4];
                    newDataRow.Cells[5].Value = array[5];
                    newDataRow.Cells[6].Value = array[6];
                    newDataRow.Cells[7].Value = array[7];
                    newDataRow.Cells[8].Value = array[8];
                    newDataRow.Cells[9].Value = array[9];
                    newDataRow.Cells[10].Value = array[10];
                    newDataRow.Cells[11].Value = array[11];
                    newDataRow.Cells[12].Value = array[12];
                    newDataRow.Cells[13].Value = array[13];
                    newDataRow.Cells[14].Value = array[14];
                    newDataRow.Cells[15].Value = array[15];
                    newDataRow.Cells[16].Value = array[16];
                    newDataRow.Cells[17].Value = array[17];

                }

            }
            else
                MessageBox.Show("Выбирайте чтобы изменить данных!");
            
        }

        public void Obnovit()
        {
            Object selectedItemj = comboBox1.SelectedItem;
            Object selectedItemt = comboBox3.SelectedItem;
            Object selectedItems = comboBox2.SelectedItem;
            string strJ;
            string strT;
            string strS;
            if (selectedItemj == null)
                strJ = "";
            else
                strJ = selectedItemj.ToString();
            if (selectedItemt == null)
                strT = "";
            else
                strT = selectedItemt.ToString();
            if (selectedItems == null)
                strS = "";
            else
                strS = selectedItems.ToString();

            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);

            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "SELECT r.*, g.*, t.*, s.* FROM records as r  " +
                "JOIN genres as g ON r.Genre = g.id " +
                "JOIN themes as t ON t.id = r.Theme " +
                "JOIN sections as s ON s.id = r.Section " +
                "WHERE " +
                "r.Title LIKE '%" + textBox1.Text + "%' AND " +
                "r.Performer LIKE '%" + textBox2.Text + "%' AND " +
                "r.Composer like '%" + textBox3.Text + "%' AND " +
                "r.Author like '%" + textBox4.Text + "%' AND " +
                "g.Name like '%" + strJ + "%' AND " +
                "s.Name LIKE '%" + strS + "%' AND " +
                "t.Name LIKE '%" + strT + "%' AND " +
                "r.Rubrika LIKE '%" + textBox5.Text + "%' AND " +
                "r.IssueYear LIKE '%" + textBox6.Text + "%' AND " +
                "r.CDNo LIKE '%" + textBox7.Text + "%' AND " +
                "r.RecNo LIKE '%" + textBox8.Text + "%' AND " +
                "r.LastNo LIKE '%" + textBox9.Text + "%' AND " +
                "r.Accompaniment LIKE '%" + textBox10.Text + "%' ORDER BY r.id ASC";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
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
            //t.Abort();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show( "Вы действительно хотите удалить?", "Удалить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (sectedRow != null)
                {
                    try
                    {
                        DataGridViewRow row = dataGridView1.Rows[sectedRow];
                        MySqlConnection connection = new MySqlConnection(connStr);
                        // открываем соединение
                        connection.Open();
                        // запрос удаления данных
                        string query = "DELETE FROM records WHERE id = " + int.Parse(row.Cells[0].Value.ToString());
                        // объект для выполнения SQL-запроса
                        MySqlCommand command = new MySqlCommand(query, connection);
                        // выполняем запрос
                        command.ExecuteNonQuery();
                        // закрываем подключение к БД
                        connection.Close();
                        MessageBox.Show("Данные успешно удалено!");
                        dataGridView1.Rows.RemoveAt(sectedRow);
                        //this.Obnovit();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Выбирайте чтобы изменить данных!");
            }
            
   
        }
        //в Excel
        private void button18_Click(object sender, EventArgs e)
        {
            int DataSize = Int32.Parse(dataGridView1.RowCount.ToString());
            if(DataSize == 0 || DataSize == null)
            {
                MessageBox.Show("Нет данных для печати!","Ошибка!!!");
            }
            else
            {
                if(DataSize > 500)
                {
                    Excel ex = new Excel();
                    ex.CreateNewFile(500);
                    string[,] dataString = new string[500, 12];
                    dataString = getDataString(500);
                    ex.WriteRange(3, 1, 502, 12, dataString);
                }
                else
                {
                    Excel ex = new Excel();
                    ex.CreateNewFile(DataSize);
                    string[,] dataString = new string[DataSize, 12];
                    dataString = getDataString(DataSize);
                    ex.WriteRange(3, 1, DataSize+2, 12, dataString);
                }
               
            }

        }

        public string [,] getDataString(int DataSize)
        {
            string[,] datastring = new string[DataSize, 12];
            int flag = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (flag == DataSize)
                    break;
                datastring[flag, 0] = row.Cells[1].Value.ToString();
                datastring[flag, 1] = row.Cells[2].Value.ToString();
                datastring[flag, 2] = row.Cells[4].Value.ToString();
                datastring[flag, 3] = row.Cells[6].Value.ToString();
                datastring[flag, 4] = row.Cells[7].Value.ToString();
                datastring[flag, 5] = row.Cells[8].Value.ToString();
                datastring[flag, 6] = row.Cells[9].Value.ToString();
                datastring[flag, 7] = row.Cells[10].Value.ToString();
                datastring[flag, 8] = row.Cells[11].Value.ToString();
                datastring[flag, 9] = row.Cells[13].Value.ToString();
                datastring[flag, 10] = row.Cells[15].Value.ToString();
                datastring[flag, 11] = row.Cells[16].Value.ToString();
                flag++;
            }
            
            return datastring;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ResetPass form = new ResetPass();
            form.ShowDialog();
        }

        public void StatusUser()
        {
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            //button18.Enabled = false;
            button19.Enabled = false;
        }
    }
}
