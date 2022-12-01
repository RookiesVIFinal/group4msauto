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
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);
    }
    [Test]
    public void UserLoginFirstTime()
    {
        LoginPage.Login(Constant.STAFF_USERNAME_1, Constant.BASE_STAFF_PASSWORD_1);
        DriverBaseAction.IsElementDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
        DriverBaseAction.CompareUrls(ChangePw1stTime.ReturnExpectedChangePw1stTimeUrl());
    }
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    public void UserCanLoginToTheApp(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);
        DriverBaseAction.AreElementsDisplayed(MenuBarLeft.ReturnMenuBar());
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
    }
}

