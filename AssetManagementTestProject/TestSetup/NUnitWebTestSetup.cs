using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using ServiceStack;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage LoginPage;
    protected HomePage HomePage;
    protected LogoutPopupPage LogoutPopup;
    protected LeftMenuPage MenuBarLeft;
    protected Asserter.Asserter Asserter;
    protected AuthorizationService AuthorizationService;
    public UserDAO TestUser;

    [SetUp]
    public void WebTestSetUp()
    {   
        DriverBaseAction = new WebDriverAction();
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopupPage();
        Asserter = new Asserter.Asserter();
        MenuBarLeft = new LeftMenuPage();
        AuthorizationService = new AuthorizationService();
        TestUser = AuthorizationService.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD_HN);

    }
    [TearDown]    
    public void WebTestTearDown()
    {
    }

}


