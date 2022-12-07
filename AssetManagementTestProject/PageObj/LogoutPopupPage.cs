using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj
{
    public class LogoutPopupPage : WebDriverAction
    {
        private readonly string btnLogout = "//span[text() = 'Log Out']";
        private readonly string btnCancel = "//span[text() = 'Cancel']";
        private readonly string btnClose = "//span[contains(@aria-label, 'close')]";
        public LogoutPopupPage() : base()
        {
        }
        public void LogOutOfPage()
        {
            Click(btnLogout);
        }

        public void CancelLogOutOfPage()
        {
            Click(btnCancel);
        }
    }
}

