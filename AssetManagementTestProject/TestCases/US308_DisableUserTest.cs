using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestCases;

[TestFixture]
public class US308_DisableUserTest : NUnitWebTestSetup
{
    [Test]
    public void TC02_AdminCanCancelDisableAction()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageUserInMenu);
        ManageUserPage?.InputSearch(NewUser.Data.StaffCode);
        //Verify after creating and searching new user, new user's information will appear on the record
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.TableData);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.TableData);
        ManageUserPage?.SelectDisable();
        DriverBaseAction?.WaitToBeVisible(ManageUserPage.HeaderDisableUser);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.HeaderDisableUser);
        ManageUserPage?.SelectCancelDisable();
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnStaffCode);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnFullName);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnUsername);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnJoinedDate);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnSortType);
        Asserter?.AssertElementIsDisplayed(ManageUserPage.BtnType);
    }

}
