using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Timers;
using AppHarbor;
using AppHarbor.Model;
using AppHarborLookout.Properties;

namespace AppHarborLookout {
  public class BuildProcessor {
    private Timer timer;

    /// <summary>
    /// Initializes a new instance of the <see cref="BuildProcessor" /> class.
    /// </summary>
    /// <param name="interval">The interval.</param>
    public BuildProcessor(double interval) {
      this.timer = new Timer() {
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
    protected virtual void RaiseBuildProcessedEvent(BuildInfo buildInfo) {
      // Raise the event by using the () operator. 
      if(OnBuildProcessed != null)
        OnBuildProcessed(buildInfo);
    }

    // Wrap the event in a protected virtual method 
    // to enable derived classes to raise the event. 
    protected virtual void RaiseAuthorizationErrorEvent(string message) {
      // Raise the event by using the () operator. 
      if(OnAuthorizationError != null)
        OnAuthorizationError(message);
    }

    // Wrap the event in a protected virtual method 
    // to enable derived classes to raise the event. 
    protected virtual void RaiseGeneralErrorEvent(string message) {
      // Raise the event by using the () operator. 
      if(OnGeneralError != null)
        OnGeneralError(message);
    }

    /// <summary>
    /// Called when [timer elapsed].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ElapsedEventArgs" /> instance containing the event data.</param>
    private void OnTimerElapsed(object sender, ElapsedEventArgs args) {
      try {
        if(String.IsNullOrWhiteSpace(Settings.Default.AccessToken)) {
          UpdateAuthorizationDetails();
        }

        var authInfo = new AuthInfo(Settings.Default.AccessToken, Settings.Default.TokenType);
        var client = new AppHarborClient(authInfo);
        IEnumerable<Application> applications = client.GetApplications();
        if(applications == null || applications.Count() == 0) {
          return;
        }

        RaiseBuildProcessedEvent(new BuildInfo(applications, client));
      } catch(System.Exception ex) {
        RaiseGeneralErrorEvent(ex.Message + Environment.NewLine + ex.StackTrace);
      } finally {
        timer.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
        timer.Start();
      }
    }

    /// <summary>
    /// Updates the authorization details.
    /// </summary>
    public void UpdateAuthorizationDetails() {
      var clientId = "49e17241-0631-47ec-bbf5-eface6552ea8";
      var clientSecret = "1d4e4d1b-9798-4bd3-bd86-f17ca00505e3";

      var result = GetAuthorization(clientId, clientSecret);
      var credentials = result.Item1;
      if(credentials != null) {
        Settings.Default.AccessToken = credentials.AccessToken;
        Settings.Default.TokenType = credentials.TokenType;
        Settings.Default.Save();
      } else {
        if(result.Item2 != null) {
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
    private Tuple<AuthInfo, string> GetAuthorization(string clientId, string clientSecret) {
      try {
        var authDetails = AppHarborClient.AskForAuthorization(clientId, clientSecret, TimeSpan.FromSeconds(30));
        return Tuple.Create<AuthInfo, string>(authDetails, null);
      } catch(AuthenticationException) {
        return Tuple.Create<AuthInfo, string>(null, "Failed to get authorization");
      } catch(TimeoutException) {
        return Tuple.Create<AuthInfo, string>(null, "Timeout, you have to be faster than that");
      } catch(System.Exception ex) {
        return Tuple.Create<AuthInfo, string>(null, ex.Message);
      }
    }
  }
}
