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

namespace NicoSeigaImageSearchAPI
{
    public partial class NicoSeigaImageSearchAPI : 
        UserControl,
        IImageSearchAPI
    {
        private List<ImageData> imageDatas = new List<ImageData>();

        public NicoSeigaImageSearchAPI()
        {
            InitializeComponent();
        }

        public string APIName { get { return "NicoSeigaAPI"; } }

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
            get { throw new NotImplementedException(); }
        }

        public int ImageCount
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler SearchError;

        public event EventHandler SearchFinished;

        public event ImageLoadedEventHandler ImageLoaded;

        public void Search(string query)
        {
            throw new NotImplementedException();
        }

        public ImageData GetImageData(int index)
        {
            throw new NotImplementedException();
        }
    }
}
