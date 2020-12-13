using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.State
{
    public class RollingStack
    {
        private int[] data;
        private int cursor;

        public RollingStack()
        {
            this.data = new int[128];
            this.cursor = -1;
        }

        public void Push(int value)
        {
            cursor++;
            if (cursor == data.Length)
            {
                var buffer = data;
                data = new int[data.Length * 2];
                Array.Copy(buffer, data, buffer.Length);
            }

            data[cursor] = value;
        }

        public int Pop()
        {
            return data[cursor--];
        }

        public void Roll(int numberOfRolls, int rollDepth)
        {
            // A single roll to depth n is defined as burying the top value on the stack n deep and bringing all values above it up by 1 place.
            // A negative number of rolls rolls in the opposite direction. A negative depth is an error and the command is ignored.

            if (rollDepth <= 0) return;
            if (numberOfRolls < 0)
            {
                numberOfRolls = rollDepth + 1 + numberOfRolls;
            }
            
            var indexAtDepth = cursor - rollDepth;

            if (indexAtDepth < 0) return;

            for (int n = 0; n < numberOfRolls; n++)
            {
                int buffer = data[cursor];
                for (int r = 0; r < rollDepth; r++)
                {
                    data[cursor - r] = data[cursor - r - 1];
                }
                data[indexAtDepth] = buffer;
            }  
        }

        public int Count => cursor  + 1;
    }
}
