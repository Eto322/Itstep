namespace WinFormsApp6
{
    public partial class Form1 : Form
    {

        public double oilAmount { get; set; } = 0;
        public double cafeAmount { get; set; } = 0;
        public double totalAmount { get; set; }
        public double _BurgerPrice = 5.99;
       public  double _PotatoPrice = 2.76;
       public double _ColaPrice = 5;


        private double[] priceOil = {12.40, 30.21, 21.00};

        public Form1()
        {
            InitializeComponent();

            this.Load+= FormLoad;

        }

        private void FormLoad(object sender, EventArgs e)
        {
            OilBox.SelectedIndex = 0;
            OilPriceLabel.Text = priceOil[0].ToString();

            AmountRadio.CheckedChanged += RadioButtonchanged;
            SumRadio.CheckedChanged += RadioButtonchanged;

            AmountTextBox.KeyPress += onlynumber;
            SumTextBox.KeyPress+=onlynumber;
            burgerAmount.KeyPress += onlynumber;
            PotatoAmount.KeyPress+=onlynumber;
            ColaAmount.KeyPress+=onlynumber;


            AmountTextBox.TextChanged += oilCount;
            SumTextBox.TextChanged += oilCount;

            GamburgerCheckBox.CheckedChanged += burgerChekBoxChanged;
            PotatoCheck.CheckedChanged += PotatocheckBoxChanged;
            Cola.CheckedChanged += ColaCheckBoxchanged;

            burgerAmount.ReadOnly = true;
            PotatoAmount.ReadOnly=true;
            ColaAmount.ReadOnly=true;

            burgerAmount.TextChanged += BurgerAmount_TextChanged;
            PotatoAmount.TextChanged += PotatoAmount_TextChanged;
            ColaAmount.TextChanged += ColaAmount_TextChanged;


        }

        private void ColaAmount_TextChanged(object? sender, EventArgs e)
        {
            TextBox text =sender as TextBox;

            if (text.Text!="")
            {
                cafeAmount += _ColaPrice * double.Parse(text.Text);
                CafePrice.Text = cafeAmount.ToString();
            }
        }

        private void PotatoAmount_TextChanged(object? sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text != "")
            {

                cafeAmount += _PotatoPrice * double.Parse(text.Text);
                CafePrice.Text = cafeAmount.ToString();
            }
        }

        private void BurgerAmount_TextChanged(object? sender, EventArgs e)
        {
           TextBox text=sender as  TextBox;

           if (text.Text!="")
           {
              
               cafeAmount += _BurgerPrice * double.Parse(text.Text);
               CafePrice.Text = cafeAmount.ToString();
           }
        }

        private void OilBox_SelectedIndexChanged(object sender, EventArgs e)
        {

           OilPriceLabel.Text=priceOil[OilBox.SelectedIndex].ToString();
        }

        private void RadioButtonchanged(object sender, EventArgs e)
        {
            if (AmountRadio.Checked)
            {
                SumTextBox.ReadOnly=true;
                AmountTextBox.ReadOnly = false;
                OilPrice.Text = "0.00";
            }

            if (SumRadio.Checked)
            {
                SumTextBox.ReadOnly = false;
                AmountTextBox.ReadOnly = true;
                OilPrice.Text = "0.00";
            }
            
        }

        private void onlynumber(object sender, KeyPressEventArgs e)
        {
           

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void oilCount(object sender, EventArgs e)
        {
            TextBox text=sender as TextBox;

            if (AmountRadio.Checked)
            {
                oilAmount = 0;
                if (text.Text=="")
                {
                    OilPrice.Text = "0.00";

                }
                else
                {
                    oilAmount = priceOil[OilBox.SelectedIndex] * double.Parse(text.Text);
                    OilPrice.Text = oilAmount.ToString() + " uah";
                }
                
                
            }

            if (SumRadio.Checked)
            {
                oilAmount = 0;
                if (text.Text=="")
                {
                    OilPrice.Text = "0.00";
                }
                else
                {
                    oilAmount = double.Parse(text.Text);
                    var tmp = oilAmount / priceOil[OilBox.SelectedIndex];
                    OilPrice.Text = tmp.ToString() + " L";

                }

            }

        }

        private void burgerChekBoxChanged(object sender, EventArgs e)
        {
            if (GamburgerCheckBox.Checked)
            {
                burgerAmount.ReadOnly = false;
                burgerAmount.Focus();
            }
            else
            {
                cafeAmount -= (double.Parse(burgerAmount.Text) * _BurgerPrice);
                burgerAmount.ReadOnly = true;
                CafePrice.Text = cafeAmount.ToString();
            }
        }

        private void PotatocheckBoxChanged(object sender, EventArgs e)
        {
            if (PotatoCheck.Checked)
            {
                PotatoAmount.ReadOnly = false;
                PotatoAmount.Focus();
            }
            else
            {
                cafeAmount -= (double.Parse(ColaAmount.Text) * _PotatoPrice);
                PotatoAmount.ReadOnly = true;
                CafePrice.Text = cafeAmount.ToString();
            }
        }

        private void ColaCheckBoxchanged(object sender, EventArgs e)
        {
            if (Cola.Checked)
            {
                ColaAmount.ReadOnly = false;
                ColaAmount.Focus();
            }
            else
            {
                cafeAmount -= (double.Parse(ColaAmount.Text) * _ColaPrice);
                ColaAmount.ReadOnly = true;
                CafePrice.Text = cafeAmount.ToString();
            }
        }
        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            var sum = oilAmount + cafeAmount;
            total.Text = sum.ToString();
        }
    }
}