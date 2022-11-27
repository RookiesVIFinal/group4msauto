using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using CoreFramework.DriverCore;
using AventStack.ExtentReports;
using CoreFramework.Reporter;

namespace CoreFramework.NUnitTestSetup;

public class NUnitTestSetup
{
    // Check why [SetUp] uses InitDriver
    // Check Add Project Preference 
    protected IWebDriver? Driver;
    public WebDriverAction? DriverBaseAction;
    protected ExtentReports? _extentReport;


    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();

        // Without this, a suite will not be created
        // Assign metadata here
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName).
            AssignAuthor("Hong_Anh_Pham").AssignDevice("PC").AssignCategory("Phase2_TestProject");
    }

    [SetUp]
    public void SetUp()
    {
        // Pass before initialization => Null
        // Need a parent obj (Test) before creating child objs (Node/Case)
        HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, 
            TestContext.CurrentContext.Test.Name);
        WebDriverManager.InitDriver("chrome", 1920, 1080);
        Driver = WebDriverManager.GetCurrentDriver();
        DriverBaseAction = new WebDriverAction(Driver);
        //DriverBaseAction = new WebDriverAction();


    }

    [TearDown]
    public void TearDown()
    {
        //_driver?.Quit();
        WebDriverManager.CloseDriver();

        // Report results on ExtentRep
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {

        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
            // Unfinished error message TestExecution?
        }
        HtmlReport.Flush();
    }
}
