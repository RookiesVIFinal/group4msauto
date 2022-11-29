using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj;

public class HomePage : WebDriverAction
{
    private readonly string btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string btnReportInMenu = "//a[text() = 'Report']";

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

    public void VerifyFirstLogin()
    {
        IsElementDisplay(textChangePw1stTime);
        CompareUrls(Constant.CHANGE_PW_1ST_TIME_URL);
    }
    public void ChangePwFirstTimeLogIn()
    {
        SendKeys_(tfFirstLoginNewPw, Constant.CHANGED_ADMIN_PASSWORD);
        Click(btnSaveFirstLoginNewPw);
    }

    public void VerifyCorrectDirectToHome()
    {
        WaitToBeVisible(headerHomePage); // Wait for the page to log in before verifying
        CompareUrls(Constant.BASE_URL);
    }
    public void VerifyMenuBar()
    {
        IsElementDisplay(btnHomeInMenu);
        IsElementDisplay(btnManageUserInMenu);
        IsElementDisplay(btnManageAssetInMenu);
        IsElementDisplay(btnManageAssignmentInMenu);
        IsElementDisplay(btnManageReturningInMenu);
        IsElementDisplay(btnReportInMenu);
    }

    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }


}
