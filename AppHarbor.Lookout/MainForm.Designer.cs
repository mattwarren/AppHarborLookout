namespace AppHarborLookout
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
			System.Windows.Forms.ToolStripSeparator toolStripSeparator;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Id 1235 @ 10:32 PM - http://test.com/build123", 0);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2nd item 3453453453535345 erw345v345 4 ewrewr er wer wer wer we", 4);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 3);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("", 2);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("", 4);
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("", 6);
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("", 4);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("The last item in the list with loads of text and a url", 1);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mainScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeLinkLabel = new System.Windows.Forms.LinkLabel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripSeparator
			// 
			toolStripSeparator.Name = "toolStripSeparator";
			toolStripSeparator.Size = new System.Drawing.Size(148, 6);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "AppHarbor Lookout";
			this.notifyIcon.Visible = true;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainScreenToolStripMenuItem,
            toolStripSeparator,
            this.settingsToolStripMenuItem,
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
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
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
			this.titleLabel.Location = new System.Drawing.Point(54, 11);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(193, 25);
			this.titleLabel.TabIndex = 2;
			this.titleLabel.Text = "AppHarbor Lookout";
			// 
			// infoLabel
			// 
			this.infoLabel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoLabel.Location = new System.Drawing.Point(12, 48);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(307, 73);
			this.infoLabel.TabIndex = 3;
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
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			listViewItem2.StateImageIndex = 0;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
			this.listView1.LargeImageList = this.imageList;
			this.listView1.Location = new System.Drawing.Point(12, 124);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Scrollable = false;
			this.listView1.Size = new System.Drawing.Size(307, 316);
			this.listView1.SmallImageList = this.imageList;
			this.listView1.TabIndex = 4;
			this.listView1.TileSize = new System.Drawing.Size(302, 38);
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Tile;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(331, 471);
			this.ControlBox = false;
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.closeLinkLabel);
			this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel closeLinkLabel;
        private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.ToolStripMenuItem mainScreenToolStripMenuItem;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ListView listView1;
    }
}

