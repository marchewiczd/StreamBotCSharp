using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using IrcClient.Commands.Responses;

namespace IrcClient
{
    public class IrcClient
    {
        public string userName;
                private string channel;
        
                private TcpClient _tcpClient;
                private StreamReader _inputStream;
                private StreamWriter _outputStream;
        
                public IrcClient(string ip, int port, string userName, string password, string channel)
                {
                    try
                    {
                        this.userName = userName;
                        this.channel = channel;
        
                        _tcpClient = new TcpClient(ip, port);
                        _inputStream = new StreamReader(_tcpClient.GetStream());
                        _outputStream = new StreamWriter(_tcpClient.GetStream());
        
                        // Try to join the room
                        // _outputStream.WriteLine("PASS " + password);
                        // _outputStream.Flush();
                        // _outputStream.WriteLine("NICK " + userName);
                        // _outputStream.Flush();
                        // _outputStream.WriteLine("JOIN #" + channel);
                        // _outputStream.Flush();

                        Task readTask = Task.Factory.StartNew(this.ReadMessage);
                        Task writeTask = Task.Factory.StartNew(this.WriteMessage);

                        readTask.Wait();
                        writeTask.Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
        
                public void SendIrcMessage(string message)
                {
                    try
                    {
                        _outputStream.WriteLine(message);
                        _outputStream.Flush();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
        
                public void SendPublicChatMessage(string message)
                {
                    try
                    {
                        SendIrcMessage(":" + userName + "!" + userName + "@" + userName +
                        ".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
        
                public void ReadMessage()
                {
                    while (true)
                    {
                        Console.WriteLine(_inputStream.ReadLine());                        
                    }
                }
                
                public string WriteMessage()
                {
                    while (true)
                    {
                        _outputStream.WriteLine(Console.ReadLine());
                        _outputStream.Flush();
                    }
                }
            }
    }