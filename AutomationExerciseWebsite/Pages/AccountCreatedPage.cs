using AutomationExerciseWebsite.Base;
using OpenQA.Selenium;

namespace AutomationExerciseWebsite.Pages;

public class AccountCreatedPage : BasePage
{
    
    private readonly By accountCreatedText = By.XPath("//h2[@data-qa='account-created']");
    
    public AccountCreatedPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(accountCreatedText);
    }

    public string GetAccountCreatedText()
    {
        return GetText(accountCreatedText);
    }
}