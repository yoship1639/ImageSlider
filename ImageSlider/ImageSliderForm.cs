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
        bool start = true;
        int showImageNo = 0;
        int tickTime = 10;
        string downloadFolder;
        bool createSubFolder;

        List<IImageSearchAPI> imageSearchAPIs = new List<IImageSearchAPI>();
        IImageSearchAPI currentAPI;

        new delegate void SetBounds(int x, int y, int width, int height);
        delegate void voidDelegate();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ImageSliderForm()
        {
            InitializeComponent();

            // 英語版
            //Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en");

            TransparencyKey = BackColor;

            // GoogleImageSearchAPIを追加
            imageSearchAPIs.Add(new GoogleImageSearchAPI.GoogleImageSearchAPI());

            // PixivAPIの追加
            imageSearchAPIs.Add(new PixivImageSearchAPI.PixivImageSearchAPI());

            // TwitterAPIの追加
            imageSearchAPIs.Add(new TwitterImageSearchAPI.TwitterImageSearchAPI());

            // 実行ファイルのディレクトリを取得
            string[] pathes =
            {
                Path.GetDirectoryName(Application.ExecutablePath),
                Path.GetDirectoryName(Application.ExecutablePath) + "\\dll",
            };
            // プラグインを読み込む
            foreach (var path in pathes)
            {
                var plugins = PluginLoader.LoadPlugins<IImageSearchAPI>(path);
                foreach (var api in plugins)
                {
                    // 同じAPIが無かったら追加
                    if (!imageSearchAPIs.Exists(_api => _api.APIName == api.APIName))
                    {
                        imageSearchAPIs.Add(api);
                    }
                }
            }

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
                sizeChanger1.BackColor = panel_menu.BackColor;

                // スライド方法
                slideImage1.SlideMode = (SlideImage.ImageSlideMode)Properties.Settings.Default.SlideMode;

                // サイズモード
                slideImage1.SizeMode = (SlideImage.ImageSizeMode)Properties.Settings.Default.SizeMode;

                // 保存場所
                downloadFolder = Properties.Settings.Default.DownloadFolder;
                if (!Directory.Exists(downloadFolder))
                {
                    downloadFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                }

                // サブフォルダ
                createSubFolder = Properties.Settings.Default.CreateSubFolder;

                // APIの設定を読み込む
                try
                {
                    var settings = Serializer.XmlDeserialize<APISetting[]>(Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.config");

                    foreach (var setting in settings)
                    {
                        var api = imageSearchAPIs.Find(_api => _api.APIName == setting.APIName);
                        if (api != null)
                        {
                            api.Params = setting.Params;
                        }
                    }
                }
                catch { }
            }

            TimerCallback timerDelegate = new TimerCallback(Tick);
            timer = new System.Threading.Timer(timerDelegate, null, 0, tickTime);
        }

        int slideCount = 0;
        int slideTime = 5;

        /// <summary>
        /// 一定間隔で呼ばれる
        /// </summary>
        /// <param name="o"></param>
        public void Tick(object o)
        {
            slideCount++;
            var up = 0.2;
            var prevRate = rate;

            if ((Bounds.Contains(MousePosition) || slideImage1.ImageDatas == null || sizeFlag) && Form.ActiveForm == this)
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
                // パネル
                Invoke(new SetBounds(panel_menu.SetBounds), 0, 0, panel_menu.Size.Width, (int)(rate * 32));
                // サイズ変更パネル
                Invoke(
                    new SetBounds(sizeChanger1.SetBounds),
                    Size.Width - (int)(sizeChanger1.Width * rate),
                    Size.Height - (int)(sizeChanger1.Height * rate),
                    sizeChanger1.Width,
                    sizeChanger1.Height);

                // ボタン
                if (!searching && !neutral)
                {
                    setButtonsBounds(true);
                }
            }

            if (!searching && !neutral)
            {
                if (start && slideCount > slideTime * 1000 / tickTime)
                {
                    slideCount = 0;
                    nextImage();
                    Invoke(new voidDelegate(showImageCountLabel));
                }
                var r = showImageNo - slideImage1.Rate;
                if (Math.Abs(r) > 0.001f)
                {
                    slideImage1.Rate += (showImageNo - slideImage1.Rate) * 0.15f;
                }
                else slideImage1.Rate = showImageNo;
            }
        }

        /// <summary>
        /// 検索開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox_search.Text.Length > 0)
            {
                e.SuppressKeyPress = true;
                searching = true;
                neutral = false;
                showImageNo = 0;
                slideImage1.Rate = 0;

                slideImage1.ForceImage = Properties.Resources.searching;

                try
                {
                    currentAPI.Search(textBox_search.Text);
                }
                catch
                {
                    currentAPI_SearchError(this, EventArgs.Empty);
                }
                

                return;
            }
            slideImage1_KeyDown(null, e);
        }

        #region カレントAPI関連

        /// <summary>
        /// カレントAPIを指定する
        /// </summary>
        /// <param name="api"></param>
        private void setCurrentAPI(IImageSearchAPI api)
        {
            if (currentAPI != null)
            {
                currentAPI.ImageLoaded -= currentAPI_ImageLoaded;
                currentAPI.SearchError -= currentAPI_SearchError;
                currentAPI.SearchFinished -= currentAPI_SearchFinished;
            }
            currentAPI = api;
            currentAPI.ImageLoaded += currentAPI_ImageLoaded;
            currentAPI.SearchError += currentAPI_SearchError;
            currentAPI.SearchFinished += currentAPI_SearchFinished;
        }

        /// <summary>
        /// 検索終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void currentAPI_SearchFinished(object sender, EventArgs e)
        {
            if (slideImage1.ImageDatas == null || slideImage1.ImageDatas.Length == 0)
            {
                currentAPI_SearchError(sender, e);
            }
        }

        /// <summary>
        /// 画像が読み込まれた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void currentAPI_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            searching = false;
            slideImage1.ForceImage = null;
            slideImage1.ImageDatas = currentAPI.ImageDatas;
            if (e.Index == 0)
            {
                // ボタン
                setButtonsBounds(true);
            }
            Invoke(new voidDelegate(showImageCountLabel));
        }

        /// <summary>
        /// 検索に失敗した
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void currentAPI_SearchError(object sender, EventArgs e)
        {
            searching = false;
            neutral = true;
            slideImage1.ForceImage = Properties.Resources.searcherror;
            // ボタン
            setButtonsBounds(false);
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
                Size = new Size(Size.Width + e.Location.X - pivot.X, Size.Height + e.Location.Y - pivot.Y);
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
            Properties.Settings.Default.SlideMode = (int)slideImage1.SlideMode;
            Properties.Settings.Default.DownloadFolder = downloadFolder;
            Properties.Settings.Default.CreateSubFolder = createSubFolder;
            Properties.Settings.Default.SizeMode = (int)slideImage1.SizeMode;
            Properties.Settings.Default.Save();

            // APIの設定を保存
            var paramsList = new List<APISetting>();
            foreach (var api in imageSearchAPIs)
            {
                paramsList.Add(new APISetting() { APIName = api.APIName, Params = api.Params });
            }
            Serializer.XmlSerialize(Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.config", paramsList.ToArray());

        }

        public class APISetting
        {
            public string APIName { get; set; }
            public object[] Params { get; set; }
        }

        #endregion

        /// <summary>
        /// 設定フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_config_Click(object sender, EventArgs e)
        {
            // 設定フォームの作成
            ConfigForm config = new ConfigForm(imageSearchAPIs.ToArray(), currentAPI)
            {
                SlideTime = slideTime,
                MenuColor = panel_menu.BackColor,
                SlideMode = slideImage1.SlideMode,
                DowloadFolder = downloadFolder,
                CreateSubFolder = createSubFolder,
                SizeMode = slideImage1.SizeMode,
                FocusDownloadImage = Properties.Settings.Default.FocusDownloadImage,
            };
            config.ShowDialog(this);
            slideTime = config.SlideTime;
            panel_menu.BackColor = config.MenuColor;
            sizeChanger1.BackColor = panel_menu.BackColor;
            slideImage1.SlideMode = config.SlideMode;
            downloadFolder = config.DowloadFolder;
            createSubFolder = config.CreateSubFolder;
            slideImage1.SizeMode = config.SizeMode;
            Properties.Settings.Default.FocusDownloadImage = config.FocusDownloadImage;
            
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
                sizeChanger1.Enabled = false;
                sizeChanger1.Visible = false;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                button_windowStateChange.BackgroundImage = Properties.Resources.maximize;
                WindowState = FormWindowState.Normal;
                sizeChanger1.Enabled = true;
                sizeChanger1.Visible = true;
            }
            slideImage1.Size = Size;
        }

        /// <summary>
        /// 再生、ストップを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_startStop_Click(object sender, EventArgs e)
        {
            start = !start;

            if (start) button_startStop.BackgroundImage = Properties.Resources.stop3;
            else button_startStop.BackgroundImage = Properties.Resources.play;
        }

        /// <summary>
        /// 表示している画像の番号と最大数を表示
        /// </summary>
        private void showImageCountLabel()
        {
            if (slideImage1.ImageDatas == null) return;
            label_imageCount.Text = showImageNo+1 + "/" + slideImage1.ImageDatas.Length;
        }

        /// <summary>
        /// ボタンの位置を決める
        /// </summary>
        /// <param name="show"></param>
        private void setButtonsBounds(bool show)
        {
            if (show)
            {
                // スタートストップ
                Invoke(
                        new SetBounds(button_startStop.SetBounds),
                        ((Size.Width - button_startStop.Width) >> 1) - 64,
                        Size.Height - (int)(50 * rate),
                        button_startStop.Width,
                        button_startStop.Height);

                // ダウンロード
                Invoke(
                        new SetBounds(button_download.SetBounds),
                        ((Size.Width - button_download.Width) >> 1),
                        Size.Height - (int)(50 * rate),
                        button_download.Width,
                        button_download.Height);

                // サイトに飛ぶ
                Invoke(
                        new SetBounds(button_moveSite.SetBounds),
                        ((Size.Width - button_moveSite.Width) >> 1) + 64,
                        Size.Height - (int)(50 * rate),
                        button_moveSite.Width,
                        button_moveSite.Height);

                // 次へ
                Invoke(
                        new SetBounds(button_right.SetBounds),
                        (Width - button_right.Width - 10) + (int)(50 * (1.0f - rate)),
                        (Height - button_right.Height) >> 1,
                        button_right.Width,
                        button_right.Height);

                // 戻る
                Invoke(
                        new SetBounds(button_left.SetBounds),
                        10 - (int)(50 * (1.0f - rate)),
                        (Height - button_left.Height) >> 1,
                        button_left.Width,
                        button_left.Height);
            }
            else
            {
                // スタートストップ
                Invoke(
                        new SetBounds(button_startStop.SetBounds),
                        10000, 10000,
                        button_startStop.Width,
                        button_startStop.Height);

                // ダウンロード
                Invoke(
                        new SetBounds(button_download.SetBounds),
                        10000, 10000,
                        button_download.Width,
                        button_download.Height);

                // サイトに飛ぶ
                Invoke(
                        new SetBounds(button_moveSite.SetBounds),
                        10000, 10000,
                        button_moveSite.Width,
                        button_moveSite.Height);

                // 次へ
                Invoke(
                        new SetBounds(button_right.SetBounds),
                        10000, 10000,
                        button_right.Width,
                        button_right.Height);

                // 戻る
                Invoke(
                        new SetBounds(button_left.SetBounds),
                        10000, 10000,
                        button_left.Width,
                        button_left.Height);
            }
        }

        /// <summary>
        /// ダウンロードボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_download_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var no = (int)Math.Round(slideImage1.Rate);
                var datas = slideImage1.ImageDatas;
                var image = datas[no];
                saveImage(image);
            });
            
        }

        /// <summary>
        /// 画像を保存する
        /// </summary>
        /// <returns></returns>
        private bool saveImage(ImageData image)
        {
            try
            {
                // 保存パス
                var path = downloadFolder + "\\";
                if (createSubFolder)
                {
                    path += textBox_search.Text;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path += "\\";
                } 
                path += image.FileName;

                image.Bitmap.Save(path);
                System.Diagnostics.Debug.WriteLine(path);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("保存に失敗しました!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ショートカットキー操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slideImage1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Sで保存
            if (e.Control && e.KeyCode.HasFlag(Keys.S))
            {
                Task.Factory.StartNew(() =>
                {
                    var no = (int)Math.Round(slideImage1.Rate);
                    var datas = slideImage1.ImageDatas;
                    if (datas != null)
                    {
                        var image = datas[no];
                        saveImage(image);
                    }
                });
            }
            else if (e.KeyCode == Keys.D)       // 進む
            {
                slideCount = 0;
                nextImage();
                showImageCountLabel();
            }
            else if (e.KeyCode == Keys.A)       // 戻る
            {
                slideCount = 0;
                prevImage();
                showImageCountLabel();
            }
            else if (e.Control && e.KeyCode.HasFlag(Keys.E))    // サイトに飛ぶ
            {
                moveToSite();
            }
        }

        /// <summary>
        /// 次の画像に進む
        /// </summary>
        private void nextImage()
        {
            if (slideImage1.ImageDatas == null) return;
            showImageNo++;
            if (showImageNo >= slideImage1.ImageDatas.Length)
            {
                showImageNo = 0;
            }
            if (slideImage1.SlideMode == SlideImage.ImageSlideMode.Normal) slideImage1.Rate = showImageNo;
        }

        /// <summary>
        /// 前の画像に戻る
        /// </summary>
        private void prevImage()
        {
            if (slideImage1.ImageDatas == null) return;
            showImageNo--;
            if (showImageNo < 0) 
            {
                showImageNo = slideImage1.ImageDatas.Length - 1;
            }
            if (slideImage1.SlideMode == SlideImage.ImageSlideMode.Normal) slideImage1.Rate = showImageNo;
        }

        /// <summary>
        /// 進むボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_right_Click(object sender, EventArgs e)
        {
            slideCount = 0;
            nextImage();
            showImageCountLabel();
        }

        /// <summary>
        /// 戻るボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_left_Click(object sender, EventArgs e)
        {
            slideCount = 0;
            prevImage();
            showImageCountLabel();
        }

        /// <summary>
        /// サイトに飛ぶボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_moveSite_Click(object sender, EventArgs e)
        {
            moveToSite();
        }

        /// <summary>
        /// サイトに飛ぶ
        /// </summary>
        private void moveToSite()
        {
            var datas = slideImage1.ImageDatas;
            if (datas != null)
            {
                var no = (int)Math.Round(slideImage1.Rate);
                if (no < 0 || no >= datas.Length) return;

                System.Diagnostics.Process.Start(datas[no].SourceURL);
            }
        }

        private void button_download_MouseEnter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FocusDownloadImage)
            {
                slideImage1.FocusDownloadImage = true;
                slideImage1.Repaint();
            }
        }

        private void button_download_MouseLeave(object sender, EventArgs e)
        {
            slideImage1.FocusDownloadImage = false;
            slideImage1.Repaint();
        }
    }
}
