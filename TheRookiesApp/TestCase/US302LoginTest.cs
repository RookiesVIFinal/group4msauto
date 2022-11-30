using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.Common;
using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class US302LoginTest : NUnitTestSetUp
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    public void ID01LoginAndLogoutTest(string userName, string password)
    {
        LoginPage.DoLogin(userName, password);
        HomePage.Logout();

        LogoutPopup logOutPopup = new LogoutPopup();
        logOutPopup.LogOutOfPage();

    }
}
