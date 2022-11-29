using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj;

public class MenuLeft : WebDriverAction
{
    private readonly string btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string btnReportInMenu = "//a[text() = 'Report']";

    public MenuLeft() : base()
    {

    }
    public string ReturnHome()
    {
        return btnHomeInMenu;
    }
    public string ReturnManageUser()
    {
        return btnManageUserInMenu;
    }
    public string ReturnManageAsset()
    {
        return btnManageAssetInMenu;
    }
    public string ReturnManageAssignment()
    {
        return btnManageAssignmentInMenu;
    }
    public string ReturnManageReturning()
    {
        return btnManageReturningInMenu;
    }
    public string ReturnManageReport()
    {
        return btnReportInMenu;
    }

}
