using System;
using System.Collections.Generic;
using System.Linq;
using IrcClient.Commands;
using IrcClient.Commands.Enums;
using IrcClient.Commands.Requests;
using IrcClient.Commands.Responses;
using StreamBotConfig.Configs;

namespace StreamBotCsharp.Handlers
{
    public class CommandHandler
    {
        /// <summary>
        /// Dictionary storing loaded text commands.
        /// Key: command, e.g. "!help"
        /// Value: text
        /// </summary>
        private readonly Dictionary<string, string> _textCommands;

        /// <summary>
        /// Dictionary storing loaded action commands.
        /// Key: command, e.g. "!help"
        /// Value: action with no parameters to be performed
        /// </summary>
        private readonly Dictionary<string, Action> _actionCommands;

        private Config _config;

        public CommandHandler(Dictionary<string, string> textCommands, Dictionary<string, Action> actionCommands)
        {
            this._textCommands = textCommands;
            this._actionCommands = actionCommands;
        }

        public CommandHandler(Config config)
        {
            this._config = config;
            this._textCommands = config.TextCommands.ToDictionary(x => x.Trigger, y => y.Answer);
        }


        public IrcCommand HandleUserCommands(IrcCommand command)
        {
            if (command == null)
            {
                return null;
            }

            if (command.CommandType == CommandTypeEnum.PRIVMSG)
            {
                IrcPrivmsgResponse privmsg = new IrcPrivmsgResponse(command.RawData);
                string message = privmsg.Message;

                if (this._textCommands.ContainsKey(message))
                {
                    return new IrcPrivmsgRequest(this._config.Credentials.Channel, this._textCommands[message]);
                }
            }

            return null;
        }
    }
}