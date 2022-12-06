using NUnit.Framework;
using NUnit.Framework.Internal;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303LogoutTest : NUnitWebTestSetup
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void UserCanLogoutSuccessfully(string userName, string password)
    {
        LoginPage.Login(userName, password); 
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        Asserter.AssertElementsAreDisplayed(LoginPage.LoginPageElementUI());
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void UserCanCancelLogout(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.CancelLogOutOfPage();
        Asserter.AssertUrlEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void UserCannotGoBackToHomePageAfterLogOut(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter.AssertElementsAreDisplayed(LoginPage.LoginPageElementUI());
    }

}
