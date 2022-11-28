using Core_Framework.NUnitTestSetup;
using NUnit.Framework;
using TheRookiesApp.DAO;

namespace TheRookiesApp.TestSetup;

public class NUnitWebAndAPITestSetUp : NUnit_Test_Setup
{
    public UserListDAO User;
    [SetUp]
    public void SetUp()
    {
        DriverBaseAction.GoToUrl(Constant.LOGIN_PAGE_URl);
    }

    [TearDown]
    public void TearDown()
    {

    }

}
