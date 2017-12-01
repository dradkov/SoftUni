namespace Employee.Client.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
