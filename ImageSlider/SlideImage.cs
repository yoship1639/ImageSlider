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
    public partial class slideImage : UserControl
    {
        /// <summary>
        /// 表示する画像の位置のレート
        /// </summary>
        private float rate;
        public float Rate
        {
            get { return rate; }
            set
            {
                var prev = rate;
                rate = value;
                if (prev != rate) Invalidate();
            }
        }

        public List<ImageData> ImageDatas { get; set; }
        public Image ForceImage { get; set; }

        public slideImage()
        {
            InitializeComponent();

            Rate = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.Transparent);

            // 強制的に描画する画像がある場合
            if (ForceImage != null)
            {
               
            }

            // サイズ合わせ処理
            int no1 = (int)rate;
            int no2 = (int)rate + 1;


            if (no1 < 0 || no1 >= ImageDatas.Count)
            {
                
            }
        }
    }
}
