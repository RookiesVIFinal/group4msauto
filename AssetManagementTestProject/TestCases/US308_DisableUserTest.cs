using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class US308_DisableUserTest : NUnitWebTestSetup
{

    protected ManageUserPage? ManageUserPage;

    public void TC02_AdminCanCancelDisableAction()
    {
        ManageUserPage = new ManageUserPage();
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        ManageUserPage.GoToUserList();
        ManageUserPage.InputSearch(NewUser.Data.StaffCode);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.TableData);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.TableData);
        ManageUserPage.SelectDisable();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderDisableUser);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.HeaderDisableUser);
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.TextDisableUser);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.TextDisableUser);
        ManageUserPage.SelectCancelDisable();
        Asserter?.AssertElementIsDisplayed(ManageUserPage.HeaderUserList);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnStaffCode);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnFullName);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnUsername);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnJoinedDate);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnSortType);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnType);
    }

}


