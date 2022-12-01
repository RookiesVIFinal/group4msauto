using CoreFramework.DriverCore;
using OpenQA.Selenium;
using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.ActualData;
/// <summary>
/// Iterate through each cell of the View Asset Grid
/// Add texts from each cell to an attribute of the AssetDAO
/// Return an AssetDAO object or the JSON-converted version
/// Similar for other ActualData classes
/// </summary>
public class AssetActualData : WebDriverAction
{
    public AssetActualData() : base()
    {
    }
    public AssetDAO GetAssetInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
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
    public string ReturnAssetRowJSON(string rowLocator, string cellLocator, int index)
    {
        // To check when new asset is created/edited
        // Return only one row of user info
        string assetRow = (string)ConvertToJson(GetAssetInfoFromGrid(rowLocator, cellLocator, index));
        return assetRow;
    }
    public List<AssetDAO> ReturnAssetList(string rowLocator, string cellLocator)
    {
        int i = 0; // clean up this?
        List<AssetDAO> listOfAsset = new List<AssetDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssetDAO asset = GetAssetInfoFromGrid(rowLocator, cellLocator, i + 1);
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
