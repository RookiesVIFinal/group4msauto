using AssetManagementTestProject.DAO;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using AssetManagementTestProject.PageObj;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.TestSetup;

public class NUnitWebTestSetup : NUnitTestSetup
{
    public UserDAO User;
    protected LoginPage LoginPage;
    protected HomePage HomePage;
    protected LogoutPopup LogoutPopup;

    /// TODO: Figure out why this is not working (Null reference)
    //[OneTimeSetUp]
    //public void OneTimeSetUp()
    //{
    //    LoginPage = new LoginPage();
    //    HomePage = new HomePage();
    //    LogoutPopup = new LogoutPopup();

    //}
    [SetUp]
    public void SetUp()
    {   DriverBaseAction = new WebDriverAction();
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
        LoginPage = new LoginPage();
        HomePage = new HomePage();
        LogoutPopup = new LogoutPopup();

    }
    [TearDown]
    public void TearDown()
    {
    }


}

