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
    //public static LoginPage(IWebDriver? driver)
    //{
    //    Driver = driver;
    //}
    public LoginPage(IWebDriver? driver) : base(driver)
    {
    }


    public string GetUserNameText()
    {
        return GetText(usernameTextLocator);
    }
    public void AssertUserNameText()
    {
        AssertEquals(GetUserNameText(), "Username");
    }
    public void UserCanLogin()
    {
        SendKeys_(tfUsername, Constant.ADMIN_USERNAME);
        SendKeys_(tfPassword, Constant.ADMIN_PASSWORD);
        Click(btnLogin);
    }
}
