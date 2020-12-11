using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piet_IDE
{
    public partial class Picker : Form
    {
        private MainWindow window;

        public Picker(MainWindow window)
        {
            InitializeComponent();
            InitializePalette();

            TopMost = true;
            
            this.window = window;

            PickActive(PietColor.White);
            PickAlterate(PietColor.Black);
        }

        private void InitializePalette()
        {
            this.SuspendLayout();

            int palSize = 30;

            for (int hue = 0; hue < 6; hue++)
            {
                for (int lightness = 0; lightness < 3; lightness++)
                {
                    var pickerBox = new PictureBox();
                    pickerBox.BackColor = PietColor.Colors[hue][lightness].color;
                    pickerBox.Width = palSize;
                    pickerBox.Height = palSize;
                    pickerBox.Visible = true;
                    pickerBox.Left = 10 + hue * (palSize + 5);
                    pickerBox.Top = 10 + lightness * (palSize + 5);
                    pickerBox.Tag = PietColor.Colors[hue][lightness];
                    pickerBox.MouseDown += InitColorCallback;
                    pickerBox.MouseUp += CallbackWithColor;
                    this.Controls.Add(pickerBox);
                }
            }

            var whiteBox = new PictureBox();
            whiteBox.BackColor = PietColor.White.color;
            whiteBox.Width = 3 * palSize + 10;
            whiteBox.Height = palSize;
            whiteBox.Visible = true;
            whiteBox.Left = 10;
            whiteBox.Top = 10 + 3 * (palSize + 5);
            whiteBox.Tag = PietColor.White;
            whiteBox.MouseDown += InitColorCallback;
            whiteBox.MouseUp += CallbackWithColor;
            this.Controls.Add(whiteBox);

            var blackBox = new PictureBox();
            blackBox.BackColor = PietColor.Black.color;
            blackBox.Width = 3 * palSize + 10;
            blackBox.Height = palSize;
            blackBox.Visible = true;
            blackBox.Left = 25 + 3 * palSize;
            blackBox.Top = 10 + 3 * (palSize + 5);
            blackBox.Tag = PietColor.Black;
            blackBox.MouseDown += InitColorCallback;
            blackBox.MouseUp += CallbackWithColor;
            this.Controls.Add(blackBox);

            this.ResumeLayout();
        }

        private PietColor startColor = null;
        private void InitColorCallback(object sender, MouseEventArgs e)
        {
            var pb = (PictureBox)sender;
            startColor = (PietColor)pb.Tag;
        }

        private void CallbackWithColor(object sender, MouseEventArgs e)
        {
            var pb = (PictureBox)sender;
            var color = (PietColor)pb.Tag;

            if (color == startColor)
            {
                switch(e.Button)
                {
                    case MouseButtons.Left: PickActive(color); break;
                    case MouseButtons.Right: PickAlterate(color); break;
                }
            }
        }

        private void PickActive(PietColor color)
        {
            this.mainColor.BackColor = color.color;
            window.ActiveColor = color;
        }

        private void PickAlterate(PietColor color)
        {
            this.altColor.BackColor = color.color;
            window.AltColor = color;
        }

        private void Picker_Load(object sender, EventArgs e)
        {
            var screen = Screen.FromPoint(new Point(1, 1));
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Top + 20);
        }
    }
}
