﻿using System.Globalization;
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


    public WebDriverAction(string baseUrl = "")
    {

        Driver = DriverManager.GetCurrentDriver();
        //Driver.Url = baseUrl;
        _actions = new Actions(Driver);
        _explicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeWait));
    }

    public WebDriverAction(IWebDriver driver)
    {
        Driver = driver;
    }
    public void GoToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
        HtmlReport.Pass("Go to URL [" + url + "]");
    }

    #region  MOVEMENTS
    public void MoveForward()
    {
        // Capture Screenshot fail?
        Driver.Navigate().Forward();

    }
    public void MoveBackward()
    {
        Driver.Navigate().Back();

    }
    public void RefreshPage()
    {
        Driver.Navigate().Refresh();

    }
    public void ScrollToBottomOfPage()
    {
        //This will scroll to the bottom of the page and wait for 1 second for the action to finish
        Javascript.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        Thread.Sleep(1000);
    }
    public void ScrollToTopOfPage()
    {
        //This will scroll to the top of the page and wait one second
        Javascript.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
        Thread.Sleep(1000);
    }
    #endregion

    #region INTERACTING WITH ELEMENTS
    public By GetXpath(string locator)
    {
        return By.XPath(locator);
    }
    public string GetTitle()
    {
        return Driver.Title;
    }
    public string GetUrl()
    {
        return Driver.Url;
    }
    public string GetText(string locator)
    {
        return Driver.FindElement(By.XPath(locator)).Text;
    }
    public string GetTextFromIWebElem(IWebElement e)
    {
        return e.Text;
    }

    public IWebElement FindElementByXpath(string locator)
    {
        IWebElement e = Driver.FindElement(GetXpath(locator));
        HighlightElem(e);
        return e;
    }

    public IList<IWebElement> FindElementsByXpath(string locator)
    {
        return Driver.FindElements(GetXpath(locator));
    }


    public void PressEnter(string locator)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(Keys.Enter);
            HtmlReport.Pass("Press enter on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Press enter on element [" + locator + "] failed");
            throw excep;
        }
    }
    public void Clear(string locator)
    {
        try
        {
            FindElementByXpath(locator).Clear();
            HtmlReport.Pass("Clear previous input in element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clear previous input in element [" + locator + "] failed");
            throw excep;
        }
    }
    public void Click(string locator)
    {
        try
        {
            IWebElement btnToClick = WaitToBeClickable(locator);
            HighlightElem(btnToClick);
            btnToClick.Click();
            HtmlReport.Pass("Clicking on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clicking on element [" + locator + "] failed");
            throw excep;
        }
    }
    public void Click_(string locator)
    {
        /// Use javascriptexecutor to avoid ClickInterceptedException
        try
        {
            IWebElement btnToClick = WaitToBeClickable(locator);
            HighlightElem(btnToClick);
            Javascript.ExecuteScript("arguments[0].click();", btnToClick);

            HtmlReport.Pass("Clicking on element [" + locator + "] passed");

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clicking on element [" + locator + "] failed");
            throw excep;
        }
    }
    public void DoubleClick(string locator)
    {
        try
        {
            IWebElement btnToDoubleClick = WaitToBeClickable(locator);
            HighlightElem(btnToDoubleClick);
            /// TODO: Change this to _actions after done integrating
            //Actions action = new Actions(Driver);
            _actions.DoubleClick(btnToDoubleClick).Perform();
            HtmlReport.Pass("Double click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Double click on element [" + locator + "] failed");
            throw ex;
        }
    }
    public void DoubleClick_(string locator)
    {

        /// Double click_actions using jsexecutor
        try
        {
            IWebElement btnToDoubleClick = WaitToBeClickable(locator);
            HighlightElem(btnToDoubleClick);
            Javascript.ExecuteScript("arguments[0].dblclick();", btnToDoubleClick);
            HtmlReport.Pass("Double click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Double click on element [" + locator + "] failed");
            throw ex;
        }
    }
    public void RightClick(string locator)
    {
        try
        {
            IWebElement btnToRightClick = WaitToBeClickable(locator);
            HighlightElem(btnToRightClick);
            //Actions action = new Actions(Driver);
            _actions.ContextClick(btnToRightClick).Perform();
            HtmlReport.Pass("Right click on element [" + locator + "] successfuly");
        }
        catch (Exception ex)
        {
            HtmlReport.Fail("Right click on element [" + locator + "] failed");
            throw ex;
        }
    }

    public void SendKeys_(string locator, string key)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(key);
            HtmlReport.Pass("Sendkeys to element [" + locator + "] passed", TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Sendkeys to element [ " + locator + " ] failed", TakeScreenShot());
            throw excep;
        }
    }
    public void ReplaceKey(string locator, string key)
    {
        try
        {
            Clear(locator);
            SendKeys_(locator, key);
            HtmlReport.Pass("Clearing previous input in [" + locator + "] and " +
                "replacing it with [" + key + "] passed", TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Clearing previous input in [" + locator + "] and " +
                "replacing it with [" + key + "] failed", TakeScreenShot());
            throw excep;
        }
    }

    public IWebElement HighlightElem(IWebElement e)
    {
        try
        {
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)Driver;
            string highlightJavascript = "arguments[0].style.border='2px solid red'";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { e });
            HtmlReport.Pass("Highlight element [" + e.ToString() + "] passed");
            return e;

        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Highlight element [" + e.ToString() + "] failed");
            throw excep;

        }
    }

    public void SelectOption(string locator, string key)
    {
        try
        {
            IWebElement mySelectOption = FindElementByXpath(locator);
            SelectElement dropdown = new SelectElement(mySelectOption);
            dropdown.SelectByText(key);
            HtmlReport.Pass("Select element " + locator + " successfuly with " + key);
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Select element " + locator + " failed with " + key);
            throw excep;
        }
    }

    public void ClosePopUp(string locator)
    {
        try
        {
            //try to see if the pop up is open and visible for 15 seconds.
            //If it is, click the Close button
            IWebElement popUpCloseButton = WaitToBeClickable(locator);
            popUpCloseButton.Click();
            HtmlReport.Pass("Close Pop up successfully");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Close Pop up fail");
            throw excep;

        }
    }
    #endregion

    #region WAIT TIME
    /// <summary>
    /// Explicit waits to check Visible/Clickable/Selectable
    /// TODO: Change wait to _explicitWait  + _timeWait after done integrating WebDriverAction(string baseUrl="")
    /// </summary>
    public IWebElement WaitToBeVisible(string locator)
    {
        /// var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementIsVisible(GetXpath(locator)));
        return btnToClick;
    }
    public IWebElement WaitToBeClickable(string locator)
    {
        // var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementToBeClickable(GetXpath(locator)));
        return btnToClick;
    }
    public bool WaitToBeSelected(string locator)
    {
        /// var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        var btnToClick = _explicitWait.Until(
            ExpectedConditions.ElementToBeSelected(GetXpath(locator)));
        return btnToClick;
    }
    #endregion

    #region CAPTURE SCREENSHOT
    public string TakeScreenShot()
    {
        try
        {

            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" +
                DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; // Dynamic name
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            HtmlReport.Pass("Take screenshot successfully");
            return path;
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Take screenshot failed");
            throw excep;
        }
    }
    public string TakeScreenshotIf404()
    {
        // Use when comparing titles
        string title = GetTitle();
        string path;
        if (title.Contains("404"))
        {
            path = TakeScreenShot();
            HtmlReport.Warning("Error 404 - Screenshot taken");
            return path;

        }
        path = TakeScreenShot();
        return path;
    }
    #endregion

    #region ADDING TIMESTAMP
    public string GetDateTimeStamp()
    {
        // Get creation time for photos in VN time zone
        var VNCulture = new CultureInfo("vi-VN");
        // get current UTC time
        var utcDate = DateTime.UtcNow;
        // Change time to match VN time
        var VNDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDate, "SE Asia Standard Time");
        // output the GMT+7 time in Vietnam
        string currentTimeVN = VNDate.ToString("yyyy_MM_dd_HH_mm_ss", VNCulture);
        //string currentTimeVN = DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss");
        return currentTimeVN;
    }
    #endregion

    #region VERIFYING / COMPARING / ASSERTING ACTIONS
    public bool IsElementDisplay(string locator)
    {
        IWebElement e = Driver.FindElement(GetXpath(locator));

        if (e == null)
        {
            HtmlReport.Fail("Element is not displayed");
            return false;
        }
        else
        {
            HighlightElem(e);
            HtmlReport.Pass("Element [" + e.Text + "] is displayed", TakeScreenShot());
            return true;
        }
    }

    public void CompareTitles(string expectedTitle)
    {
        try
        {
            string actualTitle = GetTitle();
            actualTitle.Should().Match(expectedTitle);
            //Assert.That(actualTitle, Is.EqualTo(expectedTitle));
            HtmlReport.Pass("Actual title [" + actualTitle + "] matches [" + expectedTitle + "]", 
                TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Titles do not match", TakeScreenshotIf404());
            throw excep;
        }
    }

    public void CompareUrls(string expectedUrl)
    {
        try
        {
            string actualUrl = GetUrl();
            AssertEquals(actualUrl, expectedUrl);
            //Assert.That(actualUrl, Is.EqualTo(expectedUrl));
            HtmlReport.Pass("Actual title [" + actualUrl + "] matches [" + expectedUrl + "]", 
                TakeScreenShot());
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Urls do not match", TakeScreenshotIf404());
            throw excep;
        }
    }
    // TODO: Test if this actually works (Worked for string comparison so far)
    public static void AssertEquals(object actual, object expected)
    {
        try
        {
            actual.Should().BeEquivalentTo(expected);
            HtmlReport.Pass("Actual data [" + actual.ToString() + "] matches " +
                "with expected data [" + expected.ToString() + "]");
        }
        catch (Exception excep)
        {
            HtmlReport.Fail("Actual data [" + actual + "] does not match " +
                "with expected data [" + expected + "]");
            throw excep;
        }
    }
    #endregion

    #region DEALING WITH GRID
    public string GetRowIndex(string rowLocator, string cellLocator, int index)
    {
        // return an indexed row
        return rowLocator + "[" + index + "]" + cellLocator;
    }

    public IList<IWebElement> GetAllRows(string rowLocator)
    {
        IList<IWebElement> allRows = FindElementsByXpath(rowLocator);
        return allRows;
    }

    public List<string> GetTextFromAllCellsOfOneRow(string rowLocator, string cellLocator, int index)
    {
        /// Return a list of cell web elements fow an indexed row
        /// Get texts from all cells of one row and add them to a list of strings
        
        List<string> valuesFromCells = new List<string>();
        IList<IWebElement> allCells = FindElementsByXpath
            (GetRowIndex(rowLocator, cellLocator, index));
        foreach (IWebElement cell in allCells)
        {
            valuesFromCells.Add(GetTextFromIWebElem(cell));
        }
        return valuesFromCells;
    }
    public object ConvertToJson(object obj)
    {
        var list = JsonConvert.SerializeObject(obj);
        return list;
    }
    #endregion

}
