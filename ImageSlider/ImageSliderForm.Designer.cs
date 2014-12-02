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
            this.panel_menu = new System.Windows.Forms.Panel();
            this.button_windowStateChange = new System.Windows.Forms.Button();
            this.button_config = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.pictureBox_search = new System.Windows.Forms.PictureBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.pictureBox_sizeChange = new System.Windows.Forms.PictureBox();
            this.pictureBox_showImage = new System.Windows.Forms.PictureBox();
            this.panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sizeChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_showImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            // pictureBox_sizeChange
            // 
            this.pictureBox_sizeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_sizeChange.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_sizeChange.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBox_sizeChange.Image = global::ImageSlider.Properties.Resources.size2;
            this.pictureBox_sizeChange.Location = new System.Drawing.Point(456, 456);
            this.pictureBox_sizeChange.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_sizeChange.Name = "pictureBox_sizeChange";
            this.pictureBox_sizeChange.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_sizeChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_sizeChange.TabIndex = 1;
            this.pictureBox_sizeChange.TabStop = false;
            this.pictureBox_sizeChange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseDown);
            this.pictureBox_sizeChange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseMove);
            this.pictureBox_sizeChange.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_sizeChange_MouseUp);
            // 
            // pictureBox_showImage
            // 
            this.pictureBox_showImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_showImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_showImage.Name = "pictureBox_showImage";
            this.pictureBox_showImage.Size = new System.Drawing.Size(480, 480);
            this.pictureBox_showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_showImage.TabIndex = 2;
            this.pictureBox_showImage.TabStop = false;
            this.pictureBox_showImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pictureBox_showImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pictureBox_showImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // ImageSliderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Controls.Add(this.pictureBox_sizeChange);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.pictureBox_showImage);
            this.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 240);
            this.Name = "ImageSliderForm";
            this.ShowIcon = false;
            this.Text = "ImageSlider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageSliderForm_FormClosing);
            this.panel_menu.ResumeLayout(false);
            this.panel_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sizeChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_showImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.PictureBox pictureBox_search;
        private System.Windows.Forms.PictureBox pictureBox_sizeChange;
        private System.Windows.Forms.PictureBox pictureBox_showImage;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Button button_windowStateChange;

    }
}

