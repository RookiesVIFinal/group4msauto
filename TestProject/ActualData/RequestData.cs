using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class RequestData : WebDriverAction
{

    public RequestData(IWebDriver driver) : base(driver)
    {
    }
    private string rowLocator = "";
    private string cellLocator = "";


    public RequestForReturnDAO GetRequestInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);

        RequestForReturnDAO asset = new RequestForReturnDAO(
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
        List<RequestForReturnDAO> listOfRequest = new List<RequestForReturnDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            RequestForReturnDAO request = GetRequestInfoFromGrid(i + 1);
            listOfRequest.Add(request);
            i++;
        }
        string requestList = (string)ConvertToJson(listOfRequest);
        return requestList;
    }
}
