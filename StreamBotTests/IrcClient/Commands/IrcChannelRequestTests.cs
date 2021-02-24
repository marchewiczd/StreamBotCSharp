using IrcClient.Commands.Requests;
using Xunit;

namespace StreamBotTests.IrcClient.Commands
{
    public class IrcChannelRequestTests
    {
        [Fact]
        public void GetChannelFromRawDataJoinCommand()
        {
            const string exampleRequestRawData = "JOIN #examplechannel";
            const string expectedChannel = "examplechannel";
            
            IrcChannelRequest request = new IrcChannelRequest(exampleRequestRawData);
            
            Assert.Equal(expectedChannel, request.Channel);
        }
        
        [Fact]
        public void GetChannelFromRawDataPrivmsgCommand()
        {
            const string exampleRequestRawData = "PRIVMSG #examplechannel :Example text";
            const string expectedChannel = "examplechannel";
            
            IrcChannelRequest request = new IrcChannelRequest(exampleRequestRawData);
            
            Assert.Equal(expectedChannel, request.Channel);
        }
    }
}