using System.Xml;
using System.Xml.Serialization;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (SaveCheckBox.CheckState==CheckState.Checked)
            {

                Serealize();
            }
        }

        private Student parse(string tmp)
        {
            var split = tmp.Split(' ');
            int age;
            if (split.Length==4)
            {
                if (int.TryParse(split[2], out age))
                {
                    Student student = new Student(split[0], split[1], age, split[3]);
                    return student;
                }
            }
            
          



            return null;


        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (parse(AddBox.Text) == null)
            {

                MessageBox.Show("Wrong Format  : Name surname Age(in numbers) group");
                return;
            }

            StudentBox.Items.Add(parse(AddBox.Text));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {


            Serealize();


        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            Deserealizer();
        }

        public void Serealize()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
               
                using (Stream stream = File.OpenWrite(folderBrowser.SelectedPath + @"\\student.xml"))
                {
                    textBox2.Text = "saved to" + folderBrowser.SelectedPath + @"\\student.xml";
                    List<Student> students = new List<Student>();
                    foreach (var student in StudentBox.Items)
                    {   students.Add(student as Student);
                        
                    }

                   serializer.Serialize(stream,students);
                }
            }
        }
        public void Deserealizer()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer deSerializer = new XmlSerializer(typeof(List<Student>));

                using (Stream stream = File.OpenRead(fileDialog.FileName))
                {
                    textBox2.Text = "loaded from " + fileDialog.FileName;
                    List<Student> students;

                    students = (List<Student>) deSerializer.Deserialize(stream);


                    foreach (var student in students)
                    {
                        StudentBox.Items.Add(student);
                    }
                }

            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            
            AddBox.Text = StudentBox.SelectedItem.ToString();
            StudentBox.Items.Remove(StudentBox.SelectedItem);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            StudentBox.Items.Remove(StudentBox.SelectedItem);
        }
    }

    
}

   