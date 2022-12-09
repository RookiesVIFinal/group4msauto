using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    public readonly string PathManageUser = "admin/manage-user";
    public readonly string RowLocator = "";
    public readonly string CellLocator = "";
    public readonly string BtnCreateNewUser = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string BtnEditUserAtTop = "(//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only mr-2'])[1]";
    public readonly string HeaderUserList = "//h1[text()='User List']";
    public readonly string FirstRowOfUserList = "(//tr[@class='ant-table-row ant-table-row-level-0'])[1]";
    public readonly string TfSearch = "//input[@type='text']";
    public readonly string SearchButton = "//button[@class='ant-btn css-1wismvm ant-btn-default ant-btn-icon-only ant-input-search-button']";
    public ManageUserPage() : base()
    {
    }
    public void InputSearch(string input)
    {
        SendKeys(TfSearch, input);
        Click(SearchButton);
        /// Search is not fast enough
        /// TODO: Change this hard sleep to explicit wait
        Thread.Sleep(5000);
    }
    
}

