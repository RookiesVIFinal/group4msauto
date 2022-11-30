using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LeftMenuPage : WebDriverAction
{
    private readonly string btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string btnReportInMenu = "//a[text() = 'Report']";

    public LeftMenuPage() : base()
    {

    }
    public List<string> ReturnMenuBar()
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

}
