using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    private BuildProcessor buildProc;
    private string _latestBuildId;

    public AppHarborForm()
    {
      InitializeComponent();
      notifyIcon.ContextMenuStrip = contextMenuStrip;
      // TODO: Implement previous builds tab page
      tabControl.TabPages.Remove(previousBuildsTabPage);
      InitializeErrorsTab();
      InitializeClickEvents();
      InitializeBuildProcessor();
      notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout", "Monitoring your builds", ToolTipIcon.Info);
    }

    /// <summary>
    /// Initializes the build processor.
    /// </summary>
    private void InitializeBuildProcessor()
    {
      this.buildProc = new BuildProcessor(5000);
      this.buildProc.OnBuildProcessed += OnBuildProcessed;
      this.buildProc.OnGeneralError += OnBuildGeneralError;
      this.buildProc.OnAuthorizationError += OnBuildAuthorizationError;
    }

    /// <summary>
    /// Initializes the errors tab.
    /// </summary>
    private void InitializeErrorsTab()
    {
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
    }

    /// <summary>
    /// Initializes the click events.
    /// </summary>
    private void InitializeClickEvents()
    {
      buildLnk.LinkClicked += ProcessLinkClick;
      logLnk.LinkClicked += ProcessLinkClick;
      applicationLnk.LinkClicked += ProcessLinkClick;
      closeLinkLabel.Click += (sender, e) => HideMainScreen();

      mainToolStripMenuItem.Click += (sender, e) => ToggleMainScreen();
      reAuthoriseToolStripMenuItem.Click += (sender, e) => this.buildProc.UpdateAuthorizationDetails();
      exitToolStripMenuItem.Click += ExitApp;
      notifyIcon.Click += ProcessTrayIconClick;
    }

    /// <summary>
    /// Called when a [build is processed].
    /// </summary>
    /// <param name="info">The build info.</param>
    private void OnBuildProcessed(BuildInfo info)
    {
      if (info.LatestBuild == null)
        return;

      BuildStatus currentBuildStatus = statusProc.GetBuildStatus(info.LatestBuild.Status);

      if (!IsNewerBuild(info.LatestBuild.Id) 
        && !BuildStatusChanged(currentBuildStatus))
        return;

      //    Bug: Build status balloon tip showing several times.
      // Reason: Async calls were made before _LastBuildStatus was updated.
      //    Fix: lock(this) stops this from happening.
      lock (this)
      {
        this.SetNotifyIcon(currentBuildStatus);
        if (BuildStatusChanged(currentBuildStatus)
         && !string.IsNullOrEmpty(statusProc.GetBuildStatusMsg(currentBuildStatus)))
        {
          notifyIcon.ShowBalloonTip(
              timeout: 1000,
              tipTitle: "Build Status",
              tipText: statusProc.GetBuildStatusMsg(currentBuildStatus),
              tipIcon: ToolTipIcon.Warning);
        }

        if (this._FormHasBeenShown)
        {
          this.ProcessErrors(info.Errors);
          this.UpdateBuildUI(info.ApplicationName, info.LatestBuild, currentBuildStatus);
          this.SetNewerBuildId(info.LatestBuild.Id);
        }

        this._LastBuildStatus = currentBuildStatus;
      }
    }

    /// <summary>
    /// Processes the errors and displays them on UI.
    /// </summary>
    /// <param name="errors">The errors to process.</param>
    private void ProcessErrors(IEnumerable<Error> errors)
    {
      if (errors == null || errors.Count() <= 0)
        return;

      var errorsInfo = errors.Select(error => new
                      {
                        Date = error.Date
                                    .ParseAsDate()
                                    .FormatDateToStr(),
                        Value = error.GetErrorMessage()
                      }).ToList();

      dataGridViewErrors.Invoke((Action)
          (() =>
          {
            dataGridViewErrors.DataSource = errorsInfo;
            dataGridViewErrors.Show();
          }));
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
            lblCreateTime.Text = build.Created.FormatDateToStr();
            lblDeployTime.Text = IsDeployed(build) ? build.Deployed.FormatDateToStr() : "NOT DEPLOYED";
            lblDeployTime.ForeColor = IsDeployed(build) ? Color.Green : Color.Orange;
            buildLnk.SetupUrl(build.Url.AbsoluteUri);
            applicationLnk.SetupUrl(string.Format("http://{0}.apphb.com", appName.ToLowerInvariant()));
            txtCommitMsg.Text = build.Commit.Message;
            lblStatus.ForeColor = statusProc.GetBuildStatusColor(status);
          }));
    }

    /// <summary>
    /// Sets the newer build id.
    /// </summary>
    /// <param name="buildId">The build id.</param>
    private void SetNewerBuildId(string buildId)
    {
      this._latestBuildId = buildId;
    }

    /// <summary>
    /// Determines whether [is newer build] [the specified latest build].
    /// </summary>
    /// <param name="buildId">The build id.</param>
    /// <returns><c>true</c> if [is newer build] [the specified latest build]; otherwise, <c>false</c>.</returns>
    private bool IsNewerBuild(string buildId)
    {
      return string.IsNullOrEmpty(this._latestBuildId) || buildId != this._latestBuildId;
    }

    /// <summary>
    /// Determines if the status changed with respect to <paramref name="currentBuildStatus"/>
    /// </summary>
    /// <param name="currentBuildStatus">The current build status.</param>
    /// <returns>true if it changed, false otherwise.</returns>
    private bool BuildStatusChanged(BuildStatus currentBuildStatus)
    {
      return currentBuildStatus != this._LastBuildStatus;
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

    /// <summary>
    /// Exits the app.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void ExitApp(object sender, EventArgs e)
    {
      this._allowClose = true;
      this.Close();
      Environment.Exit(1);
    }

    /// <summary>
    /// Processes the tray icon click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void ProcessTrayIconClick(object sender, EventArgs e)
    {
      if (e is MouseEventArgs && (e as MouseEventArgs).Button == MouseButtons.Left)
      {
        this.ToggleMainScreen();
      }
    }

    /// <summary>
    /// Sets the notify icon.
    /// </summary>
    /// <param name="buildStatus">The build status.</param>
    private void SetNotifyIcon(BuildStatus buildStatus)
    {
      notifyIcon.Icon = statusProc.GetBuildStatusNotifyIcon(buildStatus);
      string text = string.Format(
@"AppHarbor Lookout
Build Status: {0}
Updated at: {1}",
                     buildStatus,
                     DateTime.Now.ToShortTimeString());

      notifyIcon.Text = string.Join(string.Empty, text.Take(63));
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
    /// Toggles the visibility of the main screen.
    /// </summary>
    private void ToggleMainScreen()
    {
      if (this._isVisible)
        this.HideMainScreen();
      else
        this.ShowMainScreen();
    }

    /// <summary>
    /// Hides the main screen.
    /// </summary>
    private void HideMainScreen()
    {
      this._isVisible = false;
      this.Hide();
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

      if (!this.IsFormFullyVisible())
        this.MoveToVisibleSpace();

      this._allowVisible = true;
      this._isVisible = true;
      this._FormHasBeenShown = true;
      this.Show();
    }

    /// <summary>
    /// Sets the visible core.
    /// </summary>
    /// <param name="value">true to make the control visible; otherwise, false.</param>
    protected override void SetVisibleCore(bool value)
    {
      base.SetVisibleCore(this._allowVisible && value);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the event data.</param>
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (!this._allowClose)
      {
        this.Hide();
        e.Cancel = true;
      }

      base.OnFormClosing(e);
    }

    /// <summary>
    /// Called when [build authorization error].
    /// </summary>
    /// <param name="message">The message.</param>
    private void OnBuildAuthorizationError(string message)
    {
      this.notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Authorization error", message, ToolTipIcon.Error);
    }

    /// <summary>
    /// Called when [build general error].
    /// </summary>
    /// <param name="message">The message.</param>
    private void OnBuildGeneralError(string message)
    {
      this.notifyIcon.ShowBalloonTip(1000, "AppHarbor Lookout - Error", message, ToolTipIcon.Error);
    }
  }
}
