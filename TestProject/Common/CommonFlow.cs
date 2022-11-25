using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.PageObj;
using TestProject.TestSetup;
using OpenQA.Selenium;

namespace TestProject.Common;

// Login for every test case
public class CommonFlow : NUnitWebTestSetup
{
    public static void LoginFLow(IWebDriver _driver)
    {
        LoginPage loginPage = new LoginPage(_driver);
    }
}
