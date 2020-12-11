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

            if (rollDepth < 0) return;
        }

        public int Count => cursor;
    }
}
