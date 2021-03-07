using System.IO;
using System.Net.Sockets;
using IrcClient.Interfaces;

namespace IrcClient.Connection
{
    public class TcpIpServerConnection : IServerConnection
    {
        private TcpClient _tcpClient;

        private string _address;

        private int _port;

        public TcpIpServerConnection(string address, int port)
        {
            this._address = address;
            this._port = port;
            this._tcpClient = new TcpClient(address, port);
        }
        
        public bool Connect()
        {
            if (!this._tcpClient.Connected)
            {
                this._tcpClient.Connect(this._address, this._port);
            }

            return true;
        }

        public StreamReader GetInputStream()
        {
            return this._tcpClient is {Connected: true} ? new StreamReader(this._tcpClient.GetStream()) : null;
        }

        public StreamWriter GetOutputStream()
        {
            return this._tcpClient is {Connected: true} ? new StreamWriter(this._tcpClient.GetStream()) : null;
        }
        
        public void Dispose()
        {
            this._tcpClient.Close();
        }
    }
}