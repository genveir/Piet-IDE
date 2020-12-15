using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Nop : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            return true;
        }
    }
}
