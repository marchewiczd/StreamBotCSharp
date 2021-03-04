using System;
using System.Collections.Specialized;
using IrcClient.Commands;
using IrcClient.Commands.Requests;
using IrcClient.Connection;
using IrcClient.DataStream;

namespace IrcClient
{
    public class IrcClient
    {
        private string _address;
        private int _port;
        private string _nick;
        private string _channel;
        private string _oauth;
        private Func<IrcCommand, IrcCommand> _clientActionMethod;
        private IrcDataStream _dataStream;

        public IrcClient(string address, int port, string nick, string channel, string oauth, Func<IrcCommand, IrcCommand> clientActionMethod)
        {
            this._address = address;
            this._port = port;
            this._nick = nick;
            this._channel = channel;
            this._oauth = oauth;
            this._clientActionMethod = clientActionMethod;
        }

        public void Start()
        {
            using (var serverConnection = new TcpIpServerConnection(this._address, this._port))
            using (this._dataStream =
                new IrcDataStream(serverConnection.GetInputStream(), serverConnection.GetOutputStream()))
            {
                this._dataStream.AddCollectionChangedHandler(this.ReceivedNewCommandEventHandler);
                this.Login();

                char key;
                do
                {
                    key = Console.ReadKey().KeyChar;
                } while (key != 'x' && key != 'X');
            }
        }

        public void SetClientActionMethod(Func<IrcCommand, IrcCommand> ircClientAction)
        {
            this._clientActionMethod = ircClientAction;
        }

        public void ReceivedNewCommandEventHandler(object obj, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add)
            {
                return;
            }

            IrcCommand receivedCommand = this._dataStream.GetReceivedCommand();
            if (receivedCommand == null) return;
            IrcCommand response = this._clientActionMethod.Invoke(receivedCommand);
            if (response != null)
            {
                this._dataStream.SendCommand(response);
            }
        }

        private void Login()
        {
            this._dataStream.SendRequest(new IrcPassRequest(this._oauth));
            this._dataStream.SendRequest(new IrcNickRequest(this._nick));
            this._dataStream.SendRequest(new IrcJoinRequest(this._channel));
            this._dataStream.SendRequest(new IrcPrivmsgRequest(this._channel, "Hello there!"));
        }
    }
}