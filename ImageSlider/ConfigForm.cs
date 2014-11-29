using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageSearchAPILib;

namespace ImageSlider
{
    public partial class ConfigForm : Form
    {
        public string APIName
        {
            get { return comboBox1.SelectedItem as string; }
        }

        public int SlideTime
        { 
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public Color MenuColor
        {
            get { return button_colorSelect.BackColor; }
            set { button_colorSelect.BackColor = value; }
        }

        public bool SmoothSlide
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        IImageSearchAPI[] APIs;

        public ConfigForm(IImageSearchAPI[] apis, IImageSearchAPI current)
        {
            InitializeComponent();

            APIs = apis;

            for (int i = 0; i < apis.Length; i++)
            {
                comboBox1.Items.Add(apis[i].APIName);
            }
            comboBox1.SelectedItem = comboBox1.SelectedIndex = Array.FindIndex(apis, (api)=>api == current);
            setAPI(current);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setAPI(APIs[comboBox1.SelectedIndex]);
        }

        void setAPI(IImageSearchAPI api)
        {
            panel1.Controls.Clear();
            var ctr = api as UserControl;
            if (ctr != null)
            {
                panel1.Controls.Add(ctr);
            }
            
        }

        private void button_colorSelect_Click(object sender, EventArgs e)
        {
            // ColorDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            ColorDialog colorDialog = new ColorDialog();

            // 初期選択する色を設定する
            colorDialog.Color = button_colorSelect.BackColor;

            // カスタム カラーを表示した状態にする (初期値 false)
            //colorDialog.FullOpen = true;

            // 使用可能なすべての色を基本セットに表示する (初期値 false)
            colorDialog.AnyColor = true;

            // 純色のみ表示する (初期値 false)
            //colorDialog.SolidColorOnly = true;

            // カスタム カラーを任意の色で設定する
            //colorDialog1.CustomColors = new int[] { 0x8040FF, 0xFF8040, 0x80FF40, 0x4080FF };

            // [ヘルプ] ボタンを表示する
            //colorDialog1.ShowHelp = true;

            // ダイアログを表示し、戻り値が [OK] の場合は選択した色を textBox1 に適用する
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                button_colorSelect.BackColor = colorDialog.Color;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            colorDialog.Dispose();
        }
    }
}
