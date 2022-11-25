using NUnit.Framework;
using TestProject.PageObj;
using TestProject.TestSetup;

namespace TestProject;

[TestFixture]
public class US302LoginTest : NUnitWebTestSetup
{
    [Test]
    public void UserCanInputUserName()
    {
        LoginPage loginPage = new LoginPage(_driver);
    }
}