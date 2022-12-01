﻿using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace CoreFramework.NUnitTestSetup;

[TestFixture]
public class NUnitSetup
{
    protected WebDriverBase? DriverBaseAction;
    private string Author = "Tran_Nguyen_Minh";
    private string Device = "PC";
    private string Category = "Phase2_TestProject";


    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        HtmlReport.CreateReport();

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

        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            HtmlReport.Pass("PASSED: Test case passed");
        }
        else
        {
            HtmlReport.Fail("FAILED: Test errors: "+ TestContext.CurrentContext.Result.Message, DriverBaseAction.TakeScreenShot());
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        HtmlReport.Flush();
    }
}




