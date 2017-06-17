using Ninject.Modules;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();

            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<IReader>().To<Reader>().InSingletonScope(); 
        }
    }
}
