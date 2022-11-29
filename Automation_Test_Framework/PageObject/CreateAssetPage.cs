using Core_Framework.DriverCore;

namespace TheRookiesApp.PageObject;

public class CreateAssetPage : WebDriverBase
{
    private readonly string _addedURL = "admin/manage-asset";

    public CreateAssetPage() : base()
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
