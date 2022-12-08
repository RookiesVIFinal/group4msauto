<<<<<<< Updated upstream
## Introduction

This is the Automation code base for the 2nd phase of The Rookies Program
=======
# group4msauto
## Introduction

FinalProject is an automation project for testing Asset Management
>>>>>>> Stashed changes

## Project Structure

The project is organized as the structure below

<<<<<<< Updated upstream
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
  - ChangePassword1stTimePage.cs


- **Results**: Includes test results/reports after executing tests 
- **Tests**: Includes all tests scripts divided by features
  - Asset
  - Assignment
  - Login
  - Report
  - User
=======
- **Data**: Includes data driven files
- **Helpers**: 
  - Automation_Test_Framework contains all base methods of pages
  - Core_Framework contains all base methods of test/driver interaction
- **Pages**: Includes pages
  - HomePage.cs
  - LoginPage.cs
  - ManageAssetPage.cs
  - ManageAssignmentPage.cs
  - ManageUserPage.cs
  - So on...
- **Results**: Includes test results/reports after executing tests 
- **Tests**: Includes all tests scripts divided by features
  - APITest.cs
  - LoginTest.cs
  - LogoutTest.cs
  - ManageAssetTest.cs
  - ManageAssignmentTest.cs
  - ManageUserTest.cs
>>>>>>> Stashed changes



## Coding Convention

Examples for pages

<<<<<<< Updated upstream
```cs

LoginPage.cs

using CoreFramework.DriverCore;

namespace AssetManagementTestProject.PageObj;

public class LoginPage : WebDriverAction
{
    private readonly string usernameTextLocator = "//label[contains(@title, 'Username')]"; // for testing
    private readonly string tfUsername = "//input[contains(@id, 'username')]";
    private readonly string tfPassword = "//input[contains(@id, 'password')]";
    private readonly string btnLogin = "//button[contains(@type, 'submit')]";

    public LoginPage() : base()
    {
    }

    public void Login(string userName, string password)
    {
        SendKeys_(tfUsername, userName);
        SendKeys_(tfPassword, password);
        Click(btnLogin);
    }
}
=======
```bash
HomePage.cs

*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${SEARCH_BOX} =     xpath://*[@id="gh-ac"]
${SEARCH_TEXT} =    mobile

*** Keywords ***
Input Search Text and Click Search
    Input Text    //*[@id="gh-ac"]   mobile
    Press Keys    //*[@id="gh-btn"]  RETURN

Click on Advanced Search
    wait until page contains element    //*[@id="gh-as-a"]
    Click Element    //*[@id="gh-as-a"]
>>>>>>> Stashed changes
```

Tests examples

<<<<<<< Updated upstream
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
=======
```bash
*** Settings ***
Documentation    Verify search functionality
Resource    ../Pages/SearchResultPage.robot
Resource    ../Pages/LandingPage.robot
Resource    ../Helperes/Common.robot

Test Setup  Common.Start Test
Test Teardown   Common.Finish Test

*** Test Cases ***
Verify basic search funtionality
    [Documentation]    Basic search
    [Tags]    Search    Functionality
    LandingPage.Search For Somethings
    SearchResultPage.Verify Search Results

Verify advanced search funtionality
    [Documentation]    Addvanced Search
    [Tags]    Search    Functionality
    LandingPage.Search For Somethings In Advanced
    SearchResultPage.Verify Search Results
```

## Gitflow

1/ Create new branch
```bash
git checkout -b {branch-name}
```

2/ Do your changes

3/ Change files which we want to commit to Staged status

4/ Commit your codes
```bash
git commit -m "{message}"
```
5/ Check commit logs
```bash
git log
```
or
```bash
git log --oneline
```

6/ If the log is great, push your local commit to remote repo

```bash
git push origin {branch-name}
```

7/ Create a PR to merge my branch into main

8/ Ping other team members to review my PR

9/ Read comments and fix them

10/ Commit changes and push your commits

11/ If other members are approved your PR, please merge it with squash merge mode. If there are conflicts, please rebase main branch followed these steps below

- Switch to main branch and get latest code

```bash
git checkout main
git pull origin main
```
- Switch to your branch and rebase

```bash
git checkout -
git rebase main
```
- Resolve conflicts one by one in each file
- Continue rebase

```bash
git rebase --continue
```
- IF there are some changed files, please commit your source code as a new commit

```bash
git commit -m "{message}"
```
- Push code to remote repo
```bash
git push origin {branch-name}
```

*/ If you want to hard commit to the last commit try to use:

```bash
git commit --amend --no-edit
>>>>>>> Stashed changes
```

