using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor
{
    public struct Pixel
    {
        public PietColor color;
        public int x;
        public int y;

        public Pixel(int x, int y, PietColor color)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }
    }
}
