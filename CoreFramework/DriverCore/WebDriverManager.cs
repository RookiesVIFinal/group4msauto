using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace CoreFramework.DriverCore;

public class WebDriverManager
{
    private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();
    public static IWebDriver? CreateLocalDriver(string Browser,
    int ScreenWidth, int ScreenHeight)
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
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHeight);
        return Driver;
    }

    public static void InitDriver(string Browser, int Width, int Height)
    {

        IWebDriver newDriver = CreateLocalDriver
            (Browser, Width, Height);

        if (newDriver == null)
            throw new Exception($"{Browser} browser is not supported");
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
