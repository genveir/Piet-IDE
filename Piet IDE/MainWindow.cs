using PietExecutor;
using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piet_IDE
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            DoubleBuffered = true;

            InitializeComponent();

            var scr = Screen.FromPoint(this.Location);

            new Picker(this).Show();

            ActiveColor = PietColor.White;

            this.MouseWheel += MainWindow_MouseWheel;
            this.MouseDown += MainWindow_MouseDown;
            this.MouseUp += MainWindow_MouseUp;
        }

        private PietColor _altColor;
        public PietColor AltColor
        {
            get { return _altColor; }
            set
            {
                _altColor = value;
            }
        }

        private PietColor _activeColor;
        public PietColor ActiveColor
        {
            get { return _activeColor; }
            set
            {
                _activeColor = value;
            }
        }

        private DrawingState drawingState;

        private void MainWindow_Shown(object sender, System.EventArgs e)
        {
            img = new Bitmap(this.Width, this.Height);

            NewImage(10, 10);
        }

        Bitmap img;
        private void MainWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(img))
            {
                g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, img.Width, img.Height);

                (var top, var left, var bottom, var right, var dsWidth, var dsHeight) = GetImageBounds();

                // mebbe do something so you can't scroll all of the image out of bounds

                g.DrawImage(drawingState.GetWorkingCanvas(), left, top, dsWidth, dsHeight);
            }

            e.Graphics.DrawImage(img, 0, 0);
        }

        private (int top, int left, int bottom, int right, int width, int height) GetImageBounds() 
        {
            int xCenter = img.Width / 2;
            int yCenter = img.Height / 2;

            var dsWidth = drawingState.GetWorkingCanvas().Width;
            var dsHeight = drawingState.GetWorkingCanvas().Height;

            var left = xCenter - (dsWidth) / 2 - drawingState.xCenter;
            var top = yCenter - (dsHeight) / 2 - drawingState.yCenter;
            var right = xCenter + (dsWidth) / 2 - drawingState.xCenter;
            var bottom = yCenter + (dsHeight) / 2 - drawingState.yCenter;

            return (top, left, bottom, right, dsWidth, dsHeight);
        }

        private void MainWindow_MouseWheel(object sender, MouseEventArgs e)
        {
            DrawingState.ZoomDirection zoomDirection = DrawingState.ZoomDirection.None;

            if (e.Delta > 0) zoomDirection = DrawingState.ZoomDirection.In;
            if (e.Delta < 0) zoomDirection = DrawingState.ZoomDirection.Out;

            drawingState.Zoom(zoomDirection);

            this.Invalidate();
        }

        private Point _mdPos;
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            _mdPos = e.Location;
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            var clickPos = e.Location;

            var dragDistance = Math.Abs(clickPos.X - _mdPos.X) + Math.Abs(clickPos.Y - _mdPos.Y);

            if (dragDistance < 10)
            {
                var dsWidth = drawingState.GetWorkingCanvas().Width;
                var dsHeight = drawingState.GetWorkingCanvas().Height;

                var dsTop = this.Height / 2 - dsHeight / 2;
                var dsLeft = this.Width / 2 - dsWidth / 2;

                var dsPixelX = (clickPos.X - dsLeft);
                var dsPixelY = (clickPos.Y - dsTop);

                Color color = Color.White;
                switch (e.Button)
                {
                    case MouseButtons.Left: color = ActiveColor.color; break;
                    case MouseButtons.Right: color = AltColor.color; break;
                }

                drawingState.SetPixel(dsPixelX, dsPixelY, color);
            }
            else
            {
                var xDiff = _mdPos.X - e.Location.X;
                var yDiff = _mdPos.Y - e.Location.Y;

                drawingState.xCenter += xDiff;
                drawingState.yCenter += yDiff;
            }

            this.Invalidate();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            img = new Bitmap(this.Width, this.Height);
            this.Invalidate();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveState(@".\lastExecuted.bmp");

            var stack = new EventRaisingStack(new RollingStack());
            var io = new IOForm();
            io.Show();

            var program = new PietExecutor.Program(@".\lastExecuted.bmp");

            var executor = new PietRunner(program, io, stack);

            executor.Run();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm.GetOrCreate(NewImage).Show();
        }

        private void NewImage(int width, int height)
        {
            drawingState = new DrawingState(width, height);

            this.Invalidate();
        }
    }
}
