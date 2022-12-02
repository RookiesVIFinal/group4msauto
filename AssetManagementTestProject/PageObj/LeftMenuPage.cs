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
        if (FindElementByXpath(btnManageUserInMenu) != null)
        {
            menuBar.Add(btnManageUserInMenu);
        }
        if (FindElementByXpath(btnManageAssetInMenu) != null)
        {
            menuBar.Add(btnManageAssetInMenu);
        }        
        if (FindElementByXpath(btnManageAssignmentInMenu) != null)
        {
            menuBar.Add(btnManageAssignmentInMenu);
        }        
        if (FindElementByXpath(btnManageReturningInMenu) != null)
        {
            menuBar.Add(btnManageReturningInMenu);
        }        
        if (FindElementByXpath(btnReportInMenu) != null)
        {
            menuBar.Add(btnReportInMenu);
        }
        return menuBar;

    }
    public string ReturnManageUserBtn()
    {
        return btnManageUserInMenu;
    } 
    public string ReturnHomeBtn()
    {
        return btnHomeInMenu;
    } 

}
