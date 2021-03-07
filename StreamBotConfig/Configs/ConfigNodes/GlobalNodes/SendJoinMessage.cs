namespace StreamBotConfig.Configs.ConfigNodes.GlobalNodes
{
    #region Usings

    using System.Xml.Serialization;

    #endregion

    public class SendJoinMessage
    {
        #region Properties

        [XmlText]
        public string Value { get; set; }

        [XmlAttribute]
        public string Text { get; set; }

        #endregion
    }
}
