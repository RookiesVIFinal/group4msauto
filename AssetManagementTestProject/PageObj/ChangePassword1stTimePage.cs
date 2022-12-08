using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class ChangePassword1stTimePage : WebDriverAction
{
    #region FIRST TIME LOGIN
    private string btnSaveFirstLoginNewPw = "//button[contains(@type, 'submit')]";
    private string headerChangePw1stTime = "//h1[text()='Change Password']";
    public string pathChangePw1stTime = "change-password-first-time";
    private string textChangePw1stTime = "//p[text()='You have to change your password to continue.']";
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    #endregion
    public ChangePassword1stTimePage() : base()
    {
    }
    public string AskChangePwFirstLogin()
    {
        WaitToBeVisible(headerChangePw1stTime); // Wait for the page to log in before verifying
        return textChangePw1stTime;
    }
    public void ChangePwFirstTimeLogIn(string newPassword)
    {
        SendKeys(tfFirstLoginNewPw, newPassword);
        Click(btnSaveFirstLoginNewPw);
    }
}
