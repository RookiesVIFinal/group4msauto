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
    protected Asserter.Asserter? Asserter;
    protected AssetManagementAPIServices? AuthorizationService;
    protected CreateUserDAO.CreateUserResponse? NewUser;
    protected DisableUserDAO.DisableUserRequest? DisabledUser;
    protected DisableUserDAO.DisableUserResponse? DisableUserResponse;
    protected AssetManagementAPIServices? APIService;
    protected string? Token;
    protected string? NewAdminUsername;
    protected string? NewAdminPassword;

    [SetUp]
    public void WebTestSetUp()
    {   
        /// Initialize header pages
        DriverBaseAction = new WebDriverAction();
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopupPage();
        Asserter = new Asserter.Asserter();
        MenuBarLeft = new LeftMenuPage();
        /// Create data with API for testing
        AuthorizationService = new AssetManagementAPIServices();
        Token = AuthorizationService.ReturnLoginToken(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        APIService = new AssetManagementAPIServices();
        NewUser = APIService.ReturnNewUser(CreateUserData.NEW_ADMIN_HN, Token);
        FirstTimeLoginData newLoginData = new FirstTimeLoginData();
        newLoginData.NewUser = NewUser;
        NewAdminUsername = newLoginData.GetUsername();
        NewAdminPassword = newLoginData.GetPassword();
    }
    [TearDown]    
    public void WebTestTearDown()
    {
        // Clean data generated by API if any
        if (NewUser != null)
        {
            if(NewUser.Data.Location == Constant.LOCATION_HANOI)
            {
                DisabledUser = new DisableUserDAO.DisableUserRequest(NewUser.Data.Id, (int)Constant.Locations.HaNoi);
                DisableUserResponse= APIService?.ReturnDisableUserResponse(DisabledUser, Token);
            }
            else if (NewUser.Data.Location == Constant.LOCATION_HCM)
            {
                DisabledUser = new DisableUserDAO.DisableUserRequest(NewUser.Data.Id, (int)Constant.Locations.HoChiMinh);
                DisableUserResponse= APIService?.ReturnDisableUserResponse(DisabledUser, Token);
            }

        }
    }

}


