using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Push : ICommand
    {
        public void Execute(ExecutionState state)
        {
            state.Stack.Push(state.CurrentValue);
        }
    }
}
