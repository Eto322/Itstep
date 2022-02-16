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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Ex1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
                result = FirstEX();
            } while (result == DialogResult.Retry);
        }

        DialogResult FirstEX()
        {
            string FirstBox = "ну тут типа начало ";
            string SecondBox = "ну тут типа средина";
            string ThirdBox = "ну тут типа конец";

            MessageBox.Show(FirstBox, "Ну типа Резюме 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(SecondBox, "Ну типа Резюме 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(ThirdBox, "Ну типа Резюме 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int avg = (FirstBox.Length + SecondBox.Length + ThirdBox.Length) / 3;
           var result=MessageBox.Show($"среднее количество слов {avg}", "Ну типа конец ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            return result;
        }

        static DialogResult FindNumber()
        {
            int count=0;
            DialogResult result;
            int Left = 1, Right = 2000, Middle;
            while (Right >= 1)
            {
                count++;
                Middle = (Left + Right) / 2;
                result = MessageBox.Show($"Я угадал {Middle}?", "Акинатор для бедных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    result = MessageBox.Show($"Ваше число {Middle}.\nДля этого понадобилось {count} запросов.\nХотите сыграть снова?", "Акинатор для бедных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return result;
                }
                else
                {
                    count++;
                    result = MessageBox.Show($"Ваше число больше {Middle}?", "Акинатор для бедных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Left = Middle + 1;
                    }
                    else
                    {
                        Right = Middle - 1;
                    }
                }
            }
            return DialogResult.Abort;
        }
        private void Ex2_Click(object sender, EventArgs e)
        {
            while(true)
            { 
                MessageBox.Show("Акинатор для бедных");
                MessageBox.Show("Загадайте число от 1 до 2000");
                var result = FindNumber();
                if (result == DialogResult.Yes)
                {
                    continue;
                }
                else if (result == DialogResult.Abort)
                {
                    result = MessageBox.Show("Загаданое число не находилось в границах 1 - 2000\nХотите попробовать снова?", "Акинатор для бедных", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        continue;

                    }
                    else
                    {
                        break;
                    }
                    
                }
                else
                {
                    break;
                }
                   
            }
        }

        private void Ex3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
