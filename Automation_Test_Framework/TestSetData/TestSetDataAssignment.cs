using Automation_Test_Framework.DAO;
using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataAssignment : WebDriverBase
{
    public TestSetDataAssignment(IWebDriver driver) : base(driver)
    {
    }
    public string RowLocator = "";
    public string CellLocator = "";


    public AssignmentListDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (RowLocator, CellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        AssignmentListDAO assignment = new AssignmentListDAO(
            valuesFromCells[0],
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5]
            );

        return assignment;
    }

    public string ReturnAssignmentList()
    {
        int i = 0;
        List<AssignmentListDAO> listOfAssignments = new List<AssignmentListDAO>();
        IList<IWebElement> allRows = GetAllRows(RowLocator);

        foreach (IWebElement row in allRows)
        {
            AssignmentListDAO assignment = GetInfoFromGrid(i + 1);
            listOfAssignments.Add(assignment);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (AssignmentListDAO assignment in listOfAssignments.ToList())
        {
            // remove list elements from empty rows
            if (assignment.AssetCode.Contains(" "))
            {
                listOfAssignments.Remove(assignment);
            }
            else
            {
                continue;
            }
        }
        string assignmentList = (string)ConvertToJson(listOfAssignments);
        return assignmentList;
    }

}
