
namespace dz_5
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
            this.GoodsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GoodsBox
            // 
            this.GoodsBox.AllowDrop = true;
            this.GoodsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoodsBox.FormattingEnabled = true;
            this.GoodsBox.ItemHeight = 15;
            this.GoodsBox.Location = new System.Drawing.Point(0, 0);
            this.GoodsBox.Name = "GoodsBox";
            this.GoodsBox.Size = new System.Drawing.Size(451, 424);
            this.GoodsBox.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.GoodsBox);
            this.Name = "Form2";
            this.Text = "GoodsBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox GoodsBox;
    }
}