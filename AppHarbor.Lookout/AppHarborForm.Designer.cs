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
      System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Id 1235 @ 10:32 PM - http://test.com/build123", 0);
      System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("2nd item 3453453453535345 erw345v345 4 ewrewr er wer wer wer we", 4);
      System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("", 3);
      System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("", 2);
      System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("", 4);
      System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("", 6);
      System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("", 4);
      System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("The last item in the list with loads of text and a url", 1);
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reAuthoriseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeLinkLabel = new System.Windows.Forms.LinkLabel();
      this.titleLabel = new System.Windows.Forms.Label();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.buildsListView = new System.Windows.Forms.ListView();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.currentInfoTabPage = new System.Windows.Forms.TabPage();
      this.pictureBoxLoadingSpinner = new System.Windows.Forms.PictureBox();
      this.applicationLnk = new System.Windows.Forms.LinkLabel();
      this.lblDeployTime = new System.Windows.Forms.Label();
      this.lblStatus = new System.Windows.Forms.Label();
      this.lblCreateTime = new System.Windows.Forms.Label();
      this.lblAppName = new System.Windows.Forms.Label();
      this.logLnk = new System.Windows.Forms.LinkLabel();
      this.buildLnk = new System.Windows.Forms.LinkLabel();
      this.previousBuildsTabPage = new System.Windows.Forms.TabPage();
      this.errorMessageTabPage = new System.Windows.Forms.TabPage();
      this.dataGridViewErrors = new System.Windows.Forms.DataGridView();
      this.txtCommitMsg = new System.Windows.Forms.TextBox();
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
      toolStripSeparator.Size = new System.Drawing.Size(176, 6);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label1.Location = new System.Drawing.Point(17, 52);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(80, 19);
      label1.TabIndex = 6;
      label1.Text = "Application:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label2.Location = new System.Drawing.Point(21, 86);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(75, 19);
      label2.TabIndex = 7;
      label2.Text = "Build Time:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label3.Location = new System.Drawing.Point(46, 121);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(50, 19);
      label3.TabIndex = 8;
      label3.Text = "Status:";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label5.Location = new System.Drawing.Point(26, 155);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(70, 19);
      label5.TabIndex = 12;
      label5.Text = "Deployed:";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label6.Location = new System.Drawing.Point(6, 187);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(92, 19);
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
            this.mainToolStripMenuItem,
            toolStripSeparator,
            this.reAuthoriseToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.contextMenuStrip.Name = "contextMenuStrip1";
      this.contextMenuStrip.Size = new System.Drawing.Size(180, 94);
      // 
      // mainToolStripMenuItem
      // 
      this.mainToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
      this.mainToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
      this.mainToolStripMenuItem.Text = "Main Screen";
      // 
      // reAuthoriseToolStripMenuItem
      // 
      this.reAuthoriseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.reAuthoriseToolStripMenuItem.Name = "reAuthoriseToolStripMenuItem";
      this.reAuthoriseToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
      this.reAuthoriseToolStripMenuItem.Text = "Re-Authorise";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // closeLinkLabel
      // 
      this.closeLinkLabel.AutoSize = true;
      this.closeLinkLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.closeLinkLabel.Location = new System.Drawing.Point(269, 509);
      this.closeLinkLabel.Name = "closeLinkLabel";
      this.closeLinkLabel.Size = new System.Drawing.Size(56, 23);
      this.closeLinkLabel.TabIndex = 1;
      this.closeLinkLabel.TabStop = true;
      this.closeLinkLabel.Text = "Close";
      // 
      // titleLabel
      // 
      this.titleLabel.AutoSize = true;
      this.titleLabel.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.titleLabel.Location = new System.Drawing.Point(68, 10);
      this.titleLabel.Name = "titleLabel";
      this.titleLabel.Size = new System.Drawing.Size(245, 32);
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
      listViewItem10.StateImageIndex = 0;
      this.buildsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
      this.buildsListView.LargeImageList = this.imageList;
      this.buildsListView.Location = new System.Drawing.Point(3, 3);
      this.buildsListView.MultiSelect = false;
      this.buildsListView.Name = "buildsListView";
      this.buildsListView.Scrollable = false;
      this.buildsListView.Size = new System.Drawing.Size(310, 422);
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
      this.tabControl.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tabControl.Location = new System.Drawing.Point(2, 45);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(324, 461);
      this.tabControl.TabIndex = 5;
      // 
      // currentInfoTabPage
      // 
      this.currentInfoTabPage.Controls.Add(this.txtCommitMsg);
      this.currentInfoTabPage.Controls.Add(this.pictureBoxLoadingSpinner);
      this.currentInfoTabPage.Controls.Add(this.applicationLnk);
      this.currentInfoTabPage.Controls.Add(label6);
      this.currentInfoTabPage.Controls.Add(this.lblDeployTime);
      this.currentInfoTabPage.Controls.Add(label5);
      this.currentInfoTabPage.Controls.Add(this.lblStatus);
      this.currentInfoTabPage.Controls.Add(this.lblCreateTime);
      this.currentInfoTabPage.Controls.Add(this.lblAppName);
      this.currentInfoTabPage.Controls.Add(label3);
      this.currentInfoTabPage.Controls.Add(label2);
      this.currentInfoTabPage.Controls.Add(label1);
      this.currentInfoTabPage.Controls.Add(this.logLnk);
      this.currentInfoTabPage.Controls.Add(this.buildLnk);
      this.currentInfoTabPage.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.currentInfoTabPage.Location = new System.Drawing.Point(4, 26);
      this.currentInfoTabPage.Name = "currentInfoTabPage";
      this.currentInfoTabPage.Size = new System.Drawing.Size(316, 431);
      this.currentInfoTabPage.TabIndex = 2;
      this.currentInfoTabPage.Text = "Current Build";
      this.currentInfoTabPage.UseVisualStyleBackColor = true;
      // 
      // pictureBoxLoadingSpinner
      // 
      this.pictureBoxLoadingSpinner.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoadingSpinner.Image")));
      this.pictureBoxLoadingSpinner.Location = new System.Drawing.Point(158, 99);
      this.pictureBoxLoadingSpinner.Name = "pictureBoxLoadingSpinner";
      this.pictureBoxLoadingSpinner.Size = new System.Drawing.Size(66, 66);
      this.pictureBoxLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBoxLoadingSpinner.TabIndex = 17;
      this.pictureBoxLoadingSpinner.TabStop = false;
      // 
      // applicationLnk
      // 
      this.applicationLnk.AutoSize = true;
      this.applicationLnk.Enabled = false;
      this.applicationLnk.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.applicationLnk.Location = new System.Drawing.Point(171, 13);
      this.applicationLnk.Name = "applicationLnk";
      this.applicationLnk.Size = new System.Drawing.Size(146, 19);
      this.applicationLnk.TabIndex = 16;
      this.applicationLnk.TabStop = true;
      this.applicationLnk.Text = "Go to your application";
      // 
      // lblDeployTime
      // 
      this.lblDeployTime.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDeployTime.Location = new System.Drawing.Point(93, 155);
      this.lblDeployTime.Name = "lblDeployTime";
      this.lblDeployTime.Size = new System.Drawing.Size(215, 20);
      this.lblDeployTime.TabIndex = 13;
      // 
      // lblStatus
      // 
      this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblStatus.Location = new System.Drawing.Point(93, 121);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(215, 20);
      this.lblStatus.TabIndex = 11;
      // 
      // lblCreateTime
      // 
      this.lblCreateTime.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCreateTime.Location = new System.Drawing.Point(93, 86);
      this.lblCreateTime.Name = "lblCreateTime";
      this.lblCreateTime.Size = new System.Drawing.Size(215, 20);
      this.lblCreateTime.TabIndex = 10;
      // 
      // lblAppName
      // 
      this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAppName.Location = new System.Drawing.Point(93, 52);
      this.lblAppName.Name = "lblAppName";
      this.lblAppName.Size = new System.Drawing.Size(215, 20);
      this.lblAppName.TabIndex = 9;
      // 
      // logLnk
      // 
      this.logLnk.AutoSize = true;
      this.logLnk.Enabled = false;
      this.logLnk.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.logLnk.Location = new System.Drawing.Point(6, 309);
      this.logLnk.Name = "logLnk";
      this.logLnk.Size = new System.Drawing.Size(120, 19);
      this.logLnk.TabIndex = 5;
      this.logLnk.TabStop = true;
      this.logLnk.Text = "Detailed Build Log";
      // 
      // buildLnk
      // 
      this.buildLnk.AutoSize = true;
      this.buildLnk.Enabled = false;
      this.buildLnk.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buildLnk.Location = new System.Drawing.Point(6, 281);
      this.buildLnk.Name = "buildLnk";
      this.buildLnk.Size = new System.Drawing.Size(92, 19);
      this.buildLnk.TabIndex = 4;
      this.buildLnk.TabStop = true;
      this.buildLnk.Text = "Full Build Info";
      // 
      // previousBuildsTabPage
      // 
      this.previousBuildsTabPage.Controls.Add(this.buildsListView);
      this.previousBuildsTabPage.Location = new System.Drawing.Point(4, 29);
      this.previousBuildsTabPage.Name = "previousBuildsTabPage";
      this.previousBuildsTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
      this.previousBuildsTabPage.Size = new System.Drawing.Size(316, 428);
      this.previousBuildsTabPage.TabIndex = 1;
      this.previousBuildsTabPage.Text = "Previous builds";
      this.previousBuildsTabPage.UseVisualStyleBackColor = true;
      // 
      // errorMessageTabPage
      // 
      this.errorMessageTabPage.Controls.Add(this.dataGridViewErrors);
      this.errorMessageTabPage.Location = new System.Drawing.Point(4, 26);
      this.errorMessageTabPage.Name = "errorMessageTabPage";
      this.errorMessageTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
      this.errorMessageTabPage.Size = new System.Drawing.Size(316, 431);
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
      dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
      dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
      this.dataGridViewErrors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      this.dataGridViewErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridViewErrors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dataGridViewErrors.BackgroundColor = System.Drawing.Color.White;
      this.dataGridViewErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridViewErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.dataGridViewErrors.ColumnHeadersHeight = 36;
      this.dataGridViewErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewErrors.ColumnHeadersVisible = false;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridViewErrors.DefaultCellStyle = dataGridViewCellStyle8;
      this.dataGridViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridViewErrors.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewErrors.MultiSelect = false;
      this.dataGridViewErrors.Name = "dataGridViewErrors";
      this.dataGridViewErrors.ReadOnly = true;
      this.dataGridViewErrors.RowHeadersVisible = false;
      this.dataGridViewErrors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
      this.dataGridViewErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dataGridViewErrors.Size = new System.Drawing.Size(310, 425);
      this.dataGridViewErrors.TabIndex = 0;
      // 
      // txtCommitMsg
      // 
      this.txtCommitMsg.BackColor = System.Drawing.Color.White;
      this.txtCommitMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtCommitMsg.Cursor = System.Windows.Forms.Cursors.Default;
      this.txtCommitMsg.Location = new System.Drawing.Point(97, 187);
      this.txtCommitMsg.Multiline = true;
      this.txtCommitMsg.Name = "txtCommitMsg";
      this.txtCommitMsg.ReadOnly = true;
      this.txtCommitMsg.ShortcutsEnabled = false;
      this.txtCommitMsg.Size = new System.Drawing.Size(210, 91);
      this.txtCommitMsg.TabIndex = 18;
      // 
      // AppHarborForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(326, 542);
      this.ControlBox = false;
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.closeLinkLabel);
      this.Controls.Add(this.titleLabel);
      this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ListView buildsListView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage previousBuildsTabPage;
        private System.Windows.Forms.TabPage currentInfoTabPage;
        private System.Windows.Forms.LinkLabel logLnk;
        private System.Windows.Forms.LinkLabel buildLnk;
        private System.Windows.Forms.TabPage errorMessageTabPage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblDeployTime;
        private System.Windows.Forms.LinkLabel applicationLnk;
        private System.Windows.Forms.PictureBox pictureBoxLoadingSpinner;
        private System.Windows.Forms.DataGridView dataGridViewErrors;
        private System.Windows.Forms.TextBox txtCommitMsg;
    }
}

