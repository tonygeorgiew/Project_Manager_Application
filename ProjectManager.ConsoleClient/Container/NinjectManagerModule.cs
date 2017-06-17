using Ninject.Modules;
using ProjectManager.ConsoleClient.Container;
using ProjectManager.ConsoleClient.Contracts;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;


namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {

            //Engine and Factories
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();
            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();
            
            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<IReader>().To<Reader>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IValidator>().To<Validator>().InSingletonScope();


            //Commands
            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<ICommand>().To<CreateProjectCommand>().Named("CreateProject");
            this.Bind<ICommand>().To<CreateTaskCommand>().Named("CreateTask");
            this.Bind<ICommand>().To<CreateUserCommand>().Named("CreateUser");
            this.Bind<ICommand>().To<ListProjectsCommand>().Named("ListProjects");
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named("ListProjectDetails");

        }
    }
}
