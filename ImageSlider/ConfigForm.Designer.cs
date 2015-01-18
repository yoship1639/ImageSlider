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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_slideSecond = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_colorSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_all = new System.Windows.Forms.TabPage();
            this.checkBox_showToolTip = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_slideMode = new System.Windows.Forms.ComboBox();
            this.comboBox_sizeMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage_save = new System.Windows.Forms.TabPage();
            this.checkBox_focusDownloadImage = new System.Windows.Forms.CheckBox();
            this.checkBox_subFolder = new System.Windows.Forms.CheckBox();
            this.button_downloadFolderChange = new System.Windows.Forms.Button();
            this.textBox_downloadFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_search = new System.Windows.Forms.TabPage();
            this.toolTip_config = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_slideSecond)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_all.SuspendLayout();
            this.tabPage_save.SuspendLayout();
            this.tabPage_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip_config.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.toolTip_config.SetToolTip(this.comboBox1, resources.GetString("comboBox1.ToolTip"));
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button_ok
            // 
            resources.ApplyResources(this.button_ok, "button_ok");
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Name = "button_ok";
            this.toolTip_config.SetToolTip(this.button_ok, resources.GetString("button_ok.ToolTip"));
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip_config.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // numericUpDown_slideSecond
            // 
            resources.ApplyResources(this.numericUpDown_slideSecond, "numericUpDown_slideSecond");
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
            this.toolTip_config.SetToolTip(this.numericUpDown_slideSecond, resources.GetString("numericUpDown_slideSecond.ToolTip"));
            this.numericUpDown_slideSecond.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip_config.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // button_colorSelect
            // 
            this.button_colorSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.button_colorSelect, "button_colorSelect");
            this.button_colorSelect.Name = "button_colorSelect";
            this.toolTip_config.SetToolTip(this.button_colorSelect, resources.GetString("button_colorSelect.ToolTip"));
            this.button_colorSelect.UseVisualStyleBackColor = false;
            this.button_colorSelect.Click += new System.EventHandler(this.button_colorSelect_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip_config.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage_all);
            this.tabControl1.Controls.Add(this.tabPage_save);
            this.tabControl1.Controls.Add(this.tabPage_search);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage_all
            // 
            this.tabPage_all.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_all.Controls.Add(this.checkBox_showToolTip);
            this.tabPage_all.Controls.Add(this.label8);
            this.tabPage_all.Controls.Add(this.comboBox_slideMode);
            this.tabPage_all.Controls.Add(this.comboBox_sizeMode);
            this.tabPage_all.Controls.Add(this.label7);
            this.tabPage_all.Controls.Add(this.label2);
            this.tabPage_all.Controls.Add(this.numericUpDown_slideSecond);
            this.tabPage_all.Controls.Add(this.label5);
            this.tabPage_all.Controls.Add(this.label3);
            this.tabPage_all.Controls.Add(this.button_colorSelect);
            this.tabPage_all.Controls.Add(this.label4);
            resources.ApplyResources(this.tabPage_all, "tabPage_all");
            this.tabPage_all.Name = "tabPage_all";
            // 
            // checkBox_showToolTip
            // 
            resources.ApplyResources(this.checkBox_showToolTip, "checkBox_showToolTip");
            this.checkBox_showToolTip.Name = "checkBox_showToolTip";
            this.toolTip_config.SetToolTip(this.checkBox_showToolTip, resources.GetString("checkBox_showToolTip.ToolTip"));
            this.checkBox_showToolTip.UseVisualStyleBackColor = true;
            this.checkBox_showToolTip.CheckedChanged += new System.EventHandler(this.checkBox_showToolTip_CheckedChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.toolTip_config.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // comboBox_slideMode
            // 
            this.comboBox_slideMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_slideMode.FormattingEnabled = true;
            this.comboBox_slideMode.Items.AddRange(new object[] {
            resources.GetString("comboBox_slideMode.Items"),
            resources.GetString("comboBox_slideMode.Items1"),
            resources.GetString("comboBox_slideMode.Items2"),
            resources.GetString("comboBox_slideMode.Items3")});
            resources.ApplyResources(this.comboBox_slideMode, "comboBox_slideMode");
            this.comboBox_slideMode.Name = "comboBox_slideMode";
            this.toolTip_config.SetToolTip(this.comboBox_slideMode, resources.GetString("comboBox_slideMode.ToolTip"));
            // 
            // comboBox_sizeMode
            // 
            this.comboBox_sizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sizeMode.FormattingEnabled = true;
            this.comboBox_sizeMode.Items.AddRange(new object[] {
            resources.GetString("comboBox_sizeMode.Items"),
            resources.GetString("comboBox_sizeMode.Items1"),
            resources.GetString("comboBox_sizeMode.Items2"),
            resources.GetString("comboBox_sizeMode.Items3"),
            resources.GetString("comboBox_sizeMode.Items4")});
            resources.ApplyResources(this.comboBox_sizeMode, "comboBox_sizeMode");
            this.comboBox_sizeMode.Name = "comboBox_sizeMode";
            this.toolTip_config.SetToolTip(this.comboBox_sizeMode, resources.GetString("comboBox_sizeMode.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTip_config.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // tabPage_save
            // 
            this.tabPage_save.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_save.Controls.Add(this.checkBox_focusDownloadImage);
            this.tabPage_save.Controls.Add(this.checkBox_subFolder);
            this.tabPage_save.Controls.Add(this.button_downloadFolderChange);
            this.tabPage_save.Controls.Add(this.textBox_downloadFolder);
            this.tabPage_save.Controls.Add(this.label6);
            resources.ApplyResources(this.tabPage_save, "tabPage_save");
            this.tabPage_save.Name = "tabPage_save";
            // 
            // checkBox_focusDownloadImage
            // 
            resources.ApplyResources(this.checkBox_focusDownloadImage, "checkBox_focusDownloadImage");
            this.checkBox_focusDownloadImage.Name = "checkBox_focusDownloadImage";
            this.toolTip_config.SetToolTip(this.checkBox_focusDownloadImage, resources.GetString("checkBox_focusDownloadImage.ToolTip"));
            this.checkBox_focusDownloadImage.UseVisualStyleBackColor = true;
            // 
            // checkBox_subFolder
            // 
            resources.ApplyResources(this.checkBox_subFolder, "checkBox_subFolder");
            this.checkBox_subFolder.Name = "checkBox_subFolder";
            this.toolTip_config.SetToolTip(this.checkBox_subFolder, resources.GetString("checkBox_subFolder.ToolTip"));
            this.checkBox_subFolder.UseVisualStyleBackColor = true;
            // 
            // button_downloadFolderChange
            // 
            resources.ApplyResources(this.button_downloadFolderChange, "button_downloadFolderChange");
            this.button_downloadFolderChange.Name = "button_downloadFolderChange";
            this.toolTip_config.SetToolTip(this.button_downloadFolderChange, resources.GetString("button_downloadFolderChange.ToolTip"));
            this.button_downloadFolderChange.UseVisualStyleBackColor = true;
            this.button_downloadFolderChange.Click += new System.EventHandler(this.button_downloadFolderChange_Click);
            // 
            // textBox_downloadFolder
            // 
            resources.ApplyResources(this.textBox_downloadFolder, "textBox_downloadFolder");
            this.textBox_downloadFolder.Name = "textBox_downloadFolder";
            this.toolTip_config.SetToolTip(this.textBox_downloadFolder, resources.GetString("textBox_downloadFolder.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip_config.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // tabPage_search
            // 
            this.tabPage_search.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_search.Controls.Add(this.comboBox1);
            this.tabPage_search.Controls.Add(this.panel1);
            this.tabPage_search.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage_search, "tabPage_search");
            this.tabPage_search.Name = "tabPage_search";
            // 
            // toolTip_config
            // 
            this.toolTip_config.AutoPopDelay = 10000;
            this.toolTip_config.InitialDelay = 500;
            this.toolTip_config.ReshowDelay = 100;
            // 
            // ConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_slideSecond)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_all.ResumeLayout(false);
            this.tabPage_all.PerformLayout();
            this.tabPage_save.ResumeLayout(false);
            this.tabPage_save.PerformLayout();
            this.tabPage_search.ResumeLayout(false);
            this.tabPage_search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_ok;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_showToolTip;
        private System.Windows.Forms.ToolTip toolTip_config;
    }
}