using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class AssetTestData : WebDriverAction
{

    public AssetTestData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public AssetDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        AssetDAO asset = new AssetDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5]
            );

        return asset;
    }
    public string ReturnAssetList()
    {
        int i = 0;
        List<AssetDAO> listOfAsset = new List<AssetDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssetDAO asset = GetInfoFromGrid(i + 1);
            listOfAsset.Add(asset);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (AssetDAO asset in listOfAsset.ToList())
        {
            // remove list elements from empty rows
            if (asset.assetCode.Contains(" "))
            {
                listOfAsset.Remove(asset);
            }
            else
            {
                continue;
            }
        }
        string assetList = (string)ConvertToJson(listOfAsset);
        return assetList;
    }
}
