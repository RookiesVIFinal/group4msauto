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
  - EditAssetPage.robot
  - So on...
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

// Settings
using System.Globalization;

// Variables 
public IWebDriver driver;
public IJavaScriptExecutor Javascript;

// Methods
public IWebElement FindElementByXpath(string locator)
{
	IWebElement e = driver.FindElement(GetXpath(locator));
	HighlightElem(e);
	return e;
}
```

Tests examples

```cs
using NUnit.Framework;
using TestProject.PageObj;
using TestProject.TestSetup;

namespace TestProject;

[TestFixture]
public class US302LoginTest : NUnitWebTestSetup
{
    [Test]
    public void UserCanInputUserName()
    {
        LoginPage loginPage = new LoginPage(_driver);
    }
}
```

