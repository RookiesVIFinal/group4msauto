﻿using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestData;
using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage? LoginPage;
    protected HomePage? HomePage;
    protected LogoutPopupPage? LogoutPopup;
    protected LeftMenuPage? MenuBarLeft;
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ChangePasswordPage? ChangePassword;
    protected Asserter.Asserter? Asserter;

    protected AssetManagementAPIServices? AuthorizationService;
    protected CreateUserDAO.CreateUserResponse? NewUser;
    protected DisableUserDAO.DisableUserRequest? DisabledUser;
    protected DisableUserDAO.DisableUserResponse? DisableUserResponse;
    public AssetManagementAPIServices? APIService;
    protected string? Token;

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
        ChangePassword = new ChangePasswordPage();

        AuthorizationService = new AssetManagementAPIServices();
        Token = AuthorizationService.ReturnLoginToken(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);
        APIService = new AssetManagementAPIServices();
        NewUser = APIService.ReturnNewUser(Constant.NEW_STAFF_HN, Token);
        FirstTimeLoginData newLoginData = new FirstTimeLoginData();
        newLoginData.NewUser = NewUser;
        string newAdminUsername = newLoginData.GetUsername();
        string newAdminPassword = newLoginData.GetPassword();
        LoginPage?.Login(newAdminUsername, newAdminPassword);
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePw1stTime.ChangePwFirstTimeLogIn(Constant.STAFF_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderMyAssignment);
        Asserter?.AssertElementIsDisplayed(HomePage.HeaderMyAssignment);
    }
    [TearDown]
    public void WebDriverBaseTearDown()
    {
        // TODO: Add clean user service here
        // Clean data generated by API if any
        if (NewUser != null)
        {
            if (NewUser.Data.Location == Constant.LOCATION_HANOI)
            {
                DisabledUser = new DisableUserDAO.DisableUserRequest(NewUser.Data.Id, (int)Constant.Locations.HaNoi);
                DisableUserResponse = APIService?.ReturnDisableUserResponse(DisabledUser, Token);
            }
            else if (NewUser.Data.Location == Constant.LOCATION_HCM)
            {
                DisabledUser = new DisableUserDAO.DisableUserRequest(NewUser.Data.Id, (int)Constant.Locations.HoChiMinh);
                DisableUserResponse = APIService?.ReturnDisableUserResponse(DisabledUser, Token);
            }
        }
    }

}
