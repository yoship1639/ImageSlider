using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlider
{
    public class PluginLoader
    {
        /// <summary>
        /// 指定パスにあるプラグインを読み込み、配列で返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T[] LoadPlugins<T>(string path)
        {
            List<T> plugins = new List<T>();
            if (!Directory.Exists(path)) return plugins.ToArray();
            // ディレクトリ内のDLLファイルパスを取得
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                // ファイルパスからアセンブリを読み込む
                Assembly asm = Assembly.LoadFrom(dll);
                // アセンブリで定義されている型を取得
                foreach (Type type in asm.GetTypes())
                {
                    // 非クラス型、非パブリック型、抽象クラスはスキップ
                    if (!type.IsClass || !type.IsPublic || type.IsAbstract) continue;
                    // 型に実装されているインターフェイスから T を取得
                    Type t = type.GetInterfaces().FirstOrDefault((_t) => _t == typeof(T));
                    // default(IHogePlugin) と等しい場合は未実装なのでスキップ
                    if (t == null) continue;
                    // 取得した型のインスタンスを作成
                    object obj = Activator.CreateInstance(type);
                    plugins.Add((T)obj);
                }
            }
            return plugins.ToArray();
        }
    }
}
