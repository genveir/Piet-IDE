using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Greater : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 2)
            {
                stack.Push(stack.Pop() < stack.Pop() ? 1 : 0);
            }

            return true;
        }
    }
}
