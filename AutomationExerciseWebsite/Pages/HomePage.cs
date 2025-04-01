using AutomationExerciseWebsite.Base;
using OpenQA.Selenium;

namespace AutomationExerciseWebsite.Pages;

public class HomePage : BasePage
{
    private readonly By descriptionText = By.XPath("(//div[@class='carousel-inner'])[1]//h2");
    private readonly By loginButton = By.XPath("//a[@href='/login']");
    
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(descriptionText);
    }

    public LoginPage ClickLoginButton()
    {
        Click(loginButton);

        return new LoginPage(driver);
    }
}