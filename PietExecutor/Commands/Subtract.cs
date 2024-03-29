﻿using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    class Subtract : ICommand
    {
        public bool Execute(ExecutionState state)
        {
            var stack = state.Stack;

            if (stack.Count >= 2)
            {
                var val1 = stack.Pop();
                var val2 = stack.Pop();
                stack.Push(val2 - val1);
            }

            return true;
        }
    }
}
