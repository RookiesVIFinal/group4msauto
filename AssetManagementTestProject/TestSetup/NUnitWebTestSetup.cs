using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using AssetManagementTestProject.PageObj;
using CoreFramework.DriverCore;
namespace AssetManagementTestProject.TestSetup;
public class NUnitWebTestSetup : NUnitTestSetup
{
    protected LoginPage LoginPage;
    protected HomePage HomePage;
    protected LogoutPopupPage LogoutPopup;
    protected Asserter.Asserter Asserter;
    protected LeftMenuPage MenuBarLeft;

    [SetUp]
    public void SetUp()
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
    public void TearDown()
    {
    }
}


