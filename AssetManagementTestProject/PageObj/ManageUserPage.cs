using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    private readonly string rowLocator = "";
    private readonly string cellLocator = "";
    public readonly string BtnCreateNewUser = "//button[contains(@class, 'ant-btn css-1wismvm ant-btn-primary ant-btn-dangerous ml-3')]";
    public readonly string HeaderUserList = "//h1[text()='User List']";
    public ManageUserPage() : base()
    {
    }
}
