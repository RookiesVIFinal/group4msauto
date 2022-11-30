using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using TheRookiesApp.PageObject;

namespace TheRookiesApp.TestSetup;

public class NUnitTestSetUp : NUnitSetup
{
    protected LoginPage LoginPage;
    protected HomePage HomePage;
    protected LogoutPopup LogoutPopup;
    protected Asserter.Asserter Asserter;
    protected MenuLeft MenuBarLeft;

    [SetUp]
    public void SetUp()
    {
        DriverBaseAction.GoToUrl(Constant.LOGIN_PAGE_URl);
        DriverBaseAction = new WebDriverBase();
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopup();
        Asserter = new Asserter.Asserter();
        MenuBarLeft = new MenuLeft();
    }

    [TearDown]
    public void TearDown()
    {

    }

}
