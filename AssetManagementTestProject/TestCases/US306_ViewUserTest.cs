using AssetManagementTestProject.DAO;
using AssetManagementTestProject.DataFromUI;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class US306_ViewUserTest : NUnitWebTestSetup
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01_AdminCanViewUserList(string username, string password)
    {

        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        ManageUserPage.GoToUserList();
        Asserter?.AssertElementIsDisplayed(ManageUserPage.HeaderUserList);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnStaffCode);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnFullName);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnUsername);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnJoinedDate);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnSortType);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnType);
    }
    [Test]
    public void TC02_AdminCanSearchByStaffCode()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        ManageUserPage?.GoToUserList();
        ManageUserPage?.InputSearch(NewUser.Data.StaffCode);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.TableData);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.TableData);

    }
    [Test]
    public void TC03_AdminCanFilterUserByAdmin()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.SelectAdminType();
    }

    [Test]
    public void TC04_AdminCanFilterUserByStaff()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.SelectStaffType();
    }
    [Test]
    public void TC05_AdminCanSortByStaffCodeInAscending()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.SortStaffCodeUserInAscending();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByStaffCode = UserDataFromUI.ReturnUserListStaffCode(userList);
        Asserter?.AssertUserListAscending(userListByStaffCode);
    }
    [Test]
    public void TC06_AdminCanSortByStaffCodeInDescending()
    {

        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.SortStaffCodeUserInDescending();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByStaffCode = UserDataFromUI.ReturnUserListStaffCode(userList);
        Asserter?.AssertUserListDescending(userListByStaffCode);
    }
    [Test]
    public void TC07_AdminCanSortByFullNameInAscending()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByFullName = UserDataFromUI.ReturnUserListFullName(userList);
        Asserter?.AssertUserListAscending(userListByFullName);
    }
    [Test]
    public void TC08_AdminCanSortByFullNameInDescending()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.SortFullName();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByFullName = UserDataFromUI.ReturnUserListFullName(userList);
        Asserter?.AssertUserListDescending(userListByFullName);
    }

}
