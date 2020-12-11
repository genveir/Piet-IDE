using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Mod : ICommand
    {
        public void Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 2)
            {
                var val1 = stack.Pop();
                var val2 = stack.Pop();

                if (val1 != 0)
                {
                    //The result has the same sign as the divisor (the top value). 
                    var mod = val2 % val1;

                    if (val1 < 0 && mod > 0) mod -= val1;
                    if (val1 > 0 && mod < 0) mod += val1;

                    stack.Push(mod);
                }
            }
        }
    }
}
