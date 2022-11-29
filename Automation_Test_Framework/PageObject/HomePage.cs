using Core_Framework.DriverCore;
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

    private string _btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string _btnChangePw = "//a[contains(@href, '/change-password')]";
    private string _btnLogout = "//a[contains(@href, '/logout')]";

    private string _popUp = "//div[contains(@class, 'ant-modal-content')]";
    private string _txtNewPassword = "//input[contains(@id, 'newPassword')]";
    private string _btnSaveNewPw = "//button[contains(@type, 'submit')]";

    public HomePage() : base()
    {

    }
    public void Logout()
    {
        Click(_btnNavigationBar);
        Click(_btnLogout);
    }

    public void IsCorrectRedirect()
    {
        Click(_btnHomeInMenu);
        CompareUrls(Constant.HOME_PAGE_URL);
    }

    public void ChangePassword()
    {
        IsPopUpDisplay(_popUp);
        SendKeys_(_txtNewPassword,"Admin@1234");
        Clicks(_btnSaveNewPw);
    }

}
