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
        SignUpPage signUpPage = homePage
            .ClickLoginButton()
            .ClickSignUpButton(user.Name, user.Email)
            .CreateAccountButton(user.Password);
        
        Thread.Sleep(5000);
        
    }
}