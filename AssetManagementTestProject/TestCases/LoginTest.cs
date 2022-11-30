using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    public void TestLoginAuthority(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.BASE_URL);
        DriverBaseAction.AreElementsDisplayed(MenuBarLeft.ReturnMenuBar());
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
    }

}

