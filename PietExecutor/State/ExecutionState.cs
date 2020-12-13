using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor.State
{
    public class ExecutionState
    {
        public ExecutionState(Codel topLeftCodel, IOWrapper io = null, IRollingStack stack = null)
        {
            DirectionPointer = new DirectionPointer();
            CodelChooser = new CodelChooser();
            CurrentCodel = topLeftCodel;
            LastColor = PietColor.White;
            CurrentValue = 0;
            Stack = stack ?? new RollingStack();
            IO = io ?? new ConsoleWrapper();
        }

        public DirectionPointer DirectionPointer { get; }

        public CodelChooser CodelChooser { get; }

        public Codel CurrentCodel { get; set; }

        public PietColor LastColor { get; set; }

        public int CurrentValue { get; set; }

        public IRollingStack Stack { get; }

        public IOWrapper IO { get; }
    }
}
