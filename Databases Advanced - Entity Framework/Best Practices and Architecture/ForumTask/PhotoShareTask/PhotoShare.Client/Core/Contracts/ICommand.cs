namespace PhotoShare.Client.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string command, params string[] arguments);

    }
}
