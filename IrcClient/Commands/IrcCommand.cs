using System;
using System.Collections.Generic;
using System.Linq;
using IrcClient.Commands.Enums;

namespace IrcClient.Commands
{
    public abstract class IrcCommand
    {
        #region Constructors
        
        public IrcCommand()
        {
            this.RawData = "";
        }

        public IrcCommand(string rawData)
        {
            this.RawData = rawData;
        }

        #endregion
        
        #region Properties
        
        public string RawData { get; protected set; }
        
        public int CommandTypeIndex { get; protected set; }

        public CommandTypeEnum CommandType
        {
            get => this.GetCommandType();
            set => this.SetCommandType(value);
        }
        
        public int PayloadIndex
        {
            get
            {
                if (this.RawData.Equals(string.Empty) && this.CommandType.Equals(CommandTypeEnum.Unspecified))
                {
                    return 0;
                }

                if (this.CommandType.Equals(CommandTypeEnum.Unspecified))
                {
                    return 1;
                }
            
                return this.CommandTypeIndex + this.CommandType.ToString().Length + 1;
            }
        }

        public string Payload
        {
            get => this.PayloadIndex == 0 ? string.Empty : this.RawData[this.PayloadIndex..];

            set
            {
                if (this.PayloadIndex == 0 && this.RawData.Equals(string.Empty))
                {
                    this.RawData = $" {value}";
                }
                
                this.RawData = this.RawData.Remove(this.PayloadIndex).Insert(this.PayloadIndex, value);
            }
        }

        #endregion

        #region Methods

        protected CommandTypeEnum GetCommandType()
        {
            string foundType = this.RawData.Split(' ').First(x => x.Equals(x.ToUpper()));            
            return foundType.Equals(string.Empty) ? CommandTypeEnum.Unspecified : Enum.Parse<CommandTypeEnum>(foundType);
        }
        
        protected abstract void SetCommandType(CommandTypeEnum commandType);

        #endregion        
    }
}