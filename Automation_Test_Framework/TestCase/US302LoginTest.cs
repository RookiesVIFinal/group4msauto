using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.Common;
using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class US302LoginTest : NUnitWebAndAPITestSetUp
{
    [Test]
    public void ID01LoginAndLogoutTest()
    {
        CommonFlow.LoginFlowAdmin(Driver);

        LoginPage loginPage = new LoginPage(Driver);

        HomePage homePage = new HomePage(Driver);
        homePage.IsCorrectRedirect();
        homePage.UserCanLogout();

        LogoutPopup logOutPopup = new LogoutPopup(Driver);
        logOutPopup.LogOutOfPage();

    }
}
