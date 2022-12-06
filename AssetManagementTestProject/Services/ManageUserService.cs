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
        string body = @"{""firstName"":""Tony"",""lastName"":""Tran"",""dateOfBirth"":""2000-09-21"",
            ""gender"":""0"",""joinedDate"":""2022-12-06"",""role"":""0"",""location"":""0""}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API_URL + getUserPath)
               .AddHeader("Authorization", token)
               .SetBody(body)
               .Post();
        return response;
    }
    public List<UserDAO>? GetUsers(string token)
    {
        APIResponse response = GetUsersRequest(token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        var jsonresponse = response.responseBody;
        List<UserDAO>? listUsers = JsonConvert.DeserializeObject<List<UserDAO>>(response.responseBody);
        return listUsers;
    }
}