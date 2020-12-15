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
    public partial class NewForm : Form
    {
        Action<int, int> callback;

        private static NewForm _instance;
        public static NewForm GetOrCreate(Action<int, int> callback)
        {
            if (_instance == null) _instance = new NewForm(callback);
            _instance.callback = callback;

            return _instance;
        }

        private NewForm(Action<int, int> callback)
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int width, height;
            int.TryParse(widthBox.Text.Trim(), out width);
            int.TryParse(heightBox.Text.Trim(), out height);

            if (width < 1) width = 1;
            if (height < 1) height = 1;

            callback(width, height);

            this.Hide();
        }
    }
}
