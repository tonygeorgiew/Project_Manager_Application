namespace ProjectManager.Framework.Core.Commands.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommandFromString(string commandName);
    }
}
