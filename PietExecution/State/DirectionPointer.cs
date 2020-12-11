using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecution.State
{
    public class DirectionPointer
    {
        public const int DP_RIGHT = 0;
        public const int DP_DOWN = 1;
        public const int DP_LEFT = 2;
        public const int DP_UP = 3;

        private int currentValue;

        public DirectionPointer()
        {
            currentValue = DP_RIGHT;
        }

        public void Cycle()
        {
            currentValue = (currentValue + 1) % 4;
        }

        public override string ToString()
        {
            switch(currentValue)
            {
                case DP_RIGHT: return "right";
                case DP_DOWN: return "down";
                case DP_LEFT: return "left";
                case DP_UP: return "up";
            }

            return "invalid";
        }
    }
}
