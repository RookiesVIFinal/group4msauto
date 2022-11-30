using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup;

public class APIRequestLog : IMarkup
{
    private APIRequest Request { get; set; }
    private APIResponse Response { get; set; }

    public APIRequestLog(APIRequest request, APIResponse response)
    {
        this.Request = request;
        this.Response = response;
    }

    public string GetMarkup()
    {
        string log = $@"
                <p>Request url: {Request.Url}</p>
                <p>Response body: {Response.ResponseBody}</p>
                <p>Response status: {Response.ResponseStatusCode} <p>
            ";
        return log;

    }

}
