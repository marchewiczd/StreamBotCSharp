using System.Runtime.CompilerServices;

namespace IrcClient.Commands.Requests
{
    public class IrcPrivmsgRequest : IrcChannelRequest
    {
        public IrcPrivmsgRequest(string channel, string message)
        {
            this.RawData = $"PRIVMSG #{channel} :{message}";
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