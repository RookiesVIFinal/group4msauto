using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
namespace AssetManagementTestProject.TestData
{
    public class UserTestData
    {
    #region CREATE NEW USER DAO
    public static UserDAO NEW_USER_1 = new UserDAO
    (
        "Anh",
        "Pham",
        "12/06/2000",
        Constant.GENDER_MALE,
        "01/11/2022",
        Constant.TYPE_ADMIN
    );
    #endregion
    }
}
