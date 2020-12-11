using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class InNumber : ICommand
    {
        public void Execute(ExecutionState state)
        {
            var stack = state.Stack;

            var read = state.IO.Read().ToString();

            int num;
            if (int.TryParse(read, out num))
            {
                stack.Push(num);
            }
        }
    }
}
