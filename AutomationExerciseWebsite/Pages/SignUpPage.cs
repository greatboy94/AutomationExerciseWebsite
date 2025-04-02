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
    private readonly By firstNameInput = By.Id("first_name");
    private readonly By lastNameInput = By.Id("last_name");
    private readonly By companyInput = By.Id("company");
    private readonly By address1input = By.Id("address1");
    private readonly By address2Input = By.Id("address2");
    private readonly By chooseCountry = By.Id("country");
    private readonly By stateInput = By.Id("state");
    private readonly By cityInput = By.Id("city");
    private readonly By zipcodeInput = By.Id("zipcode");
    private readonly By mobileNumberInput = By.Id("mobile_number");
    private readonly By createAccountButton = By.XPath("//button[@data-qa='create-account']");
    
    
    public SignUpPage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageLoaded()
    {
        return IsElementDisplayed(loginForm);
    }

    public SignUpPage CreateAccountWithCredentials(string password, string firstName, string lastName, string company, string address1, string address2, string state, string city, string zipcode, string mobileNumber)
    {
        ChooseGender();
        EnterPassword(password);
        SelectDateOfBirth();
        ClickToNewsLetterAndReceiveOffers();
        FillAddressForm(firstName, lastName, company, address1, address2, state, city, zipcode, mobileNumber);
        ClickToCreateAccountButton();

        return new SignUpPage(driver);
    }

    public void ChooseGender()
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

    public void FillAddressForm(string firstName, string lastName, string company, string address1, string address2, string state, string city, string zipcode, string mobileNumber)
    {
        SendKeys(firstNameInput, firstName);
        SendKeys(lastNameInput, lastName);
        SendKeys(companyInput, company);
        SendKeys(address1input, address1);
        SendKeys(address2Input, address2);
        SelectDropDownByValue(chooseCountry, "United States");
        SendKeys(stateInput, state);
        SendKeys(cityInput, city);
        SendKeys(zipcodeInput, zipcode);
        SendKeys(mobileNumberInput, mobileNumber);
        ScrollToElement(stateInput);
    }

    public void ClickToCreateAccountButton()
    {
        Click(createAccountButton);
    }
}