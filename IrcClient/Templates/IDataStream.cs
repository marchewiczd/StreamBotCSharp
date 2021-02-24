using System.Collections.Generic;
using IrcClient.Commands;
using IrcClient.Commands.Enums;

namespace IrcClient.Templates
{
    public interface IDataStream
    {
        public void SendRaw(string rawCommand);

        public void SendResponse(IrcCommand command);

        public IEnumerable<IrcCommand> ReadRequests();
    }
}