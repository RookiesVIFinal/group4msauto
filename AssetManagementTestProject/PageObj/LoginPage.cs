using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj;

public class LoginPage : WebDriverAction
{
    private readonly string usernameTextLocator = "//label[contains(@title, 'Username')]"; // for testing
    private readonly string tfUsername = "//input[contains(@id, 'username')]";
    private readonly string tfPassword = "//input[contains(@id, 'password')]";
    private readonly string btnLogin = "//button[contains(@type, 'submit')]";

    // TODO: Learn how to use WebDriverAction(string baseUrl = "") in here
    public LoginPage() : base()
    {
    }
    // public LoginPage(IWebDriver? driver) : base(driver)
    // {
    // }
    public void Login(string userName, string password)
    {
        SendKeys_(tfUsername, userName);
        SendKeys_(tfPassword, password);
        Click(btnLogin);
    }
}
