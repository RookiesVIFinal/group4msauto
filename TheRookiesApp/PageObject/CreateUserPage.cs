using Core_Framework.DriverCore;

namespace TheRookiesApp.PageObject;

public class CreateUserPage : WebDriverBase
{

    private readonly string _addedURL = "admin/manage-user";

    public CreateUserPage() : base()
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
