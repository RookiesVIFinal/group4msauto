using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [Test]
    public void UserLoginSuccess()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.BASE_URL);
    }
    [Test]
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    public void UserCanLoginToTheApp(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.BASE_URL);
        DriverBaseAction.AreElementsDisplayed(MenuBarLeft.ReturnMenuBar());
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
    }
}

