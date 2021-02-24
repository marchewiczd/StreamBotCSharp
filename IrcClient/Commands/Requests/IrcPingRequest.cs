namespace IrcClient.Commands.Requests
{
    public class IrcPingRequest : IrcRequest
    {
        public IrcPingRequest(string rawData) : base(rawData) {}
        
        public IrcPingRequest()
        {
            this.RawData = "PING :tmi.twitch.tv";
        }
    }
}