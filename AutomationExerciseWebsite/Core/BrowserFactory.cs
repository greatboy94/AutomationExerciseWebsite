using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationExerciseWebsite.Core;

public class BrowserFactory
{
    public static IWebDriver GetDriver(string browserType, bool headless = false)
    {
        IWebDriver driver = browserType.ToLower() switch
        {
            "chrome" => CreateChromeDriver(headless),
            "firefox" => CreateFirefoxDriver(headless),
            "edge" => CreateEdgeDriver(headless),
            _ => CreateChromeDriver(headless) // Default to Chrome
        };

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl($"{Configuration.BaseUrl}");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return driver;
    }

    private static IWebDriver CreateChromeDriver(bool headless)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        if (headless) options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");
        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefoxDriver(bool headless)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new FirefoxOptions();
        if (headless) options.AddArgument("--headless");
        return new FirefoxDriver(options);
    }

    private static IWebDriver CreateEdgeDriver(bool headless)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new EdgeOptions();
        if (headless) options.AddArgument("--headless");
        return new EdgeDriver(options);
    }
}