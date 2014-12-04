﻿using System;
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
            get { return checkBox_smooth.Checked; }
            set { checkBox_smooth.Checked = value; }
        }

        public string DowloadFolder 
        {
            get { return textBox_downloadFolder.Text; }
            set { textBox_downloadFolder.Text = value; }
        }

        public bool CreateSubFolder
        {
            get { return checkBox_subFolder.Checked; }
            set { checkBox_subFolder.Checked = value; }
        }

        /*SlideImage.ImageSizeMode[] sizeModes = 
        {
            SlideImage.ImageSizeMode.Normal,
            SlideImage.ImageSizeMode.Stretch,
            SlideImage.ImageSizeMode.Center,
            SlideImage.ImageSizeMode.Zoom,
            SlideImage.ImageSizeMode.Fit
        };*/

        public SlideImage.ImageSizeMode SizeMode
        {
            get
            {
                return (SlideImage.ImageSizeMode)comboBox2.SelectedIndex;
            }
            set
            {
                comboBox2.SelectedIndex = (int)value;
            }
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

        private void button_downloadFolderChange_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "画像を保存するフォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = textBox_downloadFolder.Text;
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textBox_downloadFolder.Text = fbd.SelectedPath;
            }
        }

        private void keySelect(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            var c = e.KeyCode;
            var nFlag = 
                c == Keys.D0 || 
                c == Keys.D1 || 
                c == Keys.D2 ||
                c == Keys.D3 || 
                c == Keys.D4 ||
                c == Keys.D5 ||
                c ==  Keys.D6 ||
                c ==  Keys.D7 || 
                c ==  Keys.D8 || 
                c ==  Keys.D9;

            var fFlag = e.KeyCode.HasFlag(
                Keys.F1 | Keys.F2 | Keys.F3 | Keys.F4 | Keys.F5 | Keys.F6 | Keys.F7 | Keys.F8 | Keys.F9 | Keys.F10 | Keys.F11 | Keys.F12
                );

            var iFlag = e.KeyCode.HasFlag(
                Keys.A | Keys.B | Keys.C | Keys.D | Keys.E | Keys.F | Keys.G | Keys.H | Keys.I | Keys.J | Keys.K | Keys.L | Keys.M | Keys.N | Keys.O | Keys.P | Keys.Q | Keys.R | Keys.S | Keys.T | Keys.U | Keys.V | Keys.W | Keys.X | Keys.Y | Keys.Z
                );

            if (nFlag)
            {
                textbox.Text = e.KeyCode.ToString();
            }
            else if (fFlag)
            {
                textbox.Text = e.KeyCode.ToString();
            }
            else if (iFlag)
            {
                textbox.Text = e.KeyCode.ToString();
            }
        }
    }
}
