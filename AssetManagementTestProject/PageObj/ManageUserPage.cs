using AssetManagementTestProject.ActualData;
using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;
using Newtonsoft.Json;
using OpenQA.Selenium;
using static AssetManagementTestProject.DAO.ViewUserDAO;

namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    public readonly string PathManageUser = "admin/manage-user";
    public readonly string BtnCreateNewUser = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string BtnEditUserAtTop = "(//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only mr-2'])[1]";
    public readonly string BHeaderUserList = "//h1[text()='User List']";
    public readonly string FirstRowOfUserList = "(//tr[@class='ant-table-row ant-table-row-level-0'])[1]";
    #region CELL LOCATOR
    public readonly string CellLocator = "(//tr[contains(@class, 'ant-table-row ant-table-row-level-0')])[1]//td[contains(@class, 'ant-table-cell')]";
    public readonly string RowLocator = "(//tr[contains(@class,'ant-table-row ant-table-row-level-0')])";
    #endregion
    #region USER LIST
    public readonly string BtnManageUser = "//a[contains(@href, '/admin/manage-user')]";
    public readonly string BtnStaffCode = "//span[contains(text(), 'Staff Code')]";
    public readonly string BtnFullName = "//span[contains(text(), 'Full Name')]";
    public readonly string BtnUsername = "//span[contains(text(), 'Username')]";
    public readonly string BtnJoinedDate = "//span[contains(text(), 'Joined Date')]";
    public readonly string BtnSortType = "(//input[contains(@type, 'search')])[1]";
    public readonly string BtnSortAdminType = "(//div[contains(text(), 'Admin')])[2]";
    public readonly string BtnSortStaffType = "(//div[contains(text(), 'Staff')])[2]";
    public readonly string BtnType = "(//span[contains(text(), 'Type')])[2]";
    #endregion
    public readonly string HeaderDetailedUser = "//h1[text()='Detail User Information']";
    public readonly string CellsDetailedInfo = "//td[contains(@class, 'font-bold')]/following-sibling::*";
    #region SEARCH
    public readonly string TfSearch = "//input[contains(@class,'ant-input css-1wismvm')]";
    public readonly string BtnSearch = "//button[contains(@class,'ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-input-search-button')]";
    public readonly string TableData = "//tbody[contains(@class,'ant-table-tbody')]";
    #endregion
    #region GRID
    public UserActualData? UserActualData;
    public ViewUserInList? UserInfo;
    public ViewDetailedUser? DetailedUserInfo;
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

    public void SelectAdminType()
    {
        FindElementByXpath(BtnSortType).Click();
        FindElementByXpath(BtnSortAdminType).Click();
    }
    public void SelectStaffType()
    {
        FindElementByXpath(BtnSortType).Click();
        FindElementByXpath(BtnSortAdminType).Click();
    }

    public ViewUserDAO.ViewDetailedUser ReturnDetailedUserInfoFromUI()
    {
        UserActualData actualData = new UserActualData();
        DetailedUserInfo = actualData.ReturnDetailedInfo(CellsDetailedInfo);
        return DetailedUserInfo;
    }

    public void GetDataFromGrid(int index)
    {
        UserActualData = new UserActualData();
        UserActualData.GetUserInfoFromGrid(RowLocator, CellLocator, index);
    }
    public void ReturnNumberOfRows()
    {
        List<int> rows = new List<int>();

        for (int  i = 0; i < 10; i++)
        {

        }


    }
    public void ReturnUserDataFromGrid()
    {
        UserActualData = new UserActualData();
        UserActualData.ReturnUserList(RowLocator, CellLocator);
    }

    public void ReturnUserRowJsonData(int index)
    {
        UserActualData = new UserActualData();
        UserActualData.ReturnUserRowJSON(RowLocator, CellLocator, index);
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
        ViewUserInList userInList = new ViewUserInList(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4]
            );

        return userInList;

    }

    public List<ViewUserInList> ReturnListEmployeeInfo()
    {
        int i = 0;
        List<ViewUserInList> listOfUsers = new List<ViewUserInList>();
        IList<IWebElement> allUserRows = GetAllRows();

        foreach (IWebElement row in allUserRows)
        {
            ViewUserInList employee = GetTextFromEachCell(i + 1);
            listOfUsers.Add(employee);
            i++;
        }
        return listOfUsers;
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

