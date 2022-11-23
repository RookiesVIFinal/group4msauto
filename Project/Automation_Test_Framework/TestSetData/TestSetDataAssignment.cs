using Automation_Test_Framework.DAO;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataAssignment
{
    public List<AssignmentListDAO> testRows = new();


    public void CreateTestRows()
    {
        testRows.Add(new AssignmentListDAO("", "", "", "", "", ""));
    }
}
