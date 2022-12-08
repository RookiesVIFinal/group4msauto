using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCase;

[TestFixture]
public class US303_LogoutTest : NUnitWebTestSetup
{

    [Test]
    public void TC01_UserCanLogoutSuccessfully()
    {
        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }


    [Test]
    public void TC02_UserCanCancelLogout()
    {
        HomePage?.SelectLogout();
        LogoutPopup?.CancelLogOutOfPage();
        Asserter?.AssertUrlsEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL);
    }


    [Test]
    public void TC03_UserCannotGoBackToHomePageAfterLogOut()
    {

        HomePage?.SelectLogout();
        LogoutPopup?.LogOutOfPage();
        DriverBaseAction?.MoveBackward();
        Asserter?.AssertElementIsDisplayed(LoginPage.TfUsername);
        Asserter?.AssertElementIsDisplayed(LoginPage.TfPassword);
    }

}

