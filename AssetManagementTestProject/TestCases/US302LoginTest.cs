using AssetManagementTestProject.Common;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class US302LoginTest : NUnitWebTestSetup
{
    [Test] // For testing
    public void UserCanLoginAndLogout()
    {
        AssetManagementTestBase.LoginFLow(Driver);
        HomePage homePage = new HomePage(Driver);
        homePage.UserCanLogout();
        LogoutPopup logOutPopup = new LogoutPopup(Driver);
        logOutPopup.LogOutOfPage();
    }
}