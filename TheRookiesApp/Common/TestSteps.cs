using TheRookiesApp.PageObject;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.Common
{
    public class TestSteps
    {


        public static void LoginAsAdmin()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.DoLogin(Constant.ADMIN_USER_NAME, Constant.ADMIN_PASSWORD);
        }

        public static void LoginAsStaff()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.DoLogin(Constant.STAFF_USER_NAME, Constant.STAFF_PASSWORD);
        }

        public static void LoginFail()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.DoLogin(Constant.FAIL_USER_NAME, Constant.FAIL_PASSWORD);
        }

        public static void LoginWithNewPassword()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.DoLogin(Constant.NEW_USER_NAME, Constant.NEW_PASSWORD);
        }




    }
}