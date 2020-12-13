using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piet_IDE
{
    public class EventRaisingStack : IRollingStack
    {
        IRollingStack innerStack;

        public event EventHandler Popped;
        public event EventHandler Pushed;
        public event EventHandler Rolled;

        public EventRaisingStack(IRollingStack innerStack)
        {
            this.innerStack = innerStack;
        }

        public int Count => innerStack.Count;

        public int Pop()
        {
            var value = innerStack.Pop();

            Popped?.Invoke(this, new EventArgs());

            return value;
        }

        public void Push(int value)
        {
            innerStack.Push(value);

            Pushed?.Invoke(this, new EventArgs());
        }

        public void Roll(int numberOfRolls, int rollDepth)
        {
            innerStack.Roll(numberOfRolls, rollDepth);

            Rolled?.Invoke(this, new EventArgs());
        }
    }
}
