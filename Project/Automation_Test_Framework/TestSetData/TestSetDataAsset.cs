using Automation_Test_Framework.DAO;

namespace Automation_Test_Framework.TestSetData;

public class TestSetDataAsset
{
    public List<AssetListDAO> testRows = new();


    public void CreateTestRows()
    {
        testRows.Add(new AssetListDAO("", "", "", ""));

    }
}
