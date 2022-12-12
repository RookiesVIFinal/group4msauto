using AssetManagementTestProject.DataFromUI;
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
    #region USER LIST
    public readonly string BtnManageUser = "//a[contains(@href, '/admin/manage-user')]";
    public readonly string BtnStaffCode = "//span[contains(text(), 'Staff Code')]";
    public readonly string BtnFullName = "//span[contains(text(), 'Full Name')]";
    public readonly string BtnUsername = "//span[contains(text(), 'Username')]";
    public readonly string BtnJoinedDate = "//span[contains(text(), 'Joined Date')]";
    public readonly string BtnSortType = "//div[@class='ant-select w-3/12 css-1wismvm ant-select-single ant-select-allow-clear ant-select-show-arrow']";
    public readonly string BtnSortAdminType = "//div[(text()= 'Admin') and (@class='ant-select-item-option-content')]";
    public readonly string BtnSortStaffType = "//div[(text()= 'Staff') and (@class='ant-select-item-option-content')]";
    public readonly string BtnType = "//span[text()= 'Type' and @class='ant-table-column-title']";
    #endregion
    public readonly string HeaderDetailedUser = "//h1[text()='Detail User Information']";
    public readonly string CellsDetailedInfo = "//td[contains(@class, 'font-bold')]/following-sibling::*";
    #region SEARCH
    public readonly string TfSearch = "//input[contains(@class,'ant-input css-1wismvm')]";
    public readonly string BtnSearch = "//button[contains(@class,'ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-input-search-button')]";
    public readonly string TableData = "//tbody[contains(@class,'ant-table-tbody')]";
    #endregion
    #region DISABLE
    public readonly string BtnDisableOnTable = "(//button[(@type = 'button') and (@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-btn-dangerous ml-2')])";
    public readonly string BtnDisableOnPopUp = "(//button[(@type = 'button') and (@class='ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous mr-2')])";
    public readonly string BtnCancelDisable = "(//button[(@type = 'button') and (@class='ant-btn css-1wismvm ant-btn-default')])";
    public string HeaderDisableUser = "//h1[text()='Are you sure?']";
    public string TextDisableUser = "//p[text()='Do you want to disable this user?']";
    #endregion
    #region GRID
    public UserDataFromUI? UserActualData;
    public ViewUserInList? UserInfo;
    public ViewDetailedUser? DetailedUserInfo;
    #endregion
    #region CELL LOCATOR
    public readonly string CellLocator = "//td[contains(@class,'ant-table-cell')]";
    public readonly string RowLocator = "//tr[contains(@class,'ant-table-row ant-table-row-level-0')]";
    #endregion
    public string BtnViewTopUserDetailedInfo = "(//td[@class='ant-table-cell'])[1]";
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

    public void ClearAndInputSearch(string input)
    {
        Clear(TfSearch);
        SendKeys(TfSearch, input);
        Click(BtnSearch);
        Thread.Sleep(5000);
    }
    public void ClickSearch()
    {
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
    public void SelectDisable()
    {
        Click(BtnDisableOnTable);
    }
    public void SelectDisableOnPopUp()
    {
        Click(BtnDisableOnPopUp);
        Thread.Sleep(5000);
    }
    public void SelectCancelDisable()
    {
        Click(BtnCancelDisable);
    }
    public void SortUser(string sortType)
    {
        Click(sortType);
        Thread.Sleep(5000);
    }
    public void SortStaffCodeUser()
    {
        FindElementByXpath(BtnStaffCode).Click();
        WaitForQueryResult();
        TakeScreenShot();
    }
    public void SortFullName()
    {
        FindElementByXpath(BtnFullName).Click();
        WaitForQueryResult();
        TakeScreenShot();
    }
    public void SortJoinedDate()
    {
        FindElementByXpath(BtnJoinedDate).Click();
        WaitForQueryResult();
        TakeScreenShot();
    }
    public void SortType()
    {
        FindElementByXpath(BtnType).Click();
        WaitForQueryResult();
        TakeScreenShot();
    }
}

