using AssetManagementTestProject.TestData;
using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class CreateNewCategoryPage : WebDriverAction
{
    #region CHANGE PASSWORD
    public readonly string TfCategoryName = "//input[@id='name']";
    public readonly string TfCategoryPrefix = "//input[contains(@id, 'prefix')]";
    public readonly string BtnSaveNewCategory = "(//span[text()='Save'])[2]";
    public readonly string BtnChangePw = "//a[contains(@href, '/change-password')]";
    public readonly string BtnCancel = "//span[contains(text(), 'Cancel')]";
    public readonly string BtnClose = "//button[@aria-label='Close']";
    public readonly string HeaderCreateNewCategory = "//h1[text()='Create New Category']";
    public readonly string PathCreateNewCategory = "create-category";
    public readonly string TextChangePwSuccessfully = "//p[text()='New Category is created successfully!']";
    public readonly string BtnCreateNewCategory = "//span[text()='Add New Category']";
    #endregion
    #region ERROR MESSAGES
    public readonly string ErrorMsgInvalidName = "//div[text()='Category name length should be 6 - 50 characters!']";
    public readonly string ErrorMsgInvalidPrefixOnlyUpperCase = "//div[text()='Prefix should contain only uppercase alphabetic characters!']";
    public readonly string ErrorMsgInvalidPrefixInvalidLength = "//div[text()='Prefix length should be 2 - 8 characters!']";

    #endregion

    public CreateNewCategoryPage() : base()
    {
    }
    public void CreateNewCategory()
    {
        CreateNewCategory createNewCategory = new CreateNewCategory();
        SendKeys(TfCategoryName, createNewCategory.CreateNewValidCategoryName(6));
        SendKeys(TfCategoryPrefix, createNewCategory.CreateNewValidCategoryPrefix(6));
        Click(BtnSaveNewCategory);
    }
    public void SendInvalidInfo()
    {
        CreateNewCategory createNewCategory = new CreateNewCategory();
        SendKeys(TfCategoryName, createNewCategory.CreateNewValidCategoryName(1));
        SendKeys(TfCategoryPrefix, createNewCategory.CreateInvalidCategoryPrefix(1));
    }
}

