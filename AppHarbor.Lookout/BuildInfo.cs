using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AppHarbor;
using AppHarbor.Model;

namespace AppHarborLookout
{
  public class BuildInfo
  {

    private readonly AppHarborClient _Client;
    private readonly IEnumerable<Application> _Applications;
    private string _ApplicationName;
    private Build _LatestBuild;
    private string _LatestAppId;
    private IEnumerable<Error> _Errors;
    private bool _CacheObtained;

    public BuildInfo(IEnumerable<Application> applications, AppHarborClient client)
    {
      Contract.Requires(applications != null);
      Contract.Requires(client != null);

      this._Applications = applications;
      this._Client = client;
    }

    /// <summary>
    /// Gets the name of the application.
    /// </summary>
    /// <value>The name of the application.</value>
    public string ApplicationName
    {
      get
      {
        if (!this._CacheObtained)
          this.UpdateCache();


        return _ApplicationName;
      }
    }

    /// <summary>
    /// Gets the latest build.
    /// </summary>
    /// <value>The latest build.</value>
    public Build LatestBuild
    {
      get
      {
        if (!this._CacheObtained)
          this.UpdateCache();


        return _LatestBuild;
      }
    }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    /// <value>The errors.</value>
    public IEnumerable<Error> Errors
    {
      get
      {
        if (!this._CacheObtained)
          this.UpdateCache();

        return this._Errors;
      }
    }

    /// <summary>
    /// Updates the cache.
    /// </summary>
    private void UpdateCache()
    {
      if (!this._Applications.Any())
        return;

      var appBuilds = this._Applications.Select(app => new
      {
        AppName = app.Name,
        AppId = app.Slug,
        LatestBuild = this._Client.GetBuilds(app.Slug)
                            .OrderByDescending(build => build.Created)
                            .FirstOrDefault()
      });      

      var appBuild = appBuilds.OrderByDescending(app => app.LatestBuild.Created).First();
      this._ApplicationName = appBuild.AppName;
      this._LatestAppId = appBuild.AppId;
      this._LatestBuild = appBuild.LatestBuild;
      this._Errors = _Client.GetErrors(appBuild.AppId);
      this._CacheObtained = true;

    }
  }
}
