
namespace Piet_IDE
{
    partial class Picker
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
            this.altColor = new System.Windows.Forms.PictureBox();
            this.mainColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.altColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainColor)).BeginInit();
            this.SuspendLayout();
            // 
            // altColor
            // 
            this.altColor.Location = new System.Drawing.Point(36, 280);
            this.altColor.Name = "altColor";
            this.altColor.Size = new System.Drawing.Size(159, 116);
            this.altColor.TabIndex = 0;
            this.altColor.TabStop = false;
            // 
            // mainColor
            // 
            this.mainColor.Location = new System.Drawing.Point(36, 158);
            this.mainColor.Name = "mainColor";
            this.mainColor.Size = new System.Drawing.Size(159, 116);
            this.mainColor.TabIndex = 1;
            this.mainColor.TabStop = false;
            // 
            // Picker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 406);
            this.ControlBox = false;
            this.Controls.Add(this.mainColor);
            this.Controls.Add(this.altColor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Picker";
            this.ShowInTaskbar = false;
            this.Text = "Picker";
            this.Load += new System.EventHandler(this.Picker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.altColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox altColor;
        private System.Windows.Forms.PictureBox mainColor;
    }
}