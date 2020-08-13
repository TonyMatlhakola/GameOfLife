using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameOfLife.Uitls
{
    public static class ConfigurationSettings
    {
        public static ConfigurationSeetingsDto GetConfiurationSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var settings = new ConfigurationSeetingsDto
            {
                Heigth = Convert.ToInt32(configuration["GameOfLifeSettings:Heigth"]),
                Width = Convert.ToInt32(configuration["GameOfLifeSettings:Width"]),
                MaxRuns = Convert.ToUInt32(configuration["GameOfLifeSettings:NumberOfGenerations"]),
                SleepTime = Convert.ToInt32(configuration["GameOfLifeSettings:SleepTime"])
            };
            return settings;

        }
    }

    public class ConfigurationSeetingsDto
    {

        public int Heigth;
        public int Width;
        public uint MaxRuns;
        public int SleepTime;

    }
}
