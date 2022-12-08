using AssetManagementTestProject.DAO;
using System.Globalization;
namespace AssetManagementTestProject.TestData
{
    public class FirstTimeLoginData
    {
        public CreateUserDAO.CreateUserResponse? NewUser;
        public string GetUsername()
        {
            return NewUser.Data.Username;
        }
        public string GetPassword()
        {
            string newUserDob = NewUser.Data.DateOfBirth;
            DateTime parsedDob = DateTime.ParseExact(newUserDob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string formattedDob = parsedDob.ToString("ddMMyyyy");
            string password = GetUsername() + "@" + formattedDob;
            return password;
        }
    }
}
