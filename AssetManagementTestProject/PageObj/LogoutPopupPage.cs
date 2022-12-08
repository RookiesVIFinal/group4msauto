using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj
{
    public class LogoutPopupPage : WebDriverAction
    {
        private readonly string btnCancel = "//span[text() = 'Cancel']";
        private readonly string btnClose = "//span[contains(@aria-label, 'close')]";
        private readonly string btnLogout = "//span[text() = 'Log Out']";
        public LogoutPopupPage() : base()
        {
        }
        public void LogOutOfPage()
        {
            Click(btnLogout);
        }
    }
}
