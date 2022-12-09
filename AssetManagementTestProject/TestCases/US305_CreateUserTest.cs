using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestData;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US305_CreateUserTest : NUnitWebTestSetup
{    
    /// TODO: Do not commit this to US302 branch
    protected ManageUserPage? ManageUserPage; 
    protected CreateUserPage? CreateUserPage;
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01To02_AdminCanCreateNewUser(string username, string password)
    {
        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage = new ManageUserPage();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
        CreateUserPage = new CreateUserPage();
        CreateUserPage?.CreateNewUser(CreateUserData.NEW_ADMIN_UI);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.BtnEditUserAtTop);
        DriverBaseAction?.FindElementByXpath(ManageUserPage.FirstRowOfUserList);
    }
    [Test]
    public void TC03_AdminCreatesNewUserUnsuccessfully()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage = new ManageUserPage();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
        CreateUserPage = new CreateUserPage();
        CreateUserPage?.SendInvalidInfo(CreateUserData.INVALID_INFO);
        Asserter.AssertElementIsDisplayed(CreateUserPage.ErrorMsgInvalidName);
        Asserter.AssertElementIsDisplayed(CreateUserPage.ErrorMsgDOBUnder18);
        Asserter.AssertElementIsDisplayed(CreateUserPage.ErrorMsgJoinedDateNotLaterThanDOB);
        Asserter.AssertElementIsDisplayed(CreateUserPage.ErrorMsgJoinDateIsWeekend);
    }
    [Test]
    public void TC04_AdminPressCancelWhenCreatingNewUser()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage = new ManageUserPage();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
        CreateUserPage = new CreateUserPage();
        DriverBaseAction?.Click(CreateUserPage.BtnCancel);
        Asserter?.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL + ManageUserPage.PathManageUser);
    }
}

