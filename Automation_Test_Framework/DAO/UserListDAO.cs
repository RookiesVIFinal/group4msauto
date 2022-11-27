namespace Automation_Test_Framework.DAO;

public class UserListDAO
{
    public string StaffCode { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string JoinedDate { get; set; }
    public string Type { get; set; }

    public UserListDAO(string staffCode, string fullName, string userName, 
                    string joinedDate, string type)
    {
        this.StaffCode = staffCode;
        this.FullName = fullName;
        this.UserName = userName;
        this.JoinedDate = joinedDate;
        this.Type = type;
    }

}
