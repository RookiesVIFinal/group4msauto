using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;
using TheRookiesApp.Asserter;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class US303LogoutTest : NUnitTestSetUp
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    public void ID01LogoutWhenClickOnLogoutButtonTest(string userName, string password)
    {
        LoginPage.DoLogin(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.HOME_PAGE_URL);
        DriverBaseAction.AreElementsDisplayed(MenuBarLeft.ReturnMenuBar());
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        LoginPage.IsCorrectRedirect();
    }
}
