using AutomationExerciseWebsite.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseWebsite.Base;

public abstract class BasePage
{
    protected readonly IWebDriver driver;
    protected readonly WebDriverWait wait;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    public abstract bool IsPageLoaded();

    protected void SendKeys(By locator, string text)
    {
        var element = driver.FindElement(locator);
        element.Clear();
        element.SendKeys(text);
    }
    
    protected void Click(By locator)
    {
        driver.WaitForElementClickable(locator);
        driver.FindElement(locator).Click();
    }

    protected string GetText(By locator)
    {
        driver.WaitForElementVisible(locator);
        return driver.FindElement(locator).Text;
    }

    protected bool IsElementDisplayed(By locator, int timeoutInSeconds = 5)
    {
        try
        {
            driver.WaitForElementVisible(locator, timeoutInSeconds);
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected void SelectDropDownByValue(By locator, string optionValue)
    {
        driver.WaitForElementClickable(locator, 5);
        var dropDown= driver.FindElement(locator);
        new SelectElement(dropDown).SelectByValue(optionValue);
    }
    
    protected void SelectDropDownByText(By locator, string optionText)
    {
        driver.WaitForElementClickable(locator, 5);
        var dropDown= driver.FindElement(locator);
        new SelectElement(dropDown).SelectByText(optionText);
    }
    
    protected void SelectDropDownByIndex(By locator, int optionIndex)
    {
        driver.WaitForElementClickable(locator, 5);
        var dropDown= driver.FindElement(locator);
        new SelectElement(dropDown).SelectByIndex(optionIndex);
    }
}