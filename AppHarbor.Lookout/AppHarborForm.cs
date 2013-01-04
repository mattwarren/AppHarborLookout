using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AppHarbor.Model;

namespace AppHarborLookout {

  public partial class AppHarborForm : Form {
    private bool _allowVisible = false;
    private bool _allowClose = false;
    private bool mFormHasBeenShown = false;
    private bool _isVisible = false;
    private BuildStatusInterpreter statusInterpreter = new BuildStatusInterpreter();
    private BuildStatus mLastBuildStatus = BuildStatus.Unknown;
    private BuildProcessor buildProc;

    public AppHarborForm() {
      InitializeComponent();
      notifyIcon.ContextMenuStrip = contextMenuStrip;

      tabControl.TabPages.Remove(previousBuildsTabPage);

      var subTitleColumn = new DataGridViewTextBoxColumn() {
        HeaderText = "Subtitle",
        MinimumWidth = 50,
        FillWeight = 65,
        DataPropertyName = "Date"
      };

      var summaryColumn = new DataGridViewTextBoxColumn() {
        HeaderText = "Summary",
        MinimumWidth = 50,
        FillWeight = 200,
        DataPropertyName = "Value"
      };

      dataGridViewErrors.Columns
                        .AddRange(new DataGridViewTextBoxColumn[] {
                          subTitleColumn, 
                          summaryColumn 
                        });

      this.buildProc = new BuildProcessor(1000);
      this.buildProc.OnBuildProcessed += OnBuildProcessed;
      this.buildProc.OnGeneralError += OnGeneralError;
      this.buildProc.OnAuthorizationError += OnAuthorizationError;

      buildUrlLinkLabel.LinkClicked += ProcessLinkClick;
      logUrlLinkLabel.LinkClicked += ProcessLinkClick;
      applicationUrlLinkLabel.LinkClicked += ProcessLinkClick;

      mainScreenToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();

      reAuthoriseToolStripMenuItem.Click += (sender, e) => this.buildProc.UpdateAuthorizationDetails();

      exitToolStripMenuItem.Click += (sender, e) => {
        _allowClose = true;
        Close();
        Environment.Exit(1);
      };

      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout", "Monitoring your builds", ToolTipIcon.Info);

      notifyIcon.Click += (sender, e) => {
        var mouseEvent = e as MouseEventArgs;
        if(mouseEvent != null && mouseEvent.Button == MouseButtons.Left) {
          ToggleMainScreen();
        }
      };

      closeLinkLabel.Click += (sender, e) => HideMainScreen();
    }

    private void OnBuildProcessed(BuildInfo info) {           
      if(info.Errors != null && info.Errors.Count() > 0) {
        var errorInfo = info.Errors.Select(x => new {
          Date = ParseDate(x.Date).ToString(),
          Value = GetErrorMessage(x)
        }).ToList();

        if(mFormHasBeenShown) {
          dataGridViewErrors.Invoke((Action)delegate {
            dataGridViewErrors.DataSource = errorInfo;
            dataGridViewErrors.Show();
          });
        }
      }
      
      if(info.LatestBuild == null) { return; }

      BuildStatus currentBuildStatus = statusInterpreter.GetBuildStatus(info.LatestBuild.Status);
      SetNotifyIcon(currentBuildStatus);

      if(currentBuildStatus != mLastBuildStatus) {
        string msg = statusInterpreter.GetBuildStatusMsg(currentBuildStatus);
        if(String.IsNullOrEmpty(msg) == false) {
          notifyIcon.ShowBalloonTip(1000, "Build Status", msg, ToolTipIcon.Warning);
        }
      }

      if(mFormHasBeenShown) {
        UpdateBuildUI(info.ApplicationName, info.LatestBuild, currentBuildStatus);
      }

      if(currentBuildStatus == BuildStatus.Succeeded || currentBuildStatus == BuildStatus.Failed) {
        mLastBuildStatus = currentBuildStatus;
      }
    }

    /// <summary>
    /// Updates the build UI.
    /// </summary>
    /// <param name="appName">Name of the application.</param>
    /// <param name="build">The build.</param>
    /// <param name="status">The status.</param>
    private void UpdateBuildUI(string appName, Build build, BuildStatus status) {
      currentInfoTabPage.Invoke((Action)delegate {
        pictureBoxLoadingSpinner.Hide();
        labelAppName.Text = appName;
        labelStatus.Text = build.Status;
        labelTime.Text = build.Created.ToString();
        var isDeployed = (build.Deployed != DateTime.MinValue);
        labelDeployed.Text = isDeployed ? build.Deployed.ToString() : "NOT DEPLOYED";
        labelDeployed.ForeColor = (isDeployed ? Color.Green : Color.Orange);

        SetupUrl(buildUrlLinkLabel, build.Url.AbsoluteUri);
        SetupUrl(applicationUrlLinkLabel, String.Format("http://{0}.apphb.com", appName.ToLowerInvariant()));

        labelCommit.Text = build.Commit.Message;

        Color colour = statusInterpreter.GetBuildStatusColor(status);
        labelStatus.ForeColor = colour;
      });
    }

    /// <summary>
    /// Processes the link click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs" /> instance containing the event data.</param>
    private void ProcessLinkClick(object sender, LinkLabelLinkClickedEventArgs e) {
      var url = e.Link.LinkData as String;
      if(url != null) {
        Process.Start(url);
      }
    }

    /// <summary>
    /// Sets the notify icon.
    /// </summary>
    /// <param name="buildStatus">The build status.</param>
    private void SetNotifyIcon(BuildStatus buildStatus) {
      notifyIcon.Icon = statusInterpreter.GetBuildStatusNotifyIcon(buildStatus);
      var text = String.Format(
@"AppHarbor Lookout
Build Status: {0}
Updated at: {1}",
               buildStatus, DateTime.Now.ToShortTimeString());

      notifyIcon.Text = String.Join(string.Empty, text.Take(63));
    }

    private void SetupUrl(LinkLabel urlLinkLabel, string url) {
      urlLinkLabel.Links.Remove(urlLinkLabel.Links[0]);
      urlLinkLabel.Links.Add(0, urlLinkLabel.Text.Length, url);
      urlLinkLabel.Enabled = true;
    }

    private DateTime ParseDate(string rawDate) {
      DateTime date;
      var cleanedUpDate = rawDate.Replace("T", " ").Replace("Z", string.Empty);
      if(DateTime.TryParseExact(cleanedUpDate, "yyyy-MM-dd hh:mm:ss.fff",
                                 CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date)) {
        return date;
      }
      return default(DateTime);
    }

    private static string GetErrorMessage(Error x) {
      return string.Format("{0} {1}", x.Request_Path, x.Exception != null ? x.Exception.Message : x.Message);
    }

    private void ToggleMainScreen() {
      if(_isVisible) {
        HideMainScreen();
      } else {
        ShowMainScreen();
      }
    }

    private void HideMainScreen() {
      _isVisible = false;
      Hide();
    }

    /// <summary>
    /// Shows the main screen.
    /// </summary>
    private void ShowMainScreen() {
      var cursorPosn = new Point(Cursor.Position.X, Cursor.Position.Y);
      var mouseLocation = new Point(cursorPosn.X - Width, cursorPosn.Y - Height - 15);
      if(mouseLocation.Y < 15) {
        mouseLocation.Y = 15;
      }

      StartPosition = FormStartPosition.Manual;
      Location = mouseLocation;

      if(!IsFormFullyVisible(this)) {
        MoveToVisibleSpace(this);
      }

      _allowVisible = true;
      _isVisible = true;
      mFormHasBeenShown = true;

      Show();
    }

    /// <summary>
    /// Moves this window to visible space.
    /// </summary>
    private void MoveToVisibleSpace(Control form) {
      Rectangle windowRect = form.DisplayRectangle; // The dimensions of the ctrl
      windowRect.Y = form.Top; // Add in the real Top and Left Vals
      windowRect.X = form.Left;
      Rectangle screenRect = Screen.GetWorkingArea(form); // The Working Area of the screen showing most of the Ctrl

      // Now tweak the ctrl's Top and Left until it's fully visible. 
      this.Left += Math.Min(0, screenRect.Left + screenRect.Width - form.Left - form.Width);
      this.Left -= Math.Min(0, form.Left - screenRect.Left);
      this.Top += Math.Min(0, screenRect.Top + screenRect.Height - form.Top - form.Height);
      this.Top -= Math.Min(0, form.Top - screenRect.Top);
    }

    /// <summary>
    /// Determines whether [is point visible on A screen] [the specified point].
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns><c>true</c> if [is point visible on A screen] [the specified point]; otherwise, <c>false</c>.</returns>
    bool IsPointVisibleOnAScreen(Point point) {
      foreach(Screen s in Screen.AllScreens) {
        if(point.X > s.Bounds.Right &&
          point.X > s.Bounds.Left &&
          point.Y > s.Bounds.Top &&
          point.Y < s.Bounds.Bottom)
          return true;
      }

      return false;
    }

    /// <summary>
    /// Determines whether [is form fully visible] [the specified form].
    /// </summary>
    /// <param name="form">The form.</param>
    /// <returns><c>true</c> if [is form fully visible] [the specified form]; otherwise, <c>false</c>.</returns>
    bool IsFormFullyVisible(Form form) {
      return IsPointVisibleOnAScreen(new Point(form.Left, form.Top)) &&
             IsPointVisibleOnAScreen(new Point(form.Right, form.Top)) &&
             IsPointVisibleOnAScreen(new Point(form.Left, form.Bottom)) &&
             IsPointVisibleOnAScreen(new Point(form.Right, form.Bottom));
    }

    protected override void SetVisibleCore(bool value) {
      if(!_allowVisible) {
        value = false;
      }

      base.SetVisibleCore(value);
    }

    protected override void OnFormClosing(FormClosingEventArgs e) {
      if(!_allowClose) {
        Hide();
        e.Cancel = true;
      }

      base.OnFormClosing(e);
    }

    private void OnAuthorizationError(string message) {
      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Authorisation error", message, ToolTipIcon.Error);
    }

    private void OnGeneralError(string message) {
      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Error", message, ToolTipIcon.Error);
    }
  }
}
