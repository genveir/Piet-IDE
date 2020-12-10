using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Piet_IDE
{
    public class DrawingState
    {
        private Bitmap[] canvasses;
        public int xCenter = 0;
        public int yCenter = 0;
        
        private int zoomLevel = 0;
        private int[] zoomsPerZoomLevel = new int[] { 1, 2, 4, 8, 16, 32 };
        private int zoomFactor => zoomsPerZoomLevel[zoomLevel];

        public enum ZoomDirection { None, In, Out }

        public static DrawingState Load(string path)
        {
            var fromFile = new Bitmap(Image.FromFile(path));

            return new DrawingState(fromFile);
        }

        private void SetAllLevels(Bitmap level0)
        {
            canvasses = new Bitmap[zoomsPerZoomLevel.Length];

            canvasses[0] = level0;

            var bmpValues = GetBytes(level0);

            for (int level = 1; level < canvasses.Length; level++)
            {
                var zoomFac = zoomsPerZoomLevel[level];

                canvasses[level] = new Bitmap(level0.Width * zoomFac, level0.Height * zoomFac);

                var writeRect = new Rectangle(0, 0, canvasses[level].Width, canvasses[level].Height);
                var writeBits = canvasses[level].LockBits(writeRect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                IntPtr writeBytesPtr = writeBits.Scan0;
                int readBytesPtr = 0;

                var lineBytes = new byte[writeBits.Stride];
                for (int line = 0; line < level0.Height; line++)
                {
                    int linePtr = 0;
                    for (int pixel = 0; pixel < level0.Width; pixel++)
                    {
                        for (int zf = 0; zf < zoomFac; zf++)
                        {
                            Array.Copy(bmpValues, readBytesPtr, lineBytes, linePtr, 4);
                            linePtr+=4;
                        }
                        readBytesPtr+=4;
                    }

                    for (int zf = 0; zf < zoomFac; zf++)
                    {
                        Marshal.Copy(lineBytes, 0, writeBytesPtr, lineBytes.Length);
                        writeBytesPtr += lineBytes.Length;
                    }
                }

                canvasses[level].UnlockBits(writeBits);
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

        private DrawingState(Bitmap level0)
        {
            SetAllLevels(level0);
        }

        public DrawingState(int width, int height)
        {
            var level0 = new Bitmap(width, height);

            using (var g = Graphics.FromImage(level0))
            {
                g.FillRectangle(new SolidBrush(PietColor.White.color), 0, 0, width, height);
            }

            SetAllLevels(level0);
        }

        public void Zoom(ZoomDirection direction)
        {
            var oldZoomLevel = zoomLevel;

            if (direction == ZoomDirection.In)
            {
                zoomLevel++;
                if (zoomLevel > zoomsPerZoomLevel.Length - 1) zoomLevel = zoomsPerZoomLevel.Length - 1;

                if (zoomLevel != oldZoomLevel)
                {
                    xCenter *= 2;
                    yCenter *= 2;
                }
            }
            else
            {
                zoomLevel--;
                if (zoomLevel < 0) zoomLevel = 0;

                if (zoomLevel != oldZoomLevel)
                {
                    xCenter /= 2;
                    yCenter /= 2;
                }
            }
        }

        public Bitmap GetWorkingCanvas()
        {
            return canvasses[zoomLevel];
        }

        public void SetPixel(int dsPixelX, int dsPixelY, Color color)
        {
            var basePixelX = dsPixelX / zoomFactor;
            var basePixelY = dsPixelY / zoomFactor;

            if (basePixelX < 0 || basePixelX >= canvasses[0].Width ||
                basePixelY < 0 || basePixelY >= canvasses[0].Height) return;

            var currentZoomLevel = zoomLevel;

            for (zoomLevel = 0; zoomLevel < zoomsPerZoomLevel.Length; zoomLevel++)
            {
                var leftStart = basePixelX * zoomFactor;
                var topStart = basePixelY * zoomFactor;

                for (int dX = 0; dX < zoomFactor; dX++)
                {
                    for (int dY = 0; dY < zoomFactor; dY++)
                    {
                        canvasses[zoomLevel].SetPixel(leftStart + dX, topStart + dY, color);
                    }
                }
            }

            zoomLevel = currentZoomLevel;
        }

        public void Save(string path)
        {
            canvasses[0].Save(path);
        }
    }
}
