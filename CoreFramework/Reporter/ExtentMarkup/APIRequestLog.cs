using AventStack.ExtentReports.MarkupUtils;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup;

public class APIRequestLog : IMarkup
{
    private APIRequest Request { get; set; }
    private APIResponse Response { get; set; }

    public APIRequestLog(APIRequest request, APIResponse response)
    {
        Request = request;
        Response = response;

    }

    public string GetMarkup()
    {
        string log = $@"
                    <p>Request url: {Request.Url}</p>
                    <p>Request body: {Response.responseBody}</p>
                    <p>Response status: {Response.responseStatusCode}</p>";
        return log;
    }
}

//public class APIRequestLogRS : IMarkup
//{
//    private APIRequestRS request { get; set; }
//    private APIResponseRS response { get; set; }

//    public APIRequestLogRS(APIRequestRS request, APIResponseRS response)
//    {
//        this.request = request;
//        this.response = response;

//    }

//    public string GetMarkup()
//    {
//        string log = $@"
//                    <p>Request url: {request.url}</p>
//                    <p>Request body: {response.responseBody}</p>
//                    <p>Response status: {response.responseStatusCode}</p>";
//        return log;
//    }
//}
