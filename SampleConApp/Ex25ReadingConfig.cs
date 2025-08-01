

using Microsoft.Extensions.Configuration; // Already present
using Microsoft.Extensions.Configuration.Json; // Already present

using SampleConApp.OperatorOverloading;

namespace SampleConApp
{
    //.NET Core uses appsettings.json file to read the configuration settings. These settings can be read using the ConfigurationBuilder class.
    //The ConfigurationBuilder class is used to build a configuration object that can be used to read the settings from the appsettings.json file. It is used to read the settings using the GetSection method.
    //JSON is the prefered format of configuration settings in .NET Core applications. It is easy to read and write, and it is also easy to parse. The JSON format is also human-readable, which makes it easy to understand the configuration settings. It can be modified easily without the need to recompile the application. The contents of the file are read from the Application and then consumed.
    //Examples of appsettings could be file locations, connection strings, API keys, etc. These settings can be used to configure the application at runtime. The settings can be modified by the end user without the need to recompile the application. This makes it easy to change the settings without the need to redeploy the application.
    //Add the nuget package Microsoft.Extensions.Configuration.Json and Microsoft.Extensions.Configuration to the project to read the appsettings.json file. To work with POCO(Plain Old CLR object) classes, you can use the Microsoft.Extensions.Configuration.Binder package. This package provides the Bind method that can be used to bind the configuration settings to a class.
    //POCO Classes are simple classes that do not have any dependencies on the framework. They contain only properties and do not have any methods. They are used to represent the configuration settings in a strongly typed manner. This makes it easy to work with the configuration settings in a type-safe manner. 
    class ConfigReading
    {
        public static IConfigurationRoot AppConfig { get; private set; }
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Add the JSON file
                .Build(); // Build the configuration

            AppConfig = config; // Store the configuration in a static property for later use
            var appName = config["AppSettings:AppName"];
            var title = config["AppSettings:Title"];
            Console.WriteLine($"~~~~~~~~~~{appName.ToUpper()}~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"-------------------{title.ToUpper()}");
            Console.ReadLine();
     
            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings); // Bind the configuration to a class. Use Microsoft.Extensions.Configuration.Binder package. This is the widely used approach to read the configuration settings in a strongly typed manner.
            Console.WriteLine(appSettings.Title);
        }
    }

    class AppSettings
    {
        public string AppName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}