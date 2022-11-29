﻿using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [Test]
    public void TestFirstLogin()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        DriverBaseAction.IsElementDisplayed(HomePage.RedirectToFirstLogin());
        HomePage.ChangePwFirstTimeLogIn();
        LogoutPopup.LogOutOfPage();
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.BASE_URL);

    }
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD)]
    [TestCase(Constant.STAFF_USERNANE, Constant.CHANGED_STAFF_PASSWORD)]
    public void TestLoginAuthority(string userName, string password)
    {
        LoginPage.Login(userName, password);
        Asserter.AssertStringEquals(HomePage.ReturnPageUrl(), Constant.BASE_URL);
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnHome());
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnManageUser());
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnManageAsset());
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnManageAssignment());
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnManageReport());
        DriverBaseAction.IsElementDisplayed(MenuBarLeft.ReturnManageReturning());
        HomePage.SelectLogout();
        LogoutPopup.LogOutOfPage();
    }

}

