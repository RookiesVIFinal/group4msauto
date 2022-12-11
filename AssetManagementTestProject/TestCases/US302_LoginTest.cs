using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US302_LoginTest : NUnitWebTestSetup
{    
    protected ChangePassword1stTimePage? ChangePw1stTime;

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD)]
    public void TC01_UserLoginSuccess(string username, string password)
    {
        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    }
    [Test]
    public void TC02_UserIsAskedChangePasswordFirstTime()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        Asserter?.AssertElementIsDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
        Asserter?.AssertEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL + ChangePw1stTime.PathChangePw1stTime);
    }
    [Test] 
    public void TC03_UserCanLoginWithNewPassword()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        LoginPage?.Login(NewAdminUsername, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    }
    [Test]
    public void TC04To07_StaffCanLoginToTheApp()
    {
        LoginPage?.Login(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    }
    [Test]
    public void TC08To14_AdminCanLoginToTheApp()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageUserInMenu);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssetInMenu);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssignmentInMenu);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnManageReturningInMenu);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnReportInMenu);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.BtnAcceptAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.BtnDeclineAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.BtnRequestReturnAsset);
    }

}

