using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AssetManagementTestProject.Services;
/// <summary>
/// API Authorize
/// </summary>
public class AuthorizationService
{
    private string userLoginPath = "";

    private APIResponse LoginRequest(string username, string password)
    {
        string body = "{\'userName\':\"" + username + "\",\'password\': \"" + password + "\"}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API_URL + userLoginPath)
               .AddHeader("Content-Type", "application/json")
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
