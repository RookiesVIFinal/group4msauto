using Automation_Test_Framework.DAO;
using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataUser : WebDriverBase
{
    public TestSetDataUser(IWebDriver driver) : base(driver)
    {
    }
    public string RowLocator = "";
    public string CellLocator = "";


    public UserListDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (RowLocator, CellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        UserListDAO user = new UserListDAO(
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
        List<UserListDAO> listOfUsers = new List<UserListDAO>();
        IList<IWebElement> allRows = GetAllRows(RowLocator);

        foreach (IWebElement row in allRows)
        {
            UserListDAO user = GetInfoFromGrid(i + 1);
            listOfUsers.Add(user);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (UserListDAO user in listOfUsers.ToList())
        {
            // remove list elements from empty rows
            if (user.StaffCode.Contains(" "))
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
