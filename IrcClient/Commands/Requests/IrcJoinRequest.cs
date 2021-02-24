namespace IrcClient.Commands.Requests
{
    public class IrcJoinRequest : IrcChannelRequest
    {
        public IrcJoinRequest(string channel)
        {
            this.RawData = $"JOIN #{channel}";
        }
    }
}