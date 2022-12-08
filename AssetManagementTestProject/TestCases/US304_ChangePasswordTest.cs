using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;

public class US304ChangePasswordTest : NUnitWebTestSetup
{
    [Test]
    public void TC01_UserCanChangePWSuccsessfullyForTheFirstTimeLogIn()
    {
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    }

    [TestCase(Constant.CHANGED_USER_PASSWORD, Constant.STAFF_PASSWORD)]
    public void TC02_UserCanChangePWSuccessfully(string newPassword, string oldPassword)
    {
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        ChangePassword?.SelectChangePassword();
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayChangePwPopUp());
        ChangePassword?.ChangeNewPwSuccessfully(oldPassword, newPassword);
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayChangePwSuccessfully());
    }

    [Test]
    public void TC03_UserCanCancelChangePWAction()
    {

        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(MenuBarLeft.BtnHomeInMenu);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        ChangePassword?.SelectCancel();
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
    }

    [TestCase(Constant.INCORRECT_USER_NEW_PASSWORD, Constant.INCORRECT_USER_OLD_PASSWORD)]
    public void TC04_UserChangePwUnsuccessfully(string incorrectNewPw, string incorrectOldPw)
    {
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        ChangePassword?.SelectChangePassword();
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayChangePwPopUp());
        ChangePassword?.ChangeNewPwUnSuccessfully(incorrectOldPw, incorrectNewPw);
        Asserter?.AssertElementIsDisplayed(ChangePassword.DisplayErrorMessages());
    }

}
