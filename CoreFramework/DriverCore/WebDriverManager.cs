using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace CoreFramework.DriverCore;

public class WebDriverManager
{
    private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();
    public static IWebDriver? CreateLocalDriver(string browser,
    int? screenWidth = null, int? screenHeight = null)
    {
        IWebDriver? Driver = null;
        if (browser.SequenceEqual("firefox"))
        {
            Driver = new FirefoxDriver();
        }
        else if (browser.SequenceEqual("chrome"))
        {
            Driver = new ChromeDriver();
        }
        else if (browser.SequenceEqual("safari"))
        {
            Driver = new SafariDriver();
        }
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        if (screenHeight != null & screenWidth != null)
        {
            Driver.Manage().Window.Size = new Size(screenWidth ?? 1920, screenHeight ?? 1080);
        }
        return Driver;
    }

    public static void InitDriver(string browser, int? width = null, int? height = null)
    {

        IWebDriver newDriver = CreateLocalDriver
            (browser, width, height);

        if (newDriver == null)
            throw new Exception($"{browser} Browser is not supported");
        driver.Value = newDriver;

    }
    public static IWebDriver GetCurrentDriver()
    {
        return driver.Value;
    }
    public static void CloseDriver()
    {
        if (driver.Value != null)
        {
            driver.Value.Quit();
            driver.Value.Dispose();
        }
    }
}

