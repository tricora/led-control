using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedControl.basics;

namespace LedControl.device
{
    public partial class FormDevice : Form, ILedDevice
    {
        private int ledWidth = 1;
        private int gapWidth = 1;

        public FormDevice(int LedWidth, int GapWidth)
        {
            ledWidth = LedWidth;
            gapWidth = GapWidth;
            InitializeComponent();
        }

        public FormDevice()
        {
            InitializeComponent();
        }

        public ColorCorrection ColorCorrection
        {
            get; set;
        }

        public int LedCount
        {
            get;
        }

        public void Open()
        {
            Show();
        }

        void ILedDevice.Close()
        {
            Hide();
        }

        private basics.Color[] ledColors;

        public void Show(basics.Color[] colors)
        {
            if (!this.Visible)
            {
                return;
            }
            ledColors = colors;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;
            Rectangle rc = ClientRectangle;

            gfx.FillRectangle(new SolidBrush(System.Drawing.Color.Black), rc);

            if (ledColors == null)
            {
                return;
            }
            float stripWidth = (float)(rc.Width - 2) / (ledColors.Length * ledWidth);
            for (int i = 0; i < ledColors.Length; i++)
            {
                basics.Color c = ledColors[i];
                if (c == basics.Color.OFF)
                {
                    continue;
                }
                //gfx.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(255, c.R, c.G, c.B)), stripWidth * (i * ledWidth ) + 1, 1f, stripWidth * ledWidth - 2, rc.Height - 2);
                
                for (int j = 0; j < ledWidth; j++)
                {
                    //gfx.FillEllipse(new SolidBrush(System.Drawing.Color.FromArgb(255, c.R, c.G, c.B)), stripWidth * (i*3 + j) + 1, 1f, stripWidth-gapWidth, stripWidth-1);
                    gfx.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(255, c.R, c.G, c.B)), stripWidth * (i * ledWidth + j) + 1, 1f, stripWidth - gapWidth, rc.Height - 2);
                }

            }
        }

        public bool IsOpen()
        {
            return this.Visible;
        }
    }
}
