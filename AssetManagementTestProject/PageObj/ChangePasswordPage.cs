using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class ChangePasswordPage : WebDriverAction
{
    #region CHANGE PASSWORD
    private string btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string tfNewPw = "//input[contains(@id, 'newPassword')]";
    private string tfOldPw = "//input[contains(@id, 'oldPassword')]";
    private string btnSaveNewPw = "//button[contains(@type, 'submit')]";
    private string btnChangePw = "//a[contains(@href, '/change-password')]";
    private string btnCancel = "//span[contains(text(), 'Cancel')]";
    public string HeaderChangePw = "//h1[text()='Change Password']";
    private string pathChangePw = "change-password";
    public string TextChangePwSuccessfully = "//p[text()='Your password has been changed successfully']";
    #endregion
    #region ERROR MESSAGES
    public string ErrorMessagesNewPw = "//div[contains(@id, 'newPassword_help')]";
    public string ErrorMessagesOldPw = "//div[contains(@id, 'newPassword_help')]";
    #endregion

    public ChangePasswordPage() : base()
    {
    }
    public string DisplayChangePwPopUp()
    {
        WaitToBeVisible(HeaderChangePw);
        return HeaderChangePw;
    }
    public string ReturnExpectedChangePWUrl()
    {
        return Constant.BASE_URL + pathChangePw;
    }
    public void ChangeNewPwSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(tfOldPw, oldPassword);
        SendKeys(tfNewPw, newPassword);
        Click(btnSaveNewPw);
    }
    public void ChangeNewPwUnSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(tfOldPw, oldPassword);
        SendKeys(tfNewPw, newPassword);
    }
    public string DisplayChangePwSuccessfully()
    {
        WaitToBeVisible(HeaderChangePw);
        return TextChangePwSuccessfully;
    }
    public void SelectChangePassword()
    {
        Click(btnNavigationBar);
        Click(btnChangePw);

    }
    public void SelectCancel()
    {
        Click(btnNavigationBar);
        Click(btnChangePw);
        Click(btnCancel);
    }
    public string DisplayErrorMessages()
    {
        WaitToBeVisible(ErrorMessagesNewPw);
        return ErrorMessagesNewPw;
        WaitToBeVisible(ErrorMessagesOldPw);
        return ErrorMessagesOldPw;
    }
}

