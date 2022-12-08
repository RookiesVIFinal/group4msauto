using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
namespace CoreFramework.NUnitTestSetup;
public class NUnitTestSetup
{
    protected WebDriverAction? DriverBaseAction;
    private string Device = "PC";
    private string Category = "Phase2_TestProject";
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName).AssignDevice(Device).AssignCategory(Category);
    }

    [SetUp]
    public void SetUp()
    {
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, 
            TestContext.CurrentContext.Test.Name);
        WebDriverManager.InitDriver("chrome");
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
        else
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
