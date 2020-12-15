using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Roll : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 2)
            {
                var numberOfRolls = stack.Pop();
                var rollDepth = stack.Pop();

                stack.Roll(numberOfRolls, rollDepth);
            }

            return true;
        }
    }
}
