using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.DAO;

namespace TheRookiesApp.TestSetData;

public class TestSetDataAsset : WebDriverBase
{
    public TestSetDataAsset(IWebDriver? driver) : base(driver)
    {

    }


    public AssetListDAO GetAssetInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        AssetListDAO asset = new AssetListDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5]
            );

        return asset;
    }

    public string ReturnAssetRowJSON(string rowLocator, string cellLocator, int index)
    {
        // To check when new asset is created/edited
        // Return only one row of user info
        string assetRow = (string)ConvertToJson(GetInfoFromGrid(rowLocator, cellLocator, index));
        return assetRow;
    }

    public List<AssetListDAO> ReturnAssetList(string rowLocator, string cellLocator)
    {
        int i = 0; // clean up this?
        List<AssetListDAO> listOfAsset = new List<AssetListDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssetListDAO asset = GetAssetInfoFromGrid(rowLocator, cellLocator, i + 1);
            listOfAsset.Add(asset);
            i++;
        }
        return listOfAsset;
    }

    public string ReturnAssetListJSON(string rowLocator, string cellLocator)
    {
        string assetList = (string)ConvertToJson(ReturnAssetList(rowLocator, cellLocator));
        return assetList;
    }

}
