using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AppHarbor.Model;

namespace AppHarborLookout
{

  public partial class AppHarborForm : Form
  {
    private bool _allowVisible = false;
    private bool _allowClose = false;
    private bool _FormHasBeenShown = false;
    private bool _isVisible = false;
    private readonly BuildStatusInterpreter statusProc = new BuildStatusInterpreter();
    private BuildStatus _LastBuildStatus = BuildStatus.Unknown;
    private readonly BuildProcessor buildProc;

    public AppHarborForm()
    {
      InitializeComponent();
      notifyIcon.ContextMenuStrip = contextMenuStrip;
      // TODO: Implement previous builds tab page
      tabControl.TabPages.Remove(previousBuildsTabPage);

      var subTitleColumn = new DataGridViewTextBoxColumn()
      {
        HeaderText = "Subtitle",
        MinimumWidth = 50,
        FillWeight = 65,
        DataPropertyName = "Date"
      };

      var summaryColumn = new DataGridViewTextBoxColumn()
      {
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
      this.buildProc.OnGeneralError += OnBuildGeneralError;
      this.buildProc.OnAuthorizationError += OnBuildAuthorizationError;

      buildLnk.LinkClicked += ProcessLinkClick;
      logLnk.LinkClicked += ProcessLinkClick;
      applicationLnk.LinkClicked += ProcessLinkClick;

      mainToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();

      reAuthoriseToolStripMenuItem.Click += (sender, e) => this.buildProc.UpdateAuthorizationDetails();

      exitToolStripMenuItem.Click += ExitLookoutApp;

      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout", "Monitoring your builds", ToolTipIcon.Info);
      notifyIcon.Click += ProcessTrayIconClick;

      closeLinkLabel.Click += (sender, e) => HideMainScreen();
    }

    /// <summary>
    /// Called when a [build is processed].
    /// </summary>
    /// <param name="info">The build info.</param>
    private void OnBuildProcessed(BuildInfo info)
    {
      if (info.Errors != null && info.Errors.Count() > 0)
      {
        var errorInfo = info.Errors.Select(x => new
        {
          Date = ParseDate(x.Date).ToString(),
          Value = GetErrorMessage(x)
        }).ToList();

        if (this._FormHasBeenShown)
        {
          dataGridViewErrors.Invoke((Action)
              (() =>
              {
                dataGridViewErrors.DataSource = errorInfo;
                dataGridViewErrors.Show();
              }));
        }
      }

      if (info.LatestBuild == null)
      {
        return;
      }

      BuildStatus currentBuildStatus = statusProc.GetBuildStatus(info.LatestBuild.Status);
      this.SetNotifyIcon(currentBuildStatus);

      if (currentBuildStatus != this._LastBuildStatus)
      {
        string buildStatusMsg = statusProc.GetBuildStatusMsg(currentBuildStatus);
        if (!string.IsNullOrEmpty(buildStatusMsg))
        {
          notifyIcon.ShowBalloonTip(
              timeout: 1000,
              tipTitle: "Build Status",
              tipText: buildStatusMsg,
              tipIcon: ToolTipIcon.Warning);
        }
      }

      if (this._FormHasBeenShown)
        this.UpdateBuildUI(info.ApplicationName, info.LatestBuild, currentBuildStatus);


      if (currentBuildStatus == BuildStatus.Succeeded || currentBuildStatus == BuildStatus.Failed)
        this._LastBuildStatus = currentBuildStatus;

    }

    /// <summary>
    /// Updates the build UI.
    /// </summary>
    /// <param name="appName">Name of the application.</param>
    /// <param name="build">The build.</param>
    /// <param name="status">The status.</param>
    private void UpdateBuildUI(string appName, Build build, BuildStatus status)
    {
      currentInfoTabPage.Invoke((Action)
          (() =>
          {
            pictureBoxLoadingSpinner.Hide();
            lblAppName.Text = appName;
            lblStatus.Text = build.Status;
            lblCreateTime.Text = GetDateStr(build.Created);
            lblDeployTime.Text = IsDeployed(build) ? GetDateStr(build.Deployed) : "NOT DEPLOYED";
            lblDeployTime.ForeColor = IsDeployed(build) ? Color.Green : Color.Orange;
            SetupUrl(buildLnk, build.Url.AbsoluteUri);
            SetupUrl(applicationLnk, String.Format("http://{0}.apphb.com", appName.ToLowerInvariant()));
            lblCommitMsg.Text = build.Commit.Message;
            lblStatus.ForeColor = statusProc.GetBuildStatusColor(status);
          }));
    }

    /// <summary>
    /// Processes the link click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs" /> instance containing the event data.</param>
    private void ProcessLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (e.Link.LinkData is string)
        Process.Start(e.Link.LinkData.ToString());
    }

    private void ExitLookoutApp(object sender, EventArgs e)
    {
      _allowClose = true;
      Close();
      Environment.Exit(1);
    }
    private void ProcessTrayIconClick(object sender, EventArgs e)
    {
      if (e is MouseEventArgs && (e as MouseEventArgs).Button == MouseButtons.Left)
      {
        ToggleMainScreen();
      }
    }
    /// <summary>
    /// Gets the date string format for the DateTime object.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <returns>A date time string in dd/MM hh:mm format</returns>
    private static string GetDateStr(DateTime date)
    {
      return date.ToString("dd/MM hh:mm");
    }

    /// <summary>
    /// Determines whether the specified build is deployed.
    /// </summary>
    /// <param name="build">The build object.</param>
    /// <returns><c>true</c> if the specified build is deployed; otherwise, <c>false</c>.</returns>
    private static bool IsDeployed(Build build)
    {
      return build.Deployed != DateTime.MinValue;
    }

    /// <summary>
    /// Sets the notify icon.
    /// </summary>
    /// <param name="buildStatus">The build status.</param>
    private void SetNotifyIcon(BuildStatus buildStatus)
    {
      notifyIcon.Icon = statusProc.GetBuildStatusNotifyIcon(buildStatus);
      var text = String.Format(
@"AppHarbor Lookout
Build Status: {0}
Updated at: {1}",
               buildStatus, DateTime.Now.ToShortTimeString());

      notifyIcon.Text = string.Join(string.Empty, text.Take(63));
    }

    private static void SetupUrl(LinkLabel urlLinkLabel, string url)
    {
      urlLinkLabel.Links.Remove(urlLinkLabel.Links[0]);
      urlLinkLabel.Links.Add(0, urlLinkLabel.Text.Length, url);
      urlLinkLabel.Enabled = true;
    }

    private static DateTime ParseDate(string rawDate)
    {
      DateTime date;
      var cleanedUpDate = rawDate.Replace("T", " ").Replace("Z", string.Empty);
      if (DateTime.TryParseExact(
              cleanedUpDate,
              "yyyy-MM-dd hh:mm:ss.fff",
              CultureInfo.InvariantCulture,
              DateTimeStyles.AssumeUniversal,
              out date))
      {
        return date;
      }

      return default(DateTime);
    }

    private static string GetErrorMessage(Error x)
    {
      return string.Format("{0} {1}", x.Request_Path, x.Exception != null ? x.Exception.Message : x.Message);
    }

    /// <summary>
    /// Toggles the visibility of the main screen.
    /// </summary>
    private void ToggleMainScreen()
    {
      if (_isVisible)
        HideMainScreen();
      else
        ShowMainScreen();
    }

    /// <summary>
    /// Hides the main screen.
    /// </summary>
    private void HideMainScreen()
    {
      this._isVisible = false;
      Hide();
    }

    /// <summary>
    /// Shows the main screen.
    /// </summary>
    private void ShowMainScreen()
    {
      var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
      var mouseLoc = new Point(cursorPos.X - Width, cursorPos.Y - Height - 15);

      if (mouseLoc.Y < 15)
        mouseLoc.Y = 15;

      this.StartPosition = FormStartPosition.Manual;
      this.Location = mouseLoc;

      if (!IsFormFullyVisible(this))
        MoveToVisibleSpace(this);

      this._allowVisible = true;
      this._isVisible = true;
      this._FormHasBeenShown = true;
      this.Show();
    }

    /// <summary>
    /// Moves this window to visible space.
    /// </summary>
    private void MoveToVisibleSpace(Control form)
    {
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
    static bool IsPointVisibleOnAScreen(Point point)
    {
      foreach (Screen s in Screen.AllScreens)
      {
        if (point.X > s.Bounds.Right &&
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
    static bool IsFormFullyVisible(Form form)
    {
      return IsPointVisibleOnAScreen(new Point(form.Left, form.Top)) &&
             IsPointVisibleOnAScreen(new Point(form.Right, form.Top)) &&
             IsPointVisibleOnAScreen(new Point(form.Left, form.Bottom)) &&
             IsPointVisibleOnAScreen(new Point(form.Right, form.Bottom));
    }

    protected override void SetVisibleCore(bool value)
    {
      base.SetVisibleCore(_allowVisible && value);
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

    private void OnBuildAuthorizationError(string message)
    {
      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Authorisation error", message, ToolTipIcon.Error);
    }

    private void OnBuildGeneralError(string message)
    {
      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Error", message, ToolTipIcon.Error);
    }
  }
}
