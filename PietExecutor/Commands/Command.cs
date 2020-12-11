using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Commands
{
    static class Command
    {
        static ICommand[][] commands;

        static Command()
        {
            commands = new ICommand[6][];
            commands[0] = new ICommand[] { new Nop(), new Push(), new Pop() };
            commands[1] = new ICommand[] { new Add(), new Subtract(), new Multiply() };
            commands[2] = new ICommand[] { new Divide(), new Mod(), new Not() };
            commands[3] = new ICommand[] { new Greater(), new Pointer(), new Switch() };
            commands[4] = new ICommand[] { new Duplicate(), new Roll(), new InNumber() };
            commands[5] = new ICommand[] { new InChar(), new OutNumber(), new OutChar() };
        }

        public static ICommand GetCommand(int hueDifference, int lightnessDifference)
        {
            return commands[hueDifference][lightnessDifference];
        }
    }
}
