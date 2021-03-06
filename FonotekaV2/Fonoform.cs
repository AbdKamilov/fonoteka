﻿using MySql.Data.MySqlClient;
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
    public partial class Fonoform : Form
    {
        public Fonoform()
        {
            InitializeComponent();
        }
        public bool insertStatus = false;

        string connStr = "Server=" + Properties.Settings.Default.AppServer + ";Database=" +
            Properties.Settings.Default.AppDB + ";User Id=" + Properties.Settings.Default.DBuser + ";password=" + Properties.Settings.Default.DBpassword + ";port=" + Properties.Settings.Default.Dbport + ";CharSet=utf8";


        private void Fonoform_Load(object sender, EventArgs e)
        {
            insertStatus = false;
            // создаём объект для подключения к БД
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

            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            //comboBox3.SelectedIndex = 0;
            //comboBox4.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // isert data
            int janrID=0, themeID=0, sectionID=0, recType=0;
            Object selectedItemj = comboBox1.SelectedItem;
            Object selectedItemt = comboBox4.SelectedItem;
            Object selectedItemtype = comboBox3.SelectedItem;
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
            if (selectedItemtype == null)
            {
                recType = 3;
            }
            else if (selectedItemtype.ToString() == "Моно")
            {
                recType = 0;
            }
            else if (selectedItemtype.ToString() == "Стерео")
                recType = 1;
            else if (selectedItemtype.ToString() == "подлен.пер.")
                recType = 2;
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                //This is my insert query in which i am taking input from the user through windows forms             
                string sqlg = "select * from genres where Name = '"+ strJ+"' ";
                string sqlt = "select * from themes where Name = '" + strT + "' ";
                string sqls = "select * from sections where Name = '" + strS + "' ";

                MySqlCommand commandg = new MySqlCommand(sqlg, conn);
                MySqlDataReader readerg = commandg.ExecuteReader();
                while (readerg.Read())
                {
                   janrID = int.Parse(readerg["id"].ToString());
                }
                readerg.Close();

                MySqlCommand commandt = new MySqlCommand(sqlt, conn);
                MySqlDataReader readert = commandt.ExecuteReader();
                while (readert.Read())
                {
                    themeID = int.Parse(readert["id"].ToString());
                }
                readert.Close();

                MySqlCommand commandS = new MySqlCommand(sqls, conn);
                MySqlDataReader readers = commandS.ExecuteReader();
                while (readers.Read())
                {
                    sectionID = int.Parse(readers["id"].ToString());
                }
                readers.Close();
                // закрываем соединение с БД
                conn.Close();


                string Query = "insert into records (" +
                    "DVDNO," +
                    "CDNo," +
                    "RecNo," +
                    "LastNo," +
                    "Title," +
                    "Composer," +
                    "Author," +
                    "Performer," +
                    "Rubrika," +
                    "Accompaniment," +
                    "IssueYear," +
                    "Genre," +
                    "Phonation," +
                    "Theme," +
                    "Section," +
                    "RecType," +
                    "Comment" +              
                    ") values('" 
                    + this.textBox1.Text + "','" 
                    + this.textBox2.Text + "','"
                    + this.textBox3.Text + "','"
                    + this.textBox4.Text + "','"
                    + this.textBox5.Text + "','"
                    + this.textBox6.Text + "','"
                    + this.textBox7.Text + "','"
                    + this.textBox8.Text + "','"
                    + this.textBox9.Text + "','"
                    + this.textBox12.Text + "','"
                    + this.textBox11.Text + "',"
                    + janrID + ",'"
                    + this.textBox10.Text + "',"
                    + themeID + ","
                    + sectionID + ","
                    + recType + ",'"
                    + this.textBox13.Text 
                    + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(connStr);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Данные успешно добавлено!");
                insertStatus = true;
                MyConn2.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
