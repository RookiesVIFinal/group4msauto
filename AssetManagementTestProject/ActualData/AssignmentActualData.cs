using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using AssetManagementTestProject.DAO;

namespace AssetManagementTestProject.TestData;

public class AssignmentActualData : WebDriverAction
{
    public AssignmentActualData(IWebDriver? driver) : base(driver)
    {
    }
    public AssignmentDAO GetAssignmentInfoFromGrid(string rowLocator, string cellLocator, int index)
    {
        List<string> valuesFromCells = GetTextFromAllCellsOfOneRow
            (rowLocator, cellLocator, index);

        // start from index 1 to skip No. column
        AssignmentDAO assignment = new AssignmentDAO(
            valuesFromCells[1],
            valuesFromCells[2],
            valuesFromCells[3],
            valuesFromCells[4],
            valuesFromCells[5],
            valuesFromCells[6]
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
    public List<AssignmentDAO> ReturnAssignmentList(string rowLocator, string cellLocator)
    {
        int i = 0;
        List<AssignmentDAO> listOfAssignments = new List<AssignmentDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssignmentDAO assignment = GetAssignmentInfoFromGrid(rowLocator, cellLocator, i + 1);
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
