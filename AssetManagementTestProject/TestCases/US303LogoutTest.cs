using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303LogoutTest : NUnitWebTestSetup
{
    [Test]
    public void UserCanLogoutSuccessfully()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        Asserter.AssertElementsAreDisplayed(LoginPage.LoginPageElementUI());
    }

    [Test]
    public void UserCanCancelLogout()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage.SelectLogout();
        LogoutPopup.CancelLogOutOfPage();
        Asserter.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }

    [Test]
    public void UserCannotGoBackToHomePageAfterLogOut()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter.AssertElementsAreDisplayed(LoginPage.LoginPageElementUI());
    }

}
