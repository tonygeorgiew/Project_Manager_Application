﻿using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Services;

namespace ProjectManager.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var configProvider = new ConfigurationProvider();

            var fileLogger = new FileLogger(configProvider.LogFilePath);

            var engine = new Engine(fileLogger);

            engine.Start();
        }
    }
}