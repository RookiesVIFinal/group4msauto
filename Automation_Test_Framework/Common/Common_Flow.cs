using Automation_Test_Framework.PageObject;
using OpenQA.Selenium;

namespace Automation_Test_Framework.Common
{
    public class CommonFlow
    {


        public static void LoginFlow(IWebDriver _driver)
        {
            LoginPage loginPage = new LoginPage(_driver);
        }


    }
}