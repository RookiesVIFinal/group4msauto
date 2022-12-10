using AssetManagementTestProject.ActualData;
using AssetManagementTestProject.DAO;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class DetailedUserInfoPage : WebDriverAction
{
    public readonly string HeaderDetailedUser = "//h1[text()='Detail User Information']";
    public readonly string CellsDetailedInfo = "//td[contains(@class, 'font-bold')]/following-sibling::*";
    public ViewUserDAO.ViewDetailedUser DetailedUserInfo;
    public DetailedUserInfoPage() : base()
    {
    }
    public ViewUserDAO.ViewDetailedUser ReturnDetailedUserInfoFromUI()
    {
        UserActualData actualData = new UserActualData();
        DetailedUserInfo = actualData.ReturnDetailedInfo(CellsDetailedInfo);
        return DetailedUserInfo;
    }
    
}

