﻿using System;
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

namespace GoogleImageSearchAPI
{
    public partial class GoogleImageSearchAPI :
        UserControl,
        IImageSearchAPI
    {
        public string APIName { get { return "GoogleImageSearch"; } }

        /// <summary>
        /// Params内訳
        /// 0: int   拡張子
        /// 1: string   検索するサイト
        /// 2: bool   色
        /// 3: int   サイズ
        /// 4: int   安全性
        /// </summary>

        string[] extensionNames =
        {
            "",
            "jpg",
            "png",
            "bmp",
            "gif"
        };

        string[] sizeNames =
        {
            "",
            "icon",
            "small",
            "medium",
            "large",
            "xlarge",
            "xxlarge",
            "huge"
        };

        string[] safeNames =
        {
            "active",
            "",
            "off"
        };

        public object[] Params
        {
            get
            {
                return new object[]
                {
                    comboBox1.SelectedIndex,
                    textBox1.Text,
                    checkBox1.Checked,
                    comboBox2.SelectedIndex,
                    comboBox3.SelectedIndex,
                };
            }
            set
            {
                comboBox1.SelectedIndex = Clip((int)value[0], 0, 4);
                textBox1.Text = value[1] as string;
                checkBox1.Checked = (bool)value[2];
                comboBox2.SelectedIndex = Clip((int)value[3], 0, 7);
                comboBox3.SelectedIndex = Clip((int)value[4], 0, 2);
            }
        }

        private int Clip(int value, int min, int max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            return value;
        }

        public object[] DefaultParams
        {
            get
            {
                return new object[]
                {
                    0,
                    "",
                    false,
                    3,
                    0,
                };
            }
        }

        public GoogleImageSearchAPI()
        {
            InitializeComponent();

            Params = DefaultParams;
        }

        public ImageData[] ImageDatas { get { return images.ToArray(); } }

        private List<ImageData> images = new List<ImageData>();

        public event EventHandler SearchError = delegate { };
        public event EventHandler SearchFinished = delegate { };
        public event ImageLoadedEventHandler ImageLoaded = delegate { };

        public void Search(string query)
        {
            images.Clear();
            Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 8, i =>
                {
                    GoogleImageSearchAPIJsonData data = null;
                    try
                    {
                        data = search(query, i * 8);

                        if (data.responseStatus == 200)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                try
                                {
                                    string url = data.responseData.results[j].unescapedUrl;
                                    var wc = new System.Net.WebClient();
                                    Stream stream = wc.OpenRead(url);
                                    var bitmap = new System.Drawing.Bitmap(stream);
                                    stream.Close();

                                    /*
                                    var idx = data.responseData.results[j].url.LastIndexOf('/');
                                    if (idx < 0) idx = 0;
                                    var sub = data.responseData.results[j].url.Substring(idx + 1);

                                    var idx1 = sub.LastIndexOf(":large");
                                    var idx2 = sub.LastIndexOf("-large");
                                    if(idx1 > 0)
                                    {
                                        sub = sub.Substring(0, idx1);
                                    }
                                    else if (idx2 > 0)
                                    {
                                        sub = sub.Substring(0, idx2);
                                    }
                                
                                    var subDot = sub.LastIndexOf('.');
                                    if (subDot == -1)
                                    {
                                        sub += "." + GetFileFormat(bitmap);
                                    }*/

                                    //Shift-JISでURLデコードする
                                    //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
                                    //string urlDecSjis = System.Web.HttpUtility.UrlDecode(sub, enc);

                                    var image = new ImageData()
                                    {
                                        Bitmap = bitmap,
                                        FileName = query + "_" + i + "_" + j + "." + GetFileFormat(bitmap),
                                        SourceURL = data.responseData.results[j].originalContextUrl,
                                    };
                                
                                    lock (images)
                                    {
                                        images.Add(image);
                                        ImageLoaded(this, new ImageLoadedEventArgs() { Index = images.Count - 1, ImageData = image });
                                    }
                                
                                }
                                catch { }
                            }
                        }
                    }
                    catch
                    {
                    }
                    
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

        private GoogleImageSearchAPIJsonData search(string query, int start)
        {
            query = query.Replace("　", " ");
            // スペースで区切る
            var words = query.Split(' ');

            // Httpエンコード
            var httpWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                httpWords[i] = HttpUtility.HtmlEncode(words[i]);
            }

            //ダウンロード元のURLの作成
            StringBuilder sb = new StringBuilder();
            sb.Append("http://ajax.googleapis.com/ajax/services/search/images?v=1.0&rsz=8");
            // 拡張子の指定があったら
            if (comboBox1.SelectedIndex != 0) sb.Append("&as_filetype=" + extensionNames[comboBox1.SelectedIndex]);
            // 検索するサイトの指定があったら
            if (!string.IsNullOrWhiteSpace(textBox1.Text)) sb.Append("&as_sitesearch=" + textBox1.Text);
            // 色の指定があったら
            if (checkBox1.Checked) sb.Append("&imgc=gray");
            // サイズの指定があったら
            if (comboBox2.SelectedIndex != 0) sb.Append("&imgsz=" + sizeNames[comboBox2.SelectedIndex]);
            // 安全性の指定があったら
            if (comboBox3.SelectedIndex != 0) sb.Append("&safe=" + safeNames[comboBox3.SelectedIndex]);

            sb.Append("&start=" + start + "&q=");
            foreach (var word in httpWords)
            {
                sb.Append(word);
                if (word != httpWords[httpWords.Length - 1]) sb.Append("+");
            }

            string html = null;
            //WebClientを作成
            using (var wc = new System.Net.WebClient())
            {
                //文字コードを指定
                //wc.Encoding = Encoding.GetEncoding("Shift_JIS");
                wc.Encoding = Encoding.UTF8;
                //データを文字列としてダウンロードする
                html = wc.DownloadString(sb.ToString());
            }
            System.Diagnostics.Debug.WriteLine(html);

            //（2）DataContractJsonSerializerをインスタンス化
            var serializer = new DataContractJsonSerializer(typeof(GoogleImageSearchAPIJsonData));

            //（3）JSONデータを文字列からバイト配列に変換
            var jsonBytes = Encoding.UTF8.GetBytes(html);

            //（4）バイト配列を読み込むMemoryStreamクラスを定義
            var sr = new MemoryStream(jsonBytes);

            //（5）ReadObjectメソッドでJSONデータを.NETオブジェクトに変換
            return (GoogleImageSearchAPIJsonData)serializer.ReadObject(sr);
        }

        [DataContract]
        public class GoogleImageSearchAPIJsonData
        {
            [DataMember]
            public ResponseData responseData { get; set; }

            [DataMember]
            public string responseDetails { get; set; }

            [DataMember]
            public int responseStatus { get; set; }
        }

        [DataContract]
        public class ResponseData
        {
            [DataMember]
            public ResultImageData[] results { get; set; }

            [DataMember]
            public CursorData cursor { get; set; }
        }

        [DataContract]
        public class ResultImageData
        {
            [DataMember]
            public string GsearchResultClass { get; set; }

            [DataMember]
            public string width { get; set; }

            [DataMember]
            public string height { get; set; }

            [DataMember]
            public string imageId { get; set; }

            [DataMember]
            public string tbWidth { get; set; }

            [DataMember]
            public string tbHeight { get; set; }

            [DataMember]
            public string unescapedUrl { get; set; }

            [DataMember]
            public string url { get; set; }

            [DataMember]
            public string visibleUrl { get; set; }

            [DataMember]
            public string title { get; set; }

            [DataMember]
            public string titleNoFormatting { get; set; }

            [DataMember]
            public string originalContextUrl { get; set; }

            [DataMember]
            public string content { get; set; }

            [DataMember]
            public string contentNoFormatting { get; set; }

            [DataMember]
            public string tbUrl { get; set; }
        }

        [DataContract]
        public class CursorData
        {
            [DataMember]
            public PageData[] pages { get; set; }

            [DataMember]
            public string estimatedResultCount { get; set; }

            [DataMember]
            public int currentPageIndex { get; set; }

            [DataMember]
            public string moreResultsUrl { get; set; }
        }

        [DataContract]
        public class PageData
        {
            [DataMember]
            public string start { get; set; }

            [DataMember]
            public int label { get; set; }
        }
    }
}
