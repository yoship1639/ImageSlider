namespace ImageSlider
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_colorSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_smooth = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_all = new System.Windows.Forms.TabPage();
            this.button_downloadFolderChange = new System.Windows.Forms.Button();
            this.textBox_downloadFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_key = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_keySelect_prev = new System.Windows.Forms.TextBox();
            this.textBox_keySelect_next = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_keySelect_save = new System.Windows.Forms.TextBox();
            this.tabPage_search = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox_subFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_all.SuspendLayout();
            this.tabPage_key.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage_search.SuspendLayout();
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(188, 12);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 25);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
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
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "滑らかにスライド";
            // 
            // checkBox_smooth
            // 
            this.checkBox_smooth.AutoSize = true;
            this.checkBox_smooth.Location = new System.Drawing.Point(188, 83);
            this.checkBox_smooth.Name = "checkBox_smooth";
            this.checkBox_smooth.Size = new System.Drawing.Size(15, 14);
            this.checkBox_smooth.TabIndex = 10;
            this.checkBox_smooth.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_all);
            this.tabControl1.Controls.Add(this.tabPage_key);
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
            this.tabPage_all.Controls.Add(this.checkBox_subFolder);
            this.tabPage_all.Controls.Add(this.label12);
            this.tabPage_all.Controls.Add(this.button_downloadFolderChange);
            this.tabPage_all.Controls.Add(this.textBox_downloadFolder);
            this.tabPage_all.Controls.Add(this.label6);
            this.tabPage_all.Controls.Add(this.label2);
            this.tabPage_all.Controls.Add(this.checkBox_smooth);
            this.tabPage_all.Controls.Add(this.numericUpDown1);
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
            // button_downloadFolderChange
            // 
            this.button_downloadFolderChange.Location = new System.Drawing.Point(397, 116);
            this.button_downloadFolderChange.Name = "button_downloadFolderChange";
            this.button_downloadFolderChange.Size = new System.Drawing.Size(35, 27);
            this.button_downloadFolderChange.TabIndex = 13;
            this.button_downloadFolderChange.Text = "...";
            this.button_downloadFolderChange.UseVisualStyleBackColor = true;
            this.button_downloadFolderChange.Click += new System.EventHandler(this.button_downloadFolderChange_Click);
            // 
            // textBox_downloadFolder
            // 
            this.textBox_downloadFolder.Location = new System.Drawing.Point(188, 117);
            this.textBox_downloadFolder.Name = "textBox_downloadFolder";
            this.textBox_downloadFolder.ReadOnly = true;
            this.textBox_downloadFolder.Size = new System.Drawing.Size(203, 25);
            this.textBox_downloadFolder.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "画像の保存場所";
            // 
            // tabPage_key
            // 
            this.tabPage_key.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_key.Controls.Add(this.label11);
            this.tabPage_key.Controls.Add(this.label7);
            this.tabPage_key.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_key.Location = new System.Drawing.Point(4, 27);
            this.tabPage_key.Name = "tabPage_key";
            this.tabPage_key.Size = new System.Drawing.Size(438, 366);
            this.tabPage_key.TabIndex = 2;
            this.tabPage_key.Text = "ショートカットキー";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(308, 18);
            this.label11.TabIndex = 2;
            this.label11.Text = "テキストボックス上で指定したいキーを押してください";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "ショートカットキーの設定を行います";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_keySelect_prev, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_keySelect_next, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_keySelect_save, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 156);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_keySelect_prev
            // 
            this.textBox_keySelect_prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_keySelect_prev.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_keySelect_prev.Location = new System.Drawing.Point(219, 66);
            this.textBox_keySelect_prev.Name = "textBox_keySelect_prev";
            this.textBox_keySelect_prev.Size = new System.Drawing.Size(209, 25);
            this.textBox_keySelect_prev.TabIndex = 5;
            this.textBox_keySelect_prev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keySelect);
            // 
            // textBox_keySelect_next
            // 
            this.textBox_keySelect_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_keySelect_next.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_keySelect_next.Location = new System.Drawing.Point(219, 35);
            this.textBox_keySelect_next.Name = "textBox_keySelect_next";
            this.textBox_keySelect_next.Size = new System.Drawing.Size(209, 25);
            this.textBox_keySelect_next.TabIndex = 4;
            this.textBox_keySelect_next.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keySelect);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "画像の保存";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "次の画像に進む";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "前の画像に戻る";
            // 
            // textBox_keySelect_save
            // 
            this.textBox_keySelect_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_keySelect_save.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_keySelect_save.Location = new System.Drawing.Point(219, 4);
            this.textBox_keySelect_save.Name = "textBox_keySelect_save";
            this.textBox_keySelect_save.Size = new System.Drawing.Size(209, 25);
            this.textBox_keySelect_save.TabIndex = 3;
            this.textBox_keySelect_save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keySelect);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(236, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "保存時に検索ワードでサブフォルダを作る";
            // 
            // checkBox_subFolder
            // 
            this.checkBox_subFolder.AutoSize = true;
            this.checkBox_subFolder.Location = new System.Drawing.Point(286, 165);
            this.checkBox_subFolder.Name = "checkBox_subFolder";
            this.checkBox_subFolder.Size = new System.Drawing.Size(15, 14);
            this.checkBox_subFolder.TabIndex = 15;
            this.checkBox_subFolder.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_all.ResumeLayout(false);
            this.tabPage_all.PerformLayout();
            this.tabPage_key.ResumeLayout(false);
            this.tabPage_key.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage_search.ResumeLayout(false);
            this.tabPage_search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_colorSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_smooth;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_all;
        private System.Windows.Forms.TabPage tabPage_search;
        private System.Windows.Forms.Button button_downloadFolderChange;
        private System.Windows.Forms.TextBox textBox_downloadFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage_key;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_keySelect_prev;
        private System.Windows.Forms.TextBox textBox_keySelect_next;
        private System.Windows.Forms.TextBox textBox_keySelect_save;
        private System.Windows.Forms.CheckBox checkBox_subFolder;
        private System.Windows.Forms.Label label12;
    }
}