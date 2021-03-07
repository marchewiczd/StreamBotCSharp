namespace StreamBotConfig.Configs
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;

    using ConfigNodes;

    #endregion

    public class Config
    {
        #region Fields and Constants

        [XmlIgnore]
        private static readonly string DefaultPath = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)}\\Config.xml";

        #endregion

        #region Properties

        public List<TextCommand> TextCommands { get; set; }

        public Global Global { get; set; }

        public Credentials Credentials { get; set; }

        #endregion

        #region Static Methods

        public static Config Deserialize(string fullConfigPath = null)
        {
            string path = fullConfigPath ?? DefaultPath;

            XmlSerializer serializer = new XmlSerializer(typeof(Config));

            try
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    return serializer.Deserialize(stream) as Config;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Cannot open {path}. File not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Cannot find {path}. Directory not found!");
            }

            return null;
        }

        #endregion
    }
}
