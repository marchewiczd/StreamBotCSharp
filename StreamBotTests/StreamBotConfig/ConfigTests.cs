using StreamBotConfig.Configs;
using Xunit;

namespace StreamBotTests.StreamBotConfig
{
    public class ConfigTests
    {
        [Fact]
        public void DeserializerDirectoryNotFound()
        {
            Config conf = Config.Deserialize("./NonExistentFolder1111/Config.xml");

            Assert.Null(conf);
        }

        [Fact]
        public void DeserializerFileNotFound()
        {
            Config conf = Config.Deserialize("./NonExistentConf.xml");

            Assert.Null(conf);
        }

        [Fact]
        public void DeserializeFileFound()
        {
            Config conf = Config.Deserialize("Config.xml");

            Assert.NotNull(conf);
        }
    }
}
