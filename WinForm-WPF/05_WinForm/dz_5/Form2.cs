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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        public Form2(List<Goods> goods)
        {
            InitializeComponent();
            foreach (var item in goods)
            {
                GoodsBox.Items.Add(item);
            }
         



          
        }

        public Goods get_selectedgood()
        {
            if (GoodsBox.SelectedItem==null)
            {
                MessageBox.Show("Select item First");
                return null;
            }
            Goods tmp = GoodsBox.SelectedItem as Goods;

            return tmp;
            

           
        }

        public void add(Goods tmp)
        {
            GoodsBox.Items.Add(tmp);

        }
        public void updateGood()
        {
            if (GoodsBox.SelectedItem == null)
            {
                MessageBox.Show("Select item First");
                return;
            }

            Goods tmp = GoodsBox.SelectedItem as Goods;
            int index = GoodsBox.SelectedIndex;
            GoodsBox.Items.RemoveAt(GoodsBox.SelectedIndex);
            using (AddForm add = new AddForm(tmp))
            {
                add.ShowDialog();
                GoodsBox.Items.Insert(index, add.GetGoods());
            }

            


        }

        public void Delete()
        {
            if (GoodsBox.SelectedItem == null)
            {
                MessageBox.Show("Select item First");
                return;
            }
            GoodsBox.Items.RemoveAt(GoodsBox.SelectedIndex);
            

        }

        public List<Goods> GetGoods()
        {
            var goods = new List<Goods>();
            foreach (var item in GoodsBox.Items)
            {
                goods.Add(item as Goods);
            }
            return goods;
        }

        public void loadGoods(List<Goods> tmp)
        {
            foreach(var item in  tmp)
            {
                GoodsBox.Items.Add(item);
            }
        }
        public void clear()
        {
            GoodsBox.Items.Clear();
        }


       
    }
}
