using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj;

public class ManageAssignmentPage : WebDriverAction
{
    public readonly string rowLocator = "";
    public readonly string cellLocator = "";

    public ManageAssignmentPage(IWebDriver? driver) : base(driver)
    {

    }
}
