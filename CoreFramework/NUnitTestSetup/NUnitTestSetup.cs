using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;


namespace CoreFramework.NUnitTestSetup;

public class NUnitTestSetup
{
    // Check why [SetUp] uses InitDriver
    // Check Add Project Preference 
    protected IWebDriver? Driver;
    protected WebDriverAction? DriverBaseAction;



    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();

        // TODO: Change all metadata into const and avoid hardcoding
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
        //Driver = WebDriverManager.GetCurrentDriver();
        // DriverBaseAction = new WebDriverAction();
        // TODO: Learn how to use WebDriverAction(string baseUrl = "") in here
        //DriverBaseAction = new WebDriverAction(Driver.Url);


    }

    [TearDown]
    public void TearDown()
    {

        WebDriverManager.CloseDriver();

        // Report results on ExtentRep
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {

        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
        }


    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        HtmlReport.Flush();
    }
}
