using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piet_IDE
{
    public class PietColor
    {
        public static PietColor[][] Colors;
        public static PietColor White;
        public static PietColor Black;

        static PietColor()
        {
            Colors = new PietColor[6][];
            Colors[0] = new PietColor[] { new PietColor(0, 2, Color.FromArgb(255, 192, 192)), new PietColor(0, 1, Color.FromArgb(255, 0, 0))  , new PietColor(0, 0, Color.FromArgb(192, 0, 0)) }; // red
            Colors[2] = new PietColor[] { new PietColor(1, 2, Color.FromArgb(192, 255, 192)), new PietColor(1, 1, Color.FromArgb(0, 255, 0))  , new PietColor(1, 0, Color.FromArgb(0, 192, 0)) }; // green
            Colors[3] = new PietColor[] { new PietColor(2, 2, Color.FromArgb(192, 255, 255)), new PietColor(2, 1, Color.FromArgb(0, 255, 255)), new PietColor(2, 0, Color.FromArgb(0, 192, 192)) }; // cyan
            Colors[4] = new PietColor[] { new PietColor(3, 2, Color.FromArgb(192, 192, 255)), new PietColor(3, 1, Color.FromArgb(0, 0, 255))  , new PietColor(3, 0, Color.FromArgb(0, 0, 192)) }; // blue
            Colors[5] = new PietColor[] { new PietColor(4, 2, Color.FromArgb(255, 192, 255)), new PietColor(4, 1, Color.FromArgb(255, 0, 255)), new PietColor(4, 0, Color.FromArgb(192, 0, 192)) };  // magenta
            Colors[1] = new PietColor[] { new PietColor(5, 2, Color.FromArgb(255, 255, 192)), new PietColor(5, 1, Color.FromArgb(255, 255, 0)), new PietColor(5, 0, Color.FromArgb(192, 192, 0)) }; // yellow

            White = new PietColor(-100, 100, Color.White);
            Black = new PietColor(-100, -100, Color.Black);
        }

        public Color color;

        private int hue;
        private int lightness;

        private PietColor(int hue, int lightness, Color color)
        {
            this.hue = hue;
            this.lightness = lightness;
            this.color = color;
        }
    }
}
