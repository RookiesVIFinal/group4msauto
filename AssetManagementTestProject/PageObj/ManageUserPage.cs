using CoreFramework.DriverCore;
using Newtonsoft.Json;
using OpenQA.Selenium;
using static AssetManagementTestProject.DAO.ViewUserDAO;
using static MongoDB.Libmongocrypt.CryptContext;

namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    public readonly string PathManageUser = "admin/manage-user";
    public readonly string BtnCreateNewUser = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string BtnEditUserAtTop = "(//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only mr-2'])[1]";
    public readonly string BHeaderUserList = "//h1[text()='User List']";
    public readonly string FirstRowOfUserList = "(//tr[@class='ant-table-row ant-table-row-level-0'])[1]";
    #region CELL LOCATOR
    public readonly string CellLocator = "(//td[contains(@class,'ant-table-cell')])";
    public readonly string RowLocator = "(//tr[contains(@class,'ant-table-row ant-table-row-level-0')])";
    #endregion
    #region USER LIST
    public readonly string BtnManageUser = "//a[contains(@href, '/admin/manage-user')]";
    public readonly string BtnStaffCode = "//span[contains(text(), 'Staff Code')]";
    public readonly string BtnFullName = "//span[contains(text(), 'Full Name')]";
    public readonly string BtnUsername = "//span[contains(text(), 'Username')]";
    public readonly string BtnJoinedDate = "//span[contains(text(), 'Joined Date')]";
    public readonly string BtnSortType = "(//span[contains(text(), 'Type')])[1]";
    public readonly string BtnType = "(//span[contains(text(), 'Type')])[2]";
    #endregion
    #region SEARCH
    public readonly string TfSearch = "//input[contains(@class,'ant-input css-1wismvm')]";
    public readonly string BtnSearch = "//button[contains(@class,'ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-input-search-button')]";
    public readonly string TableData = "//tbody[contains(@class,'ant-table-tbody')]";
    #endregion
    public ManageUserPage() : base()
    {
    }

    public void GoToUserList()
    {
        Click(BtnManageUser);
    }

    public void InputSearch(string input)
    {
        SendKeys(TfSearch, input);
        Click(BtnSearch);
        Thread.Sleep(5000);
    }


    public string GetRowIndex_(int index)
    {
        // return an indexed row
        GetRowIndex(RowLocator, CellLocator, index);
        return RowLocator + "[" + index + "]" + CellLocator;
    }
    public IList<IWebElement> GetAllRows()
    {
        IList<IWebElement> allRows = FindElementsByXpath(RowLocator);
        return allRows;
    }
    public void GetAllRows_()
    {
        GetAllRows();
    }

    public List<string> GetTextFromAllCellsOfOneRow(int index)
    {
        /// Return a list of cell web elements fow an indexed row
        /// Get texts from all cells of one row and add them to a list of strings

        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> allCells = FindElementsByXpath
            (GetRowIndex(RowLocator, CellLocator, index));
        foreach (IWebElement cell in allCells)
        {
            valuesFromCells.Add(GetTextFromIWebElem(cell));
        }
        return valuesFromCells;
    }


    public ViewUserInList GetTextFromEachCell(int index)
    {
        // Iterate through one row to get the text value
        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> allCells = FindElementsByXpath(GetRowIndex_(index)); // get all cells in a row
        foreach (IWebElement cell in allCells)
        {
            // go through each cell and add text values to a list of string
            valuesFromCells.Add(GetTextFromIWebElem(cell));

        }
        // assign each value from cell to an EmployeeInfo object
        ViewUserInList employee = new ViewUserInList(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4]
            );

        return employee;

    }

    public List<ViewUserInList> ReturnListEmployeeInfo()
    {
        int i = 0;
        List<ViewUserInList> listOfEmployees = new List<ViewUserInList>();
        IList<IWebElement> allEmployeeRows = GetAllRows();

        foreach (IWebElement row in allEmployeeRows)
        {
            ViewUserInList employee = GetTextFromEachCell(i + 1);
            listOfEmployees.Add(employee);
            i++;
        }
        foreach (ViewUserInList employee in listOfEmployees.ToList())
        {
            // remove list elements from empty rows
            if (employee.StaffCode.Contains(" "))
            {
                listOfEmployees.Remove(employee);
            }
            else
            {
                continue;
            }
        }
        return listOfEmployees;
    }

    public object ConvertToJson(object obj)
    {
        var list = JsonConvert.SerializeObject(obj);
        return list;
    }

    public void ConvertToJson_(object obj)
    {
        ConvertToJson(obj);
    }

}

