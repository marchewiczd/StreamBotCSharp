using StreamBotConfig.Configs;

namespace StreamBotCsharp.Drivers
{
    public class YouTubeDriver : IDriver
    {
        private Config _config;

        public YouTubeDriver(Config config)
        {
            this._config = config;
        }

        public void Prepare()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}