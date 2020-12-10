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
    public partial class FileManager : Form
    {
        private MainWindow window;

        public FileManager(MainWindow window)
        {
            InitializeComponent();

            this.window = window;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            window.LoadState();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            window.SaveState();
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            var screen = Screen.FromPoint(new Point(-1, 1));
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Top);
        }
    }
}
