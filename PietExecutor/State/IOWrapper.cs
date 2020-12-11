using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.State
{
    public interface IOWrapper
    {
        char Read();

        void WriteChar(char toWrite);

        void WriteNum(int toWrite);
    }

    public class ConsoleWrapper : IOWrapper
    {
        public char Read()
        {
            return (char)Console.Read();
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
