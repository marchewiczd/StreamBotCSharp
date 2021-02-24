using System;
using System.Collections.Generic;

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
        
        public CommandHandler(Dictionary<string, string> textCommands, Dictionary<string, Action> actionCommands)
        {
            this._textCommands = textCommands;
            this._actionCommands = actionCommands;
        }       
    }
}