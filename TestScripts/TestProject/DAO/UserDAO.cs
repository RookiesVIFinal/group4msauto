namespace TestProject.DAO;

public class UserDAO
{
    public string staffCode { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string dateOfBirth { get; set; }
    public string joinedDate { get; set; }
    public string gender { get; set; }
    public string type { get; set; }


    public UserDAO(string staffCode, string firstName, 
        string lastName, string dateOfBirth, string joinedDate, string gender, string type)
    {
        this.staffCode = staffCode;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.joinedDate = joinedDate;
        this.gender = gender;
        this.type = type;
    }
}
