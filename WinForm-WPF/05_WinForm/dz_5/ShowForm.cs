using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz_5
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
        }

        public ShowForm(string text,string imagepath)
        {
            InitializeComponent();
            richTextBox1.AppendText(text);
            var image=Image.FromFile(imagepath);

            var bmp = new Bitmap(image, pictureBox1.Size);
           
            pictureBox1.Image=bmp;
        }
    }
}
