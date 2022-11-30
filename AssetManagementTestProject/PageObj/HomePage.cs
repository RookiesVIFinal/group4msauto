using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class HomePage : WebDriverAction
{
    private string btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string btnChangePw = "//a[contains(@href, '/change-password')]";
    private string btnLogout = "//a[contains(@href, '/logout')]";
    private string headerHomePage = "//h1[contains(@class, 'text-red-600')]";

    #region FIRST TIME LOGIN
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    private string btnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    private string textChangePw1stTime = "//p[text()='You have to change your password to continue.']";

    #endregion
    public HomePage() : base()
    {
    }
    public string RedirectToFirstLogin()
    {
        return textChangePw1stTime;
    }
    public void ChangePwFirstTimeLogIn(string newPassword)
    {
        SendKeys(tfFirstLoginNewPw, newPassword);
        Click(btnSaveFirstLoginNewPw);
    }
    public string ReturnPageUrl()
    {
        WaitToBeVisible(headerHomePage); // Wait for the page to log in before verifying
        return GetUrl();
    }
    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }
}
