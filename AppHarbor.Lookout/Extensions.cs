using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AppHarbor.Model;
using System.Collections.Generic;

namespace AppHarborLookout
{
  public static class Extensions
  {
    /// <summary>
    /// Moves this window to visible space.
    /// </summary>
    public static void MoveToVisibleSpace(this Control form)
    {
      Rectangle windowRect = form.DisplayRectangle; // The dimensions of the ctrl
      windowRect.Y = form.Top; // Add in the real Top and Left Vals
      windowRect.X = form.Left;
      Rectangle screenRect = Screen.GetWorkingArea(form); // The Working Area of the screen showing most of the Ctrl
      // Now tweak the ctrl's Top and Left until it's fully visible. 
      form.Left += Math.Min(0, screenRect.Left + screenRect.Width - form.Left - form.Width);
      form.Left -= Math.Min(0, form.Left - screenRect.Left);
      form.Top += Math.Min(0, screenRect.Top + screenRect.Height - form.Top - form.Height);
      form.Top -= Math.Min(0, form.Top - screenRect.Top);
    }

    /// <summary>
    /// Gets the error message as a formatted string.
    /// </summary>
    /// <param name="error">The errorMessageTabPage.</param>
    /// <returns>The message as a string.</returns>
    public static string GetErrorMessage(this Error error)
    {
      return string.Format("{0} {1}", error.Request_Path, error.Exception != null ? error.Exception.Message : error.Message);
    }

    /// <summary>
    /// Parses the date.
    /// </summary>
    /// <param name="rawDate">The raw date.</param>
    /// <returns>The DateTime</returns>
    public static DateTime ParseAsDate(this string rawDate)
    {
      DateTime date;
      var cleanedUpDate = rawDate.Replace("T", " ").Replace("Z", string.Empty);
      if (DateTime.TryParseExact(cleanedUpDate, "yyyy-MM-dd hh:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date))
      {
        return date;
      }
      return default(DateTime);
    }

    /// <summary>
    /// Gets the date string format for the DateTime object.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <returns>A date time string in dd/MM hh:mm format</returns>
    public static string FormatDateToStr(this DateTime date)
    {
      return date.ToString("MMM-dd hh:mm tt");
    }

    /// <summary>
    /// Sets up a link label with an URL string.
    /// </summary>
    /// <param name="urlLinkLabel">The URL link label.</param>
    /// <param name="url">The URL string.</param>
    public static void SetupUrl(this LinkLabel urlLinkLabel, string url)
    {
      urlLinkLabel.Links.Remove(urlLinkLabel.Links[0]);
      urlLinkLabel.Links.Add(0, urlLinkLabel.Text.Length, url);
      urlLinkLabel.Enabled = true;
    }


    /// <summary>
    /// Determines whether [is form fully visible] [the specified form].
    /// </summary>
    /// <param name="form">The form.</param>
    /// <returns><c>true</c> if [is form fully visible] [the specified form]; otherwise, <c>false</c>.</returns>
    public static bool IsFormFullyVisible(this Form form)
    {
      return IsPointVisibleOnAScreen(form.Left, form.Top) &&
             IsPointVisibleOnAScreen(form.Right, form.Top) &&
             IsPointVisibleOnAScreen(form.Left, form.Bottom) &&
             IsPointVisibleOnAScreen(form.Right, form.Bottom);
    }

    /// <summary>
    /// Determines whether [is point visible on A screen] [the specified point].
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="x"></param>

    /// <returns><c>true</c> if [is point visible on A screen] [tye specified point]; otherwise, <c>false</c>.</returns>
    private static bool IsPointVisibleOnAScreen(int x, int y)
    {
      foreach (Screen screen in Screen.AllScreens)
      {
        if (IsPointInRect(x, y, screen.Bounds))
          return true;
      }

      return false;
    }

    /// <summary>
    /// Determines whether [is point in rectangle] [the specified x, y].
    /// </summary>
    /// <param name="x">The x coord.</param>
    /// <param name="y">The y coord.</param>
    /// <param name="bounds">The bounds.</param>
    /// <returns><c>true</c> if [is point in rect] [the specified x, y]; otherwise, <c>false</c>.</returns>
    private static bool IsPointInRect(int x, int y, Rectangle bounds)
    {
      return x > bounds.Right &&
                x > bounds.Left &&
                y > bounds.Top &&
                y < bounds.Bottom;
    }
  }
}
