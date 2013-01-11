using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AppHarbor;
using AppHarbor.Model;

namespace AppHarborLookout {
  public class BuildInfo {

    private AppHarborClient mClient;
    private IEnumerable<Application> mApplications;
    private string mApplicationName;
    private Build mLatestBuild = null;
    private string mLatestAppId = null;
    private IEnumerable<Error> mErrors;
    private bool mCacheObtained = false;

    public BuildInfo(IEnumerable<Application> applications, AppHarborClient client) {
      Contract.Requires(applications != null);
      Contract.Requires(client != null);

      this.mApplications = applications;
      this.mClient = client;      
    }    

    /// <summary>
    /// Gets the name of the application.
    /// </summary>
    /// <value>The name of the application.</value>
    public string ApplicationName {
      get {        
        if(!mCacheObtained) {          
          UpdateCache();
        }

        return mApplicationName;
      }
    }

    /// <summary>
    /// Gets the latest build.
    /// </summary>
    /// <value>The latest build.</value>
    public Build LatestBuild {
      get {
        if(!mCacheObtained) {
          UpdateCache();
        }

        return mLatestBuild;
      }
    }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    /// <value>The errors.</value>
    public IEnumerable<Error> Errors {
      get {
        if(!mCacheObtained) {
          UpdateCache();
        }

        return this.mErrors;
      }
    }

    /// <summary>
    /// Updates the cache.
    /// </summary>
    private void UpdateCache() {
      var latestApp = mApplications.Select(app => new {
        AppName = app.Name,
        AppId = app.Slug,
        LatestBuild = mClient.GetBuilds(app.Slug)
                            .OrderByDescending(build => build.Created)
                            .FirstOrDefault()
      })
      .OrderByDescending(app => app.LatestBuild.Created)
      .FirstOrDefault();

      if(latestApp != null) {
        this.mApplicationName = latestApp.AppName;
        this.mLatestAppId = latestApp.AppId;
        this.mLatestBuild = latestApp.LatestBuild;
        this.mErrors = mClient.GetErrors(this.mLatestAppId);
      }
    }
  }
}
