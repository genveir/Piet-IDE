using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Duplicate : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 1)
            {
                var val = stack.Pop();
                
                stack.Push(val);
                stack.Push(val);
            }

            return true;
        }
    }
}
