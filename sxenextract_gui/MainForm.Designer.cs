namespace sxenextract_gui
{
    partial class MainForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem_open = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem_Exit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem_extractAll = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_explorer = new System.Windows.Forms.TreeView();
            this.listView_explorer = new System.Windows.Forms.ListView();
            this.openFileDialog_sxen = new System.Windows.Forms.OpenFileDialog();
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem_open,
            this.menuItem7,
            this.menuItem_Exit});
            this.menuItem1.Text = "&File";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "&New";
            // 
            // menuItem_open
            // 
            this.menuItem_open.Index = 1;
            this.menuItem_open.Text = "&Open";
            this.menuItem_open.Click += new System.EventHandler(this.menuItem_open_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Index = 3;
            this.menuItem_Exit.Text = "&Exit";
            this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_extractAll});
            this.menuItem2.Text = "&Options";
            // 
            // menuItem_extractAll
            // 
            this.menuItem_extractAll.Index = 0;
            this.menuItem_extractAll.Text = "E&xtract All";
            this.menuItem_extractAll.Click += new System.EventHandler(this.menuItem_extractAll_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9});
            this.menuItem3.Text = "&Help";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "&About";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_explorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView_explorer);
            this.splitContainer1.Size = new System.Drawing.Size(718, 357);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView_explorer
            // 
            this.treeView_explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_explorer.Location = new System.Drawing.Point(0, 0);
            this.treeView_explorer.Name = "treeView_explorer";
            this.treeView_explorer.Size = new System.Drawing.Size(227, 357);
            this.treeView_explorer.TabIndex = 0;
            // 
            // listView_explorer
            // 
            this.listView_explorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnType,
            this.columnSize});
            this.listView_explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_explorer.Location = new System.Drawing.Point(0, 0);
            this.listView_explorer.Name = "listView_explorer";
            this.listView_explorer.Size = new System.Drawing.Size(487, 357);
            this.listView_explorer.TabIndex = 0;
            this.listView_explorer.UseCompatibleStateImageBehavior = false;
            this.listView_explorer.View = System.Windows.Forms.View.Details;
            // 
            // openFileDialog_sxen
            // 
            this.openFileDialog_sxen.DefaultExt = "sxen";
            this.openFileDialog_sxen.Filter = "DERPG SXEN Archives (*.sxen)|*.sxen";
            this.openFileDialog_sxen.Title = "Select a SXEN archive to open";
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "Name";
            this.columnFilename.Width = 240;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Size";
            this.columnSize.Width = 120;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 357);
            this.Controls.Add(this.splitContainer1);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "sxenextract_gui by iDestyKK";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem_open;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem_Exit;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem_extractAll;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_explorer;
        private System.Windows.Forms.ListView listView_explorer;
        private System.Windows.Forms.OpenFileDialog openFileDialog_sxen;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

