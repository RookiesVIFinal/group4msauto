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

    public HomePage(IWebDriver? driver) : base(driver)
    {
    }


    public void UserCanLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }


}
