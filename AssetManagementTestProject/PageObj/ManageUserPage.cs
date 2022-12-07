using CoreFramework.DriverCore;
namespace AssetManagementTestProject.PageObj;
public class ManageUserPage : WebDriverAction
{
    public readonly string rowLocator = "";
    public readonly string cellLocator = "";

    public string BtnCreateNewUser = "//a[contains(@href,'/admin/manage-user/create-user')]";

    public ManageUserPage() : base()
    {

    }
}

