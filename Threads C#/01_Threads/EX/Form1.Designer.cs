namespace WinFormsApp7
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
            this.EX1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitCodeLabel = new System.Windows.Forms.Label();
            this.EX2 = new System.Windows.Forms.Button();
            this.EX3 = new System.Windows.Forms.Button();
            this.signBox = new System.Windows.Forms.ComboBox();
            this.FirstNumber = new System.Windows.Forms.NumericUpDown();
            this.SecondNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // EX1
            // 
            this.EX1.Location = new System.Drawing.Point(95, 45);
            this.EX1.Name = "EX1";
            this.EX1.Size = new System.Drawing.Size(125, 63);
            this.EX1.TabIndex = 0;
            this.EX1.Text = "Ex1";
            this.EX1.UseVisualStyleBackColor = true;
            this.EX1.Click += new System.EventHandler(this.EX1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ExitCode";
            // 
            // ExitCodeLabel
            // 
            this.ExitCodeLabel.AutoSize = true;
            this.ExitCodeLabel.Location = new System.Drawing.Point(432, 69);
            this.ExitCodeLabel.Name = "ExitCodeLabel";
            this.ExitCodeLabel.Size = new System.Drawing.Size(0, 15);
            this.ExitCodeLabel.TabIndex = 2;
            // 
            // EX2
            // 
            this.EX2.Location = new System.Drawing.Point(95, 165);
            this.EX2.Name = "EX2";
            this.EX2.Size = new System.Drawing.Size(125, 55);
            this.EX2.TabIndex = 3;
            this.EX2.Text = "Ex2";
            this.EX2.UseVisualStyleBackColor = true;
            this.EX2.Click += new System.EventHandler(this.EX2_Click);
            // 
            // EX3
            // 
            this.EX3.Location = new System.Drawing.Point(95, 284);
            this.EX3.Name = "EX3";
            this.EX3.Size = new System.Drawing.Size(125, 55);
            this.EX3.TabIndex = 4;
            this.EX3.Text = "Ex3";
            this.EX3.UseVisualStyleBackColor = true;
            this.EX3.Click += new System.EventHandler(this.EX3_Click);
            // 
            // signBox
            // 
            this.signBox.FormattingEnabled = true;
            this.signBox.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.signBox.Location = new System.Drawing.Point(472, 301);
            this.signBox.Name = "signBox";
            this.signBox.Size = new System.Drawing.Size(121, 23);
            this.signBox.TabIndex = 7;
            this.signBox.Text = "-";
            // 
            // FirstNumber
            // 
            this.FirstNumber.DecimalPlaces = 1;
            this.FirstNumber.Location = new System.Drawing.Point(346, 301);
            this.FirstNumber.Name = "FirstNumber";
            this.FirstNumber.Size = new System.Drawing.Size(120, 23);
            this.FirstNumber.TabIndex = 8;
            // 
            // SecondNumber
            // 
            this.SecondNumber.DecimalPlaces = 1;
            this.SecondNumber.Location = new System.Drawing.Point(599, 302);
            this.SecondNumber.Name = "SecondNumber";
            this.SecondNumber.Size = new System.Drawing.Size(120, 23);
            this.SecondNumber.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SecondNumber);
            this.Controls.Add(this.FirstNumber);
            this.Controls.Add(this.signBox);
            this.Controls.Add(this.EX3);
            this.Controls.Add(this.EX2);
            this.Controls.Add(this.ExitCodeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EX1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FirstNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ExitCodeLabel;
        private System.Windows.Forms.Button EX2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EX3;
        private System.Windows.Forms.ComboBox signBox;
        private System.Windows.Forms.NumericUpDown FirstNumber;
        private System.Windows.Forms.NumericUpDown SecondNumber;
    }
}
