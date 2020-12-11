using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecution.State
{
    public class CodelChooser
    {
        public const int CC_LEFT = 0;
        public const int CC_RIGHT = 1;

        private int currentValue;
        public CodelChooser()
        {
            currentValue = CC_LEFT;
        }

        public void Cycle()
        {
            currentValue = 1 - currentValue;
        }

        public override string ToString()
        {
            switch(currentValue)
            {
                case CC_LEFT: return "left";
                case CC_RIGHT: return "right";
            }

            return "invalid";
        }
    }
}
