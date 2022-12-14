using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCases;

[TestFixture]
public class US303_LogoutTest : NUnitWebTestSetup
{
    [Test]
    public void TC01_AdminCanLogoutSuccessfully()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime?.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }
    [Test]
    public void TC02_AdminCanCancelLogout()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime?.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.CancelLogOutOfPage();
        Asserter?.AssertEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }
    [Test]
    public void TC03_AdminCannotGoBackToHomePageAfterLogOut()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime?.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }
    [Test]
    public void TC04_StaffCanLogoutSuccessfully()
    {
        LoginPage?.Login(LoginTestData.STAFF_USERNAME, LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }
    [Test]
    public void TC05_StaffCanCancelLogout()
    {
        LoginPage?.Login(LoginTestData.STAFF_USERNAME, LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.CancelLogOutOfPage();
        Asserter?.AssertEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }
    [Test]
    public void TC06_StaffCannotGoBackToHomePageAfterLogOut()
    {
        LoginPage?.Login(LoginTestData.STAFF_USERNAME, LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }
}
