﻿using Core_Framework.DriverCore;
using OpenQA.Selenium;

namespace TheRookiesApp.PageObject;

public class EditUserInfoPage : WebDriverBase
{
    public EditUserInfoPage(IWebDriver driver) : base(driver)
    {

    }

    //public bool IsCorrectRedirect()
    //{
    //    if (Constant.BASE_URL + addedURL == GetUrl())
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}