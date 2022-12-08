using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using System.Globalization;
using CoreFramework.DriverCore;
using OpenQA.Selenium.Support.UI;

namespace AssetManagementTestProject.PageObj;
public class CreateUserPage : WebDriverAction
{
    private readonly string btnSave = "//span[text()='Save']";
    private readonly string datePickJoinedDate = "//input[contains(@id, 'formCreateUser_joinedDate')]";
    private readonly string dropBarType = "//input[@id='formCreateUser_role']";
    private readonly string tfFirstName = "//input[contains(@id, 'formCreateUser_firstName')]";
    private readonly string tfLastName = "//input[contains(@id, 'formCreateUser_lastName')]";
    private readonly string tickGenderFemale = "(//input[contains(@type, 'radio')])[1]";
    private readonly string tickGenderMale = "(//input[contains(@type, 'radio')])[2]";

    private string typePath = "//div[text()='{0}']";
    #region BUTTONS TO PICK DOB
    private readonly string datePickDateOfBirth = "//input[contains(@id, 'formCreateUser_dateOfBirth')]";
    private readonly string btnHeaderYear = "//button[@class='ant-picker-year-btn']";
    private readonly string btnSuperPrevious = "//button[@class='ant-picker-header-super-prev-btn']";
    private readonly string btnSelectYear = "(//div[@class='ant-picker-cell-inner'])[2]";
    #endregion
    
    public CreateUserPage() : base()
    {
    }
    public void CreateNewUser(CreateUserDAO.CreateUserUI userInfo)
    {
        SendKeys(tfFirstName, userInfo.FirstName);
        SendKeys(tfLastName,userInfo.LastName);
        SelectDateOfBirth(userInfo.DateOfBirth);
        SelectJoinedDate(userInfo.JoinedDate);
        SelectUserType(userInfo.Role);
        Click(btnSave);
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
            /// TODO: Fix Elem not interactable here
            FindElementByXpath(typePath).Click();
        }
        else if (userType == Constant.ROLE_STAFF)
        {
            typePath = string.Format(typePath, Constant.ROLE_STAFF);
            FindElementByXpath(typePath).Click();
        }
    }
    public void SelectGender (string gender)
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
