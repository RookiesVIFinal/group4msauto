using Core_Framework.NUnitTestSetup;
using NUnit.Framework;

namespace Automation_Test_Framework.TestSetup;

public class NUnitWebTestSetUp : NUnit_Test_Setup
{
    [SetUp]
    public void SetUp()
    {
        driverBaseAction.GoToUrl(Constant.BASE_URL);
    }

    [TearDown]
    public void TearDown()
    {

    }
}
