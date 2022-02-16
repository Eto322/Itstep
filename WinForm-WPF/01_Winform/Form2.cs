using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        public bool isCntrl { get; set; } = false;
        public Form2()
        {
            InitializeComponent();
        }

      

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isCntrl)
                {
                    this.Close();
                }
                   
                else
                {
                    if (e.X < 10 || e.Y < 10 || e.X > this.ClientSize.Width - 10
                        || e.Y > this.ClientSize.Height - 10)
                    {
                        MessageBox.Show("За границами прямоугольника");
                    }
                    else if (e.X >= 10 && e.X <= 15 || e.X >= this.ClientSize.Width - 15 &&
                        e.X <= this.ClientSize.Width - 10 || e.Y >= 10 && e.Y <= 15 
                        || e.Y >= this.ClientSize.Height - 15 && e.Y <= this.ClientSize.Height - 10)
                    {
                        MessageBox.Show("На границе прямоугольника");
                    }
                       
                    else if (e.X > 15 || e.Y > 15 || e.X < this.ClientSize.Width - 15 
                        || e.Y < this.ClientSize.Height)
                    {
                        MessageBox.Show("В прямоугольнике");
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Text = $"Ширина = {this.ClientSize.Width} Высота = {this.ClientSize.Height}";
            }
            else
            {
                this.Text = $"X = {e.X} Y = {e.Y}";
            }
                
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            isCntrl = e.Control;
        }

      

    

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkCyan);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(10,10, this.ClientSize.Width - 20, this.ClientSize.Height - 20));
            myBrush.Dispose();
            
        }
    }
}
