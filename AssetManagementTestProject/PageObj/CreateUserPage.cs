using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.DriverCore;
using System.Globalization;
namespace AssetManagementTestProject.PageObj;
public class CreateUserPage : WebDriverAction
{
    private readonly string btnSave = "//span[text()='Save']";
    private readonly string datePickDateOfBirth = "//input[contains(@id, 'formCreateUser_dateOfBirth')]";
    private readonly string datePickJoinedDate = "//input[contains(@id, 'formCreateUser_joinedDate')]";
    private readonly string dropBarType = "//input[contains(@id, 'formCreateUser_role')]";
    private readonly string tfFirstName = "//input[contains(@id, 'formCreateUser_firstName')]";
    private readonly string tfLastName = "//input[contains(@id, 'formCreateUser_lastName')]";
    private readonly string tickGenderFemale = "(//input[contains(@type, 'radio')])[1]";
    private readonly string tickGenderMale = "(//input[contains(@type, 'radio')])[2]";
    private readonly string typeAdmin = "//div[text()='Admin']";
    private readonly string typeStaff = "//div[text()='Staff']";
    public CreateUserPage() : base()
    {
    }
    public void CreateNewUser(CreateUserDAO.CreateUserUI userInfo)
    {
        SendKeys(tfFirstName, userInfo.FirstName);
        SendKeys(tfLastName, userInfo.LastName);
        SelectDateOfBirth(userInfo.DateOfBirth);
        SelectGender(userInfo.Gender);
        SelectJoinedDate(userInfo.JoinedDate);
        SelectUserType(userInfo.Role);
        Click(btnSave);
    }
    public void SelectDate(string dateTimeString, string dateField)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        WaitToBeClickable(dateField);
        Javascript.ExecuteScript($"arguments[0].setAttribute('value', '{dateTime.ToString("yyyy/MM/dd")}");
    }
    public void SelectDateOfBirth(string dateTimeString)
    {
        SelectDate(dateTimeString, datePickDateOfBirth);
    }
    public void SelectJoinedDate(string dateTimeString)
    {
        SelectDate(dateTimeString, datePickJoinedDate);
    }
    public void SelectUserType(string userType)
    {
        if (userType == GetText(typeAdmin))
        {
            SelectOption(dropBarType, userType);
        }
        else if (userType == GetText(typeStaff))
        {
            SelectOption(dropBarType, userType);
        }
    }
    public void SelectGender(string gender)
    {
        if (gender == Constant.GENDER_MALE)
        {
            Click(tickGenderMale);
        }
        else if (gender == Constant.GENDER_FEMALE)
        {
            Click(tickGenderFemale);
        }
    }
}