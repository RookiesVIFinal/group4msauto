using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class HomePage : WebDriverAction
{
    private string btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string btnChangePw = "//a[contains(@href, '/change-password')]";
    private string btnLogout = "//a[contains(@href, '/logout')]";
    public string HeaderHomePage = "//h1[contains(@class, 'text-red-600')]";

    #region FIRST TIME LOGIN
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    private string btnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    public string HeaderChangePw1stTime = "//h1[text()='Change Password']";
    private string textChangePw1stTime = "//p[text()='You have to change your password to continue.']";
    private string pathChangePw1stTime = "/change-password-first-time";
    #endregion
    public HomePage() : base()
    {
    }
    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }
}
