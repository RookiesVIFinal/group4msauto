﻿using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;
public class HomePage : WebDriverAction
{
    private string btnNavigationBar = "//div[contains(@class, 'ant-dropdown-trigger cursor-pointer')]";
    private string btnChangePw = "//a[contains(@href, '/change-password')]";
    private string btnLogout = "//a[contains(@href, '/logout')]";
    public string HeaderHomePage = "//h1[contains(@class, 'text-red-600')]";
    
    #region MY ASSIGNMENT LIST
    public string HeaderMyAssignment = "//h1[text()='My Assignment']";
    public string BtnAcceptAssignment = "(//span[contains(@aria-label, 'check')])[1]";
    public string BtnDeclineAssignment = "(//span[contains(@aria-label, 'close')])[1]";
    public string BtnRequestReturnAsset = "(//span[contains(@aria-label, 'undo')])[1]";
    #endregion
    public HomePage() : base()
    {
    }
    public void SelectLogout()
    {
        Click(btnNavigationBar);
        Click(btnLogout);
    }
}
