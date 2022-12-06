using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AssetManagementTestProject.Services;

public class AuthorizationService
{
    /// <summary>
    /// API Authorize
    /// </summary>
    private string userLoginPath = "api/authentication";
    public APIResponse LoginRequest(string username, string password)
    {
        string body = "{\"username\":\"" + username + "\",\"password\": \"" + password + "\"}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API_URL + userLoginPath)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;

    }
    public UserDAO? Login(string username, string password)
    {
        APIResponse response = LoginRequest(username, password);
        Assert.True(response.responseStatusCode.Equals("OK"));
        UserDAO? user = JsonConvert.DeserializeObject<UserDAO>(response.responseBody);
        return user;
    }

}
