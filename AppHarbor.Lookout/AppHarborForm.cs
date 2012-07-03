using System;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Windows.Forms;
using AppHarbor;
using AppHarborLookout.Properties;
using System.Diagnostics;
using AppHarbor.Model;
//using Timer = System.Windows.Forms.Timer;
using Timer = System.Timers.Timer;
using System.Collections.Generic;
using System.Globalization;

namespace AppHarborLookout
{
    public enum BuildStatus
    {
        Unknown,
        Succeeded,
        Failed,
        Queued,
        Building
    }

    public partial class AppHarborForm : Form
    {
        private bool _allowVisible = false;
        private bool _allowClose = false;
        private bool _formHasBeenShown = false;
        private bool _isVisible = false;
        private readonly Timer timer;

        private BuildStatus _lastBuildStatus = BuildStatus.Unknown;

        public AppHarborForm()
        {
            InitializeComponent();
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            tabControl.TabPages.Remove(previousBuildsTabPage);

            //http://stackoverflow.com/questions/2154154/datagridview-how-to-set-column-width
            DataGridViewTextBoxColumn subTitleColumn = new DataGridViewTextBoxColumn();
            subTitleColumn.HeaderText = "Subtitle";
            subTitleColumn.MinimumWidth = 50;
            subTitleColumn.FillWeight = 65;
            subTitleColumn.DataPropertyName = "Date";

            DataGridViewTextBoxColumn summaryColumn = new DataGridViewTextBoxColumn();
            summaryColumn.HeaderText = "Summary";
            summaryColumn.MinimumWidth = 50;
            summaryColumn.FillWeight = 200;
            summaryColumn.DataPropertyName = "Value";

            dataGridViewErrors.Columns.AddRange(new DataGridViewTextBoxColumn[] { subTitleColumn, summaryColumn });

            //Make the timer fire straight-away, the 1st time
            timer = new Timer {Enabled = true, Interval = 500};            
            //timer.Tick += (sender, e) =>
            timer.Elapsed += (sender, e) =>
            {
                timer.Stop();
                try
                {                    
                    if (String.IsNullOrWhiteSpace(Settings.Default.AccessToken))
                    {
                        UpdateAuthorisationDetails();
                    }

                    var authInfo = new AuthInfo(Settings.Default.AccessToken, Settings.Default.TokenType);
                    var client = new AppHarborClient(authInfo);
                    var applications = client.GetApplications();
                    if (applications == null || applications.Count() == 0)
                        return;

                    var application = applications.First();

                    var builds = client.GetBuilds(application.Slug);
                    var errors = client.GetErrors(application.Slug);
                    if (errors != null && errors.Count() > 0)
                    {
                        var errorInfo = errors.Take(10).Select(x => new
                        {
                            //2012-07-03T00:36:44.292Z
                            Date = ParseDate(x.Date).ToString(),
                            Value = x.Exception.Message
                        }).ToList();
                        if (_formHasBeenShown)
                        {
                            dataGridViewErrors.Invoke((Action)delegate
                            {
                                dataGridViewErrors.DataSource = errorInfo;
                                dataGridViewErrors.Show();
                            });
                        }
                    }

                    //var tests = client.GetTests(application.Slug, build.Id);

                    var latestBuild = builds.OrderByDescending(x => x.Created)
                                    //.Skip(1)
                                    .FirstOrDefault();
                    if (latestBuild == null)
                        return;

                    var currentBuildStatus = GetBuildStatus(latestBuild.Status);

                    SetNotifyIcon(currentBuildStatus);

                    if (currentBuildStatus != _lastBuildStatus)
                    {
                        string msg = GetBuildStatusMsg(currentBuildStatus, _lastBuildStatus);
                        if (String.IsNullOrEmpty(msg) == false)
                            notifyIcon.ShowBalloonTip(1000, "Build Status", msg, ToolTipIcon.Warning);
                    }

                    if (_formHasBeenShown)
                    {                        
                        UpdateBuildUI(application, latestBuild, currentBuildStatus);
                    }
                    else
                    {
                        //Store the info, so when the form is popped up, we can populate it??
                    }

                    if (currentBuildStatus == BuildStatus.Succeeded ||
                        currentBuildStatus == BuildStatus.Failed)
                    {
                        //We only really care about failed/succeeded changes
                        _lastBuildStatus = currentBuildStatus;
                    }                    
                }
                catch (System.Exception ex)
                {
                    notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Error",
                                                    ex.Message + "\n" + ex.StackTrace, ToolTipIcon.Error);
                }
                finally
                {
#if DEBUG
                    timer.Interval = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
#else
                    timer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
#endif
                    timer.Start();
                }
            };

            buildUrlLinkLabel.LinkClicked += ProcessLinkClick;
            logUrlLinkLabel.LinkClicked += ProcessLinkClick;
            applicationUrlLinkLabel.LinkClicked += ProcessLinkClick;

            mainScreenToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();

            reAuthoriseToolStripMenuItem.Click += (sender, e) => UpdateAuthorisationDetails();

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

        private DateTime ParseDate(string rawDate)
        {
            DateTime date;
            var cleanedUpDate = rawDate.Replace("T", " ").Replace("Z", "");
            if (DateTime.TryParseExact(cleanedUpDate, "yyyy-MM-dd hh:mm:ss.fff",
                                       CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date))
            {
                return date;
            }
            return default(DateTime);
        }

        private void UpdateAuthorisationDetails()
        {
            //Settings stored in C:\Users\matt.warren\AppData\Local\AppHarborLookout
            //App authorized at https://appharbor.com/user/authorizations
            string clientId = "49e17241-0631-47ec-bbf5-eface6552ea8";
            string clientSecret = "1d4e4d1b-9798-4bd3-bd86-f17ca00505e3";

            var result = GetAuthorisation(clientId, clientSecret);
            var credentials = result.Item1;
            if (credentials != null)
            {
                Settings.Default.AccessToken = credentials.AccessToken;
                Settings.Default.TokenType = credentials.TokenType;
                Settings.Default.Save();
            }
            else if (result.Item2 != null)
            {
                notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Authorisation error", result.Item2, ToolTipIcon.Error);
            }
        }

        private void UpdateBuildUI(AppHarbor.Model.Application application, Build build, BuildStatus status)
        {
            currentInfoTabPage.Invoke((Action)delegate
            {
                pictureBoxLoadingSpinner.Hide();
                labelAppName.Text = application.Name;
                labelStatus.Text = build.Status;
                labelTime.Text = build.Created.ToString();
                var isDeployed = (build.Deployed != DateTime.MinValue);
                labelDeployed.Text = isDeployed ? build.Deployed.ToString() : "NOT DEPLOYED";
                labelDeployed.ForeColor = (isDeployed ? Color.Green : Color.Orange);

                SetupUrl(buildUrlLinkLabel, build.Url.AbsoluteUri);
                SetupUrl(applicationUrlLinkLabel, String.Format("http://{0}.apphb.com", application.Name.ToLowerInvariant()));

                labelCommit.Text = build.Commit.Message;

                var colour = GetColourForBuildStatus(status);
                labelStatus.ForeColor = colour;
            });
        }

        void ProcessLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData as String;
            if (url != null)
                Process.Start(url);   
        }

        private string GetBuildStatusMsg(BuildStatus current, BuildStatus previous)
        {
            if (current == BuildStatus.Succeeded) // && previous == BuildStatus.Failed)
                return "Yay, the build was fixed";
            if (current == BuildStatus.Failed) // && previous == BuildStatus.Succeeded)
                return "Uh oh, someone broke the build!!";

            return null;
        }

        private Color GetColourForBuildStatus(BuildStatus currentBuildStatus)
        {
            if (currentBuildStatus == BuildStatus.Failed)
                return Color.Red;
            if (currentBuildStatus == BuildStatus.Succeeded)
                return Color.Green;
            if (currentBuildStatus == BuildStatus.Queued ||
                currentBuildStatus == BuildStatus.Building)
                return Color.Orange;
            return Color.Gray;
        }

        private void SetNotifyIcon(BuildStatus buildStatus)
        {
            //Status can be: "Succeeded", "Failed", "Queued", 
            if (buildStatus == BuildStatus.Failed)
                notifyIcon.Icon = Resources.RedButton;
            else if (buildStatus == BuildStatus.Succeeded)
                notifyIcon.Icon = Resources.GreenButton;
            else if (buildStatus == BuildStatus.Queued ||
                     buildStatus == BuildStatus.Building)
                notifyIcon.Icon = Resources.OrangeButton;
            else
                notifyIcon.Icon = Resources.GrayButton;
            
            var text = String.Format(
@"AppHarbor Lookout
Build Status: {0}
Updated at: {1}",
                     buildStatus, DateTime.Now.ToShortTimeString());

            //Text length must be less than 64 characters long.
            notifyIcon.Text = String.Join("", text.Take(63));
        }

        private BuildStatus GetBuildStatus(string status)
        {
            if (status.ToLowerInvariant() == "failed")
                return BuildStatus.Failed;
            if (status.ToLowerInvariant() == "succeeded")
                return BuildStatus.Succeeded;
            if (status.ToLowerInvariant() == "queued")
                return BuildStatus.Queued;
            if (status.ToLowerInvariant() == "building")
                return BuildStatus.Building;
            return BuildStatus.Unknown;
        }

        private void SetupUrl(LinkLabel urlLinkLabel, string url)
        {
            //var url = fullUrl.Url.AbsoluteUri;
            urlLinkLabel.Links.Remove(urlLinkLabel.Links[0]);
            urlLinkLabel.Links.Add(0, urlLinkLabel.Text.Length, url);
            urlLinkLabel.Enabled = true;
        }

        private Tuple<AuthInfo, string> GetAuthorisation(string clientId, string clientSecret)
        {
            try
            {
                var authDetails = AppHarborClient.AskForAuthorization(clientId, clientSecret, TimeSpan.FromSeconds(30));
                return Tuple.Create<AuthInfo, string>(authDetails, null);
            }
            catch (AuthenticationException)
            {
                return Tuple.Create<AuthInfo, string>(null, "Failed to get authorization");
            }
            catch (TimeoutException)
            {
                return Tuple.Create<AuthInfo, string>(null, "Timeout, you have to be faster than that");                
            }
            catch (System.Exception ex)
            {
                return Tuple.Create<AuthInfo, string>(null, ex.Message);
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
            var cursorPosn = new Point(Cursor.Position.X, Cursor.Position.Y);            
            var mouseLocation = new Point(cursorPosn.X - Width, cursorPosn.Y - Height - 15);
            StartPosition = FormStartPosition.Manual;
            Location = mouseLocation;
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
    }
}
