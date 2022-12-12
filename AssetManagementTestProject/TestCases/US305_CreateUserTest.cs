using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestData;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US305_CreateUserTest : NUnitWebTestSetup
{    

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01To02_AdminCanCreateNewUser(string username, string password)
    {
        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
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
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
        CreateUserPage?.SendInvalidInfo(CreateUserData.INVALID_INFO);
        Asserter?.AssertElementIsDisplayed(CreateUserPage.ErrorMsgInvalidName);
        Asserter?.AssertElementIsDisplayed(CreateUserPage.ErrorMsgDOBUnder18);
        Asserter?.AssertElementIsDisplayed(CreateUserPage.ErrorMsgJoinedDateNotLaterThanDOB);
        Asserter?.AssertElementIsDisplayed(CreateUserPage.ErrorMsgJoinDateIsWeekend);
    }
    [Test]
    public void TC04_AdminPressCancelWhenCreatingNewUser()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnCreateNewUser);
        DriverBaseAction?.Click(CreateUserPage.BtnCancel);
        Asserter?.AssertEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL + ManageUserPage.PathManageUser);
    }
}

