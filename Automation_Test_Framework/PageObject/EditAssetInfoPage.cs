﻿using Core_Framework.DriverCore;
using OpenQA.Selenium;
using TheRookiesApp.TestSetup;

namespace TheRookiesApp.PageObject;

public class EditAssetInfoPage : WebDriverBase
{
    public EditAssetInfoPage(IWebDriver driver) : base(driver)
    {

    }

    private readonly string _addedURL = "admin/manage-asset";

    //public bool IsCorrectRedirect()
    //{
    //    if (Constant.BASE_URL + _addedURL == GetUrl())
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
