using CoreFramework.DriverCore;

namespace TheRookiesApp.PageObject;

public class EditAssetInfoPage : WebDriverBase
{
    private readonly string _addedURL = "admin/manage-asset";

    public EditAssetInfoPage() : base()
    {

    }
    //public bool IsCorrectRedirect()
    //{
    //    if (Constant.BASE_URL + _addedURL == GetUrl())
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
