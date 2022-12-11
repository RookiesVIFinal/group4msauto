using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    public static string PathManageUser = "admin/manage-user";
    public string BtnViewTopUserDetailedInfo = "(//td[@class='ant-table-cell'])[1]";
    public readonly string BtnCreateNewUser = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string BtnEditUserAtTop = "(//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only mr-2'])[1]";
    public readonly string HeaderUserList = "//h1[text()='User List']";
    public readonly string FirstRowOfUserList = "(//tr[@class='ant-table-row ant-table-row-level-0'])[1]";
    public readonly string TfSearch = "//input[@type='text']";
    public readonly string TableData = "//tbody[contains(@class,'ant-table-tbody')]";
    public readonly string SearchButton = "//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-input-search-button']";
    public readonly string BtnStaffCode = "//span[contains(text(), 'Staff Code')]";
    public readonly string BtnFullName = "//span[contains(text(), 'Full Name')]";
    public readonly string BtnUsername = "//span[contains(text(), 'Username')]";
    public readonly string BtnJoinedDate = "//span[contains(text(), 'Joined Date')]";
    public readonly string BtnSortType = "//div[@class='ant-select w-3/12 css-1wismvm ant-select-single ant-select-allow-clear ant-select-show-arrow']";
    public readonly string BtnSortAdminType = "//div[(text()= 'Admin') and (@class='ant-select-item-option-content')]";
    public readonly string BtnSortStaffType = "//div[(text()= 'Staff') and (@class='ant-select-item-option-content')]";
    public readonly string BtnType = "//span[text()= 'Type' and @class='ant-table-column-title']";
    public ManageUserPage() : base()
    {
    }
    public void InputSearch(string input)
    {
        SendKeys(TfSearch, input);
        FindElementByXpath(SearchButton).Click();
        /// Search is not fast enough
        Thread.Sleep(5000);
    }
    public string ReturnStaffCodeTopListUser()
    {
        return FindElementByXpath(BtnViewTopUserDetailedInfo).Text;
    }
    public void SelectAdminType()
    {
        FindElementByXpath(BtnSortType).Click();
        Click(BtnSortAdminType);
    }
    public void SelectStaffType()
    {
        FindElementByXpath(BtnSortType).Click();
        Click(BtnSortStaffType);
    }
}

