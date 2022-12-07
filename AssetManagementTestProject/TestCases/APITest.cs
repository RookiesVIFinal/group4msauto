using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestData;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    public class US302_LoginTest : NUnitWebTestSetup
    {
        protected ChangePassword1stTimePage? ChangePw1stTime;


        [Test]
        public void TC01_UserLoginSuccess()
        {
            LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
            DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
            Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        }
        [Test]
        public void TC02_UserAskedChangePasswordFirstTime()
        {
            AuthorizationService = new AssetManagementAPIServices();
            Token = AuthorizationService.ReturnLoginToken(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
            newUserService = new AssetManagementAPIServices();
            newUser = newUserService.ReturnNewUser(Constant.NEW_ADMIN_HN, Token);
            FirstTimeLoginData newLoginData = new FirstTimeLoginData();
            newLoginData.newUser = newUser;
            string newAdminUsername = newLoginData.GetUsername();
            string newAdminPassword = newLoginData.GetPassword();
            LoginPage?.Login(newAdminUsername, newAdminPassword);
            ChangePw1stTime = new ChangePassword1stTimePage();
            Asserter?.AssertElementIsDisplayed(ChangePw1stTime.AskChangePwFirstLogin());
            Asserter?.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL + ChangePw1stTime.pathChangePw1stTime);
        }
        [Test]
        public void TC03_UserLoginWithNewPassword()
        {
            AuthorizationService = new AssetManagementAPIServices();
            Token = AuthorizationService.ReturnLoginToken(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
            newUserService = new AssetManagementAPIServices();
            newUser = newUserService.ReturnNewUser(Constant.NEW_ADMIN_HN, Token);
            FirstTimeLoginData newLoginData = new FirstTimeLoginData();
            newLoginData.newUser = newUser;
            string newAdminUsername = newLoginData.GetUsername();
            string newAdminPassword = newLoginData.GetPassword();
            LoginPage?.Login(newAdminUsername, newAdminPassword);
            ChangePw1stTime = new ChangePassword1stTimePage();
            ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.ADMIN_PASSWORD_HN);
            DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
            HomePage?.SelectLogout();
            LogoutPopup?.LogOutOfPage();
            LoginPage?.Login(newAdminUsername, Constant.ADMIN_PASSWORD_HN);
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
            LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
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
}