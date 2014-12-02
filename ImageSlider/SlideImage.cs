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
                //var prev = imageDatas;
                imageDatas = value;
                //if (prev != value) Invalidate();
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
            Slide_Right,
            Slide_Left,
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

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(BackColor);
            g.SetClip(new Rectangle(0, 0, Width, Height));

            // 強制的に描画する画像がある場合
            if (ForceImage != null)
            {
                g.DrawImage(ForceImage, getImageDrawRect(ForceImage, 0, 0));
                return;
            }

            // 画像データが無かったらリターン
            if (imageDatas == null) return;

            // 描画する画像を選択
            int no1 = (int)rate;
            int no2 = (int)rate + 1;

            // 描画
            if (slideMode == ImageSlideMode.Normal)                 // 通常切り替え
            {
                if (no1 < 0 || no1 >= imageDatas.Length) return;
                var image = imageDatas[no1].Bitmap;
                g.DrawImage(image, getImageDrawRect(image, 0, 0));
            }
            else if (slideMode == ImageSlideMode.Slide_Right)       // 右にスライド
            {
                float r = rate - no1;
                if (no1 >= 0 && no1 < imageDatas.Length)
                {
                    var image1 = imageDatas[no1].Bitmap;
                    int px1 = (int)(Width * r);
                    g.SetClip(new Rectangle(px1, 0, Width, Height));
                    g.DrawImage(image1, getImageDrawRect(image1, px1, 0));

                    if (no2 == imageDatas.Length) no2 = 0;
                    var image2 = imageDatas[no2].Bitmap;
                    var px2 = px1 - Width;
                    g.SetClip(new Rectangle(px2, 0, Width, Height));
                    g.DrawImage(image2, getImageDrawRect(image2, px2, 0));
                }
            }
            else if (slideMode == ImageSlideMode.Slide_Left)       // 左にスライド
            {
                float r = rate - no1;
                if (no1 >= 0 && no1 < imageDatas.Length)
                {
                    var image1 = imageDatas[no1].Bitmap;
                    int px1 = -(int)(Width * r);
                    g.SetClip(new Rectangle(px1, 0, Width, Height));
                    g.DrawImage(image1, getImageDrawRect(image1, px1, 0));

                    if (no2 == imageDatas.Length) no2 = 0;
                    var image2 = imageDatas[no2].Bitmap;
                    var px2 = px1 + Width;
                    g.SetClip(new Rectangle(px2, 0, Width, Height));
                    g.DrawImage(image2, getImageDrawRect(image2, px2, 0));
                }
            }
        }
        
        /// <summary>
        /// 画像の描画領域を取得する
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
                return new Rectangle(x + px, y + py, image.Width, image.Height);
            }
            else if (sizeMode == ImageSizeMode.Zoom)        // ズーム
            {
                float imgR = image.Width / (float)image.Height;
                float ctrR = Width / (float)Height;

                if (imgR > ctrR)
                {
                    var wr = Width / (float)image.Width;
                    var h = image.Height * wr;
                    return new Rectangle(x, y + ((Height - (int)h) >> 1), Width, (int)h);
                }
                else if (imgR < ctrR)
                {
                    var hr = Height / (float)image.Height;
                    var w = image.Width * hr;
                    return new Rectangle(x + ((Width - (int)w) >> 1), y, (int)w, Height);
                }
                else
                {
                    return new Rectangle(0, 0, Width, Height);
                }
            }
            else                                            // フィット
            {
                float imgR = image.Width / (float)image.Height;
                float ctrR = Width / (float)Height;

                if (imgR > ctrR)
                {
                    if (image.Width < Width)
                    {
                        var px = (Width - image.Width) >> 1;
                        var py = (Height - image.Height) >> 1;
                        return new Rectangle(x + px, y + py, image.Width, image.Height);
                    }
                    var wr = Width / (float)image.Width;
                    var h = image.Height * wr;
                    return new Rectangle(x, y + ((Height - (int)h) >> 1), Width, (int)h);
                }
                else if (imgR < ctrR)
                {
                    if (image.Height < Height)
                    {
                        var px = (Width - image.Width) >> 1;
                        var py = (Height - image.Height) >> 1;
                        return new Rectangle(x + px, y + py, image.Width, image.Height);
                    }
                    var hr = Height / (float)image.Height;
                    var w = image.Width * hr;
                    return new Rectangle(x + ((Width - (int)w) >> 1), y, (int)w, Height);
                }
                else
                {
                    return new Rectangle(0, 0, Width, Height);
                }
            }
        }


    }
}
