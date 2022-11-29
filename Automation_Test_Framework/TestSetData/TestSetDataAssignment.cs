using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.DAO;

namespace TheRookiesApp.TestSetData;

public class TestSetDataAssignment : WebDriverBase
{
    public TestSetDataAssignment() : base()
    {
    }


    public AssignmentListDAO GetAssignmentInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);
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

    public string ReturnAssignmentRowJSON(string rowLocator, string cellLocator, int index)
    {
        // To check when new assignment is created/edited
        // return only one row of user info
        string assignmentRow = (string)ConvertToJson(GetAssignmentInfoFromGrid(rowLocator, cellLocator, index));
        return assignmentRow;
    }

    public List<AssignmentListDAO> ReturnAssignmentList(string rowLocator, string cellLocator)
    {
        int i = 0;
        List<AssignmentListDAO> listOfAssignments = new List<AssignmentListDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssignmentListDAO assignment = GetAssignmentInfoFromGrid(rowLocator, cellLocator, i + 1);
            listOfAssignments.Add(assignment);
            i++;
        }
        return listOfAssignments;
    }

    public string ReturnAssignmentListJSON(string rowLocator, string cellLocator)
    {
        string assignmentList = (string)ConvertToJson(ReturnAssignmentList(rowLocator, cellLocator));
        return assignmentList;
    }

}
