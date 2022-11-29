using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace CoreFramework.NUnitTestSetup;

[TestFixture]
public class NUnitSetup
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
        WebDriverManager.CloseDriver();

        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {

        }
        else if (testStatus.Equals(TestStatus.Failed))
        {

        }
        HtmlReport.Flush();
    }

}




