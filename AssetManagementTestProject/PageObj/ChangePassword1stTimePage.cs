using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class ChangePassword1stTimePage : WebDriverAction
{
    #region FIRST TIME LOGIN
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    private string btnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    private string headerChangePw1stTime = "//h1[text()='Change Password']";
    private string textChangePw1stTime = "//p[text()='You have to change your password to continue.']";
    private string pathChangePw1stTime = "/change-password-first-time";
    #endregion
    public ChangePassword1stTimePage() : base()
    {
    }
    public string AskChangePwFirstLogin()
    {
        WaitToBeVisible(headerChangePw1stTime); // Wait for the page to log in before verifying
        return textChangePw1stTime;
    }
    public string ReturnExpectedChangePw1stTimeUrl()
    {
        return Constant.BASE_URL + pathChangePw1stTime;
    }
    public void ChangePwFirstTimeLogIn(string newPassword)
    {
        SendKeys(tfFirstLoginNewPw, newPassword);
        Click(btnSaveFirstLoginNewPw);
    }
}