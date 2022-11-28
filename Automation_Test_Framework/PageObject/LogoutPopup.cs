using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace TheRookiesApp.PageObject;

public class LogoutPopup : WebDriverBase
{
    public LogoutPopup(IWebDriver driver) : base(driver)
    {

    }
    private readonly string _btnLogout = "//span[text() = 'Log Out']";
    private readonly string _btnCancel = "//span[text() = 'Cancel']";
    private readonly string _btnClose = "//span[contains(@aria-label, 'close')]";

    public void LogOutOfPage()
    {
        Click(_btnLogout);
    }
}
