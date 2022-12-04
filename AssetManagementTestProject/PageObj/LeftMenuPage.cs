using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class LeftMenuPage : WebDriverAction
{
    private readonly string btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string btnReportInMenu = "//a[text() = 'Report']";
    public List<string> MenuBar;
    public readonly string BtnHomeInMenu = "//a[text() = 'Home']";
    public LeftMenuPage() : base()
    {
    }
    public List<string> ReturnMenuBar()
    {
        MenuBar = new List<string>();
        MenuBar.Add(BtnHomeInMenu);
        if (FindElementByXpath(btnManageUserInMenu) != null)
        {
            MenuBar.Add(btnManageUserInMenu);
        }
        if (FindElementByXpath(btnManageAssetInMenu) != null)
        {
            MenuBar.Add(btnManageAssetInMenu);
        }        
        if (FindElementByXpath(btnManageAssignmentInMenu) != null)
        {
            MenuBar.Add(btnManageAssignmentInMenu);
        }        
        if (FindElementByXpath(btnManageReturningInMenu) != null)
        {
            MenuBar.Add(btnManageReturningInMenu);
        }        
        if (FindElementByXpath(btnReportInMenu) != null)
        {
            MenuBar.Add(btnReportInMenu);
        }
        return MenuBar;
    }
}

