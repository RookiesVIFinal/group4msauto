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

    public sealed class RecordRowComparator : Comparer<UserListDAO>
    {
        public override int Compare(UserListDAO? x, UserListDAO? y)
        {
            var compareResult = String.Equals(x?.StaffCode, y?.StaffCode) &&
                String.Equals(x?.FullName, y?.FullName) &&
                String.Equals(x?.UserName, y?.UserName) &&
                String.Equals(x?.JoinedDate, y?.JoinedDate) &&
                String.Equals(x?.Type, y?.Type);
            if (compareResult)
            {
                return 0;
            }
            return 1;
        }
    }
}
