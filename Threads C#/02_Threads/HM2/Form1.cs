using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM2
{
    public partial class Form1 : Form
    {
        private readonly Thread Ex1;
        private readonly Thread Ex2;
        public Form1()
        {
            InitializeComponent();
            Ex1 = new Thread(Thread1Start);
            Ex2 = new Thread(Thread2Start);
        }

        private void EX1Btn_Click(object sender, EventArgs e)
        {
            Ex1.Start();
            EX1Btn.Enabled = false;

        }




        private void Thread1Start()
        {
            decimal min=2;
            decimal max=int.MaxValue;
           
            if (Min.Value>2)
            {
                min = Min.Value;

            }

            if (Max.Value>2)
            {
                max = Max.Value;
            }

            GeneratePrime(min,max);
        }
        private  void GeneratePrime(decimal start, decimal end)
        {
            //Ex1Box.Invoke(new Action(() => Ex1Box.Text = j.ToString()));

            for (int i =(int)start; i < (int) end; i++)
            {
                var check = 0;
                if (i > 1)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        Ex1Box.Invoke(new Action(() => Ex1Box.Text += i.ToString()+" "));
                    }
                }
            }

        }

        private void Kill1_Click(object sender, EventArgs e)
        {
           
            Ex1.Abort();//при таком варианте завершения опять его запустить не получиться 
            //EX1Btn.Enabled = true;
        }


        private uint Fibonacci(int n)
        {

            uint first = 0;
            uint second = 1;
            uint result = 0;

            if (n == 0)
            {
                return 0;
            } 
            if (n == 1)
            {
                return 1;
            }
            for (int i = 2; i <= n; i++)  
            {
                result = first + second;
                first = second;
                second = result;
            }
            return result;
        }

        private void Thread2Start()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                Ex2Box.Invoke(new Action(() => Ex2Box.Text += Fibonacci(i).ToString()+" "));
            }
        }
        private void Ex2btn_Click(object sender, EventArgs e)
        {
            Ex2.Start();
            Ex2btn.Enabled= false;
        }

        private void Kill2_Click(object sender, EventArgs e)
        {
            Ex2.Abort();
        }
    }
}
