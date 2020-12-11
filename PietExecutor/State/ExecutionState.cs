using System;
using System.Collections.Generic;
using System.Text;

namespace PietExecutor.State
{
    public struct ExecutionState
    {
        public DirectionPointer DirectionPointer { get; }

        public CodelChooser CodelChooser { get; }

        public Nullable<Codel> CurrentCodel { get; }

        public PietColor LastColor { get; }

        public List<int> Stack { get; }
    }
}
