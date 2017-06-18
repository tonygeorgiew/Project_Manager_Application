﻿using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.ConsoleClient.Container;
using ProjectManager.ConsoleClient.Contracts;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateUserInternalName = "CreateUserInternal";
        private const string CreateProjectInternalName = "CreateProjectInternal";
        private const string CreateTaskInternalName = "CreateTaskInternal";
        private const string ListProjectDetailsInternalName = "ListProjectDetailsInternal";
        private const string ListProjectsInternalName = "ListProjectsInternal";

        private const string CacheableCommandName = "CacheableCommand";

        private const string CreateUserName = "CreateUser";
        private const string CreateProjectName = "CreateProject";
        private const string CreateTaskName = "CreateTask";
        private const string ListProjectDetailsName = "ListProjectDetails";
        private const string ListProjectsName = "ListProjects";

        public override void Load()
        {
            // Engine
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IValidator>().To<Validator>().InSingletonScope();

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            

            this.Bind<ICachingService>().To<CachingService>().InSingletonScope()
                .WithConstructorArgument(configurationProvider.CacheDurationInSeconds);

            this.Bind<IReader>().To<Reader>().InSingletonScope();
            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<ILogger>().To<FileLogger>().InSingletonScope()
                .WithConstructorArgument(configurationProvider.LogFilePath);

            var cmdProcessor = this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            cmdProcessor.Intercept().With<LogErrorInterceptor>();
            cmdProcessor.Intercept().With<InfoInterceptor>();

            // Models Factory
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();


            // Command Factory
            this.Bind<IServiceLocator>().To<ServiceLocator>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserInternalName);
            this.Bind<ICommand>().To<CreateProjectCommand>().Named(CreateProjectInternalName);
            this.Bind<ICommand>().To<CreateTaskCommand>().Named(CreateTaskInternalName);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(ListProjectDetailsInternalName);
            this.Bind<ICommand>().To<ListProjectsCommand>().Named(ListProjectsInternalName);

            this.Bind<ICommand>().To<CacheableCommand>().Named(CacheableCommandName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectsInternalName));

            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateUserName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateUserInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateProjectName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateProjectInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateTaskName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateTaskInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectDetailsName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectDetailsInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectsName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CacheableCommandName));
        }
    }
}
