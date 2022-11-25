using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using TestProject.DAO;

namespace TestProject.TestData;

public class AssignmentData : WebDriverAction
{

    public AssignmentData(IWebDriver driver) : base(driver)
    {
    }
    public string rowLocator = "";
    public string cellLocator = "";


    public AssignmentDAO GetAssignmentInfoFromGrid(int index)
    {
        List<string> valuesFromCells = GetInfoFromGrid
            (rowLocator, cellLocator, index);

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
            AssignmentDAO assignment = GetAssignmentInfoFromGrid(i + 1);
            listOfAssignments.Add(assignment);
            i++;
        }
        string assignmentList = (string)ConvertToJson(listOfAssignments);
        return assignmentList;
    }
}
