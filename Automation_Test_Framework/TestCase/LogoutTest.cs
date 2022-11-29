using NUnit.Framework;
using NUnit.Framework.Internal;
using TheRookiesApp.Common;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.TestCase;

[TestFixture]
public class LogoutTest : NUnitTestSetUp
{
    [Test]
    public void ID01Logout()
    {
        TestSteps.LoginFlowAdmin(Driver);

        //Profile_Page profilePage = new Profile_Page(_driver);
        //Assert.IsTrue(profilePage.GetUserName().Equals("tonyautotest"));
        //TestContext.WriteLine("Login Successfully");
    }
}