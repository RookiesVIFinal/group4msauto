using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage LoginPage;
    protected ChangePassword1stTimePage ChangePw1stTime;
    protected HomePage HomePage;
    protected LogoutPopupPage LogoutPopup;
    protected LeftMenuPage MenuBarLeft;
    protected Asserter.Asserter Asserter;
    protected ChangePassword ChangePassword;
    protected AuthorizationService AuthorizationService;

    protected UserDAO TestUser;

    [SetUp]
    public void WebDriverBaseSetUp()
    {   
        DriverBaseAction = new WebDriverAction();
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopupPage();
        Asserter = new Asserter.Asserter();
        MenuBarLeft = new LeftMenuPage();
        ChangePw1stTime = new ChangePassword1stTimePage();
        ChangePassword = new ChangePassword();

        AuthorizationService = new AuthorizationService();
        TestUser = AuthorizationService.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);

    }
    [TearDown]
    public void WebDriverBaseTearDown()
    {
    }

}


