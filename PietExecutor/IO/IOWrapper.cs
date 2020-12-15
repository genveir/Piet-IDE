using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.IO
{
    public interface IOWrapper
    {
        bool HasRead();

        char Read();

        void WriteChar(char toWrite);

        void WriteNum(int toWrite);
    }
}
