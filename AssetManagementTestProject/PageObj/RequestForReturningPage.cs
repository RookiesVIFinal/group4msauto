using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj;

public class RequestForReturningPage : WebDriverAction
{
    public readonly string rowLocator = "";
    public readonly string cellLocator = "";

    public RequestForReturningPage(IWebDriver? driver) : base(driver)
    {

    }
}
