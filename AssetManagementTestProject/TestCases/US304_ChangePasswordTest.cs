using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;

public class US304_ChangePasswordTest : NUnitWebTestSetup
{
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ChangePasswordPage? ChangePassword;

    [Test]
    public void TC01_UserCanChangePWSuccsessfullyForTheFirstTimeLogIn()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    }

    [TestCase(LoginTestData.CHANGED_USER_PASSWORD, LoginTestData.STAFF_PASSWORD)]
    public void TC02_UserCanChangePWSuccessfully(string newPassword, string oldPassword)
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        ChangePassword = new ChangePasswordPage();
        ChangePassword?.SelectChangePassword();
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayChangePwPopUp());
        ChangePassword?.ChangeNewPwSuccessfully(oldPassword, newPassword);
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayChangePwSuccessfully());
    }

    [Test]
    public void TC03_UserCanCancelChangePWAction()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        ChangePassword = new ChangePasswordPage();
        ChangePassword?.SelectCancel();
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    }

    [TestCase(LoginTestData.INCORRECT_USER_NEW_PASSWORD, LoginTestData.INCORRECT_USER_OLD_PASSWORD)]
    public void TC04_UserChangePwUnsuccessfully(string incorrectNewPw, string incorrectOldPw)
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(LoginTestData.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        ChangePassword = new ChangePasswordPage();
        ChangePassword?.SelectChangePassword();
        DriverBaseAction?.WaitToBeVisible(ChangePassword.HeaderChangePw);
        Asserter?.AssertElementIsDisplayed(ChangePassword.HeaderChangePw);
        ChangePassword?.ChangeNewPwUnSuccessfully(incorrectOldPw, incorrectNewPw);
        DriverBaseAction?.WaitToBeVisible(ChangePassword.ErrorMessagesOldPw);
        Asserter?.AssertElementIsDisplayed(ChangePassword.ErrorMessagesOldPw);
        DriverBaseAction?.WaitToBeVisible(ChangePassword.ErrorMessagesNewPw);
        Asserter?.AssertElementIsDisplayed(ChangePassword.ErrorMessagesNewPw);
    }

}
