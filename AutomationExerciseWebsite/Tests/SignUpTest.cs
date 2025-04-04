using AutomationExerciseWebsite.Base;
using AutomationExerciseWebsite.Models;
using AutomationExerciseWebsite.Pages;
using AutomationExerciseWebsite.TestData;
using NUnit.Framework;

namespace AutomationExerciseWebsite.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class SignUpTest : BaseTest
{
    private const string ExpectedAccountCreatedText = "ACCOUNT CREATED!";
    
    [Test]
    [TestCaseSource(typeof(TestDataJsonReader), nameof(TestDataJsonReader.GetSignUpUserData))]
    public void SignUp_WithValidUser(UserModel user)
    {

        HomePage homePage = new HomePage(GetDriver());
        SignUpPage signUpPage = homePage
            .ClickLoginButton()
            .ClickSignUpButton(user.Name, user.Email)
            .CreateAccountWithCredentials(user.Password, user.FirstName, user.LastName, user.Company, user.Address1, user.Address2, user.City, user.State, user.Zipcode, user.MobileNumber);

        AccountCreatedPage accountCreatedPage = new AccountCreatedPage(GetDriver());
        Assert.That(accountCreatedPage.GetAccountCreatedText(), Is.EqualTo(ExpectedAccountCreatedText), "Account not created");
        
    }
}