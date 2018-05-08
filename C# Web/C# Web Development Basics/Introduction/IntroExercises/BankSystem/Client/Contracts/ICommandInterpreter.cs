namespace BankSystem.Client.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string cmdName, string[] args);
    }
}
