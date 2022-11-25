using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using TestProject.DAO;
using TestProject.Services;

namespace TestProject.TestSetup;

public class NUnitAPITestSetup : NUnitTestSetup
{
    public UserDAO user;
    [SetUp]
    public void SetUp()
    {
        AuthorizationService authorizationService = new AuthorizationService();
        user = authorizationService.Login(Constant.API_ADMIN_USERNAME, Constant.API_ADMIN_PASSWORD);
    }
    [TearDown]
    public void TearDown()
    {
    }
}

