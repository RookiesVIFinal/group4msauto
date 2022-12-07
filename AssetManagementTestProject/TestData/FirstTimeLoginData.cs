using AssetManagementTestProject.DAO;
using System.Globalization;
namespace AssetManagementTestProject.TestData
{
    public class FirstTimeLoginData
    {
        public CreateUserDAO.CreateUserResponse? newUser;
        public string GetUsername()
        {
            return newUser.Data.Username;
        }
        public string GetPassword()
        {
            string newUserDob = newUser.Data.DateOfBirth;
            DateTime parsedDob = DateTime.ParseExact(newUserDob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string formattedDob = parsedDob.ToString("ddMMyyyy");
            string password = GetUsername() + "@" + formattedDob;
            return password;
        }
    }
}