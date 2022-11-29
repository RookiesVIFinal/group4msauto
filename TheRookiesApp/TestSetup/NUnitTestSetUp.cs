using Core_Framework.NUnitTestSetup;
using NUnit.Framework;
using TheRookiesApp.DAO;

namespace TheRookiesApp.TestSetup;

public class NUnitTestSetUp : NUnitSetup
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
