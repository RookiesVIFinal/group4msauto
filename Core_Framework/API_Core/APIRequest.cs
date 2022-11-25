using Core_Framework.Reporter;
using System.Net;
using System.Text;

namespace Core_Framework.API_Core;

public class APIRequest
{

    // ------------------------------- WORKING WITH URL -------------------------------

    public HttpWebRequest request;
    public string Url { get; set; }
    public string? RequestBody { get; set; }
    public string FormData { get; set; }



    public APIRequest()
    {
        Url = "";
        RequestBody = "";
        FormData = "";
    }
    public APIRequest(string baseUrl)
    {
        Url = baseUrl;
        RequestBody = "";
        FormData = "";
    }
    // ------------------------------- REQUEST ACTIONS -------------------------------


    /////// ADD
    public APIRequest AddHeader(string key, string value)
    {
        request.Headers.Add(key, value);
        return this;
    }

    public APIRequest AddFormData(string key, string value)
    {
        if (FormData.Equals("") || FormData == null)
        {
            FormData += key + "=" + value;
        }
        else if (!FormData.Equals(""))
        {
            FormData += "&" + key + "=" + value;
        }
        return this;
    }

    /////// SET 
    public APIRequest SetBody(string body)
    {
        RequestBody = body;
        return this;
    }
    public APIRequest SetURL(string url)
    {
        this.Url = url;
        request = (HttpWebRequest)WebRequest.Create(url);
        return this;
    }

    public APIRequest SetRequestParameter(string key, string value)
    {
        if (Url.Contains('?'))
        {
            Url += "?" + key + "=" + value;
        }
        else
        {
            
            Url += "&" + key + "=" + value;
        }
        return this;
    }
    public string SetMethod(string method)
    {
        switch (method)
        {
            case "GET":
                request.Method = "GET";
                break;
            case "POST":
                request.Method = "POST";
                break;
            case "PUT":
                request.Method = "PUT";
                break;
            case "DELETE":
                request.Method = "DELETE";
                break;
        }
        return request.Method;

    }
    public APIResponse SendRequest()
    {
        if (request.Method == "GET")
        {
            RequestBody = null;
        }
        else
        {
            if (RequestBody != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(RequestBody);
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Flush();
                    dataStream.Close();
                }
            }
            if (!FormData.Equals(""))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(FormData);
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Flush();
                    dataStream.Close();
                }
            }
        }
        try
        {
            IAsyncResult asyncResult = request.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            
            var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
            APIResponse response = new(httpResponse);
            HtmlReport.CreateAPIRequestLog(this, response);
            HtmlReport.MarkUpJson(response.ResponseBody);
            return response;

        }
        catch (Exception)
        {
            throw;
        }
    }
    public APIResponse Get()
    {
        request.Method = "GET";
        APIResponse response = SendRequest();
        return response;
    }
    public APIResponse Post()
    {
        request.Method = "POST";
        APIResponse response = SendRequest();
        return response;
    }
    public APIResponse Put()
    {
        request.Method = "PUT";
        APIResponse response = SendRequest();
        return response;
    }
    public APIResponse Delete()
    {
        request.Method = "DELETE";
        APIResponse response = SendRequest();
        return response;
    }
}