using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class ChangePassword : WebDriverAction
{
    #region CHANGE PASSWORD
    private string tfFirstLoginNewPw = "//input[contains(@id, 'newPassword')]";
    private string btnSaveNewPw = "//button[contains(@type, 'submit')]";
    private string btnCancel = "//span[contains(text(), 'Cancel')]";
    private string headerChangePw = "//h1[text()='Change Password']";
    private string pathChangePw = "change-password";
    private string textChangePwSuccessfully = "//p[text()='Your password has been changed successfully']";
    #endregion

    public ChangePassword() : base()
    {
    }
    public string DisplayChangePwPopUp()
    {
        WaitToBeVisible(headerChangePw);
        return headerChangePw;
    }
    public string ReturnExpectedChangePWUrl()
    {
        return Constant.BASE_URL + pathChangePw;
    }
    public void ChangePw(string newPassword)
    {
        SendKeys(tfFirstLoginNewPw, newPassword);
        Click(btnSaveNewPw);
    }
    public string DisplayChangePwSuccessfully()
    {
        WaitToBeVisible(headerChangePw);
        return textChangePwSuccessfully;
    }
}
