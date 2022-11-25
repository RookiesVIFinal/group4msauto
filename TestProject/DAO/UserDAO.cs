using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace TestProject.DAO;

public class UserDAO
{
    public string staffCode { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullName { get; set; }
    public string userName { get; set; }    
    public string dateOfBirth { get; set; }
    public string joinedDate { get; set; }
    public string gender { get; set; }
    public string type { get; set; }
    public string location { get; set; }

    // To check Create + Edit User - 6 properties
    public UserDAO(string firstName, 
        string lastName, string dateOfBirth, string gender, string joinedDate,  string type)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.joinedDate = joinedDate;
        this.type = type;
    }

    // To check View User - 5 properties
    public UserDAO(string staffCode, string fullName,
        string userName, string joinedDate, string type)
    {
        this.staffCode = staffCode;
        this.fullName = fullName;
        this.userName = userName;
        this.joinedDate = joinedDate;
        this.type = type;
    }

    // To check Detailed User Info - 7 properties
    public UserDAO(string staffCode, string fullName,
        string userName, string dateOfBirth, string gender, string type, string location)
    {
        this.staffCode = staffCode;
        this.fullName = fullName;
        this.userName = userName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.type=type;
        this.location = location;
    }


}
