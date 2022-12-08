using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LeftMenuPage : WebDriverAction
{
    public readonly string BtnHomeInMenu = "//a[text() = 'Home']";
    public readonly string BtnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    public readonly string BtnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    public readonly string BtnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    public readonly string BtnManageUserInMenu = "//a[text() = 'Manage User']";
    public readonly string BtnReportInMenu = "//a[text() = 'Report']";
    public LeftMenuPage() : base()
    {
    }
}
    {
        List<string> menuBar = new List<string>();
        menuBar.Add(btnHomeInMenu);
        menuBar.Add(btnManageUserInMenu);
        menuBar.Add(btnManageAssetInMenu);
        menuBar.Add(btnManageAssignmentInMenu);
        menuBar.Add(btnManageReturningInMenu);
        menuBar.Add(btnReportInMenu);
        return menuBar;

    }

