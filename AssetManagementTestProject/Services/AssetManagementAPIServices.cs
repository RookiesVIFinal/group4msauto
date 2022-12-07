using AssetManagementTestProject.DAO;
using AssetManagementTestProject.TestSetup;
using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
namespace AssetManagementTestProject.Services;
public class AssetManagementAPIServices
{
    #region AUTHORIZATION
    private string userLoginPath = "api/authentication";
    private APIResponse LoginRequest(string username, string password)
    {
        string body = "{\"username\":\"" + username + "\",\"password\": \"" + password + "\"}";
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + userLoginPath)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;
    }
    public string ReturnLoginToken(string username, string password)
    {
        APIResponse response = LoginRequest(username, password);
        Assert.True(response.responseStatusCode.Equals("OK"));
        LoginDAO.LoginPostResponse loginRequest = JsonConvert.DeserializeObject
            <LoginDAO.LoginPostResponse>(response.responseBody);
        return loginRequest.Data.Token;
    }
    #endregion
    #region CREATE NEW USER
    private string userPath = "api/users";
    private APIResponse CreateNewUserRequest(CreateUserDAO.CreateUserRequest newUser, string token)
    {
        string body = JsonConvert.SerializeObject(newUser);
        APIResponse response = new APIRequest()
               .SetURL(Constant.BASE_API + userPath)
               .AddHeader("Authorization", token)
               .AddHeader("Content-Type", "application/json")
               .AddHeader("Accept-Encoding", "none")
               .AddHeader("Accept", "*/*")
               .AddHeader("Connection", "keep-alive")
               .SetBody(body)
               .Post();
        return response;
    }
    public CreateUserDAO.CreateUserResponse ReturnNewUser(CreateUserDAO.CreateUserRequest newUserRequest, string token)
    {
        APIResponse response = CreateNewUserRequest(newUserRequest, token);
        Assert.True(response.responseStatusCode.Equals("OK"));
        CreateUserDAO.CreateUserResponse newUser = JsonConvert.DeserializeObject
            <CreateUserDAO.CreateUserResponse>(response.responseBody);
        return newUser;
    }
    #endregion
    #region GET USER AND EDIT

    #endregion
    #region DISABLE USER

    #endregion
}

