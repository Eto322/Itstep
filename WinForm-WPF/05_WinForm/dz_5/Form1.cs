using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace dz_5
{
    public partial class Form1 : Form
    {
        /*List<Goods> goods = new List<Goods>();*/
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            f2 = new Form2();
            f2.Show();

        }

        private void CreatButton_Click(object sender, EventArgs e)
        {
            /*using (AddForm add = new AddForm())
            {
                add.ShowDialog();
                goods.Add(add.GetGoods());
            }
            f2.Close();
            f2 = new Form2(goods);
            f2.Show();*/

            using (AddForm add = new AddForm())
            {
                add.ShowDialog();
                f2.add(add.GetGoods());
            }





        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            Goods tmp = f2.get_selectedgood();
            if (tmp!=null)
            {
                ShowForm form = new ShowForm(tmp.get_info(), tmp.Photo);
                form.ShowDialog();

            }
            else
            {
                return;
            }
           

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            /*  Goods tmp = f2.get_selectedgood();
              int index = goods.IndexOf(tmp);
              if (tmp!=null)
              {
                  goods.Remove(tmp);
                  goods.Insert(index, f2.updateGood());
              }
              else
              {
                  return;
              }*/

            f2.updateGood();
            

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            f2.Delete();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select folder to save");
            var folder = new FolderBrowserDialog();
            List<Goods> goods = f2.GetGoods();
            if (folder.ShowDialog()==DialogResult.OK)
            {
                var path = Path.Combine(folder.SelectedPath, "goods.xml");

                using (Stream stream = File.Open(path, FileMode.Create))
                {


                    var list_serialize = new XmlSerializer(typeof(List<Goods>));

                    list_serialize.Serialize(stream, goods);
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select folder to save");
            var folder = new FolderBrowserDialog();
            List<Goods> goods = new List<Goods>();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                var path = Path.Combine(folder.SelectedPath, "goods.xml");
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var list_serialize = new XmlSerializer(typeof(List<Goods>));

                    
                    goods = (List<Goods>)list_serialize.Deserialize(stream);
                }
            }

            f2.loadGoods(goods);

        }

        private void ClearALL_Click(object sender, EventArgs e)
        {
            f2.clear();
           
        }
    }
}
