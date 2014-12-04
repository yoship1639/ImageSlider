﻿namespace ImageSlider
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_slideSecond = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_colorSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_all = new System.Windows.Forms.TabPage();
            this.tabPage_search = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_sizeMode = new System.Windows.Forms.ComboBox();
            this.comboBox_slideMode = new System.Windows.Forms.ComboBox();
            this.tabPage_save = new System.Windows.Forms.TabPage();
            this.checkBox_subFolder = new System.Windows.Forms.CheckBox();
            this.button_downloadFolderChange = new System.Windows.Forms.Button();
            this.textBox_downloadFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_focusDownloadImage = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_slideSecond)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_all.SuspendLayout();
            this.tabPage_search.SuspendLayout();
            this.tabPage_save.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 322);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "使用する検索API";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(392, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "画像の切り替わりに掛かる時間";
            // 
            // numericUpDown_slideSecond
            // 
            this.numericUpDown_slideSecond.Location = new System.Drawing.Point(188, 12);
            this.numericUpDown_slideSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_slideSecond.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_slideSecond.Name = "numericUpDown_slideSecond";
            this.numericUpDown_slideSecond.Size = new System.Drawing.Size(39, 25);
            this.numericUpDown_slideSecond.TabIndex = 5;
            this.numericUpDown_slideSecond.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "メニューバーの色";
            // 
            // button_colorSelect
            // 
            this.button_colorSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button_colorSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_colorSelect.Location = new System.Drawing.Point(188, 43);
            this.button_colorSelect.Name = "button_colorSelect";
            this.button_colorSelect.Size = new System.Drawing.Size(75, 23);
            this.button_colorSelect.TabIndex = 8;
            this.button_colorSelect.UseVisualStyleBackColor = false;
            this.button_colorSelect.Click += new System.EventHandler(this.button_colorSelect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "スライド方法";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_all);
            this.tabControl1.Controls.Add(this.tabPage_save);
            this.tabControl1.Controls.Add(this.tabPage_search);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 397);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage_all
            // 
            this.tabPage_all.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_all.Controls.Add(this.comboBox_slideMode);
            this.tabPage_all.Controls.Add(this.comboBox_sizeMode);
            this.tabPage_all.Controls.Add(this.label7);
            this.tabPage_all.Controls.Add(this.label2);
            this.tabPage_all.Controls.Add(this.numericUpDown_slideSecond);
            this.tabPage_all.Controls.Add(this.label5);
            this.tabPage_all.Controls.Add(this.label3);
            this.tabPage_all.Controls.Add(this.button_colorSelect);
            this.tabPage_all.Controls.Add(this.label4);
            this.tabPage_all.Location = new System.Drawing.Point(4, 27);
            this.tabPage_all.Name = "tabPage_all";
            this.tabPage_all.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_all.Size = new System.Drawing.Size(438, 366);
            this.tabPage_all.TabIndex = 0;
            this.tabPage_all.Text = "全体";
            // 
            // tabPage_search
            // 
            this.tabPage_search.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_search.Controls.Add(this.comboBox1);
            this.tabPage_search.Controls.Add(this.panel1);
            this.tabPage_search.Controls.Add(this.label1);
            this.tabPage_search.Location = new System.Drawing.Point(4, 27);
            this.tabPage_search.Name = "tabPage_search";
            this.tabPage_search.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_search.Size = new System.Drawing.Size(438, 366);
            this.tabPage_search.TabIndex = 1;
            this.tabPage_search.Text = "検索";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "画像表示のサイズモード";
            // 
            // comboBox_sizeMode
            // 
            this.comboBox_sizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sizeMode.FormattingEnabled = true;
            this.comboBox_sizeMode.Items.AddRange(new object[] {
            "左寄せ",
            "ストレッチ",
            "センター",
            "ズーム",
            "フィット"});
            this.comboBox_sizeMode.Location = new System.Drawing.Point(188, 115);
            this.comboBox_sizeMode.Name = "comboBox_sizeMode";
            this.comboBox_sizeMode.Size = new System.Drawing.Size(163, 26);
            this.comboBox_sizeMode.TabIndex = 17;
            // 
            // comboBox_slideMode
            // 
            this.comboBox_slideMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_slideMode.FormattingEnabled = true;
            this.comboBox_slideMode.Items.AddRange(new object[] {
            "瞬時",
            "右にスライド",
            "左にスライド",
            "透過"});
            this.comboBox_slideMode.Location = new System.Drawing.Point(188, 77);
            this.comboBox_slideMode.Name = "comboBox_slideMode";
            this.comboBox_slideMode.Size = new System.Drawing.Size(163, 26);
            this.comboBox_slideMode.TabIndex = 18;
            // 
            // tabPage_save
            // 
            this.tabPage_save.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_save.Controls.Add(this.checkBox_focusDownloadImage);
            this.tabPage_save.Controls.Add(this.checkBox_subFolder);
            this.tabPage_save.Controls.Add(this.button_downloadFolderChange);
            this.tabPage_save.Controls.Add(this.textBox_downloadFolder);
            this.tabPage_save.Controls.Add(this.label6);
            this.tabPage_save.Location = new System.Drawing.Point(4, 27);
            this.tabPage_save.Name = "tabPage_save";
            this.tabPage_save.Size = new System.Drawing.Size(438, 366);
            this.tabPage_save.TabIndex = 2;
            this.tabPage_save.Text = "保存";
            // 
            // checkBox_subFolder
            // 
            this.checkBox_subFolder.AutoSize = true;
            this.checkBox_subFolder.Location = new System.Drawing.Point(11, 63);
            this.checkBox_subFolder.Name = "checkBox_subFolder";
            this.checkBox_subFolder.Size = new System.Drawing.Size(207, 22);
            this.checkBox_subFolder.TabIndex = 20;
            this.checkBox_subFolder.Text = "検索ワードでサブフォルダを作る";
            this.checkBox_subFolder.UseVisualStyleBackColor = true;
            // 
            // button_downloadFolderChange
            // 
            this.button_downloadFolderChange.Location = new System.Drawing.Point(379, 16);
            this.button_downloadFolderChange.Name = "button_downloadFolderChange";
            this.button_downloadFolderChange.Size = new System.Drawing.Size(35, 27);
            this.button_downloadFolderChange.TabIndex = 18;
            this.button_downloadFolderChange.Text = "...";
            this.button_downloadFolderChange.UseVisualStyleBackColor = true;
            // 
            // textBox_downloadFolder
            // 
            this.textBox_downloadFolder.Location = new System.Drawing.Point(143, 17);
            this.textBox_downloadFolder.Name = "textBox_downloadFolder";
            this.textBox_downloadFolder.ReadOnly = true;
            this.textBox_downloadFolder.Size = new System.Drawing.Size(230, 25);
            this.textBox_downloadFolder.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "画像の保存場所";
            // 
            // checkBox_focusDownloadImage
            // 
            this.checkBox_focusDownloadImage.AutoSize = true;
            this.checkBox_focusDownloadImage.Location = new System.Drawing.Point(11, 91);
            this.checkBox_focusDownloadImage.Name = "checkBox_focusDownloadImage";
            this.checkBox_focusDownloadImage.Size = new System.Drawing.Size(171, 22);
            this.checkBox_focusDownloadImage.TabIndex = 21;
            this.checkBox_focusDownloadImage.Text = "保存する画像を赤線で囲む";
            this.checkBox_focusDownloadImage.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(464, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_slideSecond)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_all.ResumeLayout(false);
            this.tabPage_all.PerformLayout();
            this.tabPage_search.ResumeLayout(false);
            this.tabPage_search.PerformLayout();
            this.tabPage_save.ResumeLayout(false);
            this.tabPage_save.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_slideSecond;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_colorSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_all;
        private System.Windows.Forms.TabPage tabPage_search;
        private System.Windows.Forms.ComboBox comboBox_sizeMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_slideMode;
        private System.Windows.Forms.TabPage tabPage_save;
        private System.Windows.Forms.CheckBox checkBox_focusDownloadImage;
        private System.Windows.Forms.CheckBox checkBox_subFolder;
        private System.Windows.Forms.Button button_downloadFolderChange;
        private System.Windows.Forms.TextBox textBox_downloadFolder;
        private System.Windows.Forms.Label label6;
    }
}