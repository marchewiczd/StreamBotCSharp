using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using IrcClient.Commands;
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

        private Task _commandReaderTask;

        public IrcDataStream(StreamReader inputStream, StreamWriter outputStream)
        {
            this._inputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream));
            this._outputStream = outputStream ?? throw new ArgumentNullException(nameof(outputStream));

            this._commandReaderTask = Task.Factory.StartNew(this.ReadRequests);
        }
        
        public void SendRaw(string rawCommand)
        {
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
                if (_receivedCommands.Count <= 0)
                {
                    return null;
                }
                
                IrcCommand receivedCommand = this._receivedCommands[0];
                this._receivedCommands.RemoveAt(0);

                return receivedCommand;
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
                    this._receivedCommands.Add(new IrcCommand(rawData));
                    Console.WriteLine(rawData);
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