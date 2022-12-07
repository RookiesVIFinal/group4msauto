using AssetManagementTestProject.DAO;
using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.Services;
using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage? LoginPage;
    protected HomePage? HomePage;
    protected LogoutPopupPage? LogoutPopup;
    protected LeftMenuPage? MenuBarLeft;
    protected Asserter.Asserter? Asserter;
    protected AssetManagementAPIServices? AuthorizationService;
    public CreateUserDAO.CreateUserResponse? newUser;
    protected AssetManagementAPIServices? newUserService;
    public string? Token;

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

    }
    [TearDown]
    public void WebDriverBaseTearDown()
    {
    }

}


