﻿using PietExecutor.Commands;
using PietExecutor.IO;
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

        // useful for tests
        internal PietRunner(Program program, ExecutionState state)
        {
            this.program = program;
            this.state = state;
        }

        public PietRunner(Program program) : this(program, new ConsoleWrapper(), new RollingStack(), new Configuration()) { }

        public PietRunner(Program program, IOWrapper io, IRollingStack stack, Configuration config = null)
        {
            this.program = program;
            this.state = new ExecutionState(program.GetPixel(0, 0).codel, io, stack);

            if (config == null) config = new Configuration();
            Configuration.Current = config;
        }

        public void Run()
        {
            while (ExecuteStep()) { }
        }

        public bool ExecuteStep()
        {
            var currentCodel = this.state.CurrentCodel;

            bool willContinue;

            var command = ResolveCommand();
            if (command.Execute(state))
            {
                this.state.LastColor = currentCodel.Color;
                this.state.CurrentValue = currentCodel.Size;

                willContinue = FindExit(0);
            }
            else willContinue = false;

            return willContinue;
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

        private ICommand ResolveCommand()
        {
            if (state.LastColor == PietColor.White || state.CurrentCodel.Color == PietColor.White) return new Nop();

            var hueDifference = (state.CurrentCodel.Color.hue - state.LastColor.hue + 6) % 6;
            var lightnessDifference = (state.CurrentCodel.Color.lightness - state.LastColor.lightness + 3) % 3;

            return Command.GetCommand(hueDifference, lightnessDifference);
        }
    }
}
