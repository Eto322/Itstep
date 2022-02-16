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
    public partial class Form2 : Form
    {
        private Process proc = new Process();

        public Form2()
        {
            InitializeComponent();
            startproc();
           

        }

        private void Waitbutton_Click(object sender, EventArgs e)
        {
            
            
            proc.WaitForExit();
            ExitCodeLabelEX2.Text = codereturn().ToString();

        }

        private void Killbutton_Click(object sender, EventArgs e)
        {
            proc.Kill();
            proc.WaitForExit();
            ExitCodeLabelEX2.Text = codereturn().ToString();
        }


        private void CloseFormbuttn_Click(object sender, EventArgs e)
        {
            proc.Kill();
            this.Close();

        }

        private void startproc()
        {
            proc.StartInfo.FileName = "notepad.exe";
            File.WriteAllText("KillORCloseMe.txt", "Kill OR Close Me please ");
            proc.StartInfo.Arguments = "KillORCloseMe";
            proc.Start();
           



        }

        private int codereturn()
        {
           
            var retutncode = proc.ExitCode;
            return retutncode;

        }
    }
}
