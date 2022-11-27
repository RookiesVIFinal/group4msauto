using Core_Framework.API_Core;

namespace Automation_Test_Framework.Service;

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

    public static APIResponse GetTodoRequest(string todoId)
    {
    }


}
