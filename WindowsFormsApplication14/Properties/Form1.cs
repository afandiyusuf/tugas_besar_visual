﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        private string conn;
        private MySqlConnection connect;

        public Form1()
        {
            InitializeComponent();
        }
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=visual_tugas;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        private bool validate_login(string user, string pass)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from login_table where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "Server=localhost;Database=visual_tugas;Uid=root;Pwd=;";
                string Query = "INSERT INTO `login_table` (`username`, `password`) VALUES ('" + textBox3.Text + "','" + textBox6.Text + "')";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Save Data");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox6.PasswordChar = '*';

            string MyConnection1 = "Server=localhost;Database=visual_tugas;Uid=root;Pwd=;";
            string Query1 = "SELECT * FROM `pengumuman`;";
            MySqlConnection MyConn1 = new MySqlConnection(MyConnection1);
            MySqlCommand MyCommand1 = new MySqlCommand(Query1, MyConn1);
            MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
            MyAdapter1.SelectCommand = MyCommand1;
            DataTable dTable1 = new DataTable();
            MyAdapter1.Fill(dTable1);
            foreach (DataRow row in dTable1.Rows)
            {

                label2.Text = (row["pengumuman"]).ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Empty Fields Detected! Please fill up all the fields");
                return;
            }
            if (user == "admin" && pass == "1234")
            {
                MessageBox.Show("Welcome Admin!");
                Form3 frm3 = new Form3();
                frm3.Show();
            }
            else{
                bool r = validate_login(user, pass);
                if (r)
                {
                    MessageBox.Show("Login Success!");
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                else
                    MessageBox.Show("Incorrect Login Credentials!");
            }
        }
    }
}
