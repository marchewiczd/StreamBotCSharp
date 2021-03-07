namespace IrcClient.Commands.Responses
{
    public class IrcPrivmsgResponse : IrcResponse
    {
        public IrcPrivmsgResponse(string rawData) : base(rawData)
        {
        }
        
        public string Message
        {
            get => this.RawData[this.MessageIndex..];

            set
            {
                this.RawData = this.RawData.Remove(this.MessageIndex).Insert(this.MessageIndex, value);
            }
        }
        
        public int MessageIndex => this.ChannelIndex + this.ChannelStringLength + 2;
    }
}