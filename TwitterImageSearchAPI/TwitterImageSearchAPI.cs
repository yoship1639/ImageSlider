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
using System.Drawing.Imaging;

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

            Params = DefaultParams;
        }

        public string APIName { get { return "TwitterAPI"; } }

        /// <summary>
        /// 0: int 検索方法 0:mixed 1:recent 2:popular
        /// 1: int 検索数 count
        /// 2: bool いつからを使うか
        /// 3: int いつから（年） YYYY-MM-DD
        /// 4: int いつから（月）
        /// 5: int いつから（日）
        /// 6: bool since_idを使うか
        /// 7: int since_id
        /// 8: bool max_idを使うか
        /// 9: int max_id
        /// </summary>

        string[] SearchMethods =
        {
            "mixed",
            "recent",
            "popular",
        };

        public object[] Params
        {
            get
            {
                return new object[]
                {
                    comboBox1.SelectedIndex,
                    numericUpDown1.Value,
                    dateTimePicker1.Checked,
                    dateTimePicker1.Value.Year,
                    dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day,
                    checkBox1.Checked,
                    numericUpDown2.Value,
                    checkBox2.Checked,
                    numericUpDown3.Value,
                };
            }
            set
            {
                comboBox1.SelectedIndex = (int)value[0];
                numericUpDown1.Value = (decimal)value[1];
                dateTimePicker1.Checked = (bool)value[2];
                dateTimePicker1.Value = new DateTime((int)value[3], (int)value[4], (int)value[5]);
                checkBox1.Checked = (bool)value[6];
                numericUpDown2.Value = (decimal)value[7];
                checkBox2.Checked = (bool)value[8];
                numericUpDown3.Value = (decimal)value[9];
            }
        }

        public object[] DefaultParams
        {
            get
            {
                return new object[]
                {
                    0,
                    (decimal)100,
                    false,
                    2007,
                    1,
                    1,
                    false,
                    (decimal)1,
                    false,
                    (decimal)10000,
                };
            }
        }

        public ImageData[] ImageDatas
        {
            get { return images.ToArray(); }
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
                var dic = new Dictionary<string, object>();
                dic.Add("q", "filter:images " + word);
                dic.Add("include_entities", true);
                dic.Add("count", (int)numericUpDown1.Value);
                if (comboBox1.SelectedIndex > 0)
                {
                    dic.Add("result_type", SearchMethods[comboBox1.SelectedIndex]);
                }
                if (dateTimePicker1.Checked)
                {
                    var date = string.Format("{0:0000}-{1:00}-{2:00}", dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    dic.Add("until", date);
                }
                if (checkBox1.Checked) dic.Add("since_id", numericUpDown2.Value);
                if (checkBox2.Checked) dic.Add("max_id", numericUpDown3.Value);
                CoreTweet.SearchResult result = null;
                try
                {
                    result = tokens.Search.Tweets(dic);
                }
                catch
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
                                var wc = new System.Net.WebClient();
                                Stream stream = wc.OpenRead(m.MediaUrl.AbsoluteUri);

                                var idx = m.MediaUrl.LocalPath.LastIndexOf('/');
                                if (idx < 0) idx = 0;
                                var sub = m.MediaUrl.LocalPath.Substring(idx + 1);

                                var idx1 = sub.LastIndexOf(":large");
                                var idx2 = sub.LastIndexOf("-large");
                                if (idx1 > 0)
                                {
                                    sub = sub.Substring(0, idx1);
                                }
                                else if (idx2 > 0)
                                {
                                    sub = sub.Substring(0, idx2);
                                }
                                var bitmap = new System.Drawing.Bitmap(stream);
                                if (sub.LastIndexOf('.') == -1)
                                {
                                    sub += "." + GetFileFormat(bitmap);
                                }

                                var image = new ImageData()
                                {
                                    Bitmap = bitmap,
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

        static string GetFileFormat(Image img)
        {
            try
            {
                foreach (ImageCodecInfo ici in ImageCodecInfo.GetImageDecoders())
                {
                    if (ici.FormatID == img.RawFormat.Guid)
                        //該当するFormatDescriptionを返します。
                        if (ici.FormatDescription == "BMP") return "bmp";
                        else if (ici.FormatDescription == "JPEG") return "jpg";
                        else if (ici.FormatDescription == "GIF") return "gif";
                        else if (ici.FormatDescription == "TIFF") return "tif";
                        else if (ici.FormatDescription == "PNG") return "png";
                        else return ici.FormatDescription;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = checkBox2.Checked;
        }
    }
}
