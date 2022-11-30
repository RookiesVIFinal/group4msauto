using CoreFramework.DriverCore;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.PageObject;

public class HomePage : WebDriverBase
{
    private readonly string _btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string _btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string _btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string _btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string _btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string _btnReportInMenu = "//a[text() = 'Report']";

    private string btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string btnChangePw = "//a[contains(@href, '/change-password')]";
    private string btnLogout = "//a[contains(@href, '/logout')]";
    private string headerHomePage = "//h1[contains(@class, 'text-red-600')]";

    private string _popUp = "//div[contains(@class, 'ant-modal-content')]";
    private string _txtNewPassword = "//input[contains(@id, 'newPassword')]";
    private string _btnSaveNewPw = "//button[contains(@type, 'submit')]";

    #region FIRST TIME LOGIN
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    private string btnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    private string txtChangePw1stTime = "//p[text()='You have to change your password to continue.']";

    #endregion

    public HomePage() : base()
    {

    }

    public string RedirectToFirstLogin()
    {
        return txtChangePw1stTime;
    }
    public void ChangePwFirstTimeLogIn(string newPassword)
    {
        SendKeys_(tfFirstLoginNewPw, newPassword);
        Click(btnSaveFirstLoginNewPw);
    }

    public string ReturnPageUrl()
    {
        WaitToBeVisible(headerHomePage);
        return GetUrl();
    }


    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }

}
