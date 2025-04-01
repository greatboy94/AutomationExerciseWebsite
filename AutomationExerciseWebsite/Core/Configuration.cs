using Microsoft.Extensions.Configuration;

namespace AutomationExerciseWebsite.Core;

public static class Configuration
{
    private static IConfiguration config;

    static Configuration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        config = builder.Build();
    }

    public static string BaseUrl => config["AppSettings:BaseUrl"];
    public static string Browser => config["AppSettings:Browser"];
    public static bool Headless => bool.Parse(config["AppSettings:Headless"]);
    public static string Username => config["Credentials:Username"];
    public static string Password => config["Credentials:Password"];
    public static string ReportPath => config["ReportSettings:Path"];
}