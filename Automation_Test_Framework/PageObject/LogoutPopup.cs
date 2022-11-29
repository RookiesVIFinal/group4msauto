using Core_Framework.DriverCore;

namespace TheRookiesApp.PageObject;

public class LogoutPopup : WebDriverBase
{

    private readonly string _btnLogout = "//span[text() = 'Log Out']";
    private readonly string _btnCancel = "//span[text() = 'Cancel']";
    private readonly string _btnClose = "//span[contains(@aria-label, 'close')]";

    public LogoutPopup() : base()
    {
    }

    public void LogOutOfPage()
    {
        Click(_btnLogout);
    }
}
