using AventStack.ExtentReports;
using Core_Framework.DriverCore;
using Core_Framework.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace Core_Framework.NUnitTestSetup;

[TestFixture]
public class NUnit_Test_Setup
{
    protected IWebDriver Driver;
    protected WebDriverBase DriverBaseAction;

    protected ExtentReports? _extentReport;
    protected ExtentTest? _extentSuite;
    protected ExtentTest? _extentTestCase;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName)
            .AssignAuthor("Tran Nguyen Minh")
            .AssignDevice("PC")
            .AssignCategory("Selenium Project");
    }


    [SetUp]
    public void SetUp()
    {
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        WebDriverManager.InitDriver("chrome", 1920, 1080);
        Driver = WebDriverManager.GetCurrentDriver();
        DriverBaseAction = new WebDriverBase(Driver);

    }

    [TearDown]
    public void TearDown()
    {
        Driver?.Quit();
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            //_extentTestCase?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");
        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
            //_extentTestCase?.Fail($"[Failed] Test {TestContext.CurrentContext.Test.Name} because the error \n - {TestContext.CurrentContext.Test.Name}");
        }

        HtmlReport.Flush();
    }

}




