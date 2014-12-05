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
using System.Runtime.InteropServices;
using System.Web;
using System.IO;

namespace PixivImageSearchAPI
{
    public partial class PixivImageSearchAPI :
        UserControl,
        IImageSearchAPI
    {
        List<ImageData> images = new List<ImageData>();

        public PixivImageSearchAPI()
        {
            InitializeComponent();
        }

        public string APIName { get { return "PixivAPI"; } }

        public object[] Params
        {
            get
            {
                return new object[]
                {
                    numericUpDown1.Value,
                };
            }
            set
            {
                numericUpDown1.Value = (decimal)value[0];
            }
        }

        public object[] DefaultParams
        {
            get
            {
                return new object[]
                {
                    (decimal)50,
                };
            }
        }

        public ImageData[] ImageDatas { get { return images.ToArray(); } }

        public event EventHandler SearchError = delegate { };
        public event EventHandler SearchFinished = delegate { };
        public event ImageLoadedEventHandler ImageLoaded = delegate { };

        public void Search(string query)
        {
            images.Clear();

            Task.Factory.StartNew(() =>
            {
                // Httpエンコード
                var word = HttpUtility.HtmlEncode(query);

                // 指定の件数だけ検索
                int max = (int)(numericUpDown1.Value / 50);
                Parallel.For(0, max, i =>
                {
                    // URLの作成
                    StringBuilder sb = new StringBuilder();
                    sb.Append("http://spapi.pixiv.net/iphone/search.php?s_mode=s_tag&word=");
                    sb.Append(word);
                    //sb.Append("&PHPSESSID=");
                    //sb.Append(sessionID);
                    sb.Append("&p=");
                    sb.Append(i+1);

                    string csv = null;

                    try
                    {
                        //WebClientを作成
                        using (var wc = new System.Net.WebClient())
                        {
                            //文字コードを指定
                            wc.Encoding = Encoding.UTF8;
                            //データを文字列としてダウンロードする
                            csv = wc.DownloadString(sb.ToString());
                        }

                        // CSVの解析
                        var datas = Deserialize(csv);

                        for (int j = 0; j < datas.Length; j++)
                        {
                            try
                            {
                                string url = datas[j].IllustURL;
                                var wc = new System.Net.WebClient();
                                Stream stream = wc.OpenRead(url);
                                var image = new ImageData()
                                {
                                    Bitmap = new System.Drawing.Bitmap(stream),
                                    FileName = datas[j].Title + "." + datas[j].Extension,
                                    SourceURL = "http://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + datas[j].IllustID,
                                };
                                lock (images)
                                {
                                    images.Add(image);
                                    ImageLoaded(this, new ImageLoadedEventArgs() { Index = images.Count - 1, ImageData = image });
                                }
                                stream.Close();
                            }
                            catch { }
                        }
                    }
                    catch { }
                });
                SearchFinished(this, EventArgs.Empty);
            });
        }

        #region 無理やりログイン
        /*
        private void login(string id, string password)
        {
            loginEnd = false;
            webBrowser1.Navigate("https://www.secure.pixiv.net/login.php");
            webBrowser1.DocumentCompleted += DocumentCompleted;
        }

        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.All.GetElementsByName("pixiv_id")[0].InnerText = textBox1.Text;
            webBrowser1.Document.All.GetElementsByName("pass")[0].InnerText = textBox2.Text;
            webBrowser1.Document.Forms[1].InvokeMember("submit");
            sessionID = getsessid();
            loginEnd = true;
        }

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrl, string lpszCookieName, StringBuilder lpszCookieData, ref int lpdwSize);

        public static string getsessid()
        {
            int size = 0;

            InternetGetCookie("http://pixiv.net", null, null, ref size);
            StringBuilder lpszCookieData = new StringBuilder(size);
            InternetGetCookie("http://pixiv.net", null, lpszCookieData, ref size);
            string cookie = lpszCookieData.ToString();

            int Index1 = cookie.IndexOf("PHPSESSID");
            int Index2 = cookie.IndexOf(";", Index1 + 1);
            return cookie.Substring(Index1 + 10, (Index2 - Index1 - 10));
        }
        */
        #endregion

        private PixivImageData[] Deserialize(string buf)
        {
            const int elemNum = 30;
            var buf2 = buf.Replace("\n", "");
            int seek = 0;
            List<string> datas = new List<string>();
            while (seek < buf2.Length)
            {
                char c = buf2[seek];
                if (c == '\"')
                {
                    var s = seek;
                    do { seek++; } while(!(buf2[seek] == '\"' && buf2[seek + 1] == ','));
                    var e = seek;
                    datas.Add(buf2.Substring(s+1, e-s-1));
                    seek += 2;
                }
                else if (c == ',')
                {
                    datas.Add("");
                    seek++;
                }
            } 
            var count = datas.Count / elemNum;
            var images = new PixivImageData[count];
            for (int i = 0; i < count; i++)
            {
                
                images[i] = new PixivImageData()
                {
                    IllustID = int.Parse(datas[i * elemNum + 0]),
                    UserID = int.Parse(datas[i * elemNum + 1]),
                    Extension = datas[i * elemNum + 2],
                    Title = datas[i * elemNum + 3],
                    UserName = datas[i * elemNum + 5],
                    ThumbnailURL = datas[i * elemNum + 6],
                    IllustURL = datas[i * elemNum + 9],
                    UploadDate = datas[i * elemNum + 12],
                    Tag = datas[i * elemNum + 13],
                    SoftwareName = datas[i * elemNum + 14],
                    Valuation = int.Parse(datas[i * elemNum + 15]),
                    SumValue = int.Parse(datas[i * elemNum + 16]),
                    BrowsingCount = int.Parse(datas[i * elemNum + 17]),
                    Caption = datas[i * elemNum + 18],
                    PageCount = datas[i * elemNum + 19] != "" ? int.Parse(datas[i * elemNum + 19]) : 1,
                    BookmarkCount = int.Parse(datas[i * elemNum + 22]),
                    ID = datas[i * elemNum + 24],
                    ProfURL = datas[i * elemNum + 29],
                };
                /*
                images[i] = new PixivImageData();
                {
                    images[i].IllustID = int.Parse(datas[i * elemNum + 0]);
                    images[i].UserID = int.Parse(datas[i * elemNum + 1]);
                    images[i].Extension = datas[i * elemNum + 2];
                    images[i].Title = datas[i * elemNum + 3];
                    images[i].UserName = datas[i * elemNum + 5];
                    images[i].ThumbnailURL = datas[i * elemNum + 6];
                    images[i].IllustURL = datas[i * elemNum + 9];
                    images[i].UploadDate = datas[i * elemNum + 12];
                    images[i].Tag = datas[i * elemNum + 13];
                    images[i].SoftwareName = datas[i * elemNum + 14];
                    images[i].Valuation = int.Parse(datas[i * elemNum + 15]);
                    images[i].SumValue = int.Parse(datas[i * elemNum + 16]);
                    images[i].BrowsingCount = int.Parse(datas[i * elemNum + 17]);
                    images[i].Caption = datas[i * elemNum + 18];
                    images[i].PageCount = datas[i * elemNum + 19] != "" ? int.Parse(datas[i * elemNum + 19]) : 1;
                    images[i].BookmarkCount = int.Parse(datas[i * elemNum + 22]);
                    images[i].ID = datas[i * elemNum + 24];
                    images[i].ProfURL = datas[i * elemNum + 29];
                };*/
            }

            return images;
        }

        class PixivImageData
        {
            public int IllustID { get; set; }               // イラストID
            public int UserID { get; set; }                 // ユーザID
            public string Extension { get; set; }           // 拡張子
            public string Title { get; set; }               // タイトル
            public string UserName { get; set; }            // ユーザ名
            public string ThumbnailURL { get; set; }        // 128x128
            public string IllustURL { get; set; }           // 480mw
            public string UploadDate { get; set; }          // 投稿日時
            public string Tag { get; set; }                 // タグ
            public string SoftwareName { get; set; }        // 使用ソフト
            public int Valuation { get; set; }              // 評価回数
            public int SumValue { get; set; }               // 総合点
            public int BrowsingCount { get; set; }          // 閲覧回数
            public string Caption { get; set; }             // キャプション
            public int PageCount { get; set; }              // ページ数（漫画の場合）
            public int BookmarkCount { get; set; }          // ブックマーク数
            public string ID { get; set; }                  // 投稿者のID
            public string ProfURL { get; set; }             // プロフィール画像URL
        }
    }
}
