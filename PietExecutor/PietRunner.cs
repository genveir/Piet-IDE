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

        internal PietRunner(Program program, ExecutionState state)
        {
            this.program = program;
            
            if (state == null) state = new ExecutionState(program.GetPixel(0, 0).codel);
            this.state = state;
        }
        public PietRunner(Program program) : this(program, null) { }

        public bool ExecuteStep()
        {
            var currentCodel = this.state.CurrentCodel;

            this.state.LastColor = currentCodel.color;

            return FindExit(0);
        }

        private bool FindExit(int attempts)
        {
            if (attempts == 4) return false;

            var DP = this.state.DirectionPointer;
            var CC = this.state.CodelChooser;

            var currentCodel = this.state.CurrentCodel;

            var exitPixel = currentCodel.GetExitPixel(DP, CC);

            var proposedNextPixel = program.GetPixel(exitPixel.x, exitPixel.y);
            if (proposedNextPixel.color == PietColor.Black)
            {
                CC.Cycle();
                exitPixel = currentCodel.GetExitPixel(DP, CC);
                proposedNextPixel = program.GetPixel(exitPixel.x, exitPixel.y);

                if (proposedNextPixel.color == PietColor.Black)
                {
                    DP.Cycle();
                    return FindExit(attempts + 1);
                }
            }

            this.state.CurrentCodel = proposedNextPixel.codel;
            return true;
        }
    }
}
