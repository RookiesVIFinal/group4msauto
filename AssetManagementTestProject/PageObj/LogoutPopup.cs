using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.PageObj
{


    public class LogoutPopup : WebDriverAction
    {
        private readonly string btnLogout = "//span[text() = 'Log Out']";
        private readonly string btnCancel = "//span[text() = 'Cancel']";
        private readonly string btnClose = "//span[contains(@aria-label, 'close')]";


        public LogoutPopup() : base()
        {
        }

        public void LogOutOfPage()
        {
            Click(btnLogout);
        }
    }
}
