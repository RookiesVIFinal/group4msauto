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
    public readonly string HeaderUserList = "//h1[text()='User List']";
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
    public readonly string BtnSortType = "(//span[text()= 'Type' and @class='ant-table-column-title'])";
    public readonly string BtnSortAdminType = "(//div[(text()= 'Admin') and (@class='ant-select-item-option-content')])";
    public readonly string BtnSortStaffType = "(//div[(text()= 'Staff') and (@class='ant-select-item-option-content')])";
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

}

