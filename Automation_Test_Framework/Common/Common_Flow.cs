using OpenQA.Selenium;
using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.Common
{
    public class CommonFlow
    {


        public static void LoginFlowAdmin(IWebDriver _driver)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.DoLogin(Constant.ADMIN_USER_NAME, Constant.ADMIN_PASSWORD);
        }

        public static void LoginFlowStaff(IWebDriver _driver)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.DoLogin(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD);
        }


    }
}