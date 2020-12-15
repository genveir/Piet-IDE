using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.IO
{
    public class ConsoleWrapper : IOWrapper
    {
        // -2 = not set, -1 is nothing to read
        int peek = -2;
        public bool HasRead()
        {
            if (peek == -2) peek = Console.Read();

            return peek != -1;
        }

        public char Read()
        {
            HasRead();

            if (peek < 0) peek = 0; // chars cant be negative, lets be explicit on what we return
            var result = (char)peek;
            peek = -2;

            return result;
        }

        public void WriteChar(char toWrite)
        {
            Console.Write((char)toWrite);
        }

        public void WriteNum(int toWrite)
        {
            Console.Write(toWrite.ToString());
        }
    }
}
