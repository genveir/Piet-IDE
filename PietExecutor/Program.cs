using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace PietExecutor
{
    public class Program
    {
        private Pixel[][] pixels;

        internal Program(Pixel[][] pixels)
        {
            this.pixels = pixels;

            ResolveCodels();
        }

        public Program(string fileName)
        {
            var bitMap = new Bitmap(Image.FromFile(fileName));

            var bytes = GetBytes(bitMap);

            int pointer = 0;
            pixels = new Pixel[bitMap.Height][];
            for (int y = 0; y < bitMap.Height; y++)
            {
                pixels[y] = new Pixel[bitMap.Width];
                for (int x = 0; x < bitMap.Width; x++)
                {
                    var color = PietColor.FromBytes(bytes, pointer);
                    pixels[y][x] = new Pixel(x, y, color);
                    pointer += 4;
                }
            }

            ResolveCodels();
        }

        private void ResolveCodels() 
        { 
            for (int y = 0; y < pixels.Length; y++)
            {
                for (int x = 0; x < pixels[y].Length; x++)
                {
                    if (pixels[y][x].codel == null)
                    {
                        var pixel = pixels[y][x];
                        var codel = new Codel(pixel.color);
                        ResolveCodel(pixel, codel);
                    }
                }
            }
        }

        private void ResolveCodel(Pixel pixel, Codel codel)
        {
            if (pixel.codel == null)
            {
                if (pixel.color != codel.color) return;

                pixel.codel = codel;
                codel.AddPixel(pixel);

                // white and black pixels are their own codels
                if (pixel.color == PietColor.White) return;
                if (pixel.color == PietColor.Black) return;

                var y = pixel.y;
                var x = pixel.x;

                if (y != 0) ResolveCodel(pixels[y - 1][x], codel);
                if (y != pixels.Length - 1) ResolveCodel(pixels[y + 1][x], codel);
                if (x != 0) ResolveCodel(pixels[y][x - 1], codel);
                if (x != pixels[y].Length - 1) ResolveCodel(pixels[y][x + 1], codel);
            }
        }

        private byte[] GetBytes(Bitmap bitmap)
        {
            var readRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var readBits = bitmap.LockBits(readRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] bmpValues = new byte[readBits.Stride * readBits.Height];
            Marshal.Copy(readBits.Scan0, bmpValues, 0, bmpValues.Length);

            bitmap.UnlockBits(readBits);

            return bmpValues;
        }

        static Pixel BorderPixel = new Pixel(-1, -1, PietColor.Black);
        public Pixel GetPixel(int x, int y)
        {
            if (x < 0 || x > pixels[0].Length - 1 ||
                y < 0 || y > pixels.Length - 1 ||
                pixels[y][x] == null) return BorderPixel;

            else return pixels[y][x];
        }
    }
}
