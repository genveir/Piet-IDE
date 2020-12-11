using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class OutNumber : ICommand
    {
        public void Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 1)
            {
                state.IO.WriteNum(stack.Pop());
            }
        }
    }
}
