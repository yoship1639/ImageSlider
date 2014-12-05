using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace ImageSlider
{
    public class Serializer
    {
        public static T XmlDeserialize<T>(string filename)
        {
            //XmlSerializerオブジェクトの作成
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            //ファイルを開く
            var sr =new System.IO.StreamReader(filename, new System.Text.UTF8Encoding(false));
            //XMLファイルから読み込み、逆シリアル化する
            T obj = (T)serializer.Deserialize(sr);
            //閉じる
            sr.Close();

            return obj;
        }

        public static void XmlSerialize<T>(string filename, T obj)
        {
            //XmlSerializerオブジェクトの作成
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            //ファイルを開く
            var sw = new System.IO.StreamWriter(filename, false, new System.Text.UTF8Encoding(false));
            //XMLファイルから読み込み、逆シリアル化する
            serializer.Serialize(sw, obj);
            //閉じる
            sw.Close();
        }
    }
}
