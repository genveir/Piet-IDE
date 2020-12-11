using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Divide : ICommand
    {
        public void Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 2)
            {
                var val1 = stack.Pop();
                var val2 = stack.Pop();

                if (val1 != 0) stack.Push(val2 / val1);
            }
        }
    }
}
