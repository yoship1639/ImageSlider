using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSlider
{
    public partial class SizeChanger : UserControl
    {
        public SizeChanger()
        {
            InitializeComponent();
        }

        private void SizeChanger_Load(object sender, EventArgs e)
        {
            SetBounds(Left, Top, Width, Height, BoundsSpecified.Size);
            Point[] points =
            {
                new Point(Width, 0),
                new Point(Width, Height),
                new Point(0, Height),
            };
            byte[] types =
            {
                (byte)System.Drawing.Drawing2D.PathPointType.Line,
                (byte)System.Drawing.Drawing2D.PathPointType.Line,
                (byte)System.Drawing.Drawing2D.PathPointType.Line,
            };

            var path = new System.Drawing.Drawing2D.GraphicsPath(points, types);

            Region = new Region(path);
        }
    }
}
