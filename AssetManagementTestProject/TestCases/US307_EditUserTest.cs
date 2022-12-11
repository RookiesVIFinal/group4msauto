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
    protected ManageUserPage? ManageUserPage; 
    protected EditUserInfoPage? EditUserInfoPage;
    protected DetailedUserInfoPage? DetailedUserInfoPage;
    protected ViewUserDAO.ViewDetailedUser? DetailedUserInfoFromUI;
    protected GetUserDAO.GetUserResponse? NewUserAfterEdit;
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
        EditUserInfoPage = new EditUserInfoPage();
        EditUserInfoPage.EditUserInfo(EditUserData.EDITED_USER);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.BtnEditUserAtTop);
        // Screen shot to ensure edited user is at the top of the list
        DriverBaseAction?.FindElementByXpath(ManageUserPage.FirstRowOfUserList);
        DriverBaseAction?.Click(ManageUserPage.BtnViewTopUserDetailedInfo);
        DetailedUserInfoPage = new DetailedUserInfoPage();
        DriverBaseAction?.WaitToBeVisible(DetailedUserInfoPage.HeaderDetailedUser);
        DetailedUserInfoPage detailedUserInfo = new DetailedUserInfoPage();
        DetailedUserInfoFromUI = detailedUserInfo.ReturnDetailedUserInfoFromUI();
        // Update new user info with GET request
        NewUserAfterEdit = APIService?.ReturnSelectedUser(NewUser.Data.Id.ToString(), Token);
        // Assert detailed info from UI with info of the user created with API
        Asserter?.AssertEquals(DetailedUserInfoFromUI.StaffCode, NewUserAfterEdit.Data.StaffCode);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.FullName, NewUserAfterEdit.Data.FullName);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.UserName, NewUserAfterEdit.Data.Username);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.DateOfBirth, NewUserAfterEdit.Data.DateOfBirth);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Gender, NewUserAfterEdit.Data.Gender);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Type, NewUserAfterEdit.Data.Role);
        // Delete white space in Location info from UI (Ha Noi to HaNoi)
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Location.Trim().Replace(" ",""), NewUserAfterEdit.Data.Location);

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
        DetailedUserInfoFromUI = detailedUserInfo.ReturnDetailedUserInfoFromUI();
        // Assert detailed info from UI with info of the user created with API
        Asserter?.AssertEquals(DetailedUserInfoFromUI.StaffCode, NewUser.Data.StaffCode);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.FullName, NewUser.Data.FullName);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.UserName, NewUser.Data.Username);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.DateOfBirth, NewUser.Data.DateOfBirth);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Gender, NewUser.Data.Gender);
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Type, NewUser.Data.Role);
        // Delete white space in Location info from UI (Ha Noi to HaNoi)
        Asserter?.AssertEquals(DetailedUserInfoFromUI.Location.Trim().Replace(" ",""), NewUser.Data.Location);

    }
}

