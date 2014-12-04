namespace ImageSlider
{
    partial class ImageSliderForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSliderForm));
            this.panel_menu = new System.Windows.Forms.Panel();
            this.label_imageCount = new System.Windows.Forms.Label();
            this.button_windowStateChange = new System.Windows.Forms.Button();
            this.button_config = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.pictureBox_search = new System.Windows.Forms.PictureBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_startStop = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.button_moveSite = new System.Windows.Forms.Button();
            this.sizeChanger1 = new ImageSlider.SizeChanger();
            this.slideImage1 = new ImageSlider.slideImage();
            this.panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel_menu.Controls.Add(this.label_imageCount);
            this.panel_menu.Controls.Add(this.button_windowStateChange);
            this.panel_menu.Controls.Add(this.button_config);
            this.panel_menu.Controls.Add(this.button_close);
            this.panel_menu.Controls.Add(this.pictureBox_search);
            this.panel_menu.Controls.Add(this.textBox_search);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(480, 32);
            this.panel_menu.TabIndex = 0;
            this.panel_menu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.panel_menu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.panel_menu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // label_imageCount
            // 
            this.label_imageCount.AutoSize = true;
            this.label_imageCount.Location = new System.Drawing.Point(214, 7);
            this.label_imageCount.Name = "label_imageCount";
            this.label_imageCount.Size = new System.Drawing.Size(0, 18);
            this.label_imageCount.TabIndex = 5;
            this.label_imageCount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.label_imageCount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.label_imageCount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // button_windowStateChange
            // 
            this.button_windowStateChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_windowStateChange.BackColor = System.Drawing.Color.Transparent;
            this.button_windowStateChange.BackgroundImage = global::ImageSlider.Properties.Resources.maximize;
            this.button_windowStateChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_windowStateChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_windowStateChange.ForeColor = System.Drawing.Color.Transparent;
            this.button_windowStateChange.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_windowStateChange.Location = new System.Drawing.Point(394, 5);
            this.button_windowStateChange.Name = "button_windowStateChange";
            this.button_windowStateChange.Size = new System.Drawing.Size(34, 23);
            this.button_windowStateChange.TabIndex = 4;
            this.button_windowStateChange.UseVisualStyleBackColor = false;
            this.button_windowStateChange.Click += new System.EventHandler(this.button_windowStateChange_Click);
            // 
            // button_config
            // 
            this.button_config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_config.BackColor = System.Drawing.Color.Transparent;
            this.button_config.BackgroundImage = global::ImageSlider.Properties.Resources.config;
            this.button_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_config.ForeColor = System.Drawing.Color.Transparent;
            this.button_config.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_config.Location = new System.Drawing.Point(354, 5);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(34, 23);
            this.button_config.TabIndex = 3;
            this.button_config.UseVisualStyleBackColor = false;
            this.button_config.Click += new System.EventHandler(this.button_config_Click);
            // 
            // button_close
            // 
            this.button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_close.BackColor = System.Drawing.Color.Transparent;
            this.button_close.BackgroundImage = global::ImageSlider.Properties.Resources.close;
            this.button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.ForeColor = System.Drawing.Color.Transparent;
            this.button_close.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_close.Location = new System.Drawing.Point(434, 5);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(34, 23);
            this.button_close.TabIndex = 2;
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // pictureBox_search
            // 
            this.pictureBox_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_search.Image = global::ImageSlider.Properties.Resources.Search;
            this.pictureBox_search.InitialImage = null;
            this.pictureBox_search.Location = new System.Drawing.Point(12, 4);
            this.pictureBox_search.Name = "pictureBox_search";
            this.pictureBox_search.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_search.TabIndex = 1;
            this.pictureBox_search.TabStop = false;
            this.pictureBox_search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pictureBox_search.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pictureBox_search.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_search.Location = new System.Drawing.Point(39, 4);
            this.textBox_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(155, 25);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_search_KeyDown);
            // 
            // button_startStop
            // 
            this.button_startStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_startStop.BackColor = System.Drawing.Color.White;
            this.button_startStop.BackgroundImage = global::ImageSlider.Properties.Resources.stop3;
            this.button_startStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_startStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_startStop.Location = new System.Drawing.Point(10000, 10000);
            this.button_startStop.Name = "button_startStop";
            this.button_startStop.Size = new System.Drawing.Size(42, 35);
            this.button_startStop.TabIndex = 4;
            this.button_startStop.UseVisualStyleBackColor = false;
            this.button_startStop.Click += new System.EventHandler(this.button_startStop_Click);
            this.button_startStop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.slideImage1_KeyDown);
            // 
            // button_download
            // 
            this.button_download.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_download.BackColor = System.Drawing.Color.White;
            this.button_download.BackgroundImage = global::ImageSlider.Properties.Resources.download;
            this.button_download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_download.Location = new System.Drawing.Point(10000, 10000);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(42, 35);
            this.button_download.TabIndex = 3;
            this.button_download.UseVisualStyleBackColor = false;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            this.button_download.KeyDown += new System.Windows.Forms.KeyEventHandler(this.slideImage1_KeyDown);
            // 
            // button_right
            // 
            this.button_right.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_right.BackColor = System.Drawing.Color.White;
            this.button_right.BackgroundImage = global::ImageSlider.Properties.Resources.right;
            this.button_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_right.Location = new System.Drawing.Point(10000, 10000);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(33, 43);
            this.button_right.TabIndex = 6;
            this.button_right.UseVisualStyleBackColor = false;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // button_left
            // 
            this.button_left.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_left.BackColor = System.Drawing.Color.White;
            this.button_left.BackgroundImage = global::ImageSlider.Properties.Resources.left;
            this.button_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_left.Location = new System.Drawing.Point(10000, 10000);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(33, 43);
            this.button_left.TabIndex = 7;
            this.button_left.UseVisualStyleBackColor = false;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_moveSite
            // 
            this.button_moveSite.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_moveSite.BackColor = System.Drawing.Color.White;
            this.button_moveSite.BackgroundImage = global::ImageSlider.Properties.Resources.move;
            this.button_moveSite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_moveSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_moveSite.Location = new System.Drawing.Point(10000, 10000);
            this.button_moveSite.Name = "button_moveSite";
            this.button_moveSite.Size = new System.Drawing.Size(42, 35);
            this.button_moveSite.TabIndex = 8;
            this.button_moveSite.UseVisualStyleBackColor = false;
            this.button_moveSite.Click += new System.EventHandler(this.button_moveSite_Click);
            // 
            // sizeChanger1
            // 
            this.sizeChanger1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeChanger1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sizeChanger1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizeChanger1.Location = new System.Drawing.Point(448, 448);
            this.sizeChanger1.Margin = new System.Windows.Forms.Padding(0);
            this.sizeChanger1.Name = "sizeChanger1";
            this.sizeChanger1.Size = new System.Drawing.Size(32, 32);
            this.sizeChanger1.TabIndex = 9;
            this.sizeChanger1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseDown);
            this.sizeChanger1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseMove);
            this.sizeChanger1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseUp);
            // 
            // slideImage1
            // 
            this.slideImage1.BackColor = System.Drawing.SystemColors.Control;
            this.slideImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slideImage1.ForceImage = null;
            this.slideImage1.ImageDatas = null;
            this.slideImage1.Location = new System.Drawing.Point(0, 0);
            this.slideImage1.Margin = new System.Windows.Forms.Padding(0);
            this.slideImage1.Name = "slideImage1";
            this.slideImage1.Rate = 0F;
            this.slideImage1.Size = new System.Drawing.Size(480, 480);
            this.slideImage1.SizeMode = ImageSlider.slideImage.ImageSizeMode.Zoom;
            this.slideImage1.SlideMode = ImageSlider.slideImage.ImageSlideMode.Slide_Left;
            this.slideImage1.TabIndex = 3;
            this.slideImage1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.slideImage1_KeyDown);
            this.slideImage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.slideImage1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.slideImage1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // ImageSliderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Controls.Add(this.sizeChanger1);
            this.Controls.Add(this.button_moveSite);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_download);
            this.Controls.Add(this.button_startStop);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.slideImage1);
            this.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "ImageSliderForm";
            this.ShowIcon = false;
            this.Text = "ImageSlider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageSliderForm_FormClosing);
            this.panel_menu.ResumeLayout(false);
            this.panel_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.PictureBox pictureBox_search;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Button button_windowStateChange;
        private slideImage slideImage1;
        private System.Windows.Forms.Button button_startStop;
        private System.Windows.Forms.Label label_imageCount;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_moveSite;
        private SizeChanger sizeChanger1;

    }
}

