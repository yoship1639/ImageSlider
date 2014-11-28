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

namespace PixivImageSearchAPI
{
    public partial class PixivImageSearchAPI :
        UserControl,
        IImageSearchAPI
    {
        List<ImageData> images = new List<ImageData>();

        private string sessionID;

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
                    textBox1.Text,
                    textBox2.Text,
                };
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object[] DefaultParams
        {
            get
            {
                return new object[]
                {
                    "",
                    "",
                };
            }
        }

        public ImageData[] ImageDatas { get { return images.ToArray(); } }

        public int ImageCount { get { throw new NotImplementedException(); } }

        public event EventHandler SearchError = delegate { };
        public event EventHandler SearchFinished = delegate { };
        public event ImageLoadedEventHandler ImageLoaded = delegate { };

        public void Search(string query)
        {
            Task.Factory.StartNew(() =>
            {
                // セッションIDが無かったらログイン
                if (sessionID == null)
                {
                    login(textBox1.Text, textBox2.Text);
                    if (sessionID == null)
                    {
                        SearchError(this, EventArgs.Empty);
                        return;
                    }
                }

                // Httpエンコード
                var word = HttpUtility.HtmlEncode(query);


            });
            


        }

        public ImageData GetImageData(int index)
        {
            throw new NotImplementedException();
        }

        #region 無理やりログイン

        WebBrowser webBrowser1;

        private void login(string id, string password)
        {
            if (webBrowser1 == null) webBrowser1 = new WebBrowser();

            webBrowser1.Navigate("https://www.secure.pixiv.net/login.php");
            webBrowser1.DocumentCompleted += DocumentCompleted;
        }

        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.All.GetElementsByName("pixiv_id")[0].InnerText = textBox1.Text;
            webBrowser1.Document.All.GetElementsByName("pass")[0].InnerText = textBox2.Text;
            webBrowser1.Document.Forms[1].InvokeMember("submit");
            sessionID = getsessid();
        }

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrl, string lpszCookieName,　StringBuilder lpszCookieData, ref int lpdwSize);

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

        #endregion
    }
}
