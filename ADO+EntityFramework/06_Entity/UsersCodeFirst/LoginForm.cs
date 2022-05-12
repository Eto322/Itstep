using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersCodeFirst
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            using (var context = new UsersDataContext())
            {
                

                if (context.User.ToList().Exists(x => x.Login == login && x.Password == password))
                {
                    var user = context.User.FirstOrDefault(x => x.Login == login && x.Password == password);
                    MessageBox.Show("Your Entered Like " + login);
                    textBox3.Text = user.Email;
                    textBox4.Text = user.Role;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
