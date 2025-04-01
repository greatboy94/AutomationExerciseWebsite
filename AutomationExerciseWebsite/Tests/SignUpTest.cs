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
    [Test]
    [TestCaseSource(typeof(TestDataJsonReader), nameof(TestDataJsonReader.GetSignUpUserData))]
    public void SignUp_WithValidUser(UserModel user)
    {
        HomePage homePage = new HomePage(GetDriver());
        //Assert.That(homePage.IsPageLoaded, Is.True, "Home page was not loaded");
        
        homePage.ClickLoginButton();
        SignUpPage signUpPage = new SignUpPage(GetDriver());
        //Assert.That(signUpPage.IsPageLoaded, Is.True, "Sign up page was not loaded");
        
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.ClickSignUpButton(user.Name, user.Email);
        //Assert.That(signUpPage.IsPageLoaded, Is.True, "Sign up page was not loaded");
        
        signUpPage.CreateAccountButton(user.Password);
        
        Assert.Multiple(() =>
        {
            Assert.That(homePage.IsPageLoaded, Is.True, "Home page was not loaded");
            Assert.That(signUpPage.IsPageLoaded, Is.True, "Sign up page was not loaded");
        });
        
        Thread.Sleep(5000);
        
    }
}