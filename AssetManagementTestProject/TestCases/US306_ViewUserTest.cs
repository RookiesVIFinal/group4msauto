using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class US306_ViewUserTest : NUnitWebTestSetup
{
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ManageUserPage? ManageUserPage;

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

}

