using AutomationExerciseWebsite.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseWebsite.Pages;

public class SignUpPage : BasePage
{
    
    private By loginForm = By.XPath("//div[@class='login-form']");
    private By genderMr = By.Id("id_gender1");
    private By passwordInput = By.Id("password");
    private By birthDay = By.Id("days");
    private By birthMonth = By.Id("months");
    private By birthYears = By.Id("years");
    
    
    public SignUpPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(loginForm);
    }

    public void CreateAccountButton(string password)
    {
        Click(genderMr);
        SendKeys(passwordInput, password);
        SelectDropDownByValue(birthDay,"24");
        SelectDropDownByValue(birthMonth,"7");
        SelectDropDownByValue(birthYears,"1994");
    }
}