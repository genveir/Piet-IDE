﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor
{
    public class Pixel
    {
        public PietColor color;
        public int x;
        public int y;

        public Codel codel;

        public Pixel(int x, int y, PietColor color)
        {
            this.color = color;
            this.x = x;
            this.y = y;

            this.codel = null;
        }

        public override string ToString()
        {
            return $"({x}, {y}) {color}";
        }
    }
}
