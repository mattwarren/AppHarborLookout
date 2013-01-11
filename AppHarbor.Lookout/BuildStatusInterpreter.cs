using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AppHarborLookout.Properties;

namespace AppHarborLookout {
  public class BuildStatusInterpreter {
    /// <summary>
    /// Gets the build status code for a status string.
    /// </summary>
    /// <param name="status">The status string.</param>
    /// <returns>A BuildStatusCode.</returns>
    public BuildStatus GetBuildStatus(string status) {
      switch(status.ToLowerInvariant()) {
        case "failed":
          return BuildStatus.Failed;
        case "succeeded":
          return BuildStatus.Succeeded;
        case "queued":
          return BuildStatus.Queued;
        case "building":
          return BuildStatus.Building;
      }

      return BuildStatus.Unknown;
    }

    /// <summary>
    /// Gets the build status message.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns>The System.String message.</returns>
    public string GetBuildStatusMsg(BuildStatus current) {
      switch(current) {
        case BuildStatus.Succeeded:
          return "Good job. The Build succeeded.";
        case BuildStatus.Failed:
          return "The build is broken :(";
        default:
          return null;
      }
    }

    /// <summary>
    /// Gets the colour for build status.
    /// </summary>
    /// <param name="currentBuildStatus">The current build status.</param>
    /// <returns>Color.</returns>
    public Color GetBuildStatusColor(BuildStatus currentBuildStatus) {
      switch(currentBuildStatus) {
        case BuildStatus.Failed:
          return Color.Red;
        case BuildStatus.Building:
        case BuildStatus.Queued:
          return Color.Orange;
        case BuildStatus.Succeeded:
          return Color.Green;
        default:
          return Color.Gray;
      }
    }

    /// <summary>
    /// Gets the build status notify icon.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <returns>Icon.</returns>
    public Icon GetBuildStatusNotifyIcon(BuildStatus status) {
      switch(status) {
        case BuildStatus.Failed:
          return Resources.RedButton;
        case BuildStatus.Succeeded:
          return Resources.GreenButton;
        case BuildStatus.Queued:
        case BuildStatus.Building:
          return Resources.OrangeButton;
        default:
          return Resources.GrayButton;
      }
    }
  }

  public enum BuildStatus {
    Building,
    Failed,
    Queued,
    Succeeded,
    Unknown
  }
}
