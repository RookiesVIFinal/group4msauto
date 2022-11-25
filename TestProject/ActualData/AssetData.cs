using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.ActualData;

public class AssetData : WebDriverAction
{

    public AssetData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public AssetDAO GetAssetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);

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
        int i = 0; // clean up this?
        List<AssetDAO> listOfAsset = new List<AssetDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssetDAO asset = GetAssetInfoFromGrid(i + 1);
            listOfAsset.Add(asset);
            i++;
        }
        string assetList = (string)ConvertToJson(listOfAsset);
        return assetList;
    }
}
