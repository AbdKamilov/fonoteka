using MySql.Data.MySqlClient;
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
    public partial class FormEdit : Form
    {
        public string dvd, cd, noOriginal, noFond, NameTitle, authorM, 
            authorS, ispol, rubrika, janr, zvuchanie, 
            year, otdel, type, theme, sopro, dopol, dataID;
        public bool updateStatus = false;
        public string janrName, otdelName, themeName, recName;

        string connStr = "Server=" + Properties.Settings.Default.AppServer + ";Database=" +
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword + ";port=" + Properties.Settings.Default.Dbport + ";CharSet=utf8";


        private void button1_Click(object sender, EventArgs e)
        {
            // update data
            int janrID = 0, themeID = 0, sectionID = 0, recType = 0;
            Object selectedItemj = comboBox1.SelectedItem;
            Object selectedItemt = comboBox4.SelectedItem;
            Object selectedItemtype = comboBox3.SelectedItem;
            Object selectedItems = comboBox2.SelectedItem;
            string strJ = selectedItemj.ToString();
            string strT = selectedItemt.ToString();
            string strS = selectedItems.ToString();
            if (selectedItemtype.ToString() == "Моно")
            {
                recType = 0;
                recName = "Моно";
            }
            else if (selectedItemtype.ToString() == "Стерео")
            {
                recType = 1;
                recName = "Стерео";
            }
            else if (selectedItemtype.ToString() == "подлен.пер.")
            {
                recType = 2;
                recName = "подлен.пер.";
            }
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                //This is my insert query in which i am taking input from the user through windows forms             
                string sqlg = "select * from genres where Name = '" + strJ + "' ";
                string sqlt = "select * from themes where Name = '" + strT + "' ";
                string sqls = "select * from sections where Name = '" + strS + "' ";

                MySqlCommand commandg = new MySqlCommand(sqlg, conn);
                MySqlDataReader readerg = commandg.ExecuteReader();
                while (readerg.Read())
                {
                    janrID = int.Parse(readerg["id"].ToString());
                    janrName = readerg["Name"].ToString();
                }
                readerg.Close();

                MySqlCommand commandt = new MySqlCommand(sqlt, conn);
                MySqlDataReader readert = commandt.ExecuteReader();
                while (readert.Read())
                {
                    themeID = int.Parse(readert["id"].ToString());
                    themeName = readert["Name"].ToString();
                }
                readert.Close();

                MySqlCommand commandS = new MySqlCommand(sqls, conn);
                MySqlDataReader readers = commandS.ExecuteReader();
                while (readers.Read())
                {
                    sectionID = int.Parse(readers["id"].ToString());
                    otdelName = readers["Name"].ToString();
                }
                readers.Close();
                // закрываем соединение с БД
                conn.Close();


                string Query = "update records set " +
                    "DVDNO = '" + this.textBox1.Text + "'," +
                    "CDNo = '" + this.textBox2.Text + "'," +
                    "RecNo = '" + this.textBox3.Text + "'," +
                    "LastNo = '" + this.textBox4.Text + "'," +
                    "Title = '" + this.textBox5.Text + "'," +
                    "Composer = '" + this.textBox6.Text + "'," +
                    "Author = '" + this.textBox7.Text + "'," +
                    "Performer = '" + this.textBox8.Text + "'," +
                    "Rubrika = '" + this.textBox9.Text + "'," +
                    "Accompaniment = '" + this.textBox12.Text + "'," +
                    "IssueYear = '" + this.textBox11.Text + "'," +
                    "Genre = " + janrID + "," +
                    "Phonation = '" + this.textBox10.Text + "'," +
                    "Theme = " + themeID + "," +
                    "Section = " + sectionID + "," +
                    "RecType = " + recType + "," +
                    "Comment = '" + this.textBox13.Text +"' where id = " + dataID;
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(connStr);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                MyCommand2.ExecuteNonQuery();
                // закрываем подключение к БД
                MyConn2.Close();
                MessageBox.Show("Данные успешно обновлены!");
                this.updateStatus = true;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            this.updateStatus = false;
            textBox1.Text = dvd;
            textBox2.Text = cd;
            textBox3.Text = noOriginal;
            textBox4.Text = noFond;
            textBox5.Text = NameTitle;
            textBox6.Text = authorM;
            textBox7.Text = authorS;
            textBox8.Text = ispol;
            textBox9.Text = rubrika;
            textBox10.Text = zvuchanie;
            textBox11.Text = year;
            textBox12.Text = sopro;
            textBox13.Text = dopol;

            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlConnection conn2 = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос 
            string sqlg = "select * from genres";
            string sqlt = "select * from themes";
            string sqls = "select * from sections";

            MySqlCommand commandg = new MySqlCommand(sqlg, conn);
            MySqlDataReader readerg = commandg.ExecuteReader();
            while (readerg.Read())
            {
                comboBox1.Items.Add(readerg["Name"].ToString());
            }
            readerg.Close();

            MySqlCommand commandt = new MySqlCommand(sqlt, conn);
            MySqlDataReader readert = commandt.ExecuteReader();
            while (readert.Read())
            {
                comboBox4.Items.Add(readert["Name"].ToString());
            }
            readert.Close();

            MySqlCommand commandS = new MySqlCommand(sqls, conn);
            MySqlDataReader readers = commandS.ExecuteReader();
            while (readers.Read())
            {
                comboBox2.Items.Add(readers["Name"].ToString());
            }
            readers.Close();
            // закрываем соединение с БД
            conn.Close();

            comboBox3.Items.Add("Моно");
            comboBox3.Items.Add("Стерео");
            comboBox3.Items.Add("подлен.пер.");


            comboBox1.SelectedItem = janr;
            comboBox2.SelectedItem = otdel;
            comboBox3.SelectedItem = type;
            comboBox4.SelectedItem = theme;
        }

        public FormEdit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //get array
        public  string[] getValues()
        {
            string[] array = new string[18];
            array[0] = dataID;
            array[1] = this.textBox1.Text;
            array[2] = this.textBox2.Text;
            array[3] = this.textBox3.Text;
            array[4] = this.textBox4.Text;
            array[5] = this.textBox9.Text;
            array[6] = this.textBox5.Text;
            array[7] = this.textBox6.Text;
            array[8] = this.textBox7.Text;
            array[9] = this.textBox8.Text;
            array[10] = this.textBox12.Text;
            array[11] = textBox11.Text;
            array[12] = janrName;
            array[13] = textBox10.Text;
            array[14] = themeName;
            array[15] = otdelName;
            array[16] = recName;
            array[17] = this.textBox13.Text;
            return array;
        }
    }
}
