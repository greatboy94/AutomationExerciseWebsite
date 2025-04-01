using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExerciseWebsite.Core;

public static class WebDriverExtensions
{
    public static void WaitForElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public static void WaitForElementClickable(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public static bool IsElementPresent(this IWebDriver driver, By locator)
    {
        try
        {
            driver.FindElement(locator);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public static void JavaScriptClick(this IWebDriver driver, IWebElement element)
    {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
    }
}