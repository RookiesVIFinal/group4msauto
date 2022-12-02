﻿using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using AssetManagementTestProject.PageObj;
using CoreFramework.DriverCore;
using AssetManagementTestProject.Common;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage LoginPage;
    protected ChangePassword1stTimePage ChangePw1stTime;
    protected HomePage HomePage;
    protected LogoutPopupPage LogoutPopup;
    protected LeftMenuPage MenuBarLeft;
    protected Asserter.Asserter Asserter;

    [SetUp]
    public void WebDriverBaseSetUp()
    {   
        DriverBaseAction = new WebDriverAction();
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopupPage();
        Asserter = new Asserter.Asserter();
        MenuBarLeft = new LeftMenuPage();
        ChangePw1stTime = new ChangePassword1stTimePage();
    }
    [TearDown]
    public void WebDriverBaseTearDown()
    {
    }

}


