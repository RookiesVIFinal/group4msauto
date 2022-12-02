using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    protected ChangePassword1stTimePage ChangePw1stTime;

    [SetUp]
    public void SetUp()
    {
        ChangePw1stTime = new ChangePassword1stTimePage();
    }
    [Test]
    public void UserLoginSuccess()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction.WaitToBeVisible(HomePage.ReturnHeaderHomePage());
        DriverBaseAction.CompareUrls(Constant.BASE_URL);
    }
    [Test]
    public void UserLoginFirstTime()
    {
        LoginPage.Login(Constant.STAFF_USERNAME_1ST_TIME, Constant.STAFF_PASSWORD_1ST_TIME);
        DriverBaseAction.IsElementDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
        DriverBaseAction.CompareUrls(ChangePw1stTime.ReturnExpectedChangePw1stTimeUrl());
    }
    [Test] 
    public void UserLoginWithNewPassword()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME, Constant.CHANGED_ADMIN_PASSWORD);
        DriverBaseAction.WaitToBeVisible(HomePage.ReturnHeaderHomePage());
        DriverBaseAction.CompareUrls(Constant.BASE_URL);
    }
    [Test]
    public void AdminCanLoginToTheApp()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        DriverBaseAction.AreElementsDisplayed(MenuBarLeft.ReturnMenuBar());
    }
    [Test]
    public void StaffCanLoginToTheApp()
    {
        LoginPage.Login(Constant.STAFF_USERNAME, Constant.STAFF_PASSWORD);
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnHomeBtn());
    }
    [TearDown]
    public void TearDown()
    {
    }
}

