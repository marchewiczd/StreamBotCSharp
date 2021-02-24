namespace IrcClient.Commands.Requests
{
    public class IrcPartRequest : IrcChannelRequest
    {
        public IrcPartRequest(string channel)
        {
            this.RawData = $"PART #{channel}";
        }
    }
}