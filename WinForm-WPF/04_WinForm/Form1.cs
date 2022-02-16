using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asdddd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Ex1Bar.Minimum = 0;
            Ex1Bar.Step = 1;
            Ex1Bar.Maximum = 5;

        }
        //EX1
        private void MinUp_ValueChanged(object sender, EventArgs e)
        {
            if (data_validating())
            {
                Ex1Bar.Minimum = (int)MinUp.Value;
            }
            else
            {
                MinUp.Value =0;
            }
            
        }

        private void MaxUp_ValueChanged(object sender, EventArgs e)
        {
            if (data_validating())
            {
                Ex1Bar.Maximum = (int)MaxUp.Value;
            }
            else
            {
                MaxUp.Value = 5;
            }

        }

        private void StepUp_ValueChanged(object sender, EventArgs e)
        {
            if (data_validating())
            {
                Ex1Bar.Step = (int)StepUp.Value;
            }
            else
            {
                StepUp.Value =1;
            }

        }

       

    

        private void StartButton_Click(object sender, EventArgs e)
        {
            ResetButton.Enabled = false;
            for (int i = Ex1Bar.Minimum; i <= Ex1Bar.Maximum; i+=Ex1Bar.Step)
            {
                Ex1Bar.Value = i;

                ProgressBarValue.Text= Ex1Bar.Value.ToString();
                this.Update();
                Thread.Sleep(1000*Ex1Bar.Step);
            }
            ResetButton.Enabled = true;

        }

     
       

        public bool data_validating()
        {
            if (MinUp.Value>MaxUp.Value)
            {
                MessageBox.Show("Min is bigger then Max" + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (StepUp.Value>MaxUp.Value-MinUp.Value)
            {
                MessageBox.Show("StepBigger then Max-Min " + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            MinUp.Value = 0;
            MaxUp.Value = 5;
            StepUp.Value = 1;

            Ex1Bar.Minimum = 0;
            Ex1Bar.Step = 1;
            Ex1Bar.Maximum = 5;
        }
        //EX2
        public List<string> TextFile { get; set; } = new List<string>();
        static int countRow = 0;
        public int TextSize { get; set; } = 0;

        private void StartButtonEX2_Click(object sender, EventArgs e)
        {

           

            if (string.IsNullOrEmpty(PathBox.Text)||string.IsNullOrWhiteSpace(PathBox.Text))
            {

                MessageBox.Show("PathBox empty");
                return;
            }

            if (!File.Exists(PathBox.Text))
            {
                MessageBox.Show("Path didint exisit");
                return;
            }

            StreamReader stream = new StreamReader(PathBox.Text);
            string line = "";
            while ((line = stream.ReadLine()) != null)
            {
                TextFile.Add(line+"\n");
                TextSize++;
            }
            progressBarEX2.Maximum = TextSize;


          
            int count = 0;
            while (countRow < TextSize)
            {
                
                Ex2RichBox.AppendText(TextFile[countRow]);
                countRow++;
                count++;
            }
            progressBarEX2.Value += count;
        }

       
    }
}

