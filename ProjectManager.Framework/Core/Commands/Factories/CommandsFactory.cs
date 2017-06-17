using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Providers;
using Bytes2you.Validation;
using ProjectManager.ConsoleClient.Contracts;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandsFactory(IServiceLocator serviceLocator)
        {
            Guard.WhenArgument(serviceLocator, "serviceLocator").IsNull().Throw();

            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            Guard.WhenArgument(commandName, "commandName").IsNull().Throw();

            return this.serviceLocator.GetCommand(commandName);
        }
    }
}
