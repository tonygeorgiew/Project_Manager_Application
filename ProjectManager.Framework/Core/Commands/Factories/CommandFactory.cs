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
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceLocator serviceLocator;
        public CommandFactory(IServiceLocator serviceLocator)
        {
            Guard.WhenArgument(serviceLocator, "serviceLocator").IsNull().Throw();

            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            Guard.WhenArgument(commandName, "commandName").IsNull().Throw();

            try
            {
                return this.serviceLocator.GetCommand(commandName);
            }

            catch
            {
                throw new UserValidationException("Command not found!");
            }
        }
    }
}
