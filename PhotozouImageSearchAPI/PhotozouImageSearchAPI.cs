using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

using ImageSearchAPILib;
using System.Drawing.Imaging;

namespace PhotozouImageSearchAPI
{
    public partial class PhotozouImageSearchAPI :
        UserControl,
        IImageSearchAPI
    {
        List<ImageData> images = new List<ImageData>();

        public PhotozouImageSearchAPI()
        {
            InitializeComponent();

            Params = DefaultParams;
        }

        public string APIName { get { return "PhotozouAPI"; } }

        /// <summary>
        /// 0: decimal limit
        /// 1: decimal offset
        /// 2: int copyright 
        /// 3: int copyright_commercial
        /// 4: int copyright_modifications
        /// </summary>

        public object[] Params
        {
            get
            {
                return new object[]
                {
                    numericUpDown_searchNum.Value,
                    numericUpDown_offset.Value,
                    comboBox_copyright.SelectedIndex,
                    comboBox_commercial.SelectedIndex,
                    comboBox_modification.SelectedIndex,
                };
            }
            set
            {
                numericUpDown_searchNum.Value = (decimal)value[0];
                numericUpDown_offset.Value = (decimal)value[1];
                comboBox_copyright.SelectedIndex = (int)value[2];
                comboBox_commercial.SelectedIndex = (int)value[3];
                comboBox_modification.SelectedIndex = (int)value[4];
            }
        }

        public object[] DefaultParams
        {
            get
            {
                return new object[]
                {
                    (decimal)100,
                    (decimal)0,
                    0,
                    0,
                    0
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
                // htmlエンコード
                var word = HttpUtility.HtmlEncode(query);

                // 検索クエリの作成
                StringBuilder sb = new StringBuilder();
                sb.Append("https://api.photozou.jp/rest/search_public.json?keyword=");
                sb.Append(word);
                sb.Append("&limit=");
                sb.Append(numericUpDown_searchNum.Value);
                sb.Append("&offset=");
                sb.Append(numericUpDown_offset.Value);
                if (comboBox_copyright.SelectedIndex > 0)
                {
                    if (comboBox_copyright.SelectedIndex == 1) sb.Append("&copyright=normal");
                    else
                    {
                        sb.Append("&copyright=creativecommons");
                        if (comboBox_commercial.SelectedIndex == 1) sb.Append("&copyright_commercial=no");
                        if (comboBox_modification.SelectedIndex == 1) sb.Append("&copyright_modifications=no");
                        else if (comboBox_modification.SelectedIndex == 2) sb.Append("&copyright_modifications=share");
                    }
                }

                PhotozouJsonData data = null;
                try
                {
                    string html = null;
                    //WebClientを作成
                    using (var wc = new System.Net.WebClient())
                    {
                        //文字コードを指定
                        wc.Encoding = Encoding.UTF8;
                        //データを文字列としてダウンロードする
                        html = wc.DownloadString(sb.ToString());
                    }

                    //（2）DataContractJsonSerializerをインスタンス化
                    var serializer = new DataContractJsonSerializer(typeof(PhotozouJsonData));

                    //（3）JSONデータを文字列からバイト配列に変換
                    var jsonBytes = Encoding.Unicode.GetBytes(html);

                    //（4）バイト配列を読み込むMemoryStreamクラスを定義
                    var sr = new MemoryStream(jsonBytes);

                    //（5）ReadObjectメソッドでJSONデータを.NETオブジェクトに変換
                    data = (PhotozouJsonData)serializer.ReadObject(sr);
                }
                catch
                {
                    SearchError(this, EventArgs.Empty);
                    return;
                }

                if (data.stat != "ok")
                {
                    SearchError(this, EventArgs.Empty);
                    return;
                }

                Parallel.For(0, data.info.photo_num, i =>
                {
                    try
                    {
                        string url = data.info.photo[i].original_image_url;
                        var wc = new System.Net.WebClient();
                        Stream stream = wc.OpenRead(url);
                        var bitmap = new System.Drawing.Bitmap(stream);
                        stream.Close();

                        var ext = GetFileFormat(bitmap);

                        var image = new ImageData()
                        {
                            Bitmap = bitmap,
                            FileName = data.info.photo[i].photo_id + "." + ext,
                            SourceURL = data.info.photo[i].url,
                        };

                        lock (images)
                        {
                            images.Add(image);
                            ImageLoaded(this, new ImageLoadedEventArgs() { Index = images.Count - 1, ImageData = image });
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

        private void comboBox_copyright_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_copyright.SelectedIndex == 2)
            {
                comboBox_commercial.Enabled = true;
                comboBox_modification.Enabled = true;
            }
            else
            {
                comboBox_commercial.Enabled = false;
                comboBox_modification.Enabled = false;
            }
        }

        [DataContract]
        public class PhotozouJsonData
        {
            [DataMember]
            public string stat { get; set; }

            [DataMember]
            public InfoData info { get; set; }

            [DataMember]
            public ErrorData err { get; set; }
        }

        [DataContract]
        public class InfoData
        {
            [DataMember]
            public int photo_num { get; set; }

            [DataMember]
            public PhotoData[] photo { get; set; }
        }

        [DataContract]
        public class ErrorData
        {
            [DataMember]
            public string code { get; set; }

            [DataMember]
            public string msg { get; set; }
        }

        [DataContract]
        public class PhotoData
        {
            [DataMember]
            public int photo_id { get; set; }

            [DataMember]
            public int user_id { get; set; }

            [DataMember]
            public int album_id { get; set; }

            [DataMember]
            public string photo_title { get; set; }

            [DataMember]
            public int favorite_num { get; set; }

            [DataMember]
            public int comment_num { get; set; }

            [DataMember]
            public int view_num { get; set; }

            [DataMember]
            public string copyright { get; set; }

            [DataMember]
            public string copyright_commercial { get; set; }

            [DataMember]
            public string copyright_modifications { get; set; }

            [DataMember]
            public int original_height { get; set; }

            [DataMember]
            public int original_width { get; set; }

            [DataMember]
            public GeoData geo { get; set; }

            [DataMember]
            public string date { get; set; }

            [DataMember]
            public string result_time { get; set; }

            [DataMember]
            public string url { get; set; }

            [DataMember]
            public string image_url { get; set; }

            [DataMember]
            public string original_image_url { get; set; }

            [DataMember]
            public string thumbnail_image_url { get; set; }

            [DataMember]
            public string large_tag { get; set; }

            [DataMember]
            public string medium_tag { get; set; }
        }

        [DataContract]
        public class GeoData
        {
            [DataMember]
            public double latitude { get; set; }

            [DataMember]
            public double longitude { get; set; }
        }
    }
}
