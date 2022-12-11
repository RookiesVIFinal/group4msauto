using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace AssetManagementTestProject.ActualData;
public class UserActualData : WebDriverAction
{
    public UserActualData() : base()
    {
    }
    public ViewUserDAO.ViewUserInList GetUserInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        // To check view user list
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        ViewUserDAO.ViewUserInList user = new ViewUserDAO.ViewUserInList(
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
    public List<ViewUserDAO.ViewUserInList> ReturnUserList(string rowLocator, string cellLocator)
    {
        // Return all user info from a table (assuming that there is no empty row)
        int i = 0;
        List<ViewUserDAO.ViewUserInList> listOfUsers = new List<ViewUserDAO.ViewUserInList>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            ViewUserDAO.ViewUserInList user = GetUserInfoFromGrid(rowLocator, cellLocator, i + 1);
            listOfUsers.Add(user);
            i++;
        }
        return listOfUsers;
    }
    public ViewUserDAO.ViewDetailedUser ReturnDetailedInfo(string locators)
    {
        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> cellElems = FindElementsByXpath(locators);
        foreach(IWebElement elem in cellElems)
        {
            valuesFromCells.Add(elem.Text);
        }
        ViewUserDAO.ViewDetailedUser userDetailedInfo = new ViewUserDAO.ViewDetailedUser(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5],
            valuesFromCells[6]
        );
        return userDetailedInfo;
    }
    public string ReturnUserListJSON(string rowLocator, string cellLocator)
    {
        string userList = (string)ConvertToJson(ReturnUserList(rowLocator, cellLocator));
        return userList;
    }
}


