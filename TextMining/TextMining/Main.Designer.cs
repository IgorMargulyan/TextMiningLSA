namespace TextMining
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDataFromGoogleRSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitIntoTermsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTextData = new System.Windows.Forms.DataGridView();
            this.dgvTerms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTextData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerms)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getDataFromGoogleRSSToolStripMenuItem,
            this.splitIntoTermsToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // getDataFromGoogleRSSToolStripMenuItem
            // 
            this.getDataFromGoogleRSSToolStripMenuItem.Name = "getDataFromGoogleRSSToolStripMenuItem";
            this.getDataFromGoogleRSSToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.getDataFromGoogleRSSToolStripMenuItem.Text = "Get Data from Google RSS";
            this.getDataFromGoogleRSSToolStripMenuItem.Click += new System.EventHandler(this.getDataFromGoogleRSSToolStripMenuItem_Click);
            // 
            // splitIntoTermsToolStripMenuItem
            // 
            this.splitIntoTermsToolStripMenuItem.Name = "splitIntoTermsToolStripMenuItem";
            this.splitIntoTermsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.splitIntoTermsToolStripMenuItem.Text = "Split into terms";
            this.splitIntoTermsToolStripMenuItem.Click += new System.EventHandler(this.splitIntoTermsToolStripMenuItem_Click);
            // 
            // dataTextData
            // 
            this.dataTextData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTextData.Location = new System.Drawing.Point(12, 57);
            this.dataTextData.Name = "dataTextData";
            this.dataTextData.Size = new System.Drawing.Size(461, 294);
            this.dataTextData.TabIndex = 1;
            // 
            // dgvTerms
            // 
            this.dgvTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerms.Location = new System.Drawing.Point(532, 57);
            this.dgvTerms.Name = "dgvTerms";
            this.dgvTerms.Size = new System.Drawing.Size(342, 190);
            this.dgvTerms.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Formatted news from Google RSS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Terms";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTerms);
            this.Controls.Add(this.dataTextData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "TextMining";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTextData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDataFromGoogleRSSToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataTextData;
        private System.Windows.Forms.DataGridView dgvTerms;
        private System.Windows.Forms.ToolStripMenuItem splitIntoTermsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

