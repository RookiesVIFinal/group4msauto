using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using TheRookiesApp.PageObject;
using TheRookiesApp.Asserter;

namespace TheRookiesApp.TestSetup;

public class NUnitTestSetUp : NUnitSetup
{
    protected LoginPage LoginPage;
    protected HomePage HomePage;
    protected LogoutPopupPage LogoutPopup;
    protected Asserter.Asserter Asserter;
    protected LeftMenuPage MenuBarLeft;

    [SetUp]
    public void SetUp()
    {
        DriverBaseAction = new WebDriverBase();
        DriverBaseAction.GoToUrl(Constant.HOME_PAGE_URL);
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
