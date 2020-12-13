
namespace Piet_IDE
{
    partial class IOForm
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
            this.IOBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IOBox
            // 
            this.IOBox.BackColor = System.Drawing.Color.Black;
            this.IOBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOBox.ForeColor = System.Drawing.Color.White;
            this.IOBox.Location = new System.Drawing.Point(0, 0);
            this.IOBox.Multiline = true;
            this.IOBox.Name = "IOBox";
            this.IOBox.Size = new System.Drawing.Size(861, 535);
            this.IOBox.TabIndex = 0;
            this.IOBox.TextChanged += new System.EventHandler(this.IOBox_TextChanged);
            // 
            // IOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 535);
            this.Controls.Add(this.IOBox);
            this.Name = "IOForm";
            this.Text = "IOForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IOBox;
    }
}