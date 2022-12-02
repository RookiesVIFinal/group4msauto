using NUnit.Framework;
using NUnit.Framework.Internal;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303LogoutTest : NUnitWebTestSetup
{
    #region STAFF AND ADMIN LOGOUT
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void LogoutSuccessfully(string userName, string password)
    {
        LoginPage.Login(userName, password); 
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        DriverBaseAction.CompareUrls(Constant.LOGIN_PAGE_URl);
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void CancelLogout(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.CancelLogOutOfPage();
        DriverBaseAction.CompareUrls(Constant.BASE_URL);
    }

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD)]
    public void CannotGoBackToHomePageAfterLogOut(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnHomePageUrl(), Constant.BASE_URL);

        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
        DriverBaseAction.MoveBackward();
        DriverBaseAction.CompareUrls(Constant.LOGIN_PAGE_URl);
    }
    #endregion

}
