using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHarbor.Model;
using AppHarborLookout;
using NSubstitute;
using NUnit.Framework;
using Fasterflect;

namespace AppHarbor.Lookout.Test
{
  [TestFixture]
  public class BuildInfoTest
  {
    /// <summary>
    /// Tests if it doesnt break on null applications.
    /// </summary>
    [TestAttribute]
    public void TestIfItDoesntBreakOnNullApplications()
    {
      // Arrange
      var target = new BuildInfo(
        new Application[] { }, 
        Substitute.For<AppHarborClient>(Substitute.For<AuthInfo>("", "")));

      // Act
      TestDelegate act = () => target.CallMethod("UpdateCache");

      // Assert
      Assert.DoesNotThrow(act);
      // Reset
    }
  }
}
