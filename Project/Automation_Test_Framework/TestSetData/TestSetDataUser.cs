using Automation_Test_Framework.DAO;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataUser
{
    public List<UserListDAO> testRows = new();

    public void CreateTestRows()
    {
        testRows.Add(new UserListDAO("", "", "", "", ""));
    }
}
