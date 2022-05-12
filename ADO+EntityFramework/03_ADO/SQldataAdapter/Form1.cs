using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQldataAdapter
{
    public partial class Form1 : Form
    {
        private bool DataLoaded = false;
        private DataTable comboBoxData = new DataTable();
        /*private DataTable DatagridData = new DataTable();*/

        
        private static string connectionString = @"Server=Taras;Database=Shop;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(connectionString);
        private SqlDataAdapter dataAdapter = new SqlDataAdapter("select [Name] from sys.tables", connectionString);
        public Form1()
        {
            
            
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            FillComboBox();
            


        }

        public SqlDataAdapter ChangeDataAdapter(SqlDataAdapter dataAdapter, string tableName)
        {
            

            dataAdapter.SelectCommand =
                new SqlCommand($"SELECT * FROM {tableName}", con);
            dataAdapter.DeleteCommand = 
                new SqlCommand($"DELETE FROM {tableName} WHERE {tableName}Id = {GetIndex()}", con);
            dataAdapter.InsertCommand =
                new SqlCommand($"INSERT INTO {tableName} VALUES ('changeMe')", con);
            dataAdapter.UpdateCommand =
                new SqlCommand($"UPDATE {tableName} SET {tableName}Name = '{textBox1.Text}' WHERE {tableName}Id = {GetIndex()}", con);

            if (comboBox1.SelectedIndex == 2)
            {
                dataAdapter.InsertCommand =
                    new SqlCommand($"INSERT INTO {tableName}({tableName}Name,{tableName}Count,Price) VALUES ('changeMe',{-1},{-1})", con);
                dataAdapter.UpdateCommand =
                    new SqlCommand($"UPDATE {tableName} SET {tableName}Name = '{textBox1.Text}',{tableName}Count={textBox2.Text},Price={textBox3.Text} WHERE {tableName}Id = {GetIndex()}", con);
            }

            return dataAdapter;
        }

        public string GetIndex()
        {
            return dataGridView1.CurrentRow?.Cells[0].Value.ToString()??"";
        }

        public string SetName()
        {
            return dataGridView1.CurrentRow?.Cells[1].Value.ToString() ?? "";
        }

        public string SetCount()
        {
            return dataGridView1.CurrentRow?.Cells[2].Value.ToString() ?? "";
        }

        public string SetPrice()
        {
            return dataGridView1.CurrentRow?.Cells[3].Value.ToString() ?? "";
        }
        public void FillComboBox()
        {

            dataAdapter.Fill(comboBoxData);
            comboBox1.DataSource = comboBoxData;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";

        }

        public void FillDataGridView()
        {
            dataAdapter = ChangeDataAdapter(dataAdapter, comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            DataTable dt = new DataTable();
            
            dataAdapter.Fill(dt);
           /* DatagridData = dt;    */       


            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = null;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAdapter = ChangeDataAdapter(dataAdapter, comboBox1.SelectedValue.ToString());
            con.Open();
            dataAdapter.DeleteCommand.ExecuteNonQuery();
            FillDataGridView();

            con.Close();



        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataAdapter = ChangeDataAdapter(dataAdapter, comboBox1.SelectedValue.ToString());
            con.Open();
            dataAdapter.InsertCommand.ExecuteNonQuery();
            FillDataGridView();

            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = SetName();
            textBox2.Text = "";
            textBox3.Text = "";

            if (comboBox1.SelectedIndex == 2)
            {
                textBox2.Text = SetCount();
                textBox3.Text = SetPrice();
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataAdapter = ChangeDataAdapter(dataAdapter, comboBox1.SelectedValue.ToString());
            con.Open();
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            FillDataGridView();

            con.Close();
        }
    }
}
