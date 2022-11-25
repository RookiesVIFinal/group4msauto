using OpenQA.Selenium;
using CoreFramework.DriverCore;

namespace TestProject.PageObj;

public class LoginPage : WebDriverAction
{
    public LoginPage(IWebDriver? driver) : base(driver)
    {
    }
}
