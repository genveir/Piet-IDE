using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor
{
    public class Codel
    {
        public List<Pixel> pixels;
        public PietColor color;

        public Codel(PietColor color)
        {
            this.pixels = new List<Pixel>();
            this.color = color;
        }

        public Codel(PietColor color, Pixel pixel) : this(color)
        {
            this.pixels.Add(pixel);
        }

        public Codel(PietColor color, IEnumerable<Pixel> pixels) :this(color)
        {
            this.pixels.AddRange(pixels);
        }

        public override string ToString()
        {
            return $"{color} size {pixels.Count}";
        }
    }
}
