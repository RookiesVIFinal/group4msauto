using AssetManagementTestProject.DAO;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestSetup;

public class NUnitWebTestSetup : NUnitTestSetup
{
    public UserDAO User;
    [SetUp]
    public void SetUp()
    {
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        //DriverBaseAction = new WebDriverAction(Driver);

        // TODO: Fix API here
        //AuthorizationService authorizationService = new AuthorizationService();
        //user = authorizationService.Login(Constant.ADMIN_USERNAME, Constant.ADMIN_USERNAME);

    }
    [TearDown]
    public void TearDown()
    {
    }
}

