using System;
using IrcClient.Commands;
using StreamBotCsharp.Handlers;

namespace StreamBotCsharp.Drivers
{
    using StreamBotConfig.Configs;

    using IrcClient = IrcClient.IrcClient;

    public class TwitchDriver : IDriver
    {
        private const string TwitchIrcAddress = "irc.twitch.tv";

        private const int TwitchPort = 6667;

        private IrcClient _ircClient;

        private readonly CommandHandler _commandHandler;

        private readonly Config _config;

        private bool _isPrepared = false;

        public TwitchDriver(Config config)
        {
            this._config = config;
            this._commandHandler = new CommandHandler(config);
        }

        public void Prepare()
        {
            this._ircClient =
                new IrcClient(
                    TwitchIrcAddress,
                    TwitchPort,
                    this._config.Credentials.Username,
                    this._config.Credentials.Channel,
                    this._config.Credentials.Password,
                    this._commandHandler.HandleUserCommands
                );

            this._isPrepared = true;
        }

        public void Start()
        {
            if (!this._isPrepared)
            {
                Console.WriteLine("Can't start Twitch driver - prepare not run.");
            }

            this._ircClient.Start();
        }
    }
}