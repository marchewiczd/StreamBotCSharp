using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StreamBotConfig.Configs.ConfigNodes;

namespace StreamBotConfig.Configs
{
    public class Config
    {
        [XmlIgnore]
        private static readonly string DefaultPath = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)}\\Config.xml";


        public List<TextCommand> TextCommands { get; set; }

        public Global Global { get; set; }

        public Credentials Credentials { get; set; }


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

            return null;
        }
    }
}
