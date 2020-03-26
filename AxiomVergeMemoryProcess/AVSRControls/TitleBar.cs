using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVSRControls
{
    public partial class TitleBar : UserControl
    {

        private bool mouseDown { get; set; }
        private Point lastLocation;

        public TitleBar()
        {
            InitializeComponent();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void MinimizeMenuItem_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void TitleBarMenu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitleBarMenu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TitleBarMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.ParentForm.Location = new Point(
                    (this.ParentForm.Location.X - lastLocation.X) + e.X, (this.ParentForm.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.ParentForm.Location = new Point(
                    (this.ParentForm.Location.X - lastLocation.X) + e.X, (this.ParentForm.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void TitleBar_Load(object sender, EventArgs e)
        {
            string s = ParentForm.Text;
            titleLabel.Text = s;
        }
    }
}
