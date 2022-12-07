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
        public CreateUserService? CreateUserService;
        [Test]
        public void AdminCanCreateUser()
        {
            CreateUserService = new CreateUserService();
            CreateUserDAO.CreateUserResponse expectedNewUsers = CreateUserService.GetNewUsers(Token);
        }

        //public AuthorizationService? AuthorizationService;
        //[Test]
        //public void AdminCanLogin()
        //{
        //    AuthorizationService = new AuthorizationService();
        //    AuthorizationService.LoginRequest(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        //    AuthorizationService.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);

        //}
    }
}
