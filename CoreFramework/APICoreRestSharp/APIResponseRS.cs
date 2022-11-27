//using System.Net;
//using RestSharp;

//namespace CoreFramework.APICoreRestSharp;

//public class APIResponseRS
//{
//    public RestResponse response;
//    public string responseBody { get; set; }
//    public string responseStatusCode { get; set; }

//    public APIResponseRS(RestResponse response)
//    {
//        this.response = response;
//        GetResponseBody();
//        GetResponseStatusCode();
//    }
//    public string GetResponseBody()
//    {
//            return response.Content();
//        }

//    }
//    public string GetResponseStatusCode()
//    {
//        try
//        {
//            HttpStatusCode statusCode = response.StatusCode;
//            responseStatusCode = statusCode.ToString();
//        }
//        catch (WebException webException)
//        {
//            // In case of 4xx and 5xx throw a WebException
//            responseStatusCode = response.StatusCode.ToString();
//            throw webException;
//        }
//        return responseStatusCode;

//    }
//}
