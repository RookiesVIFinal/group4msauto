﻿using Automation_Test_Framework.Common;
using Automation_Test_Framework.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Automation_Test_Framework.TestCase;

[TestFixture]
public class LoginTest : NUnitWebAndAPITestSetUp
{
    [Test]
    public void ID01Login()
    {
        CommonFlow.LoginFlow(Driver);

        //Profile_Page profilePage = new Profile_Page(_driver);
        //Assert.IsTrue(profilePage.GetUserName().Equals("tonyautotest"));
        //TestContext.WriteLine("Login Successfully");
    }
}
