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
        /// 表示する画像の変更度合い
        /// </summary>
        private float rate = 0;
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

        /// <summary>
        /// 描画する画像データリスト
        /// </summary>
        ImageData[] imageDatas;
        public ImageData[] ImageDatas
        {
            get { return imageDatas; }
            set
            {
                var prev = imageDatas;
                imageDatas = value;
                if (prev != value) Invalidate();
            }
        }

        /// <summary>
        /// 強制的に描画する画像データ
        /// </summary>
        Image forceImage;
        public Image ForceImage
        {
            get { return forceImage; }
            set
            {
                var prev = forceImage;
                forceImage = value;
                if (prev != value) Invalidate();
            }
        }

        /// <summary>
        /// 画像の切り替えの仕方の一覧
        /// </summary>
        public enum ImageSlideMode
        {
            Normal,
            Slide,
        }

        /// <summary>
        /// 画像の切り替えの仕方
        /// </summary>
        private ImageSlideMode slideMode = ImageSlideMode.Normal;
        public ImageSlideMode SlideMode
        {
            get { return slideMode; }
            set
            {
                var prev = slideMode;
                slideMode = value;
                if (prev != value) Invalidate();
            }
        }

        /// <summary>
        /// 画像のサイズモードの一覧
        /// </summary>
        public enum ImageSizeMode
        {
            Normal,
            Stretch,
            Center,
            Zoom,
            Fit,
        }

        /// <summary>
        /// 画像のサイズモード
        /// </summary>
        private ImageSizeMode sizeMode = ImageSizeMode.Normal;
        public ImageSizeMode SizeMode
        {
            get { return sizeMode; }
            set
            {
                var prev = sizeMode;
                sizeMode = value;
                if (sizeMode != value) Invalidate();
            }
        }

        public slideImage()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.Transparent);

            // 強制的に描画する画像がある場合
            if (ForceImage != null)
            {
                g.DrawImageUnscaled(ForceImage, getImageDrawRect(ForceImage, 0, 0));
            }

            // 画像データが無かったらリターン
            if (imageDatas == null) return;

            // 描画する画像を選択
            int no1 = (int)rate;
            int no2 = (int)rate + 1;

            // 描画
            if (slideMode == ImageSlideMode.Normal)         // 通常切り替え
            {
                
            }

        }
        
        Rectangle getImageDrawRect(Image image, int x, int y)
        {
            if (sizeMode == ImageSizeMode.Normal)           // 通常
            {
                return new Rectangle(x, y, image.Width, image.Height);
            }
            else if (sizeMode == ImageSizeMode.Stretch)     // ストレッチ
            {
                return new Rectangle(x, y, Width, Height);
            }
            else if (sizeMode == ImageSizeMode.Center)      // センター
            {
                var px = (Width - image.Width) >> 1;
                var py = (Height - image.Height) >> 1;
                return new Rectangle(px, py, image.Width, image.Height);
            }
            else if (sizeMode == ImageSizeMode.Zoom)        // ズーム
            {
                float imgR = image.Width / (float)image.Height;
                float ctrR = Width / (float)Height;

                if (imgR > ctrR)
                {

                }
                else if (imgR < ctrR)
                {

                }
                else
                {
                    return new Rectangle(0, 0, Width, Height);
                }
            }
            else                                            // フィット
            {
                return new Rectangle();
            }
            return new Rectangle(x, y, image.Width, image.Height);
        }


    }
}
