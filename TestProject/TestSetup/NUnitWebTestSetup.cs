using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace TestProject.TestSetup;

public class NUnitWebTestSetup : NUnitTestSetup
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

