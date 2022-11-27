using System.Net;

namespace Core_Framework.API_Core;

public class APIResponse
{

    // ------------------------------- ATTRIBUTES -------------------------------

    public HttpWebResponse response;
    public string ResponseBody { get; set; }
    public string ResponseStatusCode { get; set; }

    public APIResponse(HttpWebResponse response)
    {
        this.response = response;
        GetResponseBody();
        GetResponseStatusCode();
    }
    // ------------------------------- METHODS -------------------------------

    //public int GenerateID()
    //{
    //    var jsonData = JSON.parse(responseBody);
    //    System.Reflection.PropertyInfo pi = jsonData.GetType().GetProperty("todos");
    //    Array name = (Array)(pi.GetValue(0, null));
    //    int id = name[0].id;
    //    return id;

    //}
    public string GetResponseBody()
    {
        // recheck this
        ResponseBody = "";
        using (var responseStream = response.GetResponseStream())
        {
            if (responseStream != null)
            {
                using (var reader = new StreamReader(responseStream))
                {
                    ResponseBody = reader.ReadToEnd();
                }
            }
            return ResponseBody;
        }

    }

    public string GetResponseStatusCode()
    {
        try
        {
            HttpStatusCode statusCode = response.StatusCode;
            ResponseStatusCode = statusCode.ToString();
        }
        catch (WebException webException)
        {
            // In case of 4xx and 5xx throw a WebException
            ResponseStatusCode = ((HttpWebResponse)webException.Response).StatusCode.ToString();
        }
        return ResponseStatusCode;

    }
    //public string Constructor()
    //{

    //}
    //public string ExtractFromBody()
    //{

    //}

}