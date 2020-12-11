using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Pointer : ICommand
    {
        public void Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 1)
            {
                var toCycle = stack.Pop();

                toCycle = toCycle % 4;
                toCycle += 4;
                toCycle = toCycle % 4;

                for (int n = 0; n < toCycle; n++) state.DirectionPointer.Cycle();
            }
        }
    }
}
