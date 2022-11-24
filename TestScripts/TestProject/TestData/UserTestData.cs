using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class UserTestData : WebDriverAction
{

    public UserTestData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public UserDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        UserDAO user = new UserDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5],
            valuesFromCells[6]
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
            UserDAO user = GetInfoFromGrid(i + 1);
            listOfUsers.Add(user);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (UserDAO user in listOfUsers.ToList())
        {
            // remove list elements from empty rows
            if (user.staffCode.Contains(" "))
            {
                listOfUsers.Remove(user);
            }
            else
            {
                continue;
            }
        }
        string userList = (string)ConvertToJson(listOfUsers);
        return userList;
    }
}
