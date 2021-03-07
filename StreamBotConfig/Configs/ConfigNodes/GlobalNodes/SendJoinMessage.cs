using System.Xml.Serialization;

namespace StreamBotConfig.Configs.ConfigNodes.GlobalNodes
{
    public class SendJoinMessage
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute]
        public string Text { get; set; }
    }
}
