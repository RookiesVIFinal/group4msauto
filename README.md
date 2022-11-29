## Introduction

This is the Automation code base for the 2nd phase of The Rookies Program

## Project Structure

The project is organized as the structure below

- **Data**: Includes data-driven files
- **Projects**: 
  - CoreFW contains all base methods of test/driver interaction
  - TestProject contains all test cases, page objects, DAOs, etc.
- **Pages**: Includes pages
  - CreateAssetPage.cs
  - CreateAssignmentPage.cs
  - CreateUserPage.cs
  - EditAssignmentPage.cs
  - EditAssetPage.cs
  - EditUserInfoPage.cs
  - HomePage.cs
  - LoginPage.cs
  - LogoutPopup.cs
  - ManageAssetPage.cs
  - ManageAssignmentPage.cs
  - ManageUserPage.cs
  - MenuLeft.cs
  - RequestForReturningPage.cs


- **Results**: Includes test results/reports after executing tests 
- **Tests**: Includes all tests scripts divided by features
  - Asset
  - Assignment
  - Login
  - Report
  - User



## Coding Convention

Examples for pages

```cs

WebDriverAction.cs

using System.Globalization;
using CoreFramework.Reporter;
using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DriverManager = CoreFramework.DriverCore.WebDriverManager;


namespace CoreFramework.DriverCore;

public class WebDriverAction
{
    public IWebDriver Driver;
    private WebDriverWait _explicitWait;
    private Actions _actions;
    public IJavaScriptExecutor Javascript;
    private int _timeWait = 60;


    public WebDriverAction()
    {

        Driver = DriverManager.GetCurrentDriver();
        _actions = new Actions(Driver);
        _explicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeWait));
    }
}
```

Tests examples

```cs
LoginTest.cs


using AssetManagementTestProject.PageObj;
using AssetManagementTestProject.TestSetup;
using NUnit.Framework;

namespace AssetManagementTestProject;

[TestFixture]
public class LoginTest : NUnitWebTestSetup
{
    [Test]
    public void TestFirstLogin()
    {
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.BASE_ADMIN_PASSWORD);
        HomePage.VerifyFirstLogin();
        HomePage.ChangePwFirstTimeLogIn();
        LogoutPopup.LogOutOfPage();
        LoginPage.Login(Constant.ADMIN_USERNAME_HN, Constant.CHANGED_ADMIN_PASSWORD);
        Asserter.AssertStringEquals(HomePage.VerifyCorrectRedirection(), Constant.BASE_URL);

    }
}
```

