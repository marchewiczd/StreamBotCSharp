namespace StreamBotConfig.Configs.ConfigNodes
{
    #region Usings

    using System.Xml.Serialization;

    #endregion

    public class TextCommand
    {
        #region Properties

        [XmlAttribute]
        public string Trigger { get; set; }

        [XmlAttribute]
        public string Answer { get; set; }

        #endregion
    }
}
