using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LoginPage : WebDriverAction
{
    private readonly string tfUsername = "//input[contains(@id, 'username')]";
    private readonly string tfPassword = "//input[contains(@id, 'password')]";
    private readonly string btnLogin = "//button[contains(@type, 'submit')]";
    private readonly string btnViewDecryptedPassword = "//span[contains(@class, 'anticon-eye')]";
    public LoginPage() : base()
    {
    }
    public void Login(string userName, string password)
    {
        ///Click Eye icon to view if password is inputed correctly before login
        SendKeys(tfUsername, userName);
        SendKeys(tfPassword, password);
        Click(btnViewDecryptedPassword);
        TakeScreenShot();
        Click(btnLogin);
    }

    public List<string> LoginPageElementUI()
    {
        List<string> menuBar = new List<string>();
        menuBar.Add(tfUsername);
        if (FindElementByXpath(tfUsername) != null)
        {
            menuBar.Add(tfUsername);
        }
        if (FindElementByXpath(tfPassword) != null)
        {
            menuBar.Add(tfPassword);
        }
        if (FindElementByXpath(btnLogin) != null)
        {
            menuBar.Add(btnLogin);
        }
        return menuBar;
    }
}
