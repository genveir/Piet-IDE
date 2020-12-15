using PietExecutor.IO;
using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piet_IDE
{
    public partial class IOForm : Form, IOWrapper
    {
        public IOForm()
        {
            InitializeComponent();

            typedChars = new Queue<char>();
        }

        Queue<char> typedChars;

        public bool HasRead()
        {
            return typedChars.Count > 0;
        }

        public char Read()
        {
            if (typedChars.Count == 0) return (char)0;

            return typedChars.Dequeue();
        }

        bool ChangeIsOutput = false;

        public void WriteChar(char toWrite)
        {
            ChangeIsOutput = true;
            IOBox.Text += toWrite;
            ChangeIsOutput = false;
        }

        public void WriteNum(int toWrite)
        {
            ChangeIsOutput = true;
            IOBox.Text += toWrite;
            ChangeIsOutput = false;
        }

        private void IOBox_TextChanged(object sender, EventArgs e)
        {
            if (!ChangeIsOutput)
            {
                ;
            }
        }
    }
}
