using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Web;
using System.Reflection;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

using ImageSearchAPILib;

namespace ImageSlider
{
    /*
    public partial class ImageSliderForm : Form
    {
        System.Threading.Timer timer;
        double rate = 0;
        bool neutral = true;
        bool searching = false;

        int showImageNo = 0;

        int tickTime = 10;

        bool smoothSlide = false;

        List<IImageSearchAPI> imageSearchAPIs = new List<IImageSearchAPI>();
        IImageSearchAPI currentAPI;

        new delegate void SetBounds(int x, int y, int width, int height);

        public ImageSliderForm()
        {
            InitializeComponent();
            TransparencyKey = BackColor;

            // GoogleImageSearchAPIを追加
            imageSearchAPIs.Add(new GoogleImageSearchAPI.GoogleImageSearchAPI());

            // PixivAPIの追加
            imageSearchAPIs.Add(new PixivImageSearchAPI.PixivImageSearchAPI());

            // 設定の読み込み
            {
                // カレントAPIを設定
                var tmp = imageSearchAPIs.Find((api) => api.APIName == Properties.Settings.Default.SearchAPI);
                if (tmp == null) tmp = imageSearchAPIs[0];
                setCurrentAPI(tmp);

                // 切り替わり時間
                slideTime = Properties.Settings.Default.SlideTime;

                // メニュー色
                panel_menu.BackColor = Properties.Settings.Default.MenuColor;

                // 滑らかに切り替え
                smoothSlide = Properties.Settings.Default.SmoothSlide;
            }

            TimerCallback timerDelegate = new TimerCallback(Tick);
            timer = new System.Threading.Timer(timerDelegate, null, 0, tickTime);
        }

        int slideCount = 0;
        int slideTime = 5;

        int smoothCount = 0;

        public void Tick(object o)
        {
            slideCount++;
            var up = 0.2;
            var prevRate = rate;

            if ((Bounds.Contains(MousePosition) || pictureBox_showImage.Image == null) && Form.ActiveForm == this)
            {
                if (rate < 1)
                {
                    rate += (1 - rate) * up;
                }
                if(rate > 0.99) rate = 1;
            }
            else
            {
                if (rate > 0)
                {
                    rate -= rate * up;
                }
                if (rate < 0.01) rate = 0;
            }
            if (prevRate != rate)
            {
                Invoke(new SetBounds(panel_menu.SetBounds), 0, 0, panel_menu.Size.Width, (int)(rate * 32));
                Invoke(
                    new SetBounds(pictureBox_sizeChange.SetBounds),
                    Size.Width - (int)(pictureBox_sizeChange.Size.Width * rate),
                    Size.Height - (int)(pictureBox_sizeChange.Size.Height * rate),
                    pictureBox_sizeChange.Size.Width,
                    pictureBox_sizeChange.Size.Height);
            }

            if (!searching && !neutral)
            {
                if (!smoothSlide)
                {
                    if (slideCount > slideTime * 1000 / tickTime)
                    {
                        slideCount = 0;
                        if (currentAPI.ImageCount - 1 > showImageNo)
                        {
                            showImageNo++;
                            if (showImageNo >= currentAPI.ImageCount) showImageNo = 0;
                            pictureBox_showImage.Image = currentAPI.GetImageData(showImageNo).Bitmap;
                        }
                    }
                }
                else
                {
                    if (smoothCount < 50) smoothCount++;

                    if (slideCount > slideTime * 1000 / tickTime)
                    {
                        slideCount = 0;
                        smoothCount = 0;
                        if (currentAPI.ImageCount - 1 > showImageNo)
                        {
                            showImageNo++;
                            if (showImageNo >= currentAPI.ImageCount) showImageNo = 0;
                            pictureBox_showImage.Image = currentAPI.GetImageData(showImageNo).Bitmap;
                        }
                    }
                }
            }
        }

        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                searching = true;
                neutral = false;

                pictureBox_showImage.Image = Properties.Resources.loader;

                currentAPI.Search(textBox_search.Text);
                
                return;
            }
        }

        #region カレントAPI関連

        private void setCurrentAPI(IImageSearchAPI api)
        {
            if (currentAPI != null)
            {
                currentAPI.ImageLoaded -= currentAPI_ImageLoaded;
                currentAPI.SearchError -= currentAPI_SearchError;
            }
            currentAPI = api;
            currentAPI.ImageLoaded += currentAPI_ImageLoaded;
            currentAPI.SearchError += currentAPI_SearchError;
        }

        void currentAPI_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            searching = false;
        }

        void currentAPI_SearchError(object sender, EventArgs e)
        {
            searching = false;
            neutral = true;
            pictureBox_showImage.Image = Properties.Resources.close;
        }

        #endregion

        #region ウィンドウ位置変更

        bool moveFlag = false;
        Point pivot;

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                moveFlag = true;
                pivot = e.Location;
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            moveFlag = false;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag)
            {
                int x = e.Location.X - pivot.X;
                int y = e.Location.Y - pivot.Y;

                Location = new Point(Location.X + e.Location.X - pivot.X, Location.Y + e.Location.Y - pivot.Y);
            }
        }

        #endregion

        #region ウィンドウサイズ変更

        bool sizeFlag = false;
        private void pictureBox_sizeChange_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                sizeFlag = true;
                pivot = e.Location;
            }
        }

        private void pictureBox_sizeChange_MouseMove(object sender, MouseEventArgs e)
        {
            if (sizeFlag)
            {
                Size = new Size(Size.Width + e.Location.X, Size.Height + e.Location.Y);
                pictureBox_showImage.Size = Size;
            }
        }

        private void pictureBox_sizeChange_MouseUp(object sender, MouseEventArgs e)
        {
            sizeFlag = false;
        }

        #endregion

        #region 終了関連

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImageSliderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
            timer = null;

            // 設定の保存
            Properties.Settings.Default.SearchAPI = currentAPI.APIName;
            Properties.Settings.Default.SlideTime = slideTime;
            Properties.Settings.Default.MenuColor = panel_menu.BackColor;
            Properties.Settings.Default.SmoothSlide = smoothSlide;
            Properties.Settings.Default.Save();
        }

        #endregion

        private void button_config_Click(object sender, EventArgs e)
        {
            // 設定フォームの作成
            ConfigForm config = new ConfigForm(imageSearchAPIs.ToArray(), currentAPI)
            {
                SlideTime = slideTime,
                MenuColor = panel_menu.BackColor,
                SmoothSlide = smoothSlide,
            };
            config.ShowDialog(this);
            slideTime = config.SlideTime;
            panel_menu.BackColor = config.MenuColor;
            smoothSlide = config.SmoothSlide;
            if (config.APIName != currentAPI.APIName)
            {
                setCurrentAPI(imageSearchAPIs.Find((api)=>api.APIName == config.APIName));
            }
        }

        /// <summary>
        /// ウィンドウの状態を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_windowStateChange_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                button_windowStateChange.BackgroundImage = Properties.Resources.normal;
                WindowState = FormWindowState.Maximized;
                pictureBox_sizeChange.Enabled = false;
                pictureBox_sizeChange.Visible = false;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                button_windowStateChange.BackgroundImage = Properties.Resources.maximize;
                WindowState = FormWindowState.Normal;
                pictureBox_sizeChange.Enabled = true;
                pictureBox_sizeChange.Visible = true;
            }
            pictureBox_showImage.Size = Size;
        }
    }*/
    public partial class ImageSliderForm : Form
    {
        System.Threading.Timer timer;
        double rate = 0;
        bool neutral = true;
        bool searching = false;

        int showImageNo = 0;

        int tickTime = 10;

        bool smoothSlide = false;

        List<IImageSearchAPI> imageSearchAPIs = new List<IImageSearchAPI>();
        IImageSearchAPI currentAPI;

        new delegate void SetBounds(int x, int y, int width, int height);

        public ImageSliderForm()
        {
            InitializeComponent();
            TransparencyKey = BackColor;

            // GoogleImageSearchAPIを追加
            imageSearchAPIs.Add(new GoogleImageSearchAPI.GoogleImageSearchAPI());

            // PixivAPIの追加
            imageSearchAPIs.Add(new PixivImageSearchAPI.PixivImageSearchAPI());

            // 設定の読み込み
            {
                // カレントAPIを設定
                var tmp = imageSearchAPIs.Find((api) => api.APIName == Properties.Settings.Default.SearchAPI);
                if (tmp == null) tmp = imageSearchAPIs[0];
                setCurrentAPI(tmp);

                // 切り替わり時間
                slideTime = Properties.Settings.Default.SlideTime;

                // メニュー色
                panel_menu.BackColor = Properties.Settings.Default.MenuColor;

                // 滑らかに切り替え
                smoothSlide = Properties.Settings.Default.SmoothSlide;
            }

            TimerCallback timerDelegate = new TimerCallback(Tick);
            timer = new System.Threading.Timer(timerDelegate, null, 0, tickTime);
        }

        int slideCount = 0;
        int slideTime = 5;

        int smoothCount = 0;

        public void Tick(object o)
        {
            slideCount++;
            var up = 0.2;
            var prevRate = rate;

            if ((Bounds.Contains(MousePosition) || slideImage1.ImageDatas == null) && Form.ActiveForm == this)
            {
                if (rate < 1)
                {
                    rate += (1 - rate) * up;
                }
                if (rate > 0.99) rate = 1;
            }
            else
            {
                if (rate > 0)
                {
                    rate -= rate * up;
                }
                if (rate < 0.01) rate = 0;
            }
            if (prevRate != rate)
            {
                Invoke(new SetBounds(panel_menu.SetBounds), 0, 0, panel_menu.Size.Width, (int)(rate * 32));
                Invoke(
                    new SetBounds(pictureBox_sizeChange.SetBounds),
                    Size.Width - (int)(pictureBox_sizeChange.Size.Width * rate),
                    Size.Height - (int)(pictureBox_sizeChange.Size.Height * rate),
                    pictureBox_sizeChange.Size.Width,
                    pictureBox_sizeChange.Size.Height);
            }

            if (!searching && !neutral)
            {
                if (slideCount > slideTime * 1000 / tickTime)
                {
                    slideCount = 0;
                    showImageNo++;
                    if (showImageNo >= slideImage1.ImageDatas.Length)
                    {
                        showImageNo = 0;
                    } 
                }

                slideImage1.Rate += (showImageNo - slideImage1.Rate) * 0.1f;
            }
        }

        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                searching = true;
                neutral = false;

                slideImage1.ForceImage = Properties.Resources.loader;

                currentAPI.Search(textBox_search.Text);

                return;
            }
        }

        #region カレントAPI関連

        private void setCurrentAPI(IImageSearchAPI api)
        {
            if (currentAPI != null)
            {
                currentAPI.ImageLoaded -= currentAPI_ImageLoaded;
                currentAPI.SearchError -= currentAPI_SearchError;
            }
            currentAPI = api;
            currentAPI.ImageLoaded += currentAPI_ImageLoaded;
            currentAPI.SearchError += currentAPI_SearchError;
        }

        void currentAPI_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            searching = false;
            slideImage1.ForceImage = null;
            slideImage1.ImageDatas = currentAPI.ImageDatas;
        }

        void currentAPI_SearchError(object sender, EventArgs e)
        {
            searching = false;
            neutral = true;
            slideImage1.ForceImage = Properties.Resources.close;
        }

        #endregion

        #region ウィンドウ位置変更

        bool moveFlag = false;
        Point pivot;

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                moveFlag = true;
                pivot = e.Location;
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            moveFlag = false;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag)
            {
                int x = e.Location.X - pivot.X;
                int y = e.Location.Y - pivot.Y;

                Location = new Point(Location.X + e.Location.X - pivot.X, Location.Y + e.Location.Y - pivot.Y);
            }
        }

        #endregion

        #region ウィンドウサイズ変更

        bool sizeFlag = false;
        private void pictureBox_sizeChange_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                sizeFlag = true;
                pivot = e.Location;
            }
        }

        private void pictureBox_sizeChange_MouseMove(object sender, MouseEventArgs e)
        {
            if (sizeFlag)
            {
                Size = new Size(Size.Width + e.Location.X, Size.Height + e.Location.Y);
                slideImage1.Size = Size;
            }
        }

        private void pictureBox_sizeChange_MouseUp(object sender, MouseEventArgs e)
        {
            sizeFlag = false;
        }

        #endregion

        #region 終了関連

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImageSliderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
            timer = null;

            // 設定の保存
            Properties.Settings.Default.SearchAPI = currentAPI.APIName;
            Properties.Settings.Default.SlideTime = slideTime;
            Properties.Settings.Default.MenuColor = panel_menu.BackColor;
            Properties.Settings.Default.SmoothSlide = smoothSlide;
            Properties.Settings.Default.Save();
        }

        #endregion

        private void button_config_Click(object sender, EventArgs e)
        {
            // 設定フォームの作成
            ConfigForm config = new ConfigForm(imageSearchAPIs.ToArray(), currentAPI)
            {
                SlideTime = slideTime,
                MenuColor = panel_menu.BackColor,
                SmoothSlide = smoothSlide,
            };
            config.ShowDialog(this);
            slideTime = config.SlideTime;
            panel_menu.BackColor = config.MenuColor;
            smoothSlide = config.SmoothSlide;
            if (config.APIName != currentAPI.APIName)
            {
                setCurrentAPI(imageSearchAPIs.Find((api) => api.APIName == config.APIName));
            }
        }

        /// <summary>
        /// ウィンドウの状態を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_windowStateChange_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                button_windowStateChange.BackgroundImage = Properties.Resources.normal;
                WindowState = FormWindowState.Maximized;
                pictureBox_sizeChange.Enabled = false;
                pictureBox_sizeChange.Visible = false;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                button_windowStateChange.BackgroundImage = Properties.Resources.maximize;
                WindowState = FormWindowState.Normal;
                pictureBox_sizeChange.Enabled = true;
                pictureBox_sizeChange.Visible = true;
            }
            slideImage1.Size = Size;
        }
    }
}
