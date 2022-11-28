using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.DAO;

namespace TheRookiesApp.TestSetData;

public class TestSetDataRequest : WebDriverBase
{
    private string rowLocator = "";
    private string cellLocator = "";

    public TestSetDataRequest(IWebDriver? driver) : base(driver)
    {
    }
    public ReturningListDAO GetRequestInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        ReturningListDAO asset = new ReturningListDAO(
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
        List<ReturningListDAO> listOfRequest = new List<ReturningListDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            ReturningListDAO request = GetRequestInfoFromGrid(i + 1);
            listOfRequest.Add(request);
            i++;
        }
        string requestList = (string)ConvertToJson(listOfRequest);
        return requestList;
    }

}
