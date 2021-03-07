using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StreamBotConfig.Configs.ConfigNodes.GlobalNodes;

namespace StreamBotConfig.Configs.ConfigNodes
{
    public class Global
    {
        public bool AllowModAddCommand { get; set; }

        public SendJoinMessage SendJoinMessage { get; set; }

    }
}
