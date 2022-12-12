using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestData;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCases;

[TestFixture]
public class US307_EditUserTest : NUnitWebTestSetup
{    
    [Test]
    public void TC01_AdminEditUserInfoSuccessfully()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage = new ManageUserPage();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        ManageUserPage.InputSearch(NewUser.Data.StaffCode);
        // Verify that the search user is displayed on top before editing
        Asserter?.AssertEquals(ManageUserPage.ReturnStaffCodeTopListUser(), NewUser.Data.StaffCode);
        DriverBaseAction?.Click(ManageUserPage.BtnEditUserAtTop);
        // Edit user created with API
        EditUserInfoPage = new EditUserInfoPage();
        EditUserInfoPage.EditUserInfo(EditUserData.InfoToBeEdited);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.BtnEditUserAtTop);
        // Screen shot to ensure edited user is at the top of the list
        DriverBaseAction?.FindElementByXpath(ManageUserPage.FirstRowOfUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnViewTopUserDetailedInfo);
        DetailedUserInfoPage = new DetailedUserInfoPage();
        DriverBaseAction?.WaitToBeVisible(DetailedUserInfoPage.HeaderDetailedUser);
        DetailedUserInfoPage detailedUserInfo = new DetailedUserInfoPage();
        ActualDetailedUserInfoFromUI = detailedUserInfo.ReturnDetailedUserInfoFromUI();
        // Verify detailed info from UI after editing match with edited user info
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.DateOfBirth, EditUserData.ExpectedEditInfo.DateOfBirth);
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.Gender, EditUserData.ExpectedEditInfo.Gender);
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.Type, EditUserData.ExpectedEditInfo.Role);
    }
    [Test]  
    public void TC02_AdminCancelEditingUser()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage = new ManageUserPage();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderUserList);
        ManageUserPage.InputSearch(NewUser.Data.StaffCode);
        DriverBaseAction?.Click(ManageUserPage.BtnEditUserAtTop);
        EditUserInfoPage = new EditUserInfoPage();
        DriverBaseAction?.Click(EditUserInfoPage.BtnCancel);
        // Wait for edit button the first user row to appear (Fix query not fast enough)
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.BtnEditUserAtTop);
        // Search the new user again
        ManageUserPage.InputSearch(NewUser.Data.StaffCode);
        // Screen shot to ensure edited user is at the top of the list
        DriverBaseAction?.FindElementByXpath(ManageUserPage.FirstRowOfUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnViewTopUserDetailedInfo);
        DetailedUserInfoPage = new DetailedUserInfoPage();
        DriverBaseAction?.WaitToBeVisible(DetailedUserInfoPage.HeaderDetailedUser);
        DetailedUserInfoPage detailedUserInfo = new DetailedUserInfoPage();
        ActualDetailedUserInfoFromUI = detailedUserInfo.ReturnDetailedUserInfoFromUI();
        // Verify detailed info from UI after cancelling editing match with user info
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.DateOfBirth, NewUser.Data.DateOfBirth);
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.Gender, NewUser.Data.Gender);
        Asserter?.AssertEquals(ActualDetailedUserInfoFromUI.Type, NewUser.Data.Role);
    }
}

