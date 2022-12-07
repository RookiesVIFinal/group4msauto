
namespace AssetManagementTestProject.DAO;

public class ViewUserDAO
{
    /// <summary>
    /// To check View User - 5 properties
    /// </summary>
    public partial class ViewUserInList
    {
        public string StaffCode { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }    
        public string DateOfBirth { get; private set; }
        public string JoinedDate { get; private set; }
        public string Type { get; private set; }
        public ViewUserInList(string staffCode, string fullName,
        string userName, string joinedDate, string type)
        {
            StaffCode = staffCode;
            FullName = fullName;
            UserName = userName;
            JoinedDate = joinedDate;
            Type = type;
        }
    }
    /// <summary>
    /// To check Detailed User Info - 7 properties
    /// </summary>
    public partial class ViewDetailedUser
    {
        public string Gender { get; private set; }
        public string Location { get; private set; }
        public ViewUserInList UserInfo { get; private set; }
        public ViewDetailedUser(string gender, string location, ViewUserInList userInfo)
        {
            Gender = gender;
            Location = location;
            UserInfo = userInfo;
        }
    }

}
