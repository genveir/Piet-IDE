using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor
{
    public class PietColor
    {
        private static Dictionary<int, PietColor> argbPietColors;

        public static PietColor[][] Colors;
        public static PietColor White;
        public static PietColor Black;

        public static PietColor LightRed, Red, DarkRed;
        public static PietColor LightYellow, Yellow, DarkYellow;
        public static PietColor LightGreen, Green, DarkGreen;
        public static PietColor LightCyan, Cyan, DarkCyan;
        public static PietColor LightBlue, Blue, DarkBlue;
        public static PietColor LightMagenta, Magenta, DarkMagenta;

        static PietColor()
        {
            Colors = new PietColor[6][];
            Colors[0] = new PietColor[]
            {
                new PietColor("light red", 0, 2, Color.FromArgb(255, 192, 192)),
                new PietColor("red", 0, 1, Color.FromArgb(255, 0, 0))  ,
                new PietColor("dark red", 0, 0, Color.FromArgb(192, 0, 0))
            }; // red
            Colors[1] = new PietColor[]
            {
                new PietColor("light yellow", 5, 2, Color.FromArgb(255, 255, 192)),
                new PietColor("yellow", 5, 1, Color.FromArgb(255, 255, 0)),
                new PietColor("dark yellow", 5, 0, Color.FromArgb(192, 192, 0))
            }; // yellow
            Colors[2] = new PietColor[]
            {
                new PietColor("light green", 1, 2, Color.FromArgb(192, 255, 192)),
                new PietColor("green", 1, 1, Color.FromArgb(0, 255, 0))  ,
                new PietColor("dark green", 1, 0, Color.FromArgb(0, 192, 0))
            }; // green
            Colors[3] = new PietColor[]
            {
                new PietColor("light cyan", 2, 2, Color.FromArgb(192, 255, 255)),
                new PietColor("cyan", 2, 1, Color.FromArgb(0, 255, 255)),
                new PietColor("dark cyan", 2, 0, Color.FromArgb(0, 192, 192))
            }; // cyan
            Colors[4] = new PietColor[]
            {
                new PietColor("light blue", 3, 2, Color.FromArgb(192, 192, 255)),
                new PietColor("blue", 3, 1, Color.FromArgb(0, 0, 255))  ,
                new PietColor("dark blue", 3, 0, Color.FromArgb(0, 0, 192))
            }; // blue
            Colors[5] = new PietColor[]
            {
                new PietColor("light magenta", 4, 2, Color.FromArgb(255, 192, 255)),
                new PietColor("magenta", 4, 1, Color.FromArgb(255, 0, 255)),
                new PietColor("dark magenta", 4, 0, Color.FromArgb(192, 0, 192))
            };  // magenta

            White = new PietColor("white", -100, 100, Color.White);
            Black = new PietColor("black", -100, -100, Color.Black);

            argbPietColors = new Dictionary<int, PietColor>();
            for (int hue = 0; hue < 6; hue++)
            {
                for (int lightness = 0; lightness < 3; lightness++)
                {
                    var color = Colors[hue][lightness];
                    argbPietColors.Add(color.color.ToArgb(), color);
                }
            }
            argbPietColors.Add(White.color.ToArgb(), White);
            argbPietColors.Add(Black.color.ToArgb(), Black);

            LightRed = Colors[0][0];
            Red = Colors[0][1];
            DarkRed = Colors[0][2];

            LightYellow = Colors[1][0];
            Yellow = Colors[1][1];
            DarkYellow = Colors[1][2];

            LightGreen = Colors[2][0];
            Green = Colors[2][1];
            DarkGreen = Colors[2][2];

            LightCyan = Colors[3][0];
            Cyan = Colors[3][1];
            DarkCyan = Colors[3][2];

            LightBlue = Colors[4][0];
            Blue = Colors[4][1];
            DarkBlue = Colors[4][2];

            LightMagenta = Colors[5][0];
            Magenta = Colors[5][1];
            DarkMagenta = Colors[5][2];
        }

        public static PietColor FromColor(Color color)
        {
            return FromArgb(color.ToArgb());
        }

        public static PietColor FromBytes(byte[] argbBytes, int startIndex)
        {
            return FromArgb(BitConverter.ToInt32(argbBytes, startIndex));
        }

        public static PietColor FromArgb(int argb)
        {
            PietColor result;
            argbPietColors.TryGetValue(argb, out result);

            // In the simplest case, non-standard colours are treated by the language interpreter 
            // as the same as white, so may be used freely wherever white is used.
            if (result == null) result = PietColor.White;

            return result;
        }

        public string name;

        public Color color;

        private int hue;
        private int lightness;

        private PietColor(string name, int hue, int lightness, Color color)
        {
            this.name = name;
            this.hue = hue;
            this.lightness = lightness;
            this.color = color;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
