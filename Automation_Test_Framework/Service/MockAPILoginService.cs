using Core_Framework.API_Core;

namespace TheRookiesApp.Service;

public class MockAPILoginService
{
    public string userLoginPath = "/login";

    public static APIResponse LoginRequest(string username,
                                            string password)
    {
        APIResponse response = new APIRequest()
            .SetURL("" + "/login")
            .AddHeader("Content-Type", "application/x-www-form-urlencoded")
            .AddFormData("username", username)
            .AddFormData("password", password)
            .SendRequest();
        return response;
    }

    public string getTodoPath = "/todo";


}
