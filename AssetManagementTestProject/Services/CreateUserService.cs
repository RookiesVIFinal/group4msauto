using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AssetManagementTestProject.Services;

public class CreateUserService
{

    private string getUserPath = "api/users";

    private APIResponse CreateNewUsersRequest(string token)
    {
        string body = JsonConvert.SerializeObject(Constant.NEW_USER_1);
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API_URL + getUserPath)
               .AddHeader("Authorization", token)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;
    }
    public CreateUserDAO.CreateUserResponse GetNewUsers(string token)
    {
        APIResponse response = CreateNewUsersRequest(token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        var jsonresponse = response.responseBody;
        CreateUserDAO.CreateUserResponse? newUser = JsonConvert.DeserializeObject<CreateUserDAO.CreateUserResponse> (response.responseBody);
        return newUser;
    }
}