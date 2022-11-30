using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Drawing;

namespace CoreFramework.DriverCore;

public class WebDriverManager
{
    private static readonly AsyncLocal<IWebDriver> _driver = new();
    public static IWebDriver CreateLocalDriver(string Browser, int Width, int Height)
    {
        IWebDriver? Driver = null;
        if (Browser.SequenceEqual("firefox"))
        {
            Driver = new FirefoxDriver();
        }
        else if (Browser.SequenceEqual("chrome"))
        {
            Driver = new ChromeDriver();
        }
        else if (Browser.SequenceEqual("safari"))
        {
            Driver = new SafariDriver();
        }
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        Driver.Manage().Window.Size = new Size(Width, Height);
        return Driver;
    }

    public static void InitDriver(string Browser, int Width, int Height)
    {

        IWebDriver newDriver = CreateLocalDriver
            (Browser, Width, Height);

        if (newDriver == null)
            throw new Exception($"{Browser} browser is not supported");
        _driver.Value = newDriver;

    }

    public static IWebDriver GetCurrentDriver()
    {
        return _driver.Value;
    }

    public static void CloseDriver()
    {
        if (_driver.Value != null)
        {
            _driver.Value.Quit();
            _driver.Value.Dispose();
        }
    }

}
