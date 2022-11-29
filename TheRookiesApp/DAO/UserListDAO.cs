namespace TheRookiesApp.DAO;

public class UserListDAO
{
    public string StaffCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string DateOfBirth { get; set; }
    public string JoinedDate { get; set; }
    public string Gender { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }

    /// <summary>
    /// To check Create + Edit User - 6 properties
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="gender"></param>
    /// <param name="joinedDate"></param>
    /// <param name="type"></param>
    public UserListDAO(string firstName,
        string lastName, string dateOfBirth, string gender, string joinedDate, string type)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Gender = gender;
        this.JoinedDate = joinedDate;
        this.Type = type;
    }

    /// <summary>
    /// To check View User - 5 properties
    /// </summary>
    /// <param name="staffCode"></param>
    /// <param name="fullName"></param>
    /// <param name="userName"></param>
    /// <param name="joinedDate"></param>
    /// <param name="type"></param>
    public UserListDAO(string staffCode, string fullName,
        string userName, string joinedDate, string type)
    {
        this.StaffCode = staffCode;
        this.FullName = fullName;
        this.UserName = userName;
        this.JoinedDate = joinedDate;
        this.Type = type;
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
    public UserListDAO(string staffCode, string fullName,
        string userName, string dateOfBirth, string gender, string type, string location)
    {
        this.StaffCode = staffCode;
        this.FullName = fullName;
        this.UserName = userName;
        this.DateOfBirth = dateOfBirth;
        this.Gender = gender;
        this.Type = type;
        this.Location = location;
    }

}
