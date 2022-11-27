using OpenQA.Selenium;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class ManageAssetPage : WebDriverAction
{
    public readonly string rowLocator = "";
    public readonly string cellLocator = "";

    public ManageAssetPage(IWebDriver? driver) : base(driver)
    {

    }
}
