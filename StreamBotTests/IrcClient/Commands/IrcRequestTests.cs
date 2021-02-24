namespace StreamBotTests.IrcClient.Commands
{
    #region Usings

    using System;
    
    using global::IrcClient.Commands.Enums;
    using global::IrcClient.Commands.Requests;
    
    using Xunit;

    #endregion
    
    public class IrcRequestTests
    {
        [Fact]
        public void EmptyCtorEmptyRawData()
        {
            IrcRequest request = new IrcRequest();
            
            Assert.Equal(string.Empty, request.RawData);
        }
        
        [Fact]
        public void UnspecifiedCommandTypEmptyRawData()
        {
            IrcRequest request = new IrcRequest();
            
            Assert.Equal(CommandTypeEnum.Unspecified, request.CommandType);
        }
        
        [Fact]
        public void GetCommandTypeFromRawData()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            
            Assert.Equal(CommandTypeEnum.PING, request.CommandType);
        }
                
        [Fact]
        public void UpdateRawDataByCommandType()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            const string expectedRawData = "PONG :tmi.twitch.tv";
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            request.CommandType = CommandTypeEnum.PONG;
            
            Assert.Equal(expectedRawData, request.RawData);
        }
                
        [Fact]
        public void UpdateCommandType()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PONG;
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            request.CommandType = expectedCommandType;
            
            Assert.Equal(expectedCommandType, request.CommandType);
        }
        
        [Fact]
        public void PayloadIndexPositive()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            const int expectedPayloadIndex = 5;
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            
            Assert.Equal(expectedPayloadIndex, request.PayloadIndex);
        }
        
        [Fact]
        public void PayloadIndexNoPayload()
        {
            const int expectedPayloadIndex = 0;
            
            IrcRequest request = new IrcRequest();
            
            Assert.Equal(expectedPayloadIndex, request.PayloadIndex);
        }
        
        [Fact]
        public void GetPayloadFromCommand()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            const string expectedPayload = ":tmi.twitch.tv";
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            
            Assert.Equal(expectedPayload, request.Payload);
        }
        
        [Fact]
        public void EmptyRawDataEmptyPayload()
        {
            IrcRequest request = new IrcRequest();
            
            Assert.Equal(string.Empty, request.Payload);
        }
        
        [Fact]
        public void UpdatePayload()
        {
            const string exampleRequestRawData = "PING :tmi.twitch.tv";
            const string expectedPayload = ":newPayloadData";
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            request.Payload = expectedPayload;
            
            Assert.Equal(expectedPayload, request.Payload);
        }
        
        [Fact]
        public void SetNewPayloadFromEmptyRawData()
        {
            const string examplePayload = ":examplePayloadData";
            const string expectedRawData = " :examplePayloadData";
            
            IrcRequest request = new IrcRequest();
            request.Payload = examplePayload;
            
            Assert.Equal(expectedRawData, request.RawData);
        }
        
        [Fact]
        public void NoCommandTypePayloadIndex()
        {
            const string exampleRequestRawData = " :examplePayloadData";
            const int expectedPayloadIndex = 1;
            
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            
            Assert.Equal(expectedPayloadIndex, request.PayloadIndex);
        }
        
        [Fact]
        public void NoTypeRawDataWithCapitalLetters()
        {
            const string exampleRequestRawData = " :example PAYLOAD data";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.Unspecified;
            IrcRequest request = new IrcRequest(exampleRequestRawData);
            
            Assert.Equal(expectedCommandType, request.CommandType);
        }
        
        [Fact]
        public void CreateRequestWithoutSpecifyingRawData()
        {
            const string expectedRawData = "PING :tmi.twitch.tv";
            const int expectedPayloadIndex = 5;
            const int expectedCommandTypeIndex = 0;
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PING;
            const string expectedPayload = ":tmi.twitch.tv";
            
            IrcRequest request = new IrcRequest();
            request.Payload = expectedPayload;
            request.CommandType = expectedCommandType;
            
            Assert.Equal(expectedPayloadIndex, request.PayloadIndex);
            Assert.Equal(expectedCommandTypeIndex, request.CommandTypeIndex);
            Assert.Equal(expectedPayload, request.Payload);
            Assert.Equal(expectedCommandType, request.CommandType);
            Assert.Equal(expectedRawData, request.RawData);
        }
    }
}