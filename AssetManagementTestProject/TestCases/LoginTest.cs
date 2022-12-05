using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{    
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ManageUserService? ManageUserService;
    [Test]
    public void UserLoginSuccess()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    }
    [Test]
    public void UserAskedChangePasswordFirstTime()
    {
        LoginPage.Login(Constant.STAFF_USERNAME_1ST_TIME, Constant.STAFF_PASSWORD_1ST_TIME);
        ChangePw1stTime = new ChangePassword1stTimePage();
        Asserter.AssertElementIsDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
        Asserter.AssertUrlsEquals(DriverBaseAction?.GetUrl(), ChangePw1stTime.ReturnExpectedChangePw1stTimeUrl());
    }
    [Test] 
    public void UserLoginWithNewPassword()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME, Constant.CHANGED_ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter.AssertUrlsEquals(DriverBaseAction?.GetUrl(),Constant.BASE_URL);
    }
    [Test]
    public void AdminCanLoginToTheApp()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnManageUserInMenu);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssetInMenu);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnManageAssignmentInMenu);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnManageReturningInMenu);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnReportInMenu);
    }
    [Test]
    public void StaffCanLoginToTheApp()
    {
        LoginPage.Login(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
    }
}

