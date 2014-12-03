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

namespace TwitterImageSearchAPI
{
    public partial class TwitterImageSearchAPI : 
        UserControl,
        IImageSearchAPI
    {
        List<ImageData> imageDatas = new List<ImageData>();

        public TwitterImageSearchAPI()
        {
            InitializeComponent();
        }

        public string APIName { get { return "TwitterAPI"; } }

        public object[] Params
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object[] DefaultParams
        {
            get { throw new NotImplementedException(); }
        }

        public ImageData[] ImageDatas
        {
            get { return imageDatas.ToArray(); }
        }

        public int ImageCount
        {
            get { return imageDatas.Count; }
        }

        public event EventHandler SearchError = delegate { };
        public event EventHandler SearchFinished = delegate { };
        public event ImageLoadedEventHandler ImageLoaded = delegate { };

        CoreTweet.Tokens tokens = null;

        public void Search(string query)
        {
            imageDatas.Clear();
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

                // 検索し、結果を取得
                var result = tokens.Search.Tweets(new Dictionary<string, object>()
                {
                    {"q", "filter:images http " + query},
                    {"include_entities", true},
                    {"count", 100},
                });
            });
            

            
        }

        public ImageData GetImageData(int index)
        {
            throw new NotImplementedException();
        }
    }
}
