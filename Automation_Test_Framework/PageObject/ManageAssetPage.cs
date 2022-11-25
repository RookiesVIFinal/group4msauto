using Automation_Test_Framework.TestSetup;
using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.PageObject;

public class ManageAssetPage : WebDriverAction
{
    public ManageAssetPage(IWebDriver driver) : base(driver)
    {
    }

    //public bool IsCorrectRedirect()
    //{
    //    if (Constant.BASE_URL + addedURL == GetUrl())
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
