using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
namespace CoreFramework.NUnitTestSetup;
public class NUnitTestSetup
{
    // Check why [SetUp] uses InitDriver
    // Check Add Project Preference 
    // protected IWebDriver? Driver;
    protected WebDriverAction? DriverBaseAction;
    private string Author = "Hong_Anh_Pham";
    private string Device = "PC";
    private string Category = "Phase2_TestProject";
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();

        // TODO: Change all metadata into const and avoid hardcoding
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName).
            AssignAuthor(Author).AssignDevice(Device).AssignCategory(Category);
    }

    [SetUp]
    public void SetUp()
    {
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, 
            TestContext.CurrentContext.Test.Name);
        WebDriverManager.InitDriver("chrome", 1920, 1080);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriverManager.CloseDriver();
        // Report results on ExtentRep
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            HtmlReport.Pass("PASSED: Test case passed");
        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
            HtmlReport.Fail("FAILED: Test errors: " + TestContext.CurrentContext.Result.Message, DriverBaseAction.TakeScreenShot());
        }
    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        HtmlReport.Flush();
    }
}
