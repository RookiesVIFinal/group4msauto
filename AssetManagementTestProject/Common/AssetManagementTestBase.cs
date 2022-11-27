using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using OpenQA.Selenium;

namespace AssetManagementTestProject.Common;

// Login for every test case
public class AssetManagementTestBase : NUnitWebTestSetup
{
    public static void LoginFLow(IWebDriver _driver)
    {
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.UserCanLogin();
    }
    //public static void LoginFLow()
    //{
    //    LoginPage loginPage = new LoginPage();
    //    loginPage.UserCanLogin();
    //}
}
