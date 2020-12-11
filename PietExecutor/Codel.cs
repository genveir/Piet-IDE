using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PietExecutor
{
    public class Codel
    {
        private List<Pixel> pixels;
        
        private (int x, int y)[] ExitsFromCodel;

        private int?[] DPCheckVals;
        private int?[][] CCCheckVals;

        public int Size => pixels.Count;
        public PietColor Color { get; }

        public Codel(PietColor color)
        {
            this.pixels = new List<Pixel>();
            this.Color = color;

            this.DPCheckVals = new int?[4];
            this.CCCheckVals = new int?[4][];
            for (int n = 0; n < 4; n++) CCCheckVals[n] = new int?[2];

            this.ExitsFromCodel = new (int x, int y)[8];
        }

        public Codel(PietColor color, Pixel pixel) : this(color)
        {
            AddPixel(pixel);
        }

        public Codel(PietColor color, IEnumerable<Pixel> pixels) :this(color)
        {
            foreach (var pixel in pixels) AddPixel(pixel);
        }

        public void AddPixel(Pixel pixel)
        {
            this.pixels.Add(pixel);

            var x = pixel.x;
            var y = pixel.y;

            if (IsOuterMostForDP(DirectionPointer.DP_RIGHT, x, v => x >= v)) 
            {
                if (CheckOuterMostForDPCC(DirectionPointer.DP_RIGHT, CodelChooser.CC_LEFT, y, v => v >= y)) 
                    SetExit(DirectionPointer.DP_RIGHT, CodelChooser.CC_LEFT, (x + 1, y));
                if (CheckOuterMostForDPCC(DirectionPointer.DP_RIGHT, CodelChooser.CC_RIGHT, y, v => v <= y)) 
                    SetExit(DirectionPointer.DP_RIGHT, CodelChooser.CC_RIGHT, (x + 1, y));
            }
            if (IsOuterMostForDP(DirectionPointer.DP_LEFT, x, v => x <= v)) 
            {
                if (CheckOuterMostForDPCC(DirectionPointer.DP_LEFT, CodelChooser.CC_LEFT, y, v => v <= y))
                    SetExit(DirectionPointer.DP_LEFT, CodelChooser.CC_LEFT, (x - 1, y));
                if (CheckOuterMostForDPCC(DirectionPointer.DP_LEFT, CodelChooser.CC_RIGHT, y, v => v >= y))
                    SetExit(DirectionPointer.DP_LEFT, CodelChooser.CC_RIGHT, (x - 1, y));
            }
            if (IsOuterMostForDP(DirectionPointer.DP_DOWN, y, v => y >= v)) 
            {
                if (CheckOuterMostForDPCC(DirectionPointer.DP_DOWN, CodelChooser.CC_LEFT, x, v => v <= x))
                    SetExit(DirectionPointer.DP_DOWN, CodelChooser.CC_LEFT, (x, y + 1));
                if (CheckOuterMostForDPCC(DirectionPointer.DP_DOWN, CodelChooser.CC_RIGHT, x, v => v >= x))
                    SetExit(DirectionPointer.DP_DOWN, CodelChooser.CC_RIGHT, (x, y + 1));
            }
            if (IsOuterMostForDP(DirectionPointer.DP_UP, y, v => y <= v)) 
            {
                if (CheckOuterMostForDPCC(DirectionPointer.DP_UP, CodelChooser.CC_LEFT, x, v => v >= x))
                    SetExit(DirectionPointer.DP_UP, CodelChooser.CC_LEFT, (x, y - 1));
                if (CheckOuterMostForDPCC(DirectionPointer.DP_UP, CodelChooser.CC_RIGHT, x, v => v <= x))
                    SetExit(DirectionPointer.DP_UP, CodelChooser.CC_RIGHT, (x, y - 1));
            }
        }

        private bool IsOuterMostForDP(int DP, int val, Func<int, bool> comparison)
        {
            if (DPCheckVals[DP] == null || comparison(DPCheckVals[DP].Value))
            {
                if (DPCheckVals[DP] != val)
                {
                    CCCheckVals[DP][0] = null;
                    CCCheckVals[DP][1] = null;
                }

                DPCheckVals[DP] = val;
                return true;
            }
            return false;
        }

        private bool CheckOuterMostForDPCC(int DP, int CC, int val, Func<int, bool> comparison)
        {
            if (CCCheckVals[DP][CC] == null || comparison(CCCheckVals[DP][CC].Value))
            {
                CCCheckVals[DP][CC] = val;
                return true;
            }

            return false;
        }

        private void SetExit(int DP, int CC, (int x, int y) exit)
        {
            ExitsFromCodel[2 * DP + CC] = exit;
        }

        public override string ToString()
        {
            return $"{Color} size {pixels.Count}";
        }

        public (int x, int y) GetExitPixel(DirectionPointer DP, CodelChooser CC)
        {
            return ExitsFromCodel[DP.currentValue * 2 + CC.currentValue];
        }
    }
}
