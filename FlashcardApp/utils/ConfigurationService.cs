using System;
using Microsoft.Extensions.Configuration;

internal class ConfigurationService
{
    public static string GetSqlConnectionString(string rdbms)
    {
        
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("D:\\FlashcardProjects\\FlashcardApp\\appsettings.json")
                .Build();

            IConfigurationSection section = config.GetSection("Database");
            return section[rdbms];
        
        
    }



}