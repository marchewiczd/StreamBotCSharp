using IrcClient.Commands.Enums;

namespace IrcClient.Commands.Requests
{
    public class IrcRequest : IrcCommand
    {        
        public IrcRequest() : base()
        {
            this.CommandTypeIndex = 0;
        }

        public IrcRequest(string rawData) : base(rawData)
        {
            this.CommandTypeIndex = 0;
        }        
        
        protected override void SetCommandType(CommandTypeEnum commandType)
        {
            CommandTypeEnum currentCommandType = this.GetCommandType();
            
            if (currentCommandType.Equals(CommandTypeEnum.Unspecified))
            {
                this.RawData = this.RawData.Insert(this.CommandTypeIndex, commandType.ToString());
            }
            else
            {
                this.RawData = this.RawData.Replace(currentCommandType.ToString(), commandType.ToString());    
            }            
        }
    }
}