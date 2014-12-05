namespace PhotozouImageSearchAPI
{
    partial class PhotozouImageSearchAPI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotozouImageSearchAPI));
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_searchNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_offset = new System.Windows.Forms.NumericUpDown();
            this.comboBox_copyright = new System.Windows.Forms.ComboBox();
            this.comboBox_commercial = new System.Windows.Forms.ComboBox();
            this.comboBox_modification = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_searchNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_offset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericUpDown_searchNum
            // 
            resources.ApplyResources(this.numericUpDown_searchNum, "numericUpDown_searchNum");
            this.numericUpDown_searchNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_searchNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_searchNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_searchNum.Name = "numericUpDown_searchNum";
            this.numericUpDown_searchNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numericUpDown_offset
            // 
            resources.ApplyResources(this.numericUpDown_offset, "numericUpDown_offset");
            this.numericUpDown_offset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_offset.Name = "numericUpDown_offset";
            // 
            // comboBox_copyright
            // 
            resources.ApplyResources(this.comboBox_copyright, "comboBox_copyright");
            this.comboBox_copyright.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_copyright.FormattingEnabled = true;
            this.comboBox_copyright.Items.AddRange(new object[] {
            resources.GetString("comboBox_copyright.Items"),
            resources.GetString("comboBox_copyright.Items1"),
            resources.GetString("comboBox_copyright.Items2")});
            this.comboBox_copyright.Name = "comboBox_copyright";
            this.comboBox_copyright.SelectedIndexChanged += new System.EventHandler(this.comboBox_copyright_SelectedIndexChanged);
            // 
            // comboBox_commercial
            // 
            resources.ApplyResources(this.comboBox_commercial, "comboBox_commercial");
            this.comboBox_commercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_commercial.FormattingEnabled = true;
            this.comboBox_commercial.Items.AddRange(new object[] {
            resources.GetString("comboBox_commercial.Items"),
            resources.GetString("comboBox_commercial.Items1")});
            this.comboBox_commercial.Name = "comboBox_commercial";
            // 
            // comboBox_modification
            // 
            resources.ApplyResources(this.comboBox_modification, "comboBox_modification");
            this.comboBox_modification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_modification.FormattingEnabled = true;
            this.comboBox_modification.Items.AddRange(new object[] {
            resources.GetString("comboBox_modification.Items"),
            resources.GetString("comboBox_modification.Items1"),
            resources.GetString("comboBox_modification.Items2")});
            this.comboBox_modification.Name = "comboBox_modification";
            // 
            // PhotozouImageSearchAPI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.comboBox_modification);
            this.Controls.Add(this.comboBox_commercial);
            this.Controls.Add(this.comboBox_copyright);
            this.Controls.Add(this.numericUpDown_offset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_searchNum);
            this.Controls.Add(this.label1);
            this.Name = "PhotozouImageSearchAPI";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_searchNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_offset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_searchNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_offset;
        private System.Windows.Forms.ComboBox comboBox_copyright;
        private System.Windows.Forms.ComboBox comboBox_commercial;
        private System.Windows.Forms.ComboBox comboBox_modification;
    }
}
