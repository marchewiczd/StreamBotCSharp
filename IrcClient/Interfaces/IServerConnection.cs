using System;
using System.IO;

namespace IrcClient.Interfaces
{
    public interface IServerConnection : IDisposable
    {
        public bool Connect();

        public StreamReader GetInputStream();

        public StreamWriter GetOutputStream();
    }
}