using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using System.Globalization;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class CreateUserPage : WebDriverAction
{
    private readonly string btnSave = "//span[text()='Save']";
    public readonly string  BtnCancel = "//span[text()='Cancel']";
    private readonly string btnCloseAfterCreateSuccess = "//span[text()='Close']";
    private readonly string datePickDateOfBirth = "//input[contains(@id, 'formCreateUser_dateOfBirth')]";

    private readonly string datePickJoinedDate = "//input[contains(@id, 'formCreateUser_joinedDate')]";
    private readonly string dropBarType = "//input[@id='formCreateUser_role']";
    private readonly string tfFirstName = "//input[contains(@id, 'formCreateUser_firstName')]";
    private readonly string tfLastName = "//input[contains(@id, 'formCreateUser_lastName')]";
    private readonly string tickGenderFemale = "(//input[contains(@type, 'radio')])[1]";
    private readonly string tickGenderMale = "(//input[contains(@type, 'radio')])[2]";
    private string typePath = "//div[@title='{0}']";
    #region ERROR MESSAGES
    public readonly string ErrorMsgInvalidName = "//div[text()='Name should only contain alphabetic: A to Z or a to z and one space between words!']";
    public readonly string ErrorMsgDOBUnder18 = "//div[text()='User is under 18. Please select a different date!']";
    public readonly string ErrorMsgJoinedDateNotLaterThanDOB = "//div[text()='Joined date must later than Date of Birth. Please select a different date!']";
    public readonly string ErrorMsgJoinDateIsWeekend = "//div[text()='Joined date must not be Saturday or Sunday. Please select a different date!']";
    #endregion
    
    public CreateUserPage() : base()
    {
    }
    public void CreateNewUser(CreateUserDAO.CreateUserUI userInfo)
    {
        SendKeys(tfFirstName, userInfo.FirstName);
        SendKeys(tfLastName,userInfo.LastName);
        SelectDateOfBirth(userInfo.DateOfBirth);
        // Create a new female user by default
        //SelectGender(userInfo.Gender); 
        SelectJoinedDate(userInfo.JoinedDate);
        SelectUserType(userInfo.Role);
        Click(btnSave);
        Click(btnCloseAfterCreateSuccess);
    }
    public void SendInvalidInfo(CreateUserDAO.CreateUserUI invalidUserInfo)
    {
        SendKeys(tfFirstName, invalidUserInfo.FirstName);
        SendKeys(tfLastName,invalidUserInfo.LastName);
        SelectDateOfBirth(invalidUserInfo.DateOfBirth);
        // Create a new female user by default
        //SelectGender(invalidUserInfo.Gender); 
        SelectJoinedDate(invalidUserInfo.JoinedDate);
        SelectUserType(invalidUserInfo.Role);
    }
    public void SelectDate(string dateTimeString, string dateField)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        SendKeys(dateField, dateTime.ToString("yyyy/MM/dd"));
    }
    public void SelectDateOfBirth(string dateTimeString)
    {
        SelectDate(dateTimeString, datePickDateOfBirth);
        PressEnter(datePickDateOfBirth);
    }
    public void SelectJoinedDate(string dateTimeString)
    {
        SelectDate(dateTimeString, datePickJoinedDate);
        PressEnter(datePickJoinedDate);
    }
    public void SelectUserType(string userType)
    {
        FindElementByXpath(dropBarType).Click();
        if (userType == Constant.ROLE_ADMIN)
        {
            typePath = string.Format(typePath, Constant.ROLE_ADMIN);
            Click(typePath);

        }
        else if (userType == Constant.ROLE_STAFF)
        {
            typePath = string.Format(typePath, Constant.ROLE_STAFF);
            Click(typePath);
        }
    }
    public void SelectGender(string gender)
    {
        if (gender == Constant.GENDER_MALE)
        {
            Click(tickGenderMale);
        }
        else if(gender == Constant.GENDER_FEMALE)
        {
            Click(tickGenderFemale);
        }
    }
}
