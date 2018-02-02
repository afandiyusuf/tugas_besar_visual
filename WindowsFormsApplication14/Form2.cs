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

namespace WindowsFormsApplication14
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void jadwalKuliahToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "Server=localhost;Database=visual_tugas;Uid=root;Pwd=;";
                //Display query  
                string Query = "SELECT * FROM `jadwal`;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
