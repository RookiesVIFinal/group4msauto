using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
namespace AssetManagementTestProject.TestData
{
    public class EditUserData
    {
        public static EditUserDAO.EditUserUI EDITED_USER = new EditUserDAO.EditUserUI
        (
            "2000/06/13",
            Constant.GENDER_FEMALE,
            "2022/11/02",
            Constant.ROLE_STAFF
        );
    }
}
