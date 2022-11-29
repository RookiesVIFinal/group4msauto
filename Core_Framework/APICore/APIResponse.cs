using System.Net;

namespace Core_Framework.API_Core;

public class APIResponse
{

    #region RESPONSE
    public HttpWebResponse response;
    public string ResponseBody { get; set; }
    public string ResponseStatusCode { get; set; }

    public APIResponse(HttpWebResponse response)
    {
        this.response = response;
        GetResponseBody();
        GetResponseStatusCode();
    }
    #endregion


    #region "METHODS"
    public string GetResponseBody()
    {
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
            ResponseStatusCode = ((HttpWebResponse)webException.Response).StatusCode.ToString();
        }
        return ResponseStatusCode;

    }
    #endregion
}