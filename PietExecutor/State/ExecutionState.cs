using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor.State
{
    public class ExecutionState
    {
        public ExecutionState(Codel topLeftCodel)
        {
            DirectionPointer = new DirectionPointer();
            CodelChooser = new CodelChooser();
            CurrentCodel = topLeftCodel;
            LastColor = PietColor.White;
            CurrentValue = 0;
            Stack = new RollingStack();
            IO = new ConsoleWrapper();
        }

        public DirectionPointer DirectionPointer { get; }

        public CodelChooser CodelChooser { get; }

        public Codel CurrentCodel { get; set; }

        public PietColor LastColor { get; set; }

        public int CurrentValue { get; set; }

        public RollingStack Stack { get; }

        public IOWrapper IO { get; }
    }
}
