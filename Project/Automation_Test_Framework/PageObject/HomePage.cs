using Automation_Test_Framework.TestSetup;
using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.PageObject;

public class HomePage : WebDriverAction

{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    //private readonly string addedURL = "/home";




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
