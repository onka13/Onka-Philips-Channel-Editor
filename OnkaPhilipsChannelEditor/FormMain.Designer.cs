namespace OnkaPhilipsChannelEditor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn10Down = new System.Windows.Forms.Button();
            this.btn10Up = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cAutoSort = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDeleteChannel = new System.Windows.Forms.Button();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.txtFavoriteNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderAllReNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBySavedFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.cLanguageTurkish = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblChannelSuffix = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn10Down);
            this.splitContainer1.Panel1.Controls.Add(this.btn10Up);
            this.splitContainer1.Panel1.Controls.Add(this.btnDown);
            this.splitContainer1.Panel1.Controls.Add(this.btnUp);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // btn10Down
            // 
            resources.ApplyResources(this.btn10Down, "btn10Down");
            this.btn10Down.Name = "btn10Down";
            this.btn10Down.UseVisualStyleBackColor = true;
            this.btn10Down.Click += new System.EventHandler(this.btn10Down_Click);
            // 
            // btn10Up
            // 
            resources.ApplyResources(this.btn10Up, "btn10Up");
            this.btn10Up.Name = "btn10Up";
            this.btn10Up.UseVisualStyleBackColor = true;
            this.btn10Up.Click += new System.EventHandler(this.btn10Up_Click);
            // 
            // btnDown
            // 
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Name = "btnDown";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox1_DragOver);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblChannelSuffix);
            this.splitContainer2.Panel1.Controls.Add(this.cAutoSort);
            this.splitContainer2.Panel1.Controls.Add(this.btnChange);
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteChannel);
            this.splitContainer2.Panel1.Controls.Add(this.txtNo);
            this.splitContainer2.Panel1.Controls.Add(this.txtFavoriteNo);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txtName);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLog);
            // 
            // cAutoSort
            // 
            resources.ApplyResources(this.cAutoSort, "cAutoSort");
            this.cAutoSort.Name = "cAutoSort";
            this.cAutoSort.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.Name = "btnChange";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDeleteChannel
            // 
            resources.ApplyResources(this.btnDeleteChannel, "btnDeleteChannel");
            this.btnDeleteChannel.Name = "btnDeleteChannel";
            this.btnDeleteChannel.UseVisualStyleBackColor = true;
            this.btnDeleteChannel.Click += new System.EventHandler(this.btnDeleteChannel_Click);
            // 
            // txtNo
            // 
            resources.ApplyResources(this.txtNo, "txtNo");
            this.txtNo.Name = "txtNo";
            // 
            // txtFavoriteNo
            // 
            resources.ApplyResources(this.txtFavoriteNo, "txtFavoriteNo");
            this.txtFavoriteNo.Name = "txtFavoriteNo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByNoToolStripMenuItem,
            this.orderAllReNumberToolStripMenuItem,
            this.orderBySavedFileListToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // sortByNoToolStripMenuItem
            // 
            this.sortByNoToolStripMenuItem.Name = "sortByNoToolStripMenuItem";
            resources.ApplyResources(this.sortByNoToolStripMenuItem, "sortByNoToolStripMenuItem");
            this.sortByNoToolStripMenuItem.Click += new System.EventHandler(this.sortByNoToolStripMenuItem_Click);
            // 
            // orderAllReNumberToolStripMenuItem
            // 
            this.orderAllReNumberToolStripMenuItem.Name = "orderAllReNumberToolStripMenuItem";
            resources.ApplyResources(this.orderAllReNumberToolStripMenuItem, "orderAllReNumberToolStripMenuItem");
            this.orderAllReNumberToolStripMenuItem.Click += new System.EventHandler(this.orderAllReNumberToolStripMenuItem_Click);
            // 
            // orderBySavedFileListToolStripMenuItem
            // 
            this.orderBySavedFileListToolStripMenuItem.Name = "orderBySavedFileListToolStripMenuItem";
            resources.ApplyResources(this.orderBySavedFileListToolStripMenuItem, "orderBySavedFileListToolStripMenuItem");
            this.orderBySavedFileListToolStripMenuItem.Click += new System.EventHandler(this.orderBySavedFileListToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLanguageEnglish,
            this.cLanguageTurkish});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // cLanguageEnglish
            // 
            this.cLanguageEnglish.Name = "cLanguageEnglish";
            resources.ApplyResources(this.cLanguageEnglish, "cLanguageEnglish");
            this.cLanguageEnglish.Click += new System.EventHandler(this.cLanguageEnglish_Click);
            // 
            // cLanguageTurkish
            // 
            this.cLanguageTurkish.Name = "cLanguageTurkish";
            resources.ApplyResources(this.cLanguageTurkish, "cLanguageTurkish");
            this.cLanguageTurkish.Click += new System.EventHandler(this.cLanguageTurkish_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cStatus});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // cStatus
            // 
            this.cStatus.Name = "cStatus";
            resources.ApplyResources(this.cStatus, "cStatus");
            // 
            // lblChannelSuffix
            // 
            resources.ApplyResources(this.lblChannelSuffix, "lblChannelSuffix");
            this.lblChannelSuffix.Name = "lblChannelSuffix";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem orderAllReNumberToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFavoriteNo;
        private System.Windows.Forms.ToolStripMenuItem orderBySavedFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel cStatus;
        private System.Windows.Forms.Button btnDeleteChannel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.CheckBox cAutoSort;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem cLanguageTurkish;
        private System.Windows.Forms.Button btn10Down;
        private System.Windows.Forms.Button btn10Up;
        private System.Windows.Forms.Label lblChannelSuffix;
    }
}

