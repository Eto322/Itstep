namespace WinFormsApp6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.OilBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OilPriceLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OilPrice = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.SumTextBox = new System.Windows.Forms.TextBox();
            this.GamburgerCheckBox = new System.Windows.Forms.CheckBox();
            this.PotatoCheck = new System.Windows.Forms.CheckBox();
            this.Cola = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BurgerPrice = new System.Windows.Forms.Label();
            this.PotatoPrice = new System.Windows.Forms.Label();
            this.CocaColaPrice = new System.Windows.Forms.Label();
            this.burgerAmount = new System.Windows.Forms.TextBox();
            this.ColaAmount = new System.Windows.Forms.TextBox();
            this.PotatoAmount = new System.Windows.Forms.TextBox();
            this.AmountRadio = new System.Windows.Forms.RadioButton();
            this.SumRadio = new System.Windows.Forms.RadioButton();
            this.CafePrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Бензин";
            // 
            // OilBox
            // 
            this.OilBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OilBox.FormattingEnabled = true;
            this.OilBox.Items.AddRange(new object[] {
            "АИ-98",
            "АИ-92",
            "АИ-94"});
            this.OilBox.Location = new System.Drawing.Point(110, 46);
            this.OilBox.Name = "OilBox";
            this.OilBox.Size = new System.Drawing.Size(121, 23);
            this.OilBox.TabIndex = 1;
            this.OilBox.SelectedIndexChanged += new System.EventHandler(this.OilBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Цена";
            // 
            // OilPriceLabel
            // 
            this.OilPriceLabel.AutoSize = true;
            this.OilPriceLabel.Location = new System.Drawing.Point(110, 94);
            this.OilPriceLabel.Name = "OilPriceLabel";
            this.OilPriceLabel.Size = new System.Drawing.Size(0, 15);
            this.OilPriceLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "грн";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "До оплаты";
            // 
            // OilPrice
            // 
            this.OilPrice.AutoSize = true;
            this.OilPrice.Location = new System.Drawing.Point(39, 305);
            this.OilPrice.Name = "OilPrice";
            this.OilPrice.Size = new System.Drawing.Size(0, 15);
            this.OilPrice.TabIndex = 8;
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(136, 144);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(100, 23);
            this.AmountTextBox.TabIndex = 9;
            this.AmountTextBox.TextChanged += new System.EventHandler(this.AmountTextBox_TextChanged);
            // 
            // SumTextBox
            // 
            this.SumTextBox.Location = new System.Drawing.Point(136, 188);
            this.SumTextBox.Name = "SumTextBox";
            this.SumTextBox.Size = new System.Drawing.Size(100, 23);
            this.SumTextBox.TabIndex = 10;
            // 
            // GamburgerCheckBox
            // 
            this.GamburgerCheckBox.AutoSize = true;
            this.GamburgerCheckBox.Location = new System.Drawing.Point(462, 61);
            this.GamburgerCheckBox.Name = "GamburgerCheckBox";
            this.GamburgerCheckBox.Size = new System.Drawing.Size(64, 19);
            this.GamburgerCheckBox.TabIndex = 12;
            this.GamburgerCheckBox.Text = "бургер";
            this.GamburgerCheckBox.UseVisualStyleBackColor = true;
            // 
            // PotatoCheck
            // 
            this.PotatoCheck.AutoSize = true;
            this.PotatoCheck.Location = new System.Drawing.Point(462, 113);
            this.PotatoCheck.Name = "PotatoCheck";
            this.PotatoCheck.Size = new System.Drawing.Size(146, 19);
            this.PotatoCheck.TabIndex = 13;
            this.PotatoCheck.Text = "бесплатная картошка";
            this.PotatoCheck.UseVisualStyleBackColor = true;
            // 
            // Cola
            // 
            this.Cola.AutoSize = true;
            this.Cola.Location = new System.Drawing.Point(462, 171);
            this.Cola.Name = "Cola";
            this.Cola.Size = new System.Drawing.Size(81, 19);
            this.Cola.TabIndex = 14;
            this.Cola.Text = "кака-кола";
            this.Cola.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "До оплаты";
            // 
            // BurgerPrice
            // 
            this.BurgerPrice.AutoSize = true;
            this.BurgerPrice.Location = new System.Drawing.Point(628, 65);
            this.BurgerPrice.Name = "BurgerPrice";
            this.BurgerPrice.Size = new System.Drawing.Size(28, 15);
            this.BurgerPrice.TabIndex = 17;
            this.BurgerPrice.Text = "5.99";
            // 
            // PotatoPrice
            // 
            this.PotatoPrice.AutoSize = true;
            this.PotatoPrice.Location = new System.Drawing.Point(628, 112);
            this.PotatoPrice.Name = "PotatoPrice";
            this.PotatoPrice.Size = new System.Drawing.Size(28, 15);
            this.PotatoPrice.TabIndex = 18;
            this.PotatoPrice.Text = "2.76";
            // 
            // CocaColaPrice
            // 
            this.CocaColaPrice.AutoSize = true;
            this.CocaColaPrice.Location = new System.Drawing.Point(628, 175);
            this.CocaColaPrice.Name = "CocaColaPrice";
            this.CocaColaPrice.Size = new System.Drawing.Size(13, 15);
            this.CocaColaPrice.TabIndex = 19;
            this.CocaColaPrice.Text = "5";
            // 
            // burgerAmount
            // 
            this.burgerAmount.Location = new System.Drawing.Point(688, 65);
            this.burgerAmount.Name = "burgerAmount";
            this.burgerAmount.Size = new System.Drawing.Size(100, 23);
            this.burgerAmount.TabIndex = 20;
            // 
            // ColaAmount
            // 
            this.ColaAmount.Location = new System.Drawing.Point(688, 175);
            this.ColaAmount.Name = "ColaAmount";
            this.ColaAmount.Size = new System.Drawing.Size(100, 23);
            this.ColaAmount.TabIndex = 21;
            // 
            // PotatoAmount
            // 
            this.PotatoAmount.Location = new System.Drawing.Point(688, 113);
            this.PotatoAmount.Name = "PotatoAmount";
            this.PotatoAmount.Size = new System.Drawing.Size(100, 23);
            this.PotatoAmount.TabIndex = 22;
            // 
            // AmountRadio
            // 
            this.AmountRadio.AutoSize = true;
            this.AmountRadio.Location = new System.Drawing.Point(16, 144);
            this.AmountRadio.Name = "AmountRadio";
            this.AmountRadio.Size = new System.Drawing.Size(90, 19);
            this.AmountRadio.TabIndex = 23;
            this.AmountRadio.TabStop = true;
            this.AmountRadio.Text = "Количество";
            this.AmountRadio.UseVisualStyleBackColor = true;
            // 
            // SumRadio
            // 
            this.SumRadio.AutoSize = true;
            this.SumRadio.Location = new System.Drawing.Point(16, 188);
            this.SumRadio.Name = "SumRadio";
            this.SumRadio.Size = new System.Drawing.Size(53, 19);
            this.SumRadio.TabIndex = 24;
            this.SumRadio.TabStop = true;
            this.SumRadio.Text = "Цена";
            this.SumRadio.UseVisualStyleBackColor = true;
            // 
            // CafePrice
            // 
            this.CafePrice.AutoSize = true;
            this.CafePrice.Location = new System.Drawing.Point(526, 282);
            this.CafePrice.Name = "CafePrice";
            this.CafePrice.Size = new System.Drawing.Size(0, 15);
            this.CafePrice.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Кафе+Бензин";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(173, 406);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(0, 15);
            this.total.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Расчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CafePrice);
            this.Controls.Add(this.SumRadio);
            this.Controls.Add(this.AmountRadio);
            this.Controls.Add(this.PotatoAmount);
            this.Controls.Add(this.ColaAmount);
            this.Controls.Add(this.burgerAmount);
            this.Controls.Add(this.CocaColaPrice);
            this.Controls.Add(this.PotatoPrice);
            this.Controls.Add(this.BurgerPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cola);
            this.Controls.Add(this.PotatoCheck);
            this.Controls.Add(this.GamburgerCheckBox);
            this.Controls.Add(this.SumTextBox);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.OilPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OilPriceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OilBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox OilBox;
        private Label label2;
        private Label OilPriceLabel;
        private Label label3;
        private Label label4;
        private Label OilPrice;
        private TextBox AmountTextBox;
        private TextBox SumTextBox;
        private CheckBox GamburgerCheckBox;
        private CheckBox PotatoCheck;
        private CheckBox Cola;
        private Label label5;
        private Label BurgerPrice;
        private Label PotatoPrice;
        private Label CocaColaPrice;
        private TextBox burgerAmount;
        private TextBox ColaAmount;
        private TextBox PotatoAmount;
        private RadioButton AmountRadio;
        private RadioButton SumRadio;
        private Label CafePrice;
        private Label label6;
        private Label total;
        private Button button1;
    }
}