using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.DAO;

public class UserDAO
{
    public string StaffCode { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName { get; private set; }
    public string UserName { get; private set; }    
    public string DateOfBirth { get; private set; }
    public string JoinedDate { get; private set; }
    public string Gender { get; private set; }
    public string Type { get; private set; }
    public string Location { get; private set; }

    /// <summary>
    /// To check Create + Edit User - 6 properties
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="gender"></param>
    /// <param name="joinedDate"></param>
    /// <param name="type"></param>
    public UserDAO(string firstName, 
        string lastName, string dateOfBirth, string gender, string joinedDate,  string type)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        JoinedDate = joinedDate;
        Type = type;
    }

    /// <summary>
    /// To check View User - 5 properties
    /// </summary>
    /// <param name="staffCode"></param>
    /// <param name="fullName"></param>
    /// <param name="userName"></param>
    /// <param name="joinedDate"></param>
    /// <param name="type"></param>
    public UserDAO(string staffCode, string fullName,
        string userName, string joinedDate, string type)
    {
        StaffCode = staffCode;
        FullName = fullName;
        UserName = userName;
        JoinedDate = joinedDate;
        Type = type;
    }

    /// <summary>
    /// To check Detailed User Info - 7 properties
    /// </summary>
    /// <param name="staffCode"></param>
    /// <param name="fullName"></param>
    /// <param name="userName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="gender"></param>
    /// <param name="type"></param>
    /// <param name="location"></param>
    public UserDAO(string staffCode, string fullName,
        string userName, string dateOfBirth, string gender, string type, string location)
    {
        StaffCode = staffCode;
        FullName = fullName;
        UserName = userName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Type = type;
        Location = location;
    }


}
