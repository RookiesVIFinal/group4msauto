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
        SendKeys(TfUsername, userName);
        SendKeys(TfPassword, password);
        Click(BtnViewDecryptedPassword);
        TakeScreenShot();
        Click(BtnLogin);
    }

}

