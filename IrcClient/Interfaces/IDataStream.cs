using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IrcClient.Commands;
using IrcClient.Commands.Requests;
using IrcClient.Commands.Responses;

namespace IrcClient.Interfaces
{
    public interface IDataStream : IDisposable
    {
        public void SendRaw(string rawCommand);

        public void SendResponse(IrcResponse command);
        
        public void SendRequest(IrcRequest command);

        public IrcCommand GetReceivedCommand();
    }
}