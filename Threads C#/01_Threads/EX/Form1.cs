using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void EX1_Click(object sender, EventArgs e)
        {
            

            ExitCodeLabel.Text = ex1run().ToString();
        }

        private int ex1run()
        {
            var proc = new Process();
            proc.StartInfo.FileName = "notepad.exe";
            File.WriteAllText("CloseME.txt", "Close Me");
            proc.StartInfo.Arguments = "CloseME.txt";
            proc.Start();
            proc.WaitForExit();
            var retutncode = proc.ExitCode;
            return retutncode;
        }

        private void EX2_Click(object sender, EventArgs e)
        {
            var form  = new Form2();
            form.Show();
        }

        private void EX3_Click(object sender, EventArgs e)
        {




            string path = AppDomain.CurrentDomain.BaseDirectory;
            string newpath= Path.GetFullPath(Path.Combine(path, @"..\..\..\..\Calculator\bin\Debug\net5.0\Calculator.exe"));
            var proc = new Process();
            proc.StartInfo.FileName = newpath;

          
            proc.StartInfo.Arguments = FirstNumber.Text+signBox.Text+ SecondNumber.Text;
            proc.Start();
            proc.WaitForExit();

        }
    }
}
