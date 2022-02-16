
namespace WinFormsApp2
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
            this.Ex1 = new System.Windows.Forms.Button();
            this.Ex2 = new System.Windows.Forms.Button();
            this.Ex3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ex1
            // 
            this.Ex1.BackColor = System.Drawing.Color.White;
            this.Ex1.Location = new System.Drawing.Point(2, 12);
            this.Ex1.Name = "Ex1";
            this.Ex1.Size = new System.Drawing.Size(786, 89);
            this.Ex1.TabIndex = 0;
            this.Ex1.Text = "Ex1";
            this.Ex1.UseVisualStyleBackColor = false;
            this.Ex1.Click += new System.EventHandler(this.Ex1_Click);
            // 
            // Ex2
            // 
            this.Ex2.BackColor = System.Drawing.Color.White;
            this.Ex2.Location = new System.Drawing.Point(2, 186);
            this.Ex2.Name = "Ex2";
            this.Ex2.Size = new System.Drawing.Size(786, 89);
            this.Ex2.TabIndex = 1;
            this.Ex2.Text = "Ex2";
            this.Ex2.UseVisualStyleBackColor = false;
            this.Ex2.Click += new System.EventHandler(this.Ex2_Click);
            // 
            // Ex3
            // 
            this.Ex3.BackColor = System.Drawing.Color.White;
            this.Ex3.Location = new System.Drawing.Point(2, 359);
            this.Ex3.Name = "Ex3";
            this.Ex3.Size = new System.Drawing.Size(786, 89);
            this.Ex3.TabIndex = 2;
            this.Ex3.Text = "Ex3";
            this.Ex3.UseVisualStyleBackColor = false;
            this.Ex3.Click += new System.EventHandler(this.Ex3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ex3);
            this.Controls.Add(this.Ex2);
            this.Controls.Add(this.Ex1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ex1;
        private System.Windows.Forms.Button Ex2;
        private System.Windows.Forms.Button Ex3;
    }
}

