using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageSearchAPILib;

namespace ImageSlider
{
    public partial class SlideImage : UserControl
    {
        public float Rate { get; set; }
        public List<ImageData> ImageDatas { get; set; }

        public SlideImage()
        {
            InitializeComponent();

            Rate = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.Transparent);


        }
    }
}
