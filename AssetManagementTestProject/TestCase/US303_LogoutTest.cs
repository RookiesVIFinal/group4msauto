using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303_LogoutTest : NUnitWebTestSetup
{

    [Test]
    public void TC01_UserCanLogoutSuccessfully()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }


    [Test]
    public void TC02_UserCanCancelLogout()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        HomePage?.SelectLogout();
        LogoutPopup?.CancelLogOutOfPage();
        Asserter?.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }


    [Test]
    public void TC03_UserCannotGoBackToHomePageAfterLogOut()
    {
        LoginPage?.Login(NewAdminUsername, NewAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);

        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }

}