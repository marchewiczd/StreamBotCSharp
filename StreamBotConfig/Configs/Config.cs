using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StreamBotConfig.Configs.ConfigNodes;

namespace StreamBotConfig.Configs
{
    public class Config
    {
        public List<TextCommand> TextCommands { get; set; }

        public Global Global { get; set; }

        public Credentials Credentials { get; set; }
    }
}
