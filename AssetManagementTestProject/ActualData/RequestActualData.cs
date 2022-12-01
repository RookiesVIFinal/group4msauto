using CoreFramework.DriverCore;
using OpenQA.Selenium;
using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.TestData;

public class RequestActualData : WebDriverAction
{
    private string rowLocator = "";
    private string cellLocator = "";

    public RequestActualData() : base()
    {
    }
    public ReturningDAO GetRequestInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        ReturningDAO asset = new ReturningDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5],
            valuesFromCells[6]
            );

        return asset;
    }
    public string ReturnAssetList()
    {
        int i = 0; // clean up this?
        List<ReturningDAO> listOfRequest = new List<ReturningDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            ReturningDAO request = GetRequestInfoFromGrid(i + 1);
            listOfRequest.Add(request);
            i++;
        }
        string requestList = (string)ConvertToJson(listOfRequest);
        return requestList;
    }
}
