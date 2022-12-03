using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{    
    protected ChangePassword1stTimePage? ChangePw1stTime; 

    [SetUp]
    public void TestSetUp()
    {
        ChangePw1stTime = new ChangePassword1stTimePage();
    }
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
        Asserter.AssertElementsAreDisplayed(MenuBarLeft.ReturnMenuBar());
    }
    [Test]
    public void StaffCanLoginToTheApp()
    {
        LoginPage.Login(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD);
        Asserter.AssertElementIsDisplayed(MenuBarLeft.ReturnHomeBtn());
    }
    [TearDown]
    public void TestTearDown()
    {
    }
}

