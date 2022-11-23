using Core_Framework.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace Core_Framework.DriverCore;

public class WebDriverAction
{
    public IWebDriver driver;
    public IJavaScriptExecutor Javascript { get; set; }


    public WebDriverAction(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void GoToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
        HtmlReport.Pass("Go to URL" + url);
    }
    // ------------------------------- MOVEMENTS -------------------------------

    public void MoveForward()
    {
        // Capture Screenshot fail?
        driver.Navigate().Forward();

    }
    public void MoveBackward()
    {
        driver.Navigate().Back();

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

    // ------------------------------- INTERACTING WITH ELEMENTS  -------------------------------
    public static By GetXpath(string locator)
    {
        return By.XPath(locator);
    }

    public string GetTitle()
    {
        return driver.Title;
    }

    public string GetUrl()
    {
        return driver.Url;
    }

    public string GetTextFromElement(string locator)
    {
        return driver.FindElement(By.XPath(locator)).Text;
    }

    public static string GetTextFromElement(IWebElement e)
    {
        return e.Text;
    }

    public IWebElement FindElementByXpath(string locator)
    {
        IWebElement e = driver.FindElement(GetXpath(locator));
        HighlightElement(e);
        return e;
    }

    public IList<IWebElement> FindElementsByXPath(string locator)
    {
        return driver.FindElements(GetXpath(locator));
    }

    public void PressEnter(string locator)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(Keys.Enter);
            HtmlReport.Pass("Press enter on element [" + locator + "] passed");

        }
        catch (Exception)
        {
            HtmlReport.Fail("Press enter on element [" + locator + "] failed");
            throw;
        }
    }

    public IWebElement HighlightElement(IWebElement element)
    {
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
        return element;
    }


    public void Click(IWebElement e)
    {
        try
        {
            HighlightElement(e);
            e.Click();
            TestContext.WriteLine("click on element" + e.ToString() + "passed");
        }
        catch (Exception)
        {
            TestContext.WriteLine("click on element" + e.ToString() + "failed");
            throw;
        }
    }

    public void Click(string locator)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var btnClick = wait.Until(ExpectedConditions.ElementExists(GetXpath(locator)));
            HighlightElement(btnClick);
            btnClick.Click();
            TestContext.WriteLine("Click on element" + locator + "successfully");
            HtmlReport.Pass("Click on element" + locator + "successfully");

        }
        catch (Exception)
        {
            TestContext.WriteLine("Click on element" + locator + "unsuccessfully");
            HtmlReport.Fail("Click on element" + locator + "unsuccessfully", TakeScreenShot());
            throw;
        }
    }

    public void Click_(string locator)
    {
        // Use javascriptexecutor to avoid ClickInterceptedException
        try
        {
            IWebElement e = FindElementByXpath(locator);
            HighlightElement(e);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", e);
            TestContext.WriteLine("Click on element [" + locator + "] successfully");
            HtmlReport.Pass("Clicking on element [" + locator + "] passed");

        }
        catch (Exception)
        {
            HtmlReport.Fail("Clicking on element [" + locator + "] failed");
            throw;
        }
    }

    public void DoubleClick(IWebElement e)
    {
        try
        {
            WebDriverAction action = new(driver);
            HighlightElement(e);
            action.DoubleClick(e);
            HtmlReport.Pass("Double click on element " + e.ToString() + " successfuly");
        }
        catch (Exception)
        {
            HtmlReport.Fail("Double click on element " + e.ToString() + " failed with");
            throw;
        }
    }


    public static void SendKeys(IWebElement e, string key)
    {
        try
        {
            e.SendKeys(key);
            TestContext.WriteLine("Sendkey into element " + e.ToString() + " successfuly");
        }
        catch (Exception)
        {
            TestContext.WriteLine("Sendkey into element " + e.ToString() + " failed");
            throw;
        }
    }
    public void SendKeys_(string locator, string key)
    {
        try
        {
            FindElementByXpath(locator).SendKeys(key);
            TestContext.WriteLine("Sendkey into element" + locator + "passed");
            HtmlReport.Pass("Sendkey into element" + locator + "passed");
        }
        catch (Exception)
        {

            TestContext.WriteLine("Sendkey into element" + locator + "failed");
            HtmlReport.Fail("Sendkey into element" + locator + "failed", TakeScreenShot());
            throw;
        }
    }

    public void SelectOption(string locator, string key)
    {
        try
        {
            IWebElement mySelectOption = FindElementByXpath(locator);
            SelectElement dropdown = new(mySelectOption);
            dropdown.SelectByText(key);
            TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
        }
        catch (Exception)
        {
            TestContext.WriteLine("Select element " + locator + " failed with " + key);
            throw;
        }
    }

    public void Clear(string locator)
    {
        FindElementByXpath(locator).Clear();
        TestContext.WriteLine("Clear element " + locator + " successfully");
        HtmlReport.Pass("Clear element" + locator + "passed");
    }

    public void ReplaceKey(string locator, string key)
    {
        try
        {
            FindElementByXpath(locator).Clear();
            FindElementByXpath(locator).SendKeys(key);
            HtmlReport.Pass("Replace into element" + locator + "passed");
        }
        catch (Exception)
        {
            HtmlReport.Fail("Replace into element" + locator + "failed", TakeScreenShot());
            throw;
        }
    }

    public void ClosePopUp_(string locator)
    {
        try
        {
            //try to see if the pop up is open and visible for 15 seconds. If it is, click the Close button
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var popUpCloseButton = wait.Until(ExpectedConditions.ElementIsVisible(GetXpath(locator)));
            popUpCloseButton.Click();
            HtmlReport.Pass("Close Pop up successfully");
        }
        catch (Exception)
        {
            HtmlReport.Fail("Close Pop up unsuccessfully");
            throw;
        }
    }
    // ------------------------------- CAPTURE SCREENSHOT  -------------------------------

    public string TakeScreenShot()
    {
        // new version (Yes HtmlReporter)
        try
        {

            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" +
                DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; // Dynamic name
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            HtmlReport.Pass("Take screenshot successfully");
            return path;
        }
        catch (Exception)
        {
            HtmlReport.Fail("Take screenshot failed");
            throw;
        }
    }

    public void TakeScreenshotIf404()
    {
        if (driver.Title.Contains("404"))
        {
            TakeScreenShot();
            HtmlReport.Warning("Error 404 - Screenshot taken");
        }
        TakeScreenShot();
    }
    // ------------------------------- NAMING  -------------------------------
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
    // ------------------------------- VERIFYING  -------------------------------

    public bool IsElementDisplay(string locator)
    {
        IWebElement e = driver.FindElement(GetXpath(locator));

        if (e == null)
        {
            HtmlReport.Fail("Element is not displayed");
            return false;
        }
        else
        {
            HighlightElement(e);
            HtmlReport.Pass("Element [" + e.ToString() + "] is displayed", TakeScreenShot());
            return true;
        }
    }

    public bool IsPopUpDisplay(string locator)
    {
        IWebElement e = driver.FindElement(GetXpath(locator));

        if (e == null)
        {
            HtmlReport.Fail("Popup does not display");
            return false;
        }
        else
        {
            HighlightElement(e);
            HtmlReport.Pass("Popup displays", TakeScreenShot());
            return true;
        }
    }
}
