using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Not : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 1)
            {
                stack.Push(stack.Pop() == 0 ? 1 : 0);
            }

            return true;
        }
    }
}
