using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.IO
{
    class InputFileIODecorator : IOWrapper
    {
        private char[] fileContents;
        private int contentPointer = -1;
        private string fileName;

        private IOWrapper innerWrapper;

        public InputFileIODecorator(string fileName, IOWrapper innerWrapper)
        {
            this.fileName = fileName;

            this.innerWrapper = innerWrapper;
        }

        private void ReadFile()
        {
            using (var reader = new StreamReader(fileName))
            {
                var file = reader.ReadToEnd();

                fileContents = file.ToCharArray();
            }

            contentPointer = 0;
        }

        public bool HasRead()
        {
            if (contentPointer == -1) ReadFile();

            if (contentPointer == fileContents.Length) return innerWrapper.HasRead();
            else return true;
        }

        public char Read()
        {
            if (contentPointer == -1) ReadFile();

            char result;
            if (contentPointer == fileContents.Length) result = innerWrapper.Read();
            else
            {
                result = fileContents[contentPointer];
                contentPointer++;
            }

            return result;
        }

        public void WriteChar(char toWrite)
        {
            innerWrapper.WriteChar(toWrite);
        }

        public void WriteNum(int toWrite)
        {
            innerWrapper.WriteNum(toWrite);
        }
    }
}
