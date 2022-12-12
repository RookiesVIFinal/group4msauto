using AssetManagementTestProject.DataFromUI;
using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;

[TestFixture]
public class US306_ViewUserTest : NUnitWebTestSetup
{
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01_AdminCanViewUserList(string username, string password)
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
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
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.InputSearch(NewUser.Data.StaffCode);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.TableData);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.TableData);

    }
    [Test]
    public void TC03_AdminCanFilterUserByAdmin()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SelectAdminType();
    }

    [Test]
    public void TC04_AdminCanFilterUserByStaff()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SelectStaffType();
    }
    [Test]
    public void TC05_AdminCanSortByStaffCode()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SortUser(ManageUserPage.BtnStaffCode);
        UserDataFromUI = new UserDataFromUI();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByStaffCode = UserDataFromUI.ReturnUserListStaffCode(userList);
        Asserter?.AssertUserListAscending(userListByStaffCode);
    }
}


