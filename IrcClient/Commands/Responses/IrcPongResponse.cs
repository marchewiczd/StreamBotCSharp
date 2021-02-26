namespace IrcClient.Commands.Responses
{
    public class IrcPongResponse : IrcResponse
    {
        public IrcPongResponse(string rawData) : base(rawData) {}
        
        public IrcPongResponse()
        {
            this.RawData = "PONG :tmi.twitch.tv";
        }
    }
}