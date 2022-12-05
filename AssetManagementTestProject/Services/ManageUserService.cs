using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AssetManagementTestProject.Services;

public class ManageUserService
{

    private string getUserPath = "api/users";

    private APIResponse GetUsersRequest(string token)
    {
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + getUserPath)
               .AddHeader("Authorization", token)
               .Get();
        return response;
    }
    public List<UserDAO> GetUsers(string token)
    {
        APIResponse response = GetUsersRequest(token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        List<UserDAO> listUsers = (List<UserDAO>)JsonConvert.DeserializeObject
            <List<UserDAO>>(response.responseBody);
        return listUsers;
    }
}

