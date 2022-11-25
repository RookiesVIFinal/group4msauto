using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class UserData : WebDriverAction
{

    public UserData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public UserDAO GetUserInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);

        UserDAO user = new UserDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4]
            );
        return user;
    }
    public string ReturnUserList()
    {
        int i = 0;
        List<UserDAO> listOfUsers = new List<UserDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            UserDAO user = GetUserInfoFromGrid(i + 1);
            listOfUsers.Add(user);
            i++;
        }
        string userList = (string)ConvertToJson(listOfUsers);
        return userList;
    }
}
