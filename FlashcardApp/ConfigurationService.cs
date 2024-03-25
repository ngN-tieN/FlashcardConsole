using System;
using Microsoft.Extensions.Configuration;

internal class ConfigurationService
{
    public static string GetSqlConnectionString(string rdbms)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        IConfigurationSection section = config.GetSection("Database");
        return section[rdbms]; //Posible NULL, need checking 
    }



}