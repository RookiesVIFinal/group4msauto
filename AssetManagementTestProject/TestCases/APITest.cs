using AssetManagementTestProject.DAO;
using AssetManagementTestProject.Services;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace RookiesTest.APITest
{
    [TestFixture]
    public class APITest : NUnitWebTestSetup
    {
        public ManageUserService? ManageUserService;
        [Test]
        public void AdminCanCreateUser()
        {
            ManageUserService = new ManageUserService();
            List<UserDAO> expectedUsers = ManageUserService.GetUsers(TestUser.Token);
        }
    }
}

