namespace IrcClient.Commands.Requests
{
    public class IrcNickRequest : IrcRequest
    {
        public IrcNickRequest(string username)
        {
            this.RawData = $"NICK #{username}";
        }
    }
}