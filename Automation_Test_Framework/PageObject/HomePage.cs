using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.PageObject;

public class HomePage : WebDriverBase

{
    public HomePage(IWebDriver driver) : base(driver)
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


    public void UserCanLogout()
    {
        Click(_btnNavigationBar);
        Click(_btnLogout);
    }

    public void IsCorrectRedirect()
    {
        Click(_btnHomeInMenu);
        CompareUrls(Constant.HOME_PAGE_URL);
    }

}
