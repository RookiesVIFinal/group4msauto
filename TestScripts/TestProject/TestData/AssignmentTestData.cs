using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class AssignmentTestData : WebDriverAction
{

    public AssignmentTestData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public AssignmentDAO GetInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);
        // assign each value from cell to an EmployeeInfo object
        AssignmentDAO assignment = new AssignmentDAO(
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
        List<AssignmentDAO> listOfAssignments = new List<AssignmentDAO>();
        IList<IWebElement> allRows = GetAllRows(rowLocator);

        foreach (IWebElement row in allRows)
        {
            AssignmentDAO assignment = GetInfoFromGrid(i + 1);
            listOfAssignments.Add(assignment);
            i++;
        }

        // Probably no empty row - Consider delete?
        foreach (AssignmentDAO assignment in listOfAssignments.ToList())
        {
            // remove list elements from empty rows
            if (assignment.assetCode.Contains(" "))
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
