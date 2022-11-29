using CoreFramework.DriverCore;

namespace TheRookiesApp.PageObject;

public class CreateAssignmentPage : WebDriverBase
{
    private readonly string _addedURL = "admin/manage-assignment";

    public CreateAssignmentPage() : base()
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
