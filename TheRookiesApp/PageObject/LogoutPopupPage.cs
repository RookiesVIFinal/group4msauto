using CoreFramework.DriverCore;

namespace TheRookiesApp.PageObject;

public class LogoutPopupPage : WebDriverBase
{

    private readonly string _btnLogout = "//span[text() = 'Log Out']";
    private readonly string _btnCancel = "//span[text() = 'Cancel']";
    private readonly string _btnClose = "//span[contains(@aria-label, 'close')]";

    public LogoutPopupPage() : base()
    {
    }

    public void LogOutOfPage()
    {
        Click(_btnLogout);
    }
}
