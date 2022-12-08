﻿namespace AssetManagementTestProject.DAO;

public class LoginDAO
{
    public partial class LoginPostRequest
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public LoginPostRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    public partial class LoginPostResponse
    {
        public bool IsSuccess { get; private set; }
        public object Message { get; private set; }
        public Data Data { get; private set; }
        public LoginPostResponse(bool status, object message, Data data)
        {
            IsSuccess = status;
            Message = message;
            Data = data;
        }
    }

    public partial class Data
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Role { get; private set; }
        public string Token { get; set; }
        public bool IsFirstTimeLogin { get; set; }
        public Data(Guid id, string username, string role, string token, bool isFirstTimeLogin)
        {
            Id = id;
            Username = username;
            Role = role;
            Token = token;
            IsFirstTimeLogin = isFirstTimeLogin;
        }
    }
}
