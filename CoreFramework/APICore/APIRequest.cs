using System.Net;
using System.Text;
using CoreFramework.Reporter;

namespace CoreFramework.APICore;


public class APIRequest
{

    // ------------------------------- WORKING WITH URL -------------------------------

    public HttpWebRequest request;
    public string url { get; set; }
    public string requestBody { get; set; }
    public string formData { get; set; }



    public APIRequest()
    {
        url = "";
        requestBody = "";
        formData = "";
    }
    public APIRequest(string baseUrl)
    {
        this.url = baseUrl;
        requestBody = "";
        formData = "";
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
        if(formData.Equals("") || formData == null)
        {
            formData += key + "=" + value;
        }
        else if (!formData.Equals(""))
        {
            formData += "&" + key + "=" + value;
        }
        return this;
    }
    //public API_Request AddGETParam()
    //{

    //}

    /////// SET 
    public APIRequest SetBody(string body)
    {
        this.requestBody = body;
        return this;
    }
    public APIRequest SetURL(string url)
    {
        this.url = url;
        request = (HttpWebRequest)WebRequest.Create(url);
        return this;
    }

    public APIRequest SetRequestParameter(string key, string value)
    {
        if (url.Contains("?"))
        {
            url += "?" + key + "=" + value;
        }
        else
        {
            // If there is already a parameter
            url += "&" + key + "=" + value;
        }
        return this;
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
    public APIResponse SendRequest()
    {
        if (request.Method == "GET")
        {
            requestBody = null;
        }
        else
        {
            if (requestBody != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Flush();
                    dataStream.Close();
                }
            }
            if (!formData.Equals(""))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(formData);
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

            // Request 4 postman assignment went wrong here?
            var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
            APIResponse response = new APIResponse(httpResponse);
            HtmlReport.CreateAPIRequestLog_(this, response);
            HtmlReport.MarkupPassJson(response.responseBody);
            return response;

        }
        catch (Exception e)
        {
            throw e;
        }
    }

}

