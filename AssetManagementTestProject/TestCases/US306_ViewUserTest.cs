using AssetManagementTestProject.DAO;
using AssetManagementTestProject.DataFromUI;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class US306_ViewUserTest : NUnitWebTestSetup
{
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ManageUserPage? ManageUserPage;
    protected UserDataFromUI? UserDataFromUI;

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01_AdminCanViewUserList(string username, string password)
    {
        ManageUserPage = new ManageUserPage();
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
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        ManageUserPage.GoToUserList();
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
    public void TC05_AdminCanSortByStaffCodeInAscending()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SortStaffCodeUser();
        UserDataFromUI = new UserDataFromUI();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByStaffCode = UserDataFromUI.ReturnUserListStaffCode(userList);
        Asserter?.AssertUserListAscending(userListByStaffCode);
    }
    [Test]
    public void TC06_AdminCanSortByStaffCodeInDescending()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SortStaffCodeUser();
        ManageUserPage.SortStaffCodeUser();
        UserDataFromUI = new UserDataFromUI();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByStaffCode = UserDataFromUI.ReturnUserListStaffCode(userList);
        Asserter?.AssertUserListDescending(userListByStaffCode);
    }
    [Test]
    public void TC07_AdminCanSortByFullNameInAscending()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);

        UserDataFromUI = new UserDataFromUI();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByFullName = UserDataFromUI.ReturnUserListFullName(userList);
        Asserter?.AssertUserListAscending(userListByFullName);
    }
    [Test]
    public void TC08_AdminCanSortByFullNameInDescending()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage.SortFullName();

        UserDataFromUI = new UserDataFromUI();
        List<ViewUserDAO.ViewUserInList> userList = UserDataFromUI.ReturnUserList(ManageUserPage.RowLocator, ManageUserPage.CellLocator);
        List<string> userListByFullName = UserDataFromUI.ReturnUserListFullName(userList);
        Asserter?.AssertUserListDescending(userListByFullName);
    }

}

