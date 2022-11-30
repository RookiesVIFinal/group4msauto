using CoreFramework.DriverCore;

namespace TheRookiesApp.PageObject;

public class ManageUserPage : WebDriverBase
{
    public ManageUserPage() : base()
    {
    }

    private readonly string _btnHomeInMenu = "//a[text() = 'Home']";
    private readonly string _btnManageUserInMenu = "//a[text() = 'Manage User']";
    private readonly string _btnManageAssetInMenu = "//a[text() = 'Manage Asset']";
    private readonly string _btnManageAssignmentInMenu = "//a[text() = 'Manage Assignment']";
    private readonly string _btnManageReturningInMenu = "//a[text() = 'Manage Returning']";
    private readonly string _btnReportInMenu = "//a[text() = 'Report']";

    private string _btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string _btnChangePw = "//a[contains(@href, '/change-password')]";
    private string _btnLogout = "//a[contains(@href, '/logout')]";

    private string _btnFilterType = "//div[contains(@class, 'ant-select w-3/12 css-1wismvm ant-select-single ant-select-allow-clear ant-select-show-arrow')]";
    private string _btnStaffCode = "//th[contains(@class, 'ant-table-cell ant-table-column-sort ant-table-column-has-sorters')]";
    private string _btnFullName = "//span[contains(text(), 'Full Name')]";
    private string _btnUsername = "//span[contains(text(), 'Username')]";
    private string _btnJoinDated = "//span[contains(text(), 'Joined Date')]";
    private string _btnJoinDated = "//span[contains(text(), 'Joined Date')]";
}



