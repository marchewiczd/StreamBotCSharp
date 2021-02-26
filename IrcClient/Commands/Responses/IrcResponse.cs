using System;
using System.Linq;
using IrcClient.Commands.Enums;

namespace IrcClient.Commands.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// Most common response format: :<user>!<user>@<user>.<address> <CommandType> #<channel>
    /// </example>
    public class IrcResponse : IrcCommand
    {
        public string Username
        {
            get => this.UsernameLength == 0 ? string.Empty : this.RawData.Substring(1, this.UsernameLength);
            set => this.SetUsername(value);
        }

        private int UsernameLength => this.RawData.IndexOf("!", StringComparison.Ordinal) - 1;

        public IrcResponse() : base()
        {
            this.CommandTypeIndex = this.GetCommandTypeIndex();
        }

        public IrcResponse(string rawData) : base(rawData)
        {
            this.CommandTypeIndex = this.GetCommandTypeIndex();
        }        
        
        protected override void SetCommandType(CommandTypeEnum commandType)
        {
            CommandTypeEnum currentCommandType = this.GetCommandType();

            this.RawData = 
                currentCommandType.Equals(CommandTypeEnum.Unspecified) 
                    ? this.RawData.Insert(this.CommandTypeIndex, commandType.ToString()) 
                    : this.RawData.Replace(currentCommandType.ToString(), commandType.ToString());
        }

        private int GetCommandTypeIndex()
        {
            return this.RawData.IndexOf(this.RawData.First(x => x.Equals(char.ToUpper(x))));
        }

        private void SetUsername(string username)
        {
            // index values after substring removal
            const int firstUsernameEntryIndex = 1,
                      secondUsernameEntryIndex = 2,
                      thirdUsernameEntryIndex = 3;
            int currentUsernameLength = this.UsernameLength;

            if (currentUsernameLength == 0)
            {
                string prefixChars = this.RawData.Substring(0, 4);
                
                if (prefixChars.Equals(":!@."))
                {
                    this.RawData = this.RawData
                        .Insert(thirdUsernameEntryIndex, username)
                        .Insert(secondUsernameEntryIndex, username)
                        .Insert(firstUsernameEntryIndex, username);
                }
                else
                {
                    this.RawData = this.RawData.Insert(0, $":{username}!{username}@{username}.");
                }
            }
            else
            {
                this.RawData = this.RawData
                    .Remove(firstUsernameEntryIndex, currentUsernameLength)
                    .Remove(secondUsernameEntryIndex, currentUsernameLength)
                    .Remove(thirdUsernameEntryIndex, currentUsernameLength)
                    .Insert(thirdUsernameEntryIndex, username)
                    .Insert(secondUsernameEntryIndex, username)
                    .Insert(firstUsernameEntryIndex, username);
            }
        }
    }
}