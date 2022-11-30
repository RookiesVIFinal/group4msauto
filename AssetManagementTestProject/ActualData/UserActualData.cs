using CoreFramework.DriverCore;
using OpenQA.Selenium;
using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.TestData;
public class UserActualData : WebDriverAction
{
    public UserActualData() : base()
    {
    }
    public UserDAO GetUserInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        // To check view user list
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
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
    public string ReturnUserRowJSON(string rowLocator, string cellLocator, int index)
    {

        string userRow = (string)ConvertToJson(GetUserInfoFromGrid(rowLocator, cellLocator, index));
        return userRow;
    }
    public List<UserDAO> ReturnUserList(string rowLocator, string cellLocator)
    {
        // Return all user info from a table (assuming that there is no empty row)
        int i = 0;
        List<UserDAO> listOfUsers = new List<UserDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            UserDAO user = GetUserInfoFromGrid(rowLocator, cellLocator, i + 1);
            listOfUsers.Add(user);
            i++;
        }
        return listOfUsers;
    }
    public string ReturnUserListJSON(string rowLocator, string cellLocator)
    {
        string userList = (string)ConvertToJson(ReturnUserList(rowLocator, cellLocator));
        return userList;
    }
}

