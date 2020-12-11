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
        private Codel[] codels;

        public Program(string fileName)  
        {
            var bitMap = new Bitmap(Image.FromFile(fileName));

            var bytes = GetBytes(bitMap);

            ;
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
    }
}
