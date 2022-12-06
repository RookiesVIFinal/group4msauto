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
    private string headerChangePw1stTime = "//h1[text()='Change Password']";
    private string textChangePw1stTime = "//p[text()='You have to change your password to continue.']";
    private string pathChangePw1stTime = "/change-password-first-time";
    #endregion

    private readonly string btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string btnReportInMenu = "//a[text() = 'Report']";

    public HomePage() : base()
    {
    }
    public string ReturnHomePageUrl()
    {
        WaitToBeVisible(headerHomePage); // Wait for the page to log in before verifying
        return GetUrl();
    }
    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }
    public void SelectChangePw()
    {
        Click(btnNavigationBar);
        Click(btnChangePw);
    }
   
}
