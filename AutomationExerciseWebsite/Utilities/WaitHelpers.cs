using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExerciseWebsite.Utilities;

public static class WaitHelpers
{
    public static void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds = 30)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }

    public static void WaitForAjax(IWebDriver driver, int timeoutInSeconds = 30)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            
        wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript(
            "return (typeof jQuery != 'undefined') ? jQuery.active == 0 : true"));
    }

    public static void WaitForElementToDisappear(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }

    public static void WaitForTextToBePresentInElement(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
    }
}