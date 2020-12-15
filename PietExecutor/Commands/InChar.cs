using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class InChar : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            if (!state.IO.HasRead()) return false;

            var stack = state.Stack;

            char read = state.IO.Read();

            stack.Push(read);

            return true;
        }
    }
}
