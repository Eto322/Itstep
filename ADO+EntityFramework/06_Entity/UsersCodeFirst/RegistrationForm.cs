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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkLogin())
            {
                NewUser();
            }
        }

        private bool checkLogin()
        {
            var login = textBox2.Text;
            using (var context = new UsersDataContext())
            {
                var user = context.User.FirstOrDefault(u => u.Login == login);

                MessageBox.Show("User with this login already exists");

                return user == null;


            }
        }

        private void NewUser()
        {
            if (textBox3.Text == textBox4.Text)
            {
                using (var context = new UsersDataContext())
                {
                    var user = new User();
                    {
                        user.Login = textBox2.Text;
                        user.Password = textBox3.Text;
                        user.Email = textBox1.Text;
                        
                    }
                    context.User.Add(user);
                    context.SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("Different passwords");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
