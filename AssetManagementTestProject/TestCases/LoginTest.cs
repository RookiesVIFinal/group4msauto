using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [Test]
    public void FirstLogin()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        HomePage.VerifyFirstLogin();
        HomePage.ChangePwFirstTimeLogIn();
        LogoutPopup.LogOutOfPage();
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD);
        HomePage.VerifyCorrectDirectToHome();
    }
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USERNANE, Constant.CHANGED_STAFF_PASSWORD)]
    public void LoginAuthority(string userName, string password)
    {
        LoginPage.Login(userName, password);
        HomePage.VerifyCorrectDirectToHome();
        HomePage.VerifyMenuBar();
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
    }

}

