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
    public partial class ImageSliderForm : Form
    {
        System.Threading.Timer timer;
        double rate = 0;
        bool neutral = true;
        bool searching = false;

        int showImageNo = 0;

        int tickTime = 10;

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

            }

            TimerCallback timerDelegate = new TimerCallback(Tick);
            timer = new System.Threading.Timer(timerDelegate, null, 0, tickTime);
        }

        int slideCount = 0;
        int slideTime = 5;

        public void Tick(object o)
        {
            slideCount++;
            var up = 0.2;
            var prevRate = rate;

            if (Bounds.Contains(MousePosition) && Form.ActiveForm == this)
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
            };
            config.ShowDialog(this);
            slideTime = config.SlideTime;
            panel_menu.BackColor = config.MenuColor;
            if (config.APIName != currentAPI.APIName)
            {
                setCurrentAPI(imageSearchAPIs.Find((api)=>api.APIName == config.APIName));
            }
        }
    }
}
