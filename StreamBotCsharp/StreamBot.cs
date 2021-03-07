using StreamBotConfig.Configs;
using StreamBotCsharp.Drivers;
using StreamBotCsharp.Factories;

namespace StreamBotCsharp
{
    public class StreamBot
    {
        private static IDriver _driver;

        static void Main(string[] args)
        {
            Config = Config.Deserialize();
            _driver = DriverFactory.Create(Config);

            _driver.Prepare();
            _driver.Start();
        }

        public static Config Config { get; set; }
    }
}