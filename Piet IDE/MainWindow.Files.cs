using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piet_IDE
{
    partial class MainWindow
    {
        private void SaveStateHandler(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"d:\temp\piet";
            saveDialog.Filter = "Bitmap|*.bmp";
            saveDialog.FileOk += SaveDialog_FileOk;
            saveDialog.ShowDialog();
        }
        private void SaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            var saveDialog = (SaveFileDialog)sender;
            SaveState(saveDialog.FileName);
        }

        private void LoadStateHandler(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = @"d:\temp\piet";
            openDialog.FileOk += Dialog_FileOk;
            openDialog.ShowDialog();
        }
        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            LoadState(dialog.FileName);

            this.Invalidate();
        }

        private void LoadState(string fileName)
        {
            drawingState = DrawingState.Load(fileName);
        }

        private void SaveState(string fileName)
        {
            drawingState.Save(fileName);
        }
    }
}
