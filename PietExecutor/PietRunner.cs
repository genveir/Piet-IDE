using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor
{
    public class PietRunner
    {
        private Program program;
        private ExecutionState state;

        public PietRunner(Program program)
        {
            this.program = program;
            this.state = new ExecutionState(program.pixels[0][0].codel);
        }

        public void ExecuteStep()
        {
            
        }
    }
}
