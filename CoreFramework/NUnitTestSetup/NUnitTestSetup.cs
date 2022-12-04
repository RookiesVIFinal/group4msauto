﻿using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
namespace CoreFramework.NUnitTestSetup;
public class NUnitTestSetup
{
protected WebDriverAction? DriverBaseAction;
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();
        HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName);
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
