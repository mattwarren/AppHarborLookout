namespace AppHarborLookout
{
    partial class AppHarborForm
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppHarborForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Id 1235 @ 10:32 PM - http://test.com/build123", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2nd item 3453453453535345 erw345v345 4 ewrewr er wer wer wer we", 4);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 3);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("", 2);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("", 6);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("", 4);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("The last item in the list with loads of text and a url", 1);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reAuthoriseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buildsListView = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.currentInfoTabPage = new System.Windows.Forms.TabPage();
            this.pictureBoxLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.applicationUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.labelCommit = new System.Windows.Forms.Label();
            this.labelDeployed = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelAppName = new System.Windows.Forms.Label();
            this.logUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.buildUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.previousBuildsTabPage = new System.Windows.Forms.TabPage();
            this.errorMessageTabPage = new System.Windows.Forms.TabPage();
            this.dataGridViewErrors = new System.Windows.Forms.DataGridView();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.currentInfoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingSpinner)).BeginInit();
            this.previousBuildsTabPage.SuspendLayout();
            this.errorMessageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 17);
            label1.TabIndex = 6;
            label1.Text = "Application:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 17);
            label2.TabIndex = 7;
            label2.Text = "Build Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(47, 105);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 17);
            label3.TabIndex = 8;
            label3.Text = "Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(26, 135);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 17);
            label5.TabIndex = 12;
            label5.Text = "Deployed:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 163);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 17);
            label6.TabIndex = 14;
            label6.Text = "Commit Msg:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AppHarbor Lookout\r\nBuild Status: Unknown";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainScreenToolStripMenuItem,
            toolStripSeparator,
            this.reAuthoriseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(152, 76);
            // 
            // mainScreenToolStripMenuItem
            // 
            this.mainScreenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainScreenToolStripMenuItem.Name = "mainScreenToolStripMenuItem";
            this.mainScreenToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mainScreenToolStripMenuItem.Text = "Main Screen";
            // 
            // reAuthoriseToolStripMenuItem
            // 
            this.reAuthoriseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reAuthoriseToolStripMenuItem.Name = "reAuthoriseToolStripMenuItem";
            this.reAuthoriseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.reAuthoriseToolStripMenuItem.Text = "Re-Authorise";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // closeLinkLabel
            // 
            this.closeLinkLabel.AutoSize = true;
            this.closeLinkLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLinkLabel.Location = new System.Drawing.Point(273, 443);
            this.closeLinkLabel.Name = "closeLinkLabel";
            this.closeLinkLabel.Size = new System.Drawing.Size(46, 19);
            this.closeLinkLabel.TabIndex = 1;
            this.closeLinkLabel.TabStop = true;
            this.closeLinkLabel.Text = "Close";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(69, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(193, 25);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "AppHarbor Lookout";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "BlueButton.gif");
            this.imageList.Images.SetKeyName(1, "DarkBlueButton.gif");
            this.imageList.Images.SetKeyName(2, "GrayButton.gif");
            this.imageList.Images.SetKeyName(3, "GreenButton.gif");
            this.imageList.Images.SetKeyName(4, "DarkGreenButton.gif");
            this.imageList.Images.SetKeyName(5, "OrangeButton.gif");
            this.imageList.Images.SetKeyName(6, "RedButton.gif");
            // 
            // buildsListView
            // 
            this.buildsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.buildsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buildsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildsListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewItem2.StateImageIndex = 0;
            this.buildsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.buildsListView.LargeImageList = this.imageList;
            this.buildsListView.Location = new System.Drawing.Point(3, 3);
            this.buildsListView.MultiSelect = false;
            this.buildsListView.Name = "buildsListView";
            this.buildsListView.Scrollable = false;
            this.buildsListView.Size = new System.Drawing.Size(315, 368);
            this.buildsListView.SmallImageList = this.imageList;
            this.buildsListView.TabIndex = 4;
            this.buildsListView.TileSize = new System.Drawing.Size(300, 38);
            this.buildsListView.UseCompatibleStateImageBehavior = false;
            this.buildsListView.View = System.Windows.Forms.View.Tile;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.currentInfoTabPage);
            this.tabControl.Controls.Add(this.previousBuildsTabPage);
            this.tabControl.Controls.Add(this.errorMessageTabPage);
            this.tabControl.Location = new System.Drawing.Point(2, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(329, 401);
            this.tabControl.TabIndex = 5;
            // 
            // currentInfoTabPage
            // 
            this.currentInfoTabPage.Controls.Add(this.pictureBoxLoadingSpinner);
            this.currentInfoTabPage.Controls.Add(this.applicationUrlLinkLabel);
            this.currentInfoTabPage.Controls.Add(this.labelCommit);
            this.currentInfoTabPage.Controls.Add(label6);
            this.currentInfoTabPage.Controls.Add(this.labelDeployed);
            this.currentInfoTabPage.Controls.Add(label5);
            this.currentInfoTabPage.Controls.Add(this.labelStatus);
            this.currentInfoTabPage.Controls.Add(this.labelTime);
            this.currentInfoTabPage.Controls.Add(this.labelAppName);
            this.currentInfoTabPage.Controls.Add(label3);
            this.currentInfoTabPage.Controls.Add(label2);
            this.currentInfoTabPage.Controls.Add(label1);
            this.currentInfoTabPage.Controls.Add(this.logUrlLinkLabel);
            this.currentInfoTabPage.Controls.Add(this.buildUrlLinkLabel);
            this.currentInfoTabPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentInfoTabPage.Location = new System.Drawing.Point(4, 23);
            this.currentInfoTabPage.Name = "currentInfoTabPage";
            this.currentInfoTabPage.Size = new System.Drawing.Size(321, 374);
            this.currentInfoTabPage.TabIndex = 2;
            this.currentInfoTabPage.Text = "Current Build";
            this.currentInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLoadingSpinner
            // 
            this.pictureBoxLoadingSpinner.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoadingSpinner.Image")));
            this.pictureBoxLoadingSpinner.Location = new System.Drawing.Point(160, 86);
            this.pictureBoxLoadingSpinner.Name = "pictureBoxLoadingSpinner";
            this.pictureBoxLoadingSpinner.Size = new System.Drawing.Size(66, 66);
            this.pictureBoxLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLoadingSpinner.TabIndex = 17;
            this.pictureBoxLoadingSpinner.TabStop = false;
            // 
            // applicationUrlLinkLabel
            // 
            this.applicationUrlLinkLabel.AutoSize = true;
            this.applicationUrlLinkLabel.Enabled = false;
            this.applicationUrlLinkLabel.Location = new System.Drawing.Point(174, 11);
            this.applicationUrlLinkLabel.Name = "applicationUrlLinkLabel";
            this.applicationUrlLinkLabel.Size = new System.Drawing.Size(139, 17);
            this.applicationUrlLinkLabel.TabIndex = 16;
            this.applicationUrlLinkLabel.TabStop = true;
            this.applicationUrlLinkLabel.Text = "Go to your application";
            // 
            // labelCommit
            // 
            this.labelCommit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommit.Location = new System.Drawing.Point(95, 163);
            this.labelCommit.Name = "labelCommit";
            this.labelCommit.Size = new System.Drawing.Size(218, 17);
            this.labelCommit.TabIndex = 15;
            // 
            // labelDeployed
            // 
            this.labelDeployed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeployed.Location = new System.Drawing.Point(95, 135);
            this.labelDeployed.Name = "labelDeployed";
            this.labelDeployed.Size = new System.Drawing.Size(218, 17);
            this.labelDeployed.TabIndex = 13;
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelStatus.Location = new System.Drawing.Point(95, 105);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(218, 17);
            this.labelStatus.TabIndex = 11;
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(95, 75);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(218, 17);
            this.labelTime.TabIndex = 10;
            // 
            // labelAppName
            // 
            this.labelAppName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.Location = new System.Drawing.Point(95, 45);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(218, 17);
            this.labelAppName.TabIndex = 9;
            // 
            // logUrlLinkLabel
            // 
            this.logUrlLinkLabel.AutoSize = true;
            this.logUrlLinkLabel.Enabled = false;
            this.logUrlLinkLabel.Location = new System.Drawing.Point(17, 238);
            this.logUrlLinkLabel.Name = "logUrlLinkLabel";
            this.logUrlLinkLabel.Size = new System.Drawing.Size(114, 17);
            this.logUrlLinkLabel.TabIndex = 5;
            this.logUrlLinkLabel.TabStop = true;
            this.logUrlLinkLabel.Text = "Detailed Build Log";
            // 
            // buildUrlLinkLabel
            // 
            this.buildUrlLinkLabel.AutoSize = true;
            this.buildUrlLinkLabel.Enabled = false;
            this.buildUrlLinkLabel.Location = new System.Drawing.Point(17, 208);
            this.buildUrlLinkLabel.Name = "buildUrlLinkLabel";
            this.buildUrlLinkLabel.Size = new System.Drawing.Size(85, 17);
            this.buildUrlLinkLabel.TabIndex = 4;
            this.buildUrlLinkLabel.TabStop = true;
            this.buildUrlLinkLabel.Text = "Full Build Info";
            // 
            // previousBuildsTabPage
            // 
            this.previousBuildsTabPage.Controls.Add(this.buildsListView);
            this.previousBuildsTabPage.Location = new System.Drawing.Point(4, 23);
            this.previousBuildsTabPage.Name = "previousBuildsTabPage";
            this.previousBuildsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.previousBuildsTabPage.Size = new System.Drawing.Size(321, 374);
            this.previousBuildsTabPage.TabIndex = 1;
            this.previousBuildsTabPage.Text = "Previous builds";
            this.previousBuildsTabPage.UseVisualStyleBackColor = true;
            // 
            // errorMessageTabPage
            // 
            this.errorMessageTabPage.Controls.Add(this.dataGridViewErrors);
            this.errorMessageTabPage.Location = new System.Drawing.Point(4, 23);
            this.errorMessageTabPage.Name = "errorMessageTabPage";
            this.errorMessageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorMessageTabPage.Size = new System.Drawing.Size(321, 374);
            this.errorMessageTabPage.TabIndex = 3;
            this.errorMessageTabPage.Text = "Error Messages";
            this.errorMessageTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewErrors
            // 
            this.dataGridViewErrors.AllowUserToAddRows = false;
            this.dataGridViewErrors.AllowUserToDeleteRows = false;
            this.dataGridViewErrors.AllowUserToResizeColumns = false;
            this.dataGridViewErrors.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewErrors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewErrors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewErrors.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewErrors.ColumnHeadersHeight = 36;
            this.dataGridViewErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewErrors.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewErrors.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewErrors.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewErrors.MultiSelect = false;
            this.dataGridViewErrors.Name = "dataGridViewErrors";
            this.dataGridViewErrors.ReadOnly = true;
            this.dataGridViewErrors.RowHeadersVisible = false;
            this.dataGridViewErrors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewErrors.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewErrors.Size = new System.Drawing.Size(315, 368);
            this.dataGridViewErrors.TabIndex = 0;
            // 
            // AppHarborForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 471);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.closeLinkLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppHarborForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.currentInfoTabPage.ResumeLayout(false);
            this.currentInfoTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingSpinner)).EndInit();
            this.previousBuildsTabPage.ResumeLayout(false);
            this.errorMessageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reAuthoriseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel closeLinkLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ToolStripMenuItem mainScreenToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ListView buildsListView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage previousBuildsTabPage;
        private System.Windows.Forms.TabPage currentInfoTabPage;
        private System.Windows.Forms.LinkLabel logUrlLinkLabel;
        private System.Windows.Forms.LinkLabel buildUrlLinkLabel;
        private System.Windows.Forms.TabPage errorMessageTabPage;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label labelDeployed;
        private System.Windows.Forms.Label labelCommit;
        private System.Windows.Forms.LinkLabel applicationUrlLinkLabel;
        private System.Windows.Forms.PictureBox pictureBoxLoadingSpinner;
        private System.Windows.Forms.DataGridView dataGridViewErrors;
    }
}

