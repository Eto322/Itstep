namespace WinFormsApp7
{
    partial class Form2
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
            this.WaitButtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitCodeLabelEX2 = new System.Windows.Forms.Label();
            this.Killbutton = new System.Windows.Forms.Button();
            this.CloseFormbuttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WaitButtn
            // 
            this.WaitButtn.Location = new System.Drawing.Point(49, 49);
            this.WaitButtn.Name = "WaitButtn";
            this.WaitButtn.Size = new System.Drawing.Size(191, 96);
            this.WaitButtn.TabIndex = 0;
            this.WaitButtn.Text = "start";
            this.WaitButtn.UseVisualStyleBackColor = true;
            this.WaitButtn.Click += new System.EventHandler(this.Waitbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ExitCode:";
            // 
            // ExitCodeLabelEX2
            // 
            this.ExitCodeLabelEX2.AutoSize = true;
            this.ExitCodeLabelEX2.Location = new System.Drawing.Point(202, 261);
            this.ExitCodeLabelEX2.Name = "ExitCodeLabelEX2";
            this.ExitCodeLabelEX2.Size = new System.Drawing.Size(0, 15);
            this.ExitCodeLabelEX2.TabIndex = 2;
            // 
            // Killbutton
            // 
            this.Killbutton.Location = new System.Drawing.Point(328, 49);
            this.Killbutton.Name = "Killbutton";
            this.Killbutton.Size = new System.Drawing.Size(191, 96);
            this.Killbutton.TabIndex = 3;
            this.Killbutton.Text = "Kill";
            this.Killbutton.UseVisualStyleBackColor = true;
            this.Killbutton.Click += new System.EventHandler(this.Killbutton_Click);
            // 
            // CloseFormbuttn
            // 
            this.CloseFormbuttn.Location = new System.Drawing.Point(567, 49);
            this.CloseFormbuttn.Name = "CloseFormbuttn";
            this.CloseFormbuttn.Size = new System.Drawing.Size(191, 96);
            this.CloseFormbuttn.TabIndex = 4;
            this.CloseFormbuttn.Text = "CloseForm";
            this.CloseFormbuttn.UseVisualStyleBackColor = true;
            this.CloseFormbuttn.Click += new System.EventHandler(this.CloseFormbuttn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseFormbuttn);
            this.Controls.Add(this.Killbutton);
            this.Controls.Add(this.ExitCodeLabelEX2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WaitButtn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Waitbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ExitCodeLabelEX2;
        private System.Windows.Forms.Button Killbutton;
        private System.Windows.Forms.Button WaitButtn;
        private System.Windows.Forms.Button CloseFormbuttn;
    }
}