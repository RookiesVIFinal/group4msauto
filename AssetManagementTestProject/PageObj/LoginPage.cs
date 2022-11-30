using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LoginPage : WebDriverAction
{
    private readonly string tfUsername = "//input[contains(@id, 'username')]";
    private readonly string tfPassword = "//input[contains(@id, 'password')]";
    private readonly string btnLogin = "//button[contains(@type, 'submit')]";
    public LoginPage() : base()
    {
    }
    public void Login(string userName, string password)
    {
        SendKeys(tfUsername, userName);
        SendKeys(tfPassword, password);
        Click(btnLogin);
    }
}
