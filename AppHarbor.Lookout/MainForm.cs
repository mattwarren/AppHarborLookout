using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using AppHarbor;
using AppHarborLookout.Properties;

namespace AppHarborLookout
{
    public partial class MainForm : Form
    {
        private bool _allowVisible = false;
        private bool _allowClose = false;
        private bool _formHasBeenShown = false;
        private bool _isVisible = false;
        private readonly Timer timer;

        public MainForm()
        {
            InitializeComponent();
            notifyIcon.ContextMenuStrip = contextMenuStrip;

#if DEBUG
            timer = new Timer { Enabled = true, Interval = 10000 };
#else
            timer = new Timer {Enabled = true, Interval = 30 * 1000};
#endif
            timer.Tick += (sender, e) =>
            {
                if (String.IsNullOrWhiteSpace(Settings.Default.AccessToken))
                {
                    string clientId = "49e17241-0631-47ec-bbf5-eface6552ea8";
                    string clientSecret = "1d4e4d1b-9798-4bd3-bd86-f17ca00505e3";

                    var savedAuthInfo = GetAuthorization(clientId, clientSecret);
                    Settings.Default.AccessToken = savedAuthInfo.AccessToken;
                    Settings.Default.TokenType = savedAuthInfo.TokenType;
                    Settings.Default.Save();
                }

                var authInfo = new AuthInfo(Settings.Default.AccessToken, Settings.Default.TokenType);
                var client = new AppHarborClient(authInfo);
                foreach (var application in client.GetApplications())
                {
                    var builds = client.GetBuilds(application.Slug);
                    var infoMsg = String.Format("{0}: {1}: {2}", DateTime.Now.ToString("hh:mm.ss tt"), application.Name, String.Join(", ", builds.Select(b => new { b.Deployed, b.Status })));

                    if (_formHasBeenShown)
                    {
                        infoLabel.Invoke((Action) delegate
                        {
                            infoLabel.Text = infoMsg;
                        });
                    }
                }
            };

            mainScreenToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();

            //settingsToolStripMenuItem.Click += (sender, e) =>
            //{
            //     //Show settings UI?
            //};

            exitToolStripMenuItem.Click += (sender, e) =>
            {
                _allowClose = true;
                Close();
                //If the form hasn't been shown, Close() on it's own doesn't kill the process, use Exit also
                Environment.Exit(1);
            };

            notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout", "Monitoring your builds", ToolTipIcon.Info);

            notifyIcon.Click += (sender,  e) =>
            {
                var mouseEvent = e as MouseEventArgs;
                if (mouseEvent != null && mouseEvent.Button == MouseButtons.Left)
                    ToggleMainScreen();
            };

            closeLinkLabel.Click += (sender, e) => HideMainScreen();
        }

        private static AuthInfo GetAuthorization(string clientId, string clientSecret)
        {
            try
            {
                return AppHarborClient.AskForAuthorization(clientId, clientSecret, TimeSpan.FromMinutes(1));
            }
            catch (AuthenticationException)
            {
                Console.WriteLine("Failed to get authorization");
                Environment.Exit(-1);
                throw;
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout, you have to be faster than that");
                Environment.Exit(-1);
                throw;
            }
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
            _formHasBeenShown = true;
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
