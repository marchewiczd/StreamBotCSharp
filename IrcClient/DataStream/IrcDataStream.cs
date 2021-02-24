using System.Collections.Generic;
using IrcClient.Commands;
using IrcClient.Templates;

namespace IrcClient.DataStream
{
    public class IrcDataStream : IDataStream
    {
        public void SendRaw(string rawCommand)
        {
            throw new System.NotImplementedException();
        }

        public void SendResponse(IrcCommand command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IrcCommand> ReadRequests()
        {
            throw new System.NotImplementedException();
        }
    }
}