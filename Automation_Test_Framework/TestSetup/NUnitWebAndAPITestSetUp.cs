using Core_Framework.NUnitTestSetup;
using NUnit.Framework;

namespace Automation_Test_Framework.TestSetup;

public class NUnitWebAndAPITestSetUp : NUnit_Test_Setup
{
    [SetUp]
    public void SetUp()
    {
        DriverBaseAction.GoToUrl(Constant.BASE_URL);
    }

    [TearDown]
    public void TearDown()
    {

    }

}
