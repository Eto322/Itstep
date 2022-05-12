using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asdd
{
    public partial class Form1 : Form
    {
        private Group ChangingGroup;
        private Student ChangingStudent;
        public Form1()
        {
            InitializeComponent();
            LoadGroups(comboBox1);
            LoadAllStudents();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        public void LoadGroups(ComboBox comboBox)
        {
            comboBox1.DataSource = null;
            comboBox.Items.Clear();
           
            using (var context = new Model1Container())
            {
                var groups = context.Groups.Select(x => new {x.Id,Group=x.Number+x.Letter }).ToList();
                comboBox.DataSource = groups;
                comboBox.DisplayMember = "Group";
                comboBox.ValueMember = "Id";

            }
        }

        public void DeleteGroup()
        {
            var id = (int)comboBox1.SelectedValue;
            using (var context = new Model1Container())
            {
                var group = context.Groups.FirstOrDefault(x => x.Id == id);
                context.Groups.Remove(group);
                var students = context.Students.Where(x => x.GroupId == id).ToList();
                foreach (var student in students)
                {
                    student.GroupId = null;
                    
                }
                context.SaveChanges();
            }
        }

        public void DeleteStudent()
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            using (var context=new Model1Container())
            {
                var student = context.Students.FirstOrDefault(x => x.Id == (int)id);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public void LoadStudents(Int32? groupId)
        {
            dataGridView1.DataSource = null;
            using (var context = new Model1Container())
            {
                var students = context.Students.Where(s => s.GroupId == groupId).ToList();
                dataGridView1.DataSource = students;
            }
            
            
        }

        public void LoadAllStudents()
        {
            dataGridView1.DataSource = null;
            using (var context = new Model1Container())
            {
                var students = context.Students.Select(x => new { x.Id,x.FirstName, x.LastName ,Group=x.Group.Letter+x.Group.Number}).ToList();
                dataGridView1.DataSource = students;
            }

        }

        public void AddGroup()
        {
            using (var context = new Model1Container())
            {
                var group = new Group();
                group.Number ="Change Me";
                group.Letter = "Change Me";
                context.Groups.Add(group);
                context.SaveChanges();

            }



        }

        public void UpdateGroup()
        {
            button7.Enabled = true;
            var id = (int)comboBox1.SelectedValue;
            using (var context = new Model1Container())
            {
                var group = context.Groups.FirstOrDefault(x => x.Id == id);
                textBox1.Text = group.Number;
                textBox2.Text = group.Letter;
                
                ChangingGroup = group;

            }
        }

        public void AddStudent()
        {
            using (var context=new Model1Container())
            {
                var Std = new Student();
                Std.FirstName = "Change Me";
                Std.LastName = "Change Me";
                Std.Email = "Change Me";
                Std.GroupId = null;
                context.Students.Add(Std);
                context.SaveChanges();
            }
        }
        
        public void UpdateStudent()
        {
            button8.Enabled = true;
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            using (var context = new Model1Container())
            {
                var student = context.Students.FirstOrDefault(x => x.Id == (int)id);
                textBox3.Text = student.FirstName;
                textBox4.Text = student.LastName;
                textBox5.Text = student.Email;
                LoadGroups(comboBox2);
                ChangingStudent = student;
                

            }
        }

        public void SaveStudent(Student student)
        {
            button8.Enabled = false;
            using (var context=new Model1Container())
            {
                student.FirstName = textBox3.Text;
                student.LastName = textBox4.Text;
                student.Email = textBox5.Text;
                student.GroupId = (int)comboBox2.SelectedValue;
                context.Students.AddOrUpdate(student);
                context.SaveChanges();
            }
        }
        public void SaveGroup(Group group)
        {
            using (var context = new Model1Container())
            {
                group.Number = textBox1.Text;
                group.Letter = textBox2.Text;
                context.Groups.AddOrUpdate(group);
                context.SaveChanges();
            }
            button7.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAllStudents();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadStudents((Int32?)comboBox1.SelectedValue);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteGroup();
            LoadGroups(comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteStudent();
            LoadAllStudents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStudent();
            LoadAllStudents();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddGroup();
            LoadGroups(comboBox1);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateGroup();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveGroup(ChangingGroup);
            LoadGroups(comboBox1);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateStudent();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveStudent(ChangingStudent);
            LoadAllStudents();
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

        }
    }
}
