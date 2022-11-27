//using CoreFramework.Reporter;
//using RestSharp;
//using RestSharp.Authenticators;
//using RestSharp.Serialization;

//namespace CoreFramework.APICoreRestSharp;

//public class APIRequestRS
//{
//    public RestRequest request;
//    public RestClient client;

//    public string url { get; set; }
//    public string requestBody { get; set; }
//    public string formData { get; set; }
//    public APIRequestRS()
//    {
//        url = "";
//        requestBody = "";
//        formData = "";
//    }
//    public APIRequestRS(string baseUrl)
//    {
//        this.url = baseUrl;
//        requestBody = "";
//        formData = "";
//    }
//    public APIRequestRS AddHeader(string key, string value)
//    {
//        request.AddHeader(key, value);
//        return this;
//    }
//    public APIRequestRS AddFormData(string key, string value)
//    {
//        if (formData.Equals("") || formData == null)
//        {
//            formData += key + "=" + value;
//        }
//        else if (!formData.Equals(""))
//        {
//            formData += "&" + key + "=" + value;
//        }
//        return this;
//    }
//    public APIRequestRS SetBody(string body)
//    {
//        requestBody = body;
//        return this;
//    }
//    public APIRequestRS SetRequestParameter(string key, string value)
//    {
//        if (url.Contains("?"))
//        {
//            url += "?" + key + "=" + value;
//        }
//        else
//        {
//            // If there is already a parameter
//            url += "&" + key + "=" + value;
//        }
//        return this;
//    }
//    public APIRequestRS SetURL(string url)
//    {
//        this.url = url;
//        client = new RestClient(url);
//        return this;
//    }
//    public APIRequestRS SetAuthenticator(string username, string password)
//    {
//        client.Authenticator = new HttpBasicAuthenticator(username, password);
//        return this;
//    }
//    public Task<APIResponseRS> Get()
//    {
//        request = new(Method.GET);
//        Task<APIResponseRS> response = SendRequest();
//        return response;
//    }
//    public Task<APIResponseRS> Post()
//    {
//        request = new(Method.POST);
//        Task<APIResponseRS> response = SendRequest();
//        return response;
//    }
//    public Task<APIResponseRS> Put()
//    {
//        request = new(Method.PUT);
//        Task<APIResponseRS> response = SendRequest();
//        return response;
//    }
//    public Task<APIResponseRS> Delete()
//    {
//        request = new(Method.DELETE);
//        Task<APIResponseRS> response = SendRequest();
//        return response;
//    }
//    public async Task<APIResponseRS> SendRequest()
//    {
//        if (request.Method == Method.GET)
//        {
//            requestBody = null;
//        }
//        else
//        {
//            if (requestBody != null)
//            {
//                if (request.Method == Method.POST)
//                {
//                    request.AddBody(requestBody, ContentType.Json);
//                }
//                //if (request.Method == Method.PUT)
//                //{
//                //    request.AddBody(requestBody, ContentType.Json);
//                //    httpResponse = (RestResponse)await client.Put(request);
//                //}
//            }
//        }
//        try
//        {


//            APIResponseRS response = (APIResponseRS)await client.ExecuteAsync(request);
//            HtmlReport.CreateAPIRequestLogRS(this, response);
//            HtmlReport.MarkupPassJson(response.responseBody);
//            return response;

//        }
//        catch (Exception excep)
//        {
//            throw excep;
//        }
//    }
//}
