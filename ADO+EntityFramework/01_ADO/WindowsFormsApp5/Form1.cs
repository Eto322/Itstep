using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        
        string Connectionstring= string.Empty;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connectionstring = $"Initial Catalog={ConnectionBox.Text}; Integrated Security=True";
            button1.Enabled = false;

            try
            {
                ComboBoxGetdata();

            }
            catch (Exception exception)
            {
              
                MessageBox.Show(exception.ToString());

                throw;
            }
            
        }

        private void ComboBoxGetdata()
        {
           
            string query = "select [name] from sys.tables;";

            comboBox1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(Connectionstring))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }


        }

       

        private void comboBox1_DisplayMemberChanged(object sender, EventArgs e)
        { 

            string query = "select * from [" + comboBox1.Text+"]";
            using (SqlConnection connection = new SqlConnection(Connectionstring))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable data = new DataTable();
                        data.Load(reader);
                        dataGridView1.DataSource = data;
                        var count = dataGridView1.RowCount - 1;
                        Entries.Text = count.ToString();
                    }
                }
            }

        }

        private void ConnectionBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            
        }
    }
}