using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.PageObject;

public class LoginPage : WebDriverBase
{
    public LoginPage(IWebDriver driver) : base(driver)
    {

    }

    private readonly string _btnLogin = "//button[@type = 'submit']";
    private readonly string _txtUserName = "//input[@id = 'username']";
    private readonly string _popUp = "";
    private readonly string _txtPassword = "//input[@id = 'password']";

    public void IsCorrectRedirect()
    {
        CompareUrls(Constant.HOME_PAGE_URL);
    }

    public void DoLogin(string userName, string password)
    {
        SendKeys_(_txtUserName, userName);
        SendKeys_(_txtPassword, password);
        Clicks(_btnLogin);
    }


    public bool IsPopUpLogoutDisplay()
    {
        if (IsPopUpDisplay(_popUp) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
