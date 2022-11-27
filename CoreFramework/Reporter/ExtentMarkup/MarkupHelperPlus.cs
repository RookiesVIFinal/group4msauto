using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup;

public class MarkupHelperPlus
{
    public static IMarkup CreateAPIRequestLog(APIRequest request, APIResponse response)
    {
        return new APIRequestLog(request, response);
    }
    //public static IMarkup CreateAPIRequestLogRS(APIRequestRS request, APIResponseRS response)
    //{
    //    return new APIRequestLogRS(request, response);
    //}

}
