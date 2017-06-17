using Ninject;
using ProjectManager.Configs;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Common.Contracts;
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
            IKernel kernel = new StandardKernel(new NinjectManagerModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
