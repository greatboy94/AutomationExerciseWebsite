using AutomationExerciseWebsite.Models;
using Newtonsoft.Json.Linq;

namespace AutomationExerciseWebsite.TestData;

public class TestDataJsonReader
{
    public static IEnumerable<object[]> GetValidLoginTestData()
    {
        // Read test data from JSON file using provided file path ####-> Make sure testData.json file properties set to "Copy always" <-####
        JObject testData = ReadTestData("TestData\\testData.json");
        var validLoginData = testData["LoginData"]["ValidCredentials"];

        foreach (var item in validLoginData)
        {
            yield return new object[]
            {
                new UserModel
                {
                    Email = item["Username"].ToString(),
                    Password = item["Password"].ToString()
                }
            };
        }
    }
    
    public static IEnumerable<object[]> GetInvalidLoginTestData()
    {
        // Read test data from JSON file using provided file path ####-> Make sure testData.json file properties set to "Copy always" <-####
        JObject testData = ReadTestData("TestData\\testData.json");

        // Extract username and password combinations for invalid login
        var invalidLoginData = testData["LoginData"]["InvalidCredentials"];

        foreach (var item in invalidLoginData)
        {
            yield return new object[]
            {
                new UserModel
                {
                    Email = item["Username"].ToString(),
                    Password = item["Password"].ToString()
                }
            };
        }
    }
    
    public static IEnumerable<object[]> GetSignUpUserData()
    {
        // Read test data from JSON file using provided file path ####-> Make sure testData.json file properties set to "Copy always" <-####
        JObject testData = ReadTestData("TestData\\testData.json");

        // Extract username and password combinations for invalid login
        var userDaniel = testData["SignUpData"]["UserDaniel"];

        foreach (var item in userDaniel)
        {
            yield return new object[]
            {
                new UserModel
                {
                    Name = item["Name"].ToString(),
                    Email = item["Email"].ToString(),
                    Password = item["Password"].ToString()
                }
            };
        }
    }

    private static JObject ReadTestData(string filePath)
    {
        // Combine base directory with relative path to get full path
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

        // Read JSON file
        string jsonContent = File.ReadAllText(fullPath);

        // Parse JSON content
        JObject testData = JObject.Parse(jsonContent);

        return testData;
    }
}