namespace IrcClient.Commands.Requests
{
    public class IrcChannelRequest : IrcRequest
    {
        public IrcChannelRequest() : base()
        {            
        }

        public IrcChannelRequest(string rawData) : base(rawData)
        {
            this.RawData = rawData;
        }
    
        public string Channel 
        {
            get => this.RawData.Substring(this.ChannelIndex, this.ChannelStringLength);

            set =>
                this.RawData = this.RawData
                    .Remove(this.ChannelIndex, this.ChannelStringLength)
                    .Insert(this.PayloadIndex + 1, value);
        }
        
        public int ChannelIndex
        {
            get
            {
                return this.PayloadIndex + 1;
            }
        }

        protected int ChannelStringLength
        {
            get
            {
                int len = this.RawData.IndexOf(' ', this.ChannelIndex) - this.PayloadIndex - 1;
                
                if (len < 0)
                {
                    return this.RawData.Length - this.ChannelIndex;
                }

                return len;
            }
        }
    }
}