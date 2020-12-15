using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Switch : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 1)
            {
                var toCycle = state.Stack.Pop();

                toCycle = toCycle % 2;
                toCycle += 2;
                toCycle = toCycle % 2;

                for (int n = 0; n < toCycle; n++) state.CodelChooser.Cycle();
            }

            return true;
        }
    }
}
