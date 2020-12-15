using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor
{
    public class Configuration
    {
        public static Configuration Current;

        public bool Use1BasedStackRolling { get; set; } = false;
    }
}
