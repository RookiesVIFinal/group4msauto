﻿using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.TestSetup;
public class Constant
{
    #region URLS
    public static string BASE_URL = "https://group4b6ms.azurewebsites.net/";
    public static string BASE_API_URL = "https://group4b6msapi.azurewebsites.net/";
    #endregion
    #region DEFAULT USERNAME-PW
    public const string ADMIN_USERNAME_HN = "adminhn";
    public const string ADMIN_USERNAME_HCM = "adminhcm";
    public const string ADMIN_PASSWORD_HN = "Admin@123";
    #endregion
    #region CREATED USERNAMES-PWS
    public const string STAFF_USERNAME_1ST_TIME = "anhp1";
    public const string STAFF_PASSWORD_1ST_TIME = "anhp1@29112000";
    public const string ADMIN_USERNAME = "anhp3";
    public const string BASE_ADMIN_PASSWORD = "anhp3@11062000";
    public const string CHANGED_ADMIN_PASSWORD = "Admin@1234";
    public const string STAFF_USERNAME = "anhp4";
    public const string STAFF_PASSWORD = "Staff@1234";
    #endregion
    
    #region USER INFO
    public const string GENDER_MALE = "Male";
    public const string GENDER_FEMALE = "Female";
    public const string TYPE_ADMIN = "Admin";
    public const string TYPE_STAFF = "Staff";
    #endregion
}
