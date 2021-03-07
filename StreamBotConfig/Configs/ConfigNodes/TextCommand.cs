using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StreamBotConfig.Configs.ConfigNodes
{
    public class TextCommand
    {
        [XmlAttribute]
        public string Trigger { get; set; }

        [XmlAttribute]
        public string Answer { get; set; }
    }
}
