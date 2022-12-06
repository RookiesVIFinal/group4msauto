using AssetManagementTestProject.DAO;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using ServiceStack;

namespace AssetManagementTestProject.APITest
{
    [TestFixture]
    public class APITest : NUnitWebTestSetup
    {
        public ManageUserService? ManageUserService;
        [Test]
        public void AdminCanCreateUser()
        {
            ManageUserService = new ManageUserService();
            List<UserDAO> expectedUsers = ManageUserService.GetUsers(TestUser.token);
        }

        public AuthorizationService? AuthorizationService;
        [Test]
        public void AdminCanLogin()
        {
            AuthorizationService = new AuthorizationService();
            AuthorizationService.LoginRequest(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
            AuthorizationService.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);

        }
    }
}
