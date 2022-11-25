using OpenQA.Selenium;

namespace Core_Framework.DriverCore;

internal class WebDriverManager
{
    private static readonly AsyncLocal<IWebDriver> driver = new();

    public static void InitDriver(string Browser, int Width, int Height)
    {
        IWebDriver newDriver = WebDriverCreator.CreateLocalDriver(Browser, Width, Height);


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
