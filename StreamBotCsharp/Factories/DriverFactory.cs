using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamBotConfig.Configs;
using StreamBotCsharp.Drivers;
using StreamBotCsharp.Enums;

namespace StreamBotCsharp.Factories
{
    public class DriverFactory
    {
        public static IDriver Create(Config config)
        {
            if (!Enum.TryParse(config.Credentials.Platform, out PlatformEnum platform))
            {
                Console.WriteLine("Failed to recognize platform, switching to default Twitch");
            }

            return platform switch
            {
                PlatformEnum.YouTube => new YouTubeDriver(config),
                PlatformEnum.Twitch => new TwitchDriver(config),
                _ => null
            };
        }
    }
}
