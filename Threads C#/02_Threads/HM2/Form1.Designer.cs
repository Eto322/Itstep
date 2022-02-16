namespace HM2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ex1Box = new System.Windows.Forms.TextBox();
            this.EX1Btn = new System.Windows.Forms.Button();
            this.Ex2btn = new System.Windows.Forms.Button();
            this.Ex2Box = new System.Windows.Forms.TextBox();
            this.Min = new System.Windows.Forms.NumericUpDown();
            this.Max = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Kill1 = new System.Windows.Forms.Button();
            this.Kill2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Max)).BeginInit();
            this.SuspendLayout();
            // 
            // Ex1Box
            // 
            this.Ex1Box.AllowDrop = true;
            this.Ex1Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Ex1Box.Location = new System.Drawing.Point(471, 35);
            this.Ex1Box.Multiline = true;
            this.Ex1Box.Name = "Ex1Box";
            this.Ex1Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Ex1Box.Size = new System.Drawing.Size(295, 181);
            this.Ex1Box.TabIndex = 0;
            // 
            // EX1Btn
            // 
            this.EX1Btn.Location = new System.Drawing.Point(35, 35);
            this.EX1Btn.Name = "EX1Btn";
            this.EX1Btn.Size = new System.Drawing.Size(250, 94);
            this.EX1Btn.TabIndex = 1;
            this.EX1Btn.Text = "EX1";
            this.EX1Btn.UseVisualStyleBackColor = true;
            this.EX1Btn.Click += new System.EventHandler(this.EX1Btn_Click);
            // 
            // Ex2btn
            // 
            this.Ex2btn.Location = new System.Drawing.Point(35, 299);
            this.Ex2btn.Name = "Ex2btn";
            this.Ex2btn.Size = new System.Drawing.Size(250, 94);
            this.Ex2btn.TabIndex = 2;
            this.Ex2btn.Text = "EX2";
            this.Ex2btn.UseVisualStyleBackColor = true;
            this.Ex2btn.Click += new System.EventHandler(this.Ex2btn_Click);
            // 
            // Ex2Box
            // 
            this.Ex2Box.AllowDrop = true;
            this.Ex2Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Ex2Box.Location = new System.Drawing.Point(471, 253);
            this.Ex2Box.Multiline = true;
            this.Ex2Box.Name = "Ex2Box";
            this.Ex2Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Ex2Box.Size = new System.Drawing.Size(295, 181);
            this.Ex2Box.TabIndex = 3;
            // 
            // Min
            // 
            this.Min.Location = new System.Drawing.Point(35, 155);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(120, 20);
            this.Min.TabIndex = 5;
            // 
            // Max
            // 
            this.Max.Location = new System.Drawing.Point(185, 155);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(120, 20);
            this.Max.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Min if <2 start from 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "max if <2 end on int.MaxValue";
            // 
            // Kill1
            // 
            this.Kill1.Location = new System.Drawing.Point(44, 203);
            this.Kill1.Name = "Kill1";
            this.Kill1.Size = new System.Drawing.Size(250, 23);
            this.Kill1.TabIndex = 9;
            this.Kill1.Text = "KillEx1";
            this.Kill1.UseVisualStyleBackColor = true;
            this.Kill1.Click += new System.EventHandler(this.Kill1_Click);
            // 
            // Kill2
            // 
            this.Kill2.Location = new System.Drawing.Point(35, 411);
            this.Kill2.Name = "Kill2";
            this.Kill2.Size = new System.Drawing.Size(250, 23);
            this.Kill2.TabIndex = 10;
            this.Kill2.Text = "KillEx2";
            this.Kill2.UseVisualStyleBackColor = true;
            this.Kill2.Click += new System.EventHandler(this.Kill2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Kill2);
            this.Controls.Add(this.Kill1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Ex2Box);
            this.Controls.Add(this.Ex2btn);
            this.Controls.Add(this.EX1Btn);
            this.Controls.Add(this.Ex1Box);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Max)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Ex1Box;
        private System.Windows.Forms.Button EX1Btn;
        private System.Windows.Forms.Button Ex2btn;
        private System.Windows.Forms.TextBox Ex2Box;
        private System.Windows.Forms.NumericUpDown Min;
        private System.Windows.Forms.NumericUpDown Max;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Kill1;
        private System.Windows.Forms.Button Kill2;
    }
}

