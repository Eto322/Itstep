using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz_5
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(Goods tmp)
        {
            InitializeComponent();
            textBox1.Text = tmp.Name;
            textBox2.Text = tmp.Manufactor;
            textBox3.Text = tmp.ManufactorCountry;
            textBox4.Text = tmp.UKTZ;
            textBox5.Text = tmp.Price.ToString();
            checkBox1.Checked = tmp.Garanty;
            textBox6.Text = tmp.Photo;
            
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (data_validating())
            {
                this.Close();
            }
        }

        public Goods GetGoods()
        {
           
                return (new Goods(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToDouble(textBox5.Text)
               , checkBox1.Checked, textBox6.Text));
           
          
           
        }

        private bool data_validating()
        {

            if (String.IsNullOrEmpty(textBox1.Text)||String.IsNullOrWhiteSpace(textBox1.Text)||
                String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) ||
                String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrWhiteSpace(textBox4.Text) ||
                String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrWhiteSpace(textBox5.Text) ||
                String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("One of arguments are empty");
                return false;
            }
            
            if (!Double.TryParse(textBox5.Text,out double tmp))
            {
                MessageBox.Show("Price not in right format");
                return false;

            }

            if (!File.Exists(textBox6.Text))
            {
                MessageBox.Show("Path to photo didnt exist");
                return false;
            }

            return true;
        }
    }
}
