using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class ChangePasswordPage : WebDriverAction
{
    #region CHANGE PASSWORD
    private string _btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string _tfNewPw = "//input[contains(@id, 'newPassword')]";
    private string _tfOldPw = "//input[contains(@id, 'oldPassword')]";
    private string _btnSaveNewPw = "//button[contains(@type, 'submit')]";
    private string _btnChangePw = "//a[contains(@href, '/change-password')]";
    private string _btnCancel = "//span[contains(text(), 'Cancel')]";
    private string _headerChangePw = "//h1[text()='Change Password']";
    private string _pathChangePw = "change-password";
    private string _textChangePwSuccessfully = "//p[text()='Your password has been changed successfully']";
    #endregion
    #region ERROR MESSAGES
    private string _errorMessages = "//div[contains(@id, 'newPassword_help')]";
    #endregion

    public ChangePasswordPage() : base()
    {
    }
    public string DisplayChangePwPopUp()
    {
        WaitToBeVisible(_headerChangePw);
        return _headerChangePw;
    }
    public string ReturnExpectedChangePWUrl()
    {
        return Constant.BASE_URL + _pathChangePw;
    }
    public void ChangeNewPwSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(_tfOldPw, oldPassword);
        SendKeys(_tfNewPw, newPassword);
        Click(_btnSaveNewPw);
    }
    public void ChangeNewPwUnSuccessfully(string oldPassword, string newPassword)
    {
        SendKeys(_tfOldPw, oldPassword);
        SendKeys(_tfNewPw, newPassword);
    }
    public string DisplayChangePwSuccessfully()
    {
        WaitToBeVisible(_headerChangePw);
        return _textChangePwSuccessfully;
    }
    public void SelectChangePassword()
    {
        Click(_btnNavigationBar);
        Click(_btnChangePw);

    }
    public void SelectCancel()
    {
        Click(_btnNavigationBar);
        Click(_btnChangePw);
        Click(_btnCancel);
    }
    public string DisplayErrorMessages()
    {
        WaitToBeVisible(_errorMessages);
        return _errorMessages;
    }
}

