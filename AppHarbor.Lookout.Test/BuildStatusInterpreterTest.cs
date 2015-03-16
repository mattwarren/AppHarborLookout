using System;
using System.Drawing;
using AppHarborLookout;
using NUnit.Framework;
using Fasterflect;

namespace AppHarbor.Lookout.Test {
  [TestFixture]
  public class BuildStatusInterpreterTest {
    [TestCase("failed", BuildStatus.Failed)]
    [TestCase("building", BuildStatus.Building)]
    [TestCase("queued", BuildStatus.Queued)]
    [TestCase("succeeded", BuildStatus.Succeeded)]
    [TestCase("any", BuildStatus.Unknown)]
    public void TestIfItKnowsTheBuildStatusCode(string status, BuildStatus expectedCode) {
      // Arrange
      var actual = BuildStatus.Unknown;
      var target = new BuildStatusInterpreter();

      // Act
      actual = target.GetBuildStatus(status);

      // Assert
      Assert.That(actual, Is.EqualTo(expectedCode));
    }

    [TestCase(BuildStatus.Building, null)]
    [TestCase(BuildStatus.Queued, null)]
    [TestCase(BuildStatus.Unknown, null)]
    [TestCase(BuildStatus.Succeeded, "Good job. The Build succeeded.")]
    [TestCase(BuildStatus.Failed, "The build is broken :(")]
    public void TestIfItKnowsTheBuildStatusMessages(BuildStatus status, string expectedMessage) {
      // Arrange
      string actual = "";
      var target = new BuildStatusInterpreter();

      // Act
      actual = target.GetBuildStatusMsg(status);

      // Assert
      Assert.That(actual, Is.EqualTo(expectedMessage));
    }
    
    
    [TestCase(BuildStatus.Building, "Orange")]
    [TestCase(BuildStatus.Queued, "Orange")]
    [TestCase(BuildStatus.Unknown, "Gray")]
    [TestCase(BuildStatus.Succeeded, "Green")]
    [TestCase(BuildStatus.Failed, "Red")]
    public void TestIfItKnowsTheBuildStatusColors(BuildStatus status, string colorName) {
      // Arrange
      var actualColor = new Color();
      var expectedColor = Color.FromName(colorName);
      var target = new BuildStatusInterpreter();

      // Act
      actualColor = target.GetBuildStatusColor(status);

      // Assert
      Assert.That(actualColor, Is.EqualTo(expectedColor));
    }

    [TestCase(BuildStatus.Building, "OrangeButton")]
    [TestCase(BuildStatus.Queued,  "OrangeButton")]
    [TestCase(BuildStatus.Unknown,  "GrayButton")]
    [TestCase(BuildStatus.Succeeded, "GreenButton")]
    [TestCase(BuildStatus.Failed, "RedButton")]
    public void TestIfItKnowsTheBuildStatusIcons(BuildStatus status, string expectedIconName) {
      // Arrange
      Icon actualIcon = null;
      Icon expectedIcon = (Icon)typeof(AppHarborLookout.Properties.Resources).GetPropertyValue(expectedIconName);
      var target = new BuildStatusInterpreter();

      // Act
      actualIcon = target.GetBuildStatusNotifyIcon(status);

      // Assert
      Assert.That(actualIcon.ToString(), Is.EqualTo(expectedIcon.ToString()));
    }


  }
}
