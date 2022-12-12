﻿using AssetManagementTestProject.DAO;
using AssetManagementTestProject.DataFromUI;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestData;
using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected Asserter.Asserter? Asserter;
    protected AssetManagementAPIServices? APIService;
    protected AssetManagementAPIServices? AuthorizationService;
    protected ChangePassword1stTimePage? ChangePw1stTime;
    protected ChangePasswordPage? ChangePassword;
    protected CreateUserDAO.CreateUserResponse? NewUser;
    protected CreateUserPage? CreateUserPage;
    protected DetailedUserInfoPage? DetailedUserInfoPage;
    protected DisableUserDAO.DisableUserRequest? DisabledUser;
    protected DisableUserDAO.DisableUserResponse? DisableUserResponse;
    protected EditUserInfoPage? EditUserInfoPage;
    protected GetUserDAO.GetCanDisableUser? UserToBeDisabled;
    protected HomePage? HomePage;
    protected LeftMenuPage? MenuBarLeft;
    protected LoginPage? LoginPage;
    protected LogoutPopupPage? LogoutPopup;
    protected ManageUserPage? ManageUserPage; 
    protected UserDataFromUI? UserDataFromUI;
    protected ViewUserDAO.ViewDetailedUser? ActualDetailedUserInfoFromUI;
    protected string? NewAdminPassword;
    protected string? NewAdminUsername;
    protected string? Token;

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
        // Check if user created with API with no valid assignment can be disabled 
        UserToBeDisabled = APIService.ReturnCanDisableUser(NewUser.Data.Id.ToString(), Token);
        // Clean data generated by API if any
        if (UserToBeDisabled.Message == Constant.USER_CAN_BE_DISABLED_MSG)
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
