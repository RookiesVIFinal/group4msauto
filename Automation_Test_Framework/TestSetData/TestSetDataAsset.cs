using Automation_Test_Framework.DAO;
using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataAsset : WebDriverBase
{
    public TestSetDataAsset(IWebDriver driver) : base(driver)
    {

    }
    public string RowLocator = "";
    public string CellLocator = "";


    public AssetListDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid(RowLocator, CellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        AssetListDAO asset = new AssetListDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3]
            );

        return asset;
    }

    public string ReturnAssetList()
    {
        int i = 0;
        List<AssetListDAO> listOfAsset = new List<AssetListDAO>();
        IList<IWebElement> allRows = GetAllRows(RowLocator);

        foreach (IWebElement row in allRows)
        {
            AssetListDAO asset = GetInfoFromGrid(i + 1);
            listOfAsset.Add(asset);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (AssetListDAO asset in listOfAsset.ToList())
        {
            // remove list elements from empty rows
            if (asset.AssetCode.Contains(" "))
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
