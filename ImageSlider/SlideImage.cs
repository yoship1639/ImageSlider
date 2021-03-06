﻿using System;
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
            Normal = 0,
            Slide_Right = 1,
            Slide_Left = 2,
            Alpha = 3,
            FrontAndSide = 4,
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
            Normal = 0,
            Stretch = 1,
            Center = 2,
            Zoom = 3,
            Fit = 4,
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
                if (prev != value) Invalidate();
            }
        }

        private bool focusDownloadImage = false;
        public bool FocusDownloadImage
        {
            get { return focusDownloadImage; }
            set
            {
                var prev = focusDownloadImage;
                focusDownloadImage = value;
                if (prev != value) Invalidate();
            }
        }

        public SlideImage()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        public void Repaint()
        {
            Invalidate();
        }

        // カラーマトリックス
        System.Drawing.Imaging.ColorMatrix cm = new System.Drawing.Imaging.ColorMatrix();
        // イメージ属性
        System.Drawing.Imaging.ImageAttributes ia = new System.Drawing.Imaging.ImageAttributes();

        Pen downloadFocusPen = new Pen(Color.Red, 3.0f);

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            const float maxRate = 0.997f;

            g.Clear(BackColor);

            // 強制的に描画する画像がある場合
            if (ForceImage != null)
            {
                g.DrawImage(ForceImage, getImageDrawRect(ForceImage, 0, 0));
                return;
            }

            // 画像データが無かったらリターン
            if (imageDatas == null) return;

            lock (imageDatas)
            {
                // 描画する画像を選択
                int no1 = (int)rate;
                int no2 = (int)rate + 1;

                // 描画
                if (slideMode == ImageSlideMode.Normal)                 // 通常切り替え
                {
                    if (no1 < 0 || no1 >= imageDatas.Length) return;
                    var image = imageDatas[no1].Bitmap;
                    var rect = getImageDrawRect(image, 0, 0);
                    g.DrawImage(image, rect);

                    if (FocusDownloadImage) g.DrawRectangle(downloadFocusPen, rect.X+1, rect.Y+1, rect.Width -3, rect.Height-3);
                }
                else if (slideMode == ImageSlideMode.Slide_Right)       // 右にスライド
                {
                    float r = rate - no1;

                    if (no1 >= 0 && no1 < imageDatas.Length)
                    {
                        var image1 = imageDatas[no1].Bitmap;
                        int px1 = (int)(Width * r);
                        Rectangle rect1 = Rectangle.Empty;
                        Rectangle rect2 = Rectangle.Empty;
                        if (r < maxRate)
                        {
                            rect1 = getImageDrawRect(image1, px1, 0);
                            g.DrawImage(image1, rect1);
                        }
                        if (r > 1 - maxRate)
                        {
                            if (no2 == imageDatas.Length) no2 = 0;
                            var image2 = imageDatas[no2].Bitmap;
                            var px2 = px1 - Width;
                            rect2 = getImageDrawRect(image2, px2, 0);
                            g.DrawImage(image2, rect2);
                        }

                        if (FocusDownloadImage)
                        {
                            var no = Math.Round(r);
                            if (no == 0)
                            {
                                g.DrawRectangle(downloadFocusPen, rect1.X + 1, rect1.Y + 1, rect1.Width - 3, rect1.Height - 3);
                            }
                            else
                            {
                                g.DrawRectangle(downloadFocusPen, rect2.X + 1, rect2.Y + 1, rect2.Width - 3, rect2.Height - 3);
                            }
                        }
                    }
                }
                else if (slideMode == ImageSlideMode.Slide_Left)       // 左にスライド
                {
                    float r = rate - no1;
                    if (no1 >= 0 && no1 < imageDatas.Length)
                    {
                        var image1 = imageDatas[no1].Bitmap;
                        int px1 = -(int)(Width * r);
                        Rectangle rect1 = Rectangle.Empty;
                        Rectangle rect2 = Rectangle.Empty;
                        if (r < maxRate)
                        {
                            rect1 = getImageDrawRect(image1, px1, 0);
                            g.DrawImage(image1, rect1);
                        }
                        if (r > 1 - maxRate)
                        {
                            if (no2 == imageDatas.Length) no2 = 0;
                            var image2 = imageDatas[no2].Bitmap;
                            var px2 = px1 + Width;
                            rect2 = getImageDrawRect(image2, px2, 0);
                            g.DrawImage(image2, rect2);
                        }
                        if (FocusDownloadImage)
                        {
                            var no = Math.Round(r);
                            if (no == 0)
                            {
                                g.DrawRectangle(downloadFocusPen, rect1.X + 1, rect1.Y + 1, rect1.Width - 3, rect1.Height - 3);
                            }
                            else
                            {
                                g.DrawRectangle(downloadFocusPen, rect2.X + 1, rect2.Y + 1, rect2.Width - 3, rect2.Height - 3);
                            }
                        }
                    }
                }
                else if (slideMode == ImageSlideMode.Alpha)             // アルファ切り替え
                {
                    float r = rate - no1;
                    if (no1 >= 0 && no1 < imageDatas.Length)
                    {
                        Rectangle rect1 = Rectangle.Empty;
                        Rectangle rect2 = Rectangle.Empty;
                        if (r < maxRate)
                        {
                            cm.Matrix00 = 1;
                            cm.Matrix11 = 1;
                            cm.Matrix22 = 1;
                            cm.Matrix33 = 1.0f - r;
                            cm.Matrix44 = 1;
                            ia.SetColorMatrix(cm);

                            var image1 = imageDatas[no1].Bitmap;
                            rect1 = getImageDrawRect(image1, 0, 0);
                            g.DrawImage(image1, rect1, 0, 0, image1.Width, image1.Height, GraphicsUnit.Pixel, ia);
                        }
                        if (r > 1 - maxRate)
                        {
                            if (no2 == imageDatas.Length) no2 = 0;
                            cm.Matrix00 = 1;
                            cm.Matrix11 = 1;
                            cm.Matrix22 = 1;
                            cm.Matrix33 = r;
                            cm.Matrix44 = 1;
                            ia.SetColorMatrix(cm);

                            var image2 = imageDatas[no2].Bitmap;
                            rect2 = getImageDrawRect(image2, 0, 0);
                            g.DrawImage(image2, rect2, 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, ia);
                        }
                        if (FocusDownloadImage)
                        {
                            var no = Math.Round(r);
                            if (no == 0)
                            {
                                g.DrawRectangle(downloadFocusPen, rect1.X + 1, rect1.Y + 1, rect1.Width - 3, rect1.Height - 3);
                            }
                            else
                            {
                                g.DrawRectangle(downloadFocusPen, rect2.X + 1, rect2.Y + 1, rect2.Width - 3, rect2.Height - 3);
                            }
                        }
                    }
                }
                else if (slideMode == ImageSlideMode.FrontAndSide)
                {
                    float r = rate - no1;
                    if (no1 >= 0 && no1 < imageDatas.Length)
                    {
                        
                    }
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
            try
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
                        return new Rectangle(x, y, Width, Height);
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
                        return new Rectangle(x, y, Width, Height);
                    }
                }
            }
            catch
            {
                return new Rectangle(x, y, Width, Height);
            }
        }

    }
}
