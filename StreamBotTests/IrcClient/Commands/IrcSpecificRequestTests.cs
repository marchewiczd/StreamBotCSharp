namespace StreamBotTests.IrcClient.Commands
{
    #region Usings

    using System;
    
    using global::IrcClient.Commands.Enums;
    using global::IrcClient.Commands.Requests;
    
    using Xunit;

    #endregion
    
    public class IrcSpecificRequestTests
    {
        [Fact]
        public void JoinVerifyProperties()
        {
            const string expectedRawData = "JOIN #examplechannel";
            const string expectedChannel = "examplechannel";
            const int expectedChannelindex = 6;
            const string expectedPayload = "#examplechannel";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.JOIN;
            const int expectedPayloadIndex = 5;
            const int expectedCommandTypeIndex = 0;
            
            IrcJoinRequest joinRequest = new IrcJoinRequest(expectedChannel);
            
            Assert.Equal(expectedRawData, joinRequest.RawData);
            Assert.Equal(expectedPayload, joinRequest.Payload);
            Assert.Equal(expectedPayloadIndex, joinRequest.PayloadIndex);
            Assert.Equal(expectedCommandType, joinRequest.CommandType);
            Assert.Equal(expectedCommandTypeIndex, joinRequest.CommandTypeIndex);
            Assert.Equal(expectedChannel, joinRequest.Channel);
            Assert.Equal(expectedChannelindex, joinRequest.ChannelIndex);
        }
        
        [Fact]
        public void PingVerifyProperties()
        {
            const string expectedRawData = "PING :tmi.twitch.tv";
            const int expectedPayloadIndex = 5;
            const int expectedCommandTypeIndex = 0;
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PING;
            const string expectedPayload = ":tmi.twitch.tv";

            IrcPingRequest pingRequest = new IrcPingRequest();
            
            Assert.Equal(expectedPayloadIndex, pingRequest.PayloadIndex);
            Assert.Equal(expectedCommandTypeIndex, pingRequest.CommandTypeIndex);
            Assert.Equal(expectedPayload, pingRequest.Payload);
            Assert.Equal(expectedCommandType, pingRequest.CommandType);
            Assert.Equal(expectedRawData, pingRequest.RawData);
        }
        
        [Fact]
        public void PartVerifyProperties()
        {
            const string expectedRawData = "PART #examplechannel";
            const string expectedChannel = "examplechannel";
            const int expectedChannelindex = 6;
            const string expectedPayload = "#examplechannel";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PART;
            const int expectedPayloadIndex = 5;
            const int expectedCommandTypeIndex = 0;
            
            IrcPartRequest partRequest = new IrcPartRequest(expectedChannel);
            
            Assert.Equal(expectedRawData, partRequest.RawData);
            Assert.Equal(expectedPayload, partRequest.Payload);
            Assert.Equal(expectedPayloadIndex, partRequest.PayloadIndex);
            Assert.Equal(expectedCommandType, partRequest.CommandType);
            Assert.Equal(expectedCommandTypeIndex, partRequest.CommandTypeIndex);
            Assert.Equal(expectedChannel, partRequest.Channel);
            Assert.Equal(expectedChannelindex, partRequest.ChannelIndex);
        }
        
        [Fact]
        public void PrivmsgVerifyProperties()
        {
            const string expectedRawData = "PRIVMSG #examplechannel :example message text";
            const string expectedChannel = "examplechannel";
            const int expectedChannelindex = 9;
            const string expectedMessage = "example message text";
            const int expectedMessageIndex = 25;
            const string expectedPayload = "#examplechannel :example message text";
            const CommandTypeEnum expectedCommandType = CommandTypeEnum.PRIVMSG;
            const int expectedPayloadIndex = 8;
            const int expectedCommandTypeIndex = 0;
            
            IrcPrivmsgRequest privmsgRequest = new IrcPrivmsgRequest(expectedChannel, expectedMessage);
            
            Assert.Equal(expectedRawData, privmsgRequest.RawData);
            Assert.Equal(expectedPayload, privmsgRequest.Payload);
            Assert.Equal(expectedPayloadIndex, privmsgRequest.PayloadIndex);
            Assert.Equal(expectedCommandType, privmsgRequest.CommandType);
            Assert.Equal(expectedCommandTypeIndex, privmsgRequest.CommandTypeIndex);
            Assert.Equal(expectedChannel, privmsgRequest.Channel);
            Assert.Equal(expectedChannelindex, privmsgRequest.ChannelIndex);
            Assert.Equal(expectedMessage, privmsgRequest.Message);
            Assert.Equal(expectedMessageIndex, privmsgRequest.MessageIndex);
        }
        
        [Fact]
        public void PrivmsgCheckMsgIndexAfterChannelUpdate()
        {
            const string exampleChannel = "examplechannel";
            const string expectedChannel = "channel";
            const string expectedMessage = "example message text";
            const int expectedMessageIndex = 18;
            
            IrcPrivmsgRequest privmsgRequest = new IrcPrivmsgRequest(exampleChannel, expectedMessage);
            privmsgRequest.Channel = expectedChannel;
            
            Assert.Equal(expectedChannel, privmsgRequest.Channel);
            Assert.Equal(expectedMessageIndex, privmsgRequest.MessageIndex);
        }
        
        [Fact]
        public void PrivmsgUpdateMessage()
        {
            const string exampleChannel = "examplechannel";
            const string exampleMessage = "example message text";
            const string expectedMessage = "new expected message";
            const string expectedRawData = "PRIVMSG #examplechannel :new expected message";
            
            IrcPrivmsgRequest privmsgRequest = new IrcPrivmsgRequest(exampleChannel, exampleMessage);
            privmsgRequest.Message = expectedMessage;
            
            Assert.Equal(expectedMessage, privmsgRequest.Message);
            Assert.Equal(expectedRawData, privmsgRequest.RawData);
        }
    }
}