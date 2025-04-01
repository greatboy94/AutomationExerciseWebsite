using AutomationExerciseWebsite.Base;
using OpenQA.Selenium;

namespace AutomationExerciseWebsite.Pages;

public class LoginPage : BasePage
{
    private By loginHeader = By.ClassName("login-form");
    private By loginEmailInput = By.XPath("//input[@data-qa='login-email']");
    private By loginPasswordInput = By.XPath("//input[@data-qa='login-password']");
    
    private By signUpNameInput = By.XPath("//input[@data-qa='signup-name']");
    private By signUpEmailInput = By.XPath("//input[@data-qa='signup-email']");
    private By signUpButton = By.XPath("//button[@data-qa='signup-button']");
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(loginHeader) && 
               IsElementDisplayed(loginEmailInput) && 
               IsElementDisplayed(loginPasswordInput);
    }
    
    public SignUpPage ClickSignUpButton(string signUpName, string signUpEmail)
    {
        SendKeys(signUpNameInput, signUpName);
        SendKeys(signUpEmailInput, signUpEmail);
        Click(signUpButton);

        return new SignUpPage(driver);
    }
}