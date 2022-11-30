using System.Net;

namespace CoreFramework.APICore
{

    public class APIResponse
    {    

        // ------------------------------- ATTRIBUTES -------------------------------

        public HttpWebResponse response;
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public APIResponse(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }
        // ------------------------------- METHODS -------------------------------
        public string GetResponseBody()
        {
            // recheck this
            responseBody = "";
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
                return responseBody;
            }

        }
        public string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException webException)
            {
                // In case of 4xx and 5xx throw a WebException
                responseStatusCode = ((HttpWebResponse)webException.Response).StatusCode.ToString();
            }
            return responseStatusCode;

        }
    }
}
