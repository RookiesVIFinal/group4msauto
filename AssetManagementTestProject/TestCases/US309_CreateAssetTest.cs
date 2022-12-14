using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestData;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssetManagementTestProject.TestCases;

[TestFixture]
public class US309_CreateAssetTest : NUnitWebTestSetup
{    

    [TestCase(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD)]
    [TestCase(Constant.ADMIN_USERNAME_HCM, Constant.ADMIN_PASSWORD)]
    public void TC01_AdminCanCreateNewAsset(string username, string password)
    {
        LoginPage?.Login(username, password);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        CreateAssetPage?.CreateNewAsset(CreateAssetData.NEW_ASSET_UI);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.BtnEditAssetAtTop);
        DriverBaseAction?.FindElementByXpath(ManageAssetPage.FirstRowOfAssetList);
    }
    [Test]
    public void TC02_AdminCreatesNewAssetUnsuccessfully()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        CreateAssetPage?.SendInvalidInfo(CreateAssetData.INVALID_INFO);
        Asserter?.AssertElementIsDisplayed(CreateAssetPage.ErrorMsgInvalidName);
        Asserter?.AssertElementIsDisplayed(CreateAssetPage.ErrorMsgInvalidSpecification);
    }
    [Test]
    public void TC03_AdminPressCancelWhenCreatingNewAsset()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        DriverBaseAction?.Click(CreateAssetPage.BtnCancel);
        Asserter?.AssertEquals(DriverBaseAction?.GetUrl(), Constant.BASE_URL + ManageAssetPage.PathManageAsset);
    }
    [Test]
    public void TC04_AdminCanCreateNewCategory()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        DriverBaseAction?.FindElementByXpath(CreateAssetPage.DropBarCategory).Click();
        DriverBaseAction?.Click(CreateNewCategoryPage.BtnCreateNewCategory);
        CreateNewCategory.ValidCategoryName = CreateNewCategory.CreateNewValidCategoryName(6);
        CreateNewCategory.ValidCategoryPrefix = CreateNewCategory.CreateNewValidCategoryPrefix(6);
        CreateNewCategoryPage?.CreateNewCategory(CreateNewCategory.ValidCategoryName,CreateNewCategory.ValidCategoryPrefix);
    }
    [Test]
    public void TC05_AdminCreateNewCategoryUnsuccessfully()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        DriverBaseAction?.FindElementByXpath(CreateAssetPage.DropBarCategory).Click();
        DriverBaseAction?.Click(CreateNewCategoryPage.BtnCreateNewCategory);
        CreateNewCategory.InvalidCategoryname = CreateNewCategory.CreateNewValidCategoryName(1);
        CreateNewCategory.InvalidCategoryPrefix = CreateNewCategory.CreateInvalidCategoryPrefix(1);
        CreateNewCategoryPage?.SendInvalidInfo(CreateNewCategory.InvalidCategoryname, CreateNewCategory.InvalidCategoryPrefix );
        Asserter?.AssertElementIsDisplayed(CreateNewCategoryPage.ErrorMsgInvalidName);
        Asserter?.AssertElementIsDisplayed(CreateNewCategoryPage.ErrorMsgInvalidPrefixOnlyUpperCase);
        Asserter?.AssertElementIsDisplayed(CreateNewCategoryPage.ErrorMsgInvalidPrefixInvalidLength);
    }
    [Test]
    public void TC06_AdminClicksXWhenCreatingNewCategory()
    {
        LoginPage?.Login(Constant.ADMIN_USERNAME_HN, Constant.ADMIN_PASSWORD);
        DriverBaseAction?.WaitToBeVisible(HomePage.HeaderHomePage);
        DriverBaseAction?.Click(MenuBarLeft.BtnManageAssetInMenu);
        DriverBaseAction?.WaitToBeVisible(ManageAssetPage.HeaderAssetList);
        DriverBaseAction?.Click(ManageAssetPage.BtnCreateNewAsset);
        DriverBaseAction?.FindElementByXpath(CreateAssetPage.DropBarCategory).Click();
        DriverBaseAction?.Click(CreateNewCategoryPage.BtnCreateNewCategory);
        DriverBaseAction?.Click(CreateNewCategoryPage.BtnClose);
    }
}
