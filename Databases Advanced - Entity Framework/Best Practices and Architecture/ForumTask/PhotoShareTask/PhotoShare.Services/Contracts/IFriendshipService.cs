namespace PhotoShare.Services.Contracts
{
    public interface IFriendshipService
    {
        string AcceptFriend(string username1, string username2);

        string AddFriend(string username, string friendUsername);
    }
}
