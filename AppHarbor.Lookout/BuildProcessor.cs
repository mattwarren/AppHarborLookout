using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Timers;
using AppHarbor;
using AppHarbor.Model;
using AppHarborLookout.Properties;

namespace AppHarborLookout
{
  public class BuildProcessor
  {
    private Timer timer;

    /// <summary>
    /// Initializes a new instance of the <see cref="BuildProcessor" /> class.
    /// </summary>
    /// <param name="interval">The interval.</param>
    public BuildProcessor(double interval)
    {
      this.timer = new Timer()
      {
        Enabled = true,
        Interval = interval
      };

      this.timer.Elapsed += OnTimerElapsed;
    }

    public delegate void BuildProcessedHandler(BuildInfo buildInfo);

    public delegate void ErrorHandler(string message);

    // Declare the event. 
    public event BuildProcessedHandler OnBuildProcessed;

    // Declare the event. 
    public event ErrorHandler OnAuthorizationError;

    // Declare the event. 
    public event ErrorHandler OnGeneralError;

    // Wrap the event in a protected virtual method 
    // to enable derived classes to raise the event. 
    protected virtual void RaiseBuildProcessedEvent(BuildInfo buildInfo)
    {
      // Raise the event by using the () operator. 
      if (OnBuildProcessed != null)
        OnBuildProcessed(buildInfo);
    }

    // Wrap the event in a protected virtual method 
    // to enable derived classes to raise the event. 
    protected virtual void RaiseAuthorizationErrorEvent(string message)
    {
      // Raise the event by using the () operator. 
      if (OnAuthorizationError != null)
        OnAuthorizationError(message);
    }

    // Wrap the event in a protected virtual method 
    // to enable derived classes to raise the event. 
    protected virtual void RaiseGeneralErrorEvent(string message)
    {
      // Raise the event by using the () operator. 
      if (OnGeneralError != null)
        OnGeneralError(message);
    }

    /// <summary>
    /// Called when [timer elapsed].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ElapsedEventArgs" /> instance containing the event data.</param>
    private void OnTimerElapsed(object sender, ElapsedEventArgs args)
    {
      try
      {
        /**
         * Too many unnecessary calls to re-authorize, so now authorization must
         * be manual
         * if (string.IsNullOrWhiteSpace(Settings.Default.AccessToken))
         * {
         *   UpdateAuthorizationDetails();
         * }
         **/

        var authInfo = new AuthInfo(Settings.Default.AccessToken, Settings.Default.TokenType);
        var client = new AppHarborClient(authInfo);
        IEnumerable<Application> applications = client.GetApplications();
        if (IsNullOrEmpty(applications))
        {
          return;
        }

        RaiseBuildProcessedEvent(new BuildInfo(applications, client));
      }
      catch (System.Exception ex)
      {
        RaiseGeneralErrorEvent(ex.Message + Environment.NewLine + ex.StackTrace);
      }
      finally
      {
        timer.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
        timer.Start();
      }
    }

    /// <summary>
    /// Updates the authorization details.
    /// </summary>
    public void UpdateAuthorizationDetails()
    {
      string clientId = "0b2b327d-3ca1-493c-a6b1-5fce5b0f376c";//"49e17241-0631-47ec-bbf5-eface6552ea8";
      string clientSecret = "61026cc0-7bf3-4baf-8833-db4f42a59246";//1d4e4d1b-9798-4bd3-bd86-f17ca00505e3";

      Tuple<AuthInfo, string> result = GetAuthorization(clientId, clientSecret);
      AuthInfo credentials = result.Item1;
      if (credentials != null)
      {
        Settings.Default.AccessToken = credentials.AccessToken;
        Settings.Default.TokenType = credentials.TokenType;
        Settings.Default.Save();
      }
      else
      {
        if (result.Item2 != null)
        {
          this.RaiseAuthorizationErrorEvent(result.Item2);
        }
      }
    }

    /// <summary>
    /// Gets the authorization.
    /// </summary>
    /// <param name="clientId">The client id.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <returns>Tuple{AuthInfoSystem.String}.</returns>
    private static Tuple<AuthInfo, string> GetAuthorization(string clientId, string clientSecret)
    {
      try
      {
        AuthInfo authDetails = AppHarborClient.AskForAuthorization(clientId, clientSecret, TimeSpan.FromSeconds(30));
        return Tuple.Create<AuthInfo, string>(authDetails, null);
      }
      catch (AuthenticationException)
      {
        return Tuple.Create<AuthInfo, string>(null, "AuthenticationException: Failed to get authorization");
      }
      catch (TimeoutException)
      {
        return Tuple.Create<AuthInfo, string>(null, "TimeoutException: You have to be faster than that");
      }
      catch (System.Exception ex)
      {
        return Tuple.Create<AuthInfo, string>(null, string.Format("Exception: {0}", ex.Message));
      }
    }

    private static bool IsNullOrEmpty<T>(IEnumerable<T> enumerable)
    {
      return enumerable == null || enumerable.Count() == 0;
    }
  }
}
