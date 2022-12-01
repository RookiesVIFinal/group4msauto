using CoreFramework.DriverCore;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.PageObject;

public class LoginPage : WebDriverBase
{

    private readonly string _btnLogin = "//button[@type = 'submit']";
    private readonly string _txtUserName = "//input[@id = 'username']";
    private readonly string _popUp = "";
    private readonly string _txtPassword = "//input[@id = 'password']";

    private readonly string _errorMessage = "//div[contains(text(), 'Username or password is incorrect!')]";

    public LoginPage() : base()
    {

    }

    public void IsCorrectRedirect()
    {
        CompareUrls(Constant.LOGIN_PAGE_URl);
    }

    public void ErrorMessageDisplay()
    {
        IsErrorMessageDisplay(_errorMessage);
    }

    public void DoLogin(string userName, string password)
    {
        SendKeys_(_txtUserName, userName);
        SendKeys_(_txtPassword, password);
        Click(_btnLogin);
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
