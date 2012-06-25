using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppHarborLookout
{
    public partial class Form1 : Form
    {
        bool _allowVisible = false;
        bool _allowClose = false;
    	private bool _isVisible = false;

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;

            mainScreenToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();

            settingsToolStripMenuItem.Click += (sender, e) =>
                {
                    Location = new Point(Cursor.Position.X - Width, Cursor.Position.Y - Height - 15);
                    _allowVisible = true;
                    Show();
                };

            exitToolStripMenuItem.Click += (sender, e) =>
                {
                    _allowClose = true;
                    Close();
                    //If the form hasn't been shown, Close() on it's own doesn't kill the process, use Exit also
                    Environment.Exit(1);
                };

            notifyIcon1.ShowBalloonTip(1000, "Testing", "Please Click Me", ToolTipIcon.Info);

            notifyIcon1.Click += (sender,  e) =>
                {
                    var mouseEvent = e as MouseEventArgs;
                    if (mouseEvent != null && mouseEvent.Button == MouseButtons.Left)
                        ToggleMainScreen();
                };

            linkLabel1.Click += (sender, e) => HideMainScreen();
        }

		private void ToggleMainScreen()
		{
			if (_isVisible)
				HideMainScreen();
			else
				ShowMainScreen();
		}

    	private void HideMainScreen()
    	{
    		_isVisible = false;
			Hide();
    	}

    	private void ShowMainScreen()
        {
			//TODO need a better way of doing this!!!!
            Location = new Point(Cursor.Position.X - Width, Cursor.Position.Y - Height - 15);
            _allowVisible = true;
        	_isVisible = true;
            Show();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible) 
                value = false;
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        //private void showToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //_allowVisible = true;
        //    //mLoadFired = true;
        //    Show();
        //}

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //_allowClose = _allowVisible = true;
        //    //if (!mLoadFired) 
        //    //    Show();
        //    Close();
        //}
    }
}
