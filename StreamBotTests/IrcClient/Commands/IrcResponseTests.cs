using IrcClient.Commands.Enums;
using IrcClient.Commands.Responses;
using Xunit;

namespace StreamBotTests.IrcClient.Commands
{
    public class IrcResponseTests
    {
        [Fact]
        public void EmptyCtorEmptyRawData()
        {
            IrcResponse response = new IrcResponse();
            
            Assert.Equal(string.Empty, response.RawData);
        }
        
        [Fact]
        public void UnspecifiedCommandTypEmptyRawData()
        {
            IrcResponse response = new IrcResponse();
            
            Assert.Equal(CommandTypeEnum.Unspecified, response.CommandType);
        }
                
        [Fact]
        public void UpdateRawDataByCommandType()
        {
            const string exampleRawData = "PING :tmi.twitch.tv";
            const string expectedRawData = "PONG :tmi.twitch.tv";
            
            IrcResponse response = new IrcResponse(exampleRawData);
            response.CommandType = CommandTypeEnum.PONG;
            
            Assert.Equal(expectedRawData, response.RawData);
        }
                
        [Fact]
        public void UpdateCommandType()
        {
            const string exampleRawData = "PING :tmi.twitch.tv";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PONG;
            
            IrcResponse response = new IrcResponse(exampleRawData);
            response.CommandType = expectedCommandType;
            
            Assert.Equal(expectedCommandType, response.CommandType);
        }
        
        [Fact]
        public void PayloadIndexPositive()
        {
            const string exampleRawData = "PONG :tmi.twitch.tv";
            const int expectedPayloadIndex = 5;
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedPayloadIndex, response.PayloadIndex);
        }
        
        [Fact]
        public void PayloadIndexNoPayload()
        {
            const int expectedPayloadIndex = 0;
            IrcResponse response = new IrcResponse();
            
            Assert.Equal(expectedPayloadIndex, response.PayloadIndex);
        }
        
        [Fact]
        public void GetPayloadFromCommand()
        {
            const string exampleRawData = "PONG :tmi.twitch.tv";
            const string expectedPayload = ":tmi.twitch.tv";
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedPayload, response.Payload);
        }
        
        [Fact]
        public void EmptyRawDataEmptyPayload()
        {
            IrcResponse response = new IrcResponse();
            
            Assert.Equal(string.Empty, response.Payload);
        }
        
        [Fact]
        public void UpdatePayload()
        {
            const string exampleRawData = "PONG :tmi.twitch.tv";
            const string expectedPayload = ":newPayloadData";
            
            IrcResponse response = new IrcResponse(exampleRawData);
            response.Payload = expectedPayload;
            
            Assert.Equal(expectedPayload, response.Payload);
        }
        
        [Fact]
        public void SetNewPayloadFromEmptyRawData()
        {
            const string examplePayload = ":examplePayloadData";
            const string expectedRawData = " :examplePayloadData";
            
            IrcResponse response = new IrcResponse();
            response.Payload = examplePayload;
            
            Assert.Equal(expectedRawData, response.RawData);
        }
        
        [Fact]
        public void NoCommandTypePayloadIndex()
        {
            const string exampleRawData = " :examplePayloadData";
            const int expectedPayloadIndex = 1;
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedPayloadIndex, response.PayloadIndex);
        }
        
        [Fact]
        public void NoTypeRawDataWithCapitalLetters()
        {
            const string exampleRawData = " :example PAYLOAD data";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.Unspecified;
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedCommandType, response.CommandType);
        }
        
        [Fact]
        public void GetCommandTypeFromEmptyRawData()
        {
            IrcResponse response = new IrcResponse();
            
            Assert.Equal(CommandTypeEnum.Unspecified, response.CommandType);
        }
        
        [Fact]
        public void GetChannelFromRawDataPrivmsgCommand()
        {
            const string exampleRawData = ":<user>!<user>@<user>.tmi.twitch.tv PRIVMSG #examplechannel :This is a sample message";
            const string expectedChannel = "examplechannel";
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedChannel, response.Channel);
        }
        
        
        [Fact]
        public void VerifyServerAddress()
        {
            const string exampleRawData = ":<user>!<user>@<user>.tmi.twitch.tv PRIVMSG #examplechannel :This is a sample message";
            const string expectedAddress = "tmi.twitch.tv";
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedAddress, response.ServerAddress);
        }
        
        
        [Fact]
        public void VerifyServerAddressLength()
        {
            const string exampleRawData = ":<user>!<user>@<user>.tmi.twitch.tv PRIVMSG #examplechannel :This is a sample message";
            const int expectedLength = 13;
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedLength, response.ServerAddressLength);
        }
        
        
        [Fact]
        public void VerifyServerAddressIndex()
        {
            const string exampleRawData = ":<user>!<user>@<user>.tmi.twitch.tv PRIVMSG #examplechannel :This is a sample message";
            const int expectedIndex = 22;
            
            IrcResponse response = new IrcResponse(exampleRawData);
            
            Assert.Equal(expectedIndex, response.ServerAddressIndex);
        }
    }
}