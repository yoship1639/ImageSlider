using System;
using System.Drawing;

namespace ImageSearchAPILib
{
    /// <summary>
    /// 画像検索APIが実装すべき機能
    /// </summary>
    public interface IImageSearchAPI
    {
        string APIName { get; }
        object[] Params { get; set; }
        object[] DefaultParams { get; }
        ImageData[] ImageDatas { get; }
        int ImageCount { get; }

        event EventHandler SearchError;
        event EventHandler SearchFinished;
        event ImageLoadedEventHandler ImageLoaded;

        void Search(string query);
    }

    public class ImageData
    {
        public Bitmap Bitmap { get; set; }
        public string FileName { get; set; }
        public string SourceURL { get; set; }
    }

    public delegate void ImageLoadedEventHandler(object sender, ImageLoadedEventArgs e);

    public class ImageLoadedEventArgs
        : EventArgs
    {
        public int Index { get; set; }
        public ImageData ImageData { get; set; }
    }
}
