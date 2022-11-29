using AventStack.ExtentReports.MarkupUtils;
using Core_Framework.API_Core;

namespace Core_Framework.Reporter.ExtentMarkup;

public class MarkupHelperPlus
{
    public static IMarkup CreateAPIRequestLog(APIRequest request, APIResponse response)
    {
        return new APIRequestLog(request, response);
    }
}
