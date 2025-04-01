
using AutomationExerciseWebsite.Core;
using AutomationExerciseWebsite.TestData;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseWebsite.Base;

public abstract class BaseTest
{
    public ThreadLocal<IWebDriver> driver = new();
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // This runs once before all tests in the class
    }

    [SetUp]
    public void Setup()
    {
        // Initialize browser
        driver.Value = BrowserFactory.GetDriver(Configuration.Browser, Configuration.Headless);
    }
    
    public IWebDriver GetDriver()
    {
        return driver.Value;
    }
    
    public static TestDataJsonReader GetDataParser()
    {
        return new TestDataJsonReader();
    }

    [TearDown]
    public void TearDown()
    {
        // Close browser
        driver.Value?.Quit();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // This runs once after all tests in the class
    }
}