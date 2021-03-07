namespace IrcClient.Commands.Requests
{
    public class IrcPassRequest : IrcRequest
    {
        public IrcPassRequest(string oauthPass)
        {
            this.RawData = $"PASS {oauthPass}";
        }
    }
}