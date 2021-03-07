using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IrcClient.Commands;
using IrcClient.Commands.Enums;
using IrcClient.Commands.Requests;
using IrcClient.Commands.Responses;
using IrcClient.Interfaces;

namespace IrcClient.DataStream
{
    public class IrcDataStream : IDataStream
    {
        private ObservableCollection<IrcCommand> _receivedCommands = new();

        private StreamReader _inputStream;

        private StreamWriter _outputStream;

        private bool _keepReadingInput = false;

        private object _receivedCommandsLock = new();

        public IrcDataStream(StreamReader inputStream, StreamWriter outputStream)
        {
            this._inputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream));
            this._outputStream = outputStream ?? throw new ArgumentNullException(nameof(outputStream));

            Task.Factory.StartNew(this.ReadRequests);
        }

        public void SendRaw(string rawCommand)
        {
            if (!rawCommand.Contains(CommandTypeEnum.PASS.ToString()))
            {
                Console.WriteLine(rawCommand);
            }

            this._outputStream.WriteLine(rawCommand);
            this._outputStream.Flush();
        }

        public void SendResponse(IrcResponse command)
        {
            this.SendRaw(command.RawData);
        }

        public void SendRequest(IrcRequest command)
        {
            this.SendRaw(command.RawData);
        }

        public void SendCommand(IrcCommand command)
        {
            this.SendRaw(command.RawData);
        }

        public IrcCommand GetReceivedCommand()
        {
            lock (this._receivedCommandsLock)
            {
                if (!this._receivedCommands.Any())
                {
                    return null;
                }

                IrcCommand receivedCommand = this._receivedCommands[0];
                this._receivedCommands.RemoveAt(0);

                return receivedCommand;
            }
        }

        public bool ContainsUnprocessedCommands()
        {
            lock (this._receivedCommandsLock)
            {
                return this._receivedCommands.Any();
            }
        }

        public void AddCollectionChangedHandler(NotifyCollectionChangedEventHandler eventHandler)
        {
            lock (this._receivedCommandsLock)
            {
                this._receivedCommands.CollectionChanged += eventHandler;
            }
        }

        public void ReadRequests()
        {
            this._keepReadingInput = true;

            while (this._keepReadingInput)
            {
                string rawData = this._inputStream.ReadLine();

                lock (this._receivedCommandsLock)
                {
                    Console.WriteLine(rawData);
                    this._receivedCommands.Add(new IrcCommand(rawData));
                }
            }
        }

        public void Dispose()
        {
            this._keepReadingInput = false;
            this._inputStream.Close();
            this._outputStream.Close();
        }
    }
}