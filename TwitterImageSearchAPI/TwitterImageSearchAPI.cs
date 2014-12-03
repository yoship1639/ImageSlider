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

namespace TwitterImageSearchAPI
{
    public partial class TwitterImageSearchAPI : 
        UserControl,
        IImageSearchAPI
    {
        List<ImageData> images = new List<ImageData>();

        public TwitterImageSearchAPI()
        {
            InitializeComponent();
        }

        public string APIName { get { return "TwitterAPI"; } }

        public object[] Params
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public object[] DefaultParams
        {
            get { return null; }
        }

        public ImageData[] ImageDatas
        {
            get { return images.ToArray(); }
        }

        public int ImageCount
        {
            get { return images.Count; }
        }

        public event EventHandler SearchError = delegate { };
        public event EventHandler SearchFinished = delegate { };
        public event ImageLoadedEventHandler ImageLoaded = delegate { };

        CoreTweet.Tokens tokens = null;

        public void Search(string query)
        {
            images.Clear();
            Task.Factory.StartNew(() =>
            {
                // トークンを取得
                if (tokens == null)
                {
                    tokens = CoreTweet.Tokens.Create(
                         SecretSetting.Default.ConsumerKey,
                         SecretSetting.Default.ConsumerSecret,
                         SecretSetting.Default.AccessToken,
                         SecretSetting.Default.AccessTokenSecret
                         );

                    if (tokens == null)
                    {
                        SearchError(this, EventArgs.Empty);
                        return;
                    }
                }

                // Httpエンコード
                var word = HttpUtility.HtmlEncode(query);

                // 検索し、結果を取得
                var result = tokens.Search.Tweets(new Dictionary<string, object>()
                {
                    {"q", "filter:images " + word},
                    {"include_entities", true},
                    {"count", 100},
                    {"locale", "ja"},
                });
                if (result == null)
                {
                    SearchError(this, EventArgs.Empty);
                    return;
                }

                Parallel.For(0, result.Count, i =>
                {
                    try
                    {
                        var res = result[i];
                        if (res.Entities.Media != null)
                        {
                            foreach (var m in res.Entities.Media)
                            {
                                var idx = m.MediaUrl.LocalPath.LastIndexOf('/');
                                if(idx < 0) idx = 0;
                                var sub = m.MediaUrl.LocalPath.Substring(idx);

                                var wc = new System.Net.WebClient();
                                Stream stream = wc.OpenRead(m.MediaUrl.AbsoluteUri);
                                var image = new ImageData()
                                {
                                    Bitmap = new System.Drawing.Bitmap(stream),
                                    FileName = sub,
                                    SourceURL = m.ExpandedUrl.AbsoluteUri,
                                };
                                lock (images)
                                {
                                    images.Add(image);
                                    ImageLoaded(this, new ImageLoadedEventArgs() { Index = images.Count - 1, ImageData = image });
                                }
                                stream.Close();
                            }
                        }
                    }
                    catch { }
                });
                SearchFinished(this, EventArgs.Empty);
            });
        }
    }
}
