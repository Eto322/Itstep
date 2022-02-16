
namespace asdddd
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
            this.StartButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.Ex1Bar = new System.Windows.Forms.ProgressBar();
            this.MinUp = new System.Windows.Forms.NumericUpDown();
            this.MaxUp = new System.Windows.Forms.NumericUpDown();
            this.StepUp = new System.Windows.Forms.NumericUpDown();
            this.MinLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.PathBoxLabel = new System.Windows.Forms.Label();
            this.Ex1Label = new System.Windows.Forms.Label();
            this.ProgressBarValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StartButtonEX2 = new System.Windows.Forms.Button();
            this.progressBarEX2 = new System.Windows.Forms.ProgressBar();
            this.Ex2RichBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MinUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepUp)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(53, 311);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(253, 56);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(65, 404);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(227, 58);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Ex1Bar
            // 
            this.Ex1Bar.Location = new System.Drawing.Point(53, 248);
            this.Ex1Bar.Name = "Ex1Bar";
            this.Ex1Bar.Size = new System.Drawing.Size(258, 23);
            this.Ex1Bar.TabIndex = 2;
            // 
            // MinUp
            // 
            this.MinUp.Location = new System.Drawing.Point(19, 140);
            this.MinUp.Name = "MinUp";
            this.MinUp.Size = new System.Drawing.Size(120, 23);
            this.MinUp.TabIndex = 3;
            this.MinUp.ValueChanged += new System.EventHandler(this.MinUp_ValueChanged);
            // 
            // MaxUp
            // 
            this.MaxUp.Location = new System.Drawing.Point(229, 140);
            this.MaxUp.Name = "MaxUp";
            this.MaxUp.Size = new System.Drawing.Size(120, 23);
            this.MaxUp.TabIndex = 4;
            this.MaxUp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MaxUp.ValueChanged += new System.EventHandler(this.MaxUp_ValueChanged);
            // 
            // StepUp
            // 
            this.StepUp.Location = new System.Drawing.Point(127, 84);
            this.StepUp.Name = "StepUp";
            this.StepUp.Size = new System.Drawing.Size(120, 23);
            this.StepUp.TabIndex = 5;
            this.StepUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StepUp.ValueChanged += new System.EventHandler(this.StepUp_ValueChanged);
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinLabel.Location = new System.Drawing.Point(19, 110);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(49, 30);
            this.MinLabel.TabIndex = 6;
            this.MinLabel.Text = "Min";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(510, 332);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(0, 15);
            this.CountLabel.TabIndex = 7;
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxLabel.Location = new System.Drawing.Point(229, 110);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(53, 30);
            this.MaxLabel.TabIndex = 7;
            this.MaxLabel.Text = "Max";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StepLabel.Location = new System.Drawing.Point(127, 54);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(53, 30);
            this.StepLabel.TabIndex = 8;
            this.StepLabel.Text = "Step";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(615, 517);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(277, 23);
            this.PathBox.TabIndex = 9;
            // 
            // PathBoxLabel
            // 
            this.PathBoxLabel.AutoSize = true;
            this.PathBoxLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PathBoxLabel.Location = new System.Drawing.Point(711, 493);
            this.PathBoxLabel.Name = "PathBoxLabel";
            this.PathBoxLabel.Size = new System.Drawing.Size(65, 21);
            this.PathBoxLabel.TabIndex = 10;
            this.PathBoxLabel.Text = "PathBox";
            // 
            // Ex1Label
            // 
            this.Ex1Label.AutoSize = true;
            this.Ex1Label.Location = new System.Drawing.Point(155, 39);
            this.Ex1Label.Name = "Ex1Label";
            this.Ex1Label.Size = new System.Drawing.Size(25, 15);
            this.Ex1Label.TabIndex = 11;
            this.Ex1Label.Text = "Ex1";
            // 
            // ProgressBarValue
            // 
            this.ProgressBarValue.AutoSize = true;
            this.ProgressBarValue.Location = new System.Drawing.Point(155, 284);
            this.ProgressBarValue.Name = "ProgressBarValue";
            this.ProgressBarValue.Size = new System.Drawing.Size(13, 15);
            this.ProgressBarValue.TabIndex = 12;
            this.ProgressBarValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ex2";
            // 
            // StartButtonEX2
            // 
            this.StartButtonEX2.Location = new System.Drawing.Point(629, 434);
            this.StartButtonEX2.Name = "StartButtonEX2";
            this.StartButtonEX2.Size = new System.Drawing.Size(253, 56);
            this.StartButtonEX2.TabIndex = 14;
            this.StartButtonEX2.Text = "Start";
            this.StartButtonEX2.UseVisualStyleBackColor = true;
            this.StartButtonEX2.Click += new System.EventHandler(this.StartButtonEX2_Click);
            // 
            // progressBarEX2
            // 
            this.progressBarEX2.Location = new System.Drawing.Point(629, 399);
            this.progressBarEX2.Name = "progressBarEX2";
            this.progressBarEX2.Size = new System.Drawing.Size(258, 23);
            this.progressBarEX2.TabIndex = 15;
            // 
            // richTextBox1
            // 
            this.Ex2RichBox.Location = new System.Drawing.Point(605, 94);
            this.Ex2RichBox.Name = "richTextBox1";
            this.Ex2RichBox.Size = new System.Drawing.Size(341, 242);
            this.Ex2RichBox.TabIndex = 16;
            this.Ex2RichBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 600);
            this.Controls.Add(this.Ex2RichBox);
            this.Controls.Add(this.progressBarEX2);
            this.Controls.Add(this.StartButtonEX2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBarValue);
            this.Controls.Add(this.Ex1Label);
            this.Controls.Add(this.PathBoxLabel);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.StepUp);
            this.Controls.Add(this.MaxUp);
            this.Controls.Add(this.MinUp);
            this.Controls.Add(this.Ex1Bar);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MinUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ProgressBar Ex1Bar;
        private System.Windows.Forms.NumericUpDown MinUp;
        private System.Windows.Forms.NumericUpDown MaxUp;
        private System.Windows.Forms.NumericUpDown StepUp;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label PathBoxLabel;
        private System.Windows.Forms.Label Ex1Label;
        private System.Windows.Forms.Label ProgressBarValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartButtonEX2;
        private System.Windows.Forms.ProgressBar progressBarEX2;
        private System.Windows.Forms.RichTextBox Ex2RichBox;
    }
}

