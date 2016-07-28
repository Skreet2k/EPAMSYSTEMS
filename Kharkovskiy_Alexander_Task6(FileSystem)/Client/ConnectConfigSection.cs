
using System.Configuration;

namespace Client
{
    internal class ConnectConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("port")]
        public int Port
        {
            get
            {
                var str = (base["port"]).ToString();
                return int.Parse(str);
            }
        }
        [ConfigurationProperty("serverAdress")]
        public string ServerAdress
        {
            get
            {
                return (base["serverAdress"]).ToString();            
            }
        }
    }
}
