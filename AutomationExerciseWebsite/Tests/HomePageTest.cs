using AutomationExerciseWebsite.Base;
using AutomationExerciseWebsite.Models;
using AutomationExerciseWebsite.Pages;
using AutomationExerciseWebsite.TestData;
using NUnit.Framework;

namespace AutomationExerciseWebsite.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class HomePageTest : BaseTest
{
    [Test]
    [TestCaseSource(typeof(TestDataJsonReader), nameof(TestDataJsonReader.GetValidLoginTestData))]
    public void NavigateToHomePage(UserModel user)
    {
        HomePage homePage = new HomePage(GetDriver());
        Assert.That(homePage.IsPageLoaded, Is.True, "Home page was not loaded");
        
        homePage.ClickLoginButton();
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.ClickSignUpButton(user.Name, user.Email);
        
        Assert.That(loginPage.IsPageLoaded, Is.True, "Login page was not loaded");
    }
}