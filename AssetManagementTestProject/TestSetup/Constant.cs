using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.TestSetup;

public class Constant
{
    public static string BASE_URL = "https://group4b6ms.azurewebsites.net/";
    public static string BASE_API = "https://group4b6msapi.azurewebsites.net/";
    public static string CHANGE_PW_1ST_TIME_URL = "https://group4b6ms.azurewebsites.net/change-password-first-time";

    #region DEFAULT USERNAME-PW
    public const string ADMIN_USERNAME_HN = "adminhn";
    public const string ADMIN_USERNAME_HCM = "adminhcm";
    public const string ADMIN_PASSWORD_HN = "Admin@123";

    #endregion
    #region SELF-CREATED USERNAMES-PWS
    public const string STAFF_USERNAME_1ST_TIME = "anhp1";
    public const string STAFF_PASSWORD_1ST_TIME = "anhp1@29112000";
    public const string ADMIN_USERNAME = "anhp3";
    public const string BASE_ADMIN_PASSWORD = "anhp3@11062000";
    public const string CHANGED_ADMIN_PASSWORD_1 = "Admin@1234";

    public const string STAFF_USERNAME = "minht7";
    public const string STAFF_PASSWORD = "Polo@2109";
    #endregion

    #region USER INFO
    public const string GENDER_MALE = "Male";

    public const string GENDER_FEMALE = "Female";

    public enum Genders
    {
        Male,

        Female
    }
    public const string ROLE_ADMIN = "Admin";

    public const string ROLE_STAFF = "Staff";

    public enum Roles
    {
        Admin,

        Staff
    }
    public const string LOCATION_HANOI = "HaNoi";

    public const string LOCATION_HCM = "HoChiMinh";

    public enum Locations
    {
        HaNoi,

        HoChiMinh
    }
    #endregion

    #region SEND POST REQUEST TO CREATE NEW USER
    public static CreateUserDAO.CreateUserRequest NEW_ADMIN_HN = new CreateUserDAO.CreateUserRequest
    (
        "Tony",
        "Tran",
        "2000-09-21",
        (int)Genders.Male,
        "2022-12-07",
        (int)Roles.Admin,
        (int)Locations.HaNoi
    );
    public static CreateUserDAO.CreateUserRequest NEW_STAFF_HN = new CreateUserDAO.CreateUserRequest
    (
        "Anh",
        "Pham",
        "2000-06-12",
        (int)Genders.Male,
        "2022-11-01",
        (int)Roles.Staff,
        (int)Locations.HaNoi
    );
    #endregion
}
