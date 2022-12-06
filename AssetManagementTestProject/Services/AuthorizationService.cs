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
    private APIResponse LoginRequest(string username, string password)
    {
        string body = "{\"username\":" + username + ",\"password\": " + password + "}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + userLoginPath)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "gzip, deflate, br")
               .AddHeader("User-Agent", ".NET Framework Test Client")
               .SetBody(body)
               .Post();
        return response;

    }
    public UserDAO Login(string username, string password)
    {
        APIResponse response = LoginRequest(username, password);
        Assert.True(response.responseStatusCode.Equals("OK"));
        UserDAO user = (UserDAO)JsonConvert.DeserializeObject
            <UserDAO>(response.responseBody);
        return user;
    }
}
