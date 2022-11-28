using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.Common;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class LogoutTest : NUnitWebAndAPITestSetUp
{
    [Test]
    public void ID01Logout()
    {
        CommonFlow.LoginFlowAdmin(Driver);

        //Profile_Page profilePage = new Profile_Page(_driver);
        //Assert.IsTrue(profilePage.GetUserName().Equals("tonyautotest"));
        //TestContext.WriteLine("Login Successfully");
    }
}