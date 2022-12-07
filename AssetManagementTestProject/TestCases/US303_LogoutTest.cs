using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303_LogoutTest : NUnitWebTestSetup
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN)]
    [TestCase(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD)]
    public void UserCanLogoutSuccessfully(string userName, string password)
    {
        LoginPage?.Login(userName, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN)]
    [TestCase(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD)]
    public void UserCanCancelLogout(string userName, string password)
    {
        LoginPage?.Login(userName, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage.SelectLogout();
        LogoutPopup.CancelLogOutOfPage();
        Asserter.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN)]
    [TestCase(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD)]
    public void UserCannotGoBackToHomePageAfterLogOut(string userName, string password)
    {
        LoginPage?.Login(userName, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }

}

