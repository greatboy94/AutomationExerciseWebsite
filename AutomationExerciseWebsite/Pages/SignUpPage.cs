using AutomationExerciseWebsite.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseWebsite.Pages;

public class SignUpPage : BasePage
{
    
    private readonly By loginForm = By.XPath("//div[@class='login-form']");
    private readonly By genderMr = By.Id("id_gender1");
    private readonly By passwordInput = By.Id("password");
    private readonly By birthDay = By.Id("days");
    private readonly By birthMonth = By.Id("months");
    private readonly By birthYears = By.Id("years");
    private readonly By newsLetter = By.Id("newsletter");
    private readonly By receiveOffers = By.XPath("//input[@name='optin']");
    private readonly By address1 = By.Id("address1");
    
    
    public SignUpPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(loginForm);
    }

    public SignUpPage CreateAccountButton(string password)
    {
        ClickToMr();
        EnterPassword(password);
        SelectDateOfBirth();
        ClickToNewsLetterAndReceiveOffers();

        return new SignUpPage(driver);
    }

    public void ClickToMr()
    {
        Click(genderMr);
        bool isSelected = driver.FindElement(genderMr).Selected;
    
        if (!isSelected)
        {
            throw new InvalidOperationException("The 'Mr' gender radio button was not selected after clicking.");
        }
    }

    public void EnterPassword(string password)
    {
        SendKeys(passwordInput, password);
    }

    public void SelectDateOfBirth()
    {
        SelectDropDownByValue(birthDay,"24");
        SelectDropDownByValue(birthMonth,"7");
        SelectDropDownByValue(birthYears,"1994");
    }

    public void ClickToNewsLetterAndReceiveOffers()
    {
        ScrollToElement(receiveOffers);
        Click(newsLetter);
        Click(receiveOffers);
        bool isSelectedLetter = driver.FindElement(newsLetter).Selected;
        bool isSelectedOffer = driver.FindElement(receiveOffers).Selected;
    
        if (!isSelectedLetter && !isSelectedOffer)
        {
            throw new InvalidOperationException("The News Letter and Receive Offer is not checked. ");
        }
        
    }
}