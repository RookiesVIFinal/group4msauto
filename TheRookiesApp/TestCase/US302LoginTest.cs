using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.Common;
using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class US302LoginTest : NUnitTestSetUp
{
    [Test]
    public void ID01LoginAndLogoutTest()
    {
        TestSteps.LoginAsAdmin();

        LoginPage loginPage = new LoginPage();

        HomePage homePage = new HomePage();
        homePage.Logout();

        LogoutPopup logOutPopup = new LogoutPopup();
        logOutPopup.LogOutOfPage();

    }

    [Test]
    public void ID02LoginUnsuccessfully()
    {
        TestSteps.LoginFail();

        LoginPage loginPage = new LoginPage();
        loginPage.ErrorMessageDisplay();

    }

    [Test]
    public void ID03ChangePasswordInFirstLogin()
    {
        TestSteps.LoginWithNewPassword();

        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();
        homePage.ChangePassword();

    }

    [Test]
    public void ID04LoginWithNewPassword()
    {
        string user = "admin9";
        string newUser = "Admin@1234";
        TestSteps.LoginWithNewPassword();

        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();
        LogoutPopup logOutPopup = new LogoutPopup();

        homePage.ChangePassword();
        //homePage.Logout();
        //logOutPopup.LogOutOfPage();
        //loginPage.DoLogin(user, newUser);



    }
}
