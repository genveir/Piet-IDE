﻿using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    interface ICommand
    {
        void Execute(ExecutionState state);
    }
}
